using System.Drawing;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.PackControl
{
	public partial class PackFace : UserControl
	{
		public object PackPrizeLevelId;
		public object PackId;
		public object PrizeLevelId;
		public int Face;
		public Color FaceColor;
        public object FaceColorId;
		public bool Selected = false;
		public bool Enable = true;
		public int nAlpha = 50;
		public delegate void SelectedFace(PackFace ChoosenFace);
		public event SelectedFace OnSelectedFace;

		public PackFace()
		{
			InitializeComponent();			
			
		}

		public PackFace(int x, int y, int width, int height)
		{
			InitializeComponent();			
			Location = new Point( x, y );
			Size = new Size( width, height );
		}


		public void SetPack(object iPackPrizeLevelId, object iPackId, object iPrizeLevelId, int iPackFace, object iFaceColorId, Color iFaceColor)
		{
			PackPrizeLevelId = iPackPrizeLevelId;
			PackId = iPackId;
			PrizeLevelId = iPrizeLevelId;
			Face = iPackFace;
			FaceColor = iFaceColor;
            FaceColorId = iFaceColorId;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, FaceColor.R, FaceColor.G, FaceColor.B);	
		}

		public bool Hitted(int iX, int iY)
		{
			if (iX >= Location.X && iX <= (Location.X + Width)
				&& iY >= Location.Y && iY <= (Location.Y+Height))
				return true;
			return false;
		}

		private void PackControl_MouseDown(object sender, MouseEventArgs e)
		{

			if (e.Button == MouseButtons.Right)
			{
				
			}
			else
			{
				if (Enable)
				{
					Selected = !Selected;
					if (Selected)
					{
						this.OnSelectedFace(this);
						nAlpha = 255;
					}
					else
					{
						this.OnSelectedFace(null);
						nAlpha = 50;
					}
				}
				else
				{
					Selected = false;
					nAlpha = 50;;										
				}
			}

			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, FaceColor.R, FaceColor.G, FaceColor.B);
		}

		public void SetSelected(bool p_select)
		{
			Selected = p_select;
			nAlpha = p_select? 255: 50;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, FaceColor.R, FaceColor.G, FaceColor.B);
		}

		public void SetFaceLevel(object pPrizeLevelId, object color_id, Color pColor)
		{
			PrizeLevelId = pPrizeLevelId;
			FaceColor = pColor;
            FaceColorId = color_id;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, FaceColor.R, FaceColor.G, FaceColor.B);
		}
		

		public void SetFace(int pFace)
		{
			Face = pFace;
			labelName.Text = pFace.ToString();
		}


	}
}
