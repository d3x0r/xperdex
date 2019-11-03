using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FutBlowerTest
{
	public partial class Form1 : Form
	{
		BingoGameCore3.BallData.BallDataBlower ball_interface;
		BingoGameCore3.Networking.FNetBlower blower;

		public Form1()
		{
			InitializeComponent();
			blower = new BingoGameCore3.Networking.FNetBlower();
			blower.Start();
			blower.BallDrawn += new BingoGameCore3.Networking.FNetBlower.OnBallDraw( blower_BallDrawn );
		}


		delegate void SetTextCallback( string text );

		void UpdateStatus( string textToWrite )
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if( listBoxStatus.InvokeRequired )
			{

				SetTextCallback d = new SetTextCallback( UpdateStatus );
				listBoxStatus.Parent.Invoke( d, new object[] { textToWrite } );
			}
			else
			{
				ListBox lb = listBoxStatus as ListBox;
				lb.Items.Insert( 0, textToWrite );
				//listBoxStatus.Text = textToWrite;
				listBoxStatus.Refresh();
			}
		}


		void blower_BallDrawn()
		{
			UpdateStatus( blower.CallBall().ToString() );
			//throw new Exception( "The method or operation is not implemented." );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			blower.DrawBall();
			
		}

		private void button2_Click( object sender, EventArgs e )
		{
			blower.DropBalls();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			blower.SetBlower( false );
		}
	}
}