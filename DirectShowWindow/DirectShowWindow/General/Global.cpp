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

/******************************************************************************
 * Global Specific Includes
 *****************************************************************************/
#include "stdafx.h"
#include "Global.hpp"

#include <Windows.h>
#include <Psapi.h>
#include <tchar.h>

#include <fstream>
#include <limits>
#include <sys/types.h>
#include <sys/stat.h>

using namespace std;
using namespace Xperdex::TvWindow;

#pragma comment( lib, "Psapi.lib" )
#define DPSAPI_VERSION 1

std::shared_ptr<ISettingRepository> Global::g_settingRepository;

/******************************************************************************
 * LogString Global Method
 *****************************************************************************/
void Global::LogString(const wstring& outstr)
{
    static const std::wstring fileName = L"PlayCap.log";

    ios_base::openmode openMode = ios_base::out;
    if (GetFileSize(fileName) > 50000) { openMode |= ios_base::trunc; }
    else { openMode |= ios_base::app; }

    wofstream output(fileName, openMode);
    if (!output.bad())
    {
        output << outstr;
    }
    output.flush();

} // End LogString

/******************************************************************************
 * IsVistaOrLater Global Method
 *****************************************************************************/
bool Global::IsVistaOrLater()
{
    OSVERSIONINFOEX osvi;
    DWORDLONG dwlConditionMask = 0;
    BYTE op = VER_GREATER_EQUAL;

    // Initialize the OSVERSIONINFOEX structure
    ZeroMemory(&osvi, sizeof(OSVERSIONINFOEX));
    osvi.dwOSVersionInfoSize = sizeof(OSVERSIONINFOEX);
    osvi.dwMajorVersion = 6;
    osvi.dwMinorVersion = 0;
    osvi.wServicePackMajor = 0;
    osvi.wServicePackMinor = 0;

    // Initialize the condition mask.
    VER_SET_CONDITION(dwlConditionMask, VER_MAJORVERSION, op);
    VER_SET_CONDITION(dwlConditionMask, VER_MINORVERSION, op);
    VER_SET_CONDITION(dwlConditionMask, VER_SERVICEPACKMAJOR, op);
    VER_SET_CONDITION(dwlConditionMask, VER_SERVICEPACKMINOR, op);

    // Perform the test.
    return (VerifyVersionInfo(&osvi,
        VER_MAJORVERSION|VER_MINORVERSION|VER_SERVICEPACKMAJOR|VER_SERVICEPACKMINOR,
        dwlConditionMask) == TRUE);

} // End Global::IsVistaOrLater

/******************************************************************************
 * GetFileSize Global Method
 *****************************************************************************/
int Global::GetFileSize(const wstring& path)
{
    struct __stat64 fileStat;
    int err = _wstat64(path.c_str(), &fileStat);
    if (err != 0) return 0;
    return static_cast<int>(fileStat.st_size > numeric_limits<int>::max() ? numeric_limits<int>::max() : fileStat.st_size);

} // End Global::GetFileSize

/******************************************************************************
 * CheckForMultipleInstances Global Method
 *
 * This is a workaround for an issue detected in house.  What had happend was
 * that from time to time this application would not be shut down by its host
 * when the host closed.  Normally, I would add a system wide mutex and block
 * relaunching if this application were already running, however the
 * launching application monitors this application and thus if I shutdown the
 * host will just relaunch me, so the best option remaining is to attempt to
 * detect and close any previously running instances of this application.
 *****************************************************************************/
void Global::CheckForMultipleInstances()
{
    static const int PATHMULTIPLIER = 4;
    bool processesClosed = false;

    // Attempt to enumerate all processes running on the current machine
    DWORD* processIds = nullptr;
    DWORD processIdSize = 2;
    DWORD bytesReturned = 0;

    // Attempt to get the current process path
    TCHAR curProcessName[MAX_PATH*PATHMULTIPLIER];
    if (GetModuleFileNameEx(GetCurrentProcess(),
                            nullptr,
                            curProcessName, 
                            MAX_PATH*PATHMULTIPLIER) == 0) return;

    try
    {
        do
        {
            // Increase the size of our array
            if (processIds != nullptr)
            {
                processIdSize <<= 1;
            }

            // Create our array
            if (processIds != nullptr) { delete[] processIds; processIds = nullptr; }
            processIds = new DWORD[processIdSize];

            // Enumerate Processes
            if (EnumProcesses(processIds, sizeof(DWORD) * processIdSize, &bytesReturned) == FALSE) throw 0;

        } while(bytesReturned == (sizeof(DWORD) * processIdSize));

        // How many processes are in our list??
        DWORD numProcesses = bytesReturned / sizeof(DWORD);

        // Loop through each process
        for (DWORD procIndex = 0; procIndex < numProcesses; ++procIndex)
        {
            // If this is our process, move on
            if (processIds[procIndex] == GetCurrentProcessId()) continue;

            TCHAR itemProcessName[MAX_PATH*PATHMULTIPLIER];

            // Get a handle to the running process
            HANDLE itemProcHandle = OpenProcess(PROCESS_QUERY_INFORMATION|PROCESS_TERMINATE|PROCESS_VM_READ,
                                                FALSE,
                                                processIds[procIndex]);
            if (itemProcHandle == nullptr) continue;

            // Get the name of the running process
            if (GetModuleFileNameEx(itemProcHandle,
                                    nullptr,
                                    itemProcessName, 
                                    MAX_PATH*PATHMULTIPLIER) == 0)
            {
                CloseHandle(itemProcHandle);
                continue;
            }

            // Determine if the names are the same
            if (_tcscmp(curProcessName, itemProcessName) == 0)
            {
                TerminateProcess(itemProcHandle, 0);
                processesClosed = true;
            }

            CloseHandle(itemProcHandle);
        }
    }
    catch(...){}

    // Clean up any memory allocated
    if (processIds != nullptr) delete[] processIds;

    // Allow some time for OS to cleanup after previous processes
    // EX: Release sockets and COM objects... etc.
    if (processesClosed) 
        Sleep(10000);

} // End Global::CheckForMultipleInstances