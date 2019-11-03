using System;
using System.Windows.Forms;

namespace xperdex.classes
{
	public partial class OptionEditor : Form
	{
		public OptionEditor()
		{
			InitializeComponent();
		}

		OptionMap map;

		public OptionEditor( OptionMap map )
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
				map = Options.options;// Default;
			if( map == null )
				return;
			foreach( OptionEntry e in map )
			{
				TreeNode node;
                if( !e.section.ID.Equals( e.sub_options.ID ) )
                {
                    this.treeView1.Nodes.Add( node = new OptionTreeNode( e ) );
                    ( (OptionMap)e ).ReadBranch();
                    node.Collapse();
                    node.Nodes.Add( "blank" );
                }

			}
		}

		void treeView1_AfterExpand( object sender, TreeViewEventArgs e )
		{
			OptionTreeNode node = e.Node as OptionTreeNode;
			node.Nodes.Clear();
			foreach( OptionEntry entry in (OptionMap)node )
			{
				TreeNode newnode;
				node.Nodes.Add( newnode = new OptionTreeNode( entry ) );
				( (OptionMap)entry ).ReadBranch();
				newnode.Nodes.Add( "blank" );
			}
			//throw new Exception( "The method or operation is not implemented." );
		}


		class OptionTreeNode : TreeNode
		{
			internal OptionEntry e;
			internal OptionTreeNode( OptionEntry e )
			{
				this.e = e;
				this.Text = this.ToString();
			}

			public static implicit operator OptionEntry( OptionTreeNode t )
			{
				return t.e;
			}
			public static implicit operator OptionMap( OptionTreeNode t )
			{
				return (OptionMap)t.e;
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
			OptionTreeNode node = treeView1.SelectedNode as OptionTreeNode;
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
			OptionTreeNode node = treeView1.SelectedNode as OptionTreeNode;
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
				OptionTreeNode thisnode = node as OptionTreeNode;
				if( thisnode != null && thisnode.e != null )
					thisnode.e.Delete();
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