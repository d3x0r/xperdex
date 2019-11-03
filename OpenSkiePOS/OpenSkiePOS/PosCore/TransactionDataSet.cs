using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OpenSkiePOS.PosCore
{
	public class TransactionDataSet: DataSet
	{
		public delegate void _Generic();
		public delegate bool _ResultingGeneric();
		public delegate void _Generic2( Guid transid );

		public List<_ResultingGeneric> TransactionClearing;
		public event _Generic TransactionCleared;

		public event _Generic2 ReloadTransaction;

		public TransactionDataSet()
		{
			//ForeignKeyConstraint fkc = new ForeignKeyConstraint( dc1, dc2 );
			//fkc.UpdateRule = Rule.Cascade;
			
			//dt2.Constraints.Add( fkc );
			
			//this.EnforceConstraints = true;

		}


		void ClearTransaction()
		{
			foreach( _ResultingGeneric rg in TransactionClearing )
			{
				if( !rg() )
					return;
			}
			// clear all data.
			TransactionCleared();
		}

		void BeginTransaction()
		{
			ClearTransaction();
		}

		void CommitTransaction()
		{

		}
	}
}
