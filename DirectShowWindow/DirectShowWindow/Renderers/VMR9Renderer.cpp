/**************************************************************************//**
 * @file    VMR9Renderer.cpp
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
 * VMR9Renderer Specific Includes
 *****************************************************************************/
#include "stdafx.h"

#if defined(USE_VMR9)

#include "VMR9Renderer.hpp"

// C++ API Specific Includes
#include <stdexcept>

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * VMR9Renderer Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   VMR9Renderer ( )                                                 */
/** @brief  VMR9Renderer Class Constructor.
 *****************************************************************************/
VMR9Renderer::VMR9Renderer( )
{
} // End VMR9Renderer::VMR9Renderer

/******************************************************************************
 *  @name   ~VMR9Renderer ( )                                                */
/** @brief  VMR9Renderer Class Destructor.
 *****************************************************************************/
VMR9Renderer::~VMR9Renderer( )
{
} // End VMR9Renderer::~VMR9Renderer

/******************************************************************************
 *  @name   Initialize ( )                                                   */
/** @brief  Method called to initialize this object.
 *****************************************************************************/
bool VMR9Renderer::Initialize( HWND hWnd )
{
    HRESULT hr;

    m_hWnd = hWnd;
    
    // Create VMR9 base filter
    hr = CoCreateInstance(CLSID_VideoMixingRenderer9, nullptr, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**)&m_baseFilter);
    
    return SUCCEEDED(hr);

} // End VMR9Renderer::Initialize

/******************************************************************************
 *  @name   GetBaseFilter ( )                                                */
/** @brief  Method called to retrieve the base filter for this object.
 *****************************************************************************/
CComPtr<IBaseFilter> VMR9Renderer::GetBaseFilter( )
{
    return m_baseFilter;

} // End VMR9Renderer::GetBaseFilter

/******************************************************************************
 *  @name   OnAddedToGraph ( )                                               */
/** @brief  Method called when this item was added to the filter graph.
 *****************************************************************************/
void VMR9Renderer::OnAddedToGraph( )
{
    HRESULT hr;

    // Set the rendering mode and number of streams
    CComPtr<IVMRFilterConfig9> vmrFilterConfig;
    hr = m_baseFilter->QueryInterface(IID_IVMRFilterConfig9, (void**)&vmrFilterConfig);
    if (FAILED(hr)) throw runtime_error("Failed to get VMRFilterConfig interface");

    hr = vmrFilterConfig->SetRenderingMode(VMR9Mode_Windowless);
    if (FAILED(hr)) throw runtime_error("Failed to set windowless mode on VMR");

    hr = vmrFilterConfig->SetNumberOfStreams(1UL);
    if (FAILED(hr)) throw runtime_error("Failed to set number of streams on VMR");

    // Set the clipping window
    hr = m_baseFilter->QueryInterface(IID_IVMRWindowlessControl9, (void**)&m_windowlessControl);
    if (FAILED(hr)) throw runtime_error("Failed to get windowless control interface in VMR");

    hr = m_windowlessControl->SetVideoClippingWindow(m_hWnd);
    if (FAILED(hr)) throw runtime_error("Failed to set clipping window");

} // End VMR9Renderer::OnAddedToGraph

/******************************************************************************
 *  @name   OnConnectionEstablished ( )                                      */
/** @brief  Method called when a connection to this object has 
 *          been established.
 *****************************************************************************/
void VMR9Renderer::OnConnectionEstablished( )
{
} // End VMR9Renderer::OnConnectionEstablished

/******************************************************************************
 *  @name   OnConnectionEstablished ( )                                      */
/** @brief  Method called to notify this object of a windows message.
 *****************************************************************************/
void VMR9Renderer::NotifyWindowsMessage( UINT msg, WPARAM wParam, LPARAM lParam )
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
            RECT destRect;
            GetClientRect(m_hWnd, &destRect);

            RECT rc;
            rc.left = 0;
            rc.top = 0;
            rc.right = (destRect.right - destRect.left);
            rc.bottom = (destRect.bottom - destRect.top);
            m_windowlessControl->SetVideoPosition(nullptr, &rc);

            InvalidateRect(m_hWnd, nullptr, TRUE);
        }
        break;
    }

} // End VMR9Renderer::NotifyWindowsMessage

#endif