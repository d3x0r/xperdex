using System;
using System.Data;
using System.Windows.Forms;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable ]
	public class CardsetInfo  : MySQLDataTable
	{
		new public static readonly String TableName = "cardset_info";
		public static readonly String NameColumn = "friendly_name";
		new public static readonly string DisplayMemberName = NameColumn;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		public static String[] DataColumns = {
			"name", 
			"friendly_name", 
			"cards", 
			"manufacturer_id", 
            "machine_id", 
            "machine_type_is_ccf"
												 };
		public CardsetInfo()
		{
			base.TableName = "(tmp)" + TableName;
		}


		public CardsetInfo( DataSet dataSet )
			: base( Names.schedule_prefix, TableName, true, false )
		{
			Columns.Add( "name", typeof( string ) );
			Columns.Add( "friendly_name", typeof( string ) );
			Columns.Add( "cards", typeof( int ) );
			Columns.Add( "manufacturer_id", typeof( string ) );
            Columns.Add( "machine_id", typeof(int) );
            Columns.Add( "machine_type_is_ccf", typeof(bool) );
			//Create();
			//Fill();
			dataSet.Tables.Add( this );
		}

		protected override void OnRowDeleting( System.Data.DataRowChangeEventArgs e )
		{
			object o = this.connection.ExecuteScalar( "select count(*) from " + Names.schedule_prefix + "cardset_cards where cardset_id=" + e.Row["cardset_id"] );
			// no cardset_cards table?
			if( o == null )
				return;
			if( Convert.ToInt32( o ) > 0 )
			{
				if( MessageBox.Show( "Are you sure you want to delete\n" + o + " rows from cardset data?"
					, "Confirm Data Deletion"
					, MessageBoxButtons.YesNo ) == DialogResult.Yes )
					this.connection.ExecuteNonQuery( "delete from " + Names.schedule_prefix + "cardset_cards where cardset_id=" + e.Row["cardset_id"] );
				else
					throw new Exception( "Delete was aborted!?" );
			}
			base.OnRowDeleting( e );
		}

		public DataRow NewCardset( String name )
		{
			DataRow[] old_rows = Select( NameColumn + "='" + name + "'" );
			if( old_rows.Length > 0 )
			{
				MessageBox.Show( "Cardset '" + name + "' already exists.\nCardset names are required to be unique." );
				return null;
			}

			DataRow new_row = NewRow();
			new_row[NameColumn] = name;
			Rows.Add( new_row );
			CommitChanges();
			return new_row;
		}


	}
}
