/**************************************************************************//**
 * @file    MediaFoundationTunerWindow.hpp
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
#pragma once

/******************************************************************************
 * MediaFoundationTunerWindow Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>

// C++ API Specific Includes
#include <string>

// App Specific Includes
#include "BaseTunerWindow.hpp"

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   MediaFoundationTunerWindow
 * @brief   Class used to control the media foundation tuner window.
 *****************************************************************************/
class MediaFoundationTunerWindow : public BaseTunerWindow
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        MediaFoundationTunerWindow      ( HINSTANCE hInstance,
                                                          const std::wstring& commandLine,
                                                          int cmdShow );
    virtual            ~MediaFoundationTunerWindow      ( );

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/

private:

    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    MediaFoundationTunerWindow(const MediaFoundationTunerWindow& rhs);
    MediaFoundationTunerWindow& operator=(const MediaFoundationTunerWindow& rhs);
};

}}