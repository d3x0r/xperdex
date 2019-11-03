/**************************************************************************//**
 * @file    IAudioRenderer.hpp
 *
 * @brief   Interface for audio renderer objects.
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
 * IAudioRenderer Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>
#include <atlbase.h>
#include <DShow.h>

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   IAudioRenderer
 * @brief   Interface for audio renderer objects.
 *****************************************************************************/
class IAudioRenderer
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
    virtual            ~IAudioRenderer              ( ) {}

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    virtual bool                        Initialize      ( ) = 0;
    virtual ATL::CComPtr<IBaseFilter>   GetBaseFilter   ( ) = 0;

    virtual void                        OnAddedToGraph              ( ) = 0;
    virtual void                        OnConnectionEstablished     ( ) = 0;

    virtual void                        Volume                      (int vol) = 0;
    virtual int                         Volume                      ( ) const = 0;

}; // End class IAudioRenderer

}}