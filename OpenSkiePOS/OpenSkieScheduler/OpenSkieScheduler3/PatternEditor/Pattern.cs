using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;
using System.Windows.Forms;
using OpenSkieScheduler3;

namespace BingoGameCore4
{
    public class Patterns : List<Pattern>
    {
        internal PatternDescriptionTable pattern_info;
        internal PatternDataTable pattern_data;
        internal PatternMultiDataTable pattern_sub_pattern;
        internal PatternJavaDataTable pattern_java_server;

		public Patterns( PatternDescriptionTable pattern_info, PatternDataTable pattern_data, PatternMultiDataTable pattern_sub_pattern, PatternJavaDataTable pattern_java_server )
        {			
            this.pattern_info = pattern_info;
            this.pattern_data = pattern_data;
            this.pattern_sub_pattern = pattern_sub_pattern;
            this.pattern_java_server = pattern_java_server;
        }

        public Patterns(ScheduleDataSet schedule)
        {
            this.pattern_info = schedule.patterns;
            this.pattern_data = schedule.pattern_data;
            this.pattern_sub_pattern = schedule.pattern_sub_pattern;
            this.pattern_java_server = schedule.pattern_java_server;
        }

        public void UpdateSubPatterns( Pattern pattern )
        {
            PatternDescriptionTable pdt = pattern.row.Table as PatternDescriptionTable;
            DataRow[] subs = pdt.LoadPatternSubs( pattern.row );
            pattern.sub_patterns.Clear();
			
            foreach( DataRow sub_row in subs )
            {
                foreach( Pattern sub in this )
                {
                    if( sub.ID.Equals( sub_row["member_pattern_id"] ) )
                    {
                        pattern.sub_patterns.Add( sub );
						break;
                    }
                }
            }
        }

		public Pattern GetPattern( DataRow pattern, out bool created )
		{
			foreach( Pattern p in this )
			{
				if( p.row[PatternDescriptionTable.PrimaryKey].Equals( pattern[PatternDescriptionTable.PrimaryKey] ) )
				{
					created = false;
					return p;
				}
			}
			Pattern new_pattern = new Pattern( pattern, this );
			Add( new_pattern );
			created = true;
			return new_pattern;
		}
    }

	public interface IPattern : IEnumerable< Int32 >
	{

	}

	public class Pattern : IPattern
	{
		public class PatternMasks
		{
			public List<int> pattern_bitmask_list;
			public int pattern_overall_mask;
		}

		bool eCube;
		int _repeat_count;
		object _ID;
		public bool HasChanges;

		public List<PatternMasks> pattern_masks;

		public object ID
		{
			set
			{
				_ID = value;
			}
			get
			{
				return _ID;
			}
		}


		public String Name
		{
			set
			{
				if( !DsnSQLUtil.Compare( value.GetType(), value
								, this.row[PatternDescriptionTable.NameColumn] ) )
				{
					try
					{
						HasChanges = true;
						this.row[PatternDescriptionTable.NameColumn] = value;
						changed = true;
					}
					catch( ConstraintException )
					{
						MessageBox.Show( "Duplicate name exists : " + value + "\nCannot rename " );
						return;
					}
				}
			}
			get
			{
				return this.row[PatternDescriptionTable.NameColumn].ToString();
			}
		}

