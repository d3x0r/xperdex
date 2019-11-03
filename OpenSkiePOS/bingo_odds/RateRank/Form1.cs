using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BingoGameCore;
using BingoGameCore.Pattern_Editor;

namespace RateRank
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}

		protected override void OnLoad( EventArgs e )
		{
			monthCalendar1.ActiveMonth.Year = DateTime.Now.Year;
			monthCalendar1.ActiveMonth.Month = DateTime.Now.Month;

			monthCalendar1.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler( monthCalendar1_MonthChanged );
			monthCalendar1.DaySelected += new Pabo.Calendar.DaySelectedEventHandler( monthCalendar1_DaySelected );
			//textBox1.Text = "2";
			base.OnLoad( e );
		}

		void monthCalendar1_MonthChanged( object sender, Pabo.Calendar.MonthChangedEventArgs e )
		{
			//Pabo.Calendar.DateItemCollection days =

			//	monthCalendar1.;


		}

		int[] sessions;

		void monthCalendar1_DaySelected( object sender, Pabo.Calendar.DaySelectedEventArgs e )
		{
			Pabo.Calendar.SelectedDatesCollection dates = this.monthCalendar1.SelectedDates;
			sessions = BingoGameList.GetPlayedSessions( dates[0] );
			listBoxSessions.Items.Clear();
			listBoxSessions.Items.Add( "All" );
			foreach( int session in sessions )
				listBoxSessions.Items.Add( session );
			listBoxSessions.SelectedIndex = 0;
			//listBoxSessions.DataSource = sessions;
			//.SelectionMode = SelectionMode.MultiSimple;
			//throw new Exception( "The method or operation is not implemented." );
		}

		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{

		}

		BingoCore bc;
		BingoPlayers bp;
		BingoGameList bgl;
		List<BingoPack> last_packlist;
		bool all_sessions;

		void RunSession()
		{
			List<BingoPack> packlist = new List<BingoPack>();
			last_packlist = packlist;

			ConfigurePacks.PackConfigDB db = new ConfigurePacks.PackConfigDB();
			foreach( DataRow row in db.Rows )
				if( Convert.ToBoolean( row["rate"] ) )
					packlist.Add( BingoPack.GetPack( row["pack_name"].ToString() ) );

			this.Refresh(); // force status update...
			//BingoCore bc = new BingoCore( DateTime.Now, Convert.ToInt32( this.comboBox1.Text ) );
			bc = new BingoCore( packlist, bgl, bp );
			bc.max_rated_packs = xperdex.classes.INI.File( "raterank.ini" )["Config"]["Pack Count To Rate"].Integer;
			bc.max_rated_cards = xperdex.classes.INI.File( "raterank.ini" )["Config"]["Max Cards To Rate","12"].Integer;
			bc.Play( this.listBoxStatus );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.listBoxStatus.Items.Clear();

			this.labelStatus.Text = "Getting selected date...";
			Pabo.Calendar.SelectedDatesCollection dates = this.monthCalendar1.SelectedDates;
			if( dates.Count == 0 )
				return;
			int session = 0;
			all_sessions = false;
			if( String.Compare( listBoxSessions.SelectedItem.ToString(), "All", true ) == 0 )
				all_sessions = true;
			else
				session = Convert.ToInt32( listBoxSessions.SelectedItem.ToString() );

			if( all_sessions )
			{
				session = 1;
			}

			while( session > 0 )
			{
				labelStatus2.Text = "Loading session " + session + " on " + dates[0].Date;
				this.labelStatus.Text = "Loading bingo game list for session...";
				labelStatus.Refresh();
				bgl = new BingoGameList();
				bgl.Load( dates[0], session );

				//PatternEditor pe = new PatternEditor( );
				//pe.ShowDialog();

				this.labelStatus.Text = "Loading players for session...";
				this.listBoxStatus.Items.Add( this.labelStatus.Text );
				labelStatus.Refresh();
				bp = new BingoPlayers( dates[0], session, bgl );

				//BingoCore bc = new BingoCore( DateTime.Now, Convert.ToInt32( this.comboBox1.Text ) );
								/*
				List<BingoPack> packs = BingoPack.GetPackList();
				listBoxPacks.DataSource = packs;

				if( last_packlist != null )
					foreach( BingoPack pack in last_packlist )
					{
						listBoxPacks.SetSelected( packs.IndexOf( pack ), true );
					}
								  */
				this.labelStatus.Text = "Select Packs and go...";
				this.listBoxStatus.Items.Add( this.labelStatus.Text );
				if( all_sessions )
				{
					/*
					if( last_packlist == null )
					{
						SelectPacks sp = new SelectPacks();
						sp.ShowDialog();
						listBoxPacks.ClearSelected();
						foreach( BingoPack pack in sp.listBoxPacks.SelectedItems )
						{
							listBoxPacks.SetSelected( packs.IndexOf( pack ), true );
						}
					}
					*/
					this.Refresh();
					RunSession();
					this.Refresh();
					session++;
					if( session > sessions.Length )
						session = 0;
				}
				else
				{
					RunSession();
					session = 0;
				}
			}
			labelStatus.Text = "Complete...";
			this.listBoxStatus.Items.Add( this.labelStatus.Text );
			labelStatus2.Text = "Complete...";
			//BingoGameCore.BingoCore.Load( dates[0].Date, 1 );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			RunSession();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			ConfigurePoints cp = new ConfigurePoints();
			cp.ShowDialog();
		}

		private void button4_Click( object sender, EventArgs e )
		{
			ConfigurePacks cp = new ConfigurePacks();
			cp.ShowDialog();
		}

	}
}