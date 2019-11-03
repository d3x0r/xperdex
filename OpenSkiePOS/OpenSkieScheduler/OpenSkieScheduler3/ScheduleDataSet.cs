//#define no_well_known_names
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Windows.Forms;
using OpenSkieScheduler3.BingoGameDefs;
using OpenSkieScheduler3.Relations;
using xperdex.classes;
using System.IO;
using System.IO.Compression;

namespace OpenSkieScheduler3
{
	public class ScheduleDataSet : DataSet
	{
        public delegate void OnClear();
        public event OnClear Clearing;
		void SetupScheduleOptions()
		{
			OpenSkieSchedule.last_created_schedule = this;

		}
	
		// an additional prefix to tables... ( used for instance schedule )
		internal string prefix;
		bool next_commit_is_sync;
		public bool SyncOnNextCommit
		{
			set
			{
				next_commit_is_sync = value;
			}
			get
			{
				return next_commit_is_sync;
			}
		}

		List<DataColumn> snapshot_unique_cols;
		bool _snapshot;
		/// <summary>
		/// This flag is set when it's a snapshot version of the schedule not an original
		/// </summary>
		public bool snapshot
		{
			set
			{
				if( value && !_snapshot )
				{
					if( snapshot_unique_cols == null )
						snapshot_unique_cols = new List<DataColumn>();
					foreach( DataTable table in PersistantTables )
					{
						table.Prefix = table.Prefix + Names.snapshot_prefix;
						if( XDataTable.HasNumber( table ) )
						{
							DataColumn dc = table.Columns[XDataTable.Number( table )];
							if( dc.Unique )
							{
								snapshot_unique_cols.Add( dc );
								dc.Unique = false;
							}
						}
						if( XDataTable.HasName( table ) )
						{
							DataColumn dc = table.Columns[XDataTable.Name( table )];
							if( dc.Unique )
							{
								snapshot_unique_cols.Add( dc );
								dc.Unique = false;
							}
							else
								Log.log( "Non unique name..." );
						}
					}


					_snapshot = value;
				}
				else  if( !value && _snapshot )
				{
					foreach( DataColumn dc in snapshot_unique_cols )
						dc.Unique = true;
					foreach( DataTable table in PersistantTables )
					{
						table.Prefix = Names.schedule_prefix;
					}
					snapshot_unique_cols.Clear();
					_snapshot = value;
				}
			}
			get
			{
				return _snapshot;
			}
		}

		public delegate void TableFillMethod();

		/// <summary>
		/// This is a list of all the tables in this that get filled with data.
		/// </summary>
		private LinkedList<DataTable> TableFiller = new LinkedList<DataTable>();
		private List<DataTable> TableNoAutoFill = new List<DataTable>();
		class TableDefaultFiller
		{
			internal String real_fill_method;
			internal String method_name;
			internal DataTable table;
			internal TableDefaultFiller( String name, String real_fill_method, DataTable table )
			{
				this.real_fill_method = real_fill_method;
				this.table = table;
				this.method_name = name;
			}
		}
		private List<TableDefaultFiller> TableFillers = new List<TableDefaultFiller>();

		public delegate void TableCreateMethod();
		public LinkedList<DataTable> PersistantTables = new LinkedList<DataTable>();

		public delegate void OnDataSetReload( DataSet dataSet );
		public event OnDataSetReload DataSetReload;

#if !no_well_known_names
		public DataTable halls;
		public DataTable charities;

		public DataTable items;
		public DataTable item_assemblies;

		public DataTable session_day_calendar;

		public SessionTypeTable session_types;
		public SessionTable sessions;

		public BundleTable bundles;
		public SessionBundleRelation session_bundles;
		public SessionPack session_packs;
		//public BundlePackRelation bundle_packs;
		public SessionBundlePackRelation session_bundle_packs;

		public PackGroupTable pack_groups;
		public SessionPackGroup session_pack_groups;
        public PackGroupPackRelation pack_group_packs;
		public PackGroupPrizeRelation game_group_prizes;
		public ColorInfoTable colors;

		public GameTable games;

		//public SessionGameSessionPack session_game_session_pack;
        public SessionGame session_games;
        //internal SessionGamePackGroup session_game_pack_group;  //depricated, use ssion_game_sesion_pack_group
		public SessionGameSessionPackGroup session_game_session_pack_group;
        
        public PatternDescriptionTable patterns;
		public PatternFilterTable filtered_patterns;
		public PatternDataTable pattern_data;
		public PatternMultiDataTable pattern_sub_pattern;
        public PatternJavaDataTable pattern_java_server;

		public GamePatternRelation game_patterns;

        public CardsetRangePayoutLevel cardset_payout_level;
        public PackTable packs;
		public PackPrizeLevel pack_prize_level;
		public PackFacePrizeLevel pack_face_prize_level;

        public SessionMacroTable session_macros;
		public SessionDayMacroSessionTable session_macro_sessions;
		public SessionMacroSchedule session_macro_schedule;

		public PrizeLevelNames prize_level_names;

		//public SessionPrizeTable session_prize_level;
		//public SessionPrizeOrder session_prize_level_order;
        
		public PriceExceptionSet price_exception_sets;
		public SessionPriceExceptionSet session_price_exception_sets;
		public SessionPriceData session_price_data;

		public PrizeExceptionSet prize_exception_sets;
		public SessionPrizeExceptionSet session_prize_exception_sets;
		public SessionPrizeData session_prize_data;

		
		public CardsetInfo cardset_info;
		public CardsetRange cardset_ranges;
		public CardsetCards cardset_cards;
		public CardsetCards90 cardset_cards_90;
		public Dealer dealer;
		public PackCardsetRange pack_cardset_ranges;

		public CardsetRangePack cardset_range_packs;


#endif
		//public Dealer dealer;


		static ScheduleDataSet first_set;
		public static ScheduleDataSet GetScheduleDataSet()
		{
			return first_set;
		}

		public ScheduleDataSet()
		{
			SetupScheduleOptions();
			if( first_set == null )
				first_set = this;
			this.DataSetName = "Bingo Schedule";
			schedule_dsn = null;
			BuildDataset( this );
			FixupTableReferences();
		}

		public ScheduleDataSet( String xml_file )
		{
			SetupScheduleOptions();
			this.DataSetName = "Bingo Schedule";
			BuildDataset( this );
			this.ReadXml( xml_file, XmlReadMode.ReadSchema );
			FixupTableReferences();
		}
#if use_p2p_events
        public void SetTableReload( MySQLDataTable.FormUpdateMethod method )
        {
            foreach ( DataTable table in Tables )
            {
                MySQLDataTable mytable = table as MySQLDataTable;
                if ( mytable != null )
                    mytable.FormReloadTable += method;
            }
        }

		public void RemoveTableReload( MySQLDataTable.FormUpdateMethod method )
		{
			foreach( DataTable table in Tables )
			{
				MySQLDataTable mytable = table as MySQLDataTable;
				if( mytable != null )
					mytable.FormReloadTable -= method;
			}
		}
#endif
		public ScheduleDataSet( xperdex.classes.DsnConnection odbc )
			: base()
		{
			SetupScheduleOptions();
			this.DataSetName = "Bingo Schedule";
			schedule_dsn = odbc;
			BuildDataset( this );
			FixupTableReferences();
		}



		void Tables_CollectionChanged( object sender, System.ComponentModel.CollectionChangeEventArgs e )
		{
			if( e.Action == System.ComponentModel.CollectionChangeAction.Add )
			{
				bool is_persistant = false;
                //if ( ( e.Element as DataTable ) != null )
                //    Log.log( "added " + ( e.Element as DataTable ).TableName );
				foreach( Attribute attr in e.Element.GetType().GetCustomAttributes(true) )
				{
					//Log.log( "Checking " + attr.ToString() + " in " + e.Element.ToString() );
					{
						SchedulePersistantTable persist = attr as SchedulePersistantTable;
						if( null != persist )
						{
							is_persistant = true;
							PersistantTables.AddLast( ( e.Element as DataTable ) );

							DataTable db_DataTable = e.Element as DataTable;
							if( db_DataTable != null )
							{
								if( persist.FillMethod != "None" )
								{
									// this list is used for begin/end load data...
									TableFiller.AddLast( db_DataTable );
									TableFillers.Add( new TableDefaultFiller( persist.DefaultFill, persist.Fill, db_DataTable ) );
								}
								else
								{
									TableNoAutoFill.Add( db_DataTable );
								}
							}
							break;
						}
					}
					if( !is_persistant )
					{
						ScheduleTable non_persist = attr as ScheduleTable;
						if( null != non_persist )
						{
							DataTable db_DataTable = e.Element as DataTable;
							if( db_DataTable != null )
							{
								if( non_persist.FillMethod != "None" )
								{
									// this list is used for begin/end load data...
									TableFiller.AddLast( db_DataTable );
									TableFillers.Add( new TableDefaultFiller( non_persist.DefaultFill, non_persist.Fill, db_DataTable ) );
								}
								else
								{
									TableNoAutoFill.Add( db_DataTable );
								}
							}
							break;
						}
					}
				}
			}
		}

