/**************************************************************************//**
 * @file    DirectShowTunerWindow.cpp
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

/******************************************************************************
 * DirectShowTunerWindow Specific Includes
 *****************************************************************************/
#include "stdafx.h"
#include "DirectShowTunerWindow.hpp"

// Windows Specific Includes
#include <Windows.h>

// App Specific Includes
#include "Global.hpp"
#include "../Renderers/DirectSoundRenderer.hpp"
#include "../Renderers/DeviceInfo.hpp"
#include "../General/ISettingRepository.hpp"

#ifdef USE_EVR
    #include "../Renderers/EVRRenderer.hpp"
#elif USE_VMR7
    #include "../Renderers/VMR7Renderer.hpp"
#elif USE_VMR9
    #include "../Renderers/VMR9Renderer.hpp"
#endif

using namespace ATL;
using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * DirectShowTunerWindow Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   DirectShowTunerWindow ( )                                        */
/** @brief  DirectShowTunerWindow Class Constructor.
 *****************************************************************************/
DirectShowTunerWindow::DirectShowTunerWindow( HINSTANCE hInstance,
                                              const wstring& commandLine,
                                              int cmdShow ) :
    BaseTunerWindow(hInstance, commandLine, cmdShow),
    m_mediaType(nullptr),
    m_crossbarVideoOutputPin(-1),
    m_currentSource(TUNERSOURCE_UNKNOWN),
    m_isVisible(true),
    m_isRunning(false)
#ifdef DEBUG
    ,m_rotId(0)
#endif
{
} // End DirectShowTunerWindow::DirectShowTunerWindow

/******************************************************************************
 *  @name   ~DirectShowTunerWindow ( )                                       */
/** @brief  DirectShowTunerWindow Class Destructor.
 *****************************************************************************/
DirectShowTunerWindow::~DirectShowTunerWindow( )
{
#ifdef DEBUG
    if (m_rotId != 0)
    {
        CComPtr<IRunningObjectTable> rot;
        if (SUCCEEDED(GetRunningObjectTable(0, &rot)))
        {
            rot->Revoke(m_rotId);
        }
    }
#endif

} // End DirectShowTunerWindow::~DirectShowTunerWindow

/******************************************************************************
 *  @name   AppWindowProc ( )                                                */
/** @brief  Handles our application window procedure.
 *****************************************************************************/
LRESULT DirectShowTunerWindow::AppWindowProc( HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam )
{
    if (!m_isRunning && msg == WM_PAINT)
    {
        PaintTvOff(hWnd);
    }
    else
    {
        // Notify our video renderer of the windows message
        m_videoRenderer->NotifyWindowsMessage(msg, wParam, lParam);
    }

    // If this is a destroy message, set our event to notify that we are no longer running
    if (msg == WM_NCDESTROY) SetEvent(GetWaitHandle());

#ifdef DEBUG
    // Allow quit on escape key if DEBUG mode
    if (msg == WM_KEYDOWN && wParam == VK_ESCAPE) PostMessage(GetWindowHandle(), WM_CLOSE, 0, 0);
#endif

    // return default window processing for this message
    if (msg == WM_PAINT || msg ==  WM_ERASEBKGND) return 0;
    return DefWindowProc(hWnd, msg, wParam, lParam);

} // End DirectShowTunerWindow::AppWindowProc

/******************************************************************************
 *  @name   InitializeDisplaySystem ( )                                      */
/** @brief  Initializes Direct Show
 *****************************************************************************/
void DirectShowTunerWindow::InitializeDisplaySystem( )
{
    // Setup default audio device
    if (Global::g_settingRepository)
    {
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Audio Device", L"USB Audio");
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Video Capture Device Override", L"");
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Tuner from Antenna", L"1");
        Global::g_settingRepository->SetSettingDefault(L"TvWindow", L"Video Player/Capture Tuner", L"1");   
    }

    // First, Create the Direct Show filter graph
    CreateFilterGraph();

    // Create our renderer object
    CreateRendererObjects();

    // Create our tuner object
    CreateTuner();

    // Build our graph
    BuildFilterGraph();

    // Setup our TV Tuner options
    SetupTvTuner();

    // Setup our tuner crossbar
    SetupCrossbar();

#ifdef DEBUG
    // Register our filter graph
    RegisterFilterGraph();
#endif

} // End DirectShowTunerWindow::InitializeDisplaySystem