		PatternDescriptionTable.match_types _algorithm;
		public PatternDescriptionTable.match_types algorithm
		{
			set
			{
				if( value == PatternDescriptionTable.match_types.NonOverlayable )
				{
					_algorithm = PatternDescriptionTable.match_types.Normal;
					mode_mod = mode_modifications.NoOverlap;
				}
				else if( _algorithm != value )
				{
					_algorithm = value;
					changed = true;
				}
			}
			get
			{
				return _algorithm;
			}
		}
        bool _repeat_no_overlap;
		/// <summary>
		/// applies to whether patterns allowed to overlap with count.
		/// </summary>
		public bool repeat_no_overlap
		{
			get
			{
				return _repeat_no_overlap;
			}
			set
			{
				if( value != _repeat_no_overlap )
				{
					if( value )
						_mode_mod |= mode_modifications.NoOverlap;
					else
						_mode_mod &= ~mode_modifications.NoOverlap;
					_repeat_no_overlap = value;
					changed = true;
				}
			}
		}
		/// <summary>
		/// How many of this pattern must appear to match
		/// </summary>
		public int repeat_count
		{
			set
			{
				if( value != _repeat_count )
				{
					HasChanges = true;
					if( value < 1 )
						value = 1;
					_repeat_count = value;
					changed = true;
				}
			}
			get
			{
				if( _repeat_count == 0 )
					_repeat_count = 1;
				return _repeat_count;
			}
		}

		bool _crazy_hardway;
		public bool crazy_hardway
		{
			set
			{
				if( value != _crazy_hardway )
				{
					HasChanges = true;
					_crazy_hardway = value;
				}
			}
			get
			{
				return _crazy_hardway;
			}
		}

		//[Flags]
		public enum mode_modifications{
			NoExpansion,
			Anywhere,
			AnywhereHardway,
			Anydirection,
			AnydirectionHardway,
			MirrorAnydirection,
    		MirrorAnydirectionHardway,
			MirrorAnywhere,
			MirrorAnywhereHardway,
			rectionHardway,
			AnyWhereAnyDirection,
			AnyWhereAnyDirectionHardway,
			MirrorAnyWhereAnyDirection,
			MirrorAnyWhereAnyDirectionHardway,
			mask_mod = 0x0F,  // mask to get just above state.
			max_mod = 0x10,
			OverlapOK   = 0x100,
			MustOverlap = 0x200,
			NoOverlap   = 0x300,
			OverlapMod  = 0x300,  // used as mask to get overlap flags.
			SingleCard = 0x40,
			OrderMatters = 0x20,
			eCube = 0x80,

			ExternalJavaEngine = 0x100,  // set to send information to external java engine
		};
		mode_modifications _mode_mod;
		public mode_modifications mode_mod
		{
			set
			{
				if( value != _mode_mod )
				{
					HasChanges = true;
					_mode_mod = value;
				}

			}
			get
			{
				return _mode_mod;
			}
		}

		public int board_size;
        public Patterns pattern_list;
		public DataRow row;
		//public PatternDataTable pattern_data;
        //public PatternMultiDataTable pattern_sub_pattern;
		public bool changed; // set so update can work...
        public bool sub_pattern_changed; // set so update can work...
        //public int[] masks; // popuplated only when actually used, but kept forever.
		public List<Pattern> sub_patterns;
		public List<System.Collections.Specialized.BitVector32> masks;

		// patterns in masks are expanded into this list.
        public int[] simple_masks;
		public List<int> composite_masks = new List<int>();


