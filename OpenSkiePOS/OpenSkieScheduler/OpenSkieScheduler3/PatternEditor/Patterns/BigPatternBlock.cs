using System.ComponentModel;
using System.Windows.Forms;

namespace BingoGameCore4.Controls.Patterns
{
	public partial class BigPatternBlock : Form
	{
		// ref int bits.... keep the ref so back update?
		internal int bits;
		public BigPatternBlock( int bits )
		{
			this.bits = bits;
			InitializeComponent();
			patternBlock1.bits = bits;
		}
		protected override void OnClosing( CancelEventArgs e )
		{
			bits = patternBlock1.bits;			
			base.OnClosing( e );
		}
	}
}