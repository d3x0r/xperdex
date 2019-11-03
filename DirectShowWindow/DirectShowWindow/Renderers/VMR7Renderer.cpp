/**************************************************************************//**
 * @file    VMR7Renderer.cpp
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

/******************************************************************************
 * VMR7Renderer Specific Includes
 *****************************************************************************/
#include "stdafx.h"

#if defined(USE_VMR7)

#include "VMR7Renderer.hpp"

// C++ API Specific Includes
#include <stdexcept>

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * VMR7Renderer Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   VMR7Renderer ( )                                                 */
/** @brief  VMR7Renderer Class Constructor.
 *****************************************************************************/
VMR7Renderer::VMR7Renderer( )
{
} // End VMR7Renderer::VMR7Renderer

/******************************************************************************
 *  @name   ~VMR7Renderer ( )                                                */
/** @brief  VMR7Renderer Class Destructor.
 *****************************************************************************/
VMR7Renderer::~VMR7Renderer( )
{
} // End VMR7Renderer::~VMR7Renderer

/******************************************************************************
 *  @name   Initialize ( )                                                   */
/** @brief  Method called to initialize this object.
 *****************************************************************************/
bool VMR7Renderer::Initialize( HWND hWnd )
{
    HRESULT hr;

    m_hWnd = hWnd;
    
    // Create VMR7 base filter
    hr = CoCreateInstance(CLSID_VideoMixingRenderer, nullptr, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**)&m_baseFilter);
    
    return SUCCEEDED(hr);

} // End VMR7Renderer::Initialize

/******************************************************************************
 *  @name   GetBaseFilter ( )                                                */
/** @brief  Method called to retrieve the base filter for this object.
 *****************************************************************************/
CComPtr<IBaseFilter> VMR7Renderer::GetBaseFilter( )
{
    return m_baseFilter;

} // End VMR7Renderer::GetBaseFilter

/******************************************************************************
 *  @name   OnAddedToGraph ( )                                               */
/** @brief  Method called when this item was added to the filter graph.
 *****************************************************************************/
void VMR7Renderer::OnAddedToGraph( )
{
    HRESULT hr;

    // Set the rendering mode and number of streams
    CComPtr<IVMRFilterConfig> vmrFilterConfig;
    hr = m_baseFilter->QueryInterface(IID_IVMRFilterConfig, (void**)&vmrFilterConfig);
    if (FAILED(hr)) throw runtime_error("Failed to get VMRFilterConfig interface");

    hr = vmrFilterConfig->SetRenderingMode(VMRMode_Windowless);
    if (FAILED(hr)) throw runtime_error("Failed to set windowless mode on VMR");

    hr = vmrFilterConfig->SetNumberOfStreams(1UL);
    if (FAILED(hr)) throw runtime_error("Failed to set number of streams on VMR");

    // Set the clipping window
    hr = m_baseFilter->QueryInterface(IID_IVMRWindowlessControl, (void**)&m_windowlessControl);
    if (FAILED(hr)) throw runtime_error("Failed to get windowless control interface in VMR");

    hr = m_windowlessControl->SetVideoClippingWindow(m_hWnd);
    if (FAILED(hr)) throw runtime_error("Failed to set clipping window");

} // End VMR7Renderer::OnAddedToGraph

/******************************************************************************
 *  @name   OnConnectionEstablished ( )                                      */
/** @brief  Method called when a connection to this object has 
 *          been established.
 *****************************************************************************/
void VMR7Renderer::OnConnectionEstablished( )
{
} // End VMR7Renderer::OnConnectionEstablished

/******************************************************************************
 *  @name   OnConnectionEstablished ( )                                      */
/** @brief  Method called to notify this object of a windows message.
 *****************************************************************************/
void VMR7Renderer::NotifyWindowsMessage( UINT msg, WPARAM wParam, LPARAM lParam )
{
    switch(msg)
    {
    case WM_PAINT:
        {
            RECT rc;
            GetWindowRect(m_hWnd, &rc);
            rc.right -= rc.left;
            rc.bottom -= rc.top;
            rc.left = 0;
            rc.top = 0;

            PAINTSTRUCT ps;
            HDC paintHDC = BeginPaint(m_hWnd, &ps);
            FillRect(paintHDC, &rc, (HBRUSH)GetStockObject(BLACK_BRUSH));
            m_windowlessControl->RepaintVideo(m_hWnd, paintHDC);
            EndPaint(m_hWnd, &ps);
        }
        break;

    case WM_DISPLAYCHANGE:
        {
            m_windowlessControl->DisplayModeChanged();
        }
        break;

    case WM_SIZE:
        {
            RECT rc;
            memset(&rc, 0, sizeof(RECT));
            rc.right = LOWORD(lParam);
            rc.bottom = HIWORD(lParam);
            m_windowlessControl->SetVideoPosition(nullptr, &rc);

            InvalidateRect(m_hWnd, nullptr, TRUE);
        }
        break;
    }

} // End VMR7Renderer::NotifyWindowsMessage

#endif