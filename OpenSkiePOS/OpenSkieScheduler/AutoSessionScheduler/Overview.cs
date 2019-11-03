using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Data.Odbc;
using System.Data.Common;

namespace AutoSessionScheduler
{
	public partial class Overview : Form
	{
		public Overview()
		{
			InitializeComponent();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			MonthBrowse mb = new MonthBrowse();
			mb.ShowDialog();
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
			si.Dispose();
		}

		private void button5_Click( object sender, EventArgs e )
		{
			bool first = true;
			DbDataReader check_past = StaticDsnConnection.KindExecuteReader( "select ID from session_day_sessions where bingoday > cast(now() as date)" );
			if( ( check_past != null ) && check_past.HasRows )
			{
				Console.WriteLine( "Sessions scheduled after today, not deleting todays sessions - the computer clock may have been set backwards.\n" );
			}
			else
				StaticDsnConnection.KindExecuteNonQuery( "delete from session_day_sessions where bingoday=cast(now() as date)" );

			StaticDsnConnection.KindExecuteNonQuery( "update session_day_sessions set open_for_sales_flag=0" );

			DbDataReader reader = StaticDsnConnection.KindExecuteReader(
				"select session_name,elec_sch_session_macro_session.session_number,bingoday from elec_sch_session_macro_info"
				+ " join elec_sch_session_macro_session on elec_sch_session_macro_session.session_macro_info_id=elec_sch_session_macro_info.session_macro_info_id"
				+ " join elec_sch_session_info on elec_sch_session_info.session_info_id=elec_sch_session_macro_session.session_info_id"
				+ " join session_sales_pages on session_sales_pages.session_number=elec_sch_session_macro_session.session_number"
				+ " join session_sales_session_sales_pages using(session_sales_pages_id)"
				+ " join session_sales_schedule using(session_sales_info_id)"
				+ " where month(month)=month(now()) and bingoday=cast(now() as date)"
				+ " order by elec_sch_session_macro_session.session_number"
			);
			if( reader != null )
				while( reader.Read() )
				{
					string session_name;
					int session_number;
					DateTime session_date;
					session_name = reader.GetString( 0 );
					session_number = reader.GetInt32( 1 );
					session_date = reader.GetDateTime( 2 );
					long mysql_session_date = ( session_date.Year * 10000 + session_date.Month * 100 + session_date.Day );
					DbDataReader check_exist = StaticDsnConnection.KindExecuteReader( "select ID from session_day_sessions where bingoday='" + mysql_session_date + "' and `session number`=" + session_number );
					long ID = 0;
					if( check_exist != null && check_exist.HasRows )
					{
						check_exist.Read();
						ID = check_exist.GetInt32( 0 );
						Console.WriteLine( "Updating session " + ID + " to " + session_name + "[" + session_number + "] on " + mysql_session_date + "\n" );
						if( !StaticDsnConnection.KindExecuteNonQuery( "replace into session_day_sessions (ID,session_id,`session number`,bingoday,`session name`,open_for_sales_flag,acurals_flag) values ("
							+ ID + "," + session_number + "," + session_number + ",'" + mysql_session_date + "','" + session_name + "',1,1)"
							) )
						{
							Console.WriteLine( "Failed to UPDATE session in session_day_sessions\nfor " + mysql_session_date + "(" + session_name + ") number " + session_number + "\n" );
						}
					}
					else
					{
						Console.WriteLine( "Creating session " + session_name + "[" + session_number + "] on " + mysql_session_date + "\n" );
						ID = StaticDsnConnection.KindExecuteInsert( "insert into session_day_sessions (session_id,`session number`,bingoday,`session name`,open_for_sales_flag,acurals_flag) values ("
							+ session_number + "," + session_number + ",'" + mysql_session_date + "','" + session_name + "',1,1)" );
						if( ID == -1 )
						{
							Console.WriteLine( "Failed to INSERT session in session_day_sessions\nfor " + mysql_session_date + "(" + session_name + ") number " + session_number + "\n" );
						}

					}
					if( first )
					{
						StaticDsnConnection.KindExecuteNonQuery( "update operational_configuration set current_session_id='" + session_number + ",current_bingoday="
							+ mysql_session_date + "',current_session_day_sessions_id=" + ID + " where ID=0" );
						//StaticDsnConnection.KindExecuteNonQuery( "update 
						first = false;
					}
				}
		}

	}
}