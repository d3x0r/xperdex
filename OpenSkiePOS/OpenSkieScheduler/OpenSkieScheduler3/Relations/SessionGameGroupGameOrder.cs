using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;
using System.Windows.Forms;

#if asdfasdf
namespace OpenSkieScheduler.Relations
{
	[SchedulePersistantTable( FillCondition = "OrderedFill" )]
	public class SessionGameGroupGameOrder: MetaMySQLRelation
	{
		new public static readonly String TableName = "session_game_group_game";
		new public static readonly String PrimaryKey = ID( TableName );
		new public static readonly String NumberColumn = "game_number";

		static string color_name;
		public static String[,]		Relations = {
													{"session_game_group_game_meta_session_info",		 SessionTable.PrimaryKey},
													{"session_game_group_game_meta_game_info",			 GameTable.PrimaryKey},
													{"session_game_group_game_meta_game_group_info",	 PackGroupTable.PrimaryKey},
													{"session_game_group_game_meta_session_game_group",	 SessionGameGroupRelation.PrimaryKey},
													{"session_game_group_game_meta_game_group_game",	 GameGroupGameRelation.PrimaryKey},
													{"session_game_group_game_is_color",				 ColorInfoTable.PrimaryKey }
												};
		public static String[] DataColumns = { 
			"game_number", 
			"ball_timer", 
			"overlap_prior", 
			"progressive", 
			"bonanza", 
			"wild", 
			"double_wild", 
			"blind", 
			"single_hotball"
												 };

		public void OrderedFill()
		{
			base.Fill( null, NumberColumn + ",overlap_prior" );
		}

		void Reload()
		{
			Rows.Clear();
			base.Fill( null, NumberColumn + ",overlap_prior" );
		}

		public SessionGameGroupGameOrder( DsnConnection odbc, DataSet dataset )
			: base( odbc, dataset
			, dataset.Tables[SessionTable.TableName] as XDataTable
			, new MySQLRelationMap( new object[] {
				dataset.Tables[SessionTable.TableName] as XDataTable
				, MySQLRelationMap.MapOp.SaveRelationPoint
				, MySQLRelationMap.MapOp.FollowTo
				, PackGroupTable.TableName
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowTo
				, GameTable.TableName
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
			} ).ToString()
			//, ".session_has_game_group.\\game_group_in_session$/game_group_has_game.\\game_in_game_group$"
			, false
			, false
			, new DataColumn[] { new DataColumn( "game_number", typeof( int ) )
				, new DataColumn( "ball_timer", typeof( int ) )
				, new DataColumn( "overlap_prior", typeof( bool ) )
				, new DataColumn( "progressive", typeof( bool ) )
				, new DataColumn( "bonanza", typeof( bool ) )
				, new DataColumn( "wild", typeof( bool ) )
				, new DataColumn( "double_wild", typeof( bool ) )
				, new DataColumn( "blind", typeof( bool ) )
				, new DataColumn( "single_hotball", typeof( bool ) )
				, new DataColumn( ColorInfoTable.PrimaryKey, XDataTable.DefaultAutoKeyType )
				}
			)
		{
			foreach( string name in DataColumns )
			{
				this.Columns[name].AllowDBNull = false;
				this.Columns[name].DefaultValue = 0;
			}
            if( dataset != null )
            {
                DataTable child;
                dataset.Relations.Add( SessionGameGroupGameOrder.color_name = MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( SessionGameGroupGameOrder.TableName ) )
                    + "_is_"
                    + MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( ColorInfoTable.TableName ) )
                    , dataset.Tables[ColorInfoTable.TableName].Columns[ColorInfoTable.PrimaryKey]
                    , ( child = dataset.Tables[SessionGameGroupGameOrder.TableName] ).Columns[ColorInfoTable.PrimaryKey]
                    );
                ForeignKeyConstraint fkc = child.Constraints[color_name] as ForeignKeyConstraint;
                if( fkc != null )
                    fkc.DeleteRule = Rule.SetNull;
            }

            number_column = NumberColumn;
			AddingRow += new OnNewRow( initrow );
			FixupRow += new OnFixupRow( SessionGameGroupGameOrder_FixupRow );

