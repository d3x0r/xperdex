using System;
using System.Data;
using System.Windows.Forms;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable( DefaultFill="DefaultFill" )]
	public class PackTable : MySQLNameTable<PackTable.PackRow>
	{
		new static public readonly String TableName = "pack_info";
		static public readonly String NameColumn = XDataTable.Name( TableName );
		new static public readonly String PrimaryKey = XDataTable.ID( TableName );

		public class PackRow : DataRow
		{
			public PackRow( global::System.Data.DataRowBuilder rb ) :
				base( rb )
			{
			}

			public override string ToString()
			{
				return this[PackTable.NameColumn].ToString();
			}

		}

		public PackTable()
		{
			// uhmm... parameterless needed for GetChanges();
		}

		public PackTable( DataSet dataSet )
			: base( Names.schedule_prefix, TableName )
        {
            DataColumn dc;
            dc = Columns.Add( "max_sell", typeof( int ) );
			dc = Columns.Add( ColorInfoTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
            dc = Columns.Add( "onsize", typeof( int ) );
            dc = Columns.Add( "jumping_jackpot", typeof( bool ) );
            // this is actually prize_level_id
            //dc = Columns.Add( PrizeLevelNames.PrimaryKey, XDataTable.DefaultAutoKeyType );
			dc = Columns.Add( "width", typeof( int ) );
			dc = Columns.Add( "height", typeof( int ) );
			dc = Columns.Add( "face_width", typeof( int ) );
			dc.AllowDBNull = false; dc.DefaultValue = 5;
			dc = Columns.Add( "face_height", typeof( int ) );
			dc.AllowDBNull = false; dc.DefaultValue = 5;
			dc = Columns.Add( "pages", typeof( int ) );
			dc = Columns.Add( "multiplier", typeof( int ) );
			dc.DefaultValue = 1;
			dc.AllowDBNull = false;

            dc = Columns.Add( "_3_number", typeof( bool ) );
            dc.AllowDBNull = false; dc.DefaultValue = false;
			dc = Columns.Add( "double_action", typeof( bool ) );
			dc.AllowDBNull = false; dc.DefaultValue = false;
			dc = Columns.Add( "upickem", typeof( bool ) );
			dc.AllowDBNull = false; dc.DefaultValue = false;
			dc = Columns.Add( "face_size", typeof(int ) );
			dc.AllowDBNull = false; dc.DefaultValue = 25;
			dc = Columns.Add( "even_count_bonus", typeof( bool ) );
            dc.AllowDBNull = false; dc.DefaultValue = false;
            dc = Columns.Add( "odd_count_bonus", typeof( bool ) );
            dc.AllowDBNull = false; dc.DefaultValue = false;

            dataSet.Tables.Add( this );

            // relate color_info as pack_is_color
            {
                DataTable child;
                String relation_name;
                dataSet.Relations.Add( relation_name = MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( PackTable.TableName ) )
                    + "_is_"
                    + MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( ColorInfoTable.TableName ) )
                    , dataSet.Tables[ColorInfoTable.TableName].Columns[ColorInfoTable.PrimaryKey]
                    , ( child = dataSet.Tables[PackTable.TableName] ).Columns[ColorInfoTable.PrimaryKey]
                    );
                ForeignKeyConstraint fkc = child.Constraints[relation_name] as ForeignKeyConstraint;
                if( fkc != null )
                    fkc.DeleteRule = Rule.SetNull;
			}
        }

		public DataRow NewPack( String name, int rows, int cols )
		{
			{
				DataRow new_row = NewRow();
				DataRow[] old_rows = Select( NameColumn + "='" + DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, name ) + "'" );
				if( old_rows.Length > 0 )
				{
					MessageBox.Show( "Pack '" + name + "' already exists.\nPack names are required to be unique." );
					return null;
				}
				new_row[NameColumn] = name;
				new_row["width"] = cols;
				new_row["height"] = rows;
				new_row["onsize"] = cols * rows;
				new_row["face_width"] = 5;
				new_row["face_height"] = 5;
                new_row["pages"] = 1;
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

		public DataRow NewPack( String name )
		{
			return NewPack( name, 0, 0 );
		}

		public void DefaultFill()
		{
			if( Rows.Count == 0 )
			{
				DataRow nopack_row = NewRow();
				if( Columns[PrimaryKey].DataType == typeof( Guid ) )
					nopack_row[PrimaryKey] = Guid.Empty;
				nopack_row[NameColumn] = "No Pack";
				Rows.Add( nopack_row );
			}
			RowDeleting += new DataRowChangeEventHandler( PackTable_RowDeleting );
		}

		void PackTable_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			if( e.Row[PrimaryKey].Equals( Guid.Empty ) )
				throw new Exception( "Cannot delete No Pack." );
		}


		public DataRow GetPrizeLevel( DataRow pack_prize, string prize_name )
		{
			DataRow[] prizes = pack_prize.GetChildRows( "pack_has_prize_level" );
			foreach( DataRow prize in prizes )
				if( String.Compare( prize.GetParentRow( "prize_level_in_pack" )[PrizeLevelNames.NameColumn].ToString(), prize_name, true ) == 0 )
				{
					return prize;
				}
			return null;
		}

		public DataRow AddClonedRow( DataRow pack_info, DataRow updated_color )
		{
			DataRow row = NewRow();
			foreach( DataColumn dc in Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( updated_color != null && dc.ColumnName == ColorInfoTable.PrimaryKey )
						row[dc.ColumnName] = updated_color[ColorInfoTable.PrimaryKey];
					else
						row[dc.ColumnName] = pack_info[dc.ColumnName];
				}
				catch
				{
					// the column night not exist in the source table...
				}
			}
			this.Rows.Add( row );
			return row;
		}



		public DataRow GetPack( String pack_name )
		{
			DataRow[] result = Select( NameColumn + "='" + pack_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}
	}
}

