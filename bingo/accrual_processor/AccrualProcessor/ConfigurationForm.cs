using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace ECube.AccrualProcessor
{
	public partial class ConfigurationForm : Form
	{
		public ConfigurationForm()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			xperdex.classes.QueryNewName query = new xperdex.classes.QueryNewName( "Enter Accrual Name" );
			if( query.ShowDialog() == System.Windows.Forms.DialogResult.OK )
			{
				String s = query.textBox1.Text;
				AccrualGroup new_group = Local.CreateAccrual( s );
				new_group.AnySession = true;
				//Local.CreateAccount( s );
			}
		}

		private void ConfigurationForm_Load( object sender, EventArgs e )
		{
			//listBoxAccounts.DataSource = Local.jackpot_table;
			//listBoxAccounts.DisplayMember = JackpotLedger.JackpotLedgerTable.NameColumn;
			Local.ConfigureState.Lists.Add( listBoxAccruals );
			listBoxAccruals.DataSource = Local.accrual_group_table;
			listBoxAccruals.DisplayMember = AccrualGroup.AccrualGroupTable.NameColumn;

			dataGridViewSesSlotConfig.AllowUserToAddRows = false;
			dataGridViewSesSlotConfig.AllowUserToDeleteRows = false;
			dataGridViewSesSlotConfig.RowHeadersVisible = false;
			dataGridViewSesSlotConfig.Columns.Add( "Session Name", "Session Name" );
			dataGridViewSesSlotConfig.Columns[0].Width = 140;
			dataGridViewSesSlotConfig.Columns.Add( new DataGridViewCheckBoxColumn() );
			dataGridViewSesSlotConfig.Columns[1].HeaderText = "Use";
			dataGridViewSesSlotConfig.Columns[1].Width = 30;
			dataGridViewSesSlotConfig.Columns.Add( "row", "row" );
			dataGridViewSesSlotConfig.Columns[2].Visible = false;

			object[] row = new object[3];
			DataRowCollection rows;
			String colname;
			if( Local.use_program_relation )
			{
				rows = Local.BingoDataSet.program.Rows;
				colname = "prg_desc";
			}
			else
			{
				rows = Local.BingoDataSet.sesslot.Rows;
				colname = "slt_desc";
			}
			foreach( DataRow slot in rows )
			{
				row[0] = Local.TrimString( slot[colname].ToString() );
				if( Local.useSesSlot.Contains( slot ) )
					row[1] = true;
				else
					row[1] = false;
				row[2] = slot;
				dataGridViewSesSlotConfig.Rows.Add( row );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			if( Local.ConfigureState._current_accrual_group != null )
			{
				ConfigureAccrualForm form = new ConfigureAccrualForm();
				form.ShowDialog();
				form.Dispose();
			}
			else
				MessageBox.Show( "Please reselect an accrual group to configure" );
		}

		private void listBoxAccounts_SelectedIndexChanged( object sender, EventArgs e )
		{

		}

		private void listBoxAccruals_SelectedIndexChanged( object sender, EventArgs e )
		{
			object o = listBoxAccruals.SelectedItem;
			DataRowView drv = o as DataRowView;
			if( drv != null )
				Local.ConfigureState.current_accrual_group = drv.Row;
		}

		private void buttonApplyChanges_Click( object sender, EventArgs e )
		{
			listBoxAccruals.DataSource = null;
			Local.ConfigureState.Lists.Remove( listBoxAccruals );
			Close();
		}

		private void button2_Click_1( object sender, EventArgs e )
		{
			Local.useSesSlot.Clear();
			foreach( DataGridViewRow row in dataGridViewSesSlotConfig.Rows )
			{
				if( Local.use_program_relation )
				{
					if( (bool)row.Cells[1].Value )
					{
						Local.useSesSlot.Add( row.Cells[2].Value as DataRow );
						xperdex.classes.INI.Default["Accrual Processor"]["program/" + row.Cells[0].Value].Bool = true;
					}
					else
						xperdex.classes.INI.Default["Accrual Processor"]["program/" + row.Cells[0].Value].Bool = false;
				}
				else
				{
					if( (bool)row.Cells[1].Value )
					{
						Local.useSesSlot.Add( row.Cells[2].Value as DataRow );
						xperdex.classes.INI.Default["Accrual Processor"]["session/" + row.Cells[0].Value].Bool = true;
					}
					else
						xperdex.classes.INI.Default["Accrual Processor"]["session/" + row.Cells[0].Value].Bool = false;
				}
			}

			Local.session_select_set_string = "";
			bool first = true;
			if( Local.use_program_relation )
			{
				foreach( DataRow row in Local.useSesSlot )
				{
					if( !first )
						Local.session_select_set_string += ",";
					first = false;
					Local.session_select_set_string += row["prg_id"];
				}
			}
			else
			{
				foreach( DataRow row in Local.useSesSlot )
				{
					if( !first )
						Local.session_select_set_string += ",";
					first = false;
					Local.session_select_set_string += row["slt_id"];
				}
			}
		}

		private void buttonSaveAccruals_Click( object sender, EventArgs e )
		{
			SaveFileDialog ofd = new SaveFileDialog();
			ofd.FileName = "Accrual_Definitions.xml";
			ofd.ShowDialog();
			if( ofd.FileName != null && ofd.FileName.Length > 0 )
			{
				DataSet ds_write = Local.BingoDataSet.Copy();
				String[] save_names = new String[]{ AccrualGroup.AccrualGroupTable.TableName
						, AccrualGroup.AccrualGroupTable.AccrualGroupInputCategoryTable.TableName
						, AccrualGroup.AccrualGroupTable.AccrualGroupInputListPickTable.TableName
						, AccrualGroup.AccrualGroupTable.AccrualGroupInputProgramTable.TableName
						, AccrualGroup.AccrualGroupTable.AccrualGroupInputSessionTable.TableName };
				ds_write.EnforceConstraints = false;
				foreach( DataTable dt in ds_write.Tables )
				{
					bool found = false;
					foreach( String name in save_names )
						if( String.Compare( name, dt.TableName, true ) == 0 )
						{
							found = true; break;
						}
					if( dt.Rows.Count > 0 )
						xperdex.classes.Log.log( dt.TableName + "Table has some rows..." );
					if( !found )
						dt.Clear();
				}
				ds_write.WriteXml( ofd.FileName );
			}
			ofd.Dispose();
		}

		void MergeConfiguration(DataSet new_settings)
		{
			foreach( DataRow row in new_settings.Tables[AccrualGroup.AccrualGroupTable.TableName].Rows )
			{
				DataRow[] rows = Local.accrual_group_table.Select( AccrualGroup.AccrualGroupTable.PrimaryKey + "='" + row[AccrualGroup.AccrualGroupTable.PrimaryKey] +"'" );
				if( rows.Length > 0 )
				{
					DataRow editrow = rows[0];
					foreach( DataColumn dc in Local.accrual_group_table.Columns )
					{
						if( dc.ColumnName != "last_accrument"
							&& dc.ColumnName != AccrualGroup.AccrualGroupTable.PrimaryKey )
							editrow[dc.ColumnName] = row[dc.ColumnName];
					}
				}
				else
				{
					DataRow newrow = Local.accrual_group_table.NewRow();
					foreach( DataColumn dc in Local.accrual_group_table.Columns )
					{
						if( dc.ColumnName != "last_accrument" )
							newrow[dc.ColumnName] = row[dc.ColumnName];
					}
					Local.accrual_group_table.Rows.Add( newrow );

				}
			}
			Local.accrual_group_category_table.Clear();
			foreach( DataRow row in new_settings.Tables[AccrualGroup.AccrualGroupTable.AccrualGroupInputCategoryTable.TableName].Rows )
			{
				DataRow newrow = Local.accrual_group_category_table.NewRow();
				foreach( DataColumn dc in Local.accrual_group_category_table.Columns )
					newrow[dc.ColumnName] = row[dc.ColumnName];
				Local.accrual_group_category_table.Rows.Add( newrow );
			}

			Local.accrual_group_item_table.Clear();
			foreach( DataRow row in new_settings.Tables[AccrualGroup.AccrualGroupTable.AccrualGroupInputListPickTable.TableName].Rows )
			{
				DataRow newrow = Local.accrual_group_item_table.NewRow();
				foreach( DataColumn dc in Local.accrual_group_item_table.Columns )
					newrow[dc.ColumnName] = row[dc.ColumnName];
				Local.accrual_group_item_table.Rows.Add( newrow );
			}
			Local.accrual_group_session_table.Clear();
			foreach( DataRow row in new_settings.Tables[AccrualGroup.AccrualGroupTable.AccrualGroupInputSessionTable.TableName].Rows )
			{
				DataRow newrow = Local.accrual_group_session_table.NewRow();
				foreach( DataColumn dc in Local.accrual_group_session_table.Columns )
					newrow[dc.ColumnName] = row[dc.ColumnName];
				Local.accrual_group_session_table.Rows.Add( newrow );
			}
			Local.accrual_group_program_table.Clear();
			foreach( DataRow row in new_settings.Tables[AccrualGroup.AccrualGroupTable.AccrualGroupInputProgramTable.TableName].Rows )
			{
				DataRow newrow = Local.accrual_group_program_table.NewRow();
				foreach( DataColumn dc in Local.accrual_group_program_table.Columns )
					newrow[dc.ColumnName] = row[dc.ColumnName];
				Local.accrual_group_program_table.Rows.Add( newrow );
			}
			{
				DataTable percentages = Local.BingoDataSet.Tables[AccrualGroup.AccrualPercentageTable.TableName];
				percentages.Clear();
				foreach( DataRow row in new_settings.Tables[AccrualGroup.AccrualPercentageTable.TableName].Rows )
				{
					DataRow newrow = percentages.NewRow();
					foreach( DataColumn dc in percentages.Columns )
						newrow[dc.ColumnName] = row[dc.ColumnName];
					percentages.Rows.Add( newrow );
				}
			}
			Local.CommitSettingChanges();
			Local.ReloadAccrualGroups( false );
			this.Close();
		}

		private void buttonLoadAccruals_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			//ofd.ReadOnlyChecked = true;
			ofd.CheckFileExists = true;
			ofd.FileName = "Accrual_Definitions.xml";
			ofd.ShowDialog();
			if( ofd.FileName != null && ofd.FileName.Length > 0 )
			{
				DataSet ds_read = new bingoDataSet.bingoDataSet();
				new AccrualGroup.AccrualGroupTable( ds_read );
				new AccrualGroup.AccrualPercentageTable( ds_read );
				new AccrualGroup.AccrualGroupTable.AccrualGroupInputSessionTable( ds_read );
				new AccrualGroup.AccrualGroupTable.AccrualGroupInputProgramTable( ds_read );
				new AccrualGroup.AccrualGroupTable.AccrualGroupInputCategoryTable( ds_read );
				new AccrualGroup.AccrualGroupTable.AccrualGroupInputListPickTable( ds_read,  "listpick" );
				ds_read.EnforceConstraints = false;
				ds_read.ReadXml( ofd.FileName );
				MergeConfiguration( ds_read );
			}
			ofd.Dispose();
		}

		private void buttonReloadAllGroups_Click( object sender, EventArgs e )
		{
			Local.ReloadAccrualGroups( true );
		}

		private void buttonRenameAccrual_Click( object sender, EventArgs e )
		{
			String newname = xperdex.classes.QueryNewName.Show( "Enter new accrual Name", Local.ConfigureState._current_accrual_group.Name );
			if( newname != null && newname.Length > 0 )
			{
				Local.ConfigureState.current_accrual_group[AccrualGroup.AccrualGroupTable.NameColumn] = newname;
				Local.ConfigureState._current_accrual_group.Name = newname;
				Local.Refresh();
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			String deletename = xperdex.classes.QueryNewName.Show( "Enter Accrual Group Name to Delete" );
			if( deletename != null && deletename.Length > 0 )
			{
				AccrualGroup group = Local.known_accrual_groups[deletename];
				if( group != null )
				{
					Local.known_accrual_groups.Remove( group );
					group.this_row.Delete();
					Local.CommitChanges( true );
					Local.ReloadAccrualGroups( false );
				}
				else
					MessageBox.Show( "Could not find group by that name" );
			}
		}

		private void buttonForkAccrual_Click( object sender, EventArgs e )
		{
			String newname = xperdex.classes.QueryNewName.Show( "Enter new accrual Name", Local.ConfigureState._current_accrual_group.Name );
			if( newname != null && newname.Length > 0 )
			{
				AccrualGroup group = Local.CreateAccrual( newname );
				AccrualGroup current = Local.ConfigureState._current_accrual_group;
				foreach( DataColumn col in current.this_row.Table.Columns )
				{
					if( col.ColumnName == AccrualGroup.AccrualGroupTable.PrimaryKey )
						continue;
					if( col.ColumnName == "last_accrument" )
						continue;
					if( col.ColumnName == AccrualGroup.AccrualGroupTable.NameColumn )
						continue;
					group.this_row[col.Ordinal] = current.this_row[col.Ordinal];
				}

				DataRow[] relations = current.this_row.GetChildRows( Local.accrual_group_category_table.ChildrenOfParent );
				foreach( DataRow row in relations ) { DataRow newrow = Local.accrual_group_category_table.NewRow();
					newrow[AccrualGroup.AccrualGroupTable.PrimaryKey] = group.ID;
					newrow["ctg_id"] = row["ctg_id"];
					Local.accrual_group_category_table.Rows.Add( newrow );
				}
				//AccrualGroup.AccrualPercentageTable.

				relations = current.this_row.GetChildRows( Local.accrual_group_item_table.ChildrenOfParent );
				foreach( DataRow row in relations )
				{
					DataRow newrow = Local.accrual_group_item_table.NewRow();
					newrow[AccrualGroup.AccrualGroupTable.PrimaryKey] = group.ID;
					newrow["lst_desc"] = row["lst_desc"];
					Local.accrual_group_item_table.Rows.Add( newrow );
				}

				relations = current.this_row.GetChildRows( Local.accrual_group_session_table.ChildrenOfParent );
				foreach( DataRow row in relations )
				{
					DataRow newrow = Local.accrual_group_session_table.NewRow();
					newrow[AccrualGroup.AccrualGroupTable.PrimaryKey] = group.ID;
					newrow["slt_id"] = row["slt_id"];
					Local.accrual_group_session_table.Rows.Add( newrow );
				}

				relations = current.this_row.GetChildRows( Local.accrual_group_program_table.ChildrenOfParent );
				foreach( DataRow row in relations )
				{
					DataRow newrow = Local.accrual_group_program_table.NewRow();
					newrow[AccrualGroup.AccrualGroupTable.PrimaryKey] = group.ID;
					newrow["program_id"] = row["program_id"];
					Local.accrual_group_program_table.Rows.Add( newrow );
				}

				DataTable accrual_percents = Local.BingoDataSet.Tables[AccrualGroup.AccrualPercentageTable.TableName];
				List<DataRow> loaded = DsnSQLUtil.FillDataTable( Local.dataConnection, accrual_percents
						, AccrualGroup.AccrualGroupTable.PrimaryKey + "='" + current.ID + "'", "threshold" );
				DataRow[] old_percents = accrual_percents.Select( AccrualGroup.AccrualGroupTable.PrimaryKey + "='" + group.ID + "'" );
				foreach( DataRow row in old_percents )
					row.Delete();
				//relations = current.this_row.GetChildRows( accrual_percents.ChildrenOfParent );
				foreach( DataRow row in loaded )
				{
					DataRow newrow = accrual_percents.NewRow();
					newrow[AccrualGroup.AccrualGroupTable.PrimaryKey] = group.ID;
					newrow["threshold"] = row["threshold"];
					newrow["primary"] = row["primary"];
					newrow["secondary"] = row["secondary"];
					newrow["tertiary"] = row["tertiary"];
					newrow["kitty"] = row["kitty"];
					accrual_percents.Rows.Add( newrow );
				}


				//AccrualGroup.AccrualPercentageTable.
			}
			//Local.ConfigureState.current_accrual_group[AccrualGroup.AccrualGroupTable.NameColumn] = newname;
			//Local.ConfigureState._current_accrual_group.Name = newname;

		}
	}
}
