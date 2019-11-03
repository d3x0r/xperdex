/*
 * Created by SharpDevelop.
 * User: d3x0r
 * Date: 11/27/2009
 * Time: 1:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Resources;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PowerShell.support
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class ResourceCompiler
	{
		public static void Compile( string infile, string outfile )
		{
			ResXResourceReader reader = new ResXResourceReader( infile );
			ResourceWriter writer = new ResourceWriter( outfile );
			IDictionaryEnumerator en = reader.GetEnumerator();
			while( en.MoveNext() )
				writer.AddResource( (string)en.Key, (object)en.Value );
			writer.Close();
		}
		
	}
}