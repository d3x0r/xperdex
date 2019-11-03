/**************************************************************************//**
 * @file    DirectShowWindowApp.cpp
 *
 * @brief   Class used to control this application.
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
 * DirectShowWindowApp Specific Includes
 *****************************************************************************/
#include "stdafx.h"
#include "DirectShowWindowApp.hpp"

// Windows Specific Includes
#include <Windows.h>
#include <ShlObj.h>
#include <WinSock2.h>

// C++ API Specific Includes
#include <memory>

// App Specific Includes
#include "DirectShowTunerWindow.hpp"
#include "Global.hpp"
#include "../SocketCom/UDPCommandListener.hpp"
#include "IniSettingRepository.hpp"

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * DirectShowWindowApp Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   DirectShowWindowApp ( )                                          */
/** @brief  DirectShowWindowApp Class Constructor.
 *****************************************************************************/
DirectShowWindowApp::DirectShowWindowApp( HINSTANCE hInstance,
                                          const wstring& commandLine,
                                          int cmdShow ) :
    m_hInstance(hInstance),
    m_commandLine(commandLine),
    m_cmdShow(cmdShow)
{
    // Initialize windows sockets version 2.2
    WSADATA wsaData;
    const WORD wVersionRequested = MAKEWORD(2, 2);
    WSAStartup(wVersionRequested, &wsaData);

} // End DirectShowWindowApp::DirectShowWindowApp

/******************************************************************************
 *  @name   ~DirectShowWindowApp ( )                                         */
/** @brief  DirectShowWindowApp Class Destructor.
 *****************************************************************************/
DirectShowWindowApp::~DirectShowWindowApp( )
{
    // Cleanup our windows sockets.
    WSACleanup();

} // End DirectShowWindowApp::~DirectShowWindowApp

/******************************************************************************
 *  @name   Run ( )                                                          */
/** @brief  Runs this application and returns the result to the system.
 *****************************************************************************/
int DirectShowWindowApp::Run( )
{
    int returnCode = ERROR_SUCCESS;

    try
    {
        Global::LogString(L"\n\nStarting Application\n");

        // Close any previous instances of this application
        Global::CheckForMultipleInstances();

        // Set high priority process
        SetPriorityClass(GetCurrentProcess(), HIGH_PRIORITY_CLASS);

        // Setup settings repository
        wstring iniFilePath;
        wchar_t tmpStr[MAX_PATH];
        if (SHGetSpecialFolderPath(nullptr, tmpStr, CSIDL_COMMON_APPDATA, TRUE) == TRUE)
        {
            iniFilePath.append(&tmpStr[0], &tmpStr[0] + wcslen(tmpStr));
        }
        else 
        { 
            GetCurrentDirectory(MAX_PATH, tmpStr);
            iniFilePath.append(&tmpStr[0], &tmpStr[0] + wcslen(tmpStr));
        }
        wstring::size_type pos = iniFilePath.find_last_not_of(L"\\/");
        iniFilePath.erase(pos + 1);
        iniFilePath.append(L"/xperdex/xperdex.ini");

        Global::LogString(L"Initializing ini file at: ");
        Global::LogString(iniFilePath.c_str());
        Global::LogString(L"\n");
        Global::g_settingRepository = make_shared<IniSettingRepository>(iniFilePath);

        // Create the DirectShow TV Tuner Window and display the window
        const shared_ptr<DirectShowTunerWindow> tunerWindow = 
            make_shared<DirectShowTunerWindow>(m_hInstance, m_commandLine, m_cmdShow);
        tunerWindow->DisplayWindow();

        // Initialize Tuner Defaults
        RECT rc;
        rc.left = 0;
        rc.right = rc.left + 149;
        rc.top = 0;
        rc.bottom = rc.top + 149;
        tunerWindow->Position(rc);

        tunerWindow->Channel(4);
        tunerWindow->Volume(100);
        SetupDefaultInitialStates(tunerWindow);                                  

        // Run the window
        tunerWindow->Run();      

        // Initialize the network subsystem.
        const shared_ptr<UDPCommandListener> udpSocket =
            make_shared<UDPCommandListener>(tunerWindow);
        udpSocket->Initialize();

        // Wait for window to close
        const HANDLE waitHandle = tunerWindow->GetWaitHandle();
        if (waitHandle != INVALID_HANDLE_VALUE)
            WaitForSingleObject(waitHandle, INFINITE);

        // Shutdown our socket
        udpSocket->Shutdown();
    }
    catch(runtime_error& e)
    { 
        // Log our exception and return error condition
        wstring errorStr(e.what(), e.what() + strlen(e.what()));
        errorStr.append(L"\n");
        Global::LogString(errorStr);

        returnCode = ERROR_BAD_COMMAND; 
    }

    // Return results
    return returnCode;

} // End DirectShowWindowApp::Run

/******************************************************************************
 *  @name   SetupDefaultInitialStates ( )                                    */
/** @brief  Sets up the default initial states for this player
 *****************************************************************************/
void DirectShowWindowApp::SetupDefaultInitialStates( const shared_ptr<DirectShowTunerWindow> tunerWindow )
{
    if (!tunerWindow) return;

    bool bVal = false;

    // Write defaults to the repository (first time only)
    if (Global::g_settingRepository)
    {
        wchar_t sTmp[MAX_PATH];
        int nTmp = tunerWindow->GetMaximumChannel();
        swprintf_s(sTmp, L"%d", nTmp);
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Maximum Channel", sTmp);

        nTmp = tunerWindow->GetMinimumChannel();
        swprintf_s(sTmp, L"%d", nTmp);
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Minimum Channel", sTmp);    

        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Initial X Position", L"0");
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Initial Y Position", L"0");
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Initial Width", L"640");
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Initial Height", L"480");
    }

    // Setup the tuner window source    
    TVTUNER_SOURCETYPE tunerSource = TUNERSOURCE_TUNER;
    if (Global::g_settingRepository && 
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Capture Tuner", bVal) &&
        !bVal) tunerSource = TUNERSOURCE_COMPOSITE;
    tunerWindow->Source(tunerSource);

    // Setup the capture mode to antenna (if commanded)
    TVTUNER_INPUTTYPE inputType = TUNERTYPE_ANTENNA;
    if (tunerSource == TUNERSOURCE_TUNER &&
        Global::g_settingRepository &&
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Tuner from Antenna", bVal) &&
        !bVal) inputType = TUNERTYPE_CABLE;
    if (tunerSource == TUNERSOURCE_TUNER)
        tunerWindow->Input(inputType);

    // Setup the initial window position
    int xPos = -1, yPos = -1, width = -1, height = -1;
    if (Global::g_settingRepository &&
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Initial X Position", xPos) &&
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Initial Y Position", yPos) &&
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Initial Width", width) &&
        Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Initial Height", height))
    {
        if (xPos >= 0 &&
            yPos >= 0 &&
            width > 0 &&
            height > 0)
        {
            RECT position;
            position.left = xPos;
            position.top = yPos;
            position.right = position.left + width;
            position.bottom = position.top + height;

            tunerWindow->Position(position);
        }
    }

} // End DirectShowWindowApp::SetupDefaultInitialStates