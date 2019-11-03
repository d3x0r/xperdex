using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.classes;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

/* 
 * Sync database
 * 
--select top 10 * from session
delete from ap_accrument;
insert into ap_accrument (accrument_id,ses_id)  select NEWID(),ses_id from session;
--select top 10 * from ap_accrument order by ses_id desc;
delete from ap_accrument where ses_id > 4090
update ap_accrual_group set last_accrument = NULL;

 * 
 */


namespace ECube.AccrualProcessor
{
	internal class AccrualGroup
	{
		internal string Name;
		internal DataRow this_row;
		internal Guid ID;
		//internal int house_percent;
		//internal JackpotLedger input_ledger;
		//internal JackpotLedger primary_ledger;
		internal AccrualPercents use_percent;
		//internal JackpotLedger secondary_ledger;
		//internal JackpotLedger tertiary_ledger;
		//internal JackpotLedger pay_ledger;
		internal LinkedList<Accrument> accruments = new LinkedList<Accrument>();

		internal void ClearPrimaryPercent()
		{
			this.use_percent = null;
		}

		internal Decimal GetPostedvalue()
		{
			LinkedListNode<Accrument> check = accruments.Last;
			while( check != null && check.Previous != null )
			{
				if( check.Value.posted )
					return check.Value.primary_end;
				check = check.Previous;
			}
			return check.Value.primary_end;
		}

		internal Decimal GetPostedBalls()
		{
			LinkedListNode<Accrument> check = accruments.Last;
			while( check != null && check.Previous != null )
			{
				if( check.Value.posted )
					return check.Value.ball_end;
				check = check.Previous;
			}
			return check.Value.ball_end;
		}

		public  int primary_percent(Accrument a)
		{
		//	get{
				//if( this.use_percent == null )
				{
					decimal curval;
					AccrualPercents use_percent = null;
					/*
					if( a.pay_count > 0 )
					{
						Log.log( "payout happened using..." +
							a.primary_start.ToString()
								+ "  " + a.primary_transfer.ToString()
								+ "  " + a.primary_rollover.ToString()
								+ "  " + a.primary_seed.ToString()
								+ "  " + a.primary_fixup.ToString()
								+ "  " + ( a.pay * a.pay_count ).ToString() );
						curval = a.primary_start
								+ a.primary_transfer
								+ a.primary_rollover
								+ a.primary_seed
								+ a.primary_fixup
								- ( a.pay * a.pay_count );
					}
					else
					*/
					curval = a.primary_start; 
					//Log.log( Name + ":setting primary percent from " + curval.ToString( "C" ) );
					LinkedListNode<AccrualPercents> check = accrual_percentages.First;
					while( check != null )
					{
						if( check.Value.threshold <= curval )
							use_percent = check.Value;
						check = check.Next;
					}
				if( use_percent != null )
				{
					this.use_percent = use_percent;
				}
				else
					this.use_percent = accrual_percentages.First.Value;
				}
				return this.use_percent.primary;
			//}		 
		}
		internal int secondary_percent
		{
			get{
				return use_percent.secondary;
			}
		}
		internal int tertiary_percent
		{
			get{
				return use_percent.tertiary;
			}
		}

		internal LinkedList<AccrualPercents> accrual_percentages = new LinkedList<AccrualPercents>();

		public class AccrualPercents
		{
			internal decimal threshold;
			internal int primary;
			internal int secondary;
			internal int tertiary;
			internal int kitty;

			internal AccrualPercents( decimal t, int p, int s, int ter, int k )
			{
				threshold = t;
				primary = p;
				secondary = s;
				tertiary = ter;
				kitty = k;
			}
		}

		public class Accrument
		{
			//internal DataRow session;  // session row; has times, and slt_id to get session slot
			internal int ses_id = -1;
			internal int slt_id = -1;
			internal string session_name;
			internal String session_date;
			internal DataRow this_row;
			internal Guid ID;
			AccrualGroup group;
			internal Decimal input;
			internal Decimal house;
			internal int house_percent;

			internal Decimal primary_start;
			internal int primary_percent;
			//internal Decimal primary;
			internal Decimal _primary_sales;
			internal bool daily_or_weekly_accrual; // set on the daily/monthly session taht actually accrus
			internal Decimal primary_sales { get { return _primary_sales; } set { _primary_sales = value; } }
			internal Decimal primary_transfer;
			internal Decimal primary_rollover;
			internal Decimal primary_seed;
			internal Decimal primary_fixup;
			internal Decimal primary_end;

			internal Decimal secondary_start;
			internal int secondary_percent;
			//internal Decimal secondary;
			internal Decimal secondary_sales;
			internal Decimal secondary_transfer;
			internal Decimal secondary_rollover;
			internal Decimal secondary_seed;
			internal Decimal secondary_fixup;
			internal Decimal secondary_end;

			internal Decimal tertiary_start;
			internal int tertiary_percent;
			//internal Decimal tertiary;
			internal Decimal tertiary_sales;
			internal Decimal tertiary_transfer;
			internal Decimal tertiary_rollover;
			internal Decimal tertiary_seed;
			internal Decimal tertiary_fixup;
			internal Decimal tertiary_end;
			int _ball_start;
			internal int ball_start
			{
				get
				{
					if( this_row != null )
					{
						if( this_row["ball_start"] == DBNull.Value )
							return 0;
						return (int)this_row["ball_start"];
					}
					else
						return 0;
				}
				set
				{
					if( this_row != null )
						this_row["ball_start"] = value;
					else
						_ball_start = value;
				}
			}
			int _ball_delta;
			internal int ball_delta
			{
				get
				{
					if( this_row != null && this_row.RowState != DataRowState.Detached )
					{
						if( this_row["ball_delta"] == DBNull.Value )
							return 0;
						return (int)this_row["ball_delta"];
					}
					return _ball_delta;
				}
				set
				{
					if( this_row != null )
						this_row["ball_delta"] = value;
					else
						_ball_delta = value;
				}
			}
			int _ball_end;
			internal int ball_end
			{
				get
				{
					if( this_row != null && this_row.RowState != DataRowState.Detached )
					{
						if( this_row["ball_end"] == DBNull.Value )
							return 0;
						return (int)this_row["ball_end"];
					}
					return 0;
				}
				set
				{
					if( this_row != null )
						this_row["ball_end"] = value;
					else
						_ball_end = value;
				}
			}
			internal bool ball_count_set
			{
				get
				{
					if( this_row != null && this_row.RowState != DataRowState.Detached )
					{
						if( this_row["ball_count_set"] == DBNull.Value )
							return false;
						return (bool)this_row["ball_count_set"];
					}
					return false;
				}
				set
				{
					if( this_row != null )
						this_row["ball_count_set"] = value;
						
				}
			}
			internal bool paid_from_kitty;
			internal int pay_count;
			internal Decimal pay;
			internal int pay_percent;
			internal Accrument prior_accrument;
			internal bool posted
			{
				get
				{
					if( this_row == null )
						return false;
					if( this_row.RowState == DataRowState.Deleted || this.this_row.RowState == DataRowState.Detached )
						return false;
					return (bool)this_row["posted"];
				}
				set
				{
					if( this_row != null )
						this_row["posted"] = value;
				}
			}
			internal bool closed
			{
				get
				{
					if( this_row == null )
						return false;
					return (bool)this_row["closed"];
				}
				set
				{
					this_row["closed"] = value;
				}
			}
			internal Decimal kitty;

			[SQLPersistantTable]
			public class AccrualPayoutTable : xperdex.classes.MySQLDataTable<AccrualPayoutTable.AccrualPayoutTableRow>
			{
				new static public readonly String TableName = "accrual_payouts";
				//new static public readonly String NameColumn = XDataTable.Name( TableName );
				new static public readonly String PrimaryKey = XDataTable.ID( TableName );

				public AccrualPayoutTable( DataSet dataSet )
				{
					// TODO: Complete member initialization
					InitDataColumns();
					dataSet.Tables.Add( this );
				}
				public AccrualPayoutTable(  )
				{
					// TODO: Complete member initialization
					InitDataColumns();
				}

				public class AccrualPayoutTableRow : DataRow
				{
					public AccrualPayoutTableRow( global::System.Data.DataRowBuilder rb ) :
						base( rb )
					{
					}

					public override string ToString()
					{
						return "AccrualPayout";
					}
				}

				void InitDataColumns()
				{
					AddDefaultColumns( this, false, true, false );
					DataColumn dc;
					dc = Columns.Add( "ses_id", typeof( int ) );
					dc.ExtendedProperties.Add( "Index", true );
					dc.AllowDBNull = false;
					dc.DefaultValue = -1;
					dc = Columns.Add( AccrualGroupTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
					dc.ExtendedProperties.Add( "Index", true );
					Columns.Add( "pay_percent", typeof( int ) );
					Columns.Add( "pay_count", typeof( int ) );
					Columns.Add( "payout", typeof( decimal ) );
				}
			}

			[SQLPersistantTable]
			public class AccrumentTable : xperdex.classes.MySQLDataTable<AccrumentTable.AccrumentTableRow>
			{
				new static public readonly String TableName = "accrument";
				new static public readonly String NameColumn = XDataTable.Name( TableName );
				new static public readonly String PrimaryKey = XDataTable.ID( TableName );

				public AccrumentTable( DataSet dataSet )
				{
					// TODO: Complete member initialization
					InitDataColumns();
					dataSet.Tables.Add( this );
				}
				public AccrumentTable(  )
				{
					// TODO: Complete member initialization
					InitDataColumns();
				}

