using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace xperdex.classes
{
    public class RegSQLDataTableExample : RegSQLDataTable
    {
        public RegSQLDataTableExample()
        {
        }

        public RegSQLDataTableExample(string prefix, DataTable MainDatatable)
        {
            this.TableName = MainDatatable.TableName;
            this.Prefix = prefix;
            string sql = "SHOW CREATE TABLE " + MainDatatable.TableName;
            DataTable ImportDataTable = StaticDsnConnection.GetDataTableQuery(sql);

            if (ImportDataTable.Rows.Count > 0)
            {
                sql = ImportDataTable.Rows[0]["Create Table"].ToString();
                sql = sql.Remove(0, 14);
                sql = "CREATE TABLE IF NOT EXISTS `" + prefix + sql;

                StaticDsnConnection.ExecuteNonQuery("DROP TABLE IF EXISTS " + prefix + MainDatatable.TableName);
                StaticDsnConnection.ExecuteNonQuery(sql);
            }

            foreach (DataColumn MainColumn in MainDatatable.Columns)
            {
                this.Columns.Add(MainColumn.ColumnName, MainColumn.DataType);
            }
            foreach (DataRow MainRow in MainDatatable.Rows)
            {
                this.Rows.Add(MainRow.ItemArray);
            }
        }

        public void GetMySQLDataTableExample(string NewTableName, DataTable MainDatatable, string CreateTableStatement, bool DropTable)
        {
            this.TableName = NewTableName;
            string sql = "";

            if (CreateTableStatement.Length == 0)
            {
                sql = " SHOW CREATE TABLE " + MainDatatable.TableName;
                DataTable ImportDataTable = StaticDsnConnection.GetDataTableQuery(sql);
                if (ImportDataTable.Rows.Count > 0)
                {
                    CreateTableStatement = ImportDataTable.Rows[0]["Create Table"].ToString();
                }
            }
            if (CreateTableStatement.Length > 0)
            {

                int lastIndexOf = CreateTableStatement.IndexOf("`", 15);
                sql = CreateTableStatement.Remove(0, lastIndexOf + 1);
                sql = "CREATE TABLE IF NOT EXISTS `" + NewTableName + "`" + sql;

                if (DropTable)
                    StaticDsnConnection.ExecuteNonQuery("DROP TABLE IF EXISTS " + NewTableName);
                StaticDsnConnection.ExecuteNonQuery(sql);
            }

            foreach (DataColumn MainColumn in MainDatatable.Columns)
            {
                this.Columns.Add(MainColumn.ColumnName, MainColumn.DataType);
            }
            foreach (DataRow MainRow in MainDatatable.Rows)
            {
                this.Rows.Add(MainRow.ItemArray);
            }

        }

        public void LoadMySQLDataTableExample(string prefix, string tablename)
        {
            //Create(prefix, tablename, postfix);
            this.TableName = tablename;
            this.Prefix = prefix;
            Fill();
        }

        public void LoadMySQLDataTableExample(string tablename)
        {
            //Create(prefix, tablename, postfix);
            this.TableName = tablename;
            Fill();	// SelectAll();
        }

        public void LoadMySQLDataTableExample(string tablename, string pFilter, bool LoadInformation)
        {
            //Create(prefix, tablename, postfix);
            this.TableName = tablename;
            this._filter = pFilter;
            if (LoadInformation)
                Fill();	// SelectAll();
        }

    }
}