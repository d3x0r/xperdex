//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2007-2008
// Available under the terms of the
// Eclipse Public License with GPL exception
// See enclosed license file for more information
namespace PhysX.NET
{
	using System;
	using System.Runtime.InteropServices;
	
	
	[System.Flags()]
	public enum NxShapeCompartmentType : uint
	{
		
NX_COMPARTMENT_SW_RIGIDBODY =  (1<<0),
		
NX_COMPARTMENT_HW_RIGIDBODY =  (1<<1),
		
NX_COMPARTMENT_SW_FLUID =  (1<<2),
		
NX_COMPARTMENT_HW_FLUID =  (1<<3),
		
NX_COMPARTMENT_SW_CLOTH =  (1<<4),
		
NX_COMPARTMENT_HW_CLOTH =  (1<<5),
		
NX_COMPARTMENT_SW_SOFTBODY =  (1<<6),
		
NX_COMPARTMENT_HW_SOFTBODY =  (1<<7),
	}
}
