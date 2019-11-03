using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;
using OpenSkieScheduler3.Relations;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable]
	public class GamePatternRelation : MySQLRelationTable2<GamePatternRelation.GamePatternDataRow, SessionGame, PatternDescriptionTable>
    {
		new public static readonly String TableName 
			= MySQLRelationTable2<GamePatternRelation.GamePatternDataRow, SessionGame, PatternDescriptionTable>.RelationName;


		public class GamePatternDataRow : DataRow
		{
			public GamePatternDataRow( global::System.Data.DataRowBuilder rb ) :
				base( rb )
			{
			}

			public override string ToString()
			{
				DataRow row_patterns = GetParentRow( "pattern_in_session_game" );
				if( row_patterns != null )
					return row_patterns[PatternDescriptionTable.NameColumn].ToString();
				return "NO PATTERN";
			}
		}

		public GamePatternRelation()
		{
			// hooray, AGAIN for GetChanges();
		}

		public GamePatternRelation( DataSet dataSet )
			: base( dataSet )
        {
			Columns.Add("remove_after", typeof(int));
			this.keys.Add( new XDataTableKey( true
				, "game_pattern_pair"
				, new string[]{ Columns[1].ColumnName,Columns[2].ColumnName} ) );
        }



		public DataRow[] GetPatterns(DataRow game)
		{
			DataRow[] result;
			DataRow[] tmp = game.GetChildRows( "session_game_has_pattern" );
			result = new DataRow[tmp.Length];
			int idx = 0;
			foreach( DataRow row in tmp )
			{
				result[idx++] = row.GetParentRow( "pattern_in_session_game" );
			}
			return result;
		}
	}
}
