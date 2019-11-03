using System;
using System.Windows.Forms;

namespace BingoGameCore4.Controls.Patterns
{
	public partial class ShowExpandedPattern : Form
	{
		BingoGameCore4.Pattern pattern;
        public ShowExpandedPattern( BingoGameCore4.Pattern p )
		{
			pattern = p;
			InitializeComponent();
		}

		private void ShowExpandedPattern_Load( object sender, EventArgs e )
		{
			pattern.Expand();
			this.currentPatternScroller1.Pattern = pattern;
			this.currentPatternScroller1.Rate = 50;
			this.currentPatternScroller2.Pattern = pattern;
			this.currentPatternScroller2.Rate = 500;
			this.textBoxCount.Text = pattern.composite_masks.Count.ToString();
			this.patternBlockGroup1.pattern_bits = pattern.composite_masks;

		}

		private void button1_Click( object sender, EventArgs e )
		{
			Close();
		}
	}
}