/******************************************************************************
 *  @name   CreateFilterGraph ( )                                            */
/** @brief  Attempts to create the filter graph object used for creating 
 *          and managing our DirectShow stream.
 *****************************************************************************/
void DirectShowTunerWindow::CreateFilterGraph( )
{
    HRESULT hr;

    // Create our Graph Builder Interface
    hr = CoCreateInstance(CLSID_CaptureGraphBuilder2, nullptr, CLSCTX_INPROC_SERVER, IID_ICaptureGraphBuilder2, (void**)&m_captureGraphBuilder);
    if (FAILED(hr)) { throw runtime_error("Failed to create CaptureGraphBuilder2 COM object"); }

    // Create our Filter Graph Interface
    hr = CoCreateInstance(CLSID_FilterGraph, nullptr, CLSCTX_INPROC_SERVER, IID_IFilterGraph2, (void**)&m_filterGraph);
    if (FAILED(hr)) { throw runtime_error("Failed to create FilterGraph COM object"); }

    // Set the filter graph for our graph builder
    hr = m_captureGraphBuilder->SetFiltergraph(m_filterGraph);
    if (FAILED(hr)) { throw runtime_error("Failed to set the FilterGraph into the CaptureGraphBuilder"); }

} // End DirectShowTunerWindow::CreateFilterGraph

/******************************************************************************
 *  @name   CreateRendererObjects ( )                                        */
/** @brief  Creates the output renderers for this graph (audio and video)
 *****************************************************************************/
void DirectShowTunerWindow::CreateRendererObjects( )
{
    HRESULT hr;

#if defined(USE_VMR7) // VMR 7 Renderer
    m_videoRenderer = make_shared<VMR7Renderer>();
#elif defined(USE_VMR9) // VMR 9 Renderer
    m_videoRenderer = make_shared<VMR9Renderer>();
#elif defined(USE_EVR) // EVR Renderer
    m_videoRenderer = make_shared<EVRRenderer>();
#else
    static_assert(false, "No VideoRenderer was chosen");
#endif

    // Initialize our video renderer
    if (!m_videoRenderer->Initialize(GetWindowHandle()))
        throw runtime_error("Failed to initialize our video renderer");

    // Add the renderer to the graph
    m_videoRendererFilter = m_videoRenderer->GetBaseFilter();
    hr = m_filterGraph->AddFilter(m_videoRendererFilter, L"VideoRenderer");
    if (FAILED(hr)) throw runtime_error("Failed to add video renderer to filter graph");

    // Notify the filter that it was added to the graph
    m_videoRenderer->OnAddedToGraph();

    // Initialize our audio renderer
    wstring audioDevice;
    if (Global::g_settingRepository) Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Audio Device", audioDevice);
    m_audioRenderer = make_shared<DirectSoundRenderer>(audioDevice);

    // Attempt to initialize our audio renderer
    if (m_audioRenderer->Initialize())
    {
        // Add the renderer to the graph
        m_audioRendererFilter = m_audioRenderer->GetBaseFilter();
        hr = m_filterGraph->AddFilter(m_audioRendererFilter, L"AudioRenderer");
        if (FAILED(hr)) { m_audioRendererFilter.Release(); m_audioRenderer.reset(); }

        m_audioRenderer->OnAddedToGraph();
    }
    else { m_audioRenderer.reset(); }

} // End DirectShowTunerWindow::CreateRendererObjects

/******************************************************************************
 *  @name   CreateTuner ( )                                                  */
/** @brief  Creates our TV Tuner object.
 *****************************************************************************/
