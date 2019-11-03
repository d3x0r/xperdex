using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable]
	public class Dealer:MySQLDataTable
	{
		new public static readonly string TableName = "dealer";
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );
		public static readonly string NameColumn = XDataTable.Name( TableName );
		public static string[] DataColumns = {
			"card_skip", 
			"page_skip", 
			"row_skip", 
			"column_skip", 
            "superstack" 
											 };


		public void InitialFill()
		{
			if( Rows.Count == 0 )
			{
				DataRow default_row = NewRow();
				default_row[Dealer.NameColumn] = "Normal";
				default_row["card_skip"] = 50;
				default_row["page_skip"] = 1;
				default_row["row_skip"] = 0;
				default_row["column_skip"] = 0;
				Rows.Add( default_row );
				CommitChanges();
			}
			DefaultDealer = (int)Rows[0]["dealer_id"];
		}

		public Dealer()
		{
			base.TableName = "(tmp)" + TableName;
		}


		public Dealer( DataSet dataSet )
		{
			base.Prefix = Names.schedule_prefix;
			base.TableName = TableName;

			
			// use default columns adder instead...
			base.AddDefaultColumns( true, true, true );

			Columns.Add( "card_skip", typeof( int ) );
			Columns.Add( "page_skip", typeof( int ) );
			Columns.Add( "row_skip", typeof( int ) );
			Columns.Add( "column_skip", typeof( int ) );
            Columns.Add( "superstack", typeof( bool ) );
			//Create();
			//Fill();
			dataSet.Tables.Add( this );

		
			//systems = new MySQLNameTable( odbc, null, "systems", true, true, true );
			//dataSet.Tables.Add( systems );
			//config = dataSet;

			//dealer = new Dealer(odbc, dataSet);

			//dealer_systems = new DealerSystemTable(odbc, dataSet);
			//dataSet.Tables.Add( new DealerPacks( odbc ) );
			dataSet.Tables.Add( new DealerHistory( ) );
			dataSet.Relations.Add( new DataRelation( "dealer_deals", dataSet.Tables["dealer"].Columns[0], dataSet.Tables["dealer_history"].Columns["dealer_id"] ) );
		
		}

		//public DataSet config;
		//public Dealer dealer;
		public DataTable dealer_systems;
		public DataTable PrizeLevels
		{
			get
			{
				return DataSet.Tables["prize_level"];
			}
		}
		
		//public MySQLNameTable systems;// = new MySQLNameTable( odbc, null, "systems", true );

		public int DefaultDealer;

	}

	[SchedulePersistantTable]
	class DealerHistory: MySQLDataTable
	{
		new static public String TableName = "dealer_history";
		//public DealerHistory()
		//{
		//	base.TableName = "(tmp)" + TableName;
		//}


		public DealerHistory(  )
		{
			base.Prefix = Names.schedule_prefix;
			TableName = "dealer_history";
			AddDefaultColumns( false );
			Columns.Add( "dealer_id", XDataTable.DefaultAutoKeyType );
			Columns.Add( "starting_card", typeof( int ) );
			Columns.Add( "ending_card", typeof( int ) );
			Columns.Add( "dealt_whenstamp", typeof( DateTime ) );
		}

	}
}
