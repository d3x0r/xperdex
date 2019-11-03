using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ECube.AccrualProcessor
{
	class ProgessiveTickStatic : xperdex.core.interfaces.IReflectorVariable
	{
		public string Name
		{
			get
			{
				return "Post Timer Status";
			}
		}

		public string Text
		{
			get
			{
				if( Local.postTimer != null )
				{
					if( Local.postTimer.updating )
						return "Updating...";
					if( Local.postTimer.posting )
						return "posting...";
					return "Idle";
				}
				return "Timer Disabled";
			}

			set
			{
				
			}
		}
	}

	class JackpotValueVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Jackpot_Value_I"; }
			}
			int xperdex.core.interfaces.IReflectorVariableArray.Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}

			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{
							/*
							if( v.prior_accrument != null )
							{
								if( v.prior_accrument.posted )
									return v.prior_accrument.primary_end.ToString( "C" );
								if( v.prior_accrument.this_row.RowState != DataRowState.Unchanged )
								{
									if( v.prior_accrument.primary_start != 0 )
										return v.prior_accrument.primary_start.ToString( "C" );
									else
										return ( v.prior_accrument.primary_start + v.prior_accrument.primary_seed ).ToString( "C" );
								}
							}
							s*/
							return v.prior_accrument.primary_start.ToString( "C" );
						}
					}
					return "";
				}
			}

			#endregion
		}

		class JackpotNameVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Jackpot Name_I"; }
			}
			public int Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}

			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{
							return v.Name;
						}
					}
					return "";
				}
			}

			#endregion
		}

		class JackpotPostedValueVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Posted Jackpot Value_I"; }
			}
			int xperdex.core.interfaces.IReflectorVariableArray.Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}

			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{
							Decimal a = v.PostedValue;
							Decimal b = v.GetPostedvalue();
							if( a != b )
							{
								xperdex.classes.Log.log( "discrepency on " + v.Name + " is " + a.ToString( "C" ) + " and " + b.ToString( "C" ) );
								return "* " + b.ToString( "C" );
							}
							return a.ToString( "C" );
						}
					}
					return "";
				}
			}

			#endregion
		}

		class BallsPostedValueVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Posted Ball Count_I"; }
			}
			int xperdex.core.interfaces.IReflectorVariableArray.Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}
			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{
							//Decimal a = v.PostedValue; 
							if( v.prior_accrument.ball_count_set )
								return v.prior_accrument.ball_end.ToString();  // intelligent search through accrument records
							else
								return v.prior_accrument.ball_start.ToString();  // intelligent search through accrument records
						}
					}
					return "";
				}
			}

			#endregion
		}


		class JackpotUpdatedValueVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Jackpot_Updated_Value_I"; }
			}
			int xperdex.core.interfaces.IReflectorVariableArray.Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}
			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{

							if( v.prior_accrument != null )
							{
								if( v.prior_accrument.posted )
									return v.prior_accrument.primary_end.ToString( "C" );
								if( v.prior_accrument.this_row.RowState != DataRowState.Unchanged )
								{
									if( v.prior_accrument.primary_start != 0 )
										return v.prior_accrument.primary_start.ToString( "C" );
									else
										return ( v.prior_accrument.primary_start
											+ v.prior_accrument.primary_seed ).ToString( "C" );
								}
							}

							return v.prior_accrument.primary_end.ToString( "C" );
						}
					}
					return "";
				}
			}

			#endregion
		}

		class JackpotBallCountVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Ball Count_I"; }
			}
			int xperdex.core.interfaces.IReflectorVariableArray.Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}

			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{
							return v.ball_count.ToString();
						}
					}
					return "";
				}
			}

			#endregion
		}

		class AccrualCurrentPercentVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Current Percent_I"; }
			}
			int xperdex.core.interfaces.IReflectorVariableArray.Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}

			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{
							return v.primary_percent( v.GetLastPosted() ).ToString();
						}
					}
					return "";
				}
			}

			#endregion
		}

		class JackpotNextValueVariableIndexed : xperdex.core.interfaces.IReflectorVariableArray
		{
			#region IReflectorVariable Members

			string xperdex.core.interfaces.IReflectorVariableArray.Name
			{
				get { return "Jackpot New Value_I"; }
			}
			int xperdex.core.interfaces.IReflectorVariableArray.Count
			{
				get
				{
					return Local.known_accrual_groups.Count;
				}
			}

			string xperdex.core.interfaces.IReflectorVariableArray.this[int member]
			{
				get
				{
					if( member < Local.known_accrual_groups.Count )
					{
						AccrualGroup v = Local.known_accrual_groups[member];
						if( v != null )
						{
							//if( v.this_row.RowState != DataRowState.Unchanged
							//	&& v.prior_accrument != null
							//	&& v.prior_accrument.prior_accrument != null )
							//	return v.prior_accrument.primary_start.ToString( "C" );
							return v.prior_accrument.primary_end.ToString( "C" );
						}
					}
					return "";
				}
			}

			#endregion
		}
}
