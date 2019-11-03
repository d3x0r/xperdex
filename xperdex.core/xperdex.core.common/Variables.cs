using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using xperdex.core.interfaces;


namespace xperdex.core.variables
{

	public class Variable
	{
		public List<Control> controls = new List<Control>();
		public List<Variable> elements = new List<Variable>();
		IReflectorVariable IVariable = null;
		public IReflectorVariableArray IVariableArray = null;
		public IReflectorVariableNamedArray IVariableNamedArray = null;
		internal int member_index;
		internal String member_name;
		String _name;
		String _value;
		public string value { 
			get 
			{
				if( IVariableNamedArray != null )
					return IVariableNamedArray[member_name];
				if( IVariableArray != null )
					return IVariableArray[member_index];
				if( IVariable != null )
					return IVariable.Text;
				else return _value; 
			} 
			set { _value = value; } 
		}

		public string name { get { return _name; } set { _name = value; } }
		public Variable( String name, IReflectorVariable ivariable )
		{
			IVariable = ivariable;
			_name = name;
			_value = null;
		}

		public Variable( Variable var_base, int index )
		{
			IVariable = var_base.IVariable;
			IVariableArray = var_base.IVariableArray;
			IVariableNamedArray = var_base.IVariableNamedArray;
			member_index = index;
			_name = var_base._name;
			var_base.elements.Add( this );
		}

		public Variable( Variable var_base, String index )
		{
			IVariable = var_base.IVariable;
			IVariableArray = var_base.IVariableArray;
			IVariableNamedArray = var_base.IVariableNamedArray;
			Int32.TryParse( index, out member_index );
			member_name = index;
			_name = var_base._name;
			var_base.elements.Add( this );
		}

		public Variable( String name, IReflectorVariableArray ivariable )
		{
			IVariableArray = ivariable;
			_name = name;
			_value = null;
		}
		public Variable( String name, IReflectorVariableNamedArray ivariable )
		{
			IVariableNamedArray = ivariable;
			_name = name;
			_value = null;
		}
		public Variable( String name, String value )
		{
			IVariable = null;
			_value = value;
			_name = name;
		}
		public string Value( int index )
		{
			return IVariableArray[index];
		}
		public override string ToString()
		{
			return _name;
		}
		public void AddControl( Control c )
		{
			if( !controls.Contains( c ) )
				controls.Add( c );
		}
		public void Refresh()
		{
			foreach( Control c in controls )
				c.Refresh();
			int n;
			for( n = 0; n < elements.Count; n++ )
			{
				Variable v = elements[n];
				//foreach( Variable v in elements )
				v.Refresh();
			}
		}
	}