void DirectShowTunerWindow::CreateTuner( )
{
    if (!Global::g_settingRepository) 
        throw runtime_error("No setting repository found.");

    // Enumerate our available devices
    vector<const shared_ptr<const DeviceInfo> > tunerDevices;
    vector<const shared_ptr<const DeviceInfo> > videoCaptureDevices;    

    Global::LogString(L"Detecting Video Tuner Devices\n");
    GetDeviceInfo(tunerDevices, AM_KSCATEGORY_TVTUNER);

    Global::LogString(L"Detecting Video Capture Devices\n");
    GetDeviceInfo(videoCaptureDevices, CLSID_VideoInputDeviceCategory);

    // Ensure we have at least 1 tuner and 1 video capture device
    bool useTuner = true;
    Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Capture Tuner", useTuner);
    if (useTuner && tunerDevices.empty())
        throw runtime_error("Failed to detect at least 1 tuner device");
    if (videoCaptureDevices.empty())
        throw runtime_error("Failed to detect at least 1 capture device");

    // Get the video capture device that matches our tuner (assuming 1 tuner)
    size_t vidCapIndex = 0;
    
    wstring captureDevice = L"";
    if (Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Video Capture Device Override", captureDevice) &&
        !captureDevice.empty())
    {
        int capIndex = 0;
        for (auto capDevice = videoCaptureDevices.begin(); capDevice != videoCaptureDevices.end(); ++capDevice, ++capIndex)
        {
            if ((*capDevice)->Desc().compare(captureDevice) == 0)
            {
                vidCapIndex = capIndex;
                break;
            }
        }
    }
    else if (useTuner)
    {
        vidCapIndex = FindCaptureDevice(tunerDevices[0], videoCaptureDevices);
    }

    if (vidCapIndex < 0 || vidCapIndex >= videoCaptureDevices.size())
        throw runtime_error("Invalid video capture device for tuner found");

    // Create our Video Capture Device
    CreateDevice(videoCaptureDevices[vidCapIndex], m_videoCaptureFilter);

    wchar_t str[1024];
    swprintf_s(str, L"Created Device \"%s\"\n", videoCaptureDevices[vidCapIndex]->Desc().c_str());
    Global::LogString(str);

} // End DirectShowTunerWindow::CreateTuner

/******************************************************************************
 *  @name   GetDeviceInfo ( )                                                */
/** @brief  Returns an array of all devices found.
 *****************************************************************************/
void DirectShowTunerWindow::GetDeviceInfo(vector<const shared_ptr<const DeviceInfo> >& deviceList, const GUID deviceCLSID)
{
    HRESULT hr;

    // First, Empty our passed device list
    deviceList.clear();

    // Create our device enumerator
    CComPtr<ICreateDevEnum> createDevEnum;
    hr = CoCreateInstance(CLSID_SystemDeviceEnum, nullptr, CLSCTX_INPROC_SERVER, IID_ICreateDevEnum, (void**)&createDevEnum);
    if (FAILED(hr)) throw runtime_error("Failed to create a device enumerator");

    // Create a class enumerator
    CComPtr<IEnumMoniker> enumMoniker;
    hr = createDevEnum->CreateClassEnumerator(deviceCLSID, &enumMoniker, 0);
    if (hr == S_FALSE) return;
    if (FAILED(hr)) throw runtime_error("Failed to create a class enumerator");
    
    // Enumerate all classes
    CComPtr<IMoniker> moniker;
    while (enumMoniker->Next(1, &moniker, nullptr) == S_OK)
    {
        // Bind this item to a property bag
        CComPtr<IPropertyBag> propertyBag;
        hr = moniker->BindToStorage(0, 0, IID_IPropertyBag, (void**)&propertyBag);
        if (FAILED(hr)) throw runtime_error("Failed to bind moniker to property bag");

        // Create Our Device Info
        const shared_ptr<DeviceInfo> devInfo = make_shared<DeviceInfo>();
        devInfo->Moniker(moniker);

        VARIANT name, desc, path;
        name.vt = VT_BSTR;
        desc.vt = VT_BSTR;
        path.vt = VT_BSTR;

        hr = propertyBag->Read(L"FriendlyName", &name, nullptr);
        if (FAILED(hr)) throw runtime_error("Failed to read FriendlyName from property bag");
        devInfo->Name(name.bstrVal);

        if (SUCCEEDED(propertyBag->Read(L"Description", &desc, nullptr)))
            devInfo->Desc(desc.bstrVal);

        if (SUCCEEDED(propertyBag->Read(L"DevicePath", &path, nullptr)))
            devInfo->Path(path.bstrVal);

        wchar_t logStr[1024];
        swprintf_s(logStr, L"Detected Device: %s\n", devInfo->Name().c_str());
        Global::LogString(logStr);

        deviceList.push_back(devInfo);

        moniker.Release();
    }

} // End DirectShowTunerWindow::GetDeviceInfo

