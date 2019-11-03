using System;
using System.Data;
using System.Windows.Forms;

namespace CMakeProjectManager.TreeviewNodes
{
	internal class TargetNode : TreeNode
	{
		internal DataRow target;
		public TargetNode(DataRow target)
		{
			this.target = target;
			this.Text = target["name"] as String;
			this.ImageIndex = 2;
		}
		
	}
}
