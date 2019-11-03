//#define MySQLDataTableUsage

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace xperdex.classes
{

#if MySQLDataTableUsage
	public class RegSQLDataTable : MySQLDataTable 
	{
#else
	public class RegSQLDataTable : XDataTable<DataRow>
	{
		protected DsnConnection connection;
		bool CreateTable = true;
		bool FillTable = true;
#endif
		string sql_quote = "`";

		protected string _filter = "";


		public string CompleteTableName
		{
			get { return Prefix + TableName; }
		}


		#region Internal Functions
		protected RegSQLDataTable()
		{
			this.connection = StaticDsnConnection.dsn;
			//this.RowDeleting += new DataRowChangeEventHandler(MySQLDataTable_RowDeleting);	
		}

		/// <summary>
		/// Creates a DataTable with a name
		/// </summary>
		/// <param name="name">Database Table name to fill the DataTable</param>
		protected RegSQLDataTable(string prefix, string name)
		{
			this.connection = StaticDsnConnection.dsn;
			this.Prefix = prefix;
			this.TableName = name;
		}

		/// <summary>
		/// Creates a DataTable with a name
		/// </summary>
		/// <param name="name">Database Table name to fill the DataTable</param>
		protected RegSQLDataTable(DsnConnection dsn, string prefix, bool CreateTable, bool FillTable)
		{
			this.connection = dsn;
			this.Prefix = prefix;
			this.CreateTable = CreateTable;
			this.FillTable = FillTable;
		}

		/// <summary>
		/// Creates a DataTable with a name
		/// </summary>
		/// <param name="name">Database Table name to fill the DataTable</param>
		protected RegSQLDataTable(DsnConnection dsn, string name, string prefix, bool CreateTable, bool FillTable)
		{
			this.connection = dsn;
			this.Prefix = prefix;
			this.CreateTable = CreateTable;
			this.FillTable = FillTable;
			this.TableName = name;
		}

#if MySQLDataTableUsage  
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public RegSQLDataTable(DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool add_default_name)
		{
			this.connection = dsn;
			this.TableName = name;
			this.Prefix = ( prefix == null ) ? "" : prefix;
			AddDefaultColumns( trim_info, true, add_default_name );
			if( auto_fill )
			{
				Create();
				Fill();
			}
			this.RowDeleting += new DataRowChangeEventHandler(MySQLDataTable_RowDeleting);
		}
#else
		/// <summary>
		/// This is the thing that actually adds the default TableName_id and TableName_name
		/// </summary>
		/// <param name="trim_info">Option to trim _info and _description</param>
		public void AddDefaultColumns(bool trim_info, bool add_auto_id, bool add_auto_name)
		{
			if (add_auto_id)
			{
				DataColumn dc = this.Columns.Add( XDataTable.ID( this ), typeof( int ) );
				dc.AutoIncrement = true;
				(this as DataTable).PrimaryKey = new DataColumn[] { dc };
			}
			if (add_auto_name)
			{
				this.Columns.Add( NameColumn, typeof( string ) ).Unique = true;
			}
		}


#endif
		/// <summary>
		/// To Load/Reload a DataTable with a specified Table in Database
		/// </summary>
		/// <param name="name">Database Table name to fill the DataTable</param>
		protected void Create(string prefix, string name)
		{
			this.TableName = name;
			this.Prefix = prefix;
			CreateCommand();
		}

		/// <summary>
		/// OBSOLETE - IT SHOULD USE dataRow[PrimaryKey[0].Ordinal, DataRowVersion.Original]
		/// Save the Row_id to delete item(s) in Update function
		/// Because if the row is deleted from DataTable we wont be able to 
		/// access to the Row.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MySQLDataTable_RowDeleting(object sender, DataRowChangeEventArgs e)
		{
			DataColumn auto = null;
			foreach (DataColumn col in Columns)
			{
				if (col.AutoIncrement)
					auto = col;
			}
			//if (auto != null)
			//_itemDeleted.Add(Convert.ToInt64(e.Row[auto.Ordinal]));
		}

		/// <summary>
		/// Create Table and Select All Records from Database
		/// </summary>
		protected void LoadMySQLDataTable()
		{
			if (CreateTable)
				Create();
			if (FillTable)
				Fill();
			//CreateCommand();
			//SelectAll();
		}

		/// <summary>
		/// Depending on Col.Type the function will return the value with/out quotes
		/// </summary>
		/// <param name="col"></param>
		/// <param name="row"></param>
		/// <returns></returns>
		public static string GetRowValue(DataColumn col, DataRow row)
		{
			string quote = "";
			string value = "";
            if (col.DataType == typeof(string) || col.DataType == typeof(DateTime) || col.DataType == typeof(TimeSpan))
			{
				quote = "'";
			}

			if (row[col.Ordinal].ToString() == "")
			{
				if (col.Namespace == "createstamp")
					value = quote + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + quote;
                else if (col.DataType == typeof(Int16) || col.DataType == typeof(Int32) || col.DataType == typeof(Int64) ||
                    col.DataType == typeof(Double) || col.DataType == typeof(Decimal) || col.DataType == typeof(float))
				    value = quote + "0" + quote;
                else
					value = quote + col.DefaultValue + quote;
			}
			else
			{
				if (col.DataType == typeof(Money))
				{
					long MoneyAux = (Money)row[col.Ordinal];
					value = quote + MoneyAux + quote;
				}
				else if (col.DataType == typeof(TimeSpan))
				{
					TimeSpan date = TimeSpan.Parse(row[col.Ordinal].ToString());
					value = quote + date.ToString() + quote;
				}
				else if (col.DataType == typeof(DateTime) && col.Namespace == "date")
				{
					DateTime date = Convert.ToDateTime(row[col.Ordinal]);
					value = quote + date.ToString("yyyy-MM-dd") + quote;
				}
				else if (col.DataType == typeof(DateTime))
				{
					DateTime date = Convert.ToDateTime(row[col.Ordinal]);
					value = quote + date.ToString("yyyy-MM-dd HH:mm:ss") + quote;
				}
				else
				{
					value = quote + row[col.Ordinal].ToString().Replace("\'","\\'") + quote;
				}
			}

			return value;
		}

		# endregion

		#region SQL MANUAL COMMANDS

		protected void AssignChartityHall(int p_hall_id, int p_charity_id)
		{
			_filter = _filter != "" ? _filter + " AND " : _filter;
			_filter = _filter + " hall_id = " + p_hall_id + " AND charity_id = " + p_charity_id;
		}

		protected string GetColumnScript(DataColumn col)
		{
			return
				((col.DataType == typeof(string) && col.Namespace == "text")
				? "text NULL "
				: (col.DataType == typeof(string))
				? "varchar(100) NOT NULL default ''"
				: (col.DataType == typeof(bool))
				? "tinyint(1) NOT NULL default 0"
				: (col.DataType == typeof(decimal))
				? "decimal(11,4) NOT NULL  default 0.00"
				: (col.DataType == typeof(double))
				? "double (11,4) NOT NULL default 0.0"
				: (col.DataType == typeof(TimeSpan))
				? "time default NULL,"
				: (col.DataType == typeof(DateTime) && col.Namespace == "time")
				? "timestamp default '00-00-00 00:00:00'"
				: (col.DataType == typeof(DateTime) && col.Namespace == "date")
				? "date default '0000-00-00'"
				: (col.DataType == typeof(DateTime) && col.Namespace == "createstamp")
				? "timestamp NOT NULL default CURRENT_TIMESTAMP"
				: (col.DataType == typeof(DateTime))
				? "datetime default '00-00-00 00:00:00'"
				: (col.DataType == typeof(byte[]))
				? "blob default NULL"
				: (col.AutoIncrement
				? "int(11) auto_increment"
				: (col.ColumnName.EndsWith("_id")
				? "int(11)"
				: "int(11) NOT NULL default '0'")));
		}

		/// <summary>
		/// Database Create script
		/// </summary>
		/// <returns></returns>
		protected virtual string CreateCommand()
		{
			string createComm = null;

			DbDataReader reader = connection.KindExecuteReader(" SHOW CREATE TABLE " + CompleteTableName);
			if (reader == null)
			{
				bool first = true;
				DataColumn auto = null;
				foreach (DataColumn col in Columns)
				{
					if (col.AutoIncrement)
						auto = col;

					#region createComm:
					createComm += (first ? "" : ",");
					createComm += sql_quote + col.ColumnName + sql_quote + " ";
					createComm += GetColumnScript(col);
					first = false;
					#endregion

				}
				if (auto != null)
				{
					createComm += ( first ? "" : "\t," ) + " PRIMARY KEY (" + sql_quote + auto.ColumnName + sql_quote + ")";
				}
				createComm = " CREATE TABLE IF NOT EXISTS "
					+ sql_quote
					+ CompleteTableName
					+ sql_quote
					+ "("
					+ createComm
					//+ ((extra != null) ? (first ? "" : ",") + extra : "")
					+ ") ENGINE=MyISAM ";
				connection.KindExecuteNonQuery(createComm);
			}
			return createComm;
		}

		protected virtual string AddColumnsCommand()
		{
			string alterComm = null;

			bool first = true;
			DataColumn auto = null;
			foreach (DataColumn col in Columns)
			{
				if (col.AutoIncrement)
					auto = col;

				#region alterComm:
				if (!CheckDataBaseTableColumn(col.ColumnName))
				{
					alterComm += (first ? "" : ",");
					alterComm += " ADD COLUMN " + sql_quote + col.ColumnName + sql_quote + " ";
					alterComm += GetColumnScript(col);
					first = false;
				}
				#endregion
			}
			if (auto != null)
			{
				//alterComm += (first ? "" : ",") + " ADD UNIQUE KEY (" + sql_quote + auto.ColumnName + sql_quote + ")";
			}
			if (!first)
			{
				alterComm = " ALTER TABLE "
				   + sql_quote
				   + CompleteTableName
				   + sql_quote
				   + alterComm;
				//+ ((extra != null) ? (first ? "" : ",") + extra : "")

				connection.KindExecuteNonQuery(alterComm);
			}
			return alterComm;
		}

		protected string DropColumnsCommand()
		{
			string alterComm = null;

			//string LoadColumns = " SELECT column_name " +
			//                     " FROM information_schema.columns " + 
			//                     " WHERE table_schema = (select database()) " +
			//                     " AND table_name = '" + CompleteTableName + "' ";

			bool first = true;

			DataTable AuxColumn = connection.GetDataTableQuery(" DESC " + CompleteTableName);
			foreach (DataRow DataBaseCol in AuxColumn.Rows)
			{
				if (Columns[DataBaseCol["field"].ToString()] == null)
				{
					alterComm += (first ? "" : ",");
					alterComm += " DROP COLUMN " + sql_quote + DataBaseCol["field"].ToString() + sql_quote + " ";
					first = false;
				}

			}

			alterComm = " ALTER TABLE "
				+ sql_quote
				+ CompleteTableName
				+ sql_quote
				+ alterComm;
			//+ ((extra != null) ? (first ? "" : ",") + extra : "")

			connection.KindExecuteNonQuery(alterComm);
			return alterComm;
		}

		protected bool CheckDataBaseTable()
		{
			string sql = "  SELECT count(*) " +
						  " FROM information_schema.tables " +
						  " WHERE table_schema = (select database()) " +
						  " AND table_name = '" + CompleteTableName + "' ";
			object result = connection.ExecuteScalar(sql);
			if (result == null || result.ToString() == "0")
				return false;
			else
				return true;
		}

		protected bool CheckDataBaseTableColumn(string Column)
		{
			string sql = "  SELECT count(*) " +
						  " FROM information_schema.columns " +
						  " WHERE table_schema = (select database()) " +
						  " AND table_name = '" + CompleteTableName + "' " +
						  " AND column_name = '" + Column + "' ";
			object result = connection.ExecuteScalar(sql);
			if (result == null || result.ToString() == "0")
				return false;
			else
				return true;
		}
		public void DumpStructure(bool DeleteColumns)
		{
			if (CheckDataBaseTable())
			{
				if (DeleteColumns)
					DropColumnsCommand();
				AddColumnsCommand();
			}
			else
				CreateCommand();
		}

		/// <summary>
		/// Re-Assembly Select Command & Fill the DataTable
		/// </summary>
		/// <param name="condition"></param>
		public virtual void SelectCondition()
		{
			SelectAll();
		}

		protected virtual void SelectAll()
		{
			string selectComm = "SELECT * FROM " + CompleteTableName;
			if (_filter != null && _filter != "")
				selectComm += " WHERE " + _filter;
			SelectCommand(selectComm);
		}

		/// <summary>
		/// Get from the Database the Table structure // Too Many records to Load All Table
		/// </summary>
		public virtual void SelectLimited()
		{
			string selectComm = "SELECT * FROM " + CompleteTableName;
			if (_filter != null && _filter != "")
				selectComm += " WHERE " + _filter;
			selectComm += " LIMIT 1";
			SelectCommand(selectComm);
		}
		public virtual void SelectLimited(int limited)
		{
			string selectComm = "SELECT * FROM " + CompleteTableName;
			if (_filter != null && _filter != "")
				selectComm += " WHERE " + _filter;
			selectComm += " LIMIT " + limited;
			SelectCommand(selectComm);
		}

		public virtual void SelectCondition(string condition)
		{
			if (condition != null && condition != "")
				if (_filter != null && _filter != "")
					condition = " WHERE " + _filter + " AND " + condition;
				else
					condition = " WHERE " + condition;
			string selectComm = "SELECT * FROM " + CompleteTableName + condition;
			SelectCommand(selectComm);
		}

		public virtual void SelectCondition(string condition, string order)
		{
			if (condition != null && condition != "")
				if (_filter != null && _filter != "")
					condition = " WHERE " + _filter + " AND " + condition;
				else
					condition = " WHERE " + condition;
			if (order != null && order != "")
				order = " ORDER BY " + order;
			string selectComm = "SELECT * FROM " + CompleteTableName + condition + order;
			SelectCommand(selectComm);
		}

		protected virtual void SelectCommand(string SelectQuery)
		{
			bool FirstRow = true;
			this.Clear();
			//Log.log("starting SELECT comand");
			DbDataReader DbRdr = connection.KindExecuteReader(SelectQuery);
			if (DbRdr != null)
			{
				while (DbRdr.Read())
				{
					DataRow dr = NewRow();
					for (int i = 0; i < DbRdr.FieldCount; i++)
					{
						string s = DbRdr.GetName(i); ;
						try
						{
							if (FirstRow)
							{
								if (Columns.IndexOf(s) < 0)
								{
									//if (DbRdr[i].GetType() != typeof(DBNull))
									//if (!DbRdr.IsDBNull(i))
									DataColumn dc = new DataColumn(s, DbRdr.GetFieldType(i));
									dc.ReadOnly = true;
									this.Columns.Add(dc);
									dr[s] = DbRdr[i];
								}
							}
							if (Columns[s].DataType == typeof(Money))
							{
								dr[s] = new Money(Convert.ToInt64(DbRdr[i]));
							}
							else
								dr[s] = DbRdr[i];
						}
						catch (ArgumentException arg)
						{
							if (Columns[s].DataType == typeof(Money))
							{
								dr[s] = new Money(Convert.ToInt64(DbRdr[i]));
							}
							Console.WriteLine(arg.Message);
						}
					}
					try
					{
						Rows.Add(dr);
					}
					catch (Exception e)
					{
						Console.Write(e.Message);
					}
					FirstRow = false;
				}
				DbRdr.Dispose();
			}
			this.AcceptChanges();
			//Log.log("ending SELECT comand");			
		}

		protected virtual void SelectCommand_old(string SelectQuery)
		{
			this.Clear();
			Log.log("starting SELECT comand");
			DbDataReader DbRdr = connection.KindExecuteReader(SelectQuery);
			if (DbRdr != null)
			{
				while (DbRdr.Read())
				{
					DataRow dr = NewRow();
					for (int i = 0; i < DbRdr.FieldCount; i++)
					{
						string s = DbRdr.GetName(i); ;
						try
						{
							if (Columns.IndexOf(s) >= 0)
							{
								if (Columns[s].DataType == typeof(Money))
								{
									dr[s] = new Money(Convert.ToInt64(DbRdr[i]));
								}
								else
									dr[s] = DbRdr[i];
							}
							else
							{
								//if (DbRdr[i].GetType() != typeof(DBNull))
								if (!DbRdr.IsDBNull(i))
								{
									DataColumn dc = new DataColumn(s, DbRdr[i].GetType());
									dc.ReadOnly = true;
									this.Columns.Add(dc);
									dr[s] = DbRdr[i];
								}
							}
						}
						catch (ArgumentException arg)
						{
							if (Columns[s].DataType == typeof(Money))
							{
								dr[s] = new Money(Convert.ToInt64(DbRdr[i]));
							}
							Console.WriteLine(arg.Message);
						}
					}
					try
					{
						Rows.Add(dr);
					}
					catch (Exception e)
					{
						Console.Write(e.Message);
					}
				}
				DbRdr.Dispose();
			}
			this.AcceptChanges();
			Log.log("ending SELECT comand");			
		}

		string InsertCommand(DataRow Row)
		{
			string values = "";
			string insertComm = "INSERT INTO " + CompleteTableName + "(";
			bool first = true;
			DataColumn auto = null;
			foreach (DataColumn col in Columns)
			{
				if (col.AutoIncrement)
					auto = col;
				else
				{
					if (!col.ReadOnly)
					{
						if (//(Row[col.Ordinal].ToString() == "" && col.DataType == typeof(string))|| 
							// || col.DataType == typeof(DateTime)))
							(Row[col.Ordinal].ToString() != ""
							&& Row[col.Ordinal] != null ))
						{
							if (!first)
							{
								insertComm += ",";
								values += ",";
							}
							first = false;

							insertComm += col.ColumnName;

							values += GetRowValue(col, Row);
						}
					}
				}
			}
			insertComm += ")values(" + values + ")";
			if (auto != null)
			{
				DataRow[] insertedRow = Select(auto.ColumnName + " = " + Row[auto.Ordinal].ToString());
				Row[auto.Ordinal] = connection.KindExecuteInsert(insertComm);
				if (insertedRow.Length > 0)
					insertedRow[0][auto.Ordinal] = Row[auto.Ordinal];
			}
			else
				connection.KindExecuteInsert(insertComm);
			return insertComm;
		}

		private bool Compare(Type type, object a, object b)
		{
            //if (((a.GetType() == typeof(Int32) ||
            //     a.GetType() == typeof(Int64) ||
            //     a.GetType() == typeof(Double) ||
            //     a.GetType() == typeof(Decimal)) &&
            //     b.ToString() == ""))
                //return true;
            if (b.GetType() == typeof(DBNull) && a.GetType() == typeof(DBNull))
                return true;
            if (b.GetType() == typeof(DBNull))
                return false;
            if (a.GetType() == typeof(DBNull))
				return false;
            if (String.Compare(a.ToString(), b.ToString()) == 0)
				return true;
			return false;
		}

		string UpdateCommand(DataRow Row)
		{
			string updateComm = "UPDATE " + CompleteTableName + " SET ";
			bool first = true;
			DataColumn auto = null;
			
			foreach (DataColumn col in Columns)
			{
				if (col.AutoIncrement)
					auto = col;
				else
				{
					if (!col.ReadOnly)
					{
                        //if (//(Row[col.Ordinal].ToString() == "" && col.DataType == typeof(string))|| 
                        //    //|| col.DataType == typeof(DateTime)))
                        //    (Row[col.Ordinal].ToString() != ""
                        //    && Row[col.Ordinal] != null))
                        if (Row[col.Ordinal].ToString() == "" && col.DataType == typeof(DateTime))
                        {
                        }
                        else
                        {
							object a, b;
							try
							{
								a = Row[col.ColumnName, DataRowVersion.Original];
								b = Row[col.ColumnName, DataRowVersion.Current];
							}
							catch (Exception e)
							{
								Log.log(e.Message);
								continue;

							} 
							if (!Compare(col.DataType, a, b))
							{
								updateComm += (!first) ? "," : "";
								first = false;
								updateComm += col.ColumnName + " = ";
								updateComm += GetRowValue(col, Row);
							}
						}
					}
				}
			}
			updateComm += " WHERE " + auto.ColumnName + "= " + Row[auto.Ordinal];

			if (!first)
				connection.KindExecuteNonQuery(updateComm);
			return updateComm;
		}

		string DeleteCommand(DataRow Row)
		{
			DataColumn auto = null;
			foreach (DataColumn col in Columns)
			{
				if (col.AutoIncrement)
					auto = col;
			}
			string deleteComm = " DELETE from  " + CompleteTableName
						+ " WHERE " + auto.ColumnName + " = " + Row[auto.ColumnName, DataRowVersion.Original];

			connection.KindExecuteNonQuery(deleteComm);
			return deleteComm;
		}

		public string DeleteRow(DataRow Row)
		{
			DataColumn auto = null;
			string deleteComm = "";
			bool first = true;
			foreach (DataColumn col in Columns)
			{
				if (col.AutoIncrement)
					auto = col;
				else
				{
					deleteComm += (!first) ? " WHERE " : " AND ";
					first = false;

					deleteComm += col.ColumnName + " = ";
					deleteComm += GetRowValue(col, Row);
				}
			}
			if (auto != null)
			{
				deleteComm = " DELETE from  " + CompleteTableName
						+ " WHERE " + auto.ColumnName + " = " + Row[auto.ColumnName];
			}
			else
			{
				deleteComm = " DELETE from  " + CompleteTableName + deleteComm;
			}
			connection.KindExecuteNonQuery(deleteComm);
			return deleteComm;
		}

		new public string Delete(string deleteCondition)
		{
			string deleteComm = " DELETE from  " + CompleteTableName + " WHERE " + deleteCondition;
			connection.KindExecuteNonQuery(deleteComm);
			return deleteComm;
		}

		#endregion

		#region User Features


		public DsnConnection Connection
		{
			get
			{ return connection ; }
			set
			{ connection = value; }
		}

		/// <summary>
		/// Creates the DataAdapter (insert, update, delete)
		/// </summary>
		public void Create()
		{
#if MySQLDataTableUsage
			base.Create();
#else
			CreateCommand();
#endif
		}


		/// <summary>
		/// Select All Records from Database
		/// </summary>
		public void Fill()
		{
#if MySQLDataTableUsage
			base.Fill();
#else
			SelectAll();
#endif
		}


		/// <summary>
		/// Synchronize the DataTable in memory with the Table in Database and updates Datatable autoincrement value if necessary (insert)
		/// </summary>
		public virtual List<string> Update()
		{
			DataTable Updates = this.GetChanges();
			List<string> Commands = new List<string>();

			if (Updates != null)
			{
				foreach (DataRow Row in Updates.Rows)
				{
					switch (Row.RowState)
					{
						case DataRowState.Added:
							Commands.Add(InsertCommand(Row));
							break;
						case DataRowState.Modified:
							Commands.Add(UpdateCommand(Row));
							break;
						case DataRowState.Deleted:
							Commands.Add(DeleteCommand(Row));
							break;
					}
				}
				AcceptChanges();
				//_itemDeleted = new List<Int64>();
			}
			return Commands;
		}

		/// <summary>
		/// Synchronize the DataTable in memory with the Table in Database and updates Datatable autoincrement value if necessary (insert)
		/// </summary>
		public virtual DataTable UpdateGetRows()
		{
			DataTable Updates = this.GetChanges();
			List<string> Commands = new List<string>();

			if (Updates != null)
			{
				foreach (DataRow Row in Updates.Rows)
				{
					switch (Row.RowState)
					{
						case DataRowState.Added:
							Commands.Add(InsertCommand(Row));
							break;
						case DataRowState.Modified:
							Commands.Add(UpdateCommand(Row));
							break;
						case DataRowState.Deleted:
							Commands.Add(DeleteCommand(Row));
							break;
					}
				}
				AcceptChanges();
				//_itemDeleted = new List<Int64>();
			}
			return Updates;
		}

		new public string GetConditionedDisplayValue(string ValueMember, string DisplayMember, string Condition)
		{
			string parentName = "";
			if (Condition != "")
			{
				DataRow[] ParentRow = this.Select(ValueMember + " = " + Condition);
				if (ParentRow.Length > 0)
					if (ParentRow.Length > 1)
						parentName = ParentRow[0][DisplayMember].ToString() + "... ";
					else
						parentName = ParentRow[0][DisplayMember].ToString();
				else
					parentName = "Unknown";
			}
			else
				parentName = "UnAssign";
			return parentName;
		}

		public string GetConditionedDisplayValue(string ValueMember, string DisplayMember, string Condition, string Default)
		{
			string parentName = "";
			DataRow[] ParentRow = this.Select(ValueMember + " = '" + Condition + "'");
			if (ParentRow.Length > 0)
				if (ParentRow.Length > 1)
					parentName = ParentRow[0][DisplayMember].ToString() + "... ";
				else
					parentName = ParentRow[0][DisplayMember].ToString();
			else
				parentName = Default;
			return parentName;
		}

		public DataRow GetConditionedColumn(string ValueMember, string condition)
		{
			DataRow[] ParentRow = this.Select(ValueMember + " = " + condition);
			if (ParentRow.Length > 0)
				return ParentRow[0];
			else
				return null;
		}

		/// <summary>
		/// Add DisplayMember Column Mapping the ValueMember Column with the ParentTable 
		/// </summary>
		/// <param name="ParentTable"></param>
		/// <param name="ValueMember"></param>
		/// <param name="DisplayMember"></param>
		/// <returns></returns>
		public void MergeTable(RegSQLDataTable ParentTable, string ValueMember, string DisplayMember)
		{
			bool created = false;
			DataColumn dc;
			if (this.Columns[DisplayMember] == null)
			{
				dc = new DataColumn(DisplayMember, typeof(string));
				this.Columns.Add(dc);
				created = true;
			}
			else
				dc = this.Columns[DisplayMember];
			foreach (DataRow ResultRow in this.Rows)
				ResultRow[DisplayMember] = ParentTable.GetConditionedDisplayValue(ValueMember, DisplayMember, ResultRow[ValueMember].ToString());
			if (created)
				dc.ReadOnly = true;
		}

		/// <summary>
		/// Add DisplayMember2 Column (this.DisplayMember1 + ParentTable.DisplayMember2) Mapping the ValueMember Column with the ParentTable 
		/// </summary>
		/// <param name="ParentTable"></param>
		/// <param name="ValueMember"></param>
		/// <param name="DisplayMember1"></param>
		/// <param name="DisplayMember2"></param>
		/// <returns></returns>
		public void MergeTable(RegSQLDataTable ParentTable, string ValueMember, string DisplayMember1, string DisplayMember2)
		{
			bool created = false;
			DataColumn dc;
			if (this.Columns[DisplayMember2] == null)
			{
				dc = new DataColumn(DisplayMember2, typeof(string));
				this.Columns.Add(dc);
				created = true;
			}
			else
				dc = this.Columns[DisplayMember2];
			foreach (DataRow ResultRow in this.Rows)
				ResultRow[DisplayMember2] = ResultRow[DisplayMember1] + ".) " + ParentTable.GetConditionedDisplayValue(ValueMember, DisplayMember2, ResultRow[ValueMember].ToString());
			if (created)
				dc.ReadOnly = true;
		}

		/// <summary>
		/// Add NewDisplayMember Column (this.DisplayMember1 + " " + this.DisplayMember2)
		/// </summary>
		/// <param name="ParentTable"></param>
		/// <param name="ValueMember"></param>
		/// <param name="DisplayMember1"></param>
		/// <param name="DisplayMember2"></param>
		/// <returns></returns>
		public void AddDisplayColumn(string NewDisplayMember, string DisplayMember1, string DisplayMember2)
		{
			bool created = false;
			DataColumn dc;
			if (this.Columns[NewDisplayMember] == null)
			{
				dc = new DataColumn(NewDisplayMember, typeof(string));
				this.Columns.Add(dc);
				created = true;
			}
			else
				dc = this.Columns[NewDisplayMember];
			foreach (DataRow ResultRow in this.Rows)
				ResultRow[NewDisplayMember] = ResultRow[DisplayMember1] + ". " + ResultRow[DisplayMember2];
			if (created)
				dc.ReadOnly = true;
		}


		# endregion



		#region escape
		/// <summary>
		/// A general utility for embedding escapes as required by string insertiaon to handle embeeded ' characters.
		/// </summary>
		/// <param name="blob">This is a string</param>
		/// <returns>a string appropriately escaped</returns>
		public string Escape(string blob)
		{

			int n = 0;
			int targetlen = 0;
			while (n < blob.Length)
			{
				if (blob[n] == '\'' ||
					blob[n] == '\\' ||
					blob[n] == '\0' ||
					blob[n] == '\"')
					targetlen++;
				n++;
			}

			char[] output = new char[n + targetlen];
			n = 0;

			//result = tmpnamebuf = (TEXTSTR)AllocateEx( targetlen + bloblen + 1 DBG_RELAY );

			int offset = 0;
			while (n < blob.Length)
			{
				if (blob[n] == '\'' ||
					blob[n] == '\\' ||
					blob[n] == '\0' ||
					blob[n] == '\"')
					output[offset++] = '\\';
				if (blob[n] != 0)
					output[offset++] = blob[n];
				else
					output[offset++] = '0';
				n++;
			}
			return new string(output);
		}
		public string Escape(byte[] blob)
		{

			int n = 0;
			int targetlen = 2;
			while (n < blob.Length)
			{
				if (blob[n] == '\'' ||
					blob[n] == '\\' ||
					blob[n] == '\0' ||
					blob[n] == '\"')
					targetlen++;
				n++;
			}

			char[] output = new char[n + targetlen];
			n = 0;

			//result = tmpnamebuf = (TEXTSTR)AllocateEx( targetlen + bloblen + 1 DBG_RELAY );

			int offset = 0;
			output[offset++] = '\'';
			while (n < blob.Length)
			{
				if (blob[n] == '\'' ||
					blob[n] == '\\' ||
					blob[n] == '\0' ||
					blob[n] == '\"')
					output[offset++] = '\\';
				if (blob[n] != 0)
					output[offset++] = Convert.ToChar(blob[n]);
				else
					output[offset++] = '0';
				n++;
			}

			output[offset++] = '\'';
			//output[offset++] = '\0'; // best terminate this thing.
			return new string(output);
		}
		#endregion



	}
}
