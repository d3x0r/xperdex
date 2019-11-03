using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace OpenSkie.classes
{
	public class DataTableButton: IReflectorButton, IReflectorPersistance
	{
		enum ButtonModes
		{
			DataItem, NextItem, PriorItem, NextPage, PriorPage
		}
		ButtonModes mode;
		DataTable _table;
		DataTableButtonGroup group; // which dataset(button set) this button belongs to...

		public DataTableButton( DataTable table )
		{

		}

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			switch( mode )
			{
			default:
			case ButtonModes.DataItem:
				break;
			case ButtonModes.NextItem:
				break;
			case ButtonModes.PriorItem:
				break;
			case ButtonModes.NextPage:
				break;
			case ButtonModes.PriorPage:
				break;
			}
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			//throw new Exception( "The method or operation is not implemented." );
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPersistance.Properties()
		{
			DataTableButtonEditor dtbe = new DataTableButtonEditor();
			dtbe.ShowDialog();
			if( dtbe.DialogResult == System.Windows.Forms.DialogResult.OK )
			{

			}
			dtbe.Dispose();
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
