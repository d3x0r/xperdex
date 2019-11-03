using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateCards
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		byte[] DataFormat( byte[, ,] card )
		{
			byte[] result = new byte[12 * card.GetLength( 0 )];
			int n = 0;
			int r, c;
			int face = 0;
			int b = 0;
			bool side = false;
			for( c = 0; c < 5; c++ )
				for( r = 0; r < 5; r++ )
				{
					if( r == 2 && c == 2 )
						continue;
					if( side )
					{
						result[n] |= (byte)(card[face, r, c] - (c * 15) - 1);
						side = false;
						n++;
					}
					else
					{
						result[n] |= (byte)( ( card[face, r, c] - ( c * 15 ) - 1 ) << 4 );
						side = true;
					}
				}
			return result;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			FileStream fs = new FileStream( textBoxFile.Text, FileMode.CreateNew ); 
			int card_count = Convert.ToInt32( textBoxCards.Text );
			BingoGameCore3.CardMaster.CardFactory cards = new BingoGameCore3.CardMaster.CardFactory( 75 );
			int n;
			for( n = 0; n < card_count; n++ )
			{
				byte[, ,] face = cards.Create( null, 1, 0, 1, false );

				byte[] output = DataFormat( face );
				fs.Write( output, 0, 12 );
			}
			fs.Close();

		}
	}
}
