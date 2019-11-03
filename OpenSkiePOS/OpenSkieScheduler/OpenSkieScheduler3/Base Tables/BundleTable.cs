using System;
using System.Data;
using System.Windows.Forms;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable]
	public class BundleTable: MySQLNameTable<BundleTable.BundleTableRow>
	{
		new public static readonly String TableName = "bundle_info";
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );

		public class BundleTableRow : DataRow
		{
			public BundleTableRow( global::System.Data.DataRowBuilder rb ) :
				base( rb )
			{
			}

			public override string ToString()
			{
				return this[BundleTable.NameColumn].ToString();
			}

		}

		void AddColumns()
		{
			//DataColumn dc;
			//dc = Columns.Add( NameColumn, typeof( string ) );
		}

		public BundleTable()
		{
			base.TableName = "(tmp)" + TableName;
			AddDefaultColumns( true, true, true );
			AddColumns();
		}
		public BundleTable( DataSet dataSet )
			: base( Names.schedule_prefix, TableName )
		{
			// this is really a name-table... but we inherit from hallcharity...
			AddColumns();
			dataSet.Tables.Add( this );
		}


		public DataRow NewBundle( String name )
		{
			{
				DataRow new_row = NewRow();
				DataRow[] old_rows = Select( NameColumn + "='" + name + "'" );
				if( old_rows.Length > 0 )
				{
					MessageBox.Show( "Bundle '" + name + "' already exists.\nBundle names are required to be unique." );
					return null;
				}
				new_row[NameColumn] = name;
				try
				{
					Rows.Add( new_row );
					return new_row;
				}
				catch
				{
					// probably a constraint error -name already exists.
				}
				return null;
			}
		}

		public DataRow GetBundle( String name )
		{
			DataRow[] old_rows = Select( NameColumn + "='" + name + "'" );
			if( old_rows.Length > 0 )
			{
				return old_rows[0];
			}
			return null;
		}

	}
}
