using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Drawing;
using System.Windows.Forms;

namespace xperdex.picture_scroller
{
	public class Scroller : IReflectorPlugin, IReflectorPersistance
	{
		public override string ToString()
		{
			return "Image Scroller";
		}
		internal class SomeImage
		{
			internal String filename;
			String filepath;
			internal String file
			{
				set
				{
					filepath = value;
					int ext = filepath.LastIndexOf( '.');
					int f = filepath.LastIndexOfAny( new char[] { '/', '\\' } );
					filename = value.Substring( f+1, ext - (f+1) );
					image = Image.FromFile( filepath );
				}
				get
				{
					return filepath;
				}
			}
			internal SomeImage( String filename )
			{
				file = filename;
				image = Image.FromFile( filepath );
				display_time = new DateTime( 10 * 1000 * 1000 * 10 );
			}
			internal SomeImage( )
			{
			}

			internal DateTime display_time;
			internal Image image;
			public override string ToString()
			{
				return filename;
			}
		}

		static internal List<SomeImage> images = new List<SomeImage>();

		public class ImageSurface : PSI_Control
		{
			public override string ToString()
			{
				return "Scrolling Image";
			}
			Timer t;
			int current;
			Scroller scroller;

			void ScheduleTimer()
			{
				if( t == null )
				{
					t = new Timer();
					t.Tick += new EventHandler( t_Tick );
				}
				if( current < Scroller.images.Count )
				{

					t.Interval = (int)Scroller.images[current].display_time.Ticks / ( 10 * 1000 );
					t.Start();

				}
				else
				{
					t.Interval = 1000; // wait a second... check again (might have had added images...)
				}

			}

			void t_Tick( object sender, EventArgs e )
			{
				t.Stop();
				current++;
				if( current >= Scroller.images.Count )
					current = 0;
				Refresh();
				ScheduleTimer();
			}

			public ImageSurface()
			{
				current = 0;
				ScheduleTimer();
				Paint += new PaintEventHandler( ImageSurface_Paint );
			}

			void ImageSurface_Paint( object sender, PaintEventArgs e )
			{
				if( current < Scroller.images.Count )
					e.Graphics.DrawImage( Scroller.images[current].image, this.DisplayRectangle  );
			}
		}


		#region IReflectorPersistance Members

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "PictureScroller" )
			{
				bool everokay = false;
				bool okay;
				String filename = null;
				// default time.
				DateTime display_time = new DateTime( 10 * 1000 * 1000 * 10 );
				for( okay = r.MoveToFirstChild(); okay; okay = r.MoveToNext() )
				{
					everokay = true;
					if( r.Name == "Image" )
					{
						bool everokay2 = false;
						bool okay2;
						for( okay2 = r.MoveToFirstAttribute(); okay2; okay2 = r.MoveToNextAttribute() )
						{
							everokay2 = true;
							if( r.Name == "image" )
								filename = r.Value;
							if( r.Name == "display_time" )
							{
								try
								{
									display_time = new DateTime( r.ValueAsLong );
								}
								catch
								{
								}
							}
						}
						if( everokay2 )
						{
							r.MoveToParent();
							SomeImage i;

							images.Add( i = new SomeImage() );
							i.display_time = display_time;
							i.file = filename;
						}
					}
				}
				if( everokay )
					r.MoveToParent();
				return true;
			}
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "PictureScroller" );
			foreach( SomeImage image in images )
			{
				w.WriteStartElement( "Image" );

				w.WriteAttributeString( "image", image.file );
				w.WriteAttributeString( "display_time", image.display_time.Ticks.ToString() );
				w.WriteEndElement();
			}
			w.WriteEndElement();

		}

		public void Properties()
		{
			ConfigureScroller cs = new ConfigureScroller( this );
			cs.ShowDialog();
		}

		#endregion

		#region IReflectorPlugin Members

		public void Preload()
		{
			//throw new Exception("The method or operation is not implemented.");
		}

		public void FinishInit()
		{
			//throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}