				public class AccrumentTableRow : DataRow
				{
					public AccrumentTableRow( global::System.Data.DataRowBuilder rb ) :
						base( rb )
					{
					}

					public override string ToString()
					{
						return "Accrument";
					}

				}

				void InitDataColumns()
				{
					AddDefaultColumns( this, false, true, false );
					DataColumn dc;
					dc = Columns.Add( "ses_id", typeof( int ) );
					dc.AllowDBNull = false;
					dc.DefaultValue = -1;
					dc = Columns.Add( "slt_id", typeof( int ) );
					dc.AllowDBNull = false;
					dc.DefaultValue = -1;
					dc.ExtendedProperties.Add( "Index", true );
					dc = Columns.Add( "prior_ses_id", typeof( int ) );
					dc.AllowDBNull = false;
					dc.DefaultValue = false;
					dc = Columns.Add( AccrualGroupTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
					dc.ExtendedProperties.Add( "Index", true );

					Columns.Add( "input", typeof( decimal ) );
					Columns.Add( "house", typeof( decimal ) );
					Columns.Add( "house_percent", typeof( int ) );
					Columns.Add( "kitty", typeof( decimal ) );
					Columns.Add( "primary_start", typeof( decimal ) );
					Columns.Add( "primary_percent", typeof( int ) );
					Columns.Add( "primary_sales", typeof( decimal ) );
					Columns.Add( "primary_seed", typeof( decimal ) );
					Columns.Add( "primary_transfer", typeof( decimal ) );
					Columns.Add( "primary_rollover", typeof( decimal ) );
					Columns.Add( "primary_fixup", typeof( decimal ) );
					Columns.Add( "primary_end", typeof( decimal ) );
					Columns.Add( "secondary_start", typeof( decimal ) );
					Columns.Add( "secondary_percent", typeof( int ) );
					Columns.Add( "secondary_sales", typeof( decimal ) );
					Columns.Add( "secondary_seed", typeof( decimal ) );
					Columns.Add( "secondary_transfer", typeof( decimal ) );
					Columns.Add( "secondary_rollover", typeof( decimal ) );
					Columns.Add( "secondary_fixup", typeof( decimal ) );
					Columns.Add( "secondary_end", typeof( decimal ) );
					Columns.Add( "tertiary_start", typeof( decimal ) );
					Columns.Add( "tertiary_percent", typeof( int ) );
					Columns.Add( "tertiary_sales", typeof( decimal ) );
					Columns.Add( "tertiary_seed", typeof( decimal ) );
					Columns.Add( "tertiary_transfer", typeof( decimal ) );
					Columns.Add( "tertiary_rollover", typeof( decimal ) );
					Columns.Add( "tertiary_fixup", typeof( decimal ) );
					Columns.Add( "tertiary_end", typeof( decimal ) );
					Columns.Add( "pay_percent", typeof( int ) );
					Columns.Add( "pay_count", typeof( int ) );
					Columns.Add( "payout", typeof( decimal ) );
					dc = Columns.Add( "paid_from_kitty", typeof( bool ) );
					dc.DefaultValue = 0;
					dc.AllowDBNull = false;
					Columns.Add( "prior_accrument", XDataTable.DefaultAutoKeyType );
					Columns.Add( "posted", typeof( bool ) );
					Columns.Add( "closed", typeof( bool ) );
					Columns.Add( "ball_start", typeof( int ) );
					Columns.Add( "ball_delta", typeof( int ) );
					Columns.Add( "ball_end", typeof( int ) );
					Columns.Add( "ball_count_set", typeof( bool ) );

				}

				void FillAccurmentRow( DbDataReader reader, Accrument accrument )
				{
					DataRow a_row;
					DataRow[] exists = Select( AccrumentTable.PrimaryKey + "='" + reader[AccrumentTable.PrimaryKey] + "'" );
					if( exists.Length > 0 )
						a_row = exists[0];
					else
						a_row = NewRow();

					accrument.ses_id = (int)( a_row["ses_id"] = reader["ses_id"] );
					a_row["slt_id"] = reader["slt_id"];
					if( a_row["slt_id"] == DBNull.Value )
					{
						if( accrument.ses_id > 0 )
						{
							DataRow[] slot = Local.BingoDataSet.session.Select( "ses_id=" + accrument.ses_id );
							if( slot.Length == 0 )
							{
								DsnSQLUtil.FillDataTable( Local.dataConnection_alt, Local.BingoDataSet.session
										, "select top 1 * from session where Ses_id=" + accrument.ses_id
										, true );
								slot = Local.BingoDataSet.session.Select( "ses_id=" + accrument.ses_id );
							}

							if( slot.Length > 0 )
							{
								a_row["slt_id"] = slot[0]["slt_id"];
								accrument.slt_id = (int)slot[0]["slt_id"];
							}
						}
						else
						{
							a_row["slt_id"] = -1;
							accrument.slt_id = -1;
						}
					}
					else
						accrument.slt_id = (int)( a_row["slt_id"] );
					
					a_row[AccrualGroupTable.PrimaryKey] = accrument.group.ID;
					a_row["prior_accrument"] = reader["prior_accrument"];
					a_row["posted"] = reader["posted"];
					a_row["closed"] = reader["closed"];

					a_row["ball_start"] = reader["ball_start"];
					a_row["ball_delta"] = reader["ball_delta"];
					a_row["ball_end"] = reader["ball_end"];
					a_row["ball_count_set"] = reader["ball_count_set"];

					if( a_row["posted"] == DBNull.Value )
						a_row["posted"] = true;// recover from database; record is NULL; assume posted?

					if( a_row["closed"] == DBNull.Value )
						a_row["closed"] = (bool)( false );

					accrument.input = (decimal)( a_row["input"] = reader["input"] );
					accrument.house = (decimal)( a_row["house"] = reader["house"] );
					accrument.house_percent = (int)( a_row["house_percent"] = reader["house_percent"] );
					a_row["kitty"] = reader["kitty"];
					if( a_row["kitty"] == DBNull.Value )
						accrument.kitty = 0;
					else
						accrument.kitty = (decimal)( a_row["kitty"] );
					accrument.primary_start = (decimal)( a_row["primary_start"] = reader["primary_start"] );
					accrument.primary_percent = (int)( a_row["primary_percent"] = reader["primary_percent"] );
					//accrument.primary          = (decimal)( a_row["primary"] = reader["primary"] );
					accrument.primary_sales = (decimal)( a_row["primary_sales"] = reader["primary_sales"] );
					accrument.primary_transfer = (decimal)( a_row["primary_transfer"] = reader["primary_transfer"] );
					accrument.primary_rollover = (decimal)( a_row["primary_rollover"] = reader["primary_rollover"] );
					accrument.primary_seed = (decimal)( a_row["primary_seed"] = reader["primary_seed"] );
					accrument.primary_fixup = (decimal)( a_row["primary_fixup"] = reader["primary_fixup"] );
					accrument.primary_end = (decimal)( a_row["primary_end"] = reader["primary_end"] );
					accrument.secondary_start = (decimal)( a_row["secondary_start"] = reader["secondary_start"] );
					accrument.secondary_percent = (int)( a_row["secondary_percent"] = reader["secondary_percent"] );
					//accrument.secondary = (decimal)( a_row["secondary"] = reader["secondary"] );
					accrument.secondary_sales = (decimal)( a_row["secondary_sales"] = reader["secondary_sales"] );
					accrument.secondary_transfer = (decimal)( a_row["secondary_transfer"] = reader["secondary_transfer"] );
					accrument.secondary_rollover = (decimal)( a_row["secondary_rollover"] = reader["secondary_rollover"] );
					accrument.secondary_seed = (decimal)( a_row["secondary_seed"] = reader["secondary_seed"] );
					accrument.secondary_fixup = (decimal)( a_row["secondary_fixup"] = reader["secondary_fixup"] );
					accrument.secondary_end = (decimal)( a_row["secondary_end"] = reader["secondary_end"] );
					accrument.tertiary_start = (decimal)( a_row["tertiary_start"] = reader["tertiary_start"] );
					accrument.tertiary_percent = (int)( a_row["tertiary_percent"] = reader["tertiary_percent"] );
					//accrument.tertiary = (decimal)( a_row["tertiary"] = reader["tertiary"] );
					accrument.tertiary_sales = (decimal)( a_row["tertiary_sales"] = reader["tertiary_sales"] );
					accrument.tertiary_transfer = (decimal)( a_row["tertiary_transfer"] = reader["tertiary_transfer"] );
					accrument.tertiary_rollover = (decimal)( a_row["tertiary_rollover"] = reader["tertiary_rollover"] );
					accrument.tertiary_seed = (decimal)( a_row["tertiary_seed"] = reader["tertiary_seed"] );
					accrument.tertiary_fixup = (decimal)( a_row["tertiary_fixup"] = reader["tertiary_fixup"] );
					accrument.tertiary_end = (decimal)( a_row["tertiary_end"] = reader["tertiary_end"] );
					accrument.pay_count = (int)( a_row["pay_count"] = reader["pay_count"] );
					if( reader["paid_from_kitty"] == DBNull.Value )
						accrument.paid_from_kitty = (bool)( a_row["paid_from_kitty"] = false );
					else
						accrument.paid_from_kitty = (bool)( a_row["paid_from_kitty"] = reader["paid_from_kitty"] );
					accrument.pay = (decimal)( a_row["payout"] = reader["payout"] );
					a_row["pay_percent"] = reader["pay_percent"];
					if( a_row["pay_percent"] == DBNull.Value )
						a_row["pay_percent"] = accrument.pay_percent = 100;
					else
						accrument.pay_percent = (int)( a_row["pay_percent"] );

					if( exists.Length == 0 )
						a_row[AccrumentTable.PrimaryKey] = reader[AccrumentTable.PrimaryKey];
					accrument.ID = (Guid)( a_row[AccrumentTable.PrimaryKey] );
					accrument.this_row = a_row;
					if( exists.Length == 0 )
						Rows.Add( a_row );
					a_row.AcceptChanges();  // row state should be 'unmodified'.
				}

				public void FillAccrument( Accrument accrument, Guid accrument_id )
				{
					DbDataReader reader = Local.dataConnection.KindExecuteReader( "select * from [dbo].[ap_accrument] where "
						+ Accrument.AccrumentTable.PrimaryKey + "='" + accrument_id + "'" );
					if( reader.HasRows )
					{
						if( reader.Read() )
							FillAccurmentRow( reader, accrument );
					}
					Local.dataConnection.EndReader( reader );
					{
						DataRow[] sessrow = Local.BingoDataSet.session.Select( "ses_id=" + accrument.ses_id );
						List<DataRow> loaded;
						if( sessrow.Length == 0 )
						{
							loaded = DsnSQLUtil.FillDataTable( Local.dataConnection, Local.BingoDataSet.session, "ses_id=" + accrument.ses_id );
							if( loaded != null )
								sessrow = loaded.ToArray();
						}
						if( sessrow != null && sessrow.Length > 0 )
						{
							accrument.session_date = ( (DateTime)sessrow[0]["ses_date"] ).ToString( "d" );
							{
								DataRow[] ses_slot = Local.BingoDataSet.sesslot.Select( "slt_id=" + sessrow[0]["slt_id"] );
								if( ses_slot.Length > 0 )
									accrument.session_name = Local.StripSpaces( ses_slot[0]["slt_desc"].ToString() );
								else
									accrument.session_name = "NO SESSION FOUND";
							}
						}
					}
				}

				public void FillAccrument( Accrument accrument )
				{
					DataRow[] rows;
					if( accrument.ses_id > 0 )
						rows = Local.accrument_table.Select( AccrualGroupTable.PrimaryKey + "='" + accrument.group.ID + "' and ses_id='" + accrument.ses_id + "'" );
					else
						rows = new DataRow[0];
					if( rows.Length == 0 )
					{
						DbDataReader reader = null;
						if( accrument.ses_id >= 0 )
							reader = Local.dataConnection.KindExecuteReader( "select * from [dbo].[ap_accrument] where " + AccrualGroupTable.PrimaryKey + "='" + accrument.group.ID + "' and ses_id='" + accrument.ses_id + "'" );
						if( reader != null && reader.HasRows )
						{
							while( reader.Read() )
							{
								FillAccurmentRow( reader, accrument );
								
								accrument.this_row["ses_id"] = accrument.ses_id;
								accrument.this_row["slt_id"] = accrument.slt_id;
							}
						}
						else
						{
							DataRow a_row = NewRow();
							accrument.DoMath();
							//if( accrument.ses_id != null )
							{
								a_row["ses_id"] = accrument.ses_id;
								a_row["slt_id"] = accrument.slt_id;
							}
							a_row[AccrualGroupTable.PrimaryKey] = accrument.group.ID;
							if( accrument.prior_accrument != null )
							{
								a_row["prior_accrument"] = accrument.prior_accrument.ID;
							}
							a_row["posted"] = false;
							a_row["closed"] = false;

							a_row["input"] = accrument.input;
							a_row["house"] = accrument.house;
							a_row["house_percent"] = accrument.house_percent;
							a_row["kitty"] = accrument.kitty;
							a_row["primary_start"] = accrument.primary_start;
							//a_row["primary"] = accrument.primary;
							a_row["primary_percent"] = accrument.primary_percent;
							a_row["primary_sales"] = accrument.primary_sales;
							a_row["primary_transfer"] = accrument.primary_transfer;
							a_row["primary_rollover"] = accrument.primary_rollover;
							a_row["primary_seed"] = accrument.primary_seed;
							a_row["primary_fixup"] = accrument.primary_fixup;
							a_row["primary_end"] = accrument.primary_end;
							a_row["secondary_start"] = accrument.secondary_start;
							//a_row["secondary"] = accrument.secondary;
							a_row["secondary_percent"] = accrument.secondary_percent;
							a_row["secondary_sales"] = accrument.secondary_sales;
							a_row["secondary_transfer"] = accrument.secondary_transfer;
							a_row["secondary_rollover"] = accrument.secondary_rollover;
							a_row["secondary_seed"] = accrument.secondary_seed;
							a_row["secondary_fixup"] = accrument.secondary_fixup;
							a_row["secondary_end"] = accrument.secondary_end;
							a_row["tertiary_start"] = accrument.tertiary_start;
							//a_row["tertiary"] = accrument.tertiary;
							a_row["tertiary_percent"] = accrument.tertiary_percent;
							a_row["tertiary_sales"] = accrument.tertiary_sales;
							a_row["tertiary_transfer"] = accrument.tertiary_transfer;
							a_row["tertiary_rollover"] = accrument.tertiary_rollover;
							a_row["tertiary_seed"] = accrument.tertiary_seed;
							a_row["tertiary_fixup"] = accrument.tertiary_fixup;
							a_row["tertiary_end"] = accrument.tertiary_end;
							a_row["pay_count"] = accrument.pay_count;
							a_row["payout"] = accrument.pay;
							a_row["pay_percent"] = accrument.pay_percent;
							a_row["paid_from_kitty"] = accrument.paid_from_kitty;
							a_row["ball_start"] = accrument._ball_start;
							accrument.ID = (Guid)a_row[AccrumentTable.PrimaryKey];
							accrument.this_row = a_row;
							Rows.Add( a_row );
						}
						if( reader != null )
							Local.dataConnection.EndReader( reader );
					}
					else
					{
						// recovered from row already in datatable.
						accrument.input = (decimal)( rows[0]["input"] );
						accrument.house = (decimal)( rows[0]["house"] );
						accrument.house_percent = (int)( rows[0]["house_percent"] );
						accrument.kitty = (int)( rows[0]["kitty"] );

						accrument.primary_start    = (decimal)( rows[0]["primary_start"] );
						//accrument.primary = (decimal)( rows[0]["primary"] );
						accrument.primary_percent  = (int)( rows[0]["primary_percent"] );
						accrument.primary_sales    = (decimal)( rows[0]["primary_sales"] );
						accrument.primary_transfer = (decimal)( rows[0]["primary_transfer"] );
						accrument.primary_rollover = (decimal)( rows[0]["primary_rollover"] );
						accrument.primary_seed = (decimal)( rows[0]["primary_seed"] );
						accrument.primary_fixup    = (decimal)( rows[0]["primary_fixup"] );
						accrument.primary_end      = (decimal)( rows[0]["primary_end"] );

						accrument.secondary_start    = (decimal)( rows[0]["secondary_start"] );
						//accrument.secondary = (decimal)( rows[0]["secondary"] );
						accrument.secondary_percent = (int)( rows[0]["secondary_percent"] );
						accrument.secondary_sales = (decimal)( rows[0]["secondary_sales"] );
						accrument.secondary_transfer = (decimal)( rows[0]["secondary_transfer"] );
						accrument.secondary_rollover = (decimal)( rows[0]["secondary_rollover"] );
						accrument.secondary_seed = (decimal)( rows[0]["secondary_seed"] );
						accrument.secondary_fixup    = (decimal)( rows[0]["secondary_fixup"] );
						accrument.secondary_end      = (decimal)( rows[0]["secondary_end"] );

						accrument.tertiary_start    = (decimal)( rows[0]["tertiary_start"]);
						//accrument.tertiary = (decimal)( rows[0]["tertiary"] );
						accrument.tertiary_percent = (int)( rows[0]["tertiary_percent"] );
						accrument.tertiary_sales = (decimal)( rows[0]["tertiary_sales"] );
						accrument.tertiary_transfer = (decimal)( rows[0]["tertiary_transfer"] );
						accrument.tertiary_rollover = (decimal)( rows[0]["tertiary_rollover"] );
						accrument.tertiary_seed = (decimal)( rows[0]["tertiary_seed"] );
						accrument.tertiary_fixup    = (decimal)( rows[0]["tertiary_fixup"] );
						accrument.tertiary_end      = (decimal)( rows[0]["tertiary_end"] );
						accrument.pay_count = (int)( rows[0]["pay_count"]);
						accrument.pay = (decimal)( rows[0]["payout"]);
						accrument.pay_percent = (int)( rows[0]["pay_percent"] );
						accrument.paid_from_kitty = (bool)( rows[0]["paid_from_kitty"] );
						accrument.ID = (Guid)( rows[0][AccrumentTable.PrimaryKey]);
						accrument.this_row = rows[0];
					}
				}

				internal void SyncAccrument( Accrument accru )
				{
					DataRow accru_row;
					if( accru.ID == null )
					{
						accru_row = NewRow();
						Rows.Add( accru_row );
						accru.ID = (Guid)accru_row[AccrumentTable.PrimaryKey];
						accru.this_row = accru_row;
					}
					else
					{
						if( accru.this_row == null )
						{
							return;
						}
						accru_row = accru.this_row;
					}
					if( accru.ses_id >= 0 )
					{
						accru_row["ses_id"] = accru.ses_id;
						accru_row["slt_id"] = accru.slt_id;
					}

					if( accru.prior_accrument != null )
						accru_row["prior_accrument"] = accru.prior_accrument.ID;

					/* these are handled by direct field updates now */
					//accru_row["posted"] = accru.posted;
					//accru_row["closed"] = accru.closed;

					accru_row["input"] = accru.input;
					accru_row["house"] = accru.house;
					accru_row["house_percent"] = accru.house_percent;
					accru_row["kitty"] = accru.kitty;
					accru_row["primary_percent"] = accru.primary_percent;
					accru_row["secondary_percent"] = accru.secondary_percent;
					accru_row["tertiary_percent"] = accru.tertiary_percent;
					accru_row["primary_start"] = accru.primary_start;
					//accru_row["primary"] = accru.primary;
					accru_row["primary_sales"] = accru.primary_sales;
					accru_row["primary_transfer"] = accru.primary_transfer;
					accru_row["primary_rollover"] = accru.primary_rollover;
					accru_row["primary_seed"] = accru.primary_seed;
					accru_row["primary_fixup"] = accru.primary_fixup;
					accru_row["primary_end"] = accru.primary_end;
					accru_row["secondary_start"] = accru.secondary_start;
					//accru_row["secondary"] = accru.secondary;
					accru_row["secondary_sales"] = accru.secondary_sales;
					accru_row["secondary_transfer"] = accru.secondary_transfer;
					accru_row["secondary_rollover"] = accru.secondary_rollover;
					accru_row["secondary_seed"] = accru.secondary_seed;
					accru_row["secondary_fixup"] = accru.secondary_fixup;
					accru_row["secondary_end"] = accru.secondary_end;
					accru_row["tertiary_start"] = accru.tertiary_start;
					//accru_row["tertiary"] = accru.tertiary;
					accru_row["tertiary_sales"] = accru.tertiary_sales;
					accru_row["tertiary_transfer"] = accru.tertiary_transfer;
					accru_row["tertiary_rollover"] = accru.tertiary_rollover;
					accru_row["tertiary_seed"] = accru.tertiary_seed;
					accru_row["tertiary_fixup"] = accru.tertiary_fixup;
					accru_row["tertiary_end"] = accru.tertiary_end;

					accru_row["pay_count"] = accru.pay_count;
					accru_row["payout"] = accru.pay;
					accru_row["pay_percent"] = accru.pay_percent;
					accru_row["paid_from_kitty"] = accru.paid_from_kitty;
				}
			}

