/**************************************************************************//**
 * @file    IniSettingRepository.cpp
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
#include "stdafx.h"
#include "IniSettingRepository.hpp"

// Windows Specific Includes
#include <Windows.h>

using namespace std;
using namespace Xperdex::TvWindow;

/******************************************************************************
 * IniSettingRepository Member Methods
 *****************************************************************************/
/******************************************************************************
 *  @name   IniSettingRepository ( )                                         */
/** @brief  IniSettingRepository Class Constructor.
 *****************************************************************************/
IniSettingRepository::IniSettingRepository( const wstring& fileName ) :
    m_filePath(fileName)
{

} // End UDPCommandListener::UDPCommandListener

/******************************************************************************
 *  @name   ~IniSettingRepository ( )                                        */
/** @brief  IniSettingRepository Class Destructor.
 *****************************************************************************/
IniSettingRepository::~IniSettingRepository( )
{

} // End IniSettingRepository::~IniSettingRepository

/******************************************************************************
 *  @name   SetSettingDefault ( )                                            */
/** @brief  Sets the setting default value for future calls.
 *****************************************************************************/
void IniSettingRepository::SetSettingDefault( const wstring& category,
                                              const wstring& settingName,
                                              const wstring& settingValue ) const
{
    wstring tmpSetting;
    if (!GetSetting(category, settingName, tmpSetting))
    {
        WritePrivateProfileStringW(category.c_str(),
                                   settingName.c_str(),
                                   settingValue.c_str(),
                                   m_filePath.c_str());
    }

} // End IniSettingRepository::SetSettingDefault

/******************************************************************************
 *  @name   GetSetting ( )                                                   */
/** @brief  Returns the setting value for the given category and name as 
 *          a string.
 *****************************************************************************/
bool IniSettingRepository::GetSetting( const wstring& category,
                                       const wstring& settingName,
                                       wstring& settingValue ) const
{
    wchar_t retStr[MAX_PATH];
    const wchar_t* INVALID_READ_STRING = L"XYZXYZ!@(ZY($&%"; // Gibberish string to determine if a real read happened, or the default was returned.

    GetPrivateProfileStringW(category.c_str(),
                             settingName.c_str(),
                             INVALID_READ_STRING,
                             retStr,
                             MAX_PATH,
                             m_filePath.c_str());

    if (wcscmp(retStr, INVALID_READ_STRING) == 0) return false;

    settingValue.assign(&retStr[0], &retStr[0] + wcslen(retStr));
    return true;
                            
} // End IniSettingRepository::GetSetting

/******************************************************************************
 *  @name   GetSetting ( )                                                   */
/** @brief  Returns the setting value for the given category and name as 
 *          a boolean.
 *****************************************************************************/
bool IniSettingRepository::GetSetting( const wstring& category,
                                       const wstring& settingName,
                                       bool& settingValue ) const
{
    const std::wstring WHITESPACE(L" \f\n\r\t\v");
    wstring settingValStr;
    if (!GetSetting(category, settingName, settingValStr) || settingValStr.empty()) return false;

    // trim left
    wstring::size_type pos = settingValStr.find_first_not_of(WHITESPACE);
    settingValStr.erase(0, pos);
    if (settingValStr.empty()) return false;

    // Check for True
    if (settingValStr[0] == L'1' ||
        settingValStr[0] == L't' ||
        settingValStr[0] == L'T') { settingValue = true; return true; }

    // Check for False
    if (settingValStr[0] == L'0' ||
        settingValStr[0] == L'f' ||
        settingValStr[0] == L'F') { settingValue = false; return true; }

    // Not true or false... Invalid Read
    return false;

} // End IniSettingRepository::GetSetting

/******************************************************************************
 *  @name   GetSetting ( )                                                   */
/** @brief  Returns the setting value for the given category and name as 
 *          an integer.
 *****************************************************************************/
bool IniSettingRepository::GetSetting( const wstring& category,
                                       const wstring& settingName,
                                       int& settingValue ) const
{
    wstring settingValStr;
    if (!GetSetting(category, settingName, settingValStr) || settingValStr.empty()) return false;

    settingValue = _wtoi(settingValStr.c_str());
    return true;

} // End IniSettingRepository::GetSetting