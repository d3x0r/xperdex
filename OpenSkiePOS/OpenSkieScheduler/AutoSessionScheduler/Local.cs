using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AutoSessionScheduler
{
	public static class Local
	{
		static public SessionSalesInfo session_info;

		static public ImageList imageList1;
		static public ImageList imageList_small;

		static public DataRow current_session; // selection from list.
		static public DataRow add_to_session; // selection from list.
		static public SessionSchedule session_schedule;
		static public List<ListViewItem> image_items;
		/// deleted a session, may have to update the monthview
		static public bool sessions_changed;  //test
		/// modified an image...
		static public bool session_image_changed; 
		static Local()
		{
			session_schedule = new SessionSchedule();
			session_info = new SessionSalesInfo();

			image_items = new List<ListViewItem>();

			imageList1 = new System.Windows.Forms.ImageList();
			imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			imageList1.ImageSize = new Size( 80, 120 );
			imageList1.TransparentColor = System.Drawing.Color.Transparent;

			imageList_small = new ImageList();
			imageList_small.ColorDepth = ColorDepth.Depth32Bit;
			imageList_small.ImageSize = new Size( 75, 90 );
			imageList_small.TransparentColor = Color.Transparent;

			foreach( DataRow row in Local.session_info.images.Rows )
			{
				MemoryStream s = new MemoryStream( (byte[])row["FileData"] );
				try
				{
					Bitmap bm;
					Local.imageList1.Images.Add( (string)row[1], bm = new Bitmap( (Stream)s ) );
					Local.imageList_small.Images.Add( (string)row[1], bm );
					ListViewItem lvi = new ListViewItem( (string)row[1], Local.imageList1.Images.Count - 1 );
					image_items.Add( lvi );
					s.Dispose();
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
			}

		}
	}
}
