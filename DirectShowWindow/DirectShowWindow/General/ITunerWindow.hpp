/**************************************************************************//**
 * @file    ITunerWindow.hpp
 *
 * @brief   Interface for any tuner window objects.
 *
 *          Change History
 *          -----------------
 *          d3x0r - 10/03/2011
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
 * ITunerWindow Specific Includes
 *****************************************************************************/

// Windows Specific Includes
#include <Windows.h>

namespace Xperdex {
namespace TvWindow {

/******************************************************************************
 * Public Types used in this interface
 *****************************************************************************/
enum TVTUNER_INPUTTYPE
{
    TUNERTYPE_CABLE         = 0,
    TUNERTYPE_ANTENNA       = 1,

    TUNERTYPE_UNKNOWN       = 0x7FFFFFFF
};

enum TVTUNER_SOURCETYPE
{
    TUNERSOURCE_TUNER       = 0,
    TUNERSOURCE_COMPOSITE   = 1,
    TUNERSOURCE_SVIDEO      = 2,

    TUNERSOURCE_UNKNOWN     = 0x7FFFFFFF
};

/******************************************************************************
 * Main Class Declarations
 *****************************************************************************/
/**************************************************************************//**
 * @class   ITunerWindow
 * @brief   Interface for any tuner window objects.
 *****************************************************************************/
class ITunerWindow
{
public:
    /**************************************************************************
     * Constructors & Destructors for this Class
     *************************************************************************/
    virtual                    ~ITunerWindow        ( ) = 0 { }

    /**************************************************************************
     * Public Methods for this Interface
     *************************************************************************/
    virtual void                DisplayWindow       ( ) = 0;
    virtual void                CloseWindow         ( ) = 0;

    virtual HANDLE              GetWaitHandle       ( ) const = 0;

    virtual void                Channel             ( int channel ) = 0;
    virtual int                 Channel             ( ) const = 0;
    virtual void                Input               ( TVTUNER_INPUTTYPE input ) = 0;
    virtual TVTUNER_INPUTTYPE   Input               ( ) const = 0;
    virtual void                Source              ( TVTUNER_SOURCETYPE source ) = 0;
    virtual TVTUNER_SOURCETYPE  Source              ( ) const = 0;
    virtual void                Volume              ( int vol ) = 0;
    virtual int                 Volume              ( ) const = 0;
    virtual void                Visible             ( bool visible ) = 0;
    virtual bool                Visible             ( ) const = 0;    
    virtual void                Position            ( const RECT& position ) = 0;
    virtual RECT                Position            ( ) const = 0;
    virtual bool                Running             ( ) const = 0;

    virtual int                 GetMinimumChannel   ( ) const = 0;
    virtual int                 GetMaximumChannel   ( ) const = 0;

    virtual void                Run                 ( ) = 0;
    virtual void                Stop                ( ) = 0;
};

}}