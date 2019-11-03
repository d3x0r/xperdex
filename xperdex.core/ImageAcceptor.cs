using System;
using System.Drawing;
using xperdex.core.interfaces;
using xperdex.gui;
using xperdex.core.common;

namespace xperdex.core
{
	class ImageAcceptor : IReflectorPluginDropFileTarget
	{

		public class ImageControl: PSI_Control, IReflectorPersistance
		{
			#region IReflectorPersistance Members

			public ImageControl()
			{
				BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
						
			}

			String filename;
			internal String FileName
			{
				set
				{
					filename = value;
					try
					{
						Image image = Image.FromFile( filename );
						BackgroundImage = image;
						Refresh();
					}
					catch( Exception )
					{
					}
				
				}
			}

			public new bool Load( System.Xml.XPath.XPathNavigator r )
			{
				bool everokay = false;

				switch( r.Name )
				{
				case "AcceptedImage":
					bool okay;
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						everokay = true;
						switch( r.Name )
						{
						case "location":
							FileName = r.Value;
							break;
						}
					}
					if( everokay )
						r.MoveToParent();
					break;
				}
				return everokay;
			}

			public void Save( System.Xml.XmlWriter w )
			{
					w.WriteStartElement( "AcceptedImage" );
					w.WriteAttributeString( "location", this.filename );
					w.WriteEndElement();
					w.WriteRaw( "\r\n" );
			}

			#endregion
		}

		public override string ToString()
		{
			return "Image Drop Acceptor";
		}				 
		#region IReflectorPlugin Members

		public ImageAcceptor()
		{

		}

		public void Preload()
		{
			// do nothing...
			//throw new Exception( "The method or operation is not implemented." );
		}

		public void FinishInit()
		{
			// do nothing...
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IReflectorDropFileTarget Members


		public bool Drop( object sender, string filename, int X, int Y )
		{
			try
			{
				if( core_common.current_mouse_page == null )
				{
					// not in edit mode?
					return false;
				}
				Image image;
				try
				{
					image = Image.FromFile( filename );
				}
				catch
				{
					return false;
				}
				int image_width_parts = ( image.Size.Width * core_common.current_mouse_page.partsX ) / core_common.current_mouse_page.rect.Width;
				int image_height_parts = ( image.Size.Height * core_common.current_mouse_page.partsY) / core_common.current_mouse_page.rect.Height;
				Rectangle r = new Rectangle(
						 core_common.partX - image_width_parts / 2
						, core_common.partY - image_height_parts / 2
						, image_width_parts
						, image_height_parts );
				// in grid coordinates, please.
				ControlTracker tracker = core_common.current_mouse_page.MakeControl( typeof( ImageControl ), null, r );
				ImageControl ic = tracker.c as ImageControl;
				ic.FileName = filename;
				return true;
			}
			catch( Exception )
			{
			}
			return false;
		}

		#endregion
	}
}
