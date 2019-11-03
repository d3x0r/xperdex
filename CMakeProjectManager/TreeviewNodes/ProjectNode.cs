using System;
using System.Data;
using System.Windows.Forms;

namespace CMakeProjectManager.TreeviewNodes
{
	public class ProjectNode: TreeNode
	{
		//TreeViewItem tvi = ;
			internal DataRow project;
			public ProjectNode(DataRow project)
			{
				this.project = project;
				this.Text = project["name"] as String;
				this.ImageIndex = 1;
			}
		

	}
}
