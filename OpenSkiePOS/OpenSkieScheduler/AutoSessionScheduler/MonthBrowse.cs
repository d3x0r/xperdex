using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pabo.Calendar;
using xperdex.classes;
using System.Data.Odbc;

namespace AutoSessionScheduler
{
	public partial class MonthBrowse : Form
	{
		public class MonthDayInfo
		{
			public DateTime date;
			public int session_sales_info_id; // what session is scheduled on this day...
			public int session_image_index;
			public DataRow dr;
			public string session_sales_name;
		}
		
		public bool IsDate( MonthDayInfo m )
		{
			if( m.date == current_date )
				return true;
			return false;
		}
		

		List<MonthDayInfo> month_schedule;
		public MonthBrowse()
		{
			InitializeComponent();
			monthCalendar1.DayRender += new Pabo.Calendar.DayRenderEventHandler( monthCalendar1_DayRender );
			monthCalendar1.MonthChanged += new MonthChangedEventHandler(monthCalendar1_MonthChanged);
			
			month_schedule = new List<MonthDayInfo>();
			MonthDayInfo date = month_schedule.Find( IsDate );
			monthCalendar1.ImageList = Local.imageList_small;
			SetupCurrentInfo( monthCalendar1 );
			//monthCalendar1.Da
			//DateItem di = new DateItem();
			//di.
			SessionList.DataSource = Local.session_info;
			SessionList.DisplayMember = Local.session_info.Columns[1].ColumnName;
		}

		void SetupCurrentInfo(Pabo.Calendar.MonthCalendar cal)
		{
			//DateTime dt = new DateTime( );
			month_schedule.Clear();
			foreach( DataRow row in Local.session_schedule.Rows )
			{
				object o = row[2];
				if( o.GetType() != typeof( DateTime ) )
					continue;
					DateTime dt = (DateTime)o;
				MonthDayInfo mdi = new MonthDayInfo();
				mdi.date = (DateTime)row[2];
				mdi.session_sales_info_id = (int)row[3];
				mdi.dr = row;
				DataRow[] session_sales_images = Local.session_info.images.Select( "session_sales_info_id=" + mdi.session_sales_info_id );
				if( session_sales_images.Length > 0 )
					mdi.session_image_index = Local.imageList1.Images.IndexOfKey( (string)session_sales_images[0][1] ); // lookup name to get image index...
				else
					mdi.session_image_index = -1;
				session_sales_images = Local.session_info.Select( "session_sales_info_id=" + mdi.session_sales_info_id );
				mdi.session_sales_name = (string)session_sales_images[0][1];
				month_schedule.Add( mdi );
			}
		}

		void monthCalendar1_MonthChanged( object sender, MonthChangedEventArgs e )
		{
			Pabo.Calendar. MonthCalendar cal = (Pabo.Calendar.MonthCalendar)sender;
			SetupCurrentInfo(cal);
		}

		void monthCalendar1_DayRender( object sender, Pabo.Calendar.DayRenderEventArgs e )
		{
			Pabo.Calendar.MonthCalendar cal = (Pabo.Calendar.MonthCalendar)sender;
			//GetDateInfo();
			//e.OwnerDraw = true;
			e.Graphics.DrawString( "session 1", cal.Font, new SolidBrush( Color.Black ), new Point( 10, 10 ) );
			e.Graphics.DrawString( "session 1", cal.Font, new SolidBrush( Color.Black ), new Point( 10, 20 ) );
			
			//throw new Exception( "The method or operation is not implemented." );
		}

		DataRow current_session_image;
		int current_image_index;
		DataRow current_session_sales;
		int current_session_sales_index;  // id of the session on this day.
		string current_session_name;
		DateTime current_date;
		