		void CommonInit( DataRow row, Patterns pattern_list )
		{
			this.row = row;
			//this.pattern_data = pattern_data;
			//this.pattern_sub_pattern = pattern_sub_pattern;
			this.pattern_list = pattern_list;
			int col_count = row.Table.Columns.IndexOf( "count" );
			int col_match = row.Table.Columns.IndexOf( "match" );

			//ID = Convert.ToInt32( row[XDataTable.ID( row.Table )] );
			ID = row[XDataTable.ID( row.Table )];
			Name = (String)row[XDataTable.Name( row.Table )];
			if( col_count >= 0 )
			{
				if( row[col_count].GetType() == typeof( DBNull ) )
					_repeat_count = 1;
				else
					_repeat_count = Convert.ToInt32( row[col_count] );
				if( _repeat_count == 0 && col_match >= 0 )
				{
					// this causes the row that selected this to change.
					row[col_count] = row[col_match];
					if( row[col_match].GetType() == typeof( DBNull ) )
						_repeat_count = 1;
					else
						_repeat_count = Convert.ToInt32( row[col_match] );
				}
			}
			else
			{
				_repeat_count = (int)row["match"];
			}
			_crazy_hardway = (bool)row["crazy_hardway"];
			if( row.Table.Columns.IndexOf( "mode" ) >= 0 )
				algorithm = ( row["mode"].Equals( DBNull.Value ) ? PatternDescriptionTable.match_types.Normal : (PatternDescriptionTable.match_types)row["mode"] );
			else
				algorithm = ( row["real_mode"].Equals( DBNull.Value ) ? PatternDescriptionTable.match_types.Normal : (PatternDescriptionTable.match_types)row["real_mode"] );
			_mode_mod = (mode_modifications)row["mode_mod"];
			object o = row["pattern_board_size"];

			board_size = (o == DBNull.Value)?0:Convert.ToInt32( o );
			if( ( _mode_mod & mode_modifications.eCube ) != 0 )
			{
				_mode_mod -= mode_modifications.eCube;
				eCube = true;
			}
			if( ( _mode_mod & mode_modifications.max_mod ) != 0 )
			{
				_mode_mod -= mode_modifications.max_mod;
				_repeat_no_overlap = true;
			}
			if( _mode_mod == mode_modifications.NoOverlap )
				_repeat_no_overlap = true;

			sub_patterns = new List<Pattern>();
			{
				DataRow[] sub_pattern_rows = row.GetChildRows( "pattern_has_sub_pattern" );
				foreach( DataRow pattern in sub_pattern_rows )
				{
					Pattern sub = null;
					foreach( Pattern p in pattern_list )
						if( p.ID.Equals( pattern[PatternDescriptionTable.PrimaryKey] ) )
						{
							sub = p;
							break;
						}
					if( sub == null )
					{
						bool created2;
						sub = pattern_list.GetPattern( pattern.GetParentRow( "sub_pattern_is_pattern" ), out created2 );
					}
					this.sub_patterns.Add( sub );
				}
			}
			masks = new List<System.Collections.Specialized.BitVector32>();

			// these aren't really changes.
			changed = false;
		}

		public Pattern( DataRow row, Patterns pattern_list )
		{
			CommonInit( row, pattern_list );
		}

		public void UpdateBits()
		{
			masks.Clear();
			PatternDescriptionTable pdt = row.Table as PatternDescriptionTable;
			DataRow[] bits = pdt.LoadPatternData( row );
			if( bits != null )
			foreach( DataRow child_row in bits )
			{
				if( child_row.Table.TableName == PatternMultiDataTable.TableName )
				{
					masks.Add( new System.Collections.Specialized.BitVector32( 0x1FFF ) );
				}
				if( child_row.Table.TableName == PatternDataTable.TableName )
				{
					int mask = Convert.ToInt32( child_row["bits_int"] );
					if( mask == 0 )
					{
						// the reading of pattern data should fixup the bits_int value.
						String x = child_row["mask"].ToString();
						for( int n = 0; n < 25; n++ )
						{
							if( x[n] == '1' )
								mask |= 1 << n;
						}
						child_row["bits_int"] = mask;
					}
					if( eCube )
					{
						mask >>= 3;
						{
							int tmp = 0;
							int r, c;
							for( r = 0; r < 5; r++ )
								for( c = 0; c < 5; c++ )
								{
									if( ( mask & ( 1 << ( c * 5 ) + r ) ) != 0 )
									{
										tmp |= 1 << ( ( ( 4 - c ) * 5 ) + ( 4 - r ) );
									}
								}
							mask = tmp;
						}
					}
					masks.Add( new System.Collections.Specialized.BitVector32( mask ) );
				}
	
			}
		}