			internal void DoMath()
			{
				if( prior_accrument != null )
				{
					ball_start = prior_accrument.ball_end;

					primary_start = prior_accrument.primary_end;
					secondary_start = prior_accrument.secondary_end;
					tertiary_start = prior_accrument.tertiary_end;
				}
				else if( ses_id < 0 )
				{
					primary_seed = group.SeedValue;
				}
				primary_end = primary_start
					+ primary_sales
					+ primary_transfer
					+ primary_rollover
					+ primary_seed
					+ primary_fixup
					- ( pay * pay_count );
				secondary_end = secondary_start
					+ secondary_sales
					+ secondary_transfer
					+ secondary_rollover
					//+ secondary_seed
					- primary_rollover
					+ secondary_fixup;
				tertiary_end = tertiary_start
					+ tertiary_sales
					+ tertiary_transfer
					//+ tertiary_seed
					- secondary_rollover
					+ tertiary_fixup;

				ball_end = ball_start + ball_delta;
				kitty = input - ( house + primary_sales + secondary_sales + tertiary_sales )
						 - primary_transfer
						 - secondary_transfer
						 - tertiary_transfer;
				if( paid_from_kitty )
					kitty -= pay_count * pay;
				//Log.log( "after domath; synch database..." );
				Local.accrument_table.SyncAccrument( this );
			}


