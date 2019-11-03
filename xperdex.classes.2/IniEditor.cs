using System;
using System.Windows.Forms;

namespace xperdex.classes
{
	public partial class INIEditor : Form
	{
		public INIEditor()
		{
			InitializeComponent();
		}

		INIFile map;

		public INIEditor( INIFile map )
		{
			InitializeComponent();
			this.map = map;
		}

		private void OptionEditor_Load( object sender, EventArgs e )
		{
			treeView1.AfterExpand += new TreeViewEventHandler( treeView1_AfterExpand );
			PopulateTree();
		}

		void PopulateTree()
		{
			treeView1.Nodes.Clear();
			if( map == null )
				map = INI.Default;// Default;
			if( map == null )
				return;
			foreach( INISection s in map )
			{
				TreeNode node;
				this.treeView1.Nodes.Add( node = new INITreeNode( s ) );
				foreach( INIEntry e in s )
				{
					this.treeView1.Nodes.Add( node = new INITreeNode( e ) );
                    node.Collapse();
                    node.Nodes.Add( "blank" );
                }

			}
		}

		void treeView1_AfterExpand( object sender, TreeViewEventArgs e )
		{
			INITreeNode node = e.Node as INITreeNode;
			node.Nodes.Clear();
			foreach( INIEntry entry in (INISection)node )
			{
				TreeNode newnode;
				node.Nodes.Add( newnode = new INITreeNode( entry ) );
				newnode.Nodes.Add( "blank" );
			}
			//throw new Exception( "The method or operation is not implemented." );
		}


		class INITreeNode : TreeNode
		{
			internal INISection s;
			internal INIEntry e;
			internal INITreeNode( INIEntry e )
			{
				this.e = e;
				this.Text = this.ToString();
			}

			internal INITreeNode( INISection s )
			{
				this.s = s;
				this.Text = this.ToString();
			}

			public static implicit operator INISection( INITreeNode t )
			{
				return t.s;
			}
			public static implicit operator INIEntry( INITreeNode t )
			{
				return t.e;
			}

			public override string ToString()
			{
				if( e.Value != null )
					return e.Name + "(=" + e.Value + ")";
				else
					return e.Name;
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			PopulateTree();
		}

		private void buttonUpdate_Click( object sender, EventArgs e )
		{
			INITreeNode node = treeView1.SelectedNode as INITreeNode;
			node.e.Value = textBox2.Text;
			if( node.Parent != null )
			{
				node.Parent.Collapse();
				node.Parent.Expand();
			}
			treeView1.SelectedNode = node;
		}

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			INITreeNode node = treeView1.SelectedNode as INITreeNode;
			textBox2.Text = node.e.Value;
			textBoxDescription.Text = node.e.Description;
		}

		void DeleteTree( TreeNode node )
		{
			if( node != null )
			{
				foreach( TreeNode subnode in node.Nodes )
					DeleteTree( subnode );
				node.Nodes.Clear();
				INITreeNode thisnode = node as INITreeNode;
				//if( thisnode != null && thisnode.e != null )
			//		thisnode.e.Delete();
				if( node.Parent != null )
					node.Parent.Nodes.Remove( node );
				else
					this.treeView1.Nodes.Remove( node );
			}
		}

		private void button1_Click_1( object sender, EventArgs e )
		{
			if( MessageBox.Show( "Are you sure you want to delete the selected branch?", "Convirm Deletion", MessageBoxButtons.YesNo ) == DialogResult.Yes )
			{
				DeleteTree( treeView1.SelectedNode );
			}
		}
	}
}