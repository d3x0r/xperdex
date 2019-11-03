using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Xml.XPath;
using xperdex.classes;

namespace xperdex.tasks
{
	public class TaskItem
	{
		string _path;
		string _program;
		string _arguments;
		string[] _args;
		string _name;

		internal bool run_remote;			/// this means launch it through the launchpad
		internal bool exclusive;
		internal bool capture_output;
		internal bool run_once;
		internal bool wait_for_caller;
		internal bool restart;
		// program name..." 
		StringBuilder sb;
		internal string[] Args
		{
			get
			{
				return _args;
			}
		}
		void ParseArguments()
		{
			List<String> args = new List<string>();
			int start = 0;
			bool escape = false;
			bool quote = false;
			bool started = false;
			int n;
			for( n = 0; n < _arguments.Length; n++ )
			{
				switch( _arguments[n] )
				{
				case '\"':
					if( quote )
					{
						if( escape )
						{
							escape = false;
							continue;
						}
						quote = false;
						args.Add( _arguments.Substring( start, n - start ) );
						started = false;
					}
					else
					{
						quote = true;
						start = n + 1;
					}
					break;
				case '\\':
					if( !escape )
						escape = true;
					else
						escape = false;
					break;
				case ' ':
					if( quote )
						continue;
					if( escape )
					{
						escape = false;
						continue;
					}
					args.Add( _arguments.Substring( start, n - start ) );
					start = n + 1;
					break;
				default:
					if( escape )
					{
						escape = false;
					}
					started = true;
					break;
				}

			}
			if( started )
				args.Add( _arguments.Substring( start, n - start ) );
			_args = args.ToArray();
		}
		internal string Arguments
		{
			get
			{
				return _arguments;
			}
			set
			{
				_arguments = value;
				ParseArguments();
			}

		}
		internal string Argument
		{
			set
			{
				if( value == null )
				{
					_arguments = null;
					return;
				}
				if( sb == null )
					sb = new StringBuilder();
				if( sb.Length > 0 )
					sb.Append( " " );
				if( value.IndexOf( ' ' ) >= 0 )
					sb.Append( "\"" + value + "\"" );
				else
					sb.Append( value );
				_arguments = sb.ToString();
				ParseArguments();
			}
		}
		internal string WorkingPath
		{
			get { return _path; }
			set { _path = value; }
		}
		internal string ProgramName { set { _program = value; } get { return _program; } }
		List< Process> instances;

		internal void Close()
		{
			if( instances != null )
			{
			restart_loop:
				if( instances.Count > 0 )
				{
					Process process = instances[0];
					instances.Remove( process );
					process.CloseMainWindow();
					process.Close();
					goto restart_loop;
				}
				instances = null;
			}
		}

		void Init()
		{
			System.Windows.Forms.Application.ApplicationExit += new EventHandler( Application_ApplicationExit );
		}

		void Application_ApplicationExit( object sender, EventArgs e )
		{
			Close();
		}

		internal TaskItem()
		{
			
			_path = ".";
			_program = "cmd.exe";
			_arguments = "/c dir";

			_program = "sky.jpg";
			_arguments = null;
			Init();
		}

		public TaskItem( String program_name )
		{
			_program = program_name;
			Init();
		}
		public TaskItem( String program_name, String working_path, String args )
		{
			_program = program_name;
			_path = working_path;
			_arguments = args;
			Init();

		}
		public TaskItem( String program_name, String working_path )
		{
			_program = program_name;
			_path = working_path;
			Init();
		}

		~TaskItem()
		{
			System.Windows.Forms.Application.ApplicationExit -= Application_ApplicationExit;
		}

		// pretty name (for button text)
		internal string Name { set { _name = value; }  get { return _name; } }
		public override string ToString()
		{
			return Name;

		}

