using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Xml.XPath;
using System.IO;
using System.Xml;
using xperdex.classes.Types;

namespace CheckSolutionReferences
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}


		struct project_tag {
			public string name;
		} 
		List<String> projects = new List<string>();


		String ConcatPath( string root, string relative )
		{
			String result = root + "\\" + relative;
			XString xresult = new XString( result, "/\\", null, false, false );
			for( int n = 0; n < xresult.Count; n++ )
			{
				if( (string)( xresult[n] ) == ".." )
				{
					xresult.RemoveAt( n - 2 );
					xresult.RemoveAt( n - 2 );
					xresult.RemoveAt( n - 2 );
					xresult.RemoveAt( n - 2 );
					n -= 3;
				}
			}
			return xresult.ToString();
		}

		void ScanPath( String path )
		{
			FileStream file = new FileStream( path, FileMode.Open );
			//StringReader sr = new StringReader( 
			StreamReader sr = new StreamReader( file );

			String s;
			while( !sr.EndOfStream )
			{
				XString parsed_string;
				s = sr.ReadLine();

				parsed_string = new XString( s, "()\"=,", " ", true, true );
				if( parsed_string.Count > 0 )
				if( (String)(parsed_string[0]) == "Project" )
				{
					int n;
					String project = null;
					for( n = 0; ( 12 + n ) < parsed_string.Count; n++ )
					{
						String newseg = (String)( parsed_string[12 + n] );
						project = project + newseg;
						if( ( newseg != ".." )
							&& ( newseg != "\\.." )
							&& ( newseg != "\\" )
							&& ( newseg != "/" ) )
							break;
					}
					
					projects.Add( ConcatPath( Environment.CurrentDirectory, project ) );
				}
			}
			sr.Close();

			foreach( String zfile in projects )
			{

				XString zfile_path = new XString( zfile, "/\\", null, false, false );
				zfile_path.RemoveAt( zfile_path.Count - 1 );
				zfile_path.RemoveAt( zfile_path.Count - 1 );
				bool updated = false;
				XmlDocument xd = new XmlDocument();
				try
				{
					xd.Load( zfile );
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
					if( xn.Name == "ItemGroup" )
					{
						bool found_outpath = false;
						bool found_intermed_1 = false;
						bool found_intermed_2 = false;
						bool found_base_output = false;
						bool found_framework = false;
						bool ok2;
						bool ever_ok2 = false;

						bool found_condition = false;

						ever_ok2 = false;
						for( ok2 = xn.MoveToFirstChild(); ok2; ok2 = xn.MoveToNext() )
						{
							ever_ok2 = true;
							if( xn.Name == "ProjectReference" )
							{
								bool ever_ok3 = false;
								for( bool ok3 = xn.MoveToFirstAttribute(); ok3; ok3 = xn.MoveToNextAttribute() )
								{
									ever_ok3 = true;
									if( xn.Name == "Include" )
									{
										String fullpath = ConcatPath( zfile_path, xn.Value );
										if( !projects.Contains( fullpath ) )
										{
											listBox1.Items.Add( zfile + " references " + xn.Value );
										}
									}
								}
								if( ever_ok3 )
									xn.MoveToParent();
							}							
						}
						if( ever_ok2 )
						{
							xn.MoveToParent();
						}
					}
				}
				//else
				//    listBox1.Items.Add( "Ignore:"+file );
				listBox1.Refresh();

			}

		}

		private void Form1_Load( object sender, EventArgs e )
		{
			INIControl.EnableDialog = true;
			String default_path = INI.Default["Default Path3"]["path"].Value;

			OpenFileDialog ofd = new OpenFileDialog();
			DialogResult dr = ofd.ShowDialog();
			ofd.RestoreDirectory = false;
			ofd.InitialDirectory = INI.Default["Default Path3"]["path"].Value;


			if( dr == System.Windows.Forms.DialogResult.OK )
			{

				INI.Default["Default Path3"]["path"].Value = ofd.FileName;
				{
					XString tmp = new XString( ofd.FileName, "/\\", null, false, false );
					tmp.RemoveAt( tmp.Count - 1 );
					Environment.CurrentDirectory = tmp;
				}
				listBox1.Items.Add( "Chose:" + ofd.FileName );
				Refresh();
				ScanPath( ofd.FileName );
				listBox1.Items.Add( "Completed Updates..." );
			}
			else
				Close();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			Close();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			INIControl.EnableDialog = true;
			String default_path = INI.Default["Default Path3"]["path"].Value;
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
