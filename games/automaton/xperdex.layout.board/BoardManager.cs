using System;
using System.Collections.Generic;
using System.Data;
using xperdex.classes;

namespace xperdex.layout.board
{
	public static class BoardManager
	{
		static BoardStorageDataSet storage;
		static BoardManager()
		{
			storage = new BoardStorageDataSet();
		}

		public static void Restore()
		{
			storage.ReadXml( "static.board.storage.xml" );
		}
		public static void Restore( DsnConnection dsn )
		{
			DsnSQLUtil.FillDataSet( dsn, storage );
		}
		public static void Store()
		{
			storage.WriteXml( "static.board.storage.xml" );
		}
		public static void Store( DsnConnection dsn )
		{
			DsnSQLUtil.CreateDataTable( dsn, storage );
			DsnSQLUtil.CommitChanges( dsn, storage );
		}

		public static String[] GetBoards()
		{
			List<String> names = new List<string>();
			foreach( DataRow row in storage.Tables["Boards"].Rows )
			{
				names.Add( row["name"].ToString() );
			}
			return names.ToArray();
		}

		/// <summary>
		/// This will load a board from the storage into the board specified...
		/// </summary>
		/// <param name="board"></param>
		public static void LoadBoard( Board board, String name )
		{

		}
	}
}