			internal void Process()
			{
				int t = 0;
				Decimal tot = 0M;
				Decimal valtotal = (decimal)input;
				Decimal tmp = valtotal * ( house_percent = group.house_percent ) / 100;
				Decimal rounder;
				if( group.IsDailyAccrual )
					rounder = 0;
				else
					rounder = tmp % 1;

				if (tmp > 0)
				{
					if (rounder > 0)
						tmp -= rounder;
					house = tmp;
				}
				// now remove the house from this.
				valtotal -= tmp;

				if ( group.fixedIncrement )
				{
					if (!group.IsWeeklyAccrual
						&& !group.IsDailyAccrual)
					{
						if (group.fixedIncrement_RemainderToPrimary)
						{
							secondary_sales = group.secondaryIncrement;
							primary_sales = valtotal - secondary_sales;
							tertiary_sales = 0;
						}
						else
						{
							primary_sales = group.primaryIncrement;
						}
						if (group.fixedIncrement_RemainderToSecondary)
						{
							secondary_sales = valtotal - primary_sales;
							tertiary_sales = 0;
						}
						else
						{
							secondary_sales = group.secondaryIncrement;
							tertiary_sales = group.tertiaryIncrement;
						}
					}
					else
					{
						//if( !daily_or_weekly_accrual )
						{
							if( group.fixedIncrement_RemainderToPrimary )
								primary_sales = valtotal - secondary_sales;
							if( group.fixedIncrement_RemainderToSecondary )
								secondary_sales = valtotal - primary_sales;
							tertiary_sales = 0;
						}
					}
				}
				else
				{
					//int tmppercent;
					tmp = (decimal)valtotal * ( primary_percent = group.primary_percent(this) ) / 100;
					if( group.IsDailyAccrual )
						rounder = 0;
					else
						rounder = tmp % 1;
					if( rounder > 0 )
						tmp -= rounder;
					t += primary_percent;
					tot += tmp;
					if( t == 100 )
					{

					}
					if( pay_count > 0 )
					{
						secondary_sales = tmp;

						if( ( secondary_percent = group.secondary_percent ) > 0 )
						{
							tmp = (decimal)valtotal * secondary_percent / 100;
							if( group.IsDailyAccrual )
								rounder = 0;
							else
								rounder = tmp % 1;
							if( rounder > 0 )
								tmp -= rounder;
							t += secondary_percent;
							if( t == 100 )
							{
								tmp = valtotal - tot;
							}
							if( ( tmp + tot ) > valtotal )
							{
								tot = valtotal;
								primary_sales = ( valtotal - tot );
							}
							else
							{
								tot += tmp;
								primary_sales = tmp;
							}
						}

						if( ( tertiary_percent = group.tertiary_percent ) > 0 )
						{
							tmp = (decimal)valtotal * tertiary_percent / 100;
							if( group.IsDailyAccrual )
								rounder = 0;
							else
								rounder = tmp % 1;
							if( rounder > 0 )
								tmp -= rounder;
							t += tertiary_percent;
							if( t == 100 )
							{
								tmp = valtotal - tot;
							}
							if( ( tmp + tot ) > valtotal )
							{
								tertiary_sales = valtotal - tot;
							}
							else
							{
								tertiary_sales = tmp;
							}
						}
						{
							int tmp2;
							tmp2 = primary_percent;
							primary_percent = secondary_percent;
							secondary_percent = tmp2;
						}
					}
					else
					{
						primary_sales = tmp;

						if( ( secondary_percent = group.secondary_percent ) > 0 )
						{
							tmp = (decimal)valtotal * secondary_percent / 100;
							if( group.IsDailyAccrual )
								rounder = 0;
							else
								rounder = tmp % 1;
							if( rounder > 0 )
								tmp -= rounder;
							t += secondary_percent;
							if( t == 100 )
							{
								tmp = valtotal - tot;
							}
							if( ( tmp + tot ) > valtotal )
							{
								tot = valtotal;
								secondary_sales = ( valtotal - tot );
							}
							else
							{
								tot += tmp;
								secondary_sales = tmp;
							}
						}

						if( ( tertiary_percent = group.tertiary_percent ) > 0 )
						{
							tmp = (decimal)valtotal * tertiary_percent / 100;
							if( group.IsDailyAccrual )
								rounder = 0;
							else
								rounder = tmp % 1;
							if( rounder > 0 )
								tmp -= rounder;
							t += tertiary_percent;
							if( t == 100 )
							{
								tmp = valtotal - tot;
							}
							if( ( tmp + tot ) > valtotal )
							{
								tertiary_sales = valtotal - tot;
							}
							else
							{
								tertiary_sales = tmp;
							}
						}
					}
				}
				//Log.log( "processing " + group.Name );
				DoMath();
				//Local.accrument_table.SyncAccrument( this );
			}

			internal Decimal Input
			{
				get
				{
					return input;
				}
				set
				{
					input = value;
					Process();
				}
			}

			internal void SetSecondaryValue( Decimal val )
			{
				secondary_end = val;
				secondary_transfer = val -
					( secondary_start
					+ secondary_seed
					- primary_rollover
					+ secondary_sales );
			}

			internal void SetPrimaryValue( Decimal val )
			{
				primary_end = val;
				primary_transfer = val -
					( primary_start
					+ primary_seed
					+ primary_rollover
					+ primary_fixup
					- ( pay_count * pay )
					+ primary_sales );
			}

			internal Accrument( AccrualGroup group, Guid reload )
			{
				this.group = group;
				Local.accrument_table.FillAccrument( this, reload );

			}

			internal Accrument( AccrualGroup group )
			{
				this.group = group;
				Local.accrument_table.FillAccrument( this );
				if( this.session_name == null )
				{
					this.posted = true;// initial session; ending value is the beginning of time... so it's posted.
					this.closed = true;
				}
				DoMath();
			}

