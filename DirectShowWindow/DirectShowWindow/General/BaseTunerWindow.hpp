/**************************************************************************//**
 * @file    BaseTunerWindow.hpp
 *
 * @brief   Class used as the base to any window which controls a TV.
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
 * BaseTunerWindow Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>

// C++ API Specific Includes
#include <map>
#include <string>

// App Specific Includes
#include "ITunerWindow.hpp"

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   MediaFoundationTunerWindow
 * @brief   Class used to control the media foundation tuner window.
 *****************************************************************************/
class BaseTunerWindow : //public BaseTunerWindow,
                        public ITunerWindow
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        BaseTunerWindow                 ( HINSTANCE hInstance,
                                                          const std::wstring& commandLine,
                                                          int cmdShow );
    virtual            ~BaseTunerWindow                 ( ) = 0;

    /**************************************************************************
     * Public Methods for this Interface
     *************************************************************************/
    virtual void                DisplayWindow       ( );
    virtual void                CloseWindow         ( );

    virtual HANDLE              GetWaitHandle       ( ) const;

    /**************************************************************************
     * Public Static Methods for this Class
     *************************************************************************/
    static BaseTunerWindow* GetTunerWindowForHandle ( HWND hWnd );

    // Callback Functions
    static DWORD WINAPI StaticDisplayWindowThreadProc(LPVOID lpParameter);
    static LRESULT CALLBACK MainWndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);

protected:
    /**************************************************************************
     * Protected Methods for this Interface
     *************************************************************************/
    virtual void        InitializeDisplaySystem ( ) = 0;

    virtual LRESULT     AppWindowProc           ( HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam ) = 0;

    HWND                GetWindowHandle        ( ) const;

private:
    /**************************************************************************
     * Private Constant Variables for this Class
     *************************************************************************/
    static const wchar_t* WindowClassName;

    /**************************************************************************
     * Private Variables for this Interface
     *************************************************************************/
    const HINSTANCE             m_hInstance;
    const std::wstring          m_commandLine;
    const int                   m_cmdShow;

    HWND                        m_hWnd;

    HANDLE                      m_showWindowWaitEvent;
    HANDLE                      m_isRunningHandle;

    /**************************************************************************
     * Static Private Variables for this Class
     *************************************************************************/
    static std::map<HWND, BaseTunerWindow* >  m_windowLookup;

    /**************************************************************************
     * Private Methods for this Interface
     *************************************************************************/
    void                DisplayWindowWorker     ( );

    void                CreateWin32Window       ( );
    void                DisplayWin32Window      ( );

    void                RunMessageLoop          ( );


    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    BaseTunerWindow(const BaseTunerWindow& rhs);
    BaseTunerWindow& operator=(const BaseTunerWindow& rhs);
};

}}