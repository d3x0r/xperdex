using System;
using System.Windows.Forms;
using OpenSkieScheduler3.BingoGameDefs;
using System.Data;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class CardsetEditor : Form
	{
		public CardsetEditor()
		{
			InitializeComponent();
		}

		protected override void OnLoad( EventArgs e )
		{
			this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler( dataGridView1_DataError );
            this.dataGridView1.DataSource = ControlList.schedule.cardset_info;
			base.OnLoad( e );
		}

		void dataGridView1_DataError( object sender, DataGridViewDataErrorEventArgs e )
		{
			if( e.Exception.Message == "Delete was aborted!?" )
				return;
			xperdex.classes.Log.log( "Data Grid Error" );
			//throw new Exception( "The method or operation is not implemented." );
		}
		private void button1_Click( object sender, EventArgs e )
		{
			//ControlList.data.cardset_info.CommitChanges();
			this.Close();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			BingoCardsetCreator.BingoCardset cardset = BingoCardsetCreator.BingoCardset.Create( 100000 );
			DataRow new_cardset = ControlList.schedule.cardset_info.NewRow();
			new_cardset[CardsetInfo.NameColumn] = "Auto Cardset " + DateTime.Now.ToString();
			new_cardset["cards"] = cardset.Count;
			new_cardset["manufacturer_id"] = "Freedom Collective";
			ControlList.schedule.cardset_info.Rows.Add( new_cardset );
			cardset.StoreCards( ControlList.schedule, new_cardset );
			MessageBox.Show( "Cardset stored in database, please commit" );
		}
	}
}