		public void Reload( DsnConnection dsn )
		{
			this.BeginInit();
			this.EnforceConstraints = false;
			this.Clear();
			session_macros.Reconnect( dsn );
			sessions.Reconnect( dsn );
			games.Reconnect( dsn );
			pack_groups.Reconnect( dsn );
			colors.Reconnect( dsn );
			packs.Reconnect( dsn );
			bundles.Reconnect( dsn );

			prize_level_names.Reconnect( dsn );

			this.cardset_info.Reconnect( dsn );
			this.dealer.Reconnect( dsn );
			this.cardset_ranges.Reconnect( dsn );

			this.session_macro_schedule.Reconnect( dsn );
			this.session_macro_sessions.Reconnect( dsn );
			this.session_pack_groups.Reconnect( dsn );
			//this.game_group_games.Reconnect( dsn );
			this.pack_group_packs.Reconnect( dsn );
			this.game_group_prizes.Reconnect( dsn );
			this.patterns.Reconnect( dsn );
			this.game_patterns.Reconnect( dsn );
			this.pack_cardset_ranges.Reconnect( dsn );

			//this.current_session_prize_level.Clear();
			//this.session_prize_level.Reconnect( dsn );
			// pattern data is loaded on demand through other methods
			this.pattern_data.Reconnect( dsn, false, false );
			this.pattern_java_server.Reconnect( dsn, false, false );

			// probably want to write this out... maybe do nothing.... but if the database is out of sync...
			//this.current_session_game_group_game_order.Clear();
			//this.session_game_group_game_order.Reconnect( dsn );

			this.session_bundles.Reconnect( dsn );

            try
            {
                this.EnforceConstraints = true;
            }
            catch( Exception e )
            {
                Log.log( "Failed to load: " + e.Message );
                DumpTableErrors();
            }
			this.EndInit();

		}

		/// <summary>
		/// Use this to save a schedule, it finishes loading patterns into memory then saves the data.
		/// </summary>
		/// <param name="name"></param>
		public void WriteXML( String name )
		{
			DataTable all_patterns = this.Tables[PatternDescriptionTable.TableName];
			foreach( DataRow pattern in all_patterns.Rows )
			{
                patterns.LoadPatternData( pattern );
			}

			EnforceConstraints = false;
			SuspendForeignTables();
			//ShouldSerializeRelations = true;
			//this.ShouldSerializeTables = true;

			this.WriteXmlSchema( name + ".xsd" );
			this.WriteXml( name );

			MemoryStream ms = new MemoryStream();
			DeflateStream ds = new DeflateStream( ms, CompressionMode.Compress, true );
			this.WriteXml( (Stream)ds );
			ds.Dispose();
			byte[] result = ms.ToArray();
			//System.IO.Compression
			MemoryStream ms2 = new MemoryStream();
			GZipStream gs = new GZipStream( ms2, CompressionMode.Compress, true );
			this.WriteXml( (Stream)gs);
			gs.Dispose();
			byte[] result2 = ms2.ToArray();
		
			ResumeForeignTables();
			try
			{
				EnforceConstraints = true;
			}
			catch( Exception e )
			{
				DumpTableErrors();
				Log.log( "Failed to load.  Dumping what I hvae to bad.xml: " + e.Message );
				WriteXml( "M:\\bad.xml" );
			}
		}

		internal struct tableconstraint
		{
			internal DataTable table;
			internal Constraint constraint;
		}
		List<tableconstraint> suspened_constraint;
		List<DataTable> suspended;
		List<DataRelation> suspended_relations;
		void SuspendForeignTables()
		{
			if( suspended_relations == null )
				suspended_relations = new List<DataRelation>();
			else
				suspended_relations.Clear();
			if( suspended == null )
				suspended = new List<DataTable>();
			else
				suspended.Clear();
			if( suspened_constraint == null )
				suspened_constraint = new List<tableconstraint>();
			else
				suspened_constraint.Clear();
			if( approved_tables != null )
			{
				foreach( DataTable table in Tables )
				{
					if( approved_tables.IndexOf( table ) == -1 )
					{
						suspended.Add( table );
					}
				}
			}
			if( approved_relations != null )
			{
				foreach( DataRelation relation in Relations )
				{
					if( approved_relations.IndexOf( relation ) == -1 )
					{
						suspended_relations.Add( relation );
					}
				}
			}
			foreach( DataRelation relation in suspended_relations )
			{
				Relations.Remove( relation );
			}
		
			//foreach( Constraint c in constraints
			foreach( DataTable table in suspended )
			{
				foreach( Constraint c in table.Constraints )
				{
					UniqueConstraint uc = c as UniqueConstraint;
					if( uc != null && uc.IsPrimaryKey )
						continue;
					tableconstraint tmp;
					tmp.table = table;
					tmp.constraint = c;
					suspened_constraint.Add( tmp );
				}
				foreach( tableconstraint c in suspened_constraint )
				{
					if( c.table == table )
						table.Constraints.Remove( c.constraint );
				}
				Tables.Remove( table );
			}
		}

		void ResumeForeignTables()
		{
			foreach( DataTable table in suspended )
			{
				Tables.Add( table );
				foreach( tableconstraint c in suspened_constraint )
				{
					if( c.table == table )
						table.Constraints.Add( c.constraint );
				}
			}
			foreach( DataRelation relation in suspended_relations )
			{
				Relations.Add( relation );
			}
		}

		internal bool Loading;
		/// <summary>
		/// This is the method to read a schedule... it disables events on all tables until the load completes...
		/// </summary>
		/// <param name="name"></param>
		public bool ReadXML( String name )
		{
			bool success_reading = false;
			Loading = true;
			this.Clear();

			foreach( DataTable table in PersistantTables )
			{
				IXDataTable mtable = table as IXDataTable;
				if( mtable != null )
					mtable.BeginSyncToDatabase();
				table.BeginLoadData();
			}

			try
			{
				//Log.log( "cardset ranges:"+ this.Tables["cardset_ranges"].Rows );
				base.ReadXml( name );
				success_reading = true;
			}
			catch( Exception e )
			{
				Log.log( e.Message );
			}
			try
			{
				this.EnforceConstraints = true;
			}
			catch( Exception e )
			{
				foreach( DataTable table in Tables )
				{
					DumpTableErrors();
				}
				Log.log( "Failed to load.  Dumping what I hvae to bad.xml: " + e.Message );
				WriteXml( "M:\\bad.xml" );
			}
			next_commit_is_sync = true;
			foreach( DataTable table in PersistantTables )
			{
				try
				{
					// this also tries to enforce constraints...
					table.EndLoadData();
				}
				catch( Exception e )
				{
					Log.log( table.TableName + " : " + e.Message );
				}
			}
			if( DataSetReload != null )
				DataSetReload( this );
			Loading = false;
			return success_reading;
		}

		/// <summary>
		/// Hide this method, for this dataset should use other method
		/// </summary>
		/// <param name="name"></param>
		new private void ReadXml( String name )
		{
			base.ReadXml( name );
		}

		List<DataTable> approved_tables;
		List<DataRelation> approved_relations;
		void StoreCoreTables()
		{
			if( approved_tables == null )
				approved_tables = new List<DataTable>();
			foreach( DataTable table in Tables )
			{
				approved_tables.Add( table );
			}
			if( approved_relations == null )
				approved_relations = new List<DataRelation>();
			foreach( DataRelation relation in Relations )
			{
				approved_relations.Add( relation );
			}
		}

