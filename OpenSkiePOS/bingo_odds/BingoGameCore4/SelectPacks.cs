using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BingoGameCore4
{
	public partial class SelectPacks : Form
	{
		static List<BingoPack> selected_packs = new List<BingoPack>();

		public static BingoPack[] Show( BingoSessionEvent session_event )
		{
			SelectPacks form = new SelectPacks( session_event );
			form.ShowDialog();
			return selected_packs.ToArray();
		}

		BingoSessionEvent session_event;
		List<BingoPack> selectable_packs;

		public SelectPacks( BingoSessionEvent session_event )
		{
			selectable_packs = new List<BingoPack>();
			this.session_event = session_event;
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			selected_packs.Clear();
			foreach( object item in listBox1.SelectedItems )
			{
				BingoPack pack = item as BingoPack;
				selected_packs.Add( pack );
			}
			Close();
		}

		private void SelectPacks_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = session_event.session.GameList.pack_list;
			listBox1.ClearSelected();
			//listBox1.DataSource = session_event.session.GameList[0].pa
		}
	}
}
