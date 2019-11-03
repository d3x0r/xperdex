/**************************************************************************//**
 * @file    Main.cpp
 *
 * @brief   Main entry point of this application.
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
 * Main Specific Includes
 *****************************************************************************/
#include "stdafx.h"

// Windows Specific Includes
#include <Windows.h>

// C++ API Specific Includes
#include <memory>
#include <string>

// App Specific Includes
#include "DirectShowWindowApp.hpp"

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 *  @name   wWinMain ( )                                                     */
/** @brief  Main entrypoint of the windows application.
 *****************************************************************************/
int CALLBACK wWinMain(HINSTANCE hInstance, HINSTANCE /*hPrevInstance*/, LPWSTR cmdLine, int cmdShow)
{
    // Store our command line in a string wrapper
    const wstring commandLine(cmdLine);

    // Create our application object
    const shared_ptr<DirectShowWindowApp> theApp = 
        make_shared<DirectShowWindowApp>(hInstance, commandLine, cmdShow);

    // Run the application.
    return theApp->Run();
}