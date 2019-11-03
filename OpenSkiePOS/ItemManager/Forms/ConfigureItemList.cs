using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace ItemManager.Forms
{
	public class ConfigureItemList: Form
	{
		string original_type;
		ListboxItemDescriptions item_list;
		public ConfigureItemList( ListboxItemDescriptions items_list )
		{
			original_type = items_list.inventory_type_filter;
			item_list = items_list;
			InitializeComponent();
		}

		private ListBox listBox1;
		private System.ComponentModel.IContainer components;
		private Button button1;
		private Button button2;
		private Label label1;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.DataSource = ItemManagmentState.inventory_types;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 37);
			this.listBox1.Name = "listBox1";
			this.listBox1.DisplayMember = "inv_type";
			this.listBox1.Size = new System.Drawing.Size(260, 160);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(116, 227);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(197, 227);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Select Inventory Type To Show";
			// 
			// ConfigureItemList
			// 
			this.AcceptButton = this.button1;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Name = "ConfigureItemList";
			this.Text = "Select Inventory Type To Show";
			this.Load += new System.EventHandler(this.ConfigureItemList_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void ConfigureItemList_Load( object sender, EventArgs e )
		{
			object selection = null;
			foreach( object item in listBox1.Items )
			{
				DataRowView drv = item as DataRowView;
				if( String.Compare( drv.Row["inv_type"].ToString(), item_list.inventory_type_filter, true ) == 0 )
				{
					selection = item;
					break;
				}

			}
			if( selection != null )
				listBox1.SelectedItem = selection;
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			item_list.inventory_type_filter = ( listBox1.SelectedItem as DataRowView ).Row["inv_type"].ToString();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			item_list.inventory_type_filter = original_type;
		}
	}
}
