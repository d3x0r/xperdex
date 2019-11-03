using System.Drawing;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.PackControl
{
	public partial class PackItemGen : UserControl
	{
		public int PackNumber;
		public int PackType;
		public int PackId;
		public int RealPackId;
		public string PackName;
		public string Description;
		public Color PackColor;
		public bool Selected = false;
		public bool BuyOption = false;
		public bool Enable = true;
		public int nAlpha = 50;
		public delegate void SelectedPack(PackItemGen ChoosenPack);
		public event SelectedPack OnSelectedPack;

		public delegate void EditPack(PackItemGen ChoosenPack);
		public event EditPack OnEditPack;

		public delegate void DisablePack(PackItemGen ChoosenPack);
		public event DisablePack OnDisablePack;
		
		public PackItemGen()
		{
			InitializeComponent();			
			
		}

		public PackItemGen(int x, int y, int width, int height)
		{
			InitializeComponent();			
			Location = new Point( x, y );
			Size = new Size( width, height );
		}


		public void SetPack(int iRealPackId, int iPackId, int iPackType, int iPackNumber, Color iPackColor)
		{
			RealPackId = iRealPackId;
			PackId = iPackId;
			PackType = iPackType;
			PackNumber = iPackNumber;
			PackColor = iPackColor;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, PackColor.R, PackColor.G, PackColor.B);	
		}

		public void RotatePiece()
		{

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
				if (this.OnEditPack != null)
				{
					Selected = true;
					this.OnEditPack(this);
					nAlpha = 255;
				}
			}
			else
			{
				if (Enable)
				{
					Selected = !Selected;
					if (Selected || BuyOption)
					{
						this.OnSelectedPack(this);
						nAlpha = 255;
					}
					else
					{
						this.OnSelectedPack(null);
						nAlpha = 50;
					}
				}
				else
				{
					Selected = false;
					nAlpha = 50;
					if (this.OnDisablePack != null)
						this.OnDisablePack(this);										
				}
			}

			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, PackColor.R, PackColor.G, PackColor.B);
		}

		public void SetSelected(bool p_select)
		{
			Selected = p_select;
			nAlpha = p_select? 255: 50;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, PackColor.R, PackColor.G, PackColor.B);
		}

		public void SetPackColor(Color p_color)
		{
			PackColor = p_color;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, PackColor.R, PackColor.G, PackColor.B);
		}
		

		public void SetName(string pName)
		{
			PackName = pName;
			labelName.Text = pName;
		}

		public void SetDescription(string pDescription)
		{
			Description = pDescription;
			labelDescription.Text = Description;
		}

	}
}
