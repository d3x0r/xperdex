using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using xperdex.classes;

namespace ECube.AccrualProcessor
{
	public class JackpotLedger
	{
		private string Name;
		private DataRow this_row;
		private Guid ID;

		[SQLPersistantTable]
		public class JackpotLedgerTable : xperdex.classes.MySQLDataTable<JackpotLedgerTable.JackpotLedgerRow>
		{
			new static public readonly String TableName = "jackpot_ledger";
			new static public readonly String NameColumn = XDataTable.Name( TableName );
			new static public readonly String PrimaryKey = XDataTable.ID( TableName );

			[SQLPersistantTable]
			public class JackpotLedgerTransactionTable : xperdex.classes.MySQLDataTable<JackpotLedgerTransactionTable.JackpotLedgerTransactionRow>
			{
				new static public readonly String TableName = "jackpot_ledger_row";
				//static public readonly String NameColumn = XDataTable.Name( TableName );
				new static public readonly String PrimaryKey = XDataTable.ID( TableName );
			
				public class JackpotLedgerTransactionRow : DataRow
				{
					public JackpotLedgerTransactionRow( global::System.Data.DataRowBuilder rb ) :
						base( rb )
					{
					}

					public override string ToString()
					{
						return "Transaction Row";
					}

				}

				DataColumn dc_relate;
				DataColumn dc_relate_from;
				DataColumn dc_zero;
				void InitColumns()
				{
					AddDefaultColumns( this, false, true, false );
					dc_relate = Columns.Add( JackpotLedgerTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
					dc_relate_from = Columns.Add( "jackpot_ledger_from_id", XDataTable.DefaultAutoKeyType );
					dc_zero = Columns.Add( "zero_group_id", typeof( Guid ) );
					Columns.Add( "value", typeof( Decimal ) );
				}

				public JackpotLedgerTransactionTable()
				{
					InitColumns();
				}
				public JackpotLedgerTransactionTable( DataSet dataSet )
				{
					InitColumns();

					dc_relate_from.ExtendedProperties.Add( "index", true );
					dc_zero.ExtendedProperties.Add( "index", true );

					dataSet.Tables.Add( this );
					DataTable parent = dataSet.Tables["jackpot_ledger"];
					if( parent != null )
					{
						DataRelation dr;
						ParentRelations.Add( dr = new DataRelation( "jackpot_rows", parent.PrimaryKey[0], dc_relate ) );
						dr.ChildKeyConstraint.DeleteRule = Rule.None;
						dr.ChildKeyConstraint.UpdateRule = Rule.None;
						ParentRelations.Add( dr = new DataRelation( "jackpot_from_rows", parent.PrimaryKey[0], dc_relate_from ) );
						dr.ChildKeyConstraint.DeleteRule = Rule.None;
						dr.ChildKeyConstraint.UpdateRule = Rule.None;
					}
				}

				public DataRow NewRow( Guid ledger, Guid ledger_from, object zero_group, Decimal value )
				{
					DataRow result = NewRow();
					result["value"] = value;
					result[JackpotLedgerTable.PrimaryKey] = ledger;
					if( zero_group == null )
						result["zero_group_id"] = result[PrimaryKey];
					else
						result["zero_group_id"] = zero_group;
					Rows.Add( result );
					return result;
				}
			}

	
			public class JackpotLedgerRow : DataRow
			{
				public JackpotLedgerRow( global::System.Data.DataRowBuilder rb ) :
					base( rb )
				{
				}

				public override string ToString()
				{
					return "Transaction Row";
				}

			}

			void InitColumns( )
			{
				AddDefaultColumns( this, false, true, true );
				Columns.Add( "last_zero_balance", XDataTable.DefaultAutoKeyType );
				Columns.Add( "current_balance", typeof( Decimal ) );
				Columns.Add( "thefed", typeof( bool ) );
			}

			public JackpotLedgerTable()
			{
				InitColumns();
			}

