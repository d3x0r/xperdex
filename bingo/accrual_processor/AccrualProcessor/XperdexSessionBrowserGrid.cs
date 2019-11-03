using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECube.AccrualProcessor
{
	[xperdex.core.interfaces.ControlAttribute( Name="Show Sessions Processed" )]
	public class XperdexSessionBrowserGrid : System.Windows.Forms.DataGridView
		//, xperdex.core.interfaces.IReflectorWidget
		, xperdex.core.interfaces.IReflectorPersistance
	{
		public XperdexSessionBrowserGrid( xperdex.core.Canvas canvas )
		{
			this.DataSource = Local.BingoDataSet.session;
			//this.DataSource = Local.accrual_state.accrual_processor_computed_sessions;


			this.FontChanged += XperdexSessionBrowserGrid_FontChanged;
		}

		void XperdexSessionBrowserGrid_FontChanged( object sender, EventArgs e )
		{
			this.ColumnHeadersHeight = Font.Height + 10;
			
		}


		protected override void  OnDataBindingComplete( DataGridViewBindingCompleteEventArgs e )
		{
			//DataGridViewCheckBoxColumn dgvc_bool = new DataGridViewCheckBoxColumn();
			//dgvc_bool.Name = "Processed";
			//dgvc_bool.HeaderText = "Processed";
			//dgvc_bool.

			//this.Columns["computed_session_id"].Visible = false;
			//this.Columns["when"].Visible = false;
			//this.Columns.Add( dgvc_bool );
		}
#if assdf
		bool xperdex.core.interfaces.IReflectorWidget.CanShow
		{
			get { return true; }
		}

		void xperdex.core.interfaces.IReflectorWidget.OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
 			throw new NotImplementedException();
		}

		void xperdex.core.interfaces.IReflectorWidget.OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
 			throw new NotImplementedException();
		}

		void xperdex.core.interfaces.IReflectorWidget.OnMouse(System.Windows.Forms.MouseEventArgs e)
		{
 			throw new NotImplementedException();
		}
#endif

		bool xperdex.core.interfaces.IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			/*
			if( r.Name == "displayTable" )
			{
				bool is_okay;
				if( r.MoveToFirstAttribute() )
				{
					DataSource = Local.BingoDataSet.Tables[r.Value];
					if( r.MoveToNextAttribute() )
						DisplayMember = r.Value;
					r.MoveToParent();
				}
				return true;
			}
			 * */
			// didn't handle this node...
			return false;
		}

		void xperdex.core.interfaces.IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			/*
			if( DataSource != null )
			{
				w.WriteStartElement( "displayTable" );
				w.WriteAttributeString( "tableName", ( (DataTable)DataSource ).TableName );
				w.WriteAttributeString( "displayName", DisplayMember );
				w.WriteEndElement();
			}
			 * */
			// don't save anything yet
		}

		void xperdex.core.interfaces.IReflectorPersistance.Properties()
		{
			//bingoDataSourceTableSelector form = new bingoDataSourceTableSelector( this );
			
			//form.ShowDialog( this );
			// trigger property dialog to select table to view.
		}
	}
}
