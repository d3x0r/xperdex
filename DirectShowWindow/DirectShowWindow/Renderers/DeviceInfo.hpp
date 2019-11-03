/**************************************************************************//**
 * @file    DeviceInfo.hpp
 *
 * @brief   Class which defines the device information for a single device.
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
 * DeviceInfo Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>
#include <atlbase.h>

// C++ API Specific Includes
#include <string>

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   DeviceInfo
 * @brief   Class which defines the device information for a single device.
 *****************************************************************************/
class DeviceInfo
{
public:
    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    ATL::CComPtr<IMoniker>      Moniker                 ( ) const               { return m_moniker; }
    std::wstring                Name                    ( ) const               { return m_name; }
    std::wstring                Desc                    ( ) const               { return m_desc; }
    std::wstring                Path                    ( ) const               { return m_path; }

    void                        Moniker                 ( ATL::CComPtr<IMoniker> moniker )      { m_moniker = moniker; }
    void                        Name                    ( const std::wstring& name )            { m_name = name; }
    void                        Desc                    ( const std::wstring& desc )            { m_desc = desc; }
    void                        Path                    ( const std::wstring& path )            { m_path = path; }

private:
    /**************************************************************************
     * Public Variables for this Class
     *************************************************************************/
    ATL::CComPtr<IMoniker>      m_moniker;
    std::wstring                m_name;
    std::wstring                m_desc;
    std::wstring                m_path;

}; // class DeviceInfo

}}