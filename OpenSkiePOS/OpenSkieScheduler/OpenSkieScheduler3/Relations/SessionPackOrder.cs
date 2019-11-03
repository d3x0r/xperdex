using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
    [SchedulePersistantTable]
	public class SessionPackOrder : MetaMySQLRelation<DataRow>
    {
        //basically no reference to a odbc, so it's memory only tracking.
        new public static readonly string TableName = "session_pack";
        //public static readonly string PrimaryKey = "session_game_id";
        public static readonly string NameColumn = "Name";
        new public static readonly String NumberColumn = "pack_number";

		static MySQLRelationMap session_game_packs_map = new MySQLRelationMap( new object[] {
				MySQLRelationMap.MapOp.SaveRelationPoint
				, MySQLRelationMap.MapOp.FollowToChild
				, "session_has_game"
				//, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToChild
				, "session_game_has_pack_group"
				//, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToParent
				, "pack_group_in_session_game"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToChild
				, "pack_group_has_pack"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToParent
				, "pack_in_pack_group"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
			} );



        public SessionPackOrder( DsnConnection odbc, DataSet dataSet )
            : base( odbc
                    , dataSet
                    , dataSet.Tables[SessionTable.TableName]
            , session_game_packs_map.ToString()
				//, "./session_has_game_group$\\game_group_in_session$/game_group_has_pack$\\pack_in_game_group$"
                    , false // add number column (table name is bad, so we define our own)
                    , false // auto fill
                    , new DataColumn[] { new DataColumn( NameColumn, typeof( string ) )
										, new DataColumn( SessionPackOrder.NumberColumn, typeof( int ) ) }
            )
        {
			this.unique = true;
            Init();
        }

        public SessionPackOrder()
        {
            base.TableName = "(tmp)" + TableName;
        }


        void OrderedFill()
        {
            Fill( SessionPackOrder.NumberColumn );
        }

        void Init()
        {
            number_column = NumberColumn;
            base.TableName = TableName;
            AddingRow += new MySQLRelationTable.OnNewRow( initrow );
            Fill( SessionPackOrder.NumberColumn );
        }

        void SessionPackMetaRelation_RowChanging( object sender, DataRowChangeEventArgs e )
        {
            if( e.Action == DataRowAction.Add )
            {
                if( e.Row.RowState == ( DataRowState.Added ) || e.Row.RowState == DataRowState.Detached )
                {
                    DataRow Source1 = e.Row.GetParentRow( TableName + "_meta_" + root_table.TableName );
                    DataRow Source2 = e.Row.GetParentRow( TableName + "_meta_" + terminal_table.TableName );
                    e.Row["Name"] = ( ( Source1 == null ) ? "<NULL>" : Source1[XDataTable.Name(root_table)] ) + " : " + ( ( Source2 == null ) ? "<NULL>" : Source2[terminal_table.NameColumn] );
                }
            }
        }

        void SessionGameGroupPackOrder_FixupRow( DataRow row )
        {
            try
            {

                object max_number = Compute( "Max(" + NumberColumn + ")"
                    , "session_id=" + connection.sql_value_quote_open + row["session_id"] + connection.sql_value_quote_close
                    + " and "
                    + NumberColumn + "<" + row[NumberColumn]
                    );
                int new_number;
                if( max_number.GetType() == typeof( DBNull ) )
                {
                    new_number = 1;
                }
                else
                {
                    new_number = Convert.ToInt32( max_number ) + 1;
                }
                if( Convert.ToInt32( row[NumberColumn] ) != new_number )
                    row[NumberColumn] = new_number;
            }
            catch
            {
                row[NumberColumn] = 1;
            }

        }

        void initrow( DataRow row )
        {
            try
            {
                SessionGameGroupPackOrder_FixupRow( row );
            }
            catch
            {
                row[NumberColumn] = 1;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // SessionPackOrder
            // 
            this.RowChanging += new System.Data.DataRowChangeEventHandler(this.SessionPackOrder_RowChanging);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private void SessionPackOrder_RowChanging(object sender, DataRowChangeEventArgs e)
        {

        }

    }

}
