using xperdex.gui;

namespace BingoGameCore4.Controls
{
	public class BingoCardGroup: PSI_Control
	{
		public BingoCardGroup()
		{
			this.SuspendLayout();
			this.AutoScroll = true;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Name = "BingoCardGroup";
			this.ResumeLayout( false );
			
		}

		const int default_size = 76;
		const int default_pad = 10;
		const int assumed_scrollbar_size = 20;
		int new_block_x;
		int new_block_y;

		public void Add( BingoCardState card )
		{
			Controls.Add( new BingoCard1( card, new_block_x, new_block_y, default_size, default_size ) );
			new_block_x += default_size + default_pad;
			if( new_block_x > ( Width - ( default_size + assumed_scrollbar_size ) ) )
			{
				new_block_x = 0;
				new_block_y += default_size + default_pad;
			}
		}

		public void Clear()
		{
			Controls.Clear();
			new_block_x = 0;
			new_block_y = 0;
		}

	}
}