/******************************************************************************
 *  @name   FindCaptureDevice ( )                                            */
/** @brief  Finds a capture device to match the tuner device passed.
 *****************************************************************************/
int DirectShowTunerWindow::FindCaptureDevice(shared_ptr<const DeviceInfo> tunerDevice, 
                                             vector<const shared_ptr<const DeviceInfo> >& vidCapDevices) const
{
    int bestIndex = -1;
    int bestMatch = 0;

    // Retrieve the registry path for the tuner device
    const std::wstring tunerPath = tunerDevice->Path();

    // Iterate through all video capture devices
    for (size_t i = 0; i < vidCapDevices.size(); ++i)
    {
        // Get the path of this video capture device
        const shared_ptr<const DeviceInfo> vidDevice = vidCapDevices[i];
        const std::wstring capturePath = vidDevice->Path();

        // Determine the shorter of the two comparable paths
        const int minLen = static_cast<int>(min(tunerPath.size(), capturePath.size()));
        int match = 0;

        // Count the number of sequential characters that match in the paths
        for ( ; tunerPath[match] == capturePath[match] && match < minLen; ++match);

        // If this is the best match so far, store it.
        if (match > bestMatch)
        {
            bestMatch = match;
            bestIndex = i;
        }
    }

    // Return the index of the best match. (-1 on complete failure)
    return bestIndex;

} // End DirectShowTunerWindow::FindCaptureDevice

/******************************************************************************
 *  @name   CreateDevice ( )                                                 */
/** @brief  Creates a new device of the type passed and adds to graph.  
 *          Returns the base filter for the device in the passed COM Pointer.
 *****************************************************************************/
void DirectShowTunerWindow::CreateDevice(std::shared_ptr<const DeviceInfo> device, ATL::CComPtr<IBaseFilter>& deviceFilter)
{
    HRESULT hr;

    // Create the video capture filter
    hr = device->Moniker()->BindToObject(nullptr, nullptr, IID_IBaseFilter, (void**)&deviceFilter);
    if (FAILED(hr)) throw runtime_error("Failed to create filter");

    // Add the new filter to our filter graph
    hr = m_filterGraph->AddFilter(deviceFilter, device->Name().c_str());
    if (FAILED(hr)) throw runtime_error("Failed to add filter to graph");

} // End DirectShowTunerWindow::CreateDevice

/******************************************************************************
 *  @name   BuildFilterGraph ( )                                             */
/** @brief  Builds our filter graph with the items added.
 *****************************************************************************/
void DirectShowTunerWindow::BuildFilterGraph( )
{
    HRESULT hr;

    // Assume Interleaved video and generate our video capture graph
    m_mediaType = &MEDIATYPE_Interleaved;
    hr = m_captureGraphBuilder->RenderStream(&PIN_CATEGORY_CAPTURE, m_mediaType, m_videoCaptureFilter, nullptr, m_videoRendererFilter);
    if (FAILED(hr))
    {
        // Try to render DV instead and generate our video capture graph
        m_mediaType = &MEDIATYPE_Video;
        hr = m_captureGraphBuilder->RenderStream(&PIN_CATEGORY_CAPTURE, m_mediaType, m_videoCaptureFilter, nullptr, m_videoRendererFilter);
        if (FAILED(hr))
            throw runtime_error("Unable to render video stream");
    }

    // Retrieve our media control interface
    hr = m_filterGraph->QueryInterface(IID_IMediaControl, (void**)&m_mediaControl);
    if (FAILED(hr))
        throw runtime_error("Unable to acquire media control");

    // Notify renderer that it has been connected
    m_videoRenderer->OnConnectionEstablished();

    // Build audio portion here
    if (m_audioRenderer && m_audioRendererFilter)
    {
        // Attempt to generate our audio graph (failure is not fatal)
        m_captureGraphBuilder->RenderStream(&PIN_CATEGORY_CAPTURE, &MEDIATYPE_Audio, m_videoCaptureFilter, nullptr, m_audioRendererFilter);
    }

} // End DirectShowTunerWindow::BuildFilterGraph

