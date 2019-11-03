using System;

namespace OpenSkieScheduler3.Controls.Buttons
{
	public class NewPack : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter new pack name");
            if (result.Length > 0)
            {
                ControlList.schedule.packs.NewPack( result );
                //ControlList.data.packs.CommitChanges();
            }
		}
	}
	public class NewSessionType : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			String result = xperdex.classes.QueryNewName.Show( "Enter new session type" );
			if( result.Length > 0 )
			{
				ControlList.schedule.session_types.NewSessionType( result );
				//ControlList.data.packs.CommitChanges();
			}
		}
	}
	public class NewBundle : MyButton
	{
		public NewBundle()
		{
			this.Click += new EventHandler( NewBundle_Click );
		}

		void NewBundle_Click( object sender, EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter new bundle name");
            if (result.Length > 0)
            {
                ControlList.schedule.bundles.NewBundle( result );
                //ControlList.data.bundles.CommitChanges();
            }
		}
	}
	public class NewPrizeLevel : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter New Prize Name");
            if (result.Length > 0)
            {
                ControlList.schedule.prize_level_names.NewPrize( result );
                //ControlList.data.prize_level_names.CommitChanges();
            }
		}
	}

	public class NewCardset : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter new cardset name");
            if (result.Length > 0)
            {
                ControlList.schedule.cardset_info.NewCardset( result );
                //ControlList.data.cardset_info.CommitChanges();

            }
		}
	}
	public class NewCardsetRange : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			String result = xperdex.classes.QueryNewName.Show( "Enter new cardset range name" );
            if (result.Length > 0)
            {
                ControlList.schedule.cardset_ranges.NewCardsetRange( result );
                //ControlList.data.cardset_ranges.CommitChanges();
            }
		}
	}

	
	public class NewSessionGroup : MyButton
	{
		public NewSessionGroup()
		{
			this.Click += new EventHandler( NewSessionGroup_Click );
		}

		void NewSessionGroup_Click( object sender, EventArgs e )
		{
			String result = xperdex.classes.QueryNewName.Show( "Enter new session group name" );
            if (result.Length > 0)
            {
                ControlList.schedule.session_macros.NewSessionGroup( result );
                //ControlList.data.session_macros.CommitChanges();
            }
		}
	}

	public class NewSession : MyButton
	{
		public NewSession()
		{
			this.Click += new EventHandler( NewSession_Click );
		}

		void NewSession_Click( object sender, EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter new session name");
            if (result.Length > 0)
                ControlList.schedule.sessions.NewSession( result );
		}
	}


	public class NewGameGroup : MyButton
	{
		public NewGameGroup()
		{
			this.Click += new EventHandler( NewGameGroup_Click );
		}

		void NewGameGroup_Click( object sender, EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter new game group name");
            if (result.Length > 0)
            {
                ControlList.schedule.pack_groups.NewPackGroup( result );
                //ControlList.data.game_groups.CommitChanges();
            }
		}
	}


	public class NewGame : MyButton
	{
		public NewGame()
		{
			this.Click += new EventHandler( NewGame_Click );
		}

		void NewGame_Click( object sender, EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter new game name");
            if (result.Length > 0)
            {
                //ControlList.schedule.games.NewGame( result );
                //ControlList.data.games.CommitChanges();
            }
		}
	}

}
