using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable]
	/// <summary>
	/// Represents the relation between packs and the ranges that apply to the pack.
	/// </summary>
	public class PackFacePrizeLevel : MySQLRelationTable2<DataRow,PackTable,PrizeLevelNames>
	{
		new public static readonly string TableName = "pack_face_prize_level";
		new public static readonly string PrimaryKey = XDataTable.ID(TableName);

		new public static readonly string NumberColumn = "face";

		public PackFacePrizeLevel()
		{
			base.TableName = "(tmp)" + TableName;
		}

		public PackFacePrizeLevel(DataSet dataset)
			: base( dataset )
			//base( null, dataset, Names.schedule_prefix
			//, PackFacePrizeLevel.TableName
			//, dataset.Tables[PackTable.TableName]
			//, dataset.Tables[PrizeLevelNames.TableName], false )
		{
			Columns.Add( ColorInfoTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
			//Columns.Add("face", typeof(int));


            String relation_name;
            dataset.Relations.Add( relation_name = MySQLDataTable.StripPlural( TableName )
                    + "_is_"
                    + MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( ColorInfoTable.TableName ) )
                    , dataset.Tables[ColorInfoTable.TableName].Columns[ColorInfoTable.PrimaryKey]
                    , this.Columns[ColorInfoTable.PrimaryKey]
                    );
            ForeignKeyConstraint fkc = this.Constraints[relation_name] as ForeignKeyConstraint;
            if( fkc != null )
                fkc.DeleteRule = Rule.SetNull;

		}
	}

	[SchedulePersistantTable]
	/// <summary>
	/// Represents the relation between packs and the ranges that apply to the pack.
	/// </summary>
	public class PackPrizeLevel : MySQLRelationTable2<DataRow, PackTable, PrizeLevelNames >
	{
		new public static readonly string TableName = "pack_prize_level";
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );

		public PackPrizeLevel()
		{
			base.TableName = "(tmp)" + TableName;
		}

		public PackPrizeLevel( DataSet dataset ) : base( dataset )
		{
		}

	}
}
