using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using OpenSkieScheduler3.Controls;
using xperdex.classes;

namespace OpenSkie.Scheduler.Controls.Common.Textboxes
{
	public abstract class MyTextBox : TextBox
	{
		bool allow_edit;
		public void EnableEdit( bool enable )
		{
			allow_edit = enable;
		}

		// otherwise we ended up finding it by reflection name browsing.
		DataRow datarow; // last referenced datarow.
		PropertyInfo fieldCurrentRow;
		FieldInfo fieldTable;
		internal String fieldname;
		protected bool NumberField;
		protected String NumberColumnName;
		String column;
		bool field_in_schedule;
		bool field_table_in_schedule;
		protected bool ConfirmChanges = true;

		public MyTextBox( String table_member_name, String Column )
		{
			String current_member_name = "current_" + MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( table_member_name ) );

			fieldname = table_member_name;
			Type t = typeof( OpenSkieScheduler3.ScheduleDataSet );
			Type d = typeof( ScheduleCurrents );

			fieldCurrentRow = t.GetProperty( current_member_name, BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public );
			if( fieldCurrentRow == null )
			{
				field_in_schedule = false;
				fieldCurrentRow = d.GetProperty( current_member_name, BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public );
			}
			else
				field_in_schedule = true;
			fieldTable = t.GetField( table_member_name, BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public );
			if( fieldTable == null )
			{
				field_table_in_schedule = false;
				fieldTable = d.GetField( table_member_name, BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public );
			}
			else
				field_table_in_schedule = true;

			column = Column;

			UpdateBindings();
			if( fieldTable != null )
			{
				DataTable Table = ( field_table_in_schedule ? fieldTable.GetValue( ControlList.schedule ) : fieldTable.GetValue( ControlList.data ) ) as DataTable;
				if( Table != null )
					Table.ColumnChanging += new DataColumnChangeEventHandler( Table_ColumnChanged );
			}
			this.TextChanged += new EventHandler( MyTextBox_TextChanged );
			this.LostFocus += new EventHandler( MyTextBox_LostFocus );

			ControlList.controls.Add( this );
			ControlList.names.Add( this );
		}

		bool changed;
		void MyTextBox_LostFocus( object sender, EventArgs e )
		{
			if( !changed )
				return;
			if( datarow == null 
				|| datarow.RowState == DataRowState.Detached 
				|| datarow.RowState == DataRowState.Deleted )
				return;
			if( filling )
				return;
			{
				filling = true;
				try
				{
					if( String.Compare( datarow[column].ToString(), Text ) != 0 )
					{
						DataRow[] prior;
						if( NumberField )
						{
							int value;
							if( Int32.TryParse( Text, out value ) )
							{
								if( NumberColumnName == null )
									datarow[XDataTable.Number( datarow.Table )] = value;
								else
									datarow[NumberColumnName] = value;
							}
						}
						else
						{
							prior = datarow.Table.Select( XDataTable.Name( datarow.Table ) + "='" + Text + "'" );
							if( prior.Length > 0 )
							{
								if( MessageBox.Show( "New value already exists.  Do you wish to combine these?", "Confirm Merge", MessageBoxButtons.YesNo ) == DialogResult.Yes )
								{
									String id_name = XDataTable.ID( datarow.Table );
									// might have to check the relation to make sure it's a relation on the primary key.
									foreach( DataRelation relation in datarow.Table.ChildRelations )
									{
										foreach( DataColumn dc in relation.ParentColumns )
											if( !NumberField && dc.ColumnName == id_name )
											{
												DataRow[] rows = datarow.GetChildRows( relation );
												foreach( DataRow row in rows )
													row[id_name] = prior[0][id_name];
											}
									}
	
									foreach( DataRelation relation in datarow.Table.ParentRelations )
									{
										foreach( DataColumn dc in relation.ChildColumns )
											if( dc.ColumnName == id_name )
											{
												DataRow[] rows = datarow.GetParentRows( relation );
												foreach( DataRow row in rows )
													row[id_name] = prior[0][id_name];
											}
									}
									datarow.Delete();
								}
							}
							else if( !ConfirmChanges || MessageBox.Show( "Are you sure you want to change " + datarow.Table.TableName + "." + column + " = " + datarow[column] + " to " + Text, "Confirm Change", MessageBoxButtons.YesNo ) == DialogResult.Yes )
								datarow[column] = Text;
							else
								Text = datarow[column].ToString();
						}
					}
					//(datarow.Table as MySQLDataTable).CommitChanges();
				}
				catch
				{
				}
				filling = false;
			}
		}
		~MyTextBox()
		{
			ControlList.controls.Remove( this );
			ControlList.names.Remove( this );
		}

		#region Data Binding.
		void MyTextBox_TextChanged( object sender, EventArgs e )
		{
			if( filling )
				return;
			changed = true;
		}

		void Table_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( filling )
				return;
			if( allow_edit )
				Text = e.Row[column].ToString();
		}
		#endregion

		bool filling;
		public void UpdateBindings()
		{
			if( fieldCurrentRow != null )
			{
				if( field_in_schedule )
					datarow = fieldCurrentRow.GetValue( ControlList.schedule, null ) as DataRow;
				else
					datarow = fieldCurrentRow.GetValue( ControlList.data, null ) as DataRow;
			}
			if( datarow != null )
			{
				filling = true;
				if( datarow.RowState == DataRowState.Deleted ||
					datarow.RowState == DataRowState.Detached )
					Text = "Deleted Row";
				else
					Text = datarow[column].ToString();
				filling = false;
			}
		}

	}

}
