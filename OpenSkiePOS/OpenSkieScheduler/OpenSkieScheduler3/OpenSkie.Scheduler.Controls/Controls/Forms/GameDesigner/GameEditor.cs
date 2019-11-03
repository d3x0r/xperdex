using System;
using System.Data;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class GameEditor : Form
	{
		BindingSource BindingSourceGame;
		DataRow game;

		public GameEditor(DataRow game)
		{
			this.game = game;
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler( GameEditor_FormClosing );
		}

		void GameEditor_FormClosing( object sender, FormClosingEventArgs e )
		{
			BindingSourceGame.EndEdit();
		}

		private void GameEditor_Load(object sender, EventArgs e)
		{
			BindingSourceGame = new BindingSource();
			BindingSourceGame.DataSource = this.game.Table;
			BindingSourceGame.Position = this.game.Table.Rows.IndexOf(this.game);
			DataRow CurrentBinding = ((DataRowView)BindingSourceGame.Current).Row;
			this.Text = "Game Editor (" + CurrentBinding[OpenSkieScheduler3.GameTable.NameColumn] + ")";

			textBoxGameId.DataBindings.Add(new Binding("Text", BindingSourceGame, "game_id", true));
			//textBoxGamePosition.DataBindings.Add(new Binding("Text", BindingSourceGame, "game_position", true));
			textBoxGameName.DataBindings.Add(new Binding("Text", BindingSourceGame, "game_name", true));
			textBoxGameHallId.DataBindings.Add(new Binding("Text", BindingSourceGame, "hall_id", true));
			textBoxGameCharityId.DataBindings.Add(new Binding("Text", BindingSourceGame, "charity_id", true));
			//checkBoxBonanza.DataBindings.Add(new Binding("Checked", BindingSourceGame, "bonanza", true));
			checkBoxSpecial.DataBindings.Add(new Binding("Checked", BindingSourceGame, "special", true));
			//checkBoxProgressive.DataBindings.Add(new Binding("Checked", BindingSourceGame, "progressive", true));
			checkBoxPoker.DataBindings.Add(new Binding("Checked", BindingSourceGame, "poker", true));
			
		
		}

	}
}