using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;
using xperdex.core;
using xperdex.core.interfaces;
using System.Windows.Forms;

namespace PlayList_Manager
{
	public class HallSelector :  IReflectorButton, IReflectorPersistance, IReflectorCreate
	{
		protected PSI_Button me;
		internal DataRow fileset;

		static int n;
		public HallSelector()
		{
			n++;
			if( Local.FileSets == null )
			{
				MessageBox.Show( "No File Sets available" );
				throw new Exception( "No File Sets available" );
			}
			if( n >= Local.FileSets.Rows.Count )
				n = 0;
			fileset = Local.FileSets.Rows[n];
		}


		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			if( Local.selected_button != this )
			{
				if( Local.selected_button!= null )
				Local.selected_button.me.Highlight = false;
				me.Highlight = true;
				Local.current_fileset = fileset;
				Local.selected_button = this;
			}
			return true;
		}

		#endregion

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "HallSelector" )
			{
				DataRow[] rows = Local.FileSets.Select( "Name='" + r.Value + "'" );
				if( rows.Length > 0 )
					fileset = rows[0];
				return true;
			}
			//throw new NotImplementedException();
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			w.WriteElementString( "HallSelector", fileset["Name"].ToString() );
			//throw new NotImplementedException();
		}

		void IReflectorPersistance.Properties()
		{
			EditHallSelector dialog = new EditHallSelector( this );
			dialog.ShowDialog();
			dialog.Dispose();
			// Select current FileSet associated with this button.
			//throw new NotImplementedException();
		}

		#endregion

		#region IReflectorCreate Members

		void IReflectorCreate.OnCreate( System.Windows.Forms.Control pc )
		{
			me = pc as PSI_Button;
			pc.Text = fileset["Name"].ToString();
		}

		#endregion
	}
}
