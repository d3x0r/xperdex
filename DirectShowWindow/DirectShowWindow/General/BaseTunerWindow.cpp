/**************************************************************************//**
 * @file    BaseTunerWindow.cpp
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

/******************************************************************************
 * MediaFoundationTunerWindow Specific Includes
 *****************************************************************************/
#include "stdafx.h"
#include "BaseTunerWindow.hpp"

// Windows Specific Includes
#include <Windows.h>
#include <ObjBase.h>

// App Specific Includes
#include "Global.hpp"

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * DirectShowTunerWindow Member Constants
 *****************************************************************************/
const wchar_t* BaseTunerWindow::WindowClassName = L"XperdexTvWindow";
std::map<HWND, BaseTunerWindow* > BaseTunerWindow::m_windowLookup;

/******************************************************************************
 * BaseTunerWindow Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   BaseTunerWindow ( )                                              */
/** @brief  BaseTunerWindow Class Constructor.
 *****************************************************************************/
BaseTunerWindow::BaseTunerWindow( HINSTANCE hInstance,
                                  const std::wstring& commandLine,
                                  int cmdShow ) :
    m_hInstance(hInstance),
    m_commandLine(commandLine),
    m_cmdShow(cmdShow),
    m_hWnd(nullptr)
{
    // Create our object handles
    m_showWindowWaitEvent = CreateEvent(nullptr, TRUE, FALSE, nullptr);
    m_isRunningHandle = CreateEvent(nullptr, TRUE, FALSE, nullptr);

} // End BaseTunerWindow::BaseTunerWindow

/******************************************************************************
 *  @name   ~BaseTunerWindow ( )                                             */
/** @brief  BaseTunerWindow Class Destructor.
 *****************************************************************************/
BaseTunerWindow::~BaseTunerWindow( )
{
    // Close our object handles
    CloseHandle(m_showWindowWaitEvent);
    CloseHandle(m_isRunningHandle);

} // End BaseTunerWindow::~BaseTunerWindow

/******************************************************************************
 *  @name   DisplayWindow ( )                                                */
/** @brief  Attempts to create and show the tuner window.
 *****************************************************************************/
void BaseTunerWindow::DisplayWindow( )
{
    // Use an event to wait until the window is displaying on its own thread
    // before returning to the user.
    ResetEvent(m_showWindowWaitEvent);

    // Create our new window thread
    CreateThread(nullptr,
                 0,
                 StaticDisplayWindowThreadProc,
                 this,
                 0,
                 nullptr);

    // Wait for the new window to be showing before returning to the user.
    WaitForSingleObject(m_showWindowWaitEvent, INFINITE);    

} // End BaseTunerWindow::DisplayWindow

/******************************************************************************
 *  @name   StaticDisplayWindowThreadProc ( )                                */
/** @brief  Allows a landing point for a new thread.
 *****************************************************************************/
DWORD WINAPI BaseTunerWindow::StaticDisplayWindowThreadProc(LPVOID lpParameter)
{
    // Get the actual window object and pass this method into that class 
    BaseTunerWindow *const tunerWindow = reinterpret_cast<BaseTunerWindow*>(lpParameter);
    tunerWindow->DisplayWindowWorker();

    // Always return success (This is not checked)
    return ERROR_SUCCESS;

} // End BaseTunerWindow::StaticDisplayWindowThreadProc

/******************************************************************************
 *  @name   DisplayWindowWorker ( )                                          */
/** @brief  Attempts to create and show the tuner window.
 *****************************************************************************/
void BaseTunerWindow::DisplayWindowWorker( )
{
    // Initialize COM on our new thread
    CoInitializeEx(nullptr, COINIT_MULTITHREADED);

    try
    {
        // First, create our client window
        CreateWin32Window();

        // Initialize Direct Show
        InitializeDisplaySystem();

        // Display our new window
        DisplayWin32Window();

        // Window is now displaying.
        SetEvent(m_showWindowWaitEvent);

        // Enter message loop
        RunMessageLoop();
    }
    catch(runtime_error& e)
    {
        wstring errorStr(e.what(), e.what() + strlen(e.what()));
        errorStr.append(L"\n");
        Global::LogString(errorStr);
    }

    // Release COM on this thread
    CoUninitialize();

} // End BaseTunerWindow::DisplayWindowWorker

/******************************************************************************
 *  @name   CreateWin32Window ( )                                            */
/** @brief  Creates our windows win32 window.
 *****************************************************************************/
void BaseTunerWindow::CreateWin32Window( )
{
    WNDCLASSEXW wcx;

    // Fill out our window class structure with parameters that
    // describe our main window.
    wcx.cbSize = sizeof(wcx);
    wcx.style = CS_BYTEALIGNCLIENT|CS_HREDRAW|CS_VREDRAW;
    wcx.lpfnWndProc = MainWndProc;
    wcx.cbClsExtra = 0;
    wcx.cbWndExtra = 0;
    wcx.hInstance = m_hInstance;
    wcx.hIcon = LoadIcon(nullptr, IDI_APPLICATION);
    wcx.hCursor = LoadCursor(nullptr, IDC_ARROW);
    wcx.hbrBackground = static_cast<HBRUSH>(GetStockObject(WHITE_BRUSH));
    wcx.lpszMenuName = nullptr;
    wcx.lpszClassName = WindowClassName;
    wcx.hIconSm = LoadIcon(nullptr, IDI_APPLICATION);

    // Register this class with windows
    if (RegisterClassExW(&wcx) == 0)
        throw runtime_error("Failed to register window class");

    // Attempt to create our window
    m_hWnd = CreateWindowW(WindowClassName,
                           WindowClassName,
                           WS_OVERLAPPEDWINDOW,
                           CW_USEDEFAULT,
                           CW_USEDEFAULT,
                           CW_USEDEFAULT,
                           CW_USEDEFAULT,
                           0,
                           0,
                           m_hInstance,
                           0);
    if (m_hWnd == nullptr)
        throw runtime_error("Failed to create Win32 window");

    // Store a copy of ourselves in the lookup for this window handle
    m_windowLookup[m_hWnd] = this;

} // End BaseTunerWindow::CreateWin32Window

