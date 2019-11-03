using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.classes;

namespace SetBuildOutput
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		void ScanPath( String path )
		{
			string[] files = Directory.GetFiles( path, "*.csproj", SearchOption.AllDirectories );
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
				while( xn.NodeType == XPathNodeType.Comment )
					okay = xn.MoveToNext();
				for( okay = xn.MoveToFirstChild(); okay; okay = xn.MoveToNext() )
				{
				retry:
					if( xn.Name == "PropertyGroup" )
					{
						bool found_outpath = false;
						bool found_intermed_1 = false;
						bool found_intermed_2 = false;
						bool found_base_output = false;
						bool found_framework = false;
						bool ok2;
						bool ever_ok2 = false;

						bool found_condition = false;
						for( ok2 = xn.MoveToFirstAttribute(); ok2; ok2 = xn.MoveToNextAttribute() )
						{
							ever_ok2 = true;
							if( xn.Name == "Condition" )
							{
								found_condition = true;
								break;
							}
						}
						if( ever_ok2 )
							xn.MoveToParent();

						ever_ok2 = false;
						for( ok2 = xn.MoveToFirstChild(); ok2; ok2 = xn.MoveToNext() )
						{
							ever_ok2 = true;
							if( xn.Name == "TargetFrameworkVersion" )
							{
								found_framework = true;
								target_framework = xn.Value;
							}
							if( xn.Name == "BaseOutputPath" )
							{
								if( found_base_output || found_condition )
								{
									xn.DeleteSelf();
									xn.MoveToFirstChild();
									updated = true;
									found_base_output = false;
									continue;
								}
								found_base_output = true;
								if( String.Compare( xn.Value, "$(SolutionDir)/", true ) != 0 )
								{
									xn.SetValue( "$(SolutionDir)/" );
									updated = true;
								}
							}
							if( xn.Name == "OutputPath" )
							{
								if( found_outpath || !found_condition )
								{
									xn.DeleteSelf();
									xn.MoveToFirstChild();
									updated = true;
									found_outpath = false;
									continue;
								}
								String old_value = xn.Value;
								found_outpath = true;
								if( String.Compare( old_value, "$(BaseOutputPath)/output/$(Configuration)/$(Platform)/" + target_framework, true ) != 0 )
								{
									xn.SetValue( "$(BaseOutputPath)/output/$(Configuration)/$(Platform)/" + target_framework );
									updated = true;
								}
							}
							if( xn.Name == "BaseIntermediateOutputPath" )
							{
								if( found_intermed_1 || found_condition )
								{
									xn.DeleteSelf();
									xn.MoveToFirstChild();
									updated = true;
									found_intermed_1 = false;

									continue;
								}
								String old_value = xn.Value;
								found_intermed_1 = true;
								if( String.Compare( old_value, "$(SolutionDir)/output/", true ) != 0 )
								{
									xn.SetValue( "$(SolutionDir)/output/" );
									updated = true;
								}
							}
							if( xn.Name == "IntermediateOutputPath" )
							{
								if( found_intermed_2 || !found_condition )
								{
									xn.DeleteSelf();
									xn.MoveToFirstChild();
									updated = true;
									found_intermed_2 = false;
									continue;
								}
								String new_value = "$(BaseIntermediateOutputPath)obj/$(MSBuildProjectName)/$(Configuration)/$(Platform)/" + target_framework;
								String old_value = xn.Value;
								found_intermed_2 = true;
								if( String.Compare( old_value, new_value, true ) != 0 )
								{
									xn.SetValue( new_value );
									updated = true;
								}
							}
						}
						if( ever_ok2 )
						{
							xn.MoveToParent();
						}
						if( !found_base_output && found_framework && !found_condition )
						{
							xn.AppendChildElement( null, "BaseOutputPath", null, "$(SolutionDir)/" );
							updated = true;
						}
						if( !found_outpath && found_condition )
						{
							xn.AppendChildElement( null, "OutputPath", null, "$(BaseOutputPath)/output/$(Configuration)/$(Platform)/" + target_framework );
							updated = true;
						}
						if( !found_intermed_1 && !found_condition )
						{
							xn.AppendChildElement( null, "BaseIntermediateOutputPath", null, "$(SolutionDir)/output/" );
							updated = true;
						}
						if( !found_intermed_2 && found_condition )
						{
							String new_value = "$(BaseIntermediateOutputPath)obj/$(MSBuildProjectName)/$(Configuration)/$(Platform)/" + target_framework;
							xn.AppendChildElement( null, "IntermediateOutputPath", null, new_value );
							updated = true;
						}
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
			String default_path = INI.Default["Default Path2"]["path"].Value;
			FolderBrowserDialog fb = new FolderBrowserDialog();
			fb.SelectedPath = default_path;
			if( fb.ShowDialog() == DialogResult.OK )
			{
				INI.Default["Default Path"]["path"].Value = fb.SelectedPath;
				listBox1.Items.Add( "Chose:" + fb.SelectedPath );
				Refresh();
				ScanPath( fb.SelectedPath );
				listBox1.Items.Add( "Completed Updates..." );
			}
			else
				Close();
		}
	}
}