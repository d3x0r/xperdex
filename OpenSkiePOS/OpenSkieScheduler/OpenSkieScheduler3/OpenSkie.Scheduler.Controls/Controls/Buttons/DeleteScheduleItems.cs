using System;

namespace OpenSkieScheduler3.Controls.Buttons
{
	public class DeletePack : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
                ControlList.data.current_pack.Delete();
			}
		}
	}
	public class DeleteSessionType : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
				ControlList.data.current_session_type.Delete();
			}
		}
	}
	public class DeleteBundle : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
                ControlList.data.current_bundle.Delete();
                //ControlList.schedule.bundles.DeleteBundle();
				//ControlList.data.bundles.CommitChanges();
			}
		}
	}

	public class DeleteCardset : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
                ControlList.data.current_cardset_info.Delete();
                //ControlList.schedule.cardset_info.DeleteCardset();
				//ControlList.data.cardset_info.CommitChanges();
			}
		}
	}

	public class DeleteCardsetRange : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
                ControlList.data.current_cardset_range.Delete();
                //ControlList.schedule.cardset_ranges.DeleteCardsetRange();
				//ControlList.data.cardset_ranges.CommitChanges();
			}
		}
	}

	
	public class DeleteSessionGroup : MyButton
	{
		protected override void  OnClick(EventArgs e)
		{
			if( allow_edit )
			{
				try
				{
					ControlList.data.current_session_macro.Delete();
				}
				catch 
				{ 
				}
			}
		}
	}

	public class DeleteSession : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
				try
				{
					ControlList.data.current_session.Delete();
				}
				catch 
				{ 
				}
			}
		}
	}


	public class DeleteGameGroup : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
				try
				{
					ControlList.data.current_pack_group.Delete();
				}
				catch 
				{ 
				}
			}
		}
	}

	public class DeletePrizeLevel : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( allow_edit )
			{
				try
				{
					ControlList.data.current_prize_level_name.Delete();
				}
				catch 
				{ 
				}
			}
		}
	}


	public class DeleteGame : MyButton
	{
		protected override void  OnClick(EventArgs e)
		{
			if( allow_edit )
			{
				try
				{
                ControlList.data.current_game.Delete();
				}
				catch 
				{ 
				}
			}
		}
	}
}