/******************************************************************************
 *  @name   MainWndProc ( )                                                  */
/** @brief  
 *****************************************************************************/
LRESULT CALLBACK BaseTunerWindow::MainWndProc( HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam )
{
    // Get the DirectShow window for the HWND passed
    BaseTunerWindow* tunerWindow = 
        BaseTunerWindow::GetTunerWindowForHandle(hWnd);

    // Pass our message on to the appropriate window
    if (tunerWindow)
        return tunerWindow->AppWindowProc(hWnd, msg, wParam, lParam);

    // No window lookup, process this message locally
    return DefWindowProc(hWnd, msg, wParam, lParam);

} // End MainWndProc

/******************************************************************************
 *  @name   GetTunerWindowForHandle ( )                                      */
/** @brief  Returns the tuner window associated with a window handle.
 *****************************************************************************/
BaseTunerWindow* BaseTunerWindow::GetTunerWindowForHandle(HWND hWnd)
{
    BaseTunerWindow* tunerWindow = NULL;
    auto findResult = m_windowLookup.find(hWnd);
    if (findResult != m_windowLookup.end())
    {
        tunerWindow = findResult->second;
    }
    return tunerWindow;

} // End BaseTunerWindow::GetDSWindowForHandle

/******************************************************************************
 *  @name   DisplayWin32Window ( )                                           */
/** @brief  Displays the new Win32 window.
 *****************************************************************************/
void BaseTunerWindow::DisplayWin32Window( )
{
    bool isVistaOrHigher = Global::IsVistaOrLater();

    // Show and update our window for the first time
    ShowWindow(m_hWnd, m_cmdShow);    
    UpdateWindow(m_hWnd);
   
    // Fix the window style
    LONG lStyle = GetWindowLong(m_hWnd, GWL_STYLE);
    lStyle &= ~(WS_CAPTION | WS_THICKFRAME | WS_MINIMIZE | WS_MAXIMIZE | WS_SYSMENU);
    SetWindowLong(m_hWnd, GWL_STYLE, lStyle);

    // Fix the window extended style
    LONG lExStyle = GetWindowLong(m_hWnd, GWL_EXSTYLE);
    lExStyle &= ~(WS_EX_DLGMODALFRAME | WS_EX_CLIENTEDGE | WS_EX_STATICEDGE);
    if (isVistaOrHigher) { lExStyle |= (WS_EX_LAYERED|WS_EX_TRANSPARENT); }
    SetWindowLong(m_hWnd, GWL_EXSTYLE, lExStyle);
    if (isVistaOrHigher) { SetLayeredWindowAttributes(m_hWnd, 0, 255, LWA_ALPHA); }

    // Notify windows that we have changed the frame of the window.
    SetWindowPos(m_hWnd, HWND_TOPMOST, 0,0,0,0, SWP_FRAMECHANGED | SWP_NOMOVE | SWP_NOSIZE | SWP_NOOWNERZORDER);

} // End BaseTunerWindow::DisplayWin32Window

/******************************************************************************
 *  @name   RunMessageLoop ( )                                               */
/** @brief  Runs the windows message loop for this window
 *****************************************************************************/
void BaseTunerWindow::RunMessageLoop( )
{
    MSG msg;

    // Run windows message queue
    for(;;)
    {
        // Find the next windows message
        while(PeekMessage(&msg, nullptr, 0, 0, PM_REMOVE))
        {
            if (msg.message == WM_QUIT)
                break;

            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }

        // Message is quit, leave the loop
        if (msg.message == WM_QUIT)
            break;

        // Yield the thread until more messages are received
        WaitMessage();
    }

} // End BaseTunerWindow::RunMessageLoop

/******************************************************************************
 *  @name   CloseWindow ( )                                                  */
/** @brief  Set this window visible based on what exists.
 *****************************************************************************/
void BaseTunerWindow::CloseWindow( )
{
    // Notify the window to quit
    PostMessage(m_hWnd, WM_QUIT, 0, 0);

    // Wait for the window to stop running before returning
    WaitForSingleObject(m_isRunningHandle, INFINITE);

} // End BaseTunerWindow::CloseWindow

/******************************************************************************
 *  @name   GetWaitHandle ( )                                                */
/** @brief  Returns a handle to the user that can be used to wait for us 
 *          to complete our work.
 *****************************************************************************/
HANDLE BaseTunerWindow::GetWaitHandle( ) const
{
    return m_isRunningHandle;

} // End BaseTunerWindow::GetWaitHandle

/******************************************************************************
 *  @name   GetWindowHandle ( )                                              */
/** @brief  Returns the handle to the window of the current object.
 *****************************************************************************/
HWND BaseTunerWindow::GetWindowHandle( ) const
{
    return m_hWnd;

} // End BaseTunerWindow::GetWindowHandle