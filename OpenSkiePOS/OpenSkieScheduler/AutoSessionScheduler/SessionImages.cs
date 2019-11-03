using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using xperdex.classes;

namespace AutoSessionScheduler
{
	public partial class SessionImages : Form
	{
		public SessionImages(  )
		{
			InitializeComponent();
			DataTable dt = Local.session_info;
			//imageList1.Images.Add( new Bitmap( "Resources/2ndPayDayTriple.png" ) );
			//imageList.Items.Add( "asdf", 1 );
			//imageList.im
		}
		public void Whatever()
		{
			imageList.LargeImageList = Local.imageList1;
			imageList.Items.AddRange( Local.image_items.ToArray() );
			for( int n = 0; n < imageList.Items.Count; n++ )
			{
				imageList.Items[n].Name = imageList.Items[n].Text;
			}
			SessionList.DataSource = Local.session_info;
			SessionList.DisplayMember = MySQLDataTable.Name( Local.session_info );
		}
		~SessionImages()
		{
			imageList.Items.Clear();
		}
		private void AddImageButton_Click( object sender, EventArgs e )
		{
			Stream myStream;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = ".";
			openFileDialog1.Filter = "image files (*.png;*.bmp;*.ico;*.gif;*.jpg)|*.png;*.bmp;*.ico;*.gif;*.jpg|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				try
				{
					Bitmap image = new Bitmap( openFileDialog1.FileName );
					String s = openFileDialog1.FileName;
					int x = s.LastIndexOf( '.' );
					int w = s.LastIndexOf( '\\' );
					if( w < 0 )
						w = s.LastIndexOf( '/' );
					if( w <= 0 )
						w = 0;
					else
						w++; // skip the / or \
					string result2 = QueryNewName.Show( "Enter Image Name", s.Substring( w, x - w) );
					if( result2.Length > 0 )
					{
						Stream stream = openFileDialog1.OpenFile();
						DataRow row = Local.session_info.images.NewRow();
						row[1] = result2;
						byte[] buffer = new byte[stream.Length];
						stream.Read( buffer, 0, (int)stream.Length );
						row[2] = s;
						row[3] = buffer;
						Local.session_info.images.Rows.Add( row );
						Local.session_info.images.AcceptChanges();

						// add the image to the image list...
						Local.imageList1.Images.Add( image );
						// add the text and image index tot he view
						imageList.Items.Add( result2, Local.imageList1.Images.Count - 1 );
					}
					else
						image.Dispose();
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
				
			}

		}

		bool updating_session;

		private void imageList_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
		{
			if( updating_session ) // while doing updates, don't do anything.
				return; 
			if( e.Item.Selected )
			{
				DataRow[] rows = Local.session_info.images.Select( Local.session_info.images.Columns[1].ColumnName + "='" + e.Item.Text + "'" );
				if( rows.Length > 1 )
				{
					for( int n = 1; n < rows.Length; n++ )
						rows[n].Delete();
					//row new Exception( "Multiple Images of the same name..." );
				}
				//se
				{
					Local.session_image_changed = true;
					rows[0][Local.session_info.Columns[0].ColumnName] = Local.current_session[0];
				}
			}
			else
			{
				DataRow[] rows = Local.session_info.images.Select( Local.session_info.images.Columns["session_sales_info_id"] + "=" + Local.current_session[0] + "" );
				foreach( DataRow row in rows )
				{
					row[Local.session_info.Columns[0].ColumnName] = 0;
				}

			}
		}

		private void SessionList_SelectedValueChanged( object sender, EventArgs e )
		{
			if( SessionList.SelectedValue != null )
			{
				Local.current_session = ( (DataRowView)SessionList.SelectedValue ).Row;
				if( imageList.Items.Count > 0 )
				{
					DataRow[] rows = Local.session_info.images.Select( Local.session_info.Columns[0].ColumnName + "=" + Local.current_session[0] );
					updating_session = true;
					for( int n = 0; n < imageList.Items.Count; n++ )
					{
						imageList.Items[n].Selected = false;
					}

					foreach( DataRow row in rows )
					{
						try
						{
							String s = (string)row[1];//MySQLDataTable.Name( Local.session_info.images );

							ListViewItem lvi = imageList.Items[s];
							lvi.Selected = true;
							imageList.Select();
						}
						catch( Exception e2 )
						{
						}
						//imageList.SelectedItems = items;
					}
					updating_session = false;

				}
			}
		}

		private void ClearImageButton_Click( object sender, EventArgs e )
		{
			DataRow[] rows = Local.session_info.images.Select( Local.session_info.Columns[0].ColumnName + "=" + Local.current_session[0] );
			foreach( DataRow row in rows )
			{
				try
				{
					String s = (string)row[1];//MySQLDataTable.Name( Local.session_info.images );
					ListViewItem lvi = imageList.Items[s];
					lvi.Selected = false;
					Local.session_image_changed = true;
				}
				catch( Exception e2 )
				{
				}
				//imageList.SelectedItems = items;
			}

		}

		private void button1_Click( object sender, EventArgs e )
		{
			MessageBox.Show( "Delete Image not Implemented." );
		}
	}
}