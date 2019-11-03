/**************************************************************************//**
 * @file    UDPCommandListener.cpp
 *
 * @brief   Object that listens for UDP commands
 *
 *          Change History
 *          -----------------
 *          d3x0r - 09/28/2011
 *              Initial Revision
 *
 *          This is an unpublished work protected under the copyright laws 
 *          of the United States and other countries.  All rights reserved.  
 *          Should publication occur the following will apply:  
 *          © 2011 Freedom Collective
 *
 *****************************************************************************/

/******************************************************************************
 * UDPCommandListener Specific Includes
 *****************************************************************************/
#include "stdafx.h"
#include "UDPCommandListener.hpp"

// C++ API Specific Includes
#include <stdexcept>
#include <time.h>
#include <vector>

// App Specific Includes
#include "../General/Global.hpp"
#include "../General/ITunerWindow.hpp"
#include "../General/ISettingRepository.hpp"

using namespace std;
using namespace Xperdex::TvWindow;

#pragma comment (lib, "Ws2_32.lib")

/******************************************************************************
 * UDPCommandListener Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   UDPCommandListener ( )                                           */
/** @brief  UDPCommandListener Class Constructor.
 *****************************************************************************/
UDPCommandListener::UDPCommandListener( shared_ptr<ITunerWindow> window ) :
    m_sock(INVALID_SOCKET),
    m_thread(INVALID_HANDLE_VALUE),
    m_window(window),
    m_lastTick(0xFCFCFCFC)
{
    m_shutdownEvent = WSACreateEvent();

} // End UDPCommandListener::UDPCommandListener

/******************************************************************************
 *  @name   ~UDPCommandListener ( )                                          */
/** @brief  UDPCommandListener Class Destructor.
 *****************************************************************************/
UDPCommandListener::~UDPCommandListener( )
{
    WSACloseEvent(m_shutdownEvent);

} // End UDPCommandListener::~UDPCommandListener

/******************************************************************************
 *  @name   StaticDataReceiveThreadProc ( )                                  */
/** @brief  Thread procedure for data retreival
 *****************************************************************************/
DWORD WINAPI UDPCommandListener::StaticDataReceiveThreadProc(LPVOID lpParameter)
{
    // Get a pointer to our command object
    UDPCommandListener *const commandListener = reinterpret_cast<UDPCommandListener*>(lpParameter);
    commandListener->DataReceiveThreadWorker();

    // Return success (not checked at this time)
    return ERROR_SUCCESS;

} // End StaticDataReceiveThreadProc

/******************************************************************************
 *  @name   Initialize ( )                                                   */
/** @brief  Initializes this listener.
 *****************************************************************************/