		public Pattern( Pattern p )
		{
			this.row = p.row.Table.NewRow();
			this._repeat_count = p._repeat_count;
			this.algorithm = p.algorithm;

			// clone the original data row.
			DataRow row = p.row;
			for( int n = 1; n < p.row.ItemArray.Length; n++ )
			{
				// don't copy the primary key.
				if( p.row.Table.Columns[n].AutoIncrement )
					continue;
				this.row[n] = p.row[n];
			}

			// clone all the loaded masks.
			this.masks = new List<System.Collections.Specialized.BitVector32>();
			foreach( System.Collections.Specialized.BitVector32 bits in p.masks )
				this.masks.Add( new System.Collections.Specialized.BitVector32( bits ) );

			this.sub_patterns = new List<Pattern>();
			foreach( Pattern pattern in p.sub_patterns )
				sub_patterns.Add( pattern );


			// create a new name based on the old name.
			this.row[XDataTable.Name( row.Table )] = this.Name = "Copy of " + p.Name;
			this._mode_mod = p._mode_mod;
            this.pattern_list = p.pattern_list;
			this.changed = true;
		retry_name:
			try
			{

				p.row.Table.Rows.Add( this.row );
			}
			catch( ConstraintException ce )
			{
				if( ce.Message.IndexOf( "pattern_name" ) >= 0 )
				{
					this.row[XDataTable.Name( row.Table )] = this.Name = "Copy of " + this.Name;
					goto retry_name;
				}

			}
			UpdateRow();
		}
        public Pattern()
        {
            
        }
		public Pattern( ScheduleDataSet schedule, Patterns pattern_data )
		{
			ID = Guid.Empty;
			row = schedule.patterns.NewRow();
			Name = QueryNewName.Show( "Enter new pattern name" );
			if( Name == null || Name == "" )
				throw new NullReferenceException( "Name cannot be blank." );
			_repeat_count = 1;
			algorithm = 0;
			_mode_mod = mode_modifications.NoExpansion;
			masks = new List<System.Collections.Specialized.BitVector32>( 25 );
			sub_patterns = new List<Pattern>();
			//row["pattern_name"] = Name;
			changed = true;
            this.pattern_list = pattern_data;
			//pattern_data = schedule.pattern_data;
			schedule.patterns.Rows.Add( row );
			UpdateRow();
		}

        public void UpdateSubPatterns( Pattern pattern )
        {
            DataRow[] rows = pattern.row.GetChildRows( "pattern_has_sub_pattern" );
            foreach( DataRow row in rows )
            {
                row.Delete();
            }
            int seq = 0;
            foreach( Pattern sub in pattern.sub_patterns )
            {
                DataRow newrow = pattern_list.pattern_sub_pattern.NewRow();
                newrow[PatternDescriptionTable.PrimaryKey] = pattern.ID;
                newrow["member_pattern_id"] = sub.ID;
                newrow[PatternMultiDataTable.NumberMemberName] = seq++;
                pattern_list.pattern_sub_pattern.Rows.Add( newrow );

            }
        }

