/**************************************************************************//**
 * @file    EVRRenderer.hpp
 *
 * @brief   Class which uses the Enhanced Video Renderer
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
 * EVRRenderer Specific Includes
 *****************************************************************************/

#if defined(USE_EVR)

// Windows Specific Includes
#include <Windows.h>
#include <atlbase.h>
#include <mfidl.h>
#include <evr.h>

// App Specific Includes
#include "IVideoRenderer.hpp"

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   EVRRenderer
 * @brief   Class which uses the Video Mixing Renderer verison 7
 *****************************************************************************/
class EVRRenderer : public IVideoRenderer
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        EVRRenderer                 ( );
    virtual            ~EVRRenderer                 ( );

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    virtual bool                        Initialize      ( HWND hWnd );
    virtual ATL::CComPtr<IBaseFilter>   GetBaseFilter   ( );

    virtual void                        OnAddedToGraph              ( );
    virtual void                        OnConnectionEstablished     ( );
    virtual void                        NotifyWindowsMessage        ( UINT msg, WPARAM wParam, LPARAM lParam );

private:
    /**************************************************************************
     * Private Variables for this Class
     *************************************************************************/
    HWND                                    m_hWnd;

    ATL::CComPtr<IBaseFilter>               m_baseFilter;
    ATL::CComPtr<IMFGetService>             m_mfGetService;
    ATL::CComPtr<IMFVideoDisplayControl>    m_mfVideoDisplayControl;


    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    EVRRenderer(const EVRRenderer& rhs);
    EVRRenderer& operator=(const EVRRenderer& rhs);

}; // End class EVRRenderer

}}

#endif