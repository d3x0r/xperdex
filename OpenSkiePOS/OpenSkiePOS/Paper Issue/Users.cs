using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core;
using System.Windows.Forms;
using xperdex.classes;
using System.Data.Odbc;
using System.Data.Common;
using xperdex.core.common.Text_Layout;
using xperdex.core.interfaces;

namespace OpenSkiePOS.Paper_Issue
{
	internal static class Users
	{
		static List<UserButton> buttons = new List<UserButton>();
		// valid_buttons are the count of buttons that were last 
		// successully assigned between reset user and now...
		static int valid_buttons;

		internal class User
		{
			bool _selected;
			public UserButton b;
			
			public bool selected
			{
				set
				{
					_selected = value;
					b.SetHighlighted( value );
				}
				get
				{
					return _selected;
				}
			}
		
			public string Name;
			public User( String name )
			{
				this.Name = name;
			}
			public void Click()
			{
				if( !OpenSkiePOS.Paper_Issue.Users.multi_select )
				{
					if( OpenSkiePOS.Paper_Issue.Users.Current != null )
					{
						OpenSkiePOS.Paper_Issue.Users.Current.selected = false;
					}
				}
				selected = true;
				OpenSkiePOS.Paper_Issue.Users.Current = this;
			}
		}
		static List<User> users = new List<User>();
		static User Current;
		internal static bool multi_select;
		static int last_assigned_user;
		static TextLayoutInstance user_layout;

		static void LoadUsers()
		{
			DbDataReader db = StaticDsnConnection.KindExecuteReader( "select * from permission_user_info" );
			if( db != null )
			while( db.Read() )
			{
				User user = new User( (String)db["name"] );
				users.Add( user );
			}
		}

		static Users()
		{
			LoadUsers();
		}

		static internal User AssignNext( UserButton button )
		{
			int n = 0;
			foreach( User user in users )
			{
				if( n == last_assigned_user )
				{
					last_assigned_user++;
					user.b = button;
					//button.click = user.Click;
					button.layout["User Name"] = user.Name;
					Users.buttons.Add( button );
					valid_buttons++;
					return user;
					break;
				}
				n++;				
			}
			//button.layout = user_layout;
			return null;
		}

		static internal void ReassignNext()
		{
			if( ( users.Count - last_assigned_user ) > buttons.Count )
			{
				foreach( UserButton button in buttons )
				{
					AssignNext( button );
				}
				valid_buttons = 0;
			}
		}

		static internal void ReassignPrevious()
		{
			if( last_assigned_user >= buttons.Count )
				last_assigned_user -= buttons.Count;
		}

		static internal void ResetAssignments()
		{
			Users.buttons.Clear();
			last_assigned_user = 0;
			valid_buttons = 0;
		}
	}

	public class UserButtonNext : IReflectorButton
	{
		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{

			//throw new Exception( "The method or operation is not implemented." );
			return true;
		}

		#endregion
	}

	public class UserButton : ButtonWithLabelAreas, IReflectorDirectionShow
		, IReflectorWidget
	{
		Users.User user;
		
		#region IReflectorDirectionShow Members

		void IReflectorDirectionShow.PageChanged()
		{
			Users.ResetAssignments();
		}

		void IReflectorDirectionShow.Shown( )
		{
			user = Users.AssignNext( this );
		}

		void IReflectorDirectionShow.Hidden()
		{
			user = null;
			// no real action... could maybe de-populate buttons...
		}

		#endregion

		public UserButton()
			: base( "User Button Layout" )
		{

		}

		#region IReflectorWidget Members

		bool IReflectorWidget.CanShow
		{
			get {
				return ( user != null );
			}
		}

		void IReflectorWidget.OnPaint( PaintEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorWidget.OnKeyPress( KeyPressEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