		public bool UpdateRow()
		{
			if( changed || ( row != null && row.RowState == DataRowState.Deleted ) )
			{
				expanded = false;
				if( row != null )
				{
					if( row.RowState != DataRowState.Deleted )
					{
						StringBuilder mask = new StringBuilder();
						row[XDataTable.Name( row.Table )] = Name;
						row["count"] = _repeat_count;
						row["crazy_hardway"] = _crazy_hardway;
						row["real_mode"] = _algorithm;
						row["mode_mod"] = ( (int)_mode_mod ) + ( _repeat_no_overlap ? mode_modifications.max_mod : 0 );

						PatternDescriptionTable pdt = row.Table as PatternDescriptionTable;
						//pdt.CommitChanges();

						if( XDataTable.DefaultAutoKeyType == typeof( Guid ) )
							ID = new Guid( row["pattern_id"].ToString() );
						else
							ID = row["pattern_id"];

						if( _algorithm == PatternDescriptionTable.match_types.Normal )
						{
							bool bits_changed = false;
							int block = 0;
							DataRow[] rows = row.GetChildRows( "pattern_has_bits" );
							//DataRow[] rows = pattern_data.Select( "pattern_id=" + ID.ToString() );
							foreach( DataRow delete_row in rows )
							{
								// maybe check off each pattern... 
								bits_changed = true;
								delete_row.Delete();
							}
							foreach( System.Collections.Specialized.BitVector32 bits in masks )
							{
                                DataRow newrow = pattern_list.pattern_data.NewRow();
								mask.Length = 0;
								newrow["block"] = block++;
								newrow["bits_int"] = bits.Data;
								newrow["pattern_id"] = ID;
								pattern_list.pattern_data.Rows.Add( newrow );
								bits_changed = true;
							}
                            if( pattern_list != null && pattern_list.pattern_data != null && bits_changed )
							{
                                //pattern_list.pattern_data.CommitChanges();
							}
						}
					}
					else
					{
						PatternDescriptionTable pdt = row.Table as PatternDescriptionTable;
						pdt.CommitChanges();
					}
				}

                if( sub_pattern_changed || ( row != null && row.RowState == DataRowState.Deleted ) )
                {
                    expanded = false;
					if( IsMultiPattern() )
                    {
                        UpdateSubPatterns( this );
                    }
                    sub_pattern_changed = false;
                }

				changed = false;
				return true;
			}
            if( sub_pattern_changed || ( row != null && row.RowState == DataRowState.Deleted ) )
            {
                expanded = false;
				if( IsMultiPattern() )
                {
                    UpdateSubPatterns( this );
                }
                sub_pattern_changed = false;
                return true;
            }
			return false;
		}

		public bool IsMultiPattern(  )
		{
			if( ( _algorithm == PatternDescriptionTable.match_types.CrazyMultiCard )
				|| ( _algorithm == PatternDescriptionTable.match_types.TopMiddleBottom )
				|| ( _algorithm == PatternDescriptionTable.match_types.TopMiddleBottomCrazy )
				)
				return true;
			return false;
		}

		public override string ToString()
		{
			return Name;
		}
		/*
		 public override bool Equals( object obj )
		 {
			 Pattern check = obj as Pattern;
			 if( check != null )
				 if( check.ID == this.ID )
					 return true;
			 return false;
			 //return base.Equals( obj );
		 }
		 * */
#if asdfasdf
		public static implicit operator object( Pattern p )
		{
			return p.ID;
		}
#endif
		/// <summary>
		/// This iterates each pattern passed and builds a merged list of pattern masks, and a composite bitmask pattern
		/// </summary>
		/// <param name="patterns">List of patterns to expand</param>
		public static void ExpandGamePatterns( List<Pattern> patterns, PatternMasks masks )
		{
			masks.pattern_bitmask_list = new List<int>();
			{
				int pattern_mask = 0;
				foreach( Pattern pattern in patterns )
				{
					pattern.Expand();

					foreach( int mask in pattern.composite_masks )
					{
						pattern_mask |= mask;
						masks.pattern_bitmask_list.Add( mask );
					}
				}

				masks.pattern_overall_mask = pattern_mask;
			}
		}


		bool StepCounters( ref int[] counters, int max, int which )
		{
			int x = which - 1;//; x >= 0; x-- )
			while( true )
			{
				counters[x]++;
				if( x > 0 )
				{
					if( counters[x] < ( max - ( counters.Length - which ) ) )
						return true;
					// need to recurse here ... 
					if( !StepCounters( ref counters, max, x ) )
						return false;
					counters[x] = counters[x - 1];
				}
				else
					break;
			}
			if( counters[0] < ( max - ( counters.Length - which ) ) )
				return true;
			return false;
		}

