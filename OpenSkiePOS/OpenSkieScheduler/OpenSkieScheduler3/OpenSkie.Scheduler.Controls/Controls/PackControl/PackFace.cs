using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OpenSkieScheduler.Controls.PackControl
{
	public partial class PackFace : UserControl
	{
		public int PackPrizeLevelId;
		public int PackId;
		public int PrizeLevelId;
		public int Face;
		public Color FaceColor;
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


		public void SetPack(int iPackPrizeLevelId, int iPackId, int iPrizeLevelId, int iPackFace, Color iFaceColor)
		{
			PackPrizeLevelId = iPackPrizeLevelId;
			PackId = iPackId;
			PrizeLevelId = iPrizeLevelId;
			Face = iPackFace;
			FaceColor = iFaceColor;
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

		public void SetFaceLevel(int pPrizeLevelId, Color pColor)
		{
			PrizeLevelId = pPrizeLevelId;
			FaceColor = pColor;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, FaceColor.R, FaceColor.G, FaceColor.B);
		}
		

		public void SetFace(int pFace)
		{
			Face = pFace;
			labelName.Text = pFace.ToString();
		}


	}
}
