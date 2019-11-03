using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Data.Common;
using xperdex.classes;

// SHOULD GO TO A CORE PLACE. 
// IT IS CALLED BY CONFIG CLASESS

namespace CORE.Config
{
	public class OptionTree
	{
		private System.Collections.SortedList allNodes;
		private DsnConnection _dsn;

		public OptionTree(DsnConnection odbc)
		{
			_dsn = odbc;
		}

		// Add JMU
		/// <summary>
		/// Find a value in the Option Tree. Does NOT change the database.
		/// </summary>
		/// <param name="Path"></param>
		/// <param name="Option_Value"></param>
		/// <param name="Option_Description"></param>
		/// <returns>The value of the Option searched for</returns>
		public string GetValueOptionTree(string Path, string Default_value)
		{
			string value;
			if (Path.EndsWith("/"))
			{
				Path = Path.Remove(Path.Length - 1);
			}
			if (Path.StartsWith("/"))
			{
				Path = Path.Substring(1);
			}
			value = recursiveValueOptionTree(0, Path);
			if (value == null)
				value = Default_value;
			return value;
		}

		// Add JMU
		/// <summary>
		/// Recursive Look for the value the last Node. Does NOT change the database.
		/// </summary>
		/// <param name="Parent_node_id"></param>
		/// <param name="p_Path"></param>
		/// <returns>The value of the Option searched for</returns>
		private string recursiveValueOptionTree(int Parent_node_id, string p_Path)
		{
			string path1, path2, sql, value;
			int DelimeterSize, parent_id;
			DbDataReader OptionReader;

			DelimeterSize = p_Path.IndexOf("/");
			if (DelimeterSize == -1)
			{
				#region Search for value
				sql = " Select value.string " +
				  " FROM option_map map, option_name name, option_values value " +
				  " WHERE map.parent_node_id = " + Parent_node_id +
				  " AND   map.name_id = name.name_id " +
				  " AND   name.name = '" + p_Path + "'" +
				  " AND   map.value_id = value.value_id ";
				OptionReader = _dsn.KindExecuteReader(sql);
				if (!(OptionReader.HasRows))
				{
					value = null;
				}
				else
				{
					value = OptionReader.GetString(OptionReader.GetOrdinal("string"));
				}
				OptionReader.Close();
				OptionReader = null;
				return value;
				#endregion
			}
			else
			{
				#region Search Recursive ChildNode
				path1 = p_Path.Substring(0, DelimeterSize);
				path2 = p_Path.Substring(DelimeterSize + 1);

				sql = " Select map.node_id " +
					  " FROM option_map map, option_name name " +
					  " WHERE map.parent_node_id = " + Parent_node_id +
					  " AND   map.name_id = name.name_id " +
					  " AND   name.name = '" + path1 + "'";
				OptionReader = _dsn.KindExecuteReader(sql);
				if (!(OptionReader.HasRows))
				{
					OptionReader.Close();
					OptionReader = null;
					return null;
				}
				else
				{
					parent_id = OptionReader.GetInt32(OptionReader.GetOrdinal("node_id"));
					OptionReader.Close();
					OptionReader = null;
					return recursiveValueOptionTree(parent_id, path2);
				}
				#endregion
			}

		}

		// Add JMU
		/// <summary>
		/// Find or Insert a value in the Option Tree. Make Change the database.
		/// </summary>
		/// <param name="Path"></param>
		/// <param name="Option_Value"></param>
		/// <param name="Option_Description"></param>
		/// <returns>The value of the Option searched for</returns>
		public string GetSetValueOptionTree(string Path, string Default_value, string Default_Description)
		{
			//sack.SQL.
			string value;
			if (Path.EndsWith("/"))
			{
				Path = Path.Remove(Path.Length - 1);
			}
			if (Path.StartsWith("/"))
			{
				Path = Path.Substring(1);
			}
			value = recursiveValueOptionTree(0, Path, Default_value, Default_Description);
			//if (value == null)
			//    value = Default_value;
			return value;
		}