		void ExpandByMoveSingleMask( bool[,] layout, List<int> output, bool skip_easy )
		{
			{
				{
					int r_ofs, c_ofs;
					int r, c;

					int build_mask;

					// setup layout array....
					for( r_ofs = -4; r_ofs <= 4; r_ofs++ )
					{
						for( c_ofs = -4; c_ofs <= 4; c_ofs++ )
						{
							build_mask = 0;
							for( r = 0; r < 5; r++ )
							{
								for( c = 0; c < 5; c++ )
								{
									if( layout[r, c]
										&& ( ( ( ( r + r_ofs ) < 0 )
											 || ( ( r + r_ofs ) > 4 ) )
										   || ( ( ( c + c_ofs ) < 0 )
											  || ( ( c + c_ofs ) > 4 ) )
										   )
										)
										break;
									if( layout[r, c] )
									{
										build_mask |= ( 1 << ( ( ( c + c_ofs ) * 5 ) + ( r + r_ofs ) ) );
									}
								}
								if( c < 5 )
									break;
							}
							if( r < 5 )
								continue;
							if( skip_easy
								&& ( ( build_mask & ( 1 << 12 ) ) != 0 ) ) // if the center is part of this block....
								continue;
							{
								// otherwise, this mask should be good to output...
								if( output.IndexOf( build_mask ) == -1 )
									output.Add( build_mask );
							}
						}
					}
				}
			}
		}

		void ConvertSingleMask( bool[,] layout, List<int> output )
		{
			int r_ofs, c_ofs;
			int r, c;

			int build_mask;

			// setup layout array....
			r_ofs = 0;
			c_ofs = 0;
			build_mask = 0;
			for( r = 0; r < 5; r++ )
			{
				for( c = 0; c < 5; c++ )
				{
					if( layout[r, c] )
					{
						build_mask |= ( 1 << ( ( ( c + c_ofs ) * 5 ) + ( r + r_ofs ) ) );
					}
				}
			}
			// otherwise, this mask should be good to output...
			if( output.IndexOf( build_mask ) == -1 )
				output.Add( build_mask );
		}