			internal Accrument( AccrualGroup group, DataRow session )
			{
				this.ses_id = (int)session["ses_id"];
				this.slt_id = (int)session["slt_id"];
				this.session_date = ((DateTime)session["ses_date"]).ToString( "d" );
				{
					DataRow[] ses_slot = Local.BingoDataSet.sesslot.Select( "slt_id=" + session["slt_id"] );
					this.session_name = Local.StripSpaces( ses_slot[0]["slt_desc"].ToString() );
				}
				//this.session = session;
				this.group = group;
				Local.accrument_table.FillAccrument( this );
			}

			internal Accrument( Accrument prior_accrument, AccrualGroup group, DataRow session )
			{
				this.ses_id = (int)session["ses_id"];
				this.slt_id = (int)session["slt_id"];
				this.session_date = ( (DateTime)session["ses_date"] ).ToString( "d" );
				{
					DataRow[] ses_slot = Local.BingoDataSet.sesslot.Select( "slt_id=" + session["slt_id"] );
					this.session_name = Local.StripSpaces( ses_slot[0]["slt_desc"].ToString() );
				}
				//this.session = session;
				this.group = group;
				this.prior_accrument = prior_accrument;
				Local.accrument_table.FillAccrument( this );
			}
		}

		[SQLPersistantTable]
		public class AccrualPercentageTable : xperdex.classes.MySQLDataTable<AccrualPercentageTable.AccrumentPercentageTableRow>
		{
			new static public readonly String TableName = "accrual_group_percents";
			new static public readonly String NameColumn = XDataTable.Name( TableName );
			new static public readonly String PrimaryKey = XDataTable.ID( TableName );

			public class AccrumentPercentageTableRow : DataRow
			{
				public AccrumentPercentageTableRow( global::System.Data.DataRowBuilder rb ) :
					base( rb )
				{
				}

				public override string ToString()
				{
					return "Accrual_group_percent_row";
				}

			}

			void InitDataColumns()
			{
				AddDefaultColumns( this, false, true, false );
				Columns.Add( "threshold", typeof( int ) );
				Columns.Add( "primary", typeof( int ) );
				Columns.Add( "secondary", typeof( int ) );
				Columns.Add( "tertiary", typeof( int ) );
				Columns.Add( "kitty", typeof( int ) );
				DataColumn dc;
				dc = Columns.Add( AccrualGroupTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
				if( DataSet != null )
				{

				}
			}

			public AccrualPercentageTable()
			{
				InitDataColumns();
			}
			public AccrualPercentageTable( DataSet dataSet ) 
			{
				dataSet.Tables.Add( this );
				InitDataColumns();
			}
		}

		public class CurrentObjectDataView : DataView
		{
			public static String TableName( String name )
			{
				return "current_" + name;
			}

			DataTable children;
			DataTable parents;
			DataTable[] all_parents;
			protected IMySQLRelationTableBase relation;
			IMetaMySQLRelation relation2;
			//String relation_keyname;
		
			DataRow current_parent;
			String parent_keyname;
			DataRow current_child;
			String child_keyname;

			void InitCurrentObject( DataTable table1, DataTable table2, DataTable[] tables )
			{
				parents = table1;
				if( parents != null )
					parent_keyname = XDataTable.ID( parents );

				children = table2;
				if( children != null )
					child_keyname = XDataTable.ID( children );

				all_parents = tables;
				//NameColumn = relation.Name;
				//session_game_groups = table1.DataSet.Tables[MySQLRelationTable.RelationName( table1, table2 )] as MySQLRelationTable;

				if( children == null && all_parents == null )
				{
					throw new Exception( "Table is not an XDataTable with a DisplayMemberName" );
				}

			}
			//public delegate void FillCurrent( DataRow current_parent );
			//FillCurrent FillMethod;

			void InitDataView( DataSet set, String mirror_table )
			{
				this.Table = set.Tables[mirror_table];
				this.RowFilter = "";
				this.RowStateFilter = DataViewRowState.CurrentRows;
				if( XDataTable.HasNumber( this.Table ) )
					this.Sort = XDataTable.Number( Table );
				else if( Table.Columns.Contains( XDataTable.Name( Table ) ) )
					this.Sort = XDataTable.Name( Table );
			}

			public CurrentObjectDataView( DataSet set, String mirror_table )
			{
				if ( set != null )
				{
					relation = set.Tables[mirror_table] as IMySQLRelationTableBase;

					if ( relation != null )
					{
						InitCurrentObject( relation.parent_table as DataTable
							, relation.child_table as DataTable, null );
					}
					InitDataView( set, mirror_table );
				}
			}

			public CurrentObjectDataView( DataSet set, String mirror_table, bool meta_relation )
			{
				if( meta_relation )
				{
					relation2 = set.Tables[mirror_table] as IMetaMySQLRelation;
					if( relation2 != null )
					{
						relation = relation2 as IMySQLRelationTableBase;
						Table = set.Tables[mirror_table];
						InitCurrentObject( relation2.root_table, null, relation2.parents );
					}
				}
				else
				{
					relation = set.Tables[mirror_table] as IMySQLRelationTableBase;
					if( relation != null )
					{
						InitCurrentObject( relation.parent_table, relation.child_table, null );
					}
				}
				InitDataView( set, mirror_table );
			}


			DataRow _current;
			/// <summary>
			/// this is a magic routine.
			/// If the row you set is from the parent table, then it sets the current parent reference
			/// if the row you set is on the child of the relationship this sets the current child reference.
			/// </summary>
			public DataRow Current
			{
				set
				{
					if( value != null )
					{
						if( relation != null && value.Table.TableName == relation.TableName )
							_current = value;
						//else if( value.Table.TableName == Table.TableName )
						//    _current = value.GetParentRow( relation.TableName );
						else if( all_parents != null )
						{
							if( relation2.root_table.TableName == value.Table.TableName )
							{
								current_parent = value;
								RowFilter = parent_keyname + "='" + value[parent_keyname] + "'";
							}
							else
								foreach( IXDataTable table in all_parents )
								{
									if( table.TableName == value.Table.TableName )
									{
										current_parent = value;
										RowFilter = parent_keyname + "='" + value[parent_keyname] + "'";
									}
								}
						}
						else if( parents != null && parents.TableName == value.Table.TableName )
						{
							current_parent = value;
							RowFilter = parent_keyname + "='" + value[parent_keyname] + "'";
						}
						else if( children != null && children.TableName == value.Table.TableName )
						{
							current_child = value;
						}
						else if( Table != null && Table.TableName == value.Table.TableName )
						{
						}
					}
					else
					{
						RowFilter = "false";
						current_child = null;
						current_parent = null;
						//Rows.Clear();
					}
				}
				get
				{
					return _current;
				}
			}

			public DataRow AddChildMember( DataRow member_row )
			{
				return relation.AddGroupMember( current_parent, member_row );
			}

			public DataRow InsertChildMember( DataRow member_row, DataRow before )
			{
				DataRow new_relation = relation.InsertGroupMember( current_parent, member_row, before );
				if( new_relation != null )
				{
					DataRow[] myself = new_relation.GetChildRows( new_relation.Table.TableName );
					if( myself.Length > 0 )
						return myself[0];
				}
				return null;
			}

			public DataRow ReplaceChildMember( DataRow member_row, DataRow original )
			{
				DataRow new_relation = relation.ReplaceGroupMember( member_row, original );
				if( new_relation != null )
				{
					DataRow[] myself = new_relation.GetChildRows( new_relation.Table.TableName );
					if( myself.Length > 0 )
						return myself[0];
				}
				return null;
			}

		}

		public class CurrentItemList : CurrentObjectDataView
		{
			public CurrentItemList()
				: base( null, bingoDataSet.bingoDataSet.listpickDataTable.TableName )
			{
			}

			public CurrentItemList( DataSet set, String actual_tablename )
				: base( set, actual_tablename )
			{

			}

		}

		public class CurrentAccrualGroupInputSessions : CurrentObjectDataView
		{
			public CurrentAccrualGroupInputSessions()
				: base( null, AccrualGroupTable.AccrualGroupInputSessionTable.TableName )
			{
			}

			public CurrentAccrualGroupInputSessions( DataSet set )
				: base( set, AccrualGroupTable.AccrualGroupInputSessionTable.TableName )
			{

			}

		}

		public class CurrentAccrualGroupInputPrograms : CurrentObjectDataView
		{
			public CurrentAccrualGroupInputPrograms()
				: base( null, AccrualGroupTable.AccrualGroupInputProgramTable.TableName )
			{
			}

			public CurrentAccrualGroupInputPrograms( DataSet set )
				: base( set, AccrualGroupTable.AccrualGroupInputProgramTable.TableName )
			{

			}

		}

		public class CurrentAccrualGroupInputCategories : CurrentObjectDataView
		{
			public CurrentAccrualGroupInputCategories()
				: base( null, AccrualGroupTable.AccrualGroupInputCategoryTable.TableName )
			{
			}

			public CurrentAccrualGroupInputCategories( DataSet set )
				: base( set, AccrualGroupTable.AccrualGroupInputCategoryTable.TableName )
			{

			}

		}