	class SystemName: IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "System Name"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return SystemInformation.ComputerName;
			}
			set
			{
				// cannot set computer name.
				;// Directory.SetCurrentDirectory( value );
			}
		}

		#endregion
	}

	class UserName : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "User Name"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return SystemInformation.UserInteractive + " or " + SystemInformation.UserDomainName;
			}
			set
			{
				// cannot set computer name.
				;// Directory.SetCurrentDirectory( value );
			}
		}

		#endregion
	}

	class CurrentPath : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "Current Path"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return Directory.GetCurrentDirectory();
			}
			set
			{
				Directory.SetCurrentDirectory( value );
			}
		}

		#endregion
	}

	public static class Variables
	{
		public static List<Variable> known_variables;
		public static List<Variable> known_variable_arrays;

		static void variables( out List<Variable> variables )
		{
			variables = known_variables;
		}

		static Variables()
		{
			known_variables = new List<Variable>();
			known_variable_arrays = new List<Variable>();
		}

		public static void UpdateVariable( String name )
		{
			int varnamelen;
			Variable v = FindVariable( name, out varnamelen );
			if( v != null )
			{
				v.Refresh();
			}
		}

		static Variable FindVariable( String name, out int varnamelen )
		{
			Variable this_variable = null;
			varnamelen = 0;
			foreach( Variable v in known_variables )
			{
				if( string.Compare( name, 0, v.name, 0, v.name.Length ) == 0 )
				{
					varnamelen = v.name.Length;
					this_variable = v;
				}
			}
			if( this_variable == null )
				foreach( Variable v in known_variable_arrays )
				{
					if( string.Compare( name, 0, v.name, 0, v.name.Length ) == 0 )
					{
						if( v.name.Length == name.Length )
						{
							varnamelen = name.Length;
							return v;
						}

						if( name[v.name.Length] != '[' )			   
							continue;
						int n = 0;
						for( ; v.name.Length + n < name.Length; n++ )
							if( name[v.name.Length + n] == ']' )
							{
								String index_text = name.Substring( v.name.Length + 1, n-1 );
								
								int index ;
								if( !Int32.TryParse( index_text, out index ) )
								{
									foreach( Variable instance in v.elements )
									{
										if( String.Compare( instance.member_name, index_text, true ) == 0 )
										{
											this_variable = instance;
											break;
										}
									}
								}
								else foreach( Variable instance in v.elements )
								{
									if( instance.member_index == index )
									{
										this_variable = instance;
										break;
									}
								}
								if( this_variable == null )
								{
									if( v.IVariableArray != null )
										this_variable = new Variable( v, index );
									else if( v.IVariableNamedArray != null )
										this_variable = new Variable( v, index_text );
								}
								break;
							}
						varnamelen = v.name.Length + n + 1;
						//break;
					}
				}
			return this_variable;
		}

		public static void AddVariableInterface( String name, IReflectorVariable IVariable )
		{
			int varnamelen;
			Variable this_variable = FindVariable( name, out varnamelen );
			if( this_variable == null )
				known_variables.Add( this_variable = new Variable( name, IVariable ) );
			else
			{
				Log.log( "Variable name already defined..." );
			}
			//this_variable.
		}
		public static void AddVariableInterface( String name, IReflectorVariableArray IVariable )
		{
			int varnamelen;
			Variable this_variable = FindVariable( name, out varnamelen );
			if( this_variable == null )
			{
				known_variable_arrays.Add( this_variable = new Variable( name, IVariable ) );
			}
			else
			{
				Log.log( "Variable name already defined..." );
			}
			//this_variable.
		}
		public static void AddVariableInterface( String name, IReflectorVariableNamedArray IVariable )
		{
			int varnamelen;
			Variable this_variable = FindVariable( name, out varnamelen );
			if( this_variable == null )
			{
				known_variable_arrays.Add( this_variable = new Variable( name, IVariable ) );
			}
			else
			{
				Log.log( "Variable name already defined..." );
			}
			//this_variable.
		}
		public static void SetVariable( String name, String value )
		{
			int varnamelen;
			Variable this_variable = FindVariable( name, out varnamelen );
			if( this_variable == null )
				known_variables.Add( this_variable = new Variable( name, value ) );
			else
				this_variable.value = value;
		}
		/// <summary>
		///  parse a string and replace variable refereneces within...
		/// </summary>
		/// <param name="s">the string reference to translate...</param>
		/// <returns></returns>
		public static String ResolveVariables( Control c, String s )
		{
			StringBuilder sb_out = new StringBuilder();
			int offset = 0;
			if( s == null )
				return null;
			while( offset < s.Length )
			{
				if( s[offset] == '%' )
				{
					int varnamelen;
					if( (offset+1) < s.Length )
						if( s[offset+1] == '%' )
						{
							sb_out.Append( '%' );
							offset += 2;
							continue;

						}
					Variable var = FindVariable( s.Substring( offset + 1 ), out varnamelen );
					if( var != null )
					{
						var.AddControl( c );
						offset += varnamelen;
						sb_out.Append( var.value );
					}
				}
				else
					sb_out.Append( s[offset] );
				offset++;
			}
			return sb_out.ToString();
		}
	}
}
