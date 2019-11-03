using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace SetCLR
{
    class Program
    {


        static void ScanPath( String path )
        {
            string ] files = Directory.GetFiles( path, ".vcxproj", SearchOption.AllDirectories );
            foreach( String file in files )
            {

                bool updated = false;
                if( file.Contains( "INSTALL.vcxproj" ) )
                    continue;
                if( file.Contains( "ZERO_CHECK.vcxproj" ) )
                    continue;
                if( file.Contains( "ALL_BUILD.vcxproj" ) )
                    continue;
                if( file.Contains( "PACKAGE.vcxproj" ) )
                    continue;
                if( file.Contains( "bag.externals.vcxproj" ) )
                    continue;
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
                bool found_project_import = false;
                bool found_target = false;
                okay = xn.MoveToFirstChild();
                while( xn.NodeType == XPathNodeType.Comment )
                    okay = xn.MoveToNext();
                for( okay = xn.MoveToFirstChild(); okay; okay = xn.MoveToNext() )
                {
                    retry:
                    if( xn.Name == "Import" )
                    {
                        bool ok2;
                        bool ever_ok2 = false;

                        bool found_condition = false;
                        for( ok2 = xn.MoveToFirstAttribute(); ok2; ok2 = xn.MoveToNextAttribute() )
                        {
                            ever_ok2 = true;
                            if( xn.Name == "Project" && xn.Value == "$(VCTargetsPath)\\Microsoft.Cpp.targets" )
                            {
                                found_project_import = true;
                                found_target = false;
                            }
                        }
                        if( ever_ok2 )
                        {
                            xn.MoveToParent();
                        }
                    }
                    else if( xn.Name == "Target" )
                    {
                        found_target = true;
                    }
                    else if( xn.Name == "ImportGroup" )
                    {
                        if( found_project_import && !found_target )
                        {
                            xn.InsertElementBefore( null, "Target", null, null );
                            xn.MoveToPrevious();
                            xn.CreateAttribute( null, "Name", null, "GenerateTargetFrameworkMonikerAttribute" );
                            xn.MoveToNext();
                            updated = true;
                        }
                    }
                    else if( xn.Name == "PropertyGroup" )
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
                            if( xn.Name == "Label" )
                            {
                                if( xn.Value == "Globals" )
                                    found_condition = true;
                                break;
                            }
                        }
                        if( ever_ok2 )
                            xn.MoveToParent();

                        bool found_support = false;
                        bool found_version = false;
                        ever_ok2 = false;
                        for( ok2 = xn.MoveToFirstChild(); ok2; ok2 = xn.MoveToNext() )
                        {
                            ever_ok2 = true;
                            if( xn.Name == "TargetFrameworkVersion" )
                            {
                                found_framework = true;
                                if( found_condition )
                                {
                                    xn.SetValue( "v4.0" );
                                    updated = true;
                                }
                            }
                            if( xn.Name == "CLRSupport" )
                            {
                                found_support = true;
                                if( found_condition )
                                {
                                    xn.SetValue( "true" );
                                    updated = true;
                                }
                                else
                                {
                                    xn.DeleteSelf();
                                    xn.MoveToFirstChild();
                                }
                            }
                            //    < TargetFrameworkVersion Condition = "'$(TargetFrameworkVersion)'==''" > v2.0 </ TargetFrameworkVersion >
                        }
                        if( ever_ok2 )
                        {
                            xn.MoveToParent();
                            if( found_condition )
                            {
                                if( !found_support )
                                {
                                    xn.AppendChildElement( null, "CLRSupport", null, "true" );
                                    updated = true;
                                }
                                if( !found_framework )
                                {
                                    xn.AppendChildElement( null, "TargetFrameworkVersion", null, "v4.0" );
                                    updated = true;
                                }
                            }
                        }
                        found_condition = false;

                    }
                }
                if( updated )
                {
                    //listBox1.Items.Add( file );
                    if( !File.Exists( file + ".backup" ) )
                        File.Copy( file, file + ".backup" );
                    xd.Save( file );
                }
                //else
                //    listBox1.Items.Add( "Ignore:"+file );
                //listBox1.Refresh();

            }

        }


        static void Main( string ] args )
        {
            //ScanPath( args.Length > 0 ? args[0] : "." );
            ScanPath( args.Length > 0 ? args[0] : "c:/general/build/sack-clr/debug_solution/core" );
        }
    }
}
