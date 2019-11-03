using System;
using System.Windows.Forms;
using xperdex.core.interfaces;

namespace xperdex.Milk
{
	public class Plugin: Control, IReflectorPersistance
	{
		MILK.MILK_Canvas canvas;

		public override string ToString()
		{
			//using SACK
			return "MILK Interfacer...";
		}

		public Plugin()
		{
			ConfigName = "Milk.default.config";
			canvas = new MILK.MILK_Canvas( this.Handle );
		}

		protected override void OnSizeChanged( EventArgs e )
		{
			canvas.Resize( this.Width, this.Height );
		}

		protected override void OnGotFocus( EventArgs e )
		{
			canvas.Focus();
		}

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			switch( r.Name )
			{
			case "MILK_Config":
				ConfigName = r.Value;
				canvas.Load( ConfigName );
				return true;
			}
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			if( ConfigName != null )
			{
				w.WriteElementString( "MILK_Config", ConfigName );
				canvas.Save( ConfigName );
			}
				
		}

		string ConfigName;

		void IReflectorPersistance.Properties()
		{
			ConfigureMILK cm = new ConfigureMILK();
			cm.ShowDialog();
			if( cm.DialogResult == DialogResult.OK )
			{
				ConfigName = cm.textBoxConfigName.Text;
			}
		}

		#endregion
	}
}
