using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace monosh
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public class DirNode : TreeNode
		{
			public bool expanded;
			public DirectoryInfo dir;
			public DirNode( DirectoryInfo d )
			{
				this.Text = d.Name;
				dir = d;
			}
			public override string ToString()
			{
				return dir.Name;
			}
		}

		void ExpandPath( DirNode dir, int level )
		{
                    	bool child_not_expanded = false;
                	if( level == 0 )
                	foreach( DirNode node in dir.Nodes )
                    {
                        if( !node.expanded )
                            ExpandPath( node, 1 );
                            //child_not_expanded = true;
                        }
			if( child_not_expanded || !dir.expanded )
			{
				try
				{
					DirectoryInfo[] sub = dir.dir.GetDirectories();
					foreach( DirectoryInfo d in sub )
					{
						DirNode node;
						dir.Nodes.Add( node = new DirNode( d ) );
						//if( level < 2 )
						//   ExpandPath( node, level+1 );
					}
					dir.expanded = true;
				}
				catch( UnauthorizedAccessException access_denied )
				{
					dir.expanded = true;

				}
				catch( IOException access_denied )
				{
					dir.expanded = true;
				}
				catch( Exception e )
				{
					//Log.log( "unhandled" );
				}
			}
		}

		class FileItem : ListViewItem
		{
			public FileInfo file;
			public FileItem( FileInfo f )
			{
				file = f;
				this.Text = f.Name;
			}
		}

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			DirNode dir = treeView1.SelectedNode as DirNode;
			if( dir != null )
                        {
				ExpandPath( dir, 0 );
                                listViewPrograms.BeginUpdate();
				listViewPrograms.Items.Clear();
				try
				{

					FileInfo[] files = dir.dir.GetFiles();
					foreach( FileInfo file in files )
					{
						if( ( String.Compare( file.Extension, ".exe", true ) == 0 )
							|| ( String.Compare( file.Extension, ".bat", true ) == 0 )
							)
							listViewPrograms.Items.Add( new FileItem( file ) );
						listViewAllFiles.Items.Add( new FileItem( file ) );
					}
				}
				catch( UnauthorizedAccessException access_denied )
				{
				}
				catch( IOException access_denied )
				{
					// mgiht be a CD drive...
				}
				listViewPrograms.EndUpdate();
			}
		}
		private void treeView1_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			DirNode dir = e.Node as DirNode;
			if( dir != null )
                        {
				ExpandPath( dir, 0 );
                listViewPrograms.BeginUpdate();
				listViewPrograms.Items.Clear();
				listViewAllFiles.Items.Clear();
				try
				{

					FileInfo[] files = dir.dir.GetFiles();
					foreach( FileInfo file in files )
					{
						if( (  String.Compare( file.Extension, ".exe", true )== 0 )
							||(  String.Compare( file.Extension, ".bat", true )== 0 )
							)
							listViewPrograms.Items.Add( new FileItem( file ) );
						listViewAllFiles.Items.Add( new FileItem( file ) );
					}
				}
				catch( UnauthorizedAccessException access_denied )
				{
				}
                                listViewPrograms.EndUpdate();
			}
		}

		void FillList()
		{
			//System.IO.DriveInfo.
			treeView1.Nodes.Clear();
			DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
			foreach( DriveInfo drive in drives )
			{
				try
				{
					DirNode di = new DirNode( new System.IO.DirectoryInfo( drive.Name ) );
					treeView1.Nodes.Add( di );
					ExpandPath( di, 0 );
				}
				catch
				{
				}
			}
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			FillList();
		}

		private void listView1_DoubleClick( object sender, EventArgs e )
		{
			foreach( ListViewItem item in listViewPrograms.SelectedItems )
			{
				FileItem file = item as FileItem;
				if( file != null )
				{
					xperdex.tasks.TaskItem task = 
						new xperdex.tasks.TaskItem( file.file.Name, file.file.DirectoryName );
					task.Execute();
				}
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			FillList();
		}

	}
}
