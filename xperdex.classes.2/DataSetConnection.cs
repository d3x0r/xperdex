using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace xperdex.classes
{
	public class DataSetConnection
	{
		DataSet active_dataset;
		public delegate void TableFillMethod();
		private LinkedList<DataTable> TableFiller = new LinkedList<DataTable>();
		private List<DataTable> TableNoAutoFill = new List<DataTable>();
		class TableDefaultFiller
		{
			internal String real_fill_method;
			internal String method_name;
			internal DataTable table;
			internal TableDefaultFiller( String name, String name2, DataTable table )
			{
				this.real_fill_method = name2;
				this.table = table;
				this.method_name = name;
			}
		}
		private List<TableDefaultFiller> TableFillers = new List<TableDefaultFiller>();

		public delegate void TableCreateMethod();
		public LinkedList<DataTable> PersistantTables = new LinkedList<DataTable>();


		void HookEvents( DataSet dataSet )
		{
			active_dataset = dataSet;
			dataSet.Tables.CollectionChanged += new System.ComponentModel.CollectionChangeEventHandler( Tables_CollectionChanged );
			foreach( DataTable table in dataSet.Tables )
			{
				CheckAddTable( table );
			}
		}

		void AddTable( DataTable table )
		{
			List<LinkedListNode<DataTable>> nodes = new List<LinkedListNode<DataTable>>();

			if( table.ParentRelations.Count > 0 && table.ChildRelations.Count == 0 )
			{
				// only has parents, must add at end.
				PersistantTables.AddLast( table );
				return;
			}

			// if there are no parents, add it first.  
			if( table.ParentRelations.Count == 0 )
			{
				PersistantTables.AddFirst( table );
				return;
			}

			// parent relations > 0 and child relations > 0
			// therefore fits somewhere in the center....
			{
				foreach( DataRelation dr in table.ChildRelations )
				{
					LinkedListNode<DataTable> node = PersistantTables.Find( dr.ChildTable );
					if( node != null )
						nodes.Add( node );
				}

				// there are already existing children in the persistent list, find the first, and go before it.
				if( nodes.Count > 0 )
				{
					LinkedListNode<DataTable> first_node = null;
					DataTable first = null;
					foreach( LinkedListNode<DataTable> node in nodes )
					{
						foreach( DataTable check_table in PersistantTables )
						{
							if( check_table == first )
							{
								break;
							}
							
							if( node.Value == check_table )
							{
								first = node.Value;
								first_node = node;
								break;
							}
						}
						if( first != null )
						{
							PersistantTables.AddBefore( first_node, table );
							return;
						}
					}
				}

				foreach( DataRelation dr in table.ParentRelations )
				{
					LinkedListNode<DataTable> node = PersistantTables.Find( dr.ChildTable );
					if( node != null )
						nodes.Add( node );
				}
				LinkedListNode<DataTable> last_node = null;
				DataTable last = null;
				foreach( LinkedListNode<DataTable> node in nodes )
				{
					bool found_last = false;
					foreach( DataTable check_table in PersistantTables )
					{
						if( check_table == last )
						{
							found_last = true;
							continue;
						}

						if( node.Value == check_table )
						{
							if( last == null )
							{
								last_node = node;
								last = node.Value;
							}
							else
								if( found_last )
								{
									last_node = node;
									last = node.Value;
								}
							break;
						}
					}
					if( last != null )
					{
						PersistantTables.AddAfter( last_node, table );
						return;
					}
				}
			}
			PersistantTables.AddLast( table );
			return;
		}

		void CheckAddTable( DataTable table )
		{
			//if( ( table ) != null )
			//	Log.log( "added " + ( table ).TableName );
			foreach( Attribute attr in table.GetType().GetCustomAttributes( true ) )
			{
				//Log.log( "Checking " + attr.ToString() + " in " + e.Element.ToString() );
				{
					SQLPersistantTable persist = attr as SQLPersistantTable;
					if( null != persist )
					{
						AddTable( table );

						DataTable db_DataTable = table;
						if( db_DataTable != null )
						{
							if( persist.FillMethod != "None" )
							{
								// this list is used for begin/end load data...
								TableFiller.AddLast( db_DataTable );
								TableFillers.Add( new TableDefaultFiller( persist.DefaultFill, persist.Fill, db_DataTable ) );
							}
							else
							{
								TableNoAutoFill.Add( db_DataTable );
							}
						}
						break;
					}
				}
			}
		}

		void Tables_CollectionChanged( object sender, System.ComponentModel.CollectionChangeEventArgs e )
		{
			if( e.Action == System.ComponentModel.CollectionChangeAction.Add )
			{
				CheckAddTable( e.Element as DataTable );
			}
		}

		public DataSetConnection( DataSet dataSet )
		{
			HookEvents( dataSet );
		}


		public void Create( DsnConnection odbc )
		{
			foreach( DataTable m in PersistantTables )
			{
				DsnSQLUtil.MatchCreate( odbc, m );
			}
		}

		public void Fill( DsnConnection odbc )
		{
			active_dataset.Clear();
			foreach( DataTable f in TableFiller )
			{
				IXDataTable xtable = f as IXDataTable;
				if( xtable != null )
					xtable.filling = true;
				f.BeginLoadData();
			}
			// use a slightly more complex fill method, 1, if a table has a self filler, use it
			// else use default fill all
			// and then if there is a default fill proc, call it - it will add default data if rows=0
			foreach( TableDefaultFiller f in TableFillers )
			{
				Type type = f.table.GetType();
				if( f.real_fill_method != null )
					type.InvokeMember( f.real_fill_method,
								   BindingFlags.Default | BindingFlags.InvokeMethod,
								   null,
								   f.table,
								   null );
				else
					DsnSQLUtil.FillDataTable( odbc, f.table, null, null );
				bool fill_ok = false;
				if( f.method_name == "DefaultFill" )
				{
					if( f.table.Rows.Count == 0 )
						fill_ok = true;
				}
				else
					fill_ok = true;

				if( fill_ok )
					if( f.method_name != null )
						type.InvokeMember( f.method_name,
									   BindingFlags.Default | BindingFlags.InvokeMethod,
									   null,
									   f.table,
									   null );

			}
			foreach( DataTable f in TableFiller )
			{
				try
				{
					IXDataTable xtable = f as IXDataTable;
					if( xtable != null )
						xtable.filling = false;
					f.EndLoadData();
				}
				catch( Exception e )
				{
					Log.log( "Failed to load: " + e.Message );
					DumpTableErrors();
				}
			}
		}

		void DumpTableErrors( )
		{
			foreach( DataTable table in active_dataset.Tables )
			{
				if( table.HasErrors )
				{
					Log.log( table.TableName + " is in error..." );
					DataRow[] rows = table.GetErrors();
					for( int i = 0; i < rows.Length; i++ )
					{
						for( int j = 0; j < table.Columns.Count; j++ )
						{
							Log.log( "Row" + rows[i].RowState + "[" + i + "][" + table.Columns[j].ColumnName + "] = " + rows[i][j] + " : " + rows[i].RowError );
						}
					}
				}
			}
		}

		public void Commit( DsnConnection odbc )
		{
			odbc.BeginTransaction();
			foreach( DataTable m in PersistantTables )
			{
				Log.log( "Commiting " + m.ToString() );
				DsnSQLUtil.CommitChanges( odbc, m );
			}
			odbc.EndTransaction();
			active_dataset.AcceptChanges();
		}

		List<DataTable> approved_tables;
		List<DataRelation> approved_relations;
		/// <summary>
		/// Checkpoint this dataset with its current tables and relations.  This allows temporarily removing tables for saving to XML
		/// </summary>
		public void StoreCoreTables()
		{
			if( approved_tables == null )
				approved_tables = new List<DataTable>();
			else
				approved_tables.Clear();
			foreach( DataTable table in active_dataset.Tables )
			{
				approved_tables.Add( table );
			}
			if( approved_relations == null )
				approved_relations = new List<DataRelation>();
			foreach( DataRelation relation in active_dataset.Relations )
			{
				approved_relations.Add( relation );
			}
		}

		internal struct tableconstraint
		{
			internal DataTable table;
			internal Constraint constraint;
		}
		List<tableconstraint> suspened_constraint;
		List<DataTable> suspended;
		List<DataRelation> suspended_relations;
		/// <summary>
		/// This is used to remove tables that are not part of the core dataset.  Tables that are approved should be marked by previously invoking StoreCoreTables()
		/// </summary>
		public void SuspendForeignTables( )
		{
			if( suspended_relations == null )
				suspended_relations = new List<DataRelation>();
			else
				suspended_relations.Clear();
			if( suspended == null )
				suspended = new List<DataTable>();
			else
				suspended.Clear();
			if( suspened_constraint == null )
				suspened_constraint = new List<tableconstraint>();
			else
				suspened_constraint.Clear();
			if( approved_tables != null )
			{
				foreach( DataTable table in active_dataset.Tables )
				{
					if( approved_tables.IndexOf( table ) == -1 )
					{
						suspended.Add( table );
					}
				}
			}
			if( approved_relations != null )
			{
				foreach( DataRelation relation in active_dataset.Relations )
				{
					if( approved_relations.IndexOf( relation ) == -1 )
					{
						suspended_relations.Add( relation );
					}
				}
			}
			foreach( DataRelation relation in suspended_relations )
			{
				active_dataset.Relations.Remove( relation );
			}

			//foreach( Constraint c in constraints
			foreach( DataTable table in suspended )
			{
				foreach( Constraint c in table.Constraints )
				{
					UniqueConstraint uc = c as UniqueConstraint;
					if( uc != null && uc.IsPrimaryKey )
						continue;
					tableconstraint tmp;
					tmp.table = table;
					tmp.constraint = c;
					suspened_constraint.Add( tmp );
				}
				foreach( tableconstraint c in suspened_constraint )
				{
					if( c.table == table )
						table.Constraints.Remove( c.constraint );
				}
				active_dataset.Tables.Remove( table );
			}
		}

		/// <summary>
		/// This resumes foreign tables in the dataset (post WriteXML), after SuspendforeignTables() was invoked.
		/// </summary>
		public void ResumeForeignTables()
		{
			foreach( DataTable table in suspended )
			{
				active_dataset.Tables.Add( table );
				foreach( tableconstraint c in suspened_constraint )
				{
					if( c.table == table )
						table.Constraints.Add( c.constraint );
				}
			}
			foreach( DataRelation relation in suspended_relations )
			{
				active_dataset.Relations.Add( relation );
			}
		}



		public void Drop( DsnConnection dataConnection )
		{
			for( LinkedListNode<DataTable> table_node = PersistantTables.Last; table_node != null; table_node = table_node.Previous )
			{
				DsnSQLUtil.DropTable( dataConnection, table_node.Value );
			}
		}
	}
}