		int[] ExpandMods( mode_modifications mod
			, List<System.Collections.Specialized.BitVector32> masks )
		{
			mode_modifications this_mod = ( mod & mode_modifications.mask_mod );
			bool anywhere = ( this_mod == mode_modifications.Anywhere
						|| this_mod == mode_modifications.AnywhereHardway
						|| this_mod == mode_modifications.AnyWhereAnyDirection
						|| this_mod == mode_modifications.AnyWhereAnyDirectionHardway
						|| this_mod == mode_modifications.MirrorAnywhere
						|| this_mod == mode_modifications.MirrorAnywhereHardway
						|| this_mod == mode_modifications.MirrorAnyWhereAnyDirection
						|| this_mod == mode_modifications.MirrorAnyWhereAnyDirectionHardway )
						;
			bool mirror = ( this_mod == mode_modifications.MirrorAnywhere
						|| this_mod == mode_modifications.MirrorAnywhereHardway
						|| this_mod == mode_modifications.MirrorAnydirection
						|| this_mod == mode_modifications.MirrorAnydirectionHardway
						|| this_mod == mode_modifications.MirrorAnyWhereAnyDirection
						|| this_mod == mode_modifications.MirrorAnyWhereAnyDirectionHardway )
						;
			bool anydirection = ( this_mod == mode_modifications.Anydirection
						|| this_mod == mode_modifications.AnydirectionHardway
						|| this_mod == mode_modifications.AnyWhereAnyDirection
						|| this_mod == mode_modifications.AnyWhereAnyDirectionHardway
						|| this_mod == mode_modifications.MirrorAnydirection
						|| this_mod == mode_modifications.MirrorAnydirectionHardway
						|| this_mod == mode_modifications.MirrorAnyWhereAnyDirection
						|| this_mod == mode_modifications.MirrorAnyWhereAnyDirectionHardway )
				;
			List<int> output = new List<int>();
			if( mod == mode_modifications.NoExpansion )
			{
				foreach( System.Collections.Specialized.BitVector32 mask in masks )
					output.Add( mask.Data );
				return output.ToArray();
			}
            
			if( anywhere && !anydirection )
			{
				bool skip_easy = ( mod == mode_modifications.AnywhereHardway );
				int m;
				bool[,] layout = new bool[5, 5];
				for( m = 0; m < masks.Count; m++ )
				{
					int r, c;
					// setup layout array....
					for( r = 0; r < 5; r++ )
						for( c = 0; c < 5; c++ )
						{
							if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
								layout[r, c] = true;
							else
								layout[r, c] = false;
						}
					ExpandByMoveSingleMask( layout, output, skip_easy );
				}
			}

			if( anydirection )
			{
				bool skip_easy = ( this_mod == mode_modifications.AnydirectionHardway )
					|| ( this_mod == mode_modifications.AnywhereHardway )
					|| ( this_mod == mode_modifications.AnyWhereAnyDirectionHardway )
					|| ( this_mod == mode_modifications.MirrorAnydirectionHardway )
					|| ( this_mod == mode_modifications.MirrorAnywhereHardway )
					|| ( this_mod == mode_modifications.MirrorAnyWhereAnyDirectionHardway );
				int m;
				bool[,] layout = new bool[5, 5];
				for( m = 0; m < masks.Count; m++ )
				{
					int r, c;
					// setup layout array....
					for( r = 0; r < 5; r++ )
						for( c = 0; c < 5; c++ )
						{
							if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
								layout[r, c] = true;
							else
								layout[r, c] = false;
						}

					if( anywhere )
						ExpandByMoveSingleMask( layout, output, skip_easy );
					else
						ConvertSingleMask( layout, output );

					for( r = 0; r < 5; r++ )
						for( c = 0; c < 5; c++ )
						{
							if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
								layout[c, 4 - r] = true;
							else
								layout[c, 4 - r] = false;
						}

					if( anywhere )
						ExpandByMoveSingleMask( layout, output, skip_easy );
					else
						ConvertSingleMask( layout, output );

					for( r = 0; r < 5; r++ )
						for( c = 0; c < 5; c++ )
						{
							if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
								layout[4 - r, 4 - c] = true;
							else
								layout[4 - r, 4 - c] = false;
						}

					if( anywhere )
						ExpandByMoveSingleMask( layout, output, skip_easy );
					else
						ConvertSingleMask( layout, output );

					for( r = 0; r < 5; r++ )
						for( c = 0; c < 5; c++ )
						{
							if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
								layout[4 - c, r] = true;
							else
								layout[4 - c, r] = false;
						}

					if( anywhere )
						ExpandByMoveSingleMask( layout, output, skip_easy );
					else
						ConvertSingleMask( layout, output );

					if( mirror )
					{
						// setup layout array....
						for( r = 0; r < 5; r++ )
							for( c = 0; c < 5; c++ )
							{
								if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
									layout[c, r] = true;
								else
									layout[c, r] = false;
							}

						if( anywhere )
							ExpandByMoveSingleMask( layout, output, skip_easy );
						else
							ConvertSingleMask( layout, output );

						for( r = 0; r < 5; r++ )
							for( c = 0; c < 5; c++ )
							{
								if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
									layout[4 - r, c] = true;
								else
									layout[4 - r, c] = false;
							}

						if( anywhere )
							ExpandByMoveSingleMask( layout, output, skip_easy );
						else
							ConvertSingleMask( layout, output );

						for( r = 0; r < 5; r++ )
							for( c = 0; c < 5; c++ )
							{
								if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
									layout[4 - c, 4 - r] = true;
								else
									layout[4 - c, 4 - r] = false;
							}

						if( anywhere )
							ExpandByMoveSingleMask( layout, output, skip_easy );
						else
							ConvertSingleMask( layout, output );

						for( r = 0; r < 5; r++ )
							for( c = 0; c < 5; c++ )
							{
								if( ( masks[m].Data & ( 1 << ( c * 5 + r ) ) ) != 0 )
									layout[ r, 4 - c ] = true;
								else
									layout[ r, 4 - c ] = false;
							}

						if( anywhere )
							ExpandByMoveSingleMask( layout, output, skip_easy );
						else
							ConvertSingleMask( layout, output );
					}

				}
			}
			return output.ToArray();
		}