void UDPCommandListener::Initialize( )
{
    // Create our socket object
    m_sock = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    if (m_sock == INVALID_SOCKET) throw runtime_error("Failed to open new socket listener");

    // Enable broadcast support on this socket
    const BOOL enableBroadcast = TRUE;
    if (setsockopt(m_sock, SOL_SOCKET, SO_BROADCAST, reinterpret_cast<const char*>(&enableBroadcast), sizeof(BOOL)) == SOCKET_ERROR)
        throw runtime_error("Failed to set broadcast socket options");

    // Enable reuse of port
    const BOOL reuseAddr = TRUE;
    setsockopt(m_sock, SOL_SOCKET, SO_REUSEADDR, reinterpret_cast<const char*>(&reuseAddr), sizeof(BOOL));

    memset(&m_recvFrom, 0, sizeof(m_recvFrom));
    m_recvFrom.sin_family = AF_INET;
    m_recvFrom.sin_port = htons((unsigned short)2998);
    m_recvFrom.sin_addr.s_addr = inet_addr("127.0.0.1");

    // Get our listen address
    wstring listenAddress = L"127.0.0.1";
    if (Global::g_settingRepository)
    {
        Global::g_settingRepository->SetSettingDefault(L"Network", L"Video Player/Receiver Address", listenAddress);
        Global::g_settingRepository->GetSetting(L"Network", L"Video Player/Receiver Address", listenAddress);
    }

    // Get our listen port
    int listenPort = 2999;
    if (Global::g_settingRepository)
    {
        Global::g_settingRepository->SetSettingDefault(L"Network", L"Video Player/Receiver Port", L"2999");
        Global::g_settingRepository->GetSetting(L"Network", L"Video Player/Receiver Port", listenPort);
    }

    // Get our minimum allowable channel
    auto window = m_window.lock();
    if (!window) throw runtime_error("Failed to access our window");;
    m_minChannel = window->GetMinimumChannel();
    if (Global::g_settingRepository)
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Minimum Channel", m_minChannel);

    m_maxChannel = window->GetMaximumChannel();
    if (Global::g_settingRepository)
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Maximum Channel", m_maxChannel);

    // Bind to our global ip address
    SOCKADDR_IN udpListenAddr;
    memset(&udpListenAddr, 0, sizeof(udpListenAddr));
    udpListenAddr.sin_family = AF_INET;
    udpListenAddr.sin_port = htons((unsigned short)listenPort);
    string ansiAddr(listenAddress.begin(), listenAddress.end());
    udpListenAddr.sin_addr.s_addr = inet_addr(ansiAddr.c_str());
    if (bind(m_sock, (SOCKADDR*)&udpListenAddr, sizeof(SOCKADDR_IN)) == SOCKET_ERROR)
        throw runtime_error("Failed to bind to listen address");

    // Create Data Receive Thread
    m_thread = CreateThread(nullptr,
                            0,
                            StaticDataReceiveThreadProc,
                            this,
                            0,
                            nullptr);

    Sleep(2000);
    SendClientUpdateMessage();

} // End UDPCommandListener::Initialize

/******************************************************************************
 *  @name   Shutdown ( )                                                     */
/** @brief  Shuts down this listener.
 *****************************************************************************/
void UDPCommandListener::Shutdown( )
{
    if (m_sock != INVALID_SOCKET)
        closesocket(m_sock);
    m_sock = INVALID_SOCKET;

    WSASetEvent(m_shutdownEvent);
    WaitForSingleObject(m_thread, INFINITE);

} // End UDPCommandListener::Shutdown

/******************************************************************************
 *  @name   DataReceiveThreadWorker ( )                                      */
/** @brief  The main thread procedure for this 
 *****************************************************************************/
