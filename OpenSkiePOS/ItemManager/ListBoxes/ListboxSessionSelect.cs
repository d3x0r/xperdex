using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using System.Data;
using xperdex.core.interfaces;

namespace ItemManager
{
	[ControlAttribute( Name="Macro Session Select" )]
	class ListboxSessionSelect: XListbox
	{

		public ListboxSessionSelect()
		{
			InitializeComponent();
			this.DataSource = ItemManagmentState.item_dataset.sessions;
			//this.DisplayMember = "ToString";
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ListboxSessionSelect
			// 
			this.SelectedValueChanged += new System.EventHandler(this.ListboxSessionSelect_SelectedValueChanged);
			this.ResumeLayout(false);

		}

		private void ListboxSessionSelect_SelectedValueChanged( object sender, EventArgs e )
		{
			if( this.SelectedValue != null )
				ItemManagmentState.current_session = (this.SelectedValue as DataRowView).Row;
		}
	}
}