			//Create();
			//base.Fill(null, NumberColumn+",overlap_prior");

			ColumnChanged += new DataColumnChangeEventHandler( SessionGameGroupGameOrder_ColumnChanged );
		}

		public bool updating_number = false;
		void SessionGameGroupGameOrder_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( e.Column.ColumnName == "game_number" && e.Row.HasVersion( DataRowVersion.Original ) )
			{
				if( updating_number )
					return;
				DataRow[] these_rows = this.Select( "session_id=" + e.Row["session_id"], "game_number,overlap_prior" );
	

				int row_index;
				for( row_index = 0; row_index < these_rows.Length; row_index++ )
					if( Convert.ToInt32( these_rows[row_index][PrimaryKey] ) == Convert.ToInt32( e.Row[PrimaryKey] ) )
						break;
				int newval = Convert.ToInt32( e.ProposedValue );
				int oldval = Convert.ToInt32( e.Row["game_number", DataRowVersion.Original] );
				int del = newval - oldval;
				if( ( row_index + 1 ) < these_rows.Length )
				if( Convert.ToInt32( these_rows[row_index + 1]["game_number"] ) == newval )
				{
					DialogResult result = MessageBox.Show( "Do you want to update all subsequent games?", "Auto Update", MessageBoxButtons.OKCancel );
					if( result == DialogResult.OK )
					{
						updating_number = true;
						//SuspendChanges();
						//this.BeginLoadData();
						for( int n = 1; n < these_rows.Length - row_index; n++ )
						{
							these_rows[row_index + n]["game_number"] = Convert.ToInt32( these_rows[row_index + n]["game_number"] ) + 1;
						}
						//this.EndLoadData();
						updating_number = false;
					}
				}

				if( ( row_index + 1 ) < these_rows.Length )
				if( Convert.ToInt32( these_rows[row_index + 1]["game_number"] ) == ( oldval + 1 ) )
				{
					DialogResult result = MessageBox.Show( "Do you want to update all subsequent games down "+(-del)+"?", "Auto Update", MessageBoxButtons.OKCancel );
					if( result == DialogResult.OK )
					{
						updating_number = true;
						//SuspendChanges();
						//this.BeginLoadData();
						for( int n = 1; n < these_rows.Length - row_index; n++ )
						{
							these_rows[row_index + n]["game_number"] = Convert.ToInt32( these_rows[row_index + n]["game_number"] ) + del;
						}
						//this.EndLoadData();
						updating_number = false;
					}
				}
				updating_number = false;
			}
			if( e.Column.ColumnName == "overlap_prior" && e.Row.HasVersion(DataRowVersion.Original)) 
			{
				updating_number = true;
				if( e.ProposedValue == DBNull.Value )
				{
					e.ProposedValue = false;
				}
				bool now = Convert.ToBoolean( e.ProposedValue );
				bool before = Convert.ToBoolean ( e.Row["overlap_prior", DataRowVersion.Original] );
				if( e.ProposedValue != DBNull.Value && now && now != before )
				{
					{
						DataRow[] rows = Select( "session_id=" + e.Row["session_id"] );
						//DataRowCollection rows = Rows;
						int index;
						for( index = 0; index < rows.Length; index++ )
							if( e.Row == rows[index] )
								break;
						if( index == rows.Length )
						{
							Log.log( "Fault!" );
						}
						if( index > 0 )
						{
							int remaining_rows;
							DataRow prior = rows[index - 1];
							e.Row[SessionGameGroupGameOrder.NumberColumn]
								= prior[SessionGameGroupGameOrder.NumberColumn];
							for( remaining_rows = index + 1; remaining_rows < rows.Length; remaining_rows++ )
							{
								rows[remaining_rows][SessionGameGroupGameOrder.NumberColumn] = Convert.ToInt32( rows[remaining_rows][SessionGameGroupGameOrder.NumberColumn] ) - 1;

								/*
								DataRow[] tmp = rows[remaining_rows].GetChildRows( "session_game_group_game" );
								if( tmp.Length > 0 )
								{
									tmp[0][Relations.CurrentSessionGameGroupGameOrder.NameColumn] = ( tmp[0].Table as Relations.CurrentSessionGameGroupGameOrder ).GetDisplayMember( rows[remaining_rows] );
								}
								 */
							}
						}
						else
						{
							//MessageBox.Show( "Cannot set the very first game as overlap\n(NO PRIOR)" );
							e.ProposedValue = false;
							//e.Row["overlap_prior"] = false;
						}
					}
				}

				if( e.ProposedValue != DBNull.Value && !now && now != before )
				{
					{
						DataRow[] rows = Select( "session_id=" + e.Row["session_id"] );
						//DataRowCollection rows = Rows;
						int index;
						for( index = 0; index < rows.Length; index++ )
							if( e.Row == rows[index] )
								break;

						if( index == rows.Length )
						{
							Log.log( "Fault!" );
						}
						if( index > 0 )
						{

							int remaining_rows;
							DataRow prior = rows[index - 1];
							// sanity check, for forward migration....	
							if( Convert.ToInt32( e.Row[SessionGameGroupGameOrder.NumberColumn] )
									== Convert.ToInt32( prior[SessionGameGroupGameOrder.NumberColumn] ) )
								for( remaining_rows = index; remaining_rows < rows.Length; remaining_rows++ )
								{
									rows[remaining_rows][SessionGameGroupGameOrder.NumberColumn]
										= Convert.ToInt32( rows[remaining_rows][SessionGameGroupGameOrder.NumberColumn] ) + 1;
									/*
									DataRow[] tmp = rows[remaining_rows].GetChildRows( "session_game_group_game" );
									tmp[0][Relations.CurrentSessionGameGroupGameOrder.NameColumn] = ( tmp[0].Table as Relations.CurrentSessionGameGroupGameOrder ).GetDisplayMember( rows[remaining_rows] );
									*/
								}
						}
						else
						{
							e.ProposedValue = false;
							//MessageBox.Show( "Cannot set the very first game as overlap\n(NO PRIOR)" );
							//e.Row["overlap_prior"] = false;
						}
					}
				}
			}
		}



		void SessionGameGroupGameOrder_FixupRow( DataRow row )
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
				updating_number = true;
				if( Convert.ToInt32( row[NumberColumn] ) != new_number )
					row[NumberColumn] = new_number;
				updating_number = false;
			}
			catch
			{
				row[NumberColumn] = 1;
			}

			//throw new NotImplementedException();
		}

		void initrow( DataRow row )
		{
			try
			{
				SessionGameGroupGameOrder_FixupRow( row );
			}
			catch
			{
				row[NumberColumn] = 1;
			}
			row["overlap_prior"] = false;
			row["progressive"] = false;
			row["bonanza"] = false;
			row["wild"] = false;
			row["single_hotball"] = false;
		}

		/// <summary>
		/// need a copy constructor... (GetChanges)
		/// </summary>
		public SessionGameGroupGameOrder()
		{
		}

		public DataRow[] GetGroupsFromSession( DataRow dr_session )
		{
			return dr_session.GetChildRows( children_of_parent ); 
		}

		public DataRow GetGame( DataRow group_game )
		{
			return group_game.GetParentRow( "session_game_group_game_meta_game_info" ); 
		}

		public DataRow GetGameGroup( DataRow group_game )
		{
			return group_game.GetParentRow( "session_game_group_game_meta_game_group_info" );
		}

		public DataRow[] GetPacks( DataRow group_game )
		{
			DataRow tmp = GetGameGroup( group_game);
			if( tmp != null )
			{
				List<DataRow> result = new List<DataRow>();
				DataRow[] pize_rows = tmp.GetChildRows( "game_group_has_prize_level" );
				foreach( DataRow prize_row in pize_rows )
				{
					DataRow[] rows = prize_row.GetChildRows( "game_group_prize_level_has_pack" );
					foreach( DataRow row in rows )
						result.Add( row.GetParentRow( "pack_in_game_group_prize_level" ) );
				}
				return result.ToArray();
			}
			return null;
		}


		
	}


}
#endif
