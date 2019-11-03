/**************************************************************************//**
 * @file    IniSettingRepository.hpp
 *
 * @brief   Class which retrieves settings from an INI file.
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
 * IniSettingRepository Specific Includes
 *****************************************************************************/

// App Specific Includes
#include "ISettingRepository.hpp"

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   IniSettingRepository
 * @brief   Class which retrieves settings from an INI file.
 *****************************************************************************/
class IniSettingRepository : public ISettingRepository
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
                                IniSettingRepository( const std::wstring& fileName );
    virtual                    ~IniSettingRepository( );

    /**************************************************************************
     * Public Methods for this Class
     *************************************************************************/
    virtual void                SetSettingDefault   ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      const std::wstring& settingValue ) const;
    virtual bool                GetSetting          ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      std::wstring& settingValue ) const;
    virtual bool                GetSetting          ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      bool& settingValue ) const;
    virtual bool                GetSetting          ( const std::wstring& category,
                                                      const std::wstring& settingName,
                                                      int& settingValue ) const;

public:
    /**************************************************************************
     * Private Variables for this class
     *************************************************************************/
    const std::wstring          m_filePath;         ///< The full path to the INI file.


    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    IniSettingRepository(const IniSettingRepository& rhs);
    IniSettingRepository& operator=(const IniSettingRepository& rhs);
};

}}