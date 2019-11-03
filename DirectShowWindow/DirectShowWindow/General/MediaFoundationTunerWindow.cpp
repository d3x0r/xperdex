/**************************************************************************//**
 * @file    MediaFoundationTunerWindow.cpp
 *
 * @brief   Class used to control the media foundation tuner window.
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
#include "MediaFoundationTunerWindow.hpp"

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * MediaFoundationTunerWindow Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   MediaFoundationTunerWindow ( )                                   */
/** @brief  MediaFoundationTunerWindow Class Constructor.
 *****************************************************************************/
MediaFoundationTunerWindow::MediaFoundationTunerWindow( HINSTANCE hInstance,
                                                        const std::wstring& commandLine,
                                                        int cmdShow ) :
    BaseTunerWindow(hInstance, commandLine, cmdShow)
{
} // End MediaFoundationTunerWindow::MediaFoundationTunerWindow

/******************************************************************************
 *  @name   ~MediaFoundationTunerWindow ( )                                  */
/** @brief  MediaFoundationTunerWindow Class Destructor.
 *****************************************************************************/
MediaFoundationTunerWindow::~MediaFoundationTunerWindow( )
{
} // End MediaFoundationTunerWindow::~MediaFoundationTunerWindow