/******************************************************************************
 *  @name   SetupTvTuner ( )                                                 */
/** @brief  Sets up our tuner object
 *****************************************************************************/
void DirectShowTunerWindow::SetupTvTuner( )
{
    if (!Global::g_settingRepository)
        throw runtime_error("No setting repository found.");

    HRESULT hr;

    bool useTuner = true;
    Global::g_settingRepository->GetSetting(L"TvWindow", L"Video Player/Capture Tuner", useTuner);
    if (useTuner)
    {
        // Retrieve the tuner object
        hr = m_captureGraphBuilder->FindInterface(&PIN_CATEGORY_CAPTURE, m_mediaType, m_videoCaptureFilter, IID_IAMTVTuner, (void**)&m_tvTuner);
        if (FAILED(hr)) throw runtime_error("Unable to find video capture filter interface");

        // By default tune to channel 3 on the antenna input and start running
        m_tvTuner->put_InputType(0, TunerInputAntenna);
        m_tvTuner->put_Channel(3, AMTUNER_SUBCHAN_NO_TUNE, AMTUNER_SUBCHAN_NO_TUNE);
    }

} // End DirectShowTunerWindow::SetupTvTuner

/******************************************************************************
 *  @name   SetupCrossbar ( )                                                */
/** @brief  Sets up the crossbar object for this graph.
 *****************************************************************************/
void DirectShowTunerWindow::SetupCrossbar( )
{
    HRESULT hr;

    // Retrieve the crossbar object
    hr = m_captureGraphBuilder->FindInterface(nullptr, nullptr, m_videoCaptureFilter, IID_IAMCrossbar, (void**)&m_crossbar);
    if (FAILED(hr)) throw runtime_error("Failed to find the tuner crossbar");

    // get the base filter of the crossbar object
    hr = m_crossbar->QueryInterface(IID_IBaseFilter, (void**)&m_crossbarFilter);
    if (FAILED(hr)) throw runtime_error("Failed to find the main crossbar filter");

    // Retrieve the number of pins on each side of the crossbar.
    long outputPinCount = -1;
    long inputPinCount = -1;
    hr = m_crossbar->get_PinCounts(&outputPinCount, &inputPinCount);
    if (FAILED(hr)) throw runtime_error("Failed to get the pin counts for the crossbar");

    // Find the output video decoder pin (the pin between the crossbar and the video window)
    for (long output = 0; output < outputPinCount; ++output)
    {
        long relatedPin = 0;
        long physicalType = 0;
        hr = m_crossbar->get_CrossbarPinInfo(FALSE, output, &relatedPin, &physicalType);
        if (FAILED(hr)) throw runtime_error("Failed to get pin information from crossbar");

        // This pin is a video output pin.  We will take it.
        if (physicalType == PhysConn_Video_VideoDecoder)
        {
            m_crossbarVideoOutputPin = output;
            break;
        }
    }

} // End DirectShowTunerWindow::SetupCrossbar

/******************************************************************************
 *  @name   Channel ( )                                                      */
/** @brief  Sets the current tuner channel
 *****************************************************************************/
void DirectShowTunerWindow::Channel(int channel)
{
    // If we are setting a channel, we need to set the tuner source first
    Source(TUNERSOURCE_TUNER);

    // Attempt to change the channel
    if (m_tvTuner)
        m_tvTuner->put_Channel(static_cast<long>(channel), AMTUNER_SUBCHAN_NO_TUNE, AMTUNER_SUBCHAN_NO_TUNE);

} // End DirectShowTunerWindow::Channel

