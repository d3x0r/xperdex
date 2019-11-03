using System.Windows.Forms;
using xperdex.core.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using xperd3x.breadboard;

namespace xperdex.layout.board
{
	[ControlAttribute(Name="Layout Toolbox")]
	public partial class ToolBox : UserControl, IReflectorPersistance
	{
		Type root_type;
		List<PeiceRepresentation> peices;

		public Type RootType
		{
			set
			{
				root_type = value;
				if( root_type != null )
					peices = BoardPlugin.PeiceTypes[root_type];
			}
			get
			{
				return root_type;
			}
		}

		public ToolBox()
		{
			InitializeComponent();
			Paint += new PaintEventHandler( ToolBox_Paint );
		}

		void ToolBox_Paint( object sender, PaintEventArgs e )
		{
			if( peices != null )
			{
				Rectangle rect = new Rectangle( 0, 0, Width / 2, Width / 2 );
				foreach( PeiceRepresentation peice in peices )
				{
					e.Graphics.DrawImage( peice.Image, rect );
					rect.Y += Width / 2;
					if( rect.Y > Height )
					{
						rect.Y = 0;
						rect.X += Width / 2;
					}
				}
			}
		}

        private void ToolBox_Load(object sender, System.EventArgs e)
        {

        }

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "ToolboxRoot" )
			{
				foreach( Type root_type in BoardPlugin.RootPeiceTypes )
				{
					if( r.Value == root_type.ToString() )
					{
						// call the property to setup other stuff
						this.RootType = root_type;
					}
				}
			}
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			if( root_type != null )
				w.WriteElementString( "ToolboxRoot", root_type.ToString() );
		}

		void IReflectorPersistance.Properties()
		{
			ToolboxProperties editor = new ToolboxProperties( this );
			editor.ShowDialog();
			if( editor.DialogResult == DialogResult.OK )
				RootType = editor.GetSelectedType();
			editor.Dispose();
		}
	}
}