		// Add JMU
		/// <summary>
		/// Recursive Look for the value the last Node. Make Changes in the database.
		/// </summary>
		/// <param name="Parent_node_id"></param>
		/// <param name="p_Path"></param>
		/// <returns>The value of the Option searched for</returns>
		private string recursiveValueOptionTree(int Parent_node_id, string p_Path, string Default_value, string Default_Description)
		{
			string path1, path2, sql, value;
			int DelimeterSize, parent_id;
			DbDataReader OptionReader;

			DelimeterSize = p_Path.IndexOf("/");
			if (DelimeterSize == -1)
			{
				#region Search for value
				sql = " Select value.string " +
				  " FROM option_map map, option_name name, option_values value " +
				  " WHERE map.parent_node_id = " + Parent_node_id +
				  " AND   map.name_id = name.name_id " +
				  " AND   name.name = '" + p_Path + "'"	+
				   " AND   map.value_id = value.value_id ";

				OptionReader = _dsn.KindExecuteReader(sql);
				if (!(OptionReader.HasRows))
				{
					OptionReader.Close();
					OptionReader = null;
					int name_id = GetNameID(p_Path);
					int value_id = InsertValue(Default_value);
					InsertOptionNode(Parent_node_id, name_id, Default_Description, value_id);
					value = Default_value;
				}
				else
				{
					value = OptionReader.GetString(OptionReader.GetOrdinal("string"));
					OptionReader.Close();
					OptionReader = null;
				}

				return value;
				#endregion
			}
			else
			{
				#region Search Recursive ChildNode
				path1 = p_Path.Substring(0, DelimeterSize);
				path2 = p_Path.Substring(DelimeterSize + 1);

				sql = " Select map.node_id " +
					  " FROM option_map map, option_name name " +
					  " WHERE map.parent_node_id = " + Parent_node_id +
					  " AND   map.name_id = name.name_id " +
					  " AND   name.name = '" + path1 + "'";
				OptionReader = _dsn.KindExecuteReader(sql);
				if (!(OptionReader.HasRows))
				{
					OptionReader.Close();
					OptionReader = null;
					int name_id = GetNameID(path1);
					int node_id = InsertOptionNode(Parent_node_id, name_id, "", 0);
					return recursiveValueOptionTree(node_id, path2, Default_value, Default_Description);
				}
				else
				{
					parent_id = OptionReader.GetInt32(OptionReader.GetOrdinal("node_id"));
					OptionReader.Close();
					OptionReader = null;
					return recursiveValueOptionTree(parent_id, path2, Default_value, Default_Description);
				}
				#endregion
			}
		}

		// Add JMU
		/// <summary>
		/// Find AND UPDATE value in the Option Tree. Make Change the database.
		/// </summary>
		/// <param name="Path"></param>
		/// <param name="Option_Value"></param>
		/// <param name="Option_Description"></param>
		/// <returns>The value of the Option searched for</returns>
		public string SetValueOptionTree(string Path, string Default_value, string Default_Description)
		{
			string value;
			if (Path.EndsWith("/"))
			{
				Path = Path.Remove(Path.Length - 1);
			}
			if (Path.StartsWith("/"))
			{
				Path = Path.Substring(1);
			}
			value = recursiveSetValueOptionTree(0, Path, Default_value, Default_Description);
			//if (value == null)
			//    value = Default_value;
			return value;
		}

		// Add JMU
		/// <summary>
		/// Recursive Look for the value the last Node. Make Changes in the database.
		/// </summary>
		/// <param name="Parent_node_id"></param>
		/// <param name="p_Path"></param>
		/// <returns>The value of the Option searched for</returns>
		private string recursiveSetValueOptionTree(int Parent_node_id, string p_Path, string Default_value, string Default_Description)
		{
			string path1, path2, sql, value;
			int DelimeterSize, parent_id;
			DbDataReader OptionReader;

			DelimeterSize = p_Path.IndexOf("/");
			if (DelimeterSize == -1)
			{
				#region Search for value
				sql = " Select value.value_id " +
				  " FROM option_map map, option_name name, option_values value " +
				  " WHERE map.parent_node_id = " + Parent_node_id +
				  " AND   map.name_id = name.name_id " +
				  " AND   name.name = '" + p_Path + "'" +
				   " AND   map.value_id = value.value_id ";

				OptionReader = _dsn.KindExecuteReader(sql);
				if (!(OptionReader.HasRows))
				{
					OptionReader.Close();
					OptionReader = null;
					int name_id = GetNameID(p_Path);
					int value_id = InsertValue(Default_value);
					InsertOptionNode(Parent_node_id, name_id, Default_Description, value_id);
					value = Default_value;
				}
				else
				{
					value = OptionReader.GetString(OptionReader.GetOrdinal("value_id"));
					OptionReader.Close();
					OptionReader = null;

					sql = " UPDATE option_values " +
					  " SET string = '" + Default_value + "' " +
					  " WHERE value_id = " + value;

					_dsn.KindExecuteNonQuery(sql);
				}

				return value;
				#endregion
			}
			else
			{
				#region Search Recursive ChildNode
				path1 = p_Path.Substring(0, DelimeterSize);
				path2 = p_Path.Substring(DelimeterSize + 1);

				sql = " Select map.node_id " +
					  " FROM option_map map, option_name name " +
					  " WHERE map.parent_node_id = " + Parent_node_id +
					  " AND   map.name_id = name.name_id " +
					  " AND   name.name = '" + path1 + "'";
				OptionReader = _dsn.KindExecuteReader(sql);
				if (!(OptionReader.HasRows))
				{
					OptionReader.Close();
					OptionReader = null;
					int name_id = GetNameID(path1);
					int node_id = InsertOptionNode(Parent_node_id, name_id, "", 0);
					return recursiveSetValueOptionTree(node_id, path2, Default_value, Default_Description);
				}
				else
				{
					parent_id = OptionReader.GetInt32(OptionReader.GetOrdinal("node_id"));
					OptionReader.Close();
					OptionReader = null;
					return recursiveSetValueOptionTree(parent_id, path2, Default_value, Default_Description);
				}
				#endregion
			}
		}

