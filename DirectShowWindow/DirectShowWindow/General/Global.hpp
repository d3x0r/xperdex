/**************************************************************************//**
 * @file    Global.hpp
 *
 * @brief   Global Static objects
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
 * Global Specific Includes
 *****************************************************************************/
#include <Windows.h>

#include <memory>
#include <string>

namespace Xperdex {
namespace TvWindow {

class ISettingRepository;

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   Global
 * @brief   Global Static objects
 *****************************************************************************/
class Global
{
public:
    /**************************************************************************
     * Public Static Methods for this Class
     *************************************************************************/
    static bool IsVistaOrLater();
    static void LogString(const std::wstring& outstr);
    static void CheckForMultipleInstances();

    /**************************************************************************
     * Public Static Variables for this Class
     *************************************************************************/
    static std::shared_ptr<ISettingRepository> g_settingRepository;

private:
    /**************************************************************************
     * Private Static Methods for this Class
     *************************************************************************/
    static int GetFileSize(const std::wstring& path);


    /**************************************************************************
     * Suppress object copying
     *************************************************************************/    
    Global(const Global& rhs);
    Global& operator=(const Global& rhs);
};

}}