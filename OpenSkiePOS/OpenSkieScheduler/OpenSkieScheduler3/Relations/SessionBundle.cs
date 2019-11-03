using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Relations
{

	[SchedulePersistantTable]
	public class SessionBundleRelation: MySQLRelationTable2<SessionBundleRelation.SessionBundleDataRow,SessionTable,BundleTable>
	{
		new public static readonly String TableName = MySQLRelationTable2<DataRow,SessionTable, BundleTable>.RelationName;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NumberColumn = XDataTable.Number( BundleTable.TableName );


		public class SessionBundleDataRow : DataRow
		{
			public SessionBundleDataRow( global::System.Data.DataRowBuilder rb ) :
				base( rb )
			{
			}

			public override string ToString()
			{
				return this.GetParentRow( "bundle_in_session" )[BundleTable.NameColumn].ToString();// +" in " + this.GetParentRow( "session_has_bundle" )[SessionTable.NameColumn].ToString();
			}
		}
		public SessionBundleRelation()
		{
			// hooray for GetChanges(); suck.
		}

		public SessionBundleRelation( DataSet dataset ): base( dataset )
		{

		}

	}

	[SchedulePersistantTable]
	public class SessionBundlePackRelation : MySQLRelationTable2<SessionBundlePackRelation.SessionBundlePackDataRow, SessionBundleRelation, PackTable>
	{
		new public static readonly String TableName = MySQLRelationTable2<DataRow,SessionBundleRelation, PackTable>.RelationName;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NumberColumn = XDataTable.Number( PackTable.TableName );
		public static String CountColumn = "quantity";

		public class SessionBundlePackDataRow : DataRow
		{
			public SessionBundlePackDataRow( global::System.Data.DataRowBuilder rb ) :
				base( rb )
			{
			}

			public override string ToString()
			{
				if( this["quantity"] == DBNull.Value )
					this["quantity"] = 1;
				DataRow row_bundles = this.GetParentRow( "pack_in_session_bundle" );
				if( row_bundles == null )
					return "???" + " - " + this["quantity"].ToString();
				return row_bundles[PackTable.NameColumn].ToString() + " - " + this["quantity"].ToString();// + " in " + this.GetParentRow( "session_bundle_has_pack" ).ToString() ;
			}
		}


		void AddColumns()
		{
			DataColumn dc = Columns.Add( CountColumn, typeof( int ) );
			dc.DefaultValue = 1;
			RowChanged += new DataRowChangeEventHandler( SessionBundlePackRelation_RowChanged );
		}

		/// <summary>
		/// catch row changed event, when a new row is added, make sure that the row added doesn't already exist...
		/// if it does exist, offer to add one, and in any case throw away the duplicate row.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SessionBundlePackRelation_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( !filling )
			{
				if( e.Action == DataRowAction.Add )
				{
					DataRow[] existing_row = Select( PackTable.PrimaryKey + "='" + e.Row[PackTable.PrimaryKey] + "' and " + SessionBundleRelation.PrimaryKey + "='" + e.Row[SessionBundleRelation.PrimaryKey] + "'" );
					if( existing_row.Length > 1 )
					{
						if( MessageBox.Show( "Pack already exists in bundle\nadd one to the prior pack?", "Pack Exists", MessageBoxButtons.YesNo ) == DialogResult.Yes )
						{
							foreach( DataRow row in existing_row )
							{
								if( row[PrimaryKey].Equals( e.Row[PrimaryKey] ) )
									continue;
								row[CountColumn] = Convert.ToInt32( row[CountColumn] ) + 1;
							}
						}
						e.Row.Delete();
					}
				}
			}
		}

		public SessionBundlePackRelation()
		{
			// hooray for GetChanges(); suck.
		}

		public SessionBundlePackRelation( DataSet dataset )
			: base( dataset )
		{
			AddColumns();
			CloneRow += new MySQLRelationTable.OnCloneRow( SessionBundlePackRelation_CloneRow );
		}

		void SessionBundlePackRelation_CloneRow( DataRow row, DataRow original )
		{
			row["quantity"] = original["quantity"];
		}
	}
}