		public static void BuildDataset( ScheduleDataSet dataSet )
		{
			dataSet.Tables.CollectionChanged += new System.ComponentModel.CollectionChangeEventHandler( dataSet.Tables_CollectionChanged );
			try
			{
				lock( XDataTable.Lock )
				{
                    new SessionTable( dataSet );

                    new PriceExceptionSet( dataSet );
					new PrizeExceptionSet( dataSet );

                    new SessionMacroTable( dataSet );
					new SessionMacroSchedule( dataSet );
                    new SessionTypeTable( dataSet );
                    new SessionDayMacroSessionTable( dataSet );

					new ColorInfoTable( dataSet ); // has to exist before packs - so packs can relate itself.

					new PackGroupTable( dataSet );
					new GameTable( dataSet );

					new SessionPackGroup( dataSet );

					new PatternDescriptionTable( dataSet );
					new PatternDataTable( dataSet );
					new PatternJavaDataTable( dataSet );
					new PatternMultiDataTable( dataSet );

					new PrizeLevelNames( dataSet );  // has to exist before packs - so packs can relate itself.
					new PackTable( dataSet );
					new BundleTable( dataSet );

					new Dealer( dataSet );
					new CardsetInfo( dataSet );

					new CardsetRange( dataSet );
					new CardsetCards( dataSet );
					new CardsetCards90( dataSet );

					new PackCardsetRange( dataSet );

					new CardsetRangePack( dataSet );

					new PackPrizeLevel( dataSet );

					new PackGroupPrizeRelation( dataSet );

					new SessionGame( dataSet );
					new GamePatternRelation( dataSet );
					new SessionGamePackGroup( dataSet );
					new SessionGameSessionPackGroup( dataSet );

					new PackGroupPackRelation( dataSet );

					new SessionPack( dataSet );  // this is a meta table, packs belong to groups in sessions. (groups are also in games)
					
					new SessionBundleRelation( dataSet );
					new SessionBundlePackRelation( dataSet );

					new PackFacePrizeLevel( dataSet );
					
					new SessionPriceExceptionSet( dataSet );
					new SessionPrizeExceptionSet( dataSet );

					new SessionPriceData( dataSet );
					new SessionPrizeData( dataSet );

					// mark at this point all the tables that are known to be mine in the dataset.
					// additional tables may be added later that for some things I should ignore.
					dataSet.StoreCoreTables();
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( "Initialize of schedule dataset failed\n" + ex.Message+"\n\n" + ex.StackTrace );
				Log.log( ex.Message );
			}


		}

		void FixupTableReferences()
		{
			// dealer is a complex object with tables contained too..
			dealer = this.Tables[Dealer.TableName] as Dealer;

			sessions = this.Tables[SessionTable.TableName] as SessionTable;
			session_types = this.Tables[SessionTypeTable.TableName] as SessionTypeTable;
			pack_groups = this.Tables[PackGroupTable.TableName] as PackGroupTable;
			games = this.Tables[GameTable.TableName] as GameTable;

			game_patterns = this.Tables[GamePatternRelation.TableName] as GamePatternRelation;

			patterns = this.Tables[PatternDescriptionTable.TableName] as PatternDescriptionTable;
			pattern_data = this.Tables[PatternDataTable.TableName] as PatternDataTable;
			pattern_sub_pattern = this.Tables[PatternMultiDataTable.TableName] as PatternMultiDataTable;
			pattern_java_server = this.Tables[PatternJavaDataTable.TableName] as PatternJavaDataTable;
			session_macros = this.Tables[SessionMacroTable.TableName] as SessionMacroTable;
			session_macro_schedule = this.Tables[SessionMacroSchedule.TableName] as SessionMacroSchedule;

			session_macro_sessions = this.Tables[SessionDayMacroSessionTable.TableName] as SessionDayMacroSessionTable;


			packs = this.Tables[PackTable.TableName] as PackTable;

			bundles = this.Tables[BundleTable.TableName] as BundleTable;
			session_bundles = this.Tables[SessionBundleRelation.TableName] as SessionBundleRelation;
			session_packs = this.Tables[SessionPack.TableName] as SessionPack;
			//bundle_packs = this.Tables[BundlePackRelation.TableName] as BundlePackRelation;
			session_bundle_packs = this.Tables[SessionBundlePackRelation.TableName] as SessionBundlePackRelation;


			cardset_info = this.Tables[CardsetInfo.TableName] as CardsetInfo;
			cardset_ranges = this.Tables[CardsetRange.TableName] as CardsetRange;
			cardset_cards = this.Tables[CardsetCards.TableName] as CardsetCards;
			cardset_cards_90 = this.Tables[CardsetCards90.TableName] as CardsetCards90;

			pack_cardset_ranges = this.Tables[PackCardsetRange.TableName] as PackCardsetRange;


            cardset_range_packs = this.Tables[CardsetRangePack.TableName] as CardsetRangePack;

			pack_group_packs = this.Tables[PackGroupPackRelation.TableName] as PackGroupPackRelation;

			session_pack_groups = this.Tables[SessionPackGroup.TableName] as SessionPackGroup;
			game_group_prizes = this.Tables[PackGroupPrizeRelation.TableName] as PackGroupPrizeRelation;

            session_games = this.Tables[SessionGame.TableName] as SessionGame;
			session_game_session_pack_group = this.Tables[SessionGameSessionPackGroup.TableName] as SessionGameSessionPackGroup;
            
			prize_level_names = this.Tables[PrizeLevelNames.TableName] as PrizeLevelNames;
			pack_face_prize_level = this.Tables[PackFacePrizeLevel.TableName] as PackFacePrizeLevel;

			price_exception_sets = this.Tables[PriceExceptionSet.TableName] as PriceExceptionSet;
			session_price_data = this.Tables[SessionPriceData.TableName] as SessionPriceData;
			session_price_exception_sets = this.Tables[SessionPriceExceptionSet.TableName] as SessionPriceExceptionSet;
			
			prize_exception_sets = this.Tables[PrizeExceptionSet.TableName] as PrizeExceptionSet;
			session_prize_data = this.Tables[SessionPrizeData.TableName] as SessionPrizeData;
			session_prize_exception_sets = this.Tables[SessionPrizeExceptionSet.TableName] as SessionPrizeExceptionSet;


			pack_prize_level = this.Tables[PackPrizeLevel.TableName] as PackPrizeLevel;
			colors = this.Tables[ColorInfoTable.TableName] as ColorInfoTable;

		}

		public void Create()
		{
			foreach( DataTable m in PersistantTables )
			{
				DsnSQLUtil.MatchCreate( schedule_dsn, m );
			}
		}

		void FillKeys( List<object> keys, DataTable table, String keyname )
		{
			foreach( DataRow row in table.Rows )
			{
				object o = row[keyname];
				if( keys.IndexOf( o ) == -1 )
					keys.Add( o );
			}
		}

		void FillFromSessions( List<object> session_keys )
		{
			List<object> session_type_keys = new List<object>();
			List<object> session_game_keys = new List<object>();
			List<object> pack_group_keys = new List<object>();
			List<object> pack_keys = new List<object>();
			List<object> cardset_range_keys = new List<object>();
			List<object> dealer_keys = new List<object>();
			List<object> cardset_keys = new List<object>();
			List<object> game_keys = new List<object>();
			List<object> bundle_keys = new List<object>();
			List<object> price_keys = new List<object>();
			List<object> prize_level_keys = new List<object>();
			List<object> prize_keys = new List<object>();
			List<object> session_price_keys = new List<object>();
			List<object> session_prize_keys = new List<object>();
			List<object> session_pack_group_keys = new List<object>();
			List<object> pattern_keys = new List<object>();
			List<object> pattern_data_1_keys = new List<object>();
			List<object> color_keys = new List<object>();

			DsnSQLUtil.FillDataTable( schedule_dsn, sessions, DsnSQLUtil.MakeSetSelector( SessionTable.PrimaryKey, session_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn, session_pack_groups, DsnSQLUtil.MakeSetSelector( SessionTable.PrimaryKey, session_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_games
				, DsnSQLUtil.MakeSetSelector( SessionTable.PrimaryKey, session_keys ) );

			FillKeys( pack_group_keys, session_pack_groups, PackGroupTable.PrimaryKey );
			FillKeys( session_pack_group_keys, session_pack_groups, SessionPackGroup.PrimaryKey );
			FillKeys( session_game_keys, session_games, SessionGame.PrimaryKey );

			FillKeys( color_keys, session_games, ColorInfoTable.PrimaryKey );


			DsnSQLUtil.FillDataTable( schedule_dsn
				, pack_groups
				, DsnSQLUtil.MakeSetSelector( PackGroupTable.PrimaryKey, pack_group_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, game_patterns
				, DsnSQLUtil.MakeSetSelector( SessionGame.PrimaryKey, session_game_keys ) );

			FillKeys( pattern_keys, game_patterns, PatternDescriptionTable.PrimaryKey );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, patterns
				, DsnSQLUtil.MakeSetSelector( PatternDescriptionTable.PrimaryKey, pattern_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, pattern_data
				, DsnSQLUtil.MakeSetSelector( PatternDescriptionTable.PrimaryKey, pattern_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_game_session_pack_group
				, DsnSQLUtil.MakeSetSelector( SessionGame.PrimaryKey, session_game_keys ) );

			//DsnSQLUtil.FillDataTable( schedule_dsn
			//	, session_game_session_pack
			//	, DsnSQLUtil.MakeSetSelector( SessionGame.PrimaryKey, session_game_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, pack_group_packs
				, DsnSQLUtil.MakeSetSelector( PackGroupTable.PrimaryKey, pack_group_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_packs
				, DsnSQLUtil.MakeSetSelector( SessionTable.PrimaryKey, session_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_bundles
				, DsnSQLUtil.MakeSetSelector( SessionTable.PrimaryKey, session_keys ) );
			FillKeys( bundle_keys, session_bundles, BundleTable.PrimaryKey );
			DsnSQLUtil.FillDataTable( schedule_dsn
				, bundles
				, DsnSQLUtil.MakeSetSelector( BundleTable.PrimaryKey, bundle_keys ) );

			bundle_keys.Clear();
			FillKeys( bundle_keys, session_bundles, SessionBundleRelation.PrimaryKey );
			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_bundle_packs
				, DsnSQLUtil.MakeSetSelector( SessionBundleRelation.PrimaryKey, bundle_keys ) );

			FillKeys( pack_keys, pack_group_packs, PackTable.PrimaryKey );
			FillKeys( pack_keys, session_bundle_packs, PackTable.PrimaryKey );
			FillKeys( color_keys, packs, ColorInfoTable.PrimaryKey );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, packs
				, DsnSQLUtil.MakeSetSelector( PackTable.PrimaryKey, pack_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, pack_cardset_ranges
				, DsnSQLUtil.MakeSetSelector( PackTable.PrimaryKey, pack_keys ) );

			FillKeys( cardset_range_keys, pack_cardset_ranges, CardsetRange.PrimaryKey );

			DsnSQLUtil.FillDataTable( schedule_dsn, cardset_ranges
				, DsnSQLUtil.MakeSetSelector( CardsetRange.PrimaryKey, cardset_range_keys ) );

			FillKeys( cardset_keys, cardset_ranges, CardsetInfo.PrimaryKey );
			FillKeys( dealer_keys, cardset_ranges, Dealer.PrimaryKey );

			DsnSQLUtil.FillDataTable( schedule_dsn, cardset_info
				, DsnSQLUtil.MakeSetSelector( CardsetInfo.PrimaryKey, cardset_keys ) );
			DsnSQLUtil.FillDataTable( schedule_dsn, dealer
				, DsnSQLUtil.MakeSetSelector( Dealer.PrimaryKey, dealer_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, pack_prize_level
				, DsnSQLUtil.MakeSetSelector( PackTable.PrimaryKey, pack_keys ) );

			FillKeys( prize_level_keys, pack_prize_level, PrizeLevelNames.PrimaryKey );
			FillKeys( prize_level_keys, cardset_ranges, PrizeLevelNames.PrimaryKey );

			DsnSQLUtil.FillDataTable( schedule_dsn, prize_level_names
				, DsnSQLUtil.MakeSetSelector( PrizeLevelNames.PrimaryKey, prize_level_keys ) );

			//DsnSQLUtil.FillDataTable( schedule_dsn
			//	, prize_level_names
			//	, DsnSQLUtil.MakeSetSelector( PrizeLevelNames.PrimaryKey, prize_level_keys ) );


			// ---    price info --------
			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_price_exception_sets
				, DsnSQLUtil.MakeSetSelector( SessionTable.PrimaryKey, session_keys ) );
			FillKeys( price_keys, session_price_exception_sets, PriceExceptionSet.PrimaryKey );
			FillKeys( session_price_keys, session_price_exception_sets, SessionPriceExceptionSet.PrimaryKey );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, price_exception_sets
				, DsnSQLUtil.MakeSetSelector( PriceExceptionSet.PrimaryKey, price_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_price_data
				, DsnSQLUtil.MakeSetSelector( SessionPriceExceptionSet.PrimaryKey, session_price_keys ) );

			// ---    prize info --------
			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_prize_exception_sets
				, DsnSQLUtil.MakeSetSelector( SessionTable.PrimaryKey, session_keys ) );
			FillKeys( prize_keys, session_prize_exception_sets, PrizeExceptionSet.PrimaryKey );
			FillKeys( session_prize_keys, session_prize_exception_sets, SessionPrizeExceptionSet.PrimaryKey );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, prize_exception_sets
				, DsnSQLUtil.MakeSetSelector( PrizeExceptionSet.PrimaryKey, prize_keys ) );

			DsnSQLUtil.FillDataTable( schedule_dsn
				, session_prize_data
				, DsnSQLUtil.MakeSetSelector( SessionPrizeExceptionSet.PrimaryKey, session_prize_keys ) );

			session_types.Fill();

			DsnSQLUtil.FillDataTable( schedule_dsn
							, colors
							, DsnSQLUtil.MakeSetSelector( ColorInfoTable.PrimaryKey, color_keys ) );
		}

		public void Fill( DateTime bingoday )
		{
			BeginFill();

			List<object> session_keys = new List<object>();

			SessionMacroSchedule.Fill( schedule_dsn, session_macro_schedule, bingoday );
			foreach( DataRow row in session_macro_schedule.Rows )
			{
				DsnSQLUtil.FillDataTable( schedule_dsn, session_macros, SessionMacroTable.PrimaryKey + "='" + row[SessionMacroTable.PrimaryKey] + "'" );
			}

			foreach( DataRow row in session_macros.Rows )
			{
				DsnSQLUtil.FillDataTable( schedule_dsn, session_macro_sessions
								, SessionMacroTable.PrimaryKey + "='" + row[SessionMacroTable.PrimaryKey] + "'" );
			}

			FillKeys( session_keys, session_macro_sessions, SessionTable.PrimaryKey );
			if( session_keys.Count > 0 )
				FillFromSessions( session_keys );

			EndFill();
		}

		public void Fill( object session_key )
		{
			List<object> session_keys = new List<object>();
			DataRow session_row = session_key as DataRow;
			if( session_row != null )
				session_keys.Add( session_row[SessionTable.PrimaryKey] );
			else
				session_keys.Add( session_key );
			BeginFill();

			FillFromSessions( session_keys );

			EndFill();
		}

        void DumpTableErrors()
        {
  			foreach( DataTable table in Tables )
			{
				if( table.HasErrors )
				{
					Log.log( table.TableName + " is in error..." );
					DataRow[] rows = table.GetErrors();
					for( int i = 0; i < rows.Length; i++ )
					{
						for( int j = 0; j < table.Columns.Count; j++ )
						{
							Log.log( "Row" + rows[i].RowState + "[" + i + "][" + table.Columns[j].ColumnName + "] = " + rows[i][j] + " : " + rows[i].RowError );
						}
					}
				}
				//IXDataTable mtable = table as IXDataTable;
			}
        }

		void BeginFill()
		{
			this.Clear();
			foreach( DataTable f in TableFiller )
			{
				IXDataTable xtable = f as IXDataTable;
				if( xtable != null )
					xtable.filling = true;
				f.BeginLoadData();
			}
		}

		void EndFill()
		{
			foreach( DataTable f in TableFiller )
			{
				try
				{
					IXDataTable xtable = f as IXDataTable;
					if( xtable != null )
						xtable.filling = false;
					f.EndLoadData();
				}
				catch( Exception e )
				{
					Log.log( "Failed to load: " + e.Message );
					DumpTableErrors();
				}
			}
		}

		public void Fill()
		{
			BeginFill();
			// use a slightly more complex fill method, 1, if a table has a self filler, use it
			// else use default fill all
			// and then if there is a default fill proc, call it - it will add default data if rows=0
			foreach( TableDefaultFiller f in TableFillers )
			{
				Type type = f.table.GetType();
				if( f.real_fill_method != null )
				{
					try
					{
						type.InvokeMember( f.real_fill_method,
									   BindingFlags.Default | BindingFlags.InvokeMethod,
									   null,
									   f.table,
									   new object[] { schedule_dsn } );
					}
					catch
					{
						type.InvokeMember( f.real_fill_method,
									   BindingFlags.Default | BindingFlags.InvokeMethod,
									   null,
									   f.table,
									   null );
					}
				}
				else
				{
					DsnSQLUtil.FillDataTable( schedule_dsn, f.table, null, null );
				}

				bool fill_ok = false;
				if( f.method_name == "DefaultFill" )
				{
					if( f.table.Rows.Count == 0 )
						fill_ok = true;
				}
				else
					fill_ok = true;

				if( fill_ok )
				if( f.method_name != null )
					type.InvokeMember( f.method_name,
								   BindingFlags.Default | BindingFlags.InvokeMethod,
								   null,
								   f.table,
								   null );

			}
			EndFill();
		}


		public void Commit()
		{
			schedule_dsn.BeginTransaction();
			foreach( DataTable m in PersistantTables )
			{
				if( next_commit_is_sync )
				{
					IXDataTable mtable = m as IXDataTable;
					if( mtable != null )
						mtable.SyncToDatabase( schedule_dsn );
				}
				else
				{
					Log.log( "Commiting " + m.ToString() );
					DsnSQLUtil.CommitChanges( schedule_dsn, m );
				}
			}
			schedule_dsn.EndTransaction();
			AcceptChanges();
			next_commit_is_sync = false;

	
		}


		public DsnConnection schedule_dsn;

		void GrabRelatedRows( DataRow row, String ChildRelation )
		{
			//foreach( DataRelation dr in row.Table.ChildRelations )
			{
				DataRow[] children = row.GetChildRows( ChildRelation );
				//Log.log( "Grabbing:" + dr.ToString() );
				if( children.Length > 0 )
				{
					IXDataTable source;
					source = this.Tables[children[0].Table.TableName] as IXDataTable;
					//Log.log( "In table:" + source.TableName );
					foreach( DataRow dr_clone in children )
					{
						source.AddClonedRow( dr_clone );
					}
				}
			}
		}

		void FillFromSessionDay( DsnConnection database_cache_dsn
			, DateTime bingoday
			, int session
			, bool create_if_not_exists = false )
		{
			// Purely to reload a snapshot into a working schedule(?)

			OpenSkieSessionState.SessionStateDataset session_state_dataset = new OpenSkieSessionState.SessionStateDataset();
			session_state_dataset.Fill( database_cache_dsn, bingoday );
			DataRow[] session_day_session = session_state_dataset.session_day_sessions.Select( "session_order=" + session );
			if( session_day_session.Length > 0 )
			{
				//int snapshot_session = Convert.ToInt32( session_day_session[0]["snapshot_session_id"] );
				LoadScheduleFromSessionId( session_day_session[0]["snapshot_session_id"] );
			}
			else
			{
				throw new Exception( "Session does not exist" );
			}
		}

		public ScheduleDataSet( DsnConnection database_cache_dsn
			, DateTime bingoday
			, int session
			)
		{
			schedule_dsn = database_cache_dsn;
			BuildDataset( this );
			snapshot = true;
			FillFromSessionDay( database_cache_dsn, bingoday, session );
		}

		void LoadScheduleFromSessionRow( DataRow session_row )
		{
			List<object> session_keys = new List<object>();

			session_keys.Add( session_row[SessionTable.PrimaryKey] );

			FillFromSessions( session_keys );
		}


		DataRow LoadScheduleFromSessionId( object id )
		{
			sessions.Fill( SessionTable.PrimaryKey + "=" + DsnSQLUtil.GetSQLValue( schedule_dsn, sessions.Columns[SessionTable.PrimaryKey], id ) );
			if( sessions.Rows.Count > 0 )
			{
				LoadScheduleFromSessionRow( sessions.Rows[0] );
				return sessions.Rows[0];
			}
			return null;
		}

		public ScheduleDataSet( DsnConnection database_cache_dsn
			, ScheduleDataSet schedule
			, DateTime bingoday
			, int session

			, DataRow session_info
			, DataRow price_exception_info
			, DataRow prize_exception_info
			, out DataRow snapshot_result_session
			)
			: base()
		{
			// set this flag so tables can remove the unique flag on name columns.

			SetupScheduleOptions();
			this.DataSetName = "Bingo Schedule";

			BuildDataset( this );
			// have to set snapshot after building the dataset; requires persistantTables to be filled in.
			snapshot = true;


			FixupTableReferences();

			{
				// Remove unique on name columns.
				foreach( DataTable table in schedule.Tables )
				{
					DataColumn dc_name = table.Columns[XDataTable.Name( table.TableName )];
					if( dc_name != null )
					{
						dc_name.Unique = false;
					}
				}
			}

			// add this so we can recover snapshots...
			DataColumn dc = this.session_macro_schedule.Columns.Add( "open_date", typeof( DateTime ) );
			dc.ExtendedProperties.Add( "Extra Type", "date" );
			//dc.Namespace = "date";

			this.session_macro_schedule.Columns.Add( SessionTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
			// save this out outer most level too... 
			this.session_macro_schedule.Columns.Add( "session", typeof( int ) );

			schedule_dsn = database_cache_dsn;

			DsnSQLUtil.CreateDataTable( database_cache_dsn, this );

			OpenSkieSessionState.SessionStateDataset session_state_dataset = new OpenSkieSessionState.SessionStateDataset();
			session_state_dataset.Fill( database_cache_dsn, bingoday );
			DataRow[] session_day_session = session_state_dataset.session_day_sessions.Select( "session_order=" + session );
			object session_id = null;
			if( session_day_session[0]["snapshot_session_id"] != DBNull.Value )
				session_id = session_day_session[0]["snapshot_session_id"];
			if( session_day_session.Length > 0 && session_id != null && Convert.ToInt32( session_id ) != 0 )
			{
				//int snapshot_session = Convert.ToInt32( session_day_session[0]["snapshot_session_id"] );
				LoadScheduleFromSessionId( session_day_session[0]["snapshot_session_id"] );
				snapshot_result_session = sessions.Rows[0];
			}
			else
			{
				Dictionary<DataRow, DataRow> pack_group_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> session_pack_group_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> game_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> pack_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> cardset_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> cardset_dealer_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> cardset_range_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> item_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> session_item_map = new Dictionary<DataRow, DataRow>();

				Dictionary<DataRow, DataRow> prize_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> color_map = new Dictionary<DataRow, DataRow>();
				Dictionary<DataRow, DataRow> pattern_map = new Dictionary<DataRow, DataRow>();

				DataRow session_macro = session_macro_schedule.NewRow();
				session_macro[SessionTable.PrimaryKey] = session_info[SessionTable.PrimaryKey];
				session_macro["open_date"] = bingoday;
				session_macro["session"] = session;
				session_macro_schedule.Rows.Add( session_macro );

				DataRow session_price_exception = null;
				foreach( DataRow price_row in session_info.GetChildRows( "session_has_price_exception_set" ) )
				{
					if( price_row[PriceExceptionSet.PrimaryKey].Equals( price_exception_info[PriceExceptionSet.PrimaryKey] ) )
					{
						session_price_exception = price_row;
						break;
					}
				}
				DataRow session_prize_exception = null;
				foreach( DataRow prize_row in session_info.GetChildRows( "session_has_prize_exception_set" ) )
				{
					if( prize_row[PrizeExceptionSet.PrimaryKey].Equals( prize_exception_info[PrizeExceptionSet.PrimaryKey] ) )
					{
						session_prize_exception = prize_row;
						break;
					}
				}
				session_prize_exception_sets.filling = true;
				session_price_exception_sets.filling = true;

				snapshot_result_session = sessions.Clone( session_info );
				sessions.Rows.Add( snapshot_result_session );

				session_prize_exception_sets.filling = false;
				session_price_exception_sets.filling = false;

				DataRow cloned_prize_exception = prize_exception_sets.AddClonedRow( session_prize_exception.GetParentRow( session_prize_exception_sets.ParentOfChild ) );
				DataRow cloned_session_prize_exception = session_prize_exception_sets.CloneGroupMember( snapshot_result_session, cloned_prize_exception, session_prize_exception );

				DataRow cloned_price_exception = price_exception_sets.AddClonedRow( session_price_exception.GetParentRow( session_price_exception_sets.ParentOfChild ) );
				DataRow cloned_session_price_exception = session_price_exception_sets.CloneGroupMember( snapshot_result_session, cloned_price_exception, session_price_exception );


				DataRow session_row = session_info;
				DataRow[] rows = session_macro.GetChildRows( "session_on_day" );


				if( session_row != null )
				{
					foreach( DataRow session_pack_group in session_row.GetChildRows( session_pack_groups.ChildrenOfParent ) )
					{
						DataRow pack_group = session_pack_group.GetParentRow( session_pack_groups.ParentOfChild );
						DataRow new_pack_group = pack_groups.AddClonedRow( pack_group, true );
						pack_group_map.Add( pack_group, new_pack_group );
						DataRow new_session_pack_group = session_pack_groups.CloneGroupMember( snapshot_result_session, new_pack_group, session_pack_group );
						session_pack_group_map.Add( session_pack_group, new_session_pack_group );

						foreach( DataRow pack_group_pack in pack_group.GetChildRows( this.pack_group_packs.ChildrenOfParent ) )
						{
							DataRow pack_info = pack_group_pack.GetParentRow( this.pack_group_packs.ParentOfChild );

							DataRow cloned_pack;
							DataRow pack_is_color = pack_info.GetParentRow( "pack_is_color" );

							if( pack_is_color != null && !color_map.ContainsKey( pack_is_color ) )
								color_map.Add( pack_is_color, colors.AddClonedRow( pack_is_color ) );

							if( !pack_map.ContainsKey( pack_info ) )
								pack_map.Add( pack_info, this.packs.AddClonedRow( pack_info, pack_is_color == null ? null : color_map[pack_is_color] ) );
							cloned_pack = pack_map[pack_info];

							pack_group_packs.CloneGroupMember( new_pack_group, cloned_pack, pack_group_pack );

							{
								DataRow[] ranges = pack_info.GetChildRows( this.pack_cardset_ranges.ChildrenOfParent );
								foreach( DataRow range in ranges )
								{
									DataRow cardset_range = range.GetParentRow( this.pack_cardset_ranges.ParentOfChild );
									DataRow cardset = cardset_range.GetParentRow( "cardset_has_cardset_range" );
									DataRow dealer = cardset_range.GetParentRow( "cardset_range_has_dealer" );

									DataRow new_dealer;
									if( !cardset_map.TryGetValue( dealer, out new_dealer ) )
										cardset_map.Add( dealer, new_dealer = this.dealer.AddClonedRow( dealer ) );

									DataRow new_cardset;
									if( !cardset_map.TryGetValue( cardset, out new_cardset ) )
										cardset_map.Add( cardset, new_cardset = this.cardset_info.AddClonedRow( cardset ) );

									DataRow new_cardset_range;
									if( !cardset_range_map.TryGetValue( cardset_range, out new_cardset_range ) )
										cardset_range_map.Add( cardset_range, new_cardset_range = this.cardset_ranges.AddClonedRow( cardset_range, new_cardset, new_dealer ) );

									this.pack_cardset_ranges.CloneGroupMember( cloned_pack, new_cardset_range, range );
								}
							}
							{
								DataRow[] prizes = pack_info.GetChildRows( pack_prize_level.ChildrenOfParent );
								foreach( DataRow prize in prizes )
								{
									DataRow prize_info = prize.GetParentRow( pack_prize_level.ParentOfChild );
									if( !prize_map.ContainsKey( prize_info ) )
										prize_map.Add( prize_info, this.prize_level_names.AddClonedRow( prize_info ) );
									this.pack_prize_level.CloneGroupMember( pack_map[pack_info], prize_map[prize_info], prize );
								}
							}

						}
					}

					DataRow[] copy_session_games = session_row.GetChildRows( this.session_games.ChildrenOfParent );
					foreach( DataRow game in copy_session_games )
					{
						DataRow cloned_session_game;
						cloned_session_game = this.session_games.CloneGroupMember( snapshot_result_session, null, game );

						game_map.Add( game, cloned_session_game );

						DataRow[] game_pack_groups = game.GetChildRows( this.session_game_session_pack_group.ChildrenOfParent );
						foreach( DataRow pack_group in game_pack_groups )
						{
							DataRow session_pack_group = pack_group.GetParentRow( session_game_session_pack_group.ParentOfChild );
							session_game_session_pack_group.CloneGroupMember( cloned_session_game
								, session_pack_group_map[session_pack_group]
								, pack_group );

						}
						//DataRow game_info = game.GetParentRow( this.session_games.ParentOfChild );
						//if( this.games.AddClonedRow( game_info ) != null )
						{
							DataRow[] patterns = game.GetChildRows( game_patterns.ChildrenOfParent );
							foreach( DataRow pattern in patterns )
							{
								DataRow pattern_info = pattern.GetParentRow( game_patterns.ParentOfChild );
								if( !pattern_map.ContainsKey( pattern_info ) )
								{
									DataRow new_pattern;
									pattern_map.Add( pattern_info, new_pattern = this.patterns.AddClonedRow( pattern_info ) );

									DataRow[] pattern_data = schedule.patterns.LoadPatternData( pattern_info );
									if( pattern_data != null )
										foreach( DataRow data in pattern_data )
										{
											this.pattern_data.AddClonedRow( data, new_pattern );
										}
								}

								this.game_patterns.CloneGroupMember( cloned_session_game, pattern_map[pattern_info], pattern );
							}
						}
					}

					DataRow[] copy_session_items = session_row.GetChildRows( this.session_bundles.ChildrenOfParent );
					foreach( DataRow session_item in copy_session_items )
					{
						DataRow item = session_item.GetParentRow( session_bundles.ParentOfChild );

						DataRow cloned_session_item = null;
						if( !item_map.ContainsKey( item ) )
						{
							DataRow cloned_item = bundles.AddClonedRow( item );
							item_map.Add( item, cloned_item );
						}
						DataRow new_session_bundle = session_bundles.CloneGroupMember( snapshot_result_session
							, item_map[item]
							, session_item );
						session_item_map.Add( session_item, new_session_bundle );
						foreach( DataRow session_item_pack in session_item.GetChildRows( session_bundle_packs.ChildrenOfParent ) )
						{
							DataRow item_pack = session_item_pack.GetParentRow( session_bundle_packs.ParentOfChild );
							if( !pack_map.ContainsKey( item_pack ) )
								pack_map.Add( item_pack, this.packs.AddClonedRow( item_pack, true ) );

							session_bundle_packs.CloneGroupMember( new_session_bundle
								, pack_map[item_pack]
								, session_item_pack );
						}
					}

					foreach( DataRow session_price_bundle in session_price_exception.GetChildRows( SessionPriceExceptionSet.TableName + "_has_price" ) )
					{
						DataRow session_bundle = session_price_bundle.GetParentRow( SessionBundleRelation.TableName + "_has_price" );
						DataRow prize_level_name = session_price_bundle.GetParentRow( PrizeLevelNames.TableName + "_has_price" );
						session_price_data.AddClonedRow( cloned_session_price_exception
							, session_item_map[session_bundle]
							, prize_level_name == null ? null : prize_map[prize_level_name]
							, session_price_bundle
							);
					}

					foreach( DataRow session_prize_payout in session_prize_exception.GetChildRows( SessionPrizeExceptionSet.TableName + "_has_prize" ) )
					{
						DataRow session_game = session_prize_payout.GetParentRow( SessionGame.TableName + "_has_prize" );
						DataRow prize_level_name = session_prize_payout.GetParentRow( PrizeLevelNames.TableName + "_has_prize" );
						session_prize_data.AddClonedRow( cloned_session_prize_exception
							, game_map[session_game]
							, prize_map[prize_level_name]
							, session_prize_payout
							);
					}
				}
				Commit();
				/*
				foreach( TableDefaultFiller f in TableFillers )
				{
					MySQLDataTable.AppendToDatabase( database_cache_dsn, f.table );
				}
				*/

			}
		}

		/// <summary>
		/// This version of the schedule dataset contains only the specific schedule for a day and session.
		/// This is backed up when created.
		/// </summary>
		/// <param name="odbc"></param>
		/// <param name="day"></param>
		/// <param name="session"></param>
		public ScheduleDataSet( xperdex.classes.DsnConnection odbc, DateTime day, int session, bool reload )
			: base()
		{
			SetupScheduleOptions();
			this.DataSetName = "Bingo Schedule";
			BuildDataset( this );

			FixupTableReferences();
			schedule_dsn = odbc;

			FillFromSessionDay( odbc, day, session, !reload );
		}

		/// <summary>
		/// Deletes a relation from tables...
		/// </summary>
		/// <param name="row"></param>
		public void DeleteSelectionFromTable( DataRow row )
		{
			DataTable table3 = row.Table;
			if( String.Compare( row.Table.TableName, 0, "current_", 0, 8 ) == 0 )
			{
				table3 = table3.DataSet.Tables[row.Table.TableName.Substring( 8 )];
			}
			DataRow[] rows = table3.Select( row.Table.Columns[1].ColumnName + "=" + row[1]
					+ " and "
					+ row.Table.Columns[2].ColumnName + "=" + row[2] );
			if( rows.Length > 0 )
			{
				for( int i = 0; i < rows.Length; i++ )
				{
					rows[i].Delete();
				}
			}
			if( !table3.Equals( row.Table ) )
			{
				row.Delete();
			}
			else
			{
			}
		}

		/// <summary>
		/// Result with the session_info data row for a given bingoday and session_number
		/// </summary>
		/// <param name="bingoday">date before or equal for a particular session, so basically the
		/// latest date a session might be applicable for.</param>
		/// <param name="session_number">Obvious...</param>
		/// <returns></returns>
		public DataRow GetSession( DateTime bingoday, int session_number )
		{
			if( session_macro_schedule.Rows.Count == 0 )
			{
				if( schedule_dsn != null )
				{
					DsnSQLUtil.FillDataTable( schedule_dsn, sessions );
					DsnSQLUtil.FillDataTable( schedule_dsn, session_macros );
					DsnSQLUtil.FillDataTable( schedule_dsn, session_macro_sessions );
					DsnSQLUtil.FillDataTable( schedule_dsn, session_macro_schedule );
				}
			}
            DataRow session_macro = session_macro_schedule.GetMacroScheduleRow( bingoday );
            return session_macro_sessions.GetSession( session_macro, session_number );
		}


		bool have_inventory = false;

		public void LinkInventory()
		{
			if( !have_inventory )
			{
				new ItemDescription( this, schedule_dsn );
				new ItemInstance( this, schedule_dsn );
				new ItemPackMap( schedule_dsn, this );

				have_inventory = true;
			}
		}

		public static void ConvertSchedule( ScheduleDataSet new_schedule, ScheduleDataSet original )
		{
			if( original == null )
				return;
			if( new_schedule == null )
				return;

			new_schedule.Clear();

			// load all pattern bits
			original.patterns.LoadPatternData( null );

			DataTable source;
			DataTable dest;
			String parent1;
			String parent2;

			//-------------  Copy root data tables ------------------

			source = original.session_macros;
			dest = new_schedule.session_macros;
			source.Columns.Add( "_conversion_", new_schedule.session_macros.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[SessionMacroTable.NameColumn] = row[SessionMacroTable.NameColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[SessionMacroTable.PrimaryKey];
			}

			source = original.sessions;
			dest = new_schedule.sessions;
			source.Columns.Add( "_conversion_", new_schedule.sessions.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[SessionTable.NameColumn] = row[SessionTable.NameColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[SessionTable.PrimaryKey];
			}

			source = original.pack_groups;
			dest = new_schedule.pack_groups;
			source.Columns.Add( "_conversion_", new_schedule.pack_groups.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[PackGroupTable.NameColumn] = row[PackGroupTable.NameColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[PackGroupTable.PrimaryKey];
			}

			source = original.games;
			dest = new_schedule.games;
			source.Columns.Add( "_conversion_", new_schedule.games.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[GameTable.NameColumn] = row[GameTable.NameColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[GameTable.PrimaryKey];
			}

			source = original.game_patterns;
			dest = new_schedule.game_patterns;
			source.Columns.Add( "_conversion_", new_schedule.game_patterns.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				//newrow[GamePatternRelation.NameColumn] = row[GamePatternRelation.NameColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[XDataTable.ID(source)];
			}

			source = original.session_games;
			dest = new_schedule.session_games;
			source.Columns.Add( "_conversion_", new_schedule.session_games.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[XDataTable.ID( source )];
			}

			source = original.packs;
			dest = new_schedule.packs;
			source.Columns.Add( "_conversion_", new_schedule.packs.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[PackTable.NameColumn] = row[PackTable.NameColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[PackTable.PrimaryKey];
			}

			source = original.patterns;
			dest = new_schedule.patterns;
			source.Columns.Add( "_conversion_", new_schedule.patterns.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[PatternDescriptionTable.NameColumn] = row[PatternDescriptionTable.NameColumn];
				foreach( String colname in PatternDescriptionTable.DataColumns )
					newrow[colname] = row[colname];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[PatternDescriptionTable.PrimaryKey];
			}

			source = original.prize_level_names;
			dest = new_schedule.prize_level_names;
			source.Columns.Add( "_conversion_", new_schedule.prize_level_names.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[PrizeLevelNames.NameColumn] = row[PrizeLevelNames.NameColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[PrizeLevelNames.PrimaryKey];
			}

			source = original.cardset_info;
			dest = new_schedule.cardset_info;
			source.Columns.Add( "_conversion_", new_schedule.cardset_info.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				//newrow[CardsetInfo.NameColumn] = row[CardsetInfo.NameColumn];
				foreach( String colname in CardsetInfo.DataColumns )
					newrow[colname] = row[colname];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[CardsetInfo.PrimaryKey];
			}

			source = original.dealer;
			dest = new_schedule.dealer;
			source.Columns.Add( "_conversion_", new_schedule.dealer.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				newrow[Dealer.NameColumn] = row[Dealer.NameColumn];
				foreach( String colname in Dealer.DataColumns )
					newrow[colname] = row[colname];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[Dealer.PrimaryKey];
			}

			//------------- BEGIN Related Data ---------------------------------

			source = original.session_macro_schedule;
			dest = new_schedule.session_macro_schedule;
			foreach( DataRow row in source.Rows )
			{
				DataRow related = row.GetParentRow( "session_macro_on_day" );
				DataRow newrow = dest.NewRow();

				newrow["starting_date"] = row["starting_date"];
				newrow[SessionMacroTable.PrimaryKey] = related["_conversion_"];
				dest.Rows.Add( newrow );
			}


			source = original.session_macro_sessions;
			dest = new_schedule.session_macro_sessions;
			foreach( DataRow row in source.Rows )
			{
				DataRow related1 = row.GetParentRow( "session_macro_has_session" );
				DataRow related2 = row.GetParentRow( "session_in_session_macro" );
				DataRow newrow = dest.NewRow();

				newrow[SessionMacroTable.PrimaryKey] = related1["_conversion_"];
				newrow[SessionTable.PrimaryKey] = related2["_conversion_"];
				newrow[SessionDayMacroSessionTable.NumberColumn] = row[SessionDayMacroSessionTable.NumberColumn];
				newrow[SessionDayMacroSessionTable.NameColumn] = row[SessionDayMacroSessionTable.NameColumn];
				dest.Rows.Add( newrow );
			}


			parent1 = "session";
			parent2 = "game_group";
			source = original.session_pack_groups;
			dest = new_schedule.session_pack_groups;
			source.Columns.Add( "_conversion_", new_schedule.session_pack_groups.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow related1 = row.GetParentRow( parent1 + "_has_" + parent2 );
				DataRow related2 = row.GetParentRow( parent2 + "_in_" + parent1 );
				DataRow newrow = dest.NewRow();

				newrow[SessionTable.PrimaryKey] = related1["_conversion_"];
				newrow[PackGroupTable.PrimaryKey] = related2["_conversion_"];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[SessionPackGroup.PrimaryKey];
			}

#if asdfasfd
			parent1 = "game_group";
			parent2 = "game";
			source = original.game_group_games;
			dest = new_schedule.game_group_games;
			source.Columns.Add( "_conversion_", new_schedule.game_group_games.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow related1 = row.GetParentRow( parent1 + "_has_" + parent2 );
				DataRow related2 = row.GetParentRow( parent2 + "_in_" + parent1 );
				DataRow newrow = dest.NewRow();

				newrow[PackGroupTable.PrimaryKey] = related1["_conversion_"];
				newrow[GameTable.PrimaryKey] = related2["_conversion_"];
				newrow[GameGroupGameRelation.NumberColumn] = row[GameGroupGameRelation.NumberColumn];
				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[GameGroupGameRelation.PrimaryKey];
			}
#endif

			parent1 = "game_group";
			parent2 = "prize_level";
			source = original.game_group_prizes;
			dest = new_schedule.game_group_prizes;
            if( source != null && dest != null )
                foreach( DataRow row in source.Rows )
			    {
				    DataRow related1 = row.GetParentRow( parent1 + "_has_" + parent2 );
				    DataRow related2 = row.GetParentRow( parent2 + "_in_" + parent1 );
				    DataRow newrow = dest.NewRow();

				    newrow[PackGroupTable.PrimaryKey] = related1["_conversion_"];
				    newrow[PrizeLevelNames.PrimaryKey] = related2["_conversion_"];
				    newrow[PackGroupPrizeRelation.NumberColumn] = row[PackGroupPrizeRelation.NumberColumn];
				    dest.Rows.Add( newrow );
			    }

			if( true )
			{
				parent1 = "game_group";
				parent2 = "pack";
				source = original.pack_group_packs;
				dest = new_schedule.pack_group_packs;
				if( source != null && dest != null )
				{
					foreach( DataRow row in source.Rows )
					{
						DataRow related1 = row.GetParentRow( parent1 + "_has_" + parent2 );
						DataRow related2 = row.GetParentRow( parent2 + "_in_" + parent1 );
						DataRow newrow = dest.NewRow();

						newrow[PackGroupTable.PrimaryKey] = related1["_conversion_"];
						newrow[GameTable.PrimaryKey] = related2["_conversion_"];
						//newrow[GameGroupGameRelation.NumberColumn] = row[GameGroupGameRelation.NumberColumn];
						dest.Rows.Add( newrow );
					}
				}
			}
			else
			{
			}


			parent1 = "session_game";
			parent2 = "pattern";
			source = original.game_patterns;
			dest = new_schedule.game_patterns;
			foreach( DataRow row in source.Rows )
			{
				DataRow related1 = row.GetParentRow( parent1 + "_has_" + parent2 );
				DataRow related2 = row.GetParentRow( parent2 + "_in_" + parent1 );
				DataRow[] newrows = dest.Select( XDataTable.ID(dest) + "='" + row["_conversion_"] + "'" );
				DataRow newrow = newrows[0];

				newrow[SessionGame.PrimaryKey] = related1["_conversion_"];
				newrow[PatternDescriptionTable.PrimaryKey] = related2["_conversion_"];
				//dest.Rows.Add( newrow );
			}


			source = original.cardset_ranges;
			dest = new_schedule.cardset_ranges;
			source.Columns.Add( "_conversion_", new_schedule.cardset_ranges.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow related1 = row.GetParentRow( CardsetRange.CardsetInfoRelationName );
				DataRow related2 = row.GetParentRow( CardsetRange.DealerRelationName );

				DataRow newrow = dest.NewRow();

				newrow[CardsetRange.NameColumn] = row[CardsetRange.NameColumn];
				foreach( String colname in CardsetRange.DataColumns )
					newrow[colname] = row[colname];

				newrow[CardsetInfo.PrimaryKey] = related1["_conversion_"];
				newrow[Dealer.PrimaryKey] = related2["_conversion_"];

				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[CardsetRange.PrimaryKey];
			}


			source = original.pack_cardset_ranges;
			source.Columns.Add( "_conversion_", new_schedule.pack_cardset_ranges.AutoKeyType );
			dest = new_schedule.pack_cardset_ranges;
			dest.Rows.Clear();
			parent1 = "pack";
			parent2 = "cardset_range";
			foreach( DataRow row in source.Rows )
			{
				DataRow related1 = row.GetParentRow( parent1 + "_has_" + parent2 );
				DataRow related2 = row.GetParentRow( parent2 + "_in_" + parent1 );

				DataRow newrow = dest.NewRow();

				newrow[PackTable.PrimaryKey] = related1["_conversion_"];
				newrow[CardsetRange.PrimaryKey] = related2["_conversion_"];

				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[PackCardsetRange.PrimaryKey];
			}


			//source = original.session_game_group_game_order;
			//dest = new_schedule.session_game_group_game_order;

			// these are some other rows that are auto-built based on session-game_group-game
			//new_schedule.current_session_prize_level.Rows.Clear();
			//new_schedule.session_prize_level.Rows.Clear();
			//new_schedule.current_session_game_group_game_order.Rows.Clear();

			dest.Rows.Clear();

#if asdfasdf
			source.Columns.Add( "_conversion_", new_schedule.pack_cardset_ranges.AutoKeyType );
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();

				int n;
				int max = SessionGameGroupGameOrder.Relations.GetLength( 0 );
				for( n = 0; n < max; n++ )
				{
					DataRow parent = row.GetParentRow( SessionGameGroupGameOrder.Relations[n,0] );
					if( parent != null )
						newrow[SessionGameGroupGameOrder.Relations[n, 1]] = parent["_conversion_"];
				}

				foreach( String colname in SessionGameGroupGameOrder.DataColumns )
					newrow[colname] = row[colname];

				dest.Rows.Add( newrow );
				row["_conversion_"] = newrow[SessionGameGroupGameOrder.PrimaryKey];
			}
#endif

			//source = original.session_prize_level;
			//dest = new_schedule.session_prize_level;
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				DataRow related = row.GetParentRow( "pattern_has_bits" );

				foreach( String colname in PatternDataTable.DataColumns )
					newrow[colname] = row[colname];

				dest.Rows.Add( newrow );
			}



			source = original.pattern_data;
			dest = new_schedule.pattern_data;
			foreach( DataRow row in source.Rows )
			{
				DataRow newrow = dest.NewRow();
				DataRow related = row.GetParentRow( "pattern_has_bits" );

				foreach( String colname in PatternDataTable.DataColumns )
					newrow[colname] = row[colname];

				dest.Rows.Add( newrow );
			}


		}

		/// <summary>
		/// Return a session_info row that matches the name specified
		/// </summary>
		/// <param name="session_name"></param>
		/// <returns>NULL if no session</returns>
		public DataRow GetSession( string session_name )
		{
			DataRow[] result = sessions.Select( SessionTable.NameColumn + "='" + session_name + "'" );
            if( result.Length > 0 )
                return result[ 0 ];
			return null;// sessions.NewSession( session_name );
			/*
            MySQLDataTable game_table = new MySQLDataTable( StaticDsnConnection.dsn,
                            "SELECT * from bingo_sched3_session_info where session_name='" + session_name + "'" );

			if( game_table.Rows.Count > 0 )
				return game_table.Rows[0];
			*/
			return null;
		}

		/// <summary>
		/// Return a session_info row that matches the name specified
		/// </summary>
		/// <param name="session_name"></param>
		/// <returns>NULL if no cardset</returns>
		public DataRow GetCardset( string cardset_name )
		{
			DataRow[] result = cardset_info.Select( CardsetInfo.NameColumn + "='" + cardset_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}
		/// <summary>
		/// Return a session_macro_info row for the name specified
		/// </summary>
		/// <param name="session_macro_name"></param>
		/// <returns>NULL if no session macro</returns>
		public DataRow GetSessionMacro( string session_macro_name )
		{
			DataRow[] result = session_macros.Select( SessionMacroTable.NameColumn + "='" + session_macro_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}

		/// <summary>
		/// Return a pack_info row for the name spacieifed
		/// </summary>
		/// <param name="pack_name">the name of the pack to result with the row</param>
		/// <returns>NULL if no pack</returns>
		public DataRow GetPack( string pack_name )
		{
			DataRow[] result = packs.Select( PackTable.NameColumn + "='" + pack_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}


		/// <summary>
		/// Return a bundle_info row for the name spacieifed
		/// </summary>
		/// <param name="pack_name">the name of the pack to result with the row</param>
		/// <returns>NULL if no pack</returns>
		public DataRow GetItem( string item_name )
		{
			DataRow[] result = bundles.Select( BundleTable.NameColumn + "='" + item_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}

		/// <summary>
		/// Return a game_info row for the name specified
		/// </summary>
		/// <param name="game_name">name of the game to return with</param>
		/// <returns>NULL if no game</returns>
		public DataRow GetGame( DataRow session, int game_number )
		{
			return session_games.GetGame( session, game_number );
		}

		/// <summary>
		/// Return a game_info row for the name specified
		/// </summary>
		/// <param name="game_name">name of the game to return with</param>
		/// <returns>NULL if no game</returns>
		public DataRow GetSessionGame( string game_name )
		{
			String select = GameTable.NameColumn + "=" + DsnSQLUtil.GetSQLValue( null, typeof( String ), game_name );
			DataRow[] result = games.Select( select );
			if( result.Length > 0 )
				return result[0];
			return null;
		}

		/// <summary>
		/// Return a game_group_info row for the name specified
		/// </summary>
		/// <param name="game_group_name">name of the game to return with</param>
		/// <returns>NULL if no game</returns>
		public DataRow GetPackGroup( string game_group_name )
		{
			String select = PackGroupTable.NameColumn + "=" + DsnSQLUtil.GetSQLValue( null, typeof( String ), game_group_name );
			DataRow[] result = pack_groups.Select( select );
			if( result.Length > 0 )
				return result[0];
			return null;
		}

		/// <summary>
		/// returns a color_info row for the specified name
		/// </summary>
		/// <param name="color_name">name of the color to get</param>
		/// <returns>NULL if the color name does not exist</returns>
		public DataRow GetColor( string color_name )
		{
			DataRow[] result = colors.Select( ColorInfoTable.NameColumn + "='" + color_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}

		/// <summary>
		/// returns a prize_level_name row for the specified name
		/// </summary>
		/// <param name="prize_level_name">name of the prize level to get</param>
		/// <returns>NULL if the prize level name does not exist</returns>
		public DataRow GetPrizeLevel( string prize_level_name )
		{
			DataRow[] result = prize_level_names.Select( PrizeLevelNames.NameColumn + "='" + prize_level_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}

		/// <summary>
		/// returns a prize_exception_set row for the specified name
		/// </summary>
		/// <param name="prize_level_name">name of the prize exception to get</param>
		/// <returns>NULL if the prize exception does not exist</returns>
		public DataRow GetPrizeException( string prize_exception_name )
		{
			DataRow[] result = prize_exception_sets.Select( PrizeExceptionSet.NameColumn + "='" + prize_exception_name + "'" );
			if( result.Length > 0 )
				return result[0];
			return null;
		}

		/// <summary>
		/// Returns a bundle_info row for specified anme
		/// </summary>
		/// <param name="bundle_name">name of bundle to get</param>
		/// <returns>null if bundle does not exist</returns>
		public DataRow GetBundle( DataRow session, string bundle_name )
		{
			DataRow[] result = bundles.Select( BundleTable.NameColumn + "='" + bundle_name + "'" );
			if( result.Length > 0 )
			{
				DataRow[] relative = result[0].GetChildRows( "session_has_bundle" );
				foreach( DataRow row in relative )
				{
					if( row[SessionTable.PrimaryKey].Equals( session[SessionTable.PrimaryKey] ) )
						return row;
				}
			}
			return null;
		}

		public static void MergePatterns( ScheduleDataSet new_schedule, ScheduleDataSet original )
		{
			if( original == null )
				return;
			if( new_schedule == null )
				return;

			foreach( DataRow pattern in new_schedule.patterns.Rows )
				new_schedule.patterns.LoadPatternData( pattern );

			int cols = original.patterns.Columns.Count;
			int data_cols = original.pattern_data.Columns.Count;
			int ID_col = original.patterns.Columns[PatternDescriptionTable.PrimaryKey].Ordinal;
			int data_id_col = original.pattern_data.Columns[PatternDescriptionTable.PrimaryKey].Ordinal;
			foreach( DataRow pattern_desc in original.patterns.Rows )
			{
				DataRow[] matching_pattern = new_schedule.patterns.Select( PatternDescriptionTable.NameColumn + "='" + DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, pattern_desc[PatternDescriptionTable.NameColumn].ToString() ) + "'" );
				if( matching_pattern.Length > 0 )
				{
					Log.log( "Target schedule already has pattern " + pattern_desc[PatternDescriptionTable.NameColumn] + " in it " );
					//MessageBox.Show( "Target schedule already has pattern " + pattern_desc[PatternDescriptionTable.NameColumn] + " in it " );
				}
				else
				{
					DataRow new_pattern_row = new_schedule.patterns.NewRow();
					for( int i = 0; i < cols; i++ )
					{
						if( i == ID_col )
							continue;
						new_pattern_row[i] = pattern_desc[i];
					}
					new_schedule.patterns.Rows.Add( new_pattern_row );					
					DataRow[] old_data = pattern_desc.GetChildRows( "pattern_has_bits" );
					foreach( DataRow old_data_row in old_data )
					{
						DataRow new_data_row = new_schedule.pattern_data.NewRow();
						for( int i = 0; i < data_cols; i++ )
						{
							if( i == 0 )
								continue;
							else if( i == data_id_col )
								new_data_row[i] = new_pattern_row[ID_col];
							else
								new_data_row[i] = old_data_row[i];
						}
						new_schedule.pattern_data.Rows.Add( new_data_row );
					}
				}

			}
		}

		public void ValidateSchedule()
		{
			List<String> messages = new List<string>();
			// check if there are games in a session
			foreach( DataRow session_game in session_games.Rows )
			{
				DataRow[] session_game_packs = session_game.GetChildRows( "session_game_has_pack" );
				if( session_game_packs.Length == 0 )
				{
					DataRow session = session_game.GetParentRow( session_games.ParentOfChild );
					DataRow game = session_game.GetParentRow( session_games.ChildrenOfParent );
					messages.Add( "Session " + session[SessionTable.NameColumn] + " Game " + game[GameTable.NameColumn] + " is scheduled with no packs" );
				}
			}
			if( messages.Count > 0 )
			{
				String message = null;
				foreach( String line in messages )
					message += line + "\n";
				MessageBox.Show( message );
			}
		}

		public void Drop()
		{
			schedule_dsn.BeginTransaction();
			for( LinkedListNode<DataTable> table = PersistantTables.Last; table != null; table = table.Previous )
			{
				Log.log( "dropping " + table.Value.ToString() );
				DsnSQLUtil.DropTable( schedule_dsn, table.Value );
			}
			schedule_dsn.EndTransaction();
			
		}

		protected override void Dispose( bool disposing )
		{
			EnforceConstraints = false;
			foreach( DataTable table in Tables )
			{
				table.Dispose();
			}
			base.Dispose( disposing );
		}
	}

	/// <summary>
	/// attribute to allow specifying fill method overrides mostly (non persistant)
	/// </summary>
	public class ScheduleTable : SQLPersistantTable
	{
	}
	
	/// <summary>
	/// attribute to make sure that the table is created in a database and data is written to a database.
	/// </summary>
	public class SchedulePersistantTable : SQLPersistantTable
	{
	}
}
