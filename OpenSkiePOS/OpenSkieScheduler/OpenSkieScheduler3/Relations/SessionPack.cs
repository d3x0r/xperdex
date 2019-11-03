using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable(Fill="Fill")]
	public class SessionPack : MetaMySQLRelation<SessionPack.SessionPackDataRow>
	{
		new public static readonly String TableName = "session_pack";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NumberColumn = "pack_number";

		/// <summary>
		/// need a copy constructor... (GetChanges)
		/// </summary>
		public SessionPack()
		{
		}

		public SessionPack( DataSet dataset )
			: base( dataset, 
			dataset.Tables[SessionTable.TableName]
			, new MySQLRelationMap( new object[] { 
				 MySQLRelationMap.MapOp.SaveRelationPoint
				, SessionPackGroup.TableName
				, MySQLRelationMap.MapOp.FollowToParent
				, PackGroupTable.TableName
				, MySQLRelationMap.MapOp.FollowToChild
				, PackGroupPackRelation.TableName
				, MySQLRelationMap.MapOp.FollowToParent
				, PackTable.TableName
				, MySQLRelationMap.MapOp.SaveRelationPoint
//				, MySQLRelationMap.MapOp.FollowToChild
					}
				).ToString()
			, true
			, null
				)
		{
		}

		public class SessionPackDataRow : DataRow 
		{
			public SessionPackDataRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }

			public override string ToString()
			{
				return this.GetParentRow( "session_pack_meta_pack_info" )[PackTable.NameColumn].ToString();
			}
		}
		public void Fill( DsnConnection dsn )
		{
			DsnSQLUtil.FillDataTable( dsn, this, null, null );
			BuildDataRows( false );
		}
	}
}
