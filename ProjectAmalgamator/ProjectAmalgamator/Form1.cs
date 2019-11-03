using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.classes;
using xperdex.classes.Types;

namespace ProjectAmalgamator
{
	public partial class Form1 : Form
	{
		List<String> sources;
		List<String> predefined;
		List<String> predefined_syms;
		List<String> includes;
		List<String> real_includes;

		public Form1()
		{
			sources = new List<string>();
			predefined = new List<string>();
			predefined_syms = new List<string>();
			includes = new List<string>();
			real_includes = new List<string>();
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{

		}

		void ProcessIncludes()
		{
			string collection = "";
			foreach( String include in includes )
			{
				XString words = new XString( include, true );
				foreach( XStringSeg word in words )
				{
					if( word == ";" )
					{
						if( collection != "" )
						{
							if( !real_includes.Contains( collection ) )
							{
								real_includes.Add( collection );
							}
							collection = "";
						}
						continue;
					}
					collection += word;
				}
			}
			if( collection != "" )
				if( !real_includes.Contains( collection ) )
					real_includes.Add( collection );
		}

		void ProcessPredefs()
		{
			string collection = "";
			foreach( String defines in predefined )
			{
				XString words = new XString( defines, true );
				foreach( XStringSeg word in words )
				{
					if( word == ";" )
					{
						if( collection != "" )
						{
							if( !predefined_syms.Contains( collection ) )
							{
								if( ( String.Compare( collection, 0, "TARGET_LABEL=", 0, 13 ) != 0 )
									&& ( String.Compare( collection, 0, "TARGETNAME=", 0, 10 ) != 0 ) )
									predefined_syms.Add( collection );
							}
						}
						collection = "";
						continue;
					}
					collection += word;
				}
			}
			if( collection != "" )
				if( !predefined_syms.Contains( collection ) )
					predefined_syms.Add( collection );
		}

		void ScanPath( String path )
		{
			string[] files = Directory.GetFiles( path, "*.vcxproj", SearchOption.AllDirectories );
			foreach( String file in files )
			{
				bool updated = false;
				XmlDocument xd = new XmlDocument();
				try
				{
					xd.Load( file );
				}
				catch
				{
					continue;
				}
				XPathNavigator xn = xd.CreateNavigator();
				xn.MoveToFirst();
				String target_framework = null;
				bool okay;
				okay = xn.MoveToFirstChild();
				for( okay = xn.MoveToFirstChild(); okay; okay = xn.MoveToNext() )
				{
					if( xn.Name == "ItemDefinitionGroup" )
					{
						bool ok2;
						bool ever_ok2 = false;
						for( ok2 = xn.MoveToFirstChild(); ok2; ok2 = xn.MoveToNext() )
						{
							ever_ok2 = true;
							if( xn.Name == "ClCompile" )
							{
								bool ok3;
								bool ever_ok3 = false;
								for( ok3 = xn.MoveToFirstChild(); ok3; ok3 = xn.MoveToNext() )
								{
									ever_ok3 = true;
									if( xn.Name == "AdditionalIncludeDirectories" )
									{
										if( !includes.Contains( xn.Value ) )
											includes.Add( xn.Value );
									}
									if( xn.Name == "PreprocessorDefinitions" )
									{
										predefined.Add( xn.Value );
									}
								}
								if( ever_ok3 )
									xn.MoveToParent();
							}
						}
						if( ever_ok2 )
							xn.MoveToParent();
					}
					if( xn.Name == "ItemGroup" )
					{
						bool ok2;
						bool ever_ok2 = false;
						for( ok2 = xn.MoveToFirstChild(); ok2; ok2 = xn.MoveToNext() )
						{
							ever_ok2 = true;
							if( xn.Name == "ClCompile" )
							{
								bool ok3;
								bool ever_ok3 = false;
								for( ok3 = xn.MoveToFirstAttribute(); ok3; ok3 = xn.MoveToNextAttribute() )
								{
									ever_ok3 = true;
									if( xn.Name == "Include" )
									{
										sources.Add( xn.Value );
									}
								}
								if( ever_ok3 )
									xn.MoveToParent();
							}
						}
						if( ever_ok2 )
							xn.MoveToParent();

					}

					if( xn.Name == "PropertyGroup" )
					{
						bool ok2;
						bool ever_ok2 = false;
						for( ok2 = xn.MoveToFirstChild(); ok2; ok2 = xn.MoveToNext() )
						{
							ever_ok2 = true;
							if( xn.Name == "TargetFrameworkVersion" )
							{
								target_framework = xn.Value;
							}
							if( xn.Name == "OutputPath" )
							{
								String old_value = xn.Value;
								if( String.Compare( old_value, "$(SolutionDir)/output/$(Configuration)/$(Platform)/" + target_framework, true ) != 0 )
								{
									xn.SetValue( "$(SolutionDir)/output/$(Configuration)/$(Platform)/" + target_framework );
									updated = true;
								}
							}
						}
						if( ever_ok2 )
							xn.MoveToParent();
					}
				}
				if( updated )
				{
					listBox1.Items.Add( file );
					if( !File.Exists( file + ".backup" ) )
						File.Copy( file, file + ".backup" );
					xd.Save( file );
				}
				//else
				//    listBox1.Items.Add( "Ignore:"+file );
				listBox1.Refresh();

			}

		}

		private void Form1_Load( object sender, EventArgs e )
		{
			INIControl.EnableDialog = true;
			String default_path = INI.Default["Default Path2"]["path", "C:\\general\\develop\\vs10\\eltanin_android\\build"].Value;
			default_path = "C:\\general\\develop\\vs10\\eltanin_android\\build";
			FolderBrowserDialog fb = new FolderBrowserDialog();
			fb.SelectedPath = default_path;
			fb.RootFolder = Environment.SpecialFolder.MyComputer;
			//fb.RootFolder = Environment.SpecialFolder.default_path;
			if( fb.ShowDialog() == DialogResult.OK )
			{
				INI.Default["Default Path2"]["path"].Value = fb.SelectedPath;
				listBox1.Items.Add( "Chose:" + fb.SelectedPath );
				Refresh();
				ScanPath( fb.SelectedPath );
				ProcessPredefs();
				ProcessIncludes();
				listBox1.Items.Add( "Completed Updates..." );
			}
			else
				Close();
		}
	
	}
}
