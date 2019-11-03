using System.Drawing;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.PackControl
{
	public partial class PackItem : UserControl
	{
		public int PackNumber;
		public int PackType;
		public int PackId;
		public int SessionPackId;
		public string Price;
		public Color PackColor;
		public bool Selected = false;
		public bool BuyOption = false;
		public int nAlpha = 50;
		public delegate void SelectedPack(PackItem ChoosenPack);
		public event SelectedPack OnSelectedPack;

		public PackItem()
		{
			InitializeComponent();			
			
		}

		public PackItem(int x, int y, int width, int height)
		{
			InitializeComponent();			
			Location = new Point( x, y );
			Size = new Size( width, height );
		}


		public void SetPack(int iSessionPackId, int iPackId, int iPackType, int iPackNumber, Color iPackColor)
		{
			SessionPackId = iSessionPackId;
			PackId = iPackId;
			PackType = iPackType;
			PackNumber = iPackNumber;
			PackColor = iPackColor;
			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, PackColor.R, PackColor.G, PackColor.B);	
		}

		public void CreatePack(int iPackId)
		{
			PackId = iPackId;
			switch (iPackId)
			{
				case 1:
					PackColor = Color.Blue;
					break;
				case 2:
					PackColor = Color.Green;
					break;
				case 3:
					PackColor = Color.Yellow;
					break;
				case 4:
					PackColor = Color.Red;
					break;
				case 5:
					PackColor = Color.Purple;
					break;
				case 6:
					PackColor = Color.Magenta;
					break;
				case 7:
					PackColor = Color.Cyan;
					break;
				case 8:
					PackColor = Color.Cornsilk;
					break;
				case 9:
					PackColor = Color.DarkOrange;
					break;
				case 10:
					PackColor = Color.Pink;
					break;
				case 11:
					PackColor = Color.SteelBlue;
					break;
				case 12:
					PackColor = Color.LightGreen;
					break;
			}

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

			this.BackColor = System.Drawing.Color.FromArgb(nAlpha, PackColor.R, PackColor.G, PackColor.B);
		}


		

		public void SetName(string pName)
		{
			labelName.Text = pName;
		}

		public void SetPrice(string pPrice)
		{
			//Price = new xperdex.classes.Money(pPrice); 
			labelPrice.Text = pPrice;
			
		}

	}
}