			public JackpotLedgerTable( DataSet dataSet )
			{
				InitColumns();

				dataSet.Tables.Add( this );

				DataTable child = dataSet.Tables["jackpot_ledger_rows"];
				if( child != null )
				{
					ChildRelations.Add( new DataRelation( "jackpot_rows", base.PrimaryKey[0], child.Columns[JackpotLedgerTable.PrimaryKey] ) );
					ChildRelations.Add( new DataRelation( "jackpot_from_rows", base.PrimaryKey[0], child.Columns["jackpot_ledger_from_id"] ) );
				}
				//Columns.Add( PrizeExceptionSet.PrimaryKey, XDataTable.DefaultAutoKeyType );
				//Columns.Add( PriceExceptionSet.PrimaryKey, XDataTable.DefaultAutoKeyType );
				//Columns.Add( SessionTypeTable.PrimaryKey, XDataTable.DefaultAutoKeyType );

			}

			public Decimal Total( object key )
			{
				DataTable rows = this.DataSet.Tables["jackpot_ledger_row"];
				object result = rows.Compute( "sum(value)", "jackpot_ledger_id='" + key + "'" );
				if( result == DBNull.Value )
					return 0;
				return (Decimal)result;
			}

			public DataRow CreateLedger( String s )
			{
				s = DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, s );
				this.Fill( NameColumn + "='" + s + "'" );
				DataRow[] rows = Select( NameColumn + "='" + s + "'" );
				if( rows != null && rows.Length > 0 )
				{
					Local.jackpot_transaction_table.Fill( PrimaryKey + "='" + rows[0][PrimaryKey] + "'" );
					return rows[0];
				}
				DataRow row = NewRow();
				row[NameColumn] = s;
				row["last_zero_balance"] = DBNull.Value;
				row["current_balance"] = 0.00M;
				row["thefed"] = (Rows.Count == 0)?true:false;
				//row[PrimaryKey] = Guid.NewGuid();
				Rows.Add( row );
				DataRow first_transaction = Local.jackpot_transaction_table.NewRow( 
					(Guid)row[JackpotLedgerTable.PrimaryKey]
					, (Guid)row[JackpotLedgerTable.PrimaryKey]
					, null
					, 0.00M );
				row["last_zero_balance"] 
					= first_transaction[JackpotLedger.JackpotLedgerTable.JackpotLedgerTransactionTable.PrimaryKey];
				
				return row;
			}

		}

		public JackpotLedger()
		{

		}

		public JackpotLedger( string s )
		{
			// TODO: Complete member initialization
			foreach( JackpotLedger l in Local.known_ledgers )
			{
				if( String.Compare( s, l.Name, true ) == 0 )
					throw new Exception( "Ledger of that name already exists." );
			}

			Name = s;
			this_row = Local.jackpot_table.CreateLedger( s );
			ID = (Guid)this_row[JackpotLedger.JackpotLedgerTable.PrimaryKey];
		}

		public bool isTheFed
		{
			get
			{
				return (bool)this_row["thefed"];
			}
		}

		public Decimal Total
		{
			get
			{
				return Local.jackpot_table.Total( this_row[JackpotLedgerTable.PrimaryKey] );
			}
		}
		public override string ToString()
		{
			return Name;
		}

		internal void Transfer( Decimal valtotal, JackpotLedger jackpotLedger )
		{
			DataRow row = Local.jackpot_transaction_table.NewRow( ID, jackpotLedger.ID, null, valtotal );
			this_row["current_balance"] = (Decimal)this_row["current_balance"] + valtotal;
			jackpotLedger.this_row["current_balance"] = (Decimal)this_row["current_balance"] - valtotal;
			//Local.jackpot_transaction_table.Rows.Add( row );
		}
	}

	internal class JackpotList : List<JackpotLedger>
	{
		internal JackpotList()
		{
		}
		internal JackpotLedger this[string member] {
			get { foreach( JackpotLedger JackpotLedger in this ) { if( String.Compare( JackpotLedger.ToString(), member, true ) == 0 ) return JackpotLedger; } return null; }
		}
	}
}
