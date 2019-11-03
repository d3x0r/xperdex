
using xperdex.classes;
using System.Data;
using System.Collections.Generic;
using System;
using System.Globalization;
namespace OpenSkieTransactionServer
{
	partial class TransactionDataset
	{
		partial class osts_local_transaction_sequenceDataTable
		{
		}
	
		public void Initialize()
		{
			DsnSQLUtil.MatchCreate( StaticDsnConnection.dsn, this );
			foreach( DataTable table in Tables )
			{
				table.BeginLoadData();
			}

			DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, this.osts_pending_transactions );
			DsnSQLUtil.SyncDataTableAutoIncrement( StaticDsnConnection.dsn, this.osts_global_transaction_numbers );
			DsnSQLUtil.SyncDataTableAutoIncrement( StaticDsnConnection.dsn, this.osts_local_transaction_numbers );
			foreach( DataRow row in osts_pending_transactions )
			{
				List<DataRow> global_rows;
				List<DataRow> client_rows;
				global_rows = DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, osts_global_transaction_numbers, "global_transaction_number_id='" + row["global_transaction_number_id"] + "'" );
				client_rows = DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, osts_local_transaction_numbers, "local_transaction_number_id='" + row["local_transaction_number_id"] + "'" );
				foreach( DataRow close_row in global_rows )
				{
					close_row["incomplete"] = true;
					close_row["closed"] = DateTime.Now;
				}

				foreach( DataRow close_row in client_rows )
				{
					row.Delete();
				}
				DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_global_transaction_numbers );
				DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_local_transaction_numbers );
			}

			// delete all clients, all references are unknown now.
			List<DataRow> rows = DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, osts_clients );
			if( rows != null )
			{
				foreach( DataRow row in rows )
				{
					row.Delete();
				}
				DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_clients );
			}

			foreach( DataTable table in Tables )
			{
				table.BeginLoadData();
			}
		}

		public bool GetTransactionNumbers( int client_token, out int global_transnum, out int local_transnum )
		{
			DataRow[] pending = osts_pending_transactions.Select( "client_id='" + client_token + "'" );
			if( pending.Length == 1 )
			{
				DataRow row = pending[0];
				DataRow global_trans = row.GetParentRow( "global_transaction_number_is_pending" );
				global_transnum = Convert.ToInt32( global_trans["global_transnum"] );
				DataRow local_trans = row.GetParentRow( "local_transaction_number_is_pending" );
				local_transnum = Convert.ToInt32( local_trans["local_transnum"] );
				return true;
			}

			DataRow[] clients = osts_clients.Select( "client_id='" + client_token + "'" );
			DataRow client = clients[0];
			object _last_global_sequence = StaticDsnConnection.dsn.ExecuteScalar( "select max(sequence) from osts_global_transaction_sequence" );
			object _last_local_sequence = StaticDsnConnection.dsn.ExecuteScalar( "select max(sequence) from osts_local_transaction_sequence where client_id='" + client_token + "'" );
			int last_global_sequence = _last_global_sequence!=DBNull.Value?Convert.ToInt32( _last_global_sequence ):0;
			int last_local_sequence = _last_local_sequence!=DBNull.Value?Convert.ToInt32( _last_local_sequence ):0;
			DateTime client_bingoday = Convert.ToDateTime( client["client_bingoday"] );

			DataRow global_sequence = osts_global_transaction_sequence.NewRow();
			global_sequence["sequence"] = last_global_sequence+1;
			osts_global_transaction_sequence.Rows.Add( global_sequence );

			DataRow global_transaction = osts_global_transaction_numbers.NewRow();
			global_transaction["bingoday"] = client["client_bingoday"];
			global_transaction["created"] = DateTime.Now;
			global_transaction["closed"] = DateTime.MinValue;
			global_transaction["incomplete"] = true;
			string sequence = ( last_global_sequence + 1 ).ToString( "D10" );
			global_transnum = Convert.ToInt32( client_bingoday.DayOfYear.ToString( "D3" ) + sequence.Substring( 5 ) );
			global_transaction["global_transnum"] = global_transnum;
			osts_global_transaction_numbers.Rows.Add( global_transaction );

			DataRow local_sequence = osts_local_transaction_sequence.NewRow();
			local_sequence["sequence"] = last_local_sequence+1;
			local_sequence["client_id"] = client_token;
			osts_local_transaction_sequence.Rows.Add( local_sequence );

			DataRow local_transaction = osts_local_transaction_numbers.NewRow();
			local_transaction["bingoday"] = client["client_bingoday"];
			local_transaction["client_id"] = client_token;
			sequence = ( last_local_sequence + 1 ).ToString( "D10" );
			local_transnum = Convert.ToInt32( client_bingoday.DayOfYear.ToString( "D3" ) + ( client_token.ToString( "D10" ).Substring( 8 ) ) + sequence.Substring( 6 ) );
			local_transaction["local_transnum"] = local_transnum;
			osts_local_transaction_numbers.Rows.Add( local_transaction );

			DataRow pending_row = osts_pending_transactions.NewRow();
			pending_row["global_transaction_number_id"] = global_transaction["global_transaction_number_id"];
			pending_row["local_transaction_number_id"] = local_transaction["local_transaction_number_id"];
			pending_row["client_id"] = client_token;
			osts_pending_transactions.Rows.Add( pending_row );

			global_sequence["global_transaction_number_id"] = global_transaction["global_transaction_number_id"];
			local_sequence["local_transaction_number_id"] = local_transaction["local_transaction_number_id"];

			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_global_transaction_sequence );
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_local_transaction_sequence );
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_global_transaction_numbers );
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_local_transaction_numbers );

			return true;
		}

		public int InitializeClient( String address, int port, DateTime bingoday )
		{
			DataRow[] clients = osts_clients.Select( "client_address='" + address + "' and client_bingoday=" + DsnSQLUtil.MakeDateOnly( bingoday ) );
			if( clients.Length == 0 )
			{
				DataRow new_client = osts_clients.NewRow();
				new_client["client_address"] = address;
				new_client["client_port"] = port;
				new_client["client_bingoday"] = bingoday;
				osts_clients.Rows.Add( new_client );
				return Convert.ToInt32( new_client["client_id"] );
			}
			else if( clients.Length == 1 )
			{
				return Convert.ToInt32( clients[0]["client_id"] );
			}
			else
			{
				Log.log( "More than one client from this address on this day..." );
				throw new Exception( "Database sync failure" );
			}

			return 0;
		}

		public bool CloseTransaction( int client_token )
		{
			bool closed = false;
			DataRow[] clients = osts_clients.Select( "client_id='" + client_token + "'" );
			DataRow client = clients[0];
			DataRow[] pending = osts_pending_transactions.Select( "client_id='" + client_token + "'" );
			foreach( DataRow row in pending )
			{
				closed = true;
				DataRow global_transaction = row.GetParentRow( "global_transaction_number_is_pending" );
				global_transaction["closed"] = DateTime.Now;
				global_transaction["incomplete"] = false;
				DataRow local_transaction = row.GetParentRow( "local_transaction_number_is_pending" );
				row.Delete();
			}
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_pending_transactions );
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_global_transaction_numbers );
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, osts_local_transaction_numbers );
			return closed;
		}
	}
}