void UDPCommandListener::DataReceiveThreadWorker( )
{  
    try
    {
        static const int DATA_BUFSIZE = 4096;

        DWORD recvBytes = 0;
        DWORD flags = 0;
        sockaddr_in from;
        int fromLen;

        WSABUF dataBuf;    
        char buffer[DATA_BUFSIZE];

        WSAEVENT eventArray[2];
        eventArray[0] = m_shutdownEvent;
        eventArray[1] = WSACreateEvent();

        // Setup our socket's overlapped structure
        WSAOVERLAPPED readOverlapped;
    
        // Read data over and over forever
        for(;;)
        {        
            // Setup our structs and prepare for a socket "read"
            dataBuf.len = DATA_BUFSIZE;
            dataBuf.buf = buffer;
            recvBytes = 0;
            flags = 0;
            fromLen = sizeof(sockaddr_in);
            memset(&readOverlapped, 0, sizeof(WSAOVERLAPPED));
            readOverlapped.hEvent = eventArray[1];

            // Attempt to read data from the socket
            if (WSARecvFrom(m_sock, &dataBuf, 1, &recvBytes, &flags, reinterpret_cast<sockaddr*>(&from), &fromLen, &readOverlapped, nullptr) == SOCKET_ERROR)
            {
                int error = WSAGetLastError();
                if (error != WSA_IO_PENDING)
                {
                    char errMsgStr[1024];
                    FormatMessageA(FORMAT_MESSAGE_FROM_SYSTEM, 0, error, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), errMsgStr, 1024, nullptr);

                    throw runtime_error(errMsgStr);
                }
            }

            // Wait for an event response
            DWORD eventId = WSAWaitForMultipleEvents(2, eventArray, FALSE, WSA_INFINITE, FALSE);

            // Reset the listen event that was signaled
            WSAResetEvent(eventArray[eventId - WSA_WAIT_EVENT_0]);

            // Shutdown time
            if (eventId == WSA_WAIT_EVENT_0) 
                break;

            // Data Received
            else if (eventId == (WSA_WAIT_EVENT_0 + 1))
            {            
                DWORD dwBytesTransferred;
                BOOL res = WSAGetOverlappedResult(m_sock, &readOverlapped, &dwBytesTransferred, FALSE, &flags);
                if (res == TRUE)
                {
                    if (dwBytesTransferred == 0)
                    {
                        throw runtime_error("Socket has been closed");
                    }
                    else
                    {
                        m_recvFrom = from;

                        wchar_t str[1024];
                        swprintf_s(str, L"Received a packet of %d bytes\n", dwBytesTransferred);
                        Global::LogString(str);

                        DataReceivedOnSocket(dataBuf.buf, dwBytesTransferred);
                    }
                }
                else
                {
                    // If application is shutting down, just return.
                    int errorCode = WSAGetLastError();
                    if (errorCode == ERROR_OPERATION_ABORTED)
                        return;
                }
            }
        }
    }
    catch(runtime_error& e)
    {
        wstring errorStr(e.what(), e.what() + strlen(e.what()));
        errorStr.append(L"\n");
        Global::LogString(errorStr);

        auto window = m_window.lock();
        if (window) window->CloseWindow();
    }

} // End UDPCommandListener::DataReceiveThreadWorker

/******************************************************************************
 *  @name   DataReceivedOnSocket ( )                                         */
/** @brief  Data has been received on this socket.  Do something with it.
 *****************************************************************************/