/******************************************************************************
 *  @name   Channel ( )                                                      */
/** @brief  Gets the current tuner channel
 *****************************************************************************/
int DirectShowTunerWindow::Channel( ) const
{
    LONG channel = 0;
    LONG videoSubChan;
    LONG audioSubChan;

    if (m_tvTuner)
        m_tvTuner->get_Channel(&channel, &videoSubChan, &audioSubChan);

    return static_cast<int>(channel);

} // End DirectShowTunerWindow::Channel

/******************************************************************************
 *  @name   Input ( )                                                        */
/** @brief  Sets the current video input
 *****************************************************************************/
void DirectShowTunerWindow::Input(TVTUNER_INPUTTYPE input)
{
    if (m_tvTuner)
        m_tvTuner->put_InputType(0, static_cast<TunerInputType>(input));

} // End DirectShowTunerWindow::Input

/******************************************************************************
 *  @name   Input ( )                                                        */
/** @brief  Gets the current video input
 *****************************************************************************/
TVTUNER_INPUTTYPE DirectShowTunerWindow::Input( ) const
{
    if (m_tvTuner)
    {
        TunerInputType type;
        m_tvTuner->get_InputType(0, &type);

        switch(type)
        {
        case TunerInputCable:   return TUNERTYPE_CABLE;
        case TunerInputAntenna: return TUNERTYPE_ANTENNA;
        }
    }

    return TUNERTYPE_UNKNOWN;

} // End DirectShowTunerWindow::Input

/******************************************************************************
 *  @name   Source ( )                                                       */
/** @brief  Gets the current video source.
 *****************************************************************************/
void DirectShowTunerWindow::Source(TVTUNER_SOURCETYPE source)
{
    HRESULT hr;
    long sourceType = 0;

    // Determine the actual pin type we are looking for
    switch(source)
    {
    case TUNERSOURCE_TUNER:         sourceType = PhysConn_Video_Tuner;      break;
    case TUNERSOURCE_COMPOSITE:     sourceType = PhysConn_Video_Composite;  break;
    case TUNERSOURCE_SVIDEO:        sourceType = PhysConn_Video_SVideo;     break;
    default:    return;
    }

    // Search for the input pin so we can route it to our output
    long outputPinCount = -1;
    long inputPinCount = -1;
    hr = m_crossbar->get_PinCounts(&outputPinCount, &inputPinCount);
    if (FAILED(hr)) return;

    // Find the input pin of the right source type
    for (long input = 0; input < inputPinCount; ++input)
    {
        long relatedPin = 0;
        long physicalType = 0;
        if(m_crossbar->get_CrossbarPinInfo(TRUE, input, &relatedPin, &physicalType) != S_OK) continue;

        // is the type correct?
        if (physicalType != sourceType) continue;

        // Get the information for our output crossbar pin
        long outputRelatedPin = -1;
        if (m_crossbar->get_CrossbarPinInfo(FALSE, m_crossbarVideoOutputPin, &outputRelatedPin, &physicalType) != S_OK) continue;

        // Route the video feed to our output
        m_crossbar->Route(m_crossbarVideoOutputPin, input);

        // Route the related signal (audio?) to our related output sink
        if (outputRelatedPin != -1 && relatedPin != -1)
            m_crossbar->Route(outputRelatedPin, relatedPin);

        // Store the current source for query by the user
        m_currentSource = source;
        break;
    }

} // End DirectShowTunerWindow::Source

/******************************************************************************
 *  @name   Source ( )                                                       */
/** @brief  Gets the current video source.
 *****************************************************************************/
TVTUNER_SOURCETYPE DirectShowTunerWindow::Source( ) const
{
    return m_currentSource;

} // End DirectShowTunerWindow::Source

/******************************************************************************
 *  @name   Run ( )                                                          */
/** @brief  Starts the current video stream.
 *****************************************************************************/
