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
#pragma once

/******************************************************************************
 * DirectSoundRenderer Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>
#include <atlbase.h>

// C++ API Specific Includes
#include <string>

// App Specific Includes
#include "IAudioRenderer.hpp"

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   DirectSoundRenderer
 * @brief   Class which uses the Direct Sound Renderer
 *****************************************************************************/
class DirectSoundRenderer : public IAudioRenderer
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                        DirectSoundRenderer         ( const std::wstring& audioDeviceRegex );
    virtual            ~DirectSoundRenderer         ( );

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    virtual bool                        Initialize      ( );
    virtual ATL::CComPtr<IBaseFilter>   GetBaseFilter   ( );

    virtual void                        OnAddedToGraph              ( );
    virtual void                        OnConnectionEstablished     ( );

    virtual void                        Volume                      ( int vol );
    virtual int                         Volume                      ( ) const;

private:
    /**************************************************************************
     * Private Variables for this Class
     *************************************************************************/
    const std::wstring                      m_deviceRegex;

    ATL::CComPtr<IBaseFilter>               m_baseFilter;
    ATL::CComPtr<IBasicAudio>               m_basicAudio;


    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    DirectSoundRenderer(const DirectSoundRenderer& rhs);
    DirectSoundRenderer& operator=(const DirectSoundRenderer& rhs);

}; // End class DirectSoundRenderer

}}