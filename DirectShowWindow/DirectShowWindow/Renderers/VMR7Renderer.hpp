/**************************************************************************//**
 * @file    VMR7Renderer.hpp
 *
 * @brief   Class which uses the Video Mixing Renderer verison 7
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

#if defined(USE_VMR7)

/******************************************************************************
 * VMR7Renderer Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>
#include <atlbase.h>
#include <DShow.h>

// App Specific Includes
#include "IVideoRenderer.hpp"

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   VMR7Renderer
 * @brief   Class which uses the Video Mixing Renderer verison 7
 *****************************************************************************/
class VMR7Renderer : public IVideoRenderer
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        VMR7Renderer                ( );
    virtual            ~VMR7Renderer                ( );

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
    HWND                m_hWnd;

    ATL::CComPtr<IBaseFilter>           m_baseFilter;
    ATL::CComPtr<IVMRWindowlessControl> m_windowlessControl;


    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    VMR7Renderer(const VMR7Renderer& rhs);
    VMR7Renderer& operator=(const VMR7Renderer& rhs);

}; // End class VMR7Renderer

}}

#endif