		/// <summary>
		/// Get Computer Ip Address 
		/// </summary>
		/// <returns></returns>
		public string GetSystemPath()
		{
			string sql = "SELECT user() as address";
			string ip_address;

			object return_object;

			return_object = _dsn.ExecuteScalar(sql);
			if (return_object != null)
			{
				ip_address = Convert.ToString(return_object);
				if (String_Utilities.CountWords(ip_address, "@") != 0)
				{
					ip_address = String_Utilities.GetWord(ip_address, "@", 2);
				}
				else
				{
					ip_address = "0.0.0.0";
				}
			}
			else
			{
				ip_address = "0.0.0.0";
			}

			return ip_address;
			//string ipaddress = Convert.ToString(DbService.RunScalar(sql));
			//string[] p = ipaddress.Split('@');
			//return p[1].ToString();

		}

		/// <summary>
		/// Get the id of a name from the option_name table, creates the name entry if one does not already exist.
		/// </summary>
		/// <param name="OptionName">The Name to get</param>
		/// <returns>The Index of the name from the option_name table</returns>
		private int GetNameID(string OptionName)
		{
			string Sql = null;
			int Name_ID = 0;

			try
			{
				Sql = "SELECT name_id FROM option_name " +
					  "WHERE name = '" + OptionName + "' " +
					  "ORDER BY name_id ASC";
				Name_ID = Convert.ToInt32(_dsn.ExecuteScalar(Sql));

				if (!(Name_ID > 0))
				{
					Name_ID = InsertName(OptionName);
				}

			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}

			return Name_ID;
		}

		/// <summary>
		/// Insert a Value into option_values
		/// </summary>
		/// <param name="OptionValue">The Value to insert</param>
		/// <returns>The Index of the new value from the option_values table</returns>
		private int InsertValue(string OptionValue)
		{
			return InsertValue(OptionValue, false, "", "");
		}

		/// <summary>
		/// Insert a Value into option_values
		/// </summary>
		/// <param name="OptionValue">The default Value to insert</param>
		/// <param name="prompt">To prompt or not prompt for a user specified value</param>
		/// <param name="PromptOptionPathText">Option Path for the prompt</param>
		/// <param name="PromptOptionDescriptionText">Option Description for the prompt</param>
		/// <returns>The Index of the new value from the option_values table</returns>
		private int InsertValue(string OptionValue, bool prompt, string PromptOptionPathText, string PromptOptionDescriptionText)
		{
			string[] Sql = new string[1];
			string Sql2 = null;
			int Value_ID = 0;
			
			DbDataReader Reader;
			try
			{


				Sql[0] = "INSERT INTO option_values (string) VALUES ('" + OptionValue + "')";
				Sql2 = "SELECT LAST_INSERT_ID() as value_id";
				Reader = _dsn.RunQueryNonQuery(Sql, Sql2);
				if (Reader.Read())
					Value_ID = Reader.GetInt32(0);
				else
					Value_ID = 0;

			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}

			return Value_ID;
		}

		/// <summary>
		/// Insert a Name into option_name
		/// </summary>
		/// <param name="OptionName">The Name to insert</param>
		/// <returns>The Index of the new name from the option_name table</returns>
		private int InsertName(string OptionName)
		{
			string[] Sql = new string[1];
			string Sql2 = null;
			int Name_ID = 0;

			DbDataReader Reader;
			try
			{


				Sql[0] = "INSERT INTO option_name (name) VALUES ('" + OptionName + "')";
				Sql2 = "SELECT LAST_INSERT_ID() as name_id";
				Reader = _dsn.RunQueryNonQuery(Sql, Sql2);
				if (Reader.Read())
					Name_ID = Reader.GetInt32(0);
				else
					Name_ID = 0;

			}


			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}

			return Name_ID;
		}

		private int InsertOptionNode(int ParentNode_ID, int Name_ID, string Description, int Value_ID)
		{
			string[] Sql = new string[1];
			string Sql2 = null;
			int Node_ID = 0;

			try
			{
				Sql[0] = "INSERT INTO option_map (parent_node_id, name_id, value_id, description) " +
					  "VALUES (" + ParentNode_ID + ", " + Name_ID + ", " + Value_ID + ", '" +
					  Description + "')";
				Sql2 = "SELECT LAST_INSERT_ID() as node_id";
				DbDataReader Reader = _dsn.RunQueryNonQuery(Sql, Sql2);
				if (Reader.Read())
					Node_ID = Reader.GetInt32(0);
				else
					Node_ID = 0; 
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}

			return Node_ID;
		}
	}
}
