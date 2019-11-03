using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestSQLParse
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

			
			xperdex.classes.SQL_Utilities.CreateTable( "create table test ( id int )" );


			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault( false );
			//Application.Run( new Form1() );
		}
	}
}