void UDPCommandListener::DataReceivedOnSocket( const char* buffer, unsigned long len )
{
    // Check for "quick out" (this tick same as last)
    if (len < sizeof(unsigned long)) return;
    if (m_lastTick == *((unsigned long*)buffer)) return;

    // Try to get a shared pointer to our notification window
    auto window = m_window.lock();
    if (!window) return;

    // Use a std::vector for easier data parsing.
    std::vector<const char> readBuffer(buffer, buffer+len);

    // Remove the "last tick"
    if (readBuffer.size() < sizeof(unsigned long)) return;
    unsigned long lastTick = *((unsigned long *)&readBuffer[0]);
    readBuffer.erase(readBuffer.begin(), readBuffer.begin() + sizeof(unsigned long));
    m_lastTick = lastTick;

    // Remove the "command"
    if (readBuffer.size() < sizeof(unsigned long)) return;
    unsigned long command = *((unsigned long*)&readBuffer[0]);
    readBuffer.erase(readBuffer.begin(), readBuffer.begin() + sizeof(unsigned long));

    switch(command)
    {
    case 0:
        {
            if (readBuffer.size() < sizeof(unsigned long)) return;
            unsigned long xPos = *((unsigned long*)&readBuffer[0]);
            readBuffer.erase(readBuffer.begin(), readBuffer.begin() + sizeof(unsigned long));

            if (readBuffer.size() < sizeof(unsigned long)) return;
            unsigned long yPos = *((unsigned long*)&readBuffer[0]);
            readBuffer.erase(readBuffer.begin(), readBuffer.begin() + sizeof(unsigned long));

            if (readBuffer.size() < sizeof(unsigned long)) return;
            unsigned long width = *((unsigned long*)&readBuffer[0]);
            readBuffer.erase(readBuffer.begin(), readBuffer.begin() + sizeof(unsigned long));

            if (readBuffer.size() < sizeof(unsigned long)) return;
            unsigned long height = *((unsigned long*)&readBuffer[0]);
            readBuffer.erase(readBuffer.begin(), readBuffer.begin() + sizeof(unsigned long));

            RECT windowPos;
            windowPos.left = xPos;
            windowPos.top = yPos;
            windowPos.right = xPos + width;
            windowPos.bottom = yPos + height;
            window->Position(windowPos);

            window->Visible(width > 2);

            wchar_t str[1024];
            swprintf_s(str, L"Command SetPosition (%d, %d, %d, %d)\n", xPos, yPos, width, height);
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 1:
        {
            int channel = window->Channel();
            --channel;
            if (channel < m_minChannel) channel = m_maxChannel;
            window->Channel(channel);

            wchar_t str[1024];
            swprintf_s(str, L"Command Channel Down\n");
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 2:
        {
            int channel = window->Channel();
            ++channel;
            if (channel > m_maxChannel) channel = m_minChannel;
            window->Channel(channel);

            wchar_t str[1024];
            swprintf_s(str, L"Command Channel Up\n");
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 3:
        {
            if (readBuffer.size() < sizeof(unsigned long)) return;
            unsigned long channel = *((unsigned long*)&readBuffer[0]);
            readBuffer.erase(readBuffer.begin(), readBuffer.begin() + sizeof(unsigned long));

            window->Channel((int)channel);

            wchar_t str[1024];
            swprintf_s(str, L"Command Set Channel %d\n", channel);
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 4:
        {
            int vol = window->Volume();
            vol = max(0, vol - 5);
            vol = ((int)(vol / 5) * 5);
            window->Volume(vol);

            wchar_t str[1024];
            swprintf_s(str, L"Command Volume Down\n");
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 5:
        {
            int vol = window->Volume();
            vol = min(100, vol + 5);
            vol = ((int)(vol / 5) * 5);
            window->Volume(vol);

            wchar_t str[1024];
            swprintf_s(str, L"Command Volume Up\n");
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 6:
        {
            window->Visible(false);

            wchar_t str[1024];
            swprintf_s(str, L"Command Hide\n");
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 7:
        {
            window->Stop();

            wchar_t str[1024];
            swprintf_s(str, L"Command Stop\n");
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;

    case 8:
        {
            window->Run();

            wchar_t str[1024];
            swprintf_s(str, L"Command Start\n");
            Global::LogString(str);

            SendClientUpdateMessage();
        }
        break;
    }

} // End UDPCommandListener::DataReceivedOnSocket

/******************************************************************************
 *  @name   SendClientUpdateMessage ( )                                      */
/** @brief  Notifies client of an update.
 *****************************************************************************/
void UDPCommandListener::SendClientUpdateMessage( )
{
    auto window = m_window.lock();
    if (!window) return;

    static bool initialSend = true;

    char msgData[25];
    char* dataPos = &msgData[0];
    unsigned long dataUsed = 0;

    long ticks = _time32(nullptr);
    memcpy(dataPos, &ticks, sizeof(long));
    dataPos += sizeof(long);
    dataUsed += sizeof(long);

    unsigned int tmpData = (initialSend ? 1 : 0);
    memcpy(dataPos, &tmpData, sizeof(unsigned int));
    dataPos += sizeof(unsigned int);
    dataUsed += sizeof(unsigned int);

    int channel = window->Channel();
    memcpy(dataPos, &channel, sizeof(int));
    dataPos += sizeof(int);
    dataUsed += sizeof(int);

    int volume = window->Volume();
    memcpy(dataPos, &volume, sizeof(int));
    dataPos += sizeof(int);
    dataUsed += sizeof(int);

    char on = (window->Running() ? 1 : 0);
    memcpy(dataPos, &on, sizeof(char));
    dataPos += sizeof(char);
    dataUsed += sizeof(char);

    sendto(m_sock, &msgData[0], dataUsed, 0, (const sockaddr*)&m_recvFrom, sizeof(sockaddr_in));

    initialSend  = false;

} // End UDPCommandListener::SendClientUpdateMessage