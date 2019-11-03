using xperdex.gui;

namespace BingoGameCore4.Controls
{
	public class BingoPackGroup: PSI_Control
	{
		public BingoPackGroup()
		{
			this.SuspendLayout();
			this.AutoScroll = true;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Name = "BingoCardGroup";
			this.ResumeLayout( false );
			
		}

		const int default_size = 76;
		const int default_pad = 12;
		const int default_internal_pad = 6;
		const int assumed_scrollbar_size = 20;
		int new_block_x;
		int new_block_y;

		public void Add( PlayerPack pack, int game_id )
		{
			Controls.Add( new BingoPack1( pack, game_id
				, new_block_x, new_block_y
				, default_internal_pad
				, default_size * pack.pack_info.cols + default_internal_pad * ( pack.pack_info.cols - 1 )
				, default_size * pack.pack_info.rows + default_internal_pad * ( pack.pack_info.rows - 1 ) ) );

			new_block_x += default_size * pack.pack_info.cols + default_pad + default_internal_pad * ( pack.pack_info.cols - 1 ); 
			if( new_block_x > ( Width - ( default_size + assumed_scrollbar_size ) ) )
			{
				new_block_x = 0;
				new_block_y += default_size * pack.pack_info.rows + default_pad + default_internal_pad * ( pack.pack_info.rows - 1 );
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