		bool expanded;
        public void Expand()
        {
            if( expanded )
                return;

            if( masks.Count == 0 )
            {
                // try and load related pattern_data masks... might still have 0, but maybe not...
                UpdateBits();
            }

			if( IsMultiPattern() )
            {
                if( sub_patterns.Count == 0 )
                    pattern_list.UpdateSubPatterns( this );

                foreach( Pattern p in sub_patterns )
                    p.Expand();

                if( ( mode_mod & mode_modifications.SingleCard ) != 0 )
                {
                    // can get some resulting masks from this mode... it's not multi-card pattern, it's just a composite pattern
                }
                else
                {
                    // all we can do is expand sub_patterns... matching fits a pack, so it's mostly a computation
                }
            }
			else if( _algorithm == PatternDescriptionTable.match_types.CrazyMark )
            {
                composite_masks.Clear();
                composite_masks.Add( 0x1fffff ); // 25x25 mark
                return;
            }
            else
            {
				if( ( _algorithm == PatternDescriptionTable.match_types.TwoGroups )
					|| ( _algorithm == PatternDescriptionTable.match_types.TwoGroupsNoOver )	
					|| ( _algorithm == PatternDescriptionTable.match_types.TwoGroupsPrime )	
					|| ( _algorithm == PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver ) )
				{
					bool no_overlap = ( _algorithm == PatternDescriptionTable.match_types.TwoGroupsNoOver )	
									|| ( _algorithm == PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver );
					bool prime = ( _algorithm == PatternDescriptionTable.match_types.TwoGroupsPrime )	
									|| ( _algorithm == PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver );
					int n = 0;
					int m = 0;

					for( n = 0; n < (int)_mode_mod; n++ )
					{
						if( prime )
						{
							for( m = 0; m < (int)_mode_mod; m++ )
							{
								int mask1 = masks[n].Data;
								int mask2 = masks[m].Data;
								// even if it's overlap, has to be different.
								if( mask1 == mask2 )
									continue;
								if( no_overlap && ( ( mask1 & mask2 ) != 0 ) )
									continue;
								composite_masks.Add( mask1 | mask2 );
							}
						}
						for( m = (int)_mode_mod; m < masks.Count; m++ )
						{
							int mask1 = masks[n].Data;
							int mask2 = masks[m].Data;
							if( no_overlap && ( ( mask1 & mask2 ) != 0 ) )
								continue;
							composite_masks.Add( mask1 | mask2 );
						}
					}
				}
				else
				{
					simple_masks = ExpandMods( _mode_mod, masks );
					if( ( _mode_mod & mode_modifications.NoOverlap ) != 0 )
						_repeat_no_overlap = true;
					composite_masks.Clear();
					{
						int[] counters;
						int max = simple_masks.Length;
						if ( _repeat_count < 1 )
							return;
						counters = new int[_repeat_count];

						// init the counters to 0,1,2,3...
						counters[0] = 0;
						for ( int x = 1; x < _repeat_count; x++ )
						{
							counters[x] = counters[x - 1] + 1;
						}

						//for( counters[0] = 0; counters[0] < max; counters[0]++ )
						bool is_another = true;
						int rcount = _repeat_count;
						while ( is_another )
						{
							bool valid_mask = true;
							int check_mask = 0;

							// grab the current pattern's configuration...
							for ( int x = 0; x < rcount; x++ )
							{
								int j;

								if ( ( j = counters[x] ) >= max )
								{
									valid_mask = false;
									break;
								}
								if ( _repeat_no_overlap )
									if ( ( check_mask & simple_masks[j] ) != 0 )
									{
										valid_mask = false;
										break;
									}
								check_mask |= simple_masks[j];
							}

							// returns true if valid numbers...
							// else false, and next time we don't have another ..
							is_another = StepCounters( ref counters, max, rcount );

							if ( !valid_mask )
								continue;
							composite_masks.Add( check_mask );
						}
					}
                }
                expanded = true;
            }
        }


		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
