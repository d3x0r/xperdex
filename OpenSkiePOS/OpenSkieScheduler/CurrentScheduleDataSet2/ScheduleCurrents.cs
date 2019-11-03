using System.Collections.Generic;
using System.Data;
using OpenSkie.Scheduler.CurrentTables;
using OpenSkieScheduler3;
using OpenSkieScheduler3.BingoGameDefs;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace OpenSkie.Scheduler
{
    public class ScheduleCurrents
    {
		public static ScheduleCurrents last_created_currents;
		public delegate void OnSetCurrent( DataRow current );

        public ScheduleCurrents( ScheduleDataSet schedule )
        {
            this.schedule = schedule;
            ExtendSchedule();
			last_created_currents = this;
        }
		List<DataTable> Mytables;
        ScheduleDataSet schedule;
        public ScheduleDataSet Schedule
        {
            get
            {
                return schedule;
            }
            set
            {
                schedule = value;
                ExtendSchedule();
            }
        }

		public CurrentSessions current_sessions;
		public CurrentSessions current_all_sessions;
		public CurrentSessionBundles current_session_bundles;
		public CurrentBundles current_bundles;
		public CurrentSessionBundlePacks current_session_bundle_packs;
		public CurrentGameGroupPrizePacks current_game_group_prize_packs;
        public CurrentSessionGames2 current_session_games;
		public CurrentSessionPack current_session_packs;
		public CurrentPackPrizeLevel current_pack_prize_level;
        public CurrentGamePatterns current_game_patterns;
        public CurrentPackGroupPacks current_pack_group_packs;
        public CurrentMetaGameGroupPacks current_meta_pack_group_packs;
#if asdfasdf
        public CurrentSessionPrizeOrder current_session_prize_level_order;
        public CurrentSessionGamePackPrize current_session_prize_level;
#endif
        public CurrentCardsetRanges current_cardset_ranges;
        public CurrentCardsetRangePack current_cardset_range_packs;
        public CurrentPackCardsetRanges current_pack_cardset_ranges;
        public CurrentPackFacePrizeLevel current_pack_face_prize_level;
        public CurrentGameGroupPrizes current_game_group_prizes;
		public CurrentSessionPackGroup current_session_pack_groups;
        public CurrentSessionMacroSessions current_session_macro_sessions;
		//public CurrentSessionGamePackGroups current_session_game_pack_groups;
		public CurrentSessionGameSessionPackGroups current_session_game_session_pack_groups;

		public CurrentSessionPriceExceptionSets current_session_price_exception_sets;
		public CurrentPriceData current_price_data;

		public CurrentSessionPrizeExceptionSets current_session_prize_exception_sets;
		public CurrentPrizeData current_prize_data;

        void ExtendSchedule( )
        {
			CreateCurrentTables();
            AddEvents();
            AssignCurrentTables();
        }

        bool CreateCurrentTables()
        {
            if( schedule != null && Mytables == null )
            {
                //if( schedule.UseGuid )
                //    XDataTable.DefaultAutoKeyType = typeof( Guid );
				new CurrentCardsetRanges( schedule );
				Mytables = new List<DataTable>();
                Mytables.Add( new CurrentPackFacePrizeLevel( schedule ) );
                //Mytables.Add( new CurrentPackCardsetRanges( schedule ) );
                Mytables.Add( new CurrentCardsetRangePack( schedule ) );
                Mytables.Add( new CurrentGameGroupPrizes( schedule ) );
				Mytables.Add( new CurrentPackPrizeLevel( schedule ) );
				Mytables.Add( new CurrentPriceData( schedule ) );

                return true;
            }
            return false;
        }

        void AssignCurrentTables()
        {
			current_session_macro_sessions = new CurrentSessionMacroSessions( schedule );
			current_session_pack_groups = new CurrentSessionPackGroup( schedule );
			current_session_games = new CurrentSessionGames2( schedule );
			//current_session_game_pack_groups = new CurrentSessionGamePackGroups( schedule );
			current_session_game_session_pack_groups = new CurrentSessionGameSessionPackGroups( schedule );

			current_session_bundle_packs = new CurrentSessionBundlePacks( schedule );
			current_session_bundles = new CurrentSessionBundles( schedule );

			current_session_games = new CurrentSessionGames2( schedule );
			current_sessions = new CurrentSessions( schedule );
			current_bundles = new CurrentBundles( schedule );
			current_all_sessions = new CurrentSessions( schedule );
			current_session_packs = new CurrentSessionPack( schedule );
			current_pack_group_packs = new CurrentPackGroupPacks( schedule );
			current_session_price_exception_sets = new CurrentSessionPriceExceptionSets( schedule );

			current_session_prize_exception_sets = new CurrentSessionPrizeExceptionSets( schedule );
			current_prize_data = new CurrentPrizeData( schedule );
			//current_session_pack_order = new CurrentSessionPackOrder( schedule );

			current_game_patterns = new CurrentGamePatterns( schedule );

            current_cardset_ranges = schedule.Tables[CurrentCardsetRanges.TableName] as CurrentCardsetRanges;
			current_pack_cardset_ranges = new CurrentPackCardsetRanges( schedule );
            current_cardset_range_packs = schedule.Tables[CurrentCardsetRangePack.TableName] as CurrentCardsetRangePack;
			//current_session_packs = schedule.Tables[CurrentSessionPack.TableName] as CurrentSessionPack;
			//current_session_pack_groups = schedule.Tables[CurrentSessionPackGroup.TableName] as CurrentSessionPackGroup;
			current_pack_prize_level = schedule.Tables[CurrentPackPrizeLevel.TableName] as CurrentPackPrizeLevel;

	        //current_pack_group_packs = schedule.Tables[CurrentPackGroupPacks.TableName] as CurrentPackGroupPacks;
    
            current_game_group_prizes = schedule.Tables[CurrentGameGroupPrizes.TableName] as CurrentGameGroupPrizes;

#if asdfasdf
            current_session_prize_level = schedule.Tables[CurrentSessionGamePackPrize.TableName] as CurrentSessionGamePackPrize;
#endif

			//current_session_prize_level_order = schedule.Tables[CurrentSessionPrizeOrder.TableName] as CurrentSessionPrizeOrder;
            current_pack_face_prize_level = schedule.Tables[CurrentPackFacePrizeLevel.TableName] as CurrentPackFacePrizeLevel;

            current_game_group_prize_packs = schedule.Tables[CurrentGameGroupPrizePacks.TableName] as CurrentGameGroupPrizePacks;

			//current_session_price_exception_sets = schedule.Tables[CurrentSessionPriceExceptionSets.TableName] as CurrentSessionPriceExceptionSets;
			current_price_data = schedule.Tables[CurrentPriceData.TableName] as CurrentPriceData;

			//current_session_prize_exception_sets = schedule.Tables[CurrentSessionPrizeExceptionSets.TableName] as CurrentSessionPrizeExceptionSets;
			//current_prize_data = schedule.Tables[CurrentPrizeData.TableName] as CurrentPrizeData;
		}


        void AddEvents()
        {
			if( schedule != null )
			{
				schedule.Clearing += new ScheduleDataSet.OnClear( schedule_Clearing );
				schedule.DataSetReload += new ScheduleDataSet.OnDataSetReload( schedule_DataSetReload );
			}
            //schedule.SetBundleCurrent += new ScheduleDataSet.OnSetCurrent( schedule_SetBundleCurrent );
            //schedule.SetSessionCurrent += new ScheduleDataSet.OnSetCurrent( schedule_SetSessionCurrent );
        }

		void schedule_DataSetReload( DataSet dataSet )
		{
			// somehow I have to tell all these current tables to fill themselves.
			foreach( DataTable table in Mytables )
			{
				CurrentObjectTableView cotv = table as CurrentObjectTableView;
				if( cotv != null )
					cotv.Fill();
			}
		}

        void schedule_Clearing()
        {
            // might drop all of these tables.
            // some reason I had setcurrent as NULL all over the place
            // mostly because set current doesn't get the ondelete event... which I guess could be meticulously added
            // especially if it were added to the CurrentObject dataatable type.
        }

        void schedule_SetSessionCurrent( DataRow current )
        {
			current_session = current;
        }

        void schedule_SetBundleCurrent( DataRow current )
        {
            current_session_bundles.Current = current;
            current_session_bundle_packs.Current = current;
        }

		public DataRow _current_session_type;
		public DataRow current_session_type
		{
			set { _current_session_type = value; }
			get { return _current_session_type; }
		}

		public DataRow _current_session_macro_session;		
		public DataRow current_session_macro_session
		{
			set { 
				SetCurrentSessionMacroSession( value );
				_current_session_macro_session = value; 
			} 
			get { return _current_session_macro_session; } 
		}
		public DataRow _current_session_macro;				
		public DataRow current_session_macro
		{			 
			set {  _current_session_macro= value; } 
			get { return _current_session_macro; } 
		}
		public DataRow _current_session;					
		public DataRow current_session
		{
			set { 
				SetCurrentSession( value );
			} 
			get { return _current_session; } 
		}
		public DataRow _current_pack_group;					
		public DataRow current_pack_group
		{				 
			set {  _current_pack_group= value; } 
			get { return _current_pack_group; } 
		}
		public DataRow _current_game_group_prize;			
		public DataRow current_game_group_prize
		{		 
			set {  _current_game_group_prize= value; } 
			get { return _current_game_group_prize; } 
		}
		public DataRow _current_game;						
		public DataRow current_game
		{					
			set {  _current_game= value; } 
			get { return _current_game; } 
		}
		public DataRow _current_pack;						
		public DataRow current_pack
		{					 
			set {  _current_pack= value; } 
			get { return _current_pack; } 
		}
		public DataRow _current_prize;						
		public DataRow current_prize
		{					 
			set {  _current_prize= value; } 
			get { return _current_prize; } 
		}
		public DataRow _current_pattern;					
		public DataRow current_pattern
		{					 
			set {  _current_pattern= value; } 
			get { return _current_pattern; } 
		}
		public DataRow _current_session_game_group;			
		public DataRow current_session_game_group
		{		 
			set {  _current_session_game_group= value; } 
			get { return _current_session_game_group; } 
		}
		public DataRow _current_bundle;						
		public DataRow current_bundle
		{					 
			set {  _current_bundle= value; } 
			get { return _current_bundle; } 
		}
		public DataRow _current_session_game_group_game;
		public DataRow current_session_game_group_game
		{
			set { _current_session_game_group_game = value; }
			get { return _current_session_game_group_game; }
		}
		public DataRow _current_session_bundle_pack;
		public DataRow current_session_bundle_pack
		{
			set { _current_session_bundle_pack = value; }
			get { return _current_session_bundle_pack; }
		}

		public OnSetCurrent SetBundleCurrent;
		public void SetCurrentBundle( DataRow bundle )
        {
			//current_bundle
            //current_bundle = bundle;
			current_session_bundle_packs.Current = bundle;
            current_bundle = bundle;
			
            // thre were two current tables... we lost
            //OpenSkieScheduler.Controls.ControlList.UpdateText( "bundles" );
        }

		/// <summary>
		/// CurrentSessionPriceExceptionSet row
		/// </summary>
		public DataRow current_session_price_exception_set;
		public OnSetCurrent SetSessionPriceExceptionSetCurrent;
		public void SetCurrentSessionPriceExceptionSet( DataRow row )
		{
			current_session_price_exception_set = row;
			if( current_price_data != null )
				current_price_data.Current = row;
			if( SetSessionPriceExceptionSetCurrent != null )
				SetSessionPriceExceptionSetCurrent( row );
		}

		/// <summary>
		/// CurrentSessionPrizeExceptionSet row
		/// </summary>
		public DataRow current_session_prize_exception_set;
		public OnSetCurrent SetSessionPrizeExceptionSetCurrent;
		public void SetCurrentSessionPrizeExceptionSet( DataRow row )
		{
			current_session_prize_exception_set = row;
			if( current_prize_data != null )
				current_prize_data.Current = row;
			if( SetSessionPrizeExceptionSetCurrent != null )
				SetSessionPrizeExceptionSetCurrent( row );
		}

		public event OnSetCurrent SetSessionTypeCurrent;
		public void SetCurrentSessionType( DataRow session )
		{
			if( current_session_type != session )
			{
				current_session_type = session;
				if( SetSessionTypeCurrent != null )
					SetSessionTypeCurrent( session );
			}
		}

		/// <summary>
        /// Event triggered when a current session is set
        /// </summary>
        public event OnSetCurrent SetSessionCurrent;
        public void SetCurrentSession( DataRow Session )
        {
			if( Session != null 
				&& Session.Table.TableName == SessionDayMacroSessionTable.TableName )
			{
				// prize schedule editor form can pass a current session_macro_session...
				// so soon this will be 'gimme something with a session and I get a current'
				SetCurrentSessionMacroSession( Session );
				return;
			}
            if( _current_session != Session )
            {
				_current_session = Session;

				current_session_pack_groups.Current = Session;

				//current_session_game_groups.Current = current;
				//if( current_session_pack_order != null )
				//	current_session_pack_order.Current = Session;
#if asdfasdf
				if( current_session_prize_level_order != null )
					current_session_prize_level_order.Current = Session;
#endif
				if( current_price_data != null )
					current_price_data.Current = Session;
				if( current_prize_data != null )
					current_prize_data.Current = Session;

				current_session_bundles.Current = Session;

				if( current_session_bundles != null )
					current_session_bundles.Current = Session;
				if( current_session_packs != null )
					current_session_packs.Current = Session;
				//if( current_session_pack_order != null )
				//	current_session_pack_order.Current = Session;
#if asdfasdf
				if( current_session_prize_level != null )
					current_session_prize_level.Current = Session;
#endif
				if( current_session_games != null )
					current_session_games.Current = Session;
				if( current_session_price_exception_sets != null )
					current_session_price_exception_sets.Current = Session;
				if( current_session_prize_exception_sets != null )
					current_session_prize_exception_sets.Current = Session;
                if( SetSessionCurrent != null )
                    SetSessionCurrent( Session );
            }
        }

        /// <summary>
        /// Event triggered when a current game is set
        /// </summary>
        public event OnSetCurrent SetGameCurrent;
        public void SetCurrentGame( DataRow dataRow )
        {
            //current_game = dataRow;
			current_game_patterns.Current = dataRow;
            current_game = dataRow;
            if( SetGameCurrent != null )
                SetGameCurrent( dataRow );
        }

        /// <summary>
        /// Event triggered when a current game group is set
        /// </summary>
        public event OnSetCurrent SetGameGroupCurrent;
        public void SetCurrentGameGroup( DataRow dataRow )
        {
            if( current_pack_group != dataRow )
            {
                if( current_meta_pack_group_packs != null )
                    current_meta_pack_group_packs.Current = dataRow;

                //current_game_group = dataRow;
                //if( meta_game_group_packs != null )
                //	meta_game_group_packs.Current = dataRow;

                if( current_pack_group_packs != null )
                    current_pack_group_packs.Current = dataRow;
                if( current_game_group_prizes != null )
                    current_game_group_prizes.Current = dataRow;
                current_pack_group = dataRow;
                if( SetGameGroupCurrent != null )
                    SetGameGroupCurrent( dataRow );
            }
        }



        public void SetCurrentGameGroupPrize( DataRow dataRow )
        {
            DataRow real_datarow;
            if( dataRow != null )
            {
                real_datarow = dataRow.GetParentRow( PackGroupPrizeRelation.TableName );
                if( current_game_group_prize != real_datarow )
                {
                    current_game_group_prize_packs.Current = real_datarow;

                    current_game_group_prizes.Current = real_datarow;
                }
            }
            else
            {
                current_game_group_prize_packs.Current = null;

                current_game_group_prizes.Current = null;
            }
        }
        /// <summary>
        /// Event triggered when a current pack is set
        /// </summary>
        public event OnSetCurrent SetPackCurrent;
        public void SetCurrentPack( DataRow dataRow )
        {
			if( current_pack_prize_level != null )
				current_pack_prize_level.Current = dataRow;

            current_pack_cardset_ranges.Current = dataRow;
            current_pack_face_prize_level.Current = dataRow;
            current_pack = dataRow;
            if( SetPackCurrent != null )
                SetPackCurrent( dataRow );
        }




        /// <summary>
        /// Event triggered when a current cardset is set
        /// </summary>
        public event OnSetCurrent SetCardsetCurrent;
        public DataRow current_cardset_info;
        public void SetCurrentCardset( DataRow dataRow )
        {
            current_cardset_info = dataRow;
            if( SetCardsetCurrent != null )
                SetCardsetCurrent( dataRow );
        }

        /// <summary>
        /// Event triggered when a current prize level is set
        /// </summary>
        public event OnSetCurrent SetPrizeLevelCurrent;
        public DataRow current_prize_level_name;
        public void SetCurrentPrize( DataRow dataRow )
        {
            current_prize_level_name = dataRow;
            //current_prize = dataRow;
            if( SetPrizeLevelCurrent != null )
                SetPrizeLevelCurrent( dataRow );
            //OpenSkieScheduler.Controls.ControlList.UpdateText( "prizes" );
        }

        /// <summary>
        /// Event triggered when a current cardset range is set
        /// </summary>
        public event OnSetCurrent SetCardsetRangeCurrent;
        public DataRow current_cardset_range;
        public void SetCurrentCardsetRange( DataRow dataRow )
        {
            current_cardset_ranges.Cardset = dataRow;
            current_cardset_range_packs.Current = dataRow;
            current_cardset_range = dataRow;
            if( SetCardsetRangeCurrent != null )
                SetCardsetRangeCurrent( dataRow );
        }
        /// <summary>
        /// Event triggered when a current session macro is set
        /// </summary>
        public event OnSetCurrent SetSessionMacroCurrent;
        public void SetCurrentSessionMacro( DataRow dataRow )
        {
            //current_session_macro = dataRow;
            current_session_macro_sessions.Current = dataRow;
            current_session_macro = dataRow;

            if( SetSessionMacroCurrent != null )
                SetSessionMacroCurrent( dataRow );
            //OpenSkieScheduler.Controls.ControlList.UpdateText( "session_macros" );
        }

        /// <summary>
        /// Event triggered when a current pattern is set
        /// </summary>
        public event OnSetCurrent SetPatternCurrent;
        public void SetCurrentPattern( DataRow dataRow )
        {
            current_pattern = dataRow;
            if( dataRow != null )
            {
                schedule.patterns.LoadPatternData( dataRow );
            }
            if( SetPatternCurrent != null )
                SetPatternCurrent( dataRow );
        }

        public void SetCurrentSessionBundle( DataRow dataRow )
        {
            current_session_bundles.Current = dataRow;
			current_session_bundle_packs.Current = dataRow; // set current parent
        }

		public OnSetCurrent SetSessionBundlePackCurrent;
		public void SetCurrentSessionBundlePack( DataRow dataRow )
		{
			if( dataRow.Table.GetType().IsSubclassOf( typeof( CurrentObjectTableView ) ) )
				_current_session_bundle_pack = dataRow.GetParentRow( ( dataRow.Table as CurrentObjectTableView ).ChildRelationName );
			else
				_current_session_bundle_pack = dataRow;

			current_session_bundle_packs.Current = dataRow;
			if( SetSessionBundlePackCurrent != null )
				SetSessionBundlePackCurrent( dataRow );
		}

		public void SetCurrentSessionPack( DataRow dataRow )
		{
			if( current_session_packs != null )
				current_session_packs.Current = dataRow;
			//if( current_session_pack_order != null )
			//	current_session_pack_order.Current = dataRow;
		}

		#region current_session_pack_group
		public DataRow _current_session_pack_group;
		public DataRow current_session_pack_group
		{
			get
			{
				return _current_session_pack_group;
			}
			set
			{
				SetCurrentSessionPackGroup( value );
			}
		}
		public event OnSetCurrent SetSessionPackGroupCurrent;
		public void SetCurrentSessionPackGroup( DataRow dataRow )
		{
			//if( _current_session_pack_group == dataRow )
			//	return;

			if( dataRow == null )
				SetCurrentSession( null );
			else
				SetCurrentSession( dataRow.GetParentRow( schedule.session_pack_groups.ChildrenOfParent ) );
			_current_session_pack_group = dataRow;

			current_session_pack_groups.Current = dataRow;
			current_session_game_session_pack_groups.Current = dataRow;

			if( SetSessionPackGroupCurrent != null )
				SetSessionPackGroupCurrent( dataRow );
		}
		#endregion

		#region current_session_game
		public DataRow _current_session_game;
		public DataRow current_session_game
		{
			get
			{
				return _current_session_game;
			}
			set
			{
				SetCurrentSessionGame( value );
			}
		}
		//public DataRow current_session_game_group_game_order_row;
		public event OnSetCurrent SetSessionGameCurrent;
		public void SetCurrentSessionGame( DataRow dataRow )
        {
			if( _current_session_game == dataRow )
				return;

			SetCurrentSession( dataRow.GetParentRow( schedule.session_games.ChildrenOfParent ) );

			current_game_patterns.Current = dataRow;
			current_session_games.Current = dataRow;
			current_session_game_session_pack_groups.Current = dataRow;

			_current_session_game = dataRow;

			if( SetSessionGameCurrent != null )
				SetSessionGameCurrent( dataRow );

        }
		#endregion


		public void SetCurrentSessionMacroSession( DataRow dataRow )
        {
			DataRow session = dataRow.GetParentRow( schedule.session_macro_sessions.ParentOfChild );
			SetCurrentSession( session );
            current_session_macro_sessions.Current = dataRow;
			//current_sessions.Current = dataRow;
#if asdfasdf
            current_session_prize_level.Current = dataRow;
#endif
            _current_session_macro_session = dataRow;
        }
    }
}