void DirectShowTunerWindow::Run( )
{
    m_mediaControl->Run();
    m_isRunning = true;

    InvalidateRect(GetWindowHandle(), NULL, TRUE); 

} // End DirectShowTunerWindow::Run

/******************************************************************************
 *  @name   Stop ( )                                                         */
/** @brief  Stops the current video stream.
 *****************************************************************************/
void DirectShowTunerWindow::Stop( )
{
    m_mediaControl->Stop();
    m_isRunning = false;

    InvalidateRect(GetWindowHandle(), NULL, TRUE); 

} // End DirectShowTunerWindow::Stop

/******************************************************************************
 *  @name   Position ( )                                                     */
/** @brief  Sets the position of our rendering window.
 *****************************************************************************/
void DirectShowTunerWindow::Position( const RECT& position )
{
    SetWindowPos(GetWindowHandle(), 
                 HWND_TOPMOST, 
                 position.left, 
                 position.top, 
                 (position.right - position.left), 
                 (position.bottom - position.top), 
                 SWP_FRAMECHANGED);

    RedrawWindow(GetWindowHandle(), 
                 NULL, 
                 NULL, 
                 RDW_ERASE | RDW_INVALIDATE | RDW_FRAME | RDW_ALLCHILDREN);

} // End DirectShowTunerWindow::Position

/******************************************************************************
 *  @name   Position ( )                                                     */
/** @brief  Gets the position of our rendering window.
 *****************************************************************************/
RECT DirectShowTunerWindow::Position( ) const
{
    RECT rc;
    memset(&rc, 0, sizeof(RECT));

    GetWindowRect(GetWindowHandle(), &rc);
    return rc;

} // End DirectShowTunerWindow::Position

/******************************************************************************
 *  @name   Volume ( )                                                       */
/** @brief  Sets the volume of our sound stream.
 *****************************************************************************/
void DirectShowTunerWindow::Volume(int vol)
{
    if (m_audioRenderer)
        m_audioRenderer->Volume(vol);

} // End DirectShowTunerWindow::Volume

/******************************************************************************
 *  @name   Volume ( )                                                       */
/** @brief  Gets the volume of our sound stream.
 *****************************************************************************/
int DirectShowTunerWindow::Volume( ) const
{
    if (m_audioRenderer)
        return m_audioRenderer->Volume();

    return 0;

} // End DirectShowTunerWindow::Volume

/******************************************************************************
 *  @name   Visible ( )                                                      */
/** @brief  Set this window visible based on what exists.
 *****************************************************************************/
void DirectShowTunerWindow::Visible( bool isVisible )
{
    // Set the new "visible" status
    const int cmdShow = (isVisible ? SW_SHOW : SW_HIDE);
    ShowWindow(GetWindowHandle(), cmdShow);    

    // Store the visibility status locally for user query
    m_isVisible = isVisible;

} // End DirectShowTunerWindow::Visible

/******************************************************************************
 *  @name   Visible ( )                                                      */
/** @brief  Get this window visible.
 *****************************************************************************/
bool DirectShowTunerWindow::Visible( ) const
{
    return m_isVisible;

} // End DirectShowTunerWindow::Visible

/******************************************************************************
 *  @name   Running ( )                                                      */
/** @brief  Is this window currently running?
 *****************************************************************************/
bool DirectShowTunerWindow::Running( ) const
{
    return m_isRunning;

} // End DirectShowTunerWindow::Running

/******************************************************************************
 *  @name   GetMinimumChannel ( )                                            */
/** @brief  Is this window currently running?
 *****************************************************************************/
int DirectShowTunerWindow::GetMinimumChannel( ) const
{
    int minChan = 0;

    LONG minChanLong, maxChanLong;
    if (m_tvTuner)
    {
        m_tvTuner->ChannelMinMax(&minChanLong, &maxChanLong);
        minChan = (int)minChanLong;
    }

    return minChan;

} // End DirectShowTunerWindow::GetMinimumChannel

/******************************************************************************
 *  @name   GetMaximumChannel ( )                                            */
