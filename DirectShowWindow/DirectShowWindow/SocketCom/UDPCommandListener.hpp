/**************************************************************************//**
 * @file    UDPCommandListener.hpp
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
#pragma once

/******************************************************************************
 * UDPCommandListener Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>
#include <WinSock2.h>

// C++ API Specific Includes
#include <memory>

namespace Xperdex {
namespace TvWindow {

class ITunerWindow;

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   UDPCommandListener
 * @brief   Object that listens for UDP commands
 *****************************************************************************/
class UDPCommandListener
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        UDPCommandListener          ( std::shared_ptr<ITunerWindow> window );
    virtual            ~UDPCommandListener          ( );

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    void                Initialize                  ( );
    void                Shutdown                    ( );    

    /**************************************************************************
     * Public Static Methods for this Class (callbacks)
     *************************************************************************/
    static DWORD WINAPI StaticDataReceiveThreadProc ( LPVOID lpParameter );

private:
    /**************************************************************************
     * Private Variables for this Class
     *************************************************************************/
    const std::weak_ptr<ITunerWindow>               m_window;

    SOCKET              m_sock;
    WSAEVENT            m_shutdownEvent;
    HANDLE              m_thread;
    unsigned long       m_lastTick;

    int                 m_minChannel;
    int                 m_maxChannel;

    sockaddr_in         m_recvFrom;

    /**************************************************************************
     * Private Methods for this Class
     *************************************************************************/    
    void                DataReceivedOnSocket        ( const char* buffer, unsigned long len );
    void                DataReceiveThreadWorker     ( );

    void                SendClientUpdateMessage     ( );

    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    UDPCommandListener(const UDPCommandListener& rhs);
    UDPCommandListener& operator=(const UDPCommandListener& rhs);

}; // End class UDPCommandListener

}}