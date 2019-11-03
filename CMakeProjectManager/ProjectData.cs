using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using xperdex.classes;

namespace CMakeProjectManager
{
	static class ProjectData
	{
		static internal ProjectDataSet project_data_set;
		static internal ImageList images;
		static ProjectData()
		{
			images = new ImageList();

			images.Images.Add( new System.Drawing.Bitmap( 16, 16 ) );
			//images.Images.Add( CMakeProjectManager.Properties.Resources._2202 );
			images.Images.Add( CMakeProjectManager.Properties.Resources.Target);
			images.Images.Add( CMakeProjectManager.Properties.Resources.Project );
			images.Images.Add( CMakeProjectManager.Properties.Resources.FileTarget );
			
			project_data_set = new ProjectDataSet();
			if( File.Exists( Application.CommonAppDataPath + "CmakeManagerProjects.xml" ) )
			{
				try
				{
					project_data_set.ReadXml( Application.CommonAppDataPath + "CmakeManagerProjects.xml" );
				}
				catch( Exception e )
				{
					if( project_data_set.HasErrors )
					{
						foreach( DataTable table in project_data_set.Tables )
						{
							if( table.HasErrors )
							{
								Log.log( table.TableName + " is in error..." );
								DataRow[] rows = table.GetErrors();
								for( int i = 0; i < rows.Length; i++ )
								{
									for( int j = 0; j < table.Columns.Count; j++ )
									{
										Log.log( "Row" + rows[i].RowState + "[" + i + "][" + table.Columns[j].ColumnName + "] = " + rows[i][j] + " : " + rows[i].RowError );
									}
								}
							}
							//XDataTable<DataRow> mtable = table as XDataTable<DataRow>;
						}
						Log.log( "Failed to load.  Dumping what I hvae to bad.xml: " + e.Message );
						project_data_set.WriteXml( "M:\\bad.xml" );
					}
				}
			}
		}

		static internal void SaveProjects()
		{
			project_data_set.WriteXml( Application.CommonAppDataPath + "CmakeManagerProjects.xml" );			
		}
	}
}
