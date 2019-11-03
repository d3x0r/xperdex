/**************************************************************************//**
 * @file    IVideoRenderer.hpp
 *
 * @brief   Interface for video renderer objects.
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
 * IVideoRenderer Specific Includes
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
 * @class   IVideoRenderer
 * @brief   Interface for video renderer objects.
 *****************************************************************************/
class IVideoRenderer
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
    virtual            ~IVideoRenderer              ( ) {}

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    virtual bool                        Initialize      ( HWND hWnd ) = 0;
    virtual ATL::CComPtr<IBaseFilter>   GetBaseFilter   ( ) = 0;

    virtual void                        OnAddedToGraph              ( ) = 0;
    virtual void                        OnConnectionEstablished     ( ) = 0;
    virtual void                        NotifyWindowsMessage        ( UINT msg, WPARAM wParam, LPARAM lParam ) = 0;

}; // End class IVideoRenderer

}}