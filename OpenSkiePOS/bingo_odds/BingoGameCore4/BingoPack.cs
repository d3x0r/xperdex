using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace BingoGameCore4
{
	public class BingoPack
	{
		public object ID; // this is the ID of the pack per-player.
		public string name;
		public int pack_type; // this is the pack_type_number, dynamically assigned.
		public bool new_pack;
		/// <summary>
		/// how many faces in this pack
		/// </summary>
		public int count;
		/// <summary>
		/// how many rows on this pack
		/// </summary>
		public int rows; 
		/// <summary>
		/// how many cols on this pack
		/// </summary>
		public int cols;

		/// <summary>
		/// how many marks each face has; normal bingo is 25, upickem is 6-9, 90 number would be 27...
		/// </summary>
		public int face_size;

		/// <summary>
		/// game group that this pack is in.
		/// </summary>
		public List<BingoGameGroup> game_groups = new List<BingoGameGroup>();

		/// <summary>
		/// the list of games that this pack is part of...
		/// </summary>
		public BingoGameList game_list;

		/// <summary>
		/// a pack may be playing for one or more prize levels.  1) multi level faces, 2) parallel jackpots
		/// </summary>
		List<BingoPrize> prize_levels = new List<BingoPrize>();
#if asdfasdf
        object _prize_level_id;
        // if null is by-face, if by-face prize is null, then fall back to dealer range
        public object prize_level_id
        {
            get
            {
                int a = 3;
                return _prize_level_id;
            }
            set
            {
                _prize_level_id = value;
            }
        }
#endif
        /// <summary>
        /// The pack_info row in the schedule that this pack represents (if it was created from a schedule)
        /// </summary>
        DataRow schedule_row;
        //public List<object> prize_levels = new List<object>();
		public object[] face_prize_level_id;

		public struct flags_type
		{
			/// <summary>
			/// this is set after the fact, during sale loading, when we get a specific pack instance.
			/// </summary>
			//public bool paper;
			/// <summary>
			/// this needs to be setup by game loader at this time.... the one who makes skeleton packs.
			/// </summary>
			public bool big3;
            /// <summary>
            /// this pack is a double action pack (supports two faces in one)
            /// </summary>
            public bool double_action;
            /// <summary>
            /// This pack supports a single special square marked with a 'star' - if winning on this, special
            /// </summary>
            public bool starburst;
			/// <summary>
			/// Mark when it's upickem card (is checked in upickem phase of bingo engine)
			/// </summary>
			public bool upickem;
		} ;
		public flags_type flags;
		
		/// <summary>
		/// dealer is assigned with start_card
		/// and makes this a unique instance.  Skel packs are used
		/// to provide real packs to application layer.
		/// </summary>
        //public BingoDealer _dealer;
		public List<BingoDealer> dealers = new List<BingoDealer>();
        //public int start_card;

		/// <summary>
		/// the original skeleton pack has no dealers, but these packs are clones of the skeleton plus the dealer
		/// </summary>
		internal List<BingoPack> dealer_packs = new List<BingoPack>();

		internal BingoPack()
		{
		}
		internal BingoPack( BingoPack clone )
		{
			this.ID = clone.ID;
			this.name = clone.name;
			this.pack_type = clone.pack_type;
			
			//this.prize_level_id = clone.prize_level_id;
            this.prize_levels = clone.prize_levels;
			this.face_prize_level_id = clone.face_prize_level_id;

			this.rows = clone.rows;
			this.cols = clone.cols;
			this.count = clone.count;

			this.flags.big3 = clone.flags.big3;
            this.flags.double_action = clone.flags.double_action;
            this.flags.starburst = clone.flags.starburst;

			this.game_groups = clone.game_groups;
			this.game_list = clone.game_list;
			this.dealers = clone.dealers;
			//this._dealer = clone._dealer;
        }

        /// <summary>
        /// Create a new BingoPack from a PackTable datarow
        /// </summary>
        /// <param name="dataRow">A row from PackTable</param>
        public BingoPack( BingoGameGroup game_group, DataRow dataRow )
        {
            if( dataRow != null )
            {
                this.schedule_row = dataRow;
    			ScheduleDataSet schedule = dataRow.Table.DataSet as ScheduleDataSet;

                if( game_group != null )
                {
                    this.game_groups.Add( game_group );
                    this.cols = Convert.ToInt32( dataRow[ "width" ] );
                    this.rows = Convert.ToInt32( dataRow[ "height" ] );
                    this.count = cols * rows;
                    this.name = dataRow[ PackTable.NameColumn ].ToString();
                }

        		if( schedule != null )
		        {
        			DataRow[] possible_game_group_prize = dataRow.GetChildRows( "pack_has_prize_level" );
				    List<DataRow> game_group_prize = new List<DataRow>();
				    foreach( DataRow prize in possible_game_group_prize )
				    {
                        this.prize_levels.Add( game_group.GetPrize( prize[PrizeLevelNames.PrimaryKey] ) );
				    }
			    }
			    this.ID = dataRow[PackTable.PrimaryKey];
                if( count == 0 )
                {
                    Log.log( "Pack " + dataRow[PackTable.NameColumn] + " has 0 faces defined by length and strips(rows,cols:height,width)." );
                }

			    object tmp = dataRow["_3_number"];
			    if( tmp == DBNull.Value )
				    flags.big3 = false;
			    else
				    flags.big3 = Convert.ToBoolean( tmp );
			    tmp = dataRow["double_action"];
			    if( tmp == DBNull.Value )
				    flags.double_action = false;
			    else
				    flags.double_action = Convert.ToBoolean( tmp );
            }
        }

		public override string ToString()
		{
			return name;
		}

        int last_card_pos;
        public int AutoDeal()
        {
			if( dealers == null )
			{
				MessageBox.Show( "Dealer is not set for pack, cannot deal." );
				return 0;
			}
			else
			{
				foreach( BingoDealer dealer in dealers )
				{
					int card = dealer.Deal( rows, cols, this.count );
					if( card != 0 )
						return card;
				}
			}
			return 0;
        }

        public BingoDealer GetRangeDealer( int start_card )
        {
            while( true )
            {
                {
                    foreach( BingoDealer dealer in dealers )
                        if( dealer.real_min_range <= start_card &&
                            dealer.real_max_range >= start_card )
                            return dealer;
                }
                if( schedule_row != null )
                {
                    MessageBox.Show( "Could not find range for pack: " + name + " start card:" + start_card );
                    OpenSkieScheduler3.Controls.Forms.PackEditor pe = new OpenSkieScheduler3.Controls.Forms.PackEditor( schedule_row );
                    pe.ShowDialog();
                    pe.Dispose();
                    // need to do something like...
                    //ReloadDealers();
                    throw new Exception( "Could not find range for pack: " + name + " start card:" + start_card );
                }
                else
                {
                    throw new Exception( "Could not find range for pack: " + name + " start card:" + start_card );
                }
            }
            return null;
        }

		internal BingoPack GetRangePack( int start_card )
		{
			foreach( BingoPack pack in dealer_packs )
			{
				foreach( BingoDealer dealer in pack.dealers )
					if( dealer.real_min_range <= start_card &&
						dealer.real_max_range >= start_card )
						return pack;
			}
			BingoPack dealt = new BingoPack( this );
			dealt.dealers.Add( BingoDealers.GetDealer( start_card, this.pack_type ) );
			dealer_packs.Add( dealt );
			return dealt;
		}

		internal BingoPack GetRangePack( String range_name )
		{
			if( range_name == null )
				return null;

			foreach( BingoPack pack in dealer_packs )
			{
				foreach( BingoDealer dealer in pack.dealers )
					if( dealer.RangeName == range_name )
						return pack;
			}

			BingoPack dealt = new BingoPack( this );
			dealt.dealers.Add( BingoDealers.GetDealer( range_name ) );
			dealer_packs.Add( dealt );
			return dealt;
		}
	}

	public class BingoPacks: List<BingoPack> 
	{
		List<BingoPack> pack_skel = new List<BingoPack>();
		ScheduleDataSet schedule;
		internal BingoGameList game_list;
		public List<BingoPack> GetSkeletonPackList()
		{
			return pack_skel;
		}

		public BingoPacks( BingoGameList game_list, ScheduleDataSet schedule, DataRow session_info )
		{
			this.schedule = schedule;
			this.game_list = game_list;
			//Session
			if( session_info != null )
			{
				DataRow[] pack_groups = session_info.GetChildRows( "session_has_pack_group" );
				foreach( DataRow pack_group in pack_groups )
				{
					DataRow pack_group_info = pack_group.GetParentRow( "pack_group_in_session" );
					BingoGameGroup group = game_list.game_group_list.GetGameGroup( pack_group_info );
					DataRow[ ] packs = pack_group_info.GetChildRows( "pack_group_has_pack" );
					foreach( DataRow pack in packs )
					{
						DataRow pack_info = pack.GetParentRow( "pack_in_pack_group" );
						BingoPack made_pack = this.MakePack( group, pack_info );
						this.Add( made_pack );
					}
				}
			}
		}

		public BingoPack MakePack( object pack_info_id, String packnam, int rows, int cols, int face_size = 25 )
		{
			foreach( BingoPack pack in pack_skel )
			{
				if( String.Compare( pack.name, packnam, true ) == 0 )
				{
					pack.new_pack = false;
					return pack;
				}
			}
			BingoPack newpack = new BingoPack();
			newpack.ID = pack_info_id;
			newpack.name = packnam;
			newpack.rows = rows;
			newpack.cols = cols;
			newpack.count = rows * cols;
			newpack.face_size = face_size;
			if( face_size < 20 )
				newpack.flags.upickem = true;
			//newpack.pack_type = packtype;
			newpack.new_pack = true;
			pack_skel.Add( newpack );
            newpack.pack_type = this.pack_skel.IndexOf( newpack );

			//newpack.dealer = BingoDealers.LoadDealers(  );

            return newpack;
		}

        /// <summary>
        /// Search for a pack already created by said name, if it doesn't exist, create a BingoPack as defined by PackTable Row.
        /// </summary>
        /// <param name="dataRow">a DataRow from PackTable</param>
        /// <returns></returns>
        public BingoPack MakePack( BingoGameGroup game_group, DataRow dataRow )
        {

            foreach( BingoPack pack in pack_skel )
            {
                if( String.Compare( pack.name, dataRow[PackTable.NameColumn].ToString(), true ) == 0 
					&& pack.game_groups.Contains( game_group ) )
                {
                    return pack;
                }
            }

			foreach( BingoPack pack in pack_skel )
			{
				// found the pack, but it's not in this game group, so it's not really a pack.
				if( String.Compare( pack.name, dataRow[PackTable.NameColumn].ToString(), true ) == 0 )
				{
					return pack;
				}
			}

            BingoPack newpack = new BingoPack( game_group, dataRow );
            if( dataRow != null )
            {
                DataRow[ ] ranges = dataRow.GetChildRows( "pack_has_cardset_range" );
				if( ranges.Length == 0 )
				{
					MessageBox.Show( "Pack " + dataRow[PackTable.NameColumn] + " does not have any cardset ranges..." );
					OpenSkieScheduler3.Controls.Forms.PackEditor pe = new OpenSkieScheduler3.Controls.Forms.PackEditor( dataRow );
					pe.ShowDialog();
					pe.Dispose();
                    ranges = dataRow.GetChildRows( "pack_has_cardset_range" );
                }
                if( ranges != null && ranges.Length > 0 )
                {
					foreach( DataRow cardset_range in ranges )
					{
						DataRow range = cardset_range.GetParentRow( "cardset_range_in_pack" );
						newpack.dealers.Add( BingoDealers.GetDealer( range ) );
					}
                }

                this.pack_skel.Add( newpack );
                newpack.pack_type = this.pack_skel.IndexOf( newpack );

                game_group.packs.Add( newpack );
            }
            return newpack;
        }

		public BingoPack MakePack( string packnam, int cards, int face_size = 25 )
		{
			if( cards % 3 == 0 )
				return MakePack( 200, packnam, 3, cards/3, face_size );
			else
				return MakePack( 200, packnam, cards, 1, face_size );
		}

		public PlayerPack[] GetPlayerPacks( string packnam, String range )
		{
			List<PlayerPack> packs = new List<PlayerPack>();
//retry:
			foreach( BingoPack pack in pack_skel )
			{
				if( String.Compare( pack.name, packnam, true ) == 0 )
				{
					BingoPack real_pack = pack.GetRangePack( range );
					PlayerPack newpack = new PlayerPack();
					newpack.pack_info = real_pack;
					if( packs.Count == 0 )
						newpack.start_card = newpack.pack_info.AutoDeal();
					else
						newpack.start_card = packs[0].start_card;
					packs.Add( newpack );
				}
			}

			if( packs.Count == 0 )
				if( MessageBox.Show( "Pack " + packnam + " does not exist - add to schedule?", "Configure Pack?", MessageBoxButtons.YesNo ) == DialogResult.Yes )
				{
					DataRow row = schedule.packs.NewPack( packnam );
					//OpenSkieScheduler.Controls.ControlList.schedule = schedule;
					OpenSkieScheduler3.Controls.Forms.PackEditor pe = new OpenSkieScheduler3.Controls.Forms.PackEditor( row );
					pe.ShowDialog();
					//MakePack( game_group, row );
					//goto retry;
					return null;// MakePack( game_group, row );
				}
			return packs.ToArray();
		}

		public PlayerPack[] GetPlayerPacks( string packnam )
		{
			return GetPlayerPacks( packnam, null );
		}
		public BingoPack GetPack( String packnam, String range )
		{
			return GetPack( packnam );
		}

		public BingoDealer GetDealer( BingoPack pack, int start_card )
		{
			return pack.GetRangeDealer( start_card );
		}

		public BingoPack GetPack( String packnam )
		{
			foreach( BingoPack pack in this )
			{
				if( String.Compare( pack.name, packnam, true ) == 0 )
				{
					pack.new_pack = false;
					return pack;
				}
			}

			foreach( BingoPack pack in pack_skel )
			{
				if( String.Compare( pack.name, packnam, true ) == 0 )
				{
					//BingoPack real_pack = pack.GetRangePack( start_card );
					//real_pack.new_pack = false;
					return pack;
				}
			}

			if( MessageBox.Show( "Pack " + packnam + " does not exist - add to schedule?", "Configure Pack?", MessageBoxButtons.YesNo ) == DialogResult.Yes )
			{
				DataRow row = schedule.packs.NewPack( packnam );
				//OpenSkieScheduler.Controls.ControlList.schedule = schedule;
				OpenSkieScheduler3.Controls.Forms.PackEditor pe = new OpenSkieScheduler3.Controls.Forms.PackEditor( row );
				pe.ShowDialog();
			}

			{
				BingoPack newpack = new BingoPack();
				newpack.game_list = game_list;
				newpack.name = packnam;
				newpack.new_pack = true;
				this.Add( newpack );
				return newpack;
			}
		}


		public BingoPack CreatePack( BingoDealer dealer, String packtype )
        {
            foreach( BingoPack pack in pack_skel )
            {
                if( String.Compare( pack.name, packtype, true ) == 0 )
                {
                    //BingoData.pi.S
                    BingoPack newpack = new BingoPack( pack );
                    newpack.dealers.Add( dealer );
                    //newpack.start_card = 0;
                    this.Add( newpack );
                    return newpack;
                }
            }
            BingoPack a_newpack;
            a_newpack = GetPack( packtype, null );
            a_newpack.dealers.Add( dealer );
            pack_skel.Add( a_newpack );
            return a_newpack;
        }
		public BingoPack GetPack( bool deal, int rows, int cols, int card_count, String packtype )
		{
			BingoPack pack = GetPack( packtype, null );
			if( deal && pack != null )
			{
				pack.rows = rows;
				pack.cols = cols;
				pack.count = card_count;
				//pack.start_card = pack.dealer.Deal( rows, cols, card_count );
			}
			return pack;
		}

		public BingoPack GetPackDelete( int start_card, int packtype )
		{
			foreach( BingoPack pack in pack_skel )
			{
				if( pack.pack_type == packtype )
				{
					//BingoData.pi.S
					BingoPack newpack = new BingoPack( pack );
					newpack.dealers.Add( BingoDealers.GetDealer( start_card, packtype ) );
					//newpack.start_card = start_card;
					this.Add( newpack );
					return newpack;
				}
			}
			Log.log( "Pack was not scheduled for today... could not find info to attach dealer." );
			//newpack.name = 
			return null;

		}
	}
}