		//internal Process process;
		public bool Execute( out Process out_process )
		{
			if( run_remote )
			{
				//MessageBox.Show( "Running task remote... bad status result." );
				out_process = null;
				return LaunchCommandPost.PerformLaunch( this );
			}
			if( exclusive || run_once && instances.Count > 0 )
			{
				// return failure... already running.
			}
			ProcessStartInfo ps = new ProcessStartInfo(_program, _arguments );
			//ps.Domain;
			//ps.StandardOutputEncoding
			if( _path != null )
				ps.WorkingDirectory = _path;	

			ps.RedirectStandardOutput = true;
			ps.RedirectStandardInput = true;
			ps.RedirectStandardError = true;
			//ps.
			ps.CreateNoWindow = true;
			ps.UseShellExecute = false;

			Process process = new Process();
			//p.MachineName = "172.17.3.101";
			if( instances == null )
				instances = new List<Process>();
			instances.Add( process );

			out_process = process;

			process.ErrorDataReceived += new DataReceivedEventHandler( p_ErrorDataReceived );

			process.OutputDataReceived += new DataReceivedEventHandler( p_OutputDataReceived );

			process.Exited += new EventHandler( p_Exited );
			process.EnableRaisingEvents = true;

			try
			{
				process.StartInfo = ps;
				//ps.
				process.Start();

			}
			catch( Win32Exception e )
			{
				// if launching as a window process fails, attempt to use shell execute, to handle shell associted links (.lnk)
				ps.RedirectStandardError = false;
				ps.RedirectStandardInput = false;
				ps.RedirectStandardOutput = false;
				ps.UseShellExecute = true;
				try
				{
					process.Start();
				}
				catch( Win32Exception e2 )
				{
					Log.log( "Failed to launch program (" + process.StartInfo.FileName + ") in (" + process.StartInfo.WorkingDirectory + ")" );

					instances.Remove( process );
					process = null;
					out_process = null;
					return false;
				}
				//p = Process.Start( ps );
			}
			catch( Exception e )
			{
				Console.WriteLine( e.Message );
			}
			//p.BeginOutputReadLine();
			try
			{
				if( process.HasExited )
				{
					string s;
					while( ( s = process.StandardOutput.ReadLine() ) != null )
					{
						Console.WriteLine( s );
					}
					while( ( s = process.StandardError.ReadLine() ) != null )
					{
						Console.WriteLine( s );
					}
				}
				else
				{
					if( process.StartInfo.RedirectStandardError )
						process.BeginErrorReadLine();
					if( process.StartInfo.RedirectStandardOutput )
						process.BeginOutputReadLine();
				}
			}
			catch( Exception ex )
			{
			}
			// can use p.StartInfo to get the startup... 
			return true;
		}

		public bool Execute()
		{
			Process process;
			return Execute( out process );
		}

		void p_Exited( object sender, EventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
			if( instances != null )
				instances.Remove( (Process)sender );
		}

		void p_ErrorDataReceived( object sender, DataReceivedEventArgs e )
		{
			Process p = (Process)sender;
			if( e.Data == null )
			{
				Console.WriteLine( "End of file?" );
			}
			else
			Console.WriteLine( e.Data );
		}

		void p_OutputDataReceived( object sender, DataReceivedEventArgs e )
		{
			Process p = (Process)sender;

			if( e.Data == null )
			{
				Console.WriteLine( "End of file?" );
			}
			else
				Console.WriteLine( e.Data );
		}


		internal bool Load( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				switch( r.Name )
				{
				case "Task":
					bool everokay = false;
					bool okay;
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						everokay = true;
						switch( r.Name )
						{
						case "exclusive":
							if( string.Compare( r.Value, "yes" ) == 0 )
								exclusive = true;
							else if( string.Compare( r.Value, "no" ) == 0 )
								exclusive = false;
							else if( string.Compare( r.Value, "false", true ) == 0 )
								exclusive = true;
							else if( string.Compare( r.Value, "true", true ) == 0 )
								exclusive = false;
							else
								exclusive = r.ValueAsBoolean;
							break;
						case "runonce":
							if( string.Compare( r.Value, "yes" ) == 0 )
								run_once = true;
							else if( string.Compare( r.Value, "no" ) == 0 )
								run_once = false;
							else if( string.Compare( r.Value, "false", true ) == 0 )
								run_once = true;
							else if( string.Compare( r.Value, "true", true ) == 0 )
								run_once = false;
							else
								run_once = r.ValueAsBoolean;
							break;
						case "remote":

							if( string.Compare( r.Value, "yes" ) == 0 )
								run_remote = true;
							else if( string.Compare( r.Value, "no" ) == 0 )
								run_remote = false;
							else if( string.Compare( r.Value, "false", true ) == 0 )
								run_remote = true;
							else if( string.Compare( r.Value, "true", true ) == 0 )
								run_remote = false;
							else
								run_remote = r.ValueAsBoolean;
							break;
						case "program":
							_program = r.Value;
							break;
						case "path":
							_path = r.Value;
							break;
						case "arguments":
							_arguments = r.Value;
							ParseArguments();
							break;
						case "name":
							_name = r.Value;
							break;
						}
					}
					if( everokay )
						r.MoveToParent();
					return true;
				}
				return false;
			}
			return false;
		}

		internal void Save( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "Task" );
			w.WriteAttributeString( "program", _program );
			w.WriteAttributeString( "path", _path );
			w.WriteAttributeString( "arguments", _arguments );
			w.WriteAttributeString( "name", _name );
			w.WriteAttributeString( "exclusive", exclusive.ToString() );
			w.WriteAttributeString( "runonce", run_once.ToString() );
			w.WriteAttributeString( "remote", run_remote.ToString() );
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
			//_.WriteStartAttribute( 
			//throw new Exception("The method or operation is not implemented.");
		}

	}
}
