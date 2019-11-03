/**************************************************************************//**
 * @file    ISettingRepository.hpp
 *
 * @brief   Interface for a repository to return settings
 *
 *          Change History
 *          -----------------
 *          d3x0r - 10/05/2011
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
 * ISettingRepository Specific Includes
 *****************************************************************************/

// C++ API Specific Includes
#include <string>

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   ISettingRepository
 * @brief   Interface for a repository to return settings
 *****************************************************************************/
class ISettingRepository
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
    virtual                    ~ISettingRepository  ( ) = 0 { }

    /**************************************************************************
     * Public Methods for this Interface
     *************************************************************************/
    virtual void                SetSettingDefault   ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      const std::wstring& settingValue ) const = 0;
    virtual bool                GetSetting          ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      std::wstring& settingValue ) const = 0;
    virtual bool                GetSetting          ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      bool& settingValue ) const = 0;
    virtual bool                GetSetting          ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      int& settingValue ) const = 0;
};

}}