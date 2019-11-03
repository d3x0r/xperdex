/**************************************************************************//**
 * @file    DirectShowWindowApp.hpp
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
#pragma once

/******************************************************************************
 * DirectShowWindowApp Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>

// C++ API Specific Includes
#include <memory>
#include <string>

namespace Xperdex {
namespace TvWindow {

class DirectShowTunerWindow;

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   DirectShowWindowApp
 * @brief   Class used to control this application.
 *****************************************************************************/
class DirectShowWindowApp
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        DirectShowWindowApp             ( HINSTANCE hInstance,
                                                          const std::wstring& commandLine,
                                                          int cmdShow );
    virtual            ~DirectShowWindowApp             ( );

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    int                 Run                 ( );    

private:
    /**************************************************************************
     * Private Methods for this Class
     *************************************************************************/
    void                SetupDefaultInitialStates   ( const std::shared_ptr<DirectShowTunerWindow> tunerWindow );

    /**************************************************************************
     * Private Variables for this Class
     *************************************************************************/
    const HINSTANCE         m_hInstance;                ///< The HInstance of this application
    const std::wstring      m_commandLine;              ///< The command line parameters for this application
    const int               m_cmdShow;                  ///< The show command type for this application

    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    DirectShowWindowApp(const DirectShowWindowApp& rhs);
    DirectShowWindowApp& operator=(const DirectShowWindowApp& rhs);
};

}}