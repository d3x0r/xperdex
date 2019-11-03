using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OpenSkieScheduler.Controls.PackControl
{
	public partial class PackProperties : UserControl
	{
		//GDAL.BingoPOS.PackColors DatatablePackColors = new GDAL.BingoPOS.PackColors();
		
		public PackProperties()
		{
			InitializeComponent();
		}

		private void PackProperties_Load(object sender, EventArgs e)
		{
			//comboBoxPackColors.DataSource = DatatablePackColors;
			//comboBoxPackColors.DisplayMember = GDAL.BingoPOS.PackColors.DisplayMemberName;
			//comboBoxPackColors.ValueMember = GDAL.BingoPOS.PackColors.ValueMemberName;

		}

		private void comboBoxPackColors_SelectedValueChanged(object sender, EventArgs e)
		{
			if (comboBoxPackColors.SelectedValue != null && comboBoxPackColors.SelectedValue.ToString() != "System.Data.DataRowView")
			{
				//Color Acolor = new Color();
				//string ColorAlg = LocalTables.DatatablePackColors.GetConditionedDisplayValue("color_info_id","color",comboBoxPackColors.SelectedValue.ToString());
				//int ColorAlgInt = Convert.ToInt32(ColorAlg.Remove(9));
				////string ColorAlgName = DatatablePackColors.GetConditionedDisplayValue("color_info_id", "name", comboBoxPackColors.SelectedValue.ToString());
				//Color Acolor = Color.FromName(ColorAlgName);
				//panelCheckColor.BackColor = Acolor;
			}
		}

		private void SetName(string pPackName)
		{
			textBoxPackName.Text = pPackName;
		}
	}
}
