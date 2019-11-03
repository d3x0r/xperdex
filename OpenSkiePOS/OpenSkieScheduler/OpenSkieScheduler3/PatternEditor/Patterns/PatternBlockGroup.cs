using System.Collections.Generic;
using System.Collections.Specialized;
using xperdex.gui;

namespace BingoGameCore4.Controls.Patterns
{
	class PatternBlockGroup: PSI_Control
	{

		Pattern _pattern;
		public Pattern pattern
		{
			set
			{
				this.Controls.Clear();
				_pattern = value;
				new_block_x = 0;
				new_block_y = 0;

				if( value != null && ( value.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroups
					|| value.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsNoOver
					|| value.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrime
					|| value.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver ) )
					group_separator = (int)value.mode_mod;
				else
					group_separator = 0;
				Refresh();

				if( value != null )
				{
					foreach( BitVector32 val in _pattern.masks )
					{
						AddBlock( val );
					}
				}
			}
			get
			{
				return _pattern;
			}
		}

		public List<int> pattern_bits
		{
			set
			{
				int max = 500;
				this.Controls.Clear();
				foreach( int val in value )
				{
					if( max > 0 )
						max--;
					if( max == 0 )
						break;
					AddBlock( val );
				}
			}
		}

		List<List<int>> pattern_index;

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// PatternBlockGroup
			// 
			this.AutoScroll = true;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Name = "PatternBlockGroup";
			this.Size = new System.Drawing.Size( 363, 322 );
			this.ResumeLayout( false );
			this.Paint += new System.Windows.Forms.PaintEventHandler( PatternBlockGroup_Paint );
		}

		void PatternBlockGroup_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
		{
			if( group_separator > 0 )
			{
				int cells_wide = Width / (default_size+default_pad);
				int ypos1 = ( default_size + default_pad ) * ( 1 + group_separator / cells_wide ) - ( default_pad / 2 );
				int ypos2 = ( default_size + default_pad ) * ( group_separator / cells_wide ) - ( default_pad / 2 );
				ypos1 += this.AutoScrollPosition.Y;
				ypos2 += this.AutoScrollPosition.Y;
				if( ( group_separator % cells_wide ) == 0 )
				{
					e.Graphics.DrawLine( System.Drawing.Pens.Red
						,0
						, ypos2
						, Width
						, ypos2
						);

				}
				else
				{
					int linepos = ( default_size + default_pad ) * ( group_separator % cells_wide ) - (default_pad/2);
					e.Graphics.DrawLine( System.Drawing.Pens.Red
						, 0
						, ypos1
						, linepos
						, ypos1
						);
					e.Graphics.DrawLine( System.Drawing.Pens.Red
						, linepos
						, ypos2
						, linepos
						, ypos1
						);
					e.Graphics.DrawLine( System.Drawing.Pens.Red
						, linepos
						, ypos2
						, Width
						, ypos2
						);
				}
			}
		}


		const int default_size = 76;
		const int default_pad = 10;
		const int assumed_scrollbar_size = 20;
		int new_block_x;
		int new_block_y;
		int group_separator;

		public int GroupSeparator
		{
			set
			{
				if( pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroups
					|| pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrime
					|| pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsNoOver
					|| pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver )
				{
					pattern.mode_mod = (Pattern.mode_modifications)value;
					group_separator = value;
					Refresh();
				}
			}
			get
			{
				if( pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroups
					|| pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrime
					|| pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsNoOver
					|| pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver )
				{
					return (int)pattern.mode_mod;
				}
				return 0;
			}
		}

		public void AddBlock()
		{
			int offset = this.VerticalScroll.Value;
			Controls.Add( new PatternBlock( new_block_x, new_block_y - offset, default_size, default_size ) );
			new_block_x += default_size + default_pad;
			if( new_block_x > ( Width - ( default_size + assumed_scrollbar_size ) ) )
			{
				new_block_x = 0;
				new_block_y += default_size + default_pad;
			}
		}

		public void AddBlock( BitVector32 val )
		{
			Controls.Add( new PatternBlock( val, new_block_x, new_block_y, default_size, default_size ) );
			new_block_x += default_size + default_pad;
			if( new_block_x > ( Width - ( default_size + assumed_scrollbar_size ) ) )
			{
				new_block_x = 0;
				new_block_y += default_size + default_pad;
			}
		}

		public void AddBlock( int val )
		{
			Controls.Add( new PatternBlock( val, new_block_x, new_block_y, default_size, default_size ) );
			new_block_x += default_size + default_pad;
			if( new_block_x > ( Width - ( default_size + assumed_scrollbar_size ) ) )
			{
				new_block_x = 0;
				new_block_y += default_size + default_pad;
			}
		}

		public bool ReadPattern()
		{
			bool changed = false;
			int n = 0;
			_pattern.changed = true;
			foreach( PatternBlock block in Controls )
			{
				if( block.bits != 0 )
				{
					if( n >= _pattern.masks.Count )
					{
						changed = true;
						_pattern.masks.Add( new BitVector32( block.bits ) );
					}
					else
					{
						if( block.bits != _pattern.masks[n].Data )
						{
							changed = true;
							_pattern.masks[n] = new BitVector32( block.bits );
						}
					}
				}
				else
				{
					
					// 0 blocks are not saved... and they are deleted...
					if( n < _pattern.masks.Count )
					{
						changed = true;
						_pattern.masks.RemoveAt( n );
					}
					// skip to next... don't count... 
					// this is not an addition.
					continue;
				}	
				n++;
			}
			return changed;
		}


		public PatternBlockGroup()
		{
			pattern_index = new List<List<int>>();

			InitializeComponent();
			int n;
			for( n = 0; n < 100; n++ )
				AddBlock();
		}

	}
}
