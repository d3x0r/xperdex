/*
 * Created by SharpDevelop.
 * User: d3x0r
 * Date: 11/27/2009
 * Time: 2:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;

namespace PowerShell.support
{
	/// <summary>
	/// Description of compile_resource.
	/// </summary>
	[Cmdlet("Compile", "Resource")]
	public class compile_resource:Cmdlet
	{
		// BeginProcessing - pre-processing/set-up

        // If accepts pipeline input, must override ProcessRecord and, optionally, EndProcessing

        // If does not take pipline input, should override EndProcessing

        // Cmdlets should never call WriteLine, or equivalent.
        protected override void BeginProcessing()
		{
			base.BeginProcessing();
		}
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
		}
		protected override void EndProcessing()
		{
			base.EndProcessing();
		}
		protected override void StopProcessing()
		{
			base.StopProcessing();
		}
		public compile_resource()
		{
		}
	}

	/* 
       This method of registering the Cmdlet with PowerShell extends the shell using snap-ins. This should
       be the default way of registering Cmdlets. The other way, registering with a custom shell,
       should only be used to create executable files.
     
       To install:
       1) installutil CmdletTest.dll
       2) Verify the snap in is in the list of registered snap-ins awaiting to be loaded by
          running "get-pssnapin -registered"
       3) Add the snap in to the shell by using "add-pssnapin "GetHjnntaaoPSSSnapIn01"
     */

	[RunInstaller(true)]
	public class Install: PSSnapIn
	{
		public override string Vendor {
			get {
				return "d3x0r.org";
			}
		}
		public override string Description {
			get {
				return "Compiles a .resx to a resource";
			}
		}
		public override string Name {
			get {
				return "Resource Compiler";
			}
		}
	}
}
