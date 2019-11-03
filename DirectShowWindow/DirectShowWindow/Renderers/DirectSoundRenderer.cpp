/**************************************************************************//**
 * @file    DirectSoundRenderer.hpp
 *
 * @brief   Class which uses the Direct Sound Renderer
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
 * DirectSoundRenderer Specific Includes
 *****************************************************************************/
#include "stdafx.h"
#include "DirectSoundRenderer.hpp"

// C++ API Specific Includes
#include <regex>
#include <stdexcept>
#include <vector>

// App Specific Includes
#include "DeviceInfo.hpp"
#include "../General/DirectShowTunerWindow.hpp"
#include "../General/Global.hpp"

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * DirectSoundRenderer Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   DirectSoundRenderer ( )                                          */
/** @brief  DirectSoundRenderer Class Constructor.
 *****************************************************************************/
DirectSoundRenderer::DirectSoundRenderer( const wstring& audioDeviceRegex ) :
    m_deviceRegex(audioDeviceRegex)
{
} // End DirectSoundRenderer::DirectSoundRenderer

/******************************************************************************
 *  @name   ~DirectSoundRenderer ( )                                         */
/** @brief  DirectSoundRenderer Class Destructor.
 *****************************************************************************/
DirectSoundRenderer::~DirectSoundRenderer( )
{
} // End DirectSoundRenderer::~DirectSoundRenderer

/******************************************************************************
 *  @name   Initialize ( )                                                   */
/** @brief  Method called to initialize this object.
 *****************************************************************************/
bool DirectSoundRenderer::Initialize( )
{
    // Determine if we need to search for a device
    if (m_deviceRegex.empty())
    {
        Global::LogString(L"Creating Default Direct Sound Audio Renderer\n");

        HRESULT hr;
    
        // Create direct show base filter
        hr = CoCreateInstance(CLSID_DSoundRender, nullptr, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**)&m_baseFilter);

        // Get the basic audio interface
        if (SUCCEEDED(hr))
        {
            hr = m_baseFilter->QueryInterface(IID_IBasicAudio, (void**)&m_basicAudio);
        }
    
        return SUCCEEDED(hr);
    }
    else
    {
        vector<const shared_ptr<const DeviceInfo> > audioRendererDevices;    

        Global::LogString(L"Detecting Audio Renderer Devices\n");
        DirectShowTunerWindow::GetDeviceInfo(audioRendererDevices, CLSID_AudioRendererCategory);

        shared_ptr<const DeviceInfo> selectedRenderer;
        for (auto renderer = audioRendererDevices.begin(); renderer != audioRendererDevices.end(); ++renderer)
        {
            wregex rx(m_deviceRegex);
            if (regex_search((*renderer)->Name(), rx))
            {
                selectedRenderer = *renderer;
            }
        }

        if (!selectedRenderer) return false;

        wchar_t logStr[1024];
        swprintf_s(logStr, L"Selected Audio Renderer: %s\n", selectedRenderer->Name().c_str());
        Global::LogString(logStr);

        // Create the audio capture filter
        HRESULT hr = selectedRenderer->Moniker()->BindToObject(nullptr, nullptr, IID_IBaseFilter, (void**)&m_baseFilter);  

        // Get the basic audio interface
        if (SUCCEEDED(hr))
        {
            hr = m_baseFilter->QueryInterface(IID_IBasicAudio, (void**)&m_basicAudio);
        }
    
        return SUCCEEDED(hr);
    }

} // End DirectSoundRenderer::Initialize

/******************************************************************************
 *  @name   GetBaseFilter ( )                                                */
/** @brief  Method called to retrieve the base filter for this object.
 *****************************************************************************/
CComPtr<IBaseFilter> DirectSoundRenderer::GetBaseFilter( )
{
    return m_baseFilter;

} // End DirectSoundRenderer::GetBaseFilter

/******************************************************************************
 *  @name   OnAddedToGraph ( )                                               */
/** @brief  Method called when this item was added to the filter graph.
 *****************************************************************************/
void DirectSoundRenderer::OnAddedToGraph( )
{
} // End DirectSoundRenderer::OnAddedToGraph

/******************************************************************************
 *  @name   OnConnectionEstablished ( )                                      */
/** @brief  Method called when a connection to this object has 
 *          been established.
 *****************************************************************************/
void DirectSoundRenderer::OnConnectionEstablished( )
{
} // End DirectSoundRenderer::OnConnectionEstablished

/******************************************************************************
 *  @name   Volume ( )                                                       */
/** @brief  Method called to set the volume.
 *****************************************************************************/
void DirectSoundRenderer::Volume(int vol)
{
    // (Internal volume range from (-10,000 - 0 dB)
    long volumeAmplitude = (vol * 100) - 10000;
    m_basicAudio->put_Volume(volumeAmplitude);

} // End DirectSoundRenderer::Volume

/******************************************************************************
 *  @name   Volume ( )                                                       */
/** @brief  Method called to get the volume.
 *****************************************************************************/
int DirectSoundRenderer::Volume( ) const
{
    // (Internal volume range from (-10,000 - 0 dB)
    int volume = 0;

    long volumeAmplitude = 0;
    HRESULT hr = m_basicAudio->get_Volume(&volumeAmplitude);
    if (SUCCEEDED(hr))
    {
        volume = (int)((volumeAmplitude + 10000) / 100);
    }

    return volume;

} // End DirectSoundRenderer::Volume