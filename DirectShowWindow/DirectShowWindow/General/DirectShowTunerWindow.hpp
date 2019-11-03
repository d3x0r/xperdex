/**************************************************************************//**
 * @file    DirectShowTunerWindow.hpp
 *
 * @brief   Class used to control the direct show tuner window.
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
 * DirectShowTunerWindow Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>
#include <atlbase.h>
#include <DShow.h>

// C++ API Specific Includes
#include <map>
#include <memory>
#include <string>
#include <vector>

// App Specific Includes
#include "BaseTunerWindow.hpp"
#include "../Renderers/IAudioRenderer.hpp"
#include "../Renderers/IVideoRenderer.hpp"

namespace Xperdex {
namespace TvWindow {

// Namespace local forward declarations
class DeviceInfo;

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   DirectShowTunerWindow
 * @brief   Class used to control the direct show tuner window.
 *****************************************************************************/
class DirectShowTunerWindow : public BaseTunerWindow
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        DirectShowTunerWindow           ( HINSTANCE hInstance,
                                                          const std::wstring& commandLine,
                                                          int cmdShow );
    virtual            ~DirectShowTunerWindow           ( );

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/        
    virtual void                Channel             ( int channel );
    virtual int                 Channel             ( ) const;
    virtual void                Input               ( TVTUNER_INPUTTYPE input );
    virtual TVTUNER_INPUTTYPE   Input               ( ) const;
    virtual void                Source              ( TVTUNER_SOURCETYPE source );
    virtual TVTUNER_SOURCETYPE  Source              ( ) const;
    virtual void                Volume              ( int vol );
    virtual int                 Volume              ( ) const;
    virtual void                Visible             ( bool visible );
    virtual bool                Visible             ( ) const;
    virtual void                Position            ( const RECT& position );
    virtual RECT                Position            ( ) const;
    virtual bool                Running             ( ) const;

    virtual int                 GetMinimumChannel   ( ) const;
    virtual int                 GetMaximumChannel   ( ) const;

    virtual void                Run                 ( );
    virtual void                Stop                ( );


    static void         GetDeviceInfo           ( std::vector<const std::shared_ptr<const DeviceInfo> >& deviceList, const GUID deviceCLSID );

protected:
    /**************************************************************************
     * Protected Methods for this Interface
     *************************************************************************/
    virtual void        InitializeDisplaySystem ( );

    virtual LRESULT     AppWindowProc           ( HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam );

private:
    /**************************************************************************
     * Private Variables for this Class
     *************************************************************************/       
    const GUID*                 m_mediaType;
    long                        m_crossbarVideoOutputPin;
    TVTUNER_SOURCETYPE          m_currentSource;
    bool                        m_isVisible;    
    bool                        m_isRunning;

    ATL::CComPtr<ICaptureGraphBuilder2>         m_captureGraphBuilder;
    ATL::CComPtr<IFilterGraph3>                 m_filterGraph;
    ATL::CComPtr<IMediaControl>                 m_mediaControl;
    ATL::CComPtr<IAMTVTuner>                    m_tvTuner;
    ATL::CComPtr<IAMCrossbar>                   m_crossbar;
    ATL::CComPtr<IBaseFilter>                   m_videoCaptureFilter;
    ATL::CComPtr<IBaseFilter>                   m_videoRendererFilter;
    ATL::CComPtr<IBaseFilter>                   m_audioRendererFilter;
    ATL::CComPtr<IBaseFilter>                   m_crossbarFilter;

    std::shared_ptr<IVideoRenderer>             m_videoRenderer;
    std::shared_ptr<IAudioRenderer>             m_audioRenderer;

    /**************************************************************************
     * Private Methods for this Class
     *************************************************************************/        
    void                PaintTvOff              ( HWND hWnd );

    void                CreateFilterGraph       ( );
    void                CreateRendererObjects   ( );
    void                CreateTuner             ( );
    void                CreateDevice            ( std::shared_ptr<const DeviceInfo> device, ATL::CComPtr<IBaseFilter>& deviceFilter );
    void                BuildFilterGraph        ( );
    void                SetupTvTuner            ( );
    void                SetupCrossbar           ( );    

    int                 FindCaptureDevice       ( std::shared_ptr<const DeviceInfo> tunerDevice, std::vector<const std::shared_ptr<const DeviceInfo> >& vidCapDevices ) const;

    // If in debug mode, register with filter graph.
#ifdef DEBUG
    DWORD               m_rotId;
    void                RegisterFilterGraph     ( );
#endif

    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    DirectShowTunerWindow(const DirectShowTunerWindow& rhs);
    DirectShowTunerWindow& operator=(const DirectShowTunerWindow& rhs);
};

}}