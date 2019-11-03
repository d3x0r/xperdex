/**************************************************************************//**
 * @file    VMR9Renderer.hpp
 *
 * @brief   Class which uses the Video Mixing Renderer verison 9
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

#if defined(USE_VMR9)

/******************************************************************************
 * VMR9Renderer Specific Includes
 *****************************************************************************/
// Windows Specific Includes
#include <Windows.h>
#include <atlbase.h>
#include <DShow.h>
#include <d3d9.h>
#include <vmr9.h>

// App Specific Includes
#include "IVideoRenderer.hpp"

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   VMR9Renderer
 * @brief   Class which uses the Video Mixing Renderer verison 7
 *****************************************************************************/
class VMR9Renderer : public IVideoRenderer
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        VMR9Renderer                ( );
    virtual            ~VMR9Renderer                ( );

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

    ATL::CComPtr<IBaseFilter>               m_baseFilter;
    ATL::CComPtr<IVMRWindowlessControl9>    m_windowlessControl;


    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    VMR9Renderer(const VMR9Renderer& rhs);
    VMR9Renderer& operator=(const VMR9Renderer& rhs);

}; // End class VMR9Renderer

}}

#endif