		[SQLPersistantTable]
		public class AccrualGroupTable : xperdex.classes.MySQLDataTable<AccrualGroupTable.AccrualGroupRow>
		{
			new static public readonly String TableName = "accrual_group";
			new static public readonly String NameColumn = XDataTable.Name( TableName );
			new static public readonly String PrimaryKey = XDataTable.ID( TableName );
			new static public readonly String Number = XDataTable.Number( TableName );
			public String _TableColumns;
			[SQLPersistantTable]
			public class AccrualGroupInputSessionTable :
				xperdex.classes.MySQLRelationTable2<AccrualGroupInputSessionTable.AccrualGroupInputSessionRow
						, AccrualGroupTable
						, bingoDataSet.bingoDataSet.sesslotDataTable>
			{
				new static public readonly String TableName = "accrual_group_input_sessions";
				//static public readonly String NameColumn = XDataTable.Name( TableName );
				new static public readonly String PrimaryKey = XDataTable.ID( TableName );

				public AccrualGroupInputSessionTable()
				{
				}
				public AccrualGroupInputSessionTable( DataSet dataSet ): base( dataSet )
				{
				}

				public class AccrualGroupInputSessionRow : DataRow
				{
					public AccrualGroupInputSessionRow( global::System.Data.DataRowBuilder rb ) :
						base( rb )
					{
					}

					public override string ToString()
					{
						return this.GetParentRow( "something" ).ToString();//AccrualGroupTable;
					}
				}
			}

			[SQLPersistantTable]
			public class AccrualGroupInputProgramTable :
				xperdex.classes.MySQLRelationTable2<AccrualGroupInputProgramTable.AccrualGroupInputProgramRow
						, AccrualGroupTable
						, bingoDataSet.bingoDataSet.programDataTable>
			{
				new static public readonly String TableName = "accrual_group_input_programs";
				//static public readonly String NameColumn = XDataTable.Name( TableName );
				new static public readonly String PrimaryKey = XDataTable.ID( TableName );

				public AccrualGroupInputProgramTable()
				{
				}
				public AccrualGroupInputProgramTable( DataSet dataSet ): base( dataSet )
				{
				}

				public class AccrualGroupInputProgramRow : DataRow
				{
					public AccrualGroupInputProgramRow( global::System.Data.DataRowBuilder rb ) :
						base( rb )
					{
					}

					public override string ToString()
					{
						return this.GetParentRow( "something" ).ToString();//AccrualGroupTable;
					}
				}
			}

			[SQLPersistantTable]
			public class AccrualGroupInputCategoryTable :
				xperdex.classes.MySQLRelationTable2<AccrualGroupInputCategoryTable.AccrualGroupInputCategoryRow
						, AccrualGroupTable
						, bingoDataSet.bingoDataSet.categoryDataTable>
			{
				new static public readonly String TableName = "accrual_group_input_categories";
				//static public readonly String NameColumn = XDataTable.Name( TableName );
				new static public readonly String PrimaryKey = XDataTable.ID( TableName );

				public AccrualGroupInputCategoryTable()
				{
				}
				public AccrualGroupInputCategoryTable( DataSet dataSet )
					: base( dataSet )
				{
				}

				public class AccrualGroupInputCategoryRow : DataRow
				{
					public AccrualGroupInputCategoryRow( global::System.Data.DataRowBuilder rb ) :
						base( rb )
					{
					}

					public override string ToString()
					{
						return this.GetParentRow( "something" ).ToString();//AccrualGroupTable;
					}
				}
			}


			[SQLPersistantTable]
			public class AccrualGroupInputListPickTable :
				xperdex.classes.MySQLRelationTable2<AccrualGroupInputListPickTable.AccrualGroupInputListPickRow
						, AccrualGroupTable
						, bingoDataSet.bingoDataSet.listpickDataTable>
			{
				new static public readonly String TableName = "accrual_group_input_list_pick";
				//static public readonly String NameColumn = XDataTable.Name( TableName );
				new static public readonly String PrimaryKey = XDataTable.ID( TableName );
				public AccrualGroupInputListPickTable()
				{
				}
				public AccrualGroupInputListPickTable( DataSet dataSet, string actual_related_table_name )
					: base( dataSet, Local.accrual_group_table, AccrualGroup.AccrualGroupTable.PrimaryKey, Local.item_list, "lst_desc" )
				{
				}

				public class AccrualGroupInputListPickRow : DataRow
				{
					public AccrualGroupInputListPickRow( global::System.Data.DataRowBuilder rb ) :
						base( rb )
					{
					}

					public override string ToString()
					{
						return this.GetParentRow( "something" ).ToString();//AccrualGroupTable;
					}
				}
			}


			public class AccrualGroupRow : DataRow
			{
				public AccrualGroupRow( global::System.Data.DataRowBuilder rb ) :
					base( rb )
				{
				}

				public override string ToString()
				{
					return this[AccrualGroupTable.NameColumn].ToString();
				}

			}

			public String TableColumns
			{
				get
				{
					if( _TableColumns == null )
					{
						bool first = true;
						// TODO: Complete member initialization
						foreach( DataColumn col in Columns )
						{
							if( !first )
								_TableColumns += ",";
							first = false;
							_TableColumns += FullTableName + "." + col.ColumnName;
						}
					}
					return _TableColumns;
				}
			}