		private void SessionList_SelectedValueChanged( object sender, EventArgs e )
		{
			DataRowView item = (DataRowView)this.SessionList.SelectedItem;
			if( item == null )
				return;
			DataRow[] rows = Local.session_info.images.Select( item.Row.Table.Columns[0].ColumnName + " = " + item.Row[0] );
			if( rows.Length > 0 )
			{
				//current_session_sales = rows[0];
				current_session_sales_index = (int)rows[0]["session_sales_info_id"];
				current_session_name = (string)item.Row[1];
				current_session_image = rows[0];
				current_image_index = Local.imageList1.Images.IndexOfKey( (string)current_session_image[1] );
			}
			else
			{
				current_session_sales_index = (int)item.Row[0];
				current_session_name = (string)item.Row[1];
				current_session_image = null;
				current_image_index = -1;
			}
		}

		private void monthCalendar1_DaySelected( object sender, DaySelectedEventArgs e )
		{
			// don't edit unless edit is enabled.
			if( !EditEnable.Checked )
				return;
			Pabo.Calendar.MonthCalendar month = (Pabo.Calendar.MonthCalendar)sender;
			SelectedDatesCollection m_dates = month.SelectedDates;
			//current_date = Convert.ToDateTime( e.Days[0] );
			for( int n = 0; n < m_dates.Count; n++ )
			{
				DateTime dt = m_dates[n];
				current_date = dt;
				int index = month_schedule.FindIndex( IsDate );
				MonthDayInfo day ;
				if( index < 0 )
				{
					day = new MonthDayInfo();

					day.dr = Local.session_schedule.NewRow();
					
					//day.dr[1] = current_session_sales[1];
					day.dr["bingoday"] = current_date;
					Local.session_schedule.Rows.Add( day.dr );

					day.date = current_date;
					month_schedule.Add( day );
					

				}
				else
				{
					day = month_schedule[index];
				}
				day.session_sales_info_id = current_session_sales_index;
				day.session_image_index = current_image_index;
				day.session_sales_name = current_session_name;
				day.dr["session_sales_info_id"] = current_session_sales_index;
				
			}


			DateItem[] di = month.Dates.DateInfo( Convert.ToDateTime( e.Days[0] ) );
			//Console.WriteLine( e.Days );
			//SelectedDatesCollection m_dates = month.SelectedDates; 
		}

		private void monthCalendar1_DayQueryInfo( object sender,
							DayQueryInfoEventArgs e )
		{
			// Check date
			//if( e.Date.DayOfWeek == DayOfWeek.Thursday )
			{
				// Add custom formatting
				e.Info.BackColor1 = Color.Yellow;
				e.Info.BackColor2 = Color.GhostWhite;
				current_date = e.Date;
				int index = month_schedule.FindIndex( IsDate );
				e.Info.ImageListIndex = 1;
				e.Info.GradientMode = mcGradientMode.Horizontal;

				current_date = e.Date;
				int day = month_schedule.FindIndex(IsDate);
				e.Info.ImageListIndex = month_schedule[day].session_image_index;
				// Set ownerdraw = true to add custom formatting
				e.OwnerDraw = true;
			}
		}

		private void monthCalendar1_DayQueryInfo_1( object sender, DayQueryInfoEventArgs e )
		{
			Pabo.Calendar.MonthCalendar month = (Pabo.Calendar.MonthCalendar)sender;
			//if( e.Date == current_date )
			{
				current_date = e.Date;
				int day = month_schedule.FindIndex( IsDate );
				if( day >= 0 )
				{
					if( month_schedule[day].session_image_index >= 0 )
						e.Info.ImageListIndex = month_schedule[day].session_image_index;
					e.Info.Text = month_schedule[day].session_sales_name;
				}
				e.OwnerDraw = true;
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			SessionSalesDefine sd = new SessionSalesDefine();
			sd.ShowDialog();

		}

		private void button4_MouseClick( object sender, EventArgs e )
		{
			SessionImages si = new SessionImages();
			si.Whatever();
			si.ShowDialog();
			if( si.DialogResult == DialogResult.OK )
			{
				if( Local.session_image_changed )
				{
					SetupCurrentInfo( monthCalendar1 );
					monthCalendar1.Refresh();
				}
			}
			si.Dispose();
		}

	}
}