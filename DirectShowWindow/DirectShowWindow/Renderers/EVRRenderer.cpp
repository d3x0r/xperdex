/**************************************************************************//**
 * @file    EVRRenderer.cpp
 *
 * @brief   Class which uses the Enhanced Video Renderer.
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
#include "stdafx.h"

#if defined(USE_EVR)

#include "EVRRenderer.hpp"

// C++ API Specific Includes
#include <stdexcept>

using namespace std;
using namespace Xperdex::TvWindow;

#pragma comment (lib, "Mfuuid.lib")

/******************************************************************************
 * EVRRenderer Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   EVRRenderer ( )                                                  */
/** @brief  EVRRenderer Class Constructor.
 *****************************************************************************/
EVRRenderer::EVRRenderer( ) :
    m_hWnd(nullptr)
{
} // End EVRRenderer::EVRRenderer

/******************************************************************************
 *  @name   ~EVRRenderer ( )                                                 */
/** @brief  EVRRenderer Class Destructor.
 *****************************************************************************/
EVRRenderer::~EVRRenderer( )
{
} // End EVRRenderer::~EVRRenderer

/******************************************************************************
 *  @name   Initialize ( )                                                   */
/** @brief  Method called to initialize this object.
 *****************************************************************************/
bool EVRRenderer::Initialize( HWND hWnd )
{
    HRESULT hr;

    // Store our window handle to use
    m_hWnd = hWnd;
    
    // Create EVR base filter
    hr = CoCreateInstance(CLSID_EnhancedVideoRenderer, nullptr, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**)&m_baseFilter);
    
    return SUCCEEDED(hr);

} // End EVRRenderer::Initialize

/******************************************************************************
 *  @name   GetBaseFilter ( )                                                */
/** @brief  Method called to retrieve the base filter for this object.
 *****************************************************************************/
CComPtr<IBaseFilter> EVRRenderer::GetBaseFilter( )
{
    return m_baseFilter;

} // End EVRRenderer::GetBaseFilter

/******************************************************************************
 *  @name   OnAddedToGraph ( )                                               */
/** @brief  Method called when this item was added to the filter graph.
 *****************************************************************************/
void EVRRenderer::OnAddedToGraph( )
{
    HRESULT hr;

    // Get the IMFGetService interface from the DirectShow filter
    hr = m_baseFilter->QueryInterface(IID_IMFGetService, (void**)&m_mfGetService);
    if (FAILED(hr)) throw runtime_error("Failed to get MFGetService interface");

    // Using the "MFGetService" interface, ask for the "MFVideoDisplayControl" interface.
    hr = m_mfGetService->GetService(MR_VIDEO_RENDER_SERVICE, IID_IMFVideoDisplayControl, (void**)&m_mfVideoDisplayControl);
    if (FAILED(hr)) throw runtime_error("Failed to get the Video Display Control interface");

    // Using the "MFVideoDisplayControl" interface, set the aspect ratio and video window
    hr = m_mfVideoDisplayControl->SetAspectRatioMode(MFVideoARMode_PreservePicture);
    if (FAILED(hr)) throw runtime_error("Failed to set the aspect ratio of the video");

    hr = m_mfVideoDisplayControl->SetVideoWindow(m_hWnd);
    if (FAILED(hr)) throw runtime_error("Failed to set the Video Window");

} // End EVRRenderer::OnAddedToGraph

/******************************************************************************
 *  @name   OnConnectionEstablished ( )                                      */
/** @brief  Method called when a connection to this object has 
 *          been established.
 *****************************************************************************/
void EVRRenderer::OnConnectionEstablished( )
{
} // End EVRRenderer::OnConnectionEstablished

/******************************************************************************
 *  @name   OnConnectionEstablished ( )                                      */
/** @brief  Method called to notify this object of a windows message.
 *****************************************************************************/
void EVRRenderer::NotifyWindowsMessage( UINT msg, WPARAM wParam, LPARAM lParam )
{
    // Ensure our video display control is currently valid
    if (!m_mfVideoDisplayControl) return;

    switch(msg)
    {
    case WM_PAINT:
        {
            // On a WM_PAINT, notify our VideoDisplayControl object to repaint
            m_mfVideoDisplayControl->RepaintVideo();
        }
        break;

    case WM_SIZE:
        {
            // On a WM_SIZE, notify our VideoDisplayControl to update the position
            // of its window
            RECT destRect;
            GetClientRect(m_hWnd, &destRect);

            RECT rc;
            rc.left = 0;
            rc.top = 0;
            rc.right = (destRect.right - destRect.left);
            rc.bottom = (destRect.bottom - destRect.top);
            m_mfVideoDisplayControl->SetVideoPosition(nullptr, &rc);

            InvalidateRect(m_hWnd, nullptr, TRUE);
        }
        break;
    }

} // End EVRRenderer::NotifyWindowsMessage

#endif