/** @brief  Is this window currently running?
 *****************************************************************************/
int DirectShowTunerWindow::GetMaximumChannel( ) const
{
    int maxChan = 0;

    LONG minChanLong, maxChanLong;
    if (m_tvTuner)
    {
        m_tvTuner->ChannelMinMax(&minChanLong, &maxChanLong);
        maxChan = (int)maxChanLong;
    }

    return maxChan;

} // End DirectShowTunerWindow::GetMaximumChannel

/******************************************************************************
 *  @name   PaintTvOff ( )                                                   */
/** @brief  Is this tv off and requesting a paint?
 *****************************************************************************/
void DirectShowTunerWindow::PaintTvOff( HWND hWnd )
{
    static const wchar_t* NOTV_STRING = L"TV Off";

    SIZE sz;
    HFONT hFont;
    HGDIOBJ oldFont;
    LOGFONT logFont;
    memset(&logFont, 0, sizeof(LOGFONT));
    logFont.lfHeight = 50;
    logFont.lfQuality = ANTIALIASED_QUALITY;

    PAINTSTRUCT ps;
    HDC hDC = BeginPaint(hWnd, &ps);

    try
    {
        RECT rc;
        GetClientRect(hWnd, &rc);
        FillRect(hDC, &rc, (HBRUSH)GetStockObject(BLACK_BRUSH));

        // Calculate the text size.
        int maxWidth = (rc.right - rc.left) / 2;
        if (maxWidth < 10) throw runtime_error("Invalid window size");

        for(;;)
        {
            // Create this font size
            hFont = CreateFontIndirect(&logFont);
            
            if (hFont == nullptr) throw runtime_error("Failed to create font");

            // Select the new font
            oldFont = SelectObject(hDC, hFont);
            if (oldFont == nullptr) throw runtime_error("Failed to set font object");

            // Get the extents of this size            
            if (GetTextExtentPoint32(hDC, NOTV_STRING, wcslen(NOTV_STRING), &sz) == FALSE)
            { SelectObject(hDC, oldFont); DeleteObject(hFont); throw runtime_error("Failed to get text extents"); }

            // Is our size out of bounds?
            if (sz.cx > maxWidth) { logFont.lfHeight--; SelectObject(hDC, oldFont); DeleteObject(hFont); continue; }

            // This font will do just fine.
            break;
        }

        SetTextAlign(hDC, TA_CENTER|TA_BOTTOM);
        SetTextColor(hDC, RGB(255, 255, 255));
        SetBkColor(hDC, RGB(0, 0, 0));
        TextOut(hDC, ((rc.right - rc.left)/2) + rc.left, ((rc.bottom - rc.top)/2) + rc.top + (sz.cy/2), NOTV_STRING, wcslen(NOTV_STRING));
        SelectObject(hDC, oldFont);
        DeleteObject(hFont);

    } catch(...){}

    EndPaint(hWnd, &ps);

} // End DirectShowTunerWindow::PaintTvOff

#ifdef DEBUG
/******************************************************************************
 *  @name   RegisterFilterGraph ( )                                          */
/** @brief  Registers this filter graph with the Running Object Table.
 *****************************************************************************/
void DirectShowTunerWindow::RegisterFilterGraph( )
{
    HRESULT hr;

    CComPtr<IRunningObjectTable> rot;
    hr = GetRunningObjectTable(0, &rot);
    if (FAILED(hr)) return;

    wchar_t wsz[128];
    hr = StringCchPrintfW(wsz, sizeof(wsz)/sizeof(wsz[0]), L"FilterGraph %08x pid %08x\0", (DWORD_PTR)m_filterGraph.p, GetCurrentProcessId());
    if (FAILED(hr)) return;

    CComPtr<IMoniker> moniker;
    hr = CreateItemMoniker(L"!", wsz, &moniker);
    if (FAILED(hr)) return;

    hr = rot->Register(ROTFLAGS_REGISTRATIONKEEPSALIVE, m_filterGraph.p, moniker, &m_rotId);

} // End DirectShowTunerWindow::RegisterFilterGraph
#endif