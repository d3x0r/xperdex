using System;
using System.Data;
using System.Windows.Forms;

namespace CMakeProjectManager.TreeviewNodes
{
	class TargetSourceNode: TreeNode
	{
		DataRow target_source;
		public TargetSourceNode( DataRow target_source )
		{
			this.target_source = target_source;
			this.Text = target_source["name"] as String;
			this.ImageIndex = 3;
		}
		

	}
}