			void InitColumns()
			{
				AddDefaultColumns( this, false, true, true );
				DataColumn dc;
				dc = Columns.Add( Number, typeof( int ) );
				dc.DefaultValue = 0;
				dc.AllowDBNull = false;
				dc = Columns.Add( "use_validations", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				dc = Columns.Add( "price_override", typeof( decimal ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				dc = Columns.Add( "any_session", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				dc = Columns.Add( "seed_value", typeof( decimal ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0M;
				dc = Columns.Add( "house_percent", typeof( int ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 30;
				dc = Columns.Add( "posted_value", typeof( decimal ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0M;
				dc = Columns.Add( "daily_accrual", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				dc = Columns.Add( "weekly_accrual", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				dc = Columns.Add( "weekly_accrual_day", typeof( int ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0;
				dc = Columns.Add( "paramutual_accrual", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				dc = Columns.Add( "ball_count", typeof( int ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0;

				dc = Columns.Add( "ball_count_increment_days", typeof( int ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0;
				dc = Columns.Add( "ball_count_max", typeof( int ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0;
				dc = Columns.Add( "ball_count_reset", typeof( int ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0;

				Columns.Add( "fixed_increment", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				Columns.Add( "primary_increment", typeof( decimal ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0.0M;
				Columns.Add( "secondary_increment", typeof( decimal ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0.0M;
				Columns.Add("remainder_to_secondary", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				Columns.Add("remainder_to_primary", typeof(bool));
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				Columns.Add( "tertiary_increment", typeof( decimal ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = 0.0M;
				Columns.Add( "hotball_game_name", typeof( decimal ) );
				dc.AllowDBNull = true;
				dc.DefaultValue = null;
				
				Columns.Add( "last_accrument", XDataTable.DefaultAutoKeyType );

			}

			public AccrualGroupTable()
			{
				InitColumns();
			}

			public AccrualGroupTable( DataSet dataSet )
			{
				InitColumns();
				dataSet.Tables.Add( this );
			}

			internal DataRow CreateAccrualGroup( string s )
			{
				s = DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, s );
				DataRow[] rows = Select( NameColumn + "='" + s + "'" );
				if( rows != null && rows.Length > 0 )
				{
					//Local.jackpot_trans_table.Fill( PrimaryKey + "='" + rows[0][PrimaryKey] + "'" );
					return rows[0];
				}

				this.Fill( NameColumn + "='" + s + "'" );

				DataRow row = NewRow();
				row[NameColumn] = s;
				//row[PrimaryKey] = Guid.NewGuid();
				Rows.Add( row );
				return row;
			}
		}

		/*
		class AccrualOperation
		{
			int operation;
		}
		*/

		internal void LoadPriorAccruals()
		{
			Accrument check_accru = accruments.First.Value;
			Accrument accru = accruments.First.Value;
			Accrument test = accru;
			if( IsWeeklyAccrual )
			{
				DateTime start = Convert.ToDateTime( _prior_accrument.session_date );
				DateTime check;
				TimeSpan week = new TimeSpan( 7,0,0,0,0 );
				do
				{
					if( test.this_row != null
						&& test.this_row["prior_accrument"] != DBNull.Value )
					{
						test = GetPriorAccrument( test, (Guid)test.this_row["prior_accrument"] );
						check = Convert.ToDateTime( test.session_date );
						if( ( test.pay != 0 ) || ( test.primary_sales != 0 ) )
						{
							break;
						}
					}
					else
						break;
				}
				while( ( ( start - check ) <= week ) && ( String.Compare( test.session_date, check_accru.session_date ) == 0 ) );
			}
			else
			{
				do
				{
					if( test.this_row != null
						&& test.this_row["prior_accrument"] != DBNull.Value )
						test = GetPriorAccrument( test, (Guid)test.this_row["prior_accrument"] );
					else
						break;
				}
				while( String.Compare( test.session_date, check_accru.session_date ) == 0 );
			}
		}

		//List<Session> source_sessions;

		internal void ReloadAccruments()
		{
			if( _prior_accrument != null && _prior_accrument.prior_accrument != null )
				if( !_prior_accrument.posted )
				{
					_prior_accrument = _prior_accrument.prior_accrument;
					this_row["last_accrument"] = _prior_accrument.ID;
				}
			if( this_row["last_accrument"] != DBNull.Value )
			{
				bool need_more;
				Accrument accru = GetAccrument( (Guid)this_row["last_accrument"] );
				DateTime first_loaded = Convert.ToDateTime( accru.session_date );
				TimeSpan CheckSpan = new TimeSpan( 7,0,0,0 );
				DateTime ended_weekly = first_loaded;
				Accrument test = accru;
				bool finish_day = false;
				do
				{
					need_more = false;
					if( test.this_row != null
						&& test.this_row["prior_accrument"] != DBNull.Value )
					{
						test = GetPriorAccrument( test, (Guid)test.this_row["prior_accrument"] );
						if( IsDailyAccrual && test.posted == false )
							need_more = true;
						if( finish_day )
						{
							DateTime check_Date = Convert.ToDateTime( test.session_date );
							if( check_Date == ended_weekly )
								need_more = true;
							else
								break;
						}
						else if( IsWeeklyAccrual )
						{
							if( test.pay == 0 && test.primary_sales == 0 )
							{
								DateTime this_loaded = Convert.ToDateTime( test.session_date );
								if( ( first_loaded - this_loaded ) <= CheckSpan )
									need_more = true;
							}
							else
							{
								need_more = true;
								ended_weekly = Convert.ToDateTime( test.session_date );
								finish_day = true;
							}
						}
					}
					else
						break;
				}
				while( need_more || String.Compare( test.session_date, _prior_accrument.session_date ) == 0 );
			}
			else
			{
				Accrument initial = GetAccrument();
				initial.posted = true; // new jackpot, no prior record, set posted (again probably)
			}
		}

		internal AccrualGroup( String s )
		{
			foreach( AccrualGroup l in Local.known_accrual_groups )
			{
				if( String.Compare( s, l.Name, true ) == 0 )
					throw new Exception( "Ledger of that name already exists." );
			}

			Name = s;
			this_row = Local.accrual_group_table.CreateAccrualGroup( s );
			/*
			int tmp;
			if( Int32.TryParse( this_row["primary"].ToString(), out tmp ) )
				primary_percent = tmp;
			if( Int32.TryParse( this_row["secondary"].ToString(), out tmp ) )
				secondary_percent = tmp;
			if( Int32.TryParse( this_row["tertiary"].ToString(), out tmp ) )
				tertiary_percent = tmp;
			*/
			ID = (Guid)this_row[AccrualGroupTable.PrimaryKey];
			Name = s;

			ReloadAccruments();

			{
				DataTable accrual_percents = Local.BingoDataSet.Tables[AccrualPercentageTable.TableName];
				List<DataRow> loaded = DsnSQLUtil.FillDataTable( Local.dataConnection, accrual_percents, AccrualGroupTable.PrimaryKey + "='" + ID + "'", "threshold" );
				//DataRow[] torecover = accrual_percents.Select( AccrualGroupTable.PrimaryKey + "='" + row[AccrualGroupTable.PrimaryKey] + "'" );
				if( loaded != null )
					foreach( DataRow load in loaded )
					{
						Decimal th;
						int p, sec, te, k;
						Decimal.TryParse( load["threshold"].ToString(), out th );
						Int32.TryParse( load["primary"].ToString(), out p );
						Int32.TryParse( load["secondary"].ToString(), out sec );
						Int32.TryParse( load["tertiary"].ToString(), out te );
						Int32.TryParse( load["kitty"].ToString(), out k );
						AccrualPercents data = new AccrualPercents( th, p, sec, te, k );
						accrual_percentages.AddLast( data );
					}

			}
			if( accrual_percentages.First == null )
			{
				AccrualPercents default_percents = new AccrualPercents( 0, 70, 30, 0, 0 );
				accrual_percentages.AddFirst( default_percents );
				SyncPercentages();
			}
		}

		public override string ToString()
		{
			return Name;
		}

		public Decimal PriceOverrideValue
		{
			set
			{
				//Log.log( "Update " + Name + " price override to " + value );
				this_row["price_override"] = value;
			}
			get
			{
				if( this_row["price_override"] == DBNull.Value )
					return 0M;
				return Convert.ToDecimal( this_row["price_override"] );
			}
		}

		public bool PriceOverride
		{
			get
			{
				//Log.log( "overrid " +Name + " is " + this_row["price_override"] );
				if( this_row["price_override"] == DBNull.Value )
					return false;
				return Convert.ToDecimal( this_row["price_override"] ) != 0M;
			}

		}

		public int display_order
		{
			get
			{
				return Convert.ToInt32( this_row[AccrualGroupTable.Number] );
			}
			set
			{
				this_row[AccrualGroupTable.Number] = value;
			}
		}

		public bool fixedIncrement_RemainderToSecondary
		{
			get
			{
				if( this_row["remainder_to_secondary"] == DBNull.Value )
					return false;
				return Convert.ToBoolean( this_row["remainder_to_secondary"] );
			}
			set
			{
				this_row["remainder_to_secondary"] = value;
			}
		}

		public bool fixedIncrement_RemainderToPrimary
		{
			get
			{
				if (this_row["remainder_to_primary"] == DBNull.Value)
					return false;
				return Convert.ToBoolean(this_row["remainder_to_primary"]);
			}
			set
			{
				this_row["remainder_to_primary"] = value;
			}
		}

		public bool fixedIncrement
		{
			get
			{
				if( this_row["fixed_increment"] == DBNull.Value )
					return false;
				return Convert.ToBoolean( this_row["fixed_increment"] );
			}
			set
			{
				this_row["fixed_increment"] = value;
			}
		}

		public decimal primaryIncrement
		{
			get
			{
				if( this_row["primary_increment"] == DBNull.Value )
					return 0.0M;
				return Convert.ToDecimal( this_row["primary_increment"] );
			}
			set
			{
				this_row["primary_increment"] = value;
			}
		}
		public decimal secondaryIncrement
		{
			get
			{
				if( this_row["secondary_increment"] == DBNull.Value )
					return 0.0M;
				return Convert.ToDecimal( this_row["secondary_increment"] );
			}
			set
			{
				this_row["secondary_increment"] = value;
			}
		}
		public decimal tertiaryIncrement
		{
			get
			{
				if( this_row["tertiary_increment"] == DBNull.Value )
					return 0.0M;
				return Convert.ToDecimal( this_row["tertiary_increment"] );
			}
			set
			{
				this_row["tertiary_increment"] = value;
			}
		}

		public string hotball_game_name
		{
			get
			{
				if( this_row["hotball_game_name"] == DBNull.Value )
					return "";
				return this_row["hotball_game_name"].ToString();
			}
			set
			{
				this_row["hotball_game_name"] = value;
			}
		}

		public int house_percent
		{
			set
			{
				this_row["house_percent"] = value;
			}
			get
			{
				if( this_row["house_percent"] == DBNull.Value )
					return 30;
				return (int)this_row["house_percent"];
			}
		}
		public int ball_count_max
		{
			set
			{
				this_row["ball_count_max"] = value;
			}
			get
			{
				if( this_row["ball_count_max"] == DBNull.Value )
					return 75;
				return (int)this_row["ball_count_max"];
			}
		}
		public int ball_count_reset
		{
			set
			{
				this_row["ball_count_reset"] = value;
			}
			get
			{
				if( this_row["ball_count_reset"] == DBNull.Value )
					return 1;
				return (int)this_row["ball_count_reset"];
			}
		}
		public int ball_count_increment_days
		{
			set
			{
				this_row["ball_count_increment_days"] = value;
			}
			get
			{
				if( this_row["ball_count_increment_days"] == DBNull.Value )
					return 30;
				return (int)this_row["ball_count_increment_days"];
			}
		}

		public int ball_count
		{
			set
			{
				this_row["ball_count"] = value;
			}
			get
			{
				if( this_row["ball_count"] == DBNull.Value )
					return 0;
				return (int)this_row["ball_count"];
			}
		}

		public bool UseValidations
		{
			set{
				this_row["use_validations"] = value;
			}
			get{
				if( this_row["use_validations"] == DBNull.Value )
					return false;
				return (bool)this_row["use_validations"];
			}
		} 

		public bool AnySession {
			set{
				this_row["any_session"] = value;
			}
			get{
				if( this_row["any_session"] == DBNull.Value )
					return false;
				return (bool)this_row["any_session"];
			}
		}

		public Decimal PostedValue
		{
			set{
				this_row["posted_value"] = value;
			}
			get{
				if( this_row["posted_value"] == DBNull.Value )
					return 0M;
				return (Decimal)this_row["posted_value"];
			}
		}

		public bool IsWeeklyAccrual
		{
			set
			{
				this_row["weekly_accrual"] = value;
			}
			get
			{
				if( this_row["weekly_accrual"] == DBNull.Value )
					return true;
				return (bool)this_row["weekly_accrual"];
			}
		}

		public int WeeklyAccrualDay
		{
			set
			{
				this_row["weekly_accrual_day"] = value;
			}
			get
			{
				if( this_row["weekly_accrual_day"] == DBNull.Value )
					return 0;
				return (int)this_row["weekly_accrual_day"];
			}
		}

		public bool IsDailyAccrual
		{
			set
			{
				this_row["daily_accrual"] = value;
			}
			get
			{
				if( this_row["daily_accrual"] == DBNull.Value )
					return false;
				return (bool)this_row["daily_accrual"];
			}
		}

		public bool IsParamutualAccrual
		{
			set
			{
				this_row["paramutual_accrual"] = value;
			}
			get
			{
				if( this_row["paramutual_accrual"] == DBNull.Value )
					return false;
				return (bool)this_row["paramutual_accrual"];
			}
		}

		public Decimal SeedValue
		{
			set{
				this_row["seed_value"] = value;
			}
			get{
				if( this_row["seed_value"] == DBNull.Value )
					return 0M;
				return (Decimal)this_row["seed_value"];
			}
		}

		public string CategorySet
		{
			get
			{
				String set = null;
				DataRow[] items = this_row.GetChildRows( "accrual_group_has_category" );
				foreach( DataRow item in items )
				{
					if( set != null )
						set += ",";
					set += item["ctg_id"].ToString();
				}
				return set;
			}

		}

		public string ItemSet
		{
			get
			{
				String set = null;
				DataRow[] items = this_row.GetChildRows( "accrual_group_has_listpick1" );
				foreach( DataRow item in items )
				{
					if( set != null )
						set += ",";
					set += "'" + item["lst_desc"].ToString() + "'";
				}
				return set;
			}
		}

		public bool CountsValidations
		{
			get{
				if( this.UseValidations )
					return true;
				return false;
			}
		}

		public bool CountsSession( object slt_id )
		{
			if( this.AnySession )
				return true;
			DataRow[] related_sessions = this_row.GetChildRows( "accrual_group_has_sesslot" );
			foreach( DataRow session in related_sessions )
				if( slt_id.Equals( session["slt_id"] ) )
					return true;
			return false;
		}


		//internal void InputValue( decimal valtotal )
	//	{
	//		input_ledger.Transfer( valtotal, Local.players );
	//	}

		internal void SyncPercentages()
		{
			DataTable accrual_percents = Local.BingoDataSet.Tables[AccrualPercentageTable.TableName];
			DataRow[] todelete = accrual_percents.Select( AccrualGroupTable.PrimaryKey + "='" + ID + "'" );
			foreach( DataRow row in todelete )
				row.Delete();

			//Local.dataConnection.KindExecuteNonQuery( "delete from " + MySQLDataTable.GetCompleteTableName( accrual_percents ) + " where " + AccrualGroupTable.PrimaryKey + "='" + ID + "'" );
			foreach( AccrualPercents data in accrual_percentages )
			{
				DataRow row = accrual_percents.NewRow();
				row["threshold"] = data.threshold;
				row["primary"] = data.primary;
				row["secondary"] = data.secondary;
				row["tertiary"] = data.tertiary;
				row["kitty"] = data.kitty;
				row[AccrualGroupTable.PrimaryKey] = ID;
				accrual_percents.Rows.Add( row );
			}
		}

		internal Accrument _prior_accrument;
		internal Accrument prior_accrument 
		{
			get
			{
				return _prior_accrument;
			}
			set
			{
				_prior_accrument = value;
				if( value != null )
					this_row["last_accrument"] = value.ID;
			}
		}

		internal Accrument GetAccrument( Guid reload_ID )
		{
			AccrualGroup.Accrument accru = new AccrualGroup.Accrument( this, reload_ID );
			if( accruments.Count > 0 )
				accru.prior_accrument = accruments.Last.Value;
			accruments.AddLast( accru );
			_prior_accrument = accru;
			return accru;
		}

		internal Accrument GetPriorAccrument( Accrument _this, Guid reload_ID )
		{
			AccrualGroup.Accrument accru = new AccrualGroup.Accrument( this, reload_ID );
			if( accruments.Count > 0 )
				accruments.First.Value.prior_accrument = accru;
			accruments.AddBefore( accruments.First, accru );
			//_prior_accrument = accru;
			return accru;
		}

		internal Accrument GetAccrument()
		{
			AccrualGroup.Accrument accru = new AccrualGroup.Accrument( this );
			if( accruments.Count > 0 )
				accru.prior_accrument = accruments.Last.Value;
			accruments.AddLast( accru );
			_prior_accrument = accru;
			return accru;
		}

		//bool post_weekly_last_session = true;

		internal Accrument GetAccrument( DataRow sessrow, bool do_weekly_accruments )
		{
			if( _prior_accrument.ses_id < 0 )
			{
				_prior_accrument.posted = false;
				_prior_accrument.ses_id = (int)sessrow["ses_id"];
				_prior_accrument.slt_id = (int)sessrow["slt_id"];
				_prior_accrument.session_date = sessrow["ses_date"].ToString();
				{
					DataRow[] ses_slot = Local.BingoDataSet.sesslot.Select( "slt_id=" + sessrow["slt_id"] );
					if( ses_slot.Length > 0 )
						_prior_accrument.session_name = Local.StripSpaces( ses_slot[0]["slt_desc"].ToString() );
					else
						_prior_accrument.session_name = "NO SESSION FOUND";
				}
				_prior_accrument.this_row["ses_id"] = sessrow["ses_id"];
				_prior_accrument.this_row["slt_id"] = sessrow["slt_id"];
				return _prior_accrument;
			}
			foreach( Accrument check in accruments )
			{
				if( check.ses_id >= 0 && sessrow["ses_id"].Equals( check.ses_id ) )
					return check;
			}
                        bool add_daily_accrual = false;
			if( IsDailyAccrual )
			{
				DateTime prior = Convert.ToDateTime( prior_accrument.session_date );
				DateTime now = (DateTime)sessrow["ses_date"];
				if( prior.Date != now.Date )
				{
                                	add_daily_accrual = true;
				}
			}
			bool add_weekly_accrual = false;
			if( do_weekly_accruments )
			{
				if( IsWeeklyAccrual )
				{
					{
						DateTime Start = (DateTime)Local.current_session["ses_date"];
						DateTime check_date = Start;
						int count_to_day = 0;
						int count_to_change_day = 0;
						Accrument test = prior_accrument;
						while( test != null && test.primary_sales == 0 && test.pay == 0 )
						{
							if( test != null )
							{
								check_date = Convert.ToDateTime( test.session_date );
								if( check_date == Start )
									count_to_day++;
							}
							else
								break;
							test = test.prior_accrument;
						}
						if( test != null )
						{
							TimeSpan day_count = new TimeSpan( 7, 0, 0, 0, 0 );
							if( ( Start - check_date ) > day_count )
							{
								add_weekly_accrual = true;
							}
							else if( Start - check_date == day_count )
							{
								DateTime check_start = check_date;
								while( test != null )
								{
									test = test.prior_accrument;
									if( test != null )
									{
										check_date = Convert.ToDateTime( test.session_date );
										if( check_date == check_start )
											count_to_change_day++;
										else
											break;
									}
									else
										break;
								}
								if( count_to_day >= count_to_change_day )
									add_weekly_accrual = true;
							}
						}
					}
				}
			}
			AccrualGroup.Accrument accru = new AccrualGroup.Accrument( prior_accrument, this, sessrow );
			if( accruments.Count > 0 )
				accru.prior_accrument = accruments.Last.Value;
			accruments.AddLast( accru );
			prior_accrument = accru;
			// weekly will never be true if bypass flag is passed.
			Local.ProcessBallAccruals( this );
			if( add_daily_accrual )
			{
				accru.daily_or_weekly_accrual = true;
 				accru.primary_sales = this.primaryIncrement;
				accru.secondary_sales = this.secondaryIncrement;
				accru.tertiary_sales = this.tertiaryIncrement;
				accru.posted = true;
			}
			if( add_weekly_accrual )
			{
				accru.daily_or_weekly_accrual = true;
				accru.primary_sales = this.primaryIncrement;
				accru.secondary_sales = this.secondaryIncrement;
				accru.tertiary_sales = this.tertiaryIncrement;
				accru.posted = true;
			}
			accru.DoMath();

			return accru;
		}

		internal void Payout( Accrument accrual, int winners, int pay_percent, decimal payout, bool pay_from_kitty )
		{
			accrual.pay = payout;
			accrual.pay_count = winners;
			accrual.pay_percent = pay_percent;
			accrual.paid_from_kitty = pay_from_kitty;

			if( !pay_from_kitty )
			{
				accrual.primary_rollover = accrual.secondary_start;
				accrual.secondary_rollover = accrual.tertiary_start;
				// make sure to load the sales for this accrument...
				// otherwise later we'll get sales added secondarily.
				Local.ProcessAccrualGroupAccrument( this, prior_accrument );
				accrual.Process();

				Decimal newval = accrual.primary_start
						+ accrual.primary_sales
						+ accrual.primary_transfer
						+ accrual.primary_rollover
						+ accrual.primary_fixup
						- ( accrual.pay * accrual.pay_count );
				//Log.log( "and so new value is " + accrual.primary_start + " " + accrual.primary_sales + " " + accrual.primary_transfer + " " + accrual.primary_rollover + " " + accrual.primary_fixup + " and seed is " + SeedValue );
				if( newval < SeedValue )
				{
					//Log.log( "and so new value is " + newval + " and seed is " + SeedValue );
					accrual.primary_seed = SeedValue - newval;
					accrual.primary_end += accrual.primary_seed;
					//Log.log( "and so new value is " + accrual.primary_seed );
				}

				if( ball_count_increment_days > 0 )
				{
					accrual.ball_count_set = true;
					accrual.ball_delta = this.ball_count_reset - accrual.ball_start;
					accrual.ball_end = accrual.ball_start + accrual.ball_delta;
				}
				// otherwise it will be posted as a matter of session close...
				if( IsDailyAccrual )
				{
					Local.PostAccrual( this );
				}
			}
			else
				prior_accrument.DoMath();

		}

		internal Accrument GetLastPosted()
		{
			LinkedListNode<Accrument> check = accruments.Last;
			while( check != null && check.Previous != null )
			{
				if( check.Value.posted )
					return check.Value;
				check = check.Previous;
			}
			return check.Value;
		}
	}

	internal class AccrualGroupList : List<AccrualGroup>
	{
		internal AccrualGroupList()
		{
		}
		internal AccrualGroup this[string member]
		{
			get { foreach( AccrualGroup AccrualGroup in this ) { if( String.Compare( AccrualGroup.ToString(), member, true ) == 0 ) return AccrualGroup; } return null; }
		}
	}
}
