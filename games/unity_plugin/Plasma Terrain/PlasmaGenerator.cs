using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace org.d3x0r.xperdex.games.unity_plugin
{
	public class PlasmaGenerator
	{

		internal class grid : ICloneable
		{
			internal int x, y, x2, y2;
			internal struct grid_notes
			{
				internal bool skip_left;
				internal bool skip_top;
				internal bool skip_right;
				internal bool skip_bottom;
			} 
			internal grid_notes notes;

			internal grid( )
			{
				// allow default 0 init on everything.
			}
			internal grid( grid clone )
			{
				this.x = clone.x;
				this.x2 = clone.x2;
				this.y = clone.y;
				this.y2 = clone.y2;
				notes = clone.notes;
			}
		
			public object Clone()
			{
				return new grid( this );
			}
		};

		public class plasma_patch
		{
			// where I am.
			internal int x, y;
			internal float[] corners = new float[4];
			internal int seed_corner;
			internal int saved_seed_corner;
			internal float min_height;
			internal float max_height;
			internal float _min_height;
			internal float _max_height;
			internal SaltyRandomGenerator entropy;
			internal float[] map;
			internal float[] map1;
			internal float area_scalar;
			internal float horiz_area_scalar;

			internal SaltyRandomGenerator entopy_state;
			internal plasma_state plasma;


			internal plasma_patch as_left;
			internal plasma_patch as_top;
			internal plasma_patch as_right;
			internal plasma_patch as_bottom;

			internal plasma_patch()
			{
			}

			internal plasma_patch( plasma_state  map, float[] seed, float roughness )
			{
				plasma = map;

				System.Diagnostics.Debug.WriteLine( " new floats...  " );
				map1 = new float[map.stride * map.rows];
				this.map =  new float[map.stride * map.rows];

				seed_corner = -1;   // first seed is patch corrdinate, then the corners

				area_scalar = roughness;
				horiz_area_scalar = roughness;
				entopy_state = null;
				corners[0] = seed[0];
				corners[1] = seed[1];
				corners[2] = seed[2];
				corners[3] = seed[3];
				{
					int n;
					_min_height = 0;
					_max_height = 1;
					min_height = 1;
					max_height = 0;
					/*
					for( n = 0; n < 4; n++ )
					{
						float this_point = corners[n];
						if( this_point > max_height )
							_max_height
								= max_height 
								= this_point;
						if( this_point < min_height )
							_min_height 
								= min_height
								= this_point;
					}
					*/
				}
				System.Diagnostics.Debug.WriteLine( " salty generator " );

				entropy = new SaltyRandomGenerator();
				entropy.getsalt += FeedRandom;
				System.Diagnostics.Debug.WriteLine( " salty generator done..." );

				//if( initial_render )
				//grid next;
				//	PlasmaRender( plasma, corners );
			}

			void FeedRandom( SaltyRandomGenerator.SaltData salt_data )
			{
				if( seed_corner < 0 )
				{
					salt_data += BitConverter.GetBytes( x );
					salt_data += BitConverter.GetBytes( y );
				}
				else
				{
					salt_data += BitConverter.GetBytes( corners[ seed_corner ] );
				}
				seed_corner++;
				if( seed_corner > 3 )
					seed_corner = 0;
			}

			public void Render( )
			{
				PlasmaRender( this, corners );
			}

			static int mid(int a, int b )
			{
				return (((a)+(b))/2);
			}

			Queue<grid> pdq_todo;
			void PlasmaFill2( plasma_patch plasma, float[] map, grid here )
			{
				int mx, my;
				grid next = new grid();
				float del;
				float center;
				float this_point;
				int stride = plasma.plasma.stride;
				int rows = plasma.plasma.rows;



				if( pdq_todo == null )
					pdq_todo = new Queue<grid>( rows*stride/2 );
				
				do
				{
					mx = ( here.x2 + here.x ) / 2;
					my = ( here.y2 + here.y ) / 2;

					// may be a pinched rectangle... 3x2 that just has 2 mids top bottom to fill no center
					//System.Diagnostics.Debug.WriteLine( "center " + mx +"," + my + "  next is " + here.x +","+ here.y+","+ here.x2+","+ here.y2 );

					//lprintf( "center %d,%d  next is %d,%d %d,%d", mx, my, here.x, here.y, here.x2, here.y2 );

					if( ( mx != here.x ) && ( my != here.y ) )
					{
						float del1 = ( ( plasma.entropy.GetEntropy( 7, false ) / 128.0f ) - 0.5f );
						float area = (float)( Math.Sqrt( ( ( here.x2 - here.x )*( here.x2 - here.x ) + ( here.y2 - here.y )*( here.y2 - here.y )) ) / ( plasma.area_scalar ) );
						float avg = ( map[here.x + here.y*stride] + map[here.x2 + here.y*stride]
										 + map[here.x + here.y2*stride] + map[here.x2 + here.y2*stride] ) / 4;
						//avg += ( map[here.x + my*stride] + map[here.x2 + my*stride]
						//				 + map[mx + here.y*stride] + map[mx + here.y2*stride] ) / 4;
						//avg /= 2;
						//lprintf( "Set point %d,%d = %g (%g) %g", mx, my, map[mx + my * stride], avg );
						center 
							= this_point
							= map[mx + my * stride] = avg + ( area *  del1 );
						/*
						if( map[mx + my * stride] > 1.0 )
							map[mx + my * stride] = 1.0;
						if( map[mx + my * stride] < 0.0 )
							map[mx + my * stride] = 0.0;
						*/
							if( this_point > plasma.max_height )
								plasma.max_height = this_point;
							if( this_point < plasma.min_height )
								plasma.min_height = this_point;

						if( mid( next.x = here.x, next.x2 = mx ) != next.x 
							&& mid( next.y = here.y, next.y2 = my ) != next.y  )
						{
							//next.x = here.x;
							//next.y = here.y;
							//next.x2 = mx;
							//next.y2 = my;
							next.notes.skip_left = here.notes.skip_left;
							next.notes.skip_top = here.notes.skip_top;
							pdq_todo.Enqueue( new grid( next ) );
						}
						if( mid( next.x = mx, next.x2 = here.x2 ) != next.x 
							&& mid( next.y = here.y, next.y2 = my ) != next.y  )
						{
							//next.x = mx;
							//next.y = here.y;
							//next.x2 = here.x2;
							//next.y2 = my;
							next.notes.skip_left = true;
							next.notes.skip_top = here.notes.skip_top;
							pdq_todo.Enqueue( new grid( next ) );
						}
						if( mid( next.x = here.x, next.x2 = mx ) != next.x 
							&& mid( next.y = my, next.y2 = here.y2 ) != next.y  )
						{
							//next.x = here.x;
							//next.y = my;
							//next.x2 = mx;
							//next.y2 = here.y2;
							next.notes.skip_left = here.notes.skip_left;
							next.notes.skip_top = true;
							pdq_todo.Enqueue( new grid( next ) );
						}
						if( mid( next.x = mx, next.x2 = here.x2 ) != next.x 
							&& mid( next.y = my, next.y2 = here.y2 ) != next.y  )
						{
							//next.x = mx;
							//next.y = my;
							//next.x2 = here.x2;
							//next.y2 = here.y2;
							next.notes.skip_left = true;
							next.notes.skip_top = true;
							pdq_todo.Enqueue( new grid( next ) );
						}
					}
					else 
					{
						//lprintf( "Squre, never happens..." );
						if( mx != here.x )
						{
							center = ( map[here.x + here.y*stride] + map[here.x2 + here.y*stride] ) / 2;
							if( mid( next.x = here.x, next.x2 = mx ) != next.x 
								&& mid( next.y = here.y, next.y2 = here.y2 ) != next.y  )
							{
								//next.x = here.x;
								//next.y = here.y;
								//next.x2 = mx;
								//next.y2 = here.y2;
								next.notes.skip_left = here.notes.skip_left;
								next.notes.skip_top = here.notes.skip_top;
								pdq_todo.Enqueue( new grid( next ) );
							}
							if( mid( next.x = mx, next.x2 = here.x2 ) != next.x 
								&& mid( next.y = here.y, next.y2 = here.y2 ) != next.y  )
							{
								//next.x = mx;
								//next.y = here.y;
								//next.x2 = here.x2;
								//next.y2 = here.y2;
								next.notes.skip_top = here.notes.skip_top;
								next.notes.skip_left = true;
								pdq_todo.Enqueue( new grid( next ) );
							}
						}
						else
						{
							center = ( map[here.x + here.y*stride] + map[here.x + here.y2*stride] ) / 2;
							if( mid( next.x = here.x, next.x2 = here.x2 ) != next.x 
								&& mid( next.y = here.y, next.y2 = my ) != next.y  )
							{
								//next.x = here.x;
								//next.y = here.y;
								//next.x2 = here.x2;
								//next.y2 = my;
								next.notes.skip_left = here.notes.skip_left;
								next.notes.skip_top = here.notes.skip_top;
								pdq_todo.Enqueue( new grid( next ) );
							}
							if( mid( next.x = here.x, next.x2 = here.x2 ) != next.x 
								&& mid( next.y = my, next.y2 = here.y2 ) != next.y  )
							{
								//next.x = here.x;
								//next.y = my;
								//next.x2 = here.x2;
								//next.y2 = here.y2;
								next.notes.skip_top = true;
								next.notes.skip_left = here.notes.skip_left;
								pdq_todo.Enqueue( new grid( next ) );
							}
						}
					}
					if( mx != here.x )
					{
						float del1 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
						float del2 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
						float area = ( mx - here.x ) / ( plasma.horiz_area_scalar );
						if( !here.notes.skip_top && !( here.y == 0 && plasma.as_top != null ) )
						{
							//lprintf( "set point  %d,%d", mx, here.y );
							this_point
								= map[mx + here.y * stride] 
								= ( map[here.x + here.y*stride] + map[here.x2 + here.y*stride] + center ) / 3
									+ area * del1;
							if( this_point > plasma.max_height )
								plasma.max_height = this_point;
							if( this_point < plasma.min_height )
								plasma.min_height = this_point;
						}

						if( !( here.y2 == (rows-1) && plasma.as_bottom != null ) )
						{
						//lprintf( "set point  %d,%d", mx, here.y2 );
							this_point
								= map[mx + here.y2 * stride] 
								= ( map[here.x + here.y2*stride] + map[here.x2 + here.y2*stride] + center ) / 3
									+ area * del2;
							if( this_point > plasma.max_height )
								plasma.max_height = this_point;
							if( this_point < plasma.min_height )
								plasma.min_height = this_point;
						}
						//else
					//		lprintf( "Skip point %d,%d  %g", here.y2, mx, map[mx + here.y2 * stride] );
					}
					if( my != here.y )
					{
						float del1 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
						float del2 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
						float area = ( my - here.y ) / ( plasma.horiz_area_scalar );

						if( !here.notes.skip_left && !( here.x == 0 && plasma.as_left != null ) )
						{
							this_point
								= map[here.x + my * stride] = ( map[here.x + here.y*stride] + map[here.x + here.y2*stride] + center ) / 3
								+ area * del1;
							//lprintf( "set point  %d,%d", here.x, my );
							if( this_point > plasma.max_height )
								plasma.max_height = this_point;
							if( this_point < plasma.min_height )
								plasma.min_height = this_point;
						}
						if( !( here.x2 == (stride-1) && plasma.as_right != null ) )
						{
							this_point
								= map[here.x2 + my * stride] = ( map[here.x2 + here.y*stride] + map[here.x2 + here.y2*stride] + center ) / 3
									+ area * del2;
							//lprintf( "set point  %d,%d", here.x2, my );
							if( this_point > plasma.max_height )
								plasma.max_height = this_point;
							if( this_point < plasma.min_height )
								plasma.min_height = this_point;
						}
					}
					//else
					//	lprintf( "can't happen" );

				}
				while( pdq_todo.Count > 0 && ( here = pdq_todo.Dequeue() ) != null );
				//DeleteDataQueue( &pdq_todo );
				// x to mx and mx to x2 need to be done...
			}

			void PlasmaFill( plasma_patch plasma, float[] map, grid here )
			{
				int mx, my;
				grid next = new grid();
				int stride = plasma.plasma.stride;
				int rows = plasma.plasma.rows;
				float del;
				float center;
				float this_point;
				mx = ( here.x2 + here.x ) / 2;
				my = ( here.y2 + here.y ) / 2;

				if( ( mx != here.x ) && ( my != here.y ) )
				{
					float del1 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
					float area = (float)( Math.Sqrt( ( ( here.x2 - here.x )*( here.x2 - here.x ) + ( here.y2 - here.y )*( here.y2 - here.y )) ) / ( plasma.area_scalar ) );
					float avg = ( map[here.x + here.y*stride] + map[here.x2 + here.y*stride]
									 + map[here.x + here.y2*stride] + map[here.x2 + here.y2*stride] ) / 4;
					//avg += ( map[here.x + my*stride] + map[here.x2 + my*stride]
					//				 + map[mx + here.y*stride] + map[mx + here.y2*stride] ) / 4;
					//avg /= 2;
					//lprintf( "Set point %d,%d = %g (%g) %g", del1, mx, my, map[mx + my * stride], avg );
					center 
						= this_point
						= map[mx + my * stride] = avg + ( area *  del1 );
					/*
					if( map[mx + my * stride] > 1.0 )
						map[mx + my * stride] = 1.0;
					if( map[mx + my * stride] < 0.0 )
						map[mx + my * stride] = 0.0;
					*/
						if( this_point > plasma.max_height )
							plasma.max_height = this_point;
						if( this_point < plasma.min_height )
							plasma.min_height = this_point;
				}
				else 
					if( mx != here.x )
						center = ( map[here.x + here.y*stride] + map[here.x2 + here.y*stride] ) / 2;
					else
						center = ( map[here.x + here.y*stride] + map[here.x + here.y2*stride] ) / 2;

				if( mx != here.x )
				{
					float del1 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
					float del2 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
					float area = ( mx - here.x ) / ( plasma.horiz_area_scalar );
					if( !here.notes.skip_top )
					{
						this_point
							= map[mx + here.y * stride] 
							= ( map[here.x + here.y*stride] + map[here.x2 + here.y*stride] + center ) / 3
								+ area * del1;
						/*
						if( map[mx + here.y * stride] > 1.0 )
							map[mx + here.y * stride] = 1.0;
						if( map[mx + here.y * stride] < 0.0 )
							map[mx + here.y * stride] = 0.0;
							*/
						if( this_point > plasma.max_height )
							plasma.max_height = this_point;
						if( this_point < plasma.min_height )
							plasma.min_height = this_point;
					}

					this_point
							= map[mx + here.y2 * stride] 
						= ( map[here.x + here.y2*stride] + map[here.x2 + here.y2*stride] + center ) / 3
						+ area * del2;
					/*
					if( map[mx + here.y2 * stride] > 1.0 )
						map[mx + here.y2 * stride] = 1.0;
					if( map[mx + here.y2 * stride] < 0.0 )
						map[mx + here.y2 * stride] = 0.0;
						*/
						if( this_point > plasma.max_height )
							plasma.max_height = this_point;
						if( this_point < plasma.min_height )
							plasma.min_height = this_point;
				}
				if( my != here.y )
				{
					float del1 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
					float del2 = (float)( ( plasma.entropy.GetEntropy( 7, false ) / 128.0 ) - 0.5 );
					float area = ( my - here.y ) / ( plasma.horiz_area_scalar );
					if( !here.notes.skip_left )
					{
						this_point
							= map[here.x + my * stride] = ( map[here.x + here.y*stride] + map[here.x + here.y2*stride] + center ) / 3
							+ area * del1;
						/*
						if( map[here.x + my * stride] > 1.0 )
							map[here.x + my * stride] = 1.0;
						if( map[here.x + my * stride] < 0.0 )
							map[here.x + my * stride] = 0.0;
							*/
						if( this_point > plasma.max_height )
							plasma.max_height = this_point;
						if( this_point < plasma.min_height )
							plasma.min_height = this_point;
					}
					this_point
							= map[here.x2 + my * stride] = ( map[here.x2 + here.y*stride] + map[here.x2 + here.y2*stride] + center ) / 3
						+ area * del2;
					/*
					if( map[here.x2 + my * stride] > 1.0 )
						map[here.x2 + my * stride] = 1.0;
					if( map[here.x2 + my * stride] < 0.0 )
						map[here.x2 + my * stride] = 0.0;
						*/
						if( this_point > plasma.max_height )
							plasma.max_height = this_point;
						if( this_point < plasma.min_height )
							plasma.min_height = this_point;
				}

				// x to mx and mx to x2 need to be done...
				if( ( mx != here.x ) && ( my != here.y ) )
				{
					next.x = here.x;
					next.y = here.y;
					next.x2 = mx;
					next.y2 = my;
					next.notes.skip_left = here.notes.skip_left;
					next.notes.skip_top = here.notes.skip_top;
					PlasmaFill( plasma, map, next );
					next.x = mx;
					next.y = here.y;
					next.x2 = here.x2;
					next.y2 = my;
					next.notes.skip_left = true;
					next.notes.skip_top = here.notes.skip_top;
					PlasmaFill( plasma, map, next );
					next.x = here.x;
					next.y = my;
					next.x2 = mx;
					next.y2 = here.y2;
					next.notes.skip_left = here.notes.skip_left;
					next.notes.skip_top = true;
					PlasmaFill( plasma, map, next );
					next.x = mx;
					next.y = my;
					next.x2 = here.x2;
					next.y2 = here.y2;
					next.notes.skip_left = true;
					next.notes.skip_top = true;
					PlasmaFill( plasma, map, next );
				}
				else if( mx != here.x )
				{
					next.x = here.x;
					next.y = here.y;
					next.x2 = mx;
					next.y2 = here.y2;
					next.notes.skip_left = here.notes.skip_left;
					next.notes.skip_top = here.notes.skip_top;
					PlasmaFill( plasma, map, next );
					next.x = mx;
					next.y = here.y;
					next.x2 = here.x2;
					next.y2 = here.y2;
					next.notes.skip_top = here.notes.skip_top;
					next.notes.skip_left = true;
					PlasmaFill( plasma, map, next );
				}
				else if( my != here.y )
				{
					next.x = here.x;
					next.y = here.y;
					next.x2 = here.x2;
					next.y2 = my;
					next.notes.skip_left = here.notes.skip_left;
					next.notes.skip_top = here.notes.skip_top;
					PlasmaFill( plasma, map, next );
					next.x = here.x;
					next.y = my;
					next.x2 = here.x2;
					next.y2 = here.y2;
					next.notes.skip_top = true;
					next.notes.skip_left = here.notes.skip_left;
					PlasmaFill( plasma, map, next );
				}
			}

			void PlasmaRender( plasma_patch plasma, float[] seed )
			{
				grid next = new grid();
				int stride = plasma.plasma.stride;
				int rows = plasma.plasma.rows;

				//float *map2 =  NewArray( float, stride * plasma.rows );
				if( plasma.entopy_state  != null )
				{
					plasma.entropy = new SaltyRandomGenerator( plasma.entopy_state );
					plasma.seed_corner = plasma.saved_seed_corner;
	
				}
				else
				{
					plasma.entopy_state = new SaltyRandomGenerator( plasma.entropy );
					plasma.saved_seed_corner = plasma.seed_corner;
				}
				plasma.min_height = 0;
				plasma.max_height = 0;
				next.x = 0;
				next.y = 0;
				next.x2 = stride - 1;
				next.y2 = rows - 1;
				next.notes.skip_top = false;
				next.notes.skip_left = false;

				if( seed == null )
					seed = plasma.corners;

				if( null != plasma.as_left && null != plasma.as_top )
					plasma.map1[0 + 0 * stride]                    = plasma.corners[0] = seed[0];

				if( null != plasma.as_right && null != plasma.as_top )
					plasma.map1[(stride - 1) + 0 * stride]          = plasma.corners[1] = seed[1];

				if( null != plasma.as_left && null != plasma.as_bottom )
					plasma.map1[0 + (rows-1) * stride]           = plasma.corners[2] = seed[2];

				if( null != plasma.as_bottom && null != plasma.as_right )
					plasma.map1[(stride - 1) + (rows-1) * stride] = plasma.corners[3] = seed[3];

				{
					int n;
					plasma._min_height = 1;
					plasma._max_height = 0;
					plasma.min_height = 1;
					plasma.max_height = 0;
		
					for( n = 0; n < 4; n++ )
					{
						float this_point = plasma.corners[n];
						if( this_point > plasma.max_height )
							plasma._max_height
								= plasma.max_height 
								= this_point;
						if( this_point < plasma.min_height )
							plasma._min_height 
								= plasma.min_height
								= this_point;
					}
		
				}

				//PlasmaFill( plasma, map1, &next );
				PlasmaFill2( plasma, plasma.map1, next );

			}

		};

		public class plasma_state 
		{
			internal int stride, rows;
			internal float[] read_map;  // this is the map used to retun the current state.

			internal int map_width, map_height;
			internal int root_x, root_y; // where 0, 0 is...
			internal plasma_patch[] world_map;

			internal plasma_state( float[] seed, float roughness
				, int width, int height, bool initial_render )
			{
				plasma_patch patch;
				System.Diagnostics.Debug.WriteLine( "a would render here...." );

				stride = width;
				rows = height;
				read_map =  new float[ stride * rows ];
				map_height = 10;
				map_width = 10;

				System.Diagnostics.Debug.WriteLine( "world map" );

				world_map = new plasma_patch[ map_height * map_width ];
				//MemSet( plasma.world_map, 0, sizeof( POINTER ) * plasma.map_height * plasma.map_width );
				//System.Diagnostics.Debug.WriteLine( "new patch" );
				patch = new plasma_patch( this, seed, roughness );

				root_x = 5;
				root_y = 5;
				patch.x = 0;
				patch.y = 0;
				//System.Diagnostics.Debug.WriteLine( " index " +(( root_x + patch.x ) + ( root_y + patch.y ) * map_width) + " ..." + world_map.Length );
				world_map[ ( root_x + patch.x ) + ( root_y + patch.y ) * map_width ] = patch;

				if( initial_render )
				{
					System.Diagnostics.Debug.WriteLine( " patch render " );

					patch.Render();
					System.Diagnostics.Debug.WriteLine( " patch render done " );

				}

			}

			public plasma_patch GetCurrentPatch()
			{
				return world_map[( root_x  ) + ( root_y  ) * map_width];
			}

		};


		public static plasma_patch PlasmaCreatePatch( plasma_state map, float[] seed, float roughness )
		{
			System.Diagnostics.Debug.WriteLine( " NEW PATCH 3...  " );

			plasma_patch plasma = new plasma_patch( map, seed, roughness );

			return plasma;
		}

		public static plasma_patch PlasmaCreateEx( float[] seed, float roughness, int width, int height, bool initial_render )
		{
			plasma_state plasma = new plasma_state( seed, roughness, width, height, initial_render );
			return plasma.GetCurrentPatch();
		}

		public static plasma_patch PlasmaCreate( float[] seed, float roughness, int width, int height )
		{
			return PlasmaCreateEx( seed, roughness, width, height, true );
		}

		public static plasma_patch GetMapCoord( plasma_state plasma, int x, int y )
		{
			if( ( plasma.root_x + x ) < 0 ) 
				return null;
			if( ( plasma.root_y + y ) < 0 )
				return null;
			if( ( plasma.root_x + x ) >= plasma.map_width )
				return null;
			if( ( plasma.root_y + y ) >= plasma.map_height )
				return null;
			System.Diagnostics.Debug.WriteLine( " index" + ( ( plasma.root_x + x ) + ( plasma.root_y + y ) * plasma.map_width ) + "  " + plasma.map_width + " and " + x + " ," + y + " : " + plasma.world_map.Length );
							
			return 	plasma.world_map[ ( plasma.root_x + x ) + ( plasma.root_y + y ) * plasma.map_width ];

		}

		public static void SetMapCoord( plasma_state plasma, plasma_patch patch )
		{
			plasma_patch old_patch;
			plasma.world_map[ ( plasma.root_x + patch.x ) + ( plasma.root_y + patch.y ) * plasma.map_width ] = patch;
			if( ( old_patch = GetMapCoord( plasma, patch.x-1, patch.y ) ) != null )
			{
				//lprintf( "%d,%d is right of %d,%d", patch.x, patch.y, old_patch.x, old_patch.y );
				patch.as_left = old_patch;
				old_patch.as_right = patch;
			}

			if( ( old_patch = GetMapCoord( plasma, patch.x + 1, patch.y ) ) != null )
			{
				//lprintf( "%d,%d is left of %d,%d", patch.x, patch.y, old_patch.x, old_patch.y );
				patch.as_right = old_patch;
				old_patch.as_left= patch;
			}

			// old patch is (on top of patch if +1 )
			if( ( old_patch = GetMapCoord( plasma, patch.x, patch.y + 1 ) ) != null )
			{
				//lprintf( "%d,%d is below %d,%d", patch.x, patch.y, old_patch.x, old_patch.y );
				patch.as_top = old_patch;
				old_patch.as_bottom = patch;
			}

			if( ( old_patch = GetMapCoord( plasma, patch.x, patch.y - 1 ) ) != null )
			{
				//lprintf( "%d,%d is above %d,%d", patch.x, patch.y, old_patch.x, old_patch.y );
				patch.as_bottom = old_patch;
				old_patch.as_top = patch;
			}

			{
				int stride = plasma.stride;
				int rows = plasma.rows;
				int n;
				if( ( old_patch = patch.as_left ) != null )
				{
					//lprintf( "patch has a left..." );
					for( n = 0; n < rows; n++ )
						patch.map1[ 0 + n * stride ] = old_patch.map1[ (stride-1) + n * stride ];
				}
				if( ( old_patch = patch.as_top ) != null )
				{
					//lprintf( "patch has a top..." );
					for( n = 0; n < stride; n++ )
						patch.map1[ n + 0 * stride ] = old_patch.map1[ n + (rows-1) * stride ];
				}

				if( ( old_patch = patch.as_right ) != null )
				{
					//lprintf( "patch has a right..." );
					for( n = 0; n < rows; n++ )
						patch.map1[ (stride-1) + n * stride ] = old_patch.map1[ 0 + n * stride ];
				}

				if( ( old_patch = patch.as_bottom ) != null )
				{
					//lprintf( "patch has bottom... (%d,%d) above(%d,%d)", patch.x, patch.y, old_patch.x, old_patch.y );
					for( n = 0; n < stride; n++ )
						patch.map1[ n + (rows-1) * stride ] = old_patch.map1[ n + 0 * stride ];
				}
			}
		}

		static public plasma_patch PlasmaExtend( plasma_patch plasma, int in_direction, float[] seed, float roughness )
		{
			plasma_patch new_plasma;
			float[] new_seed = new float[4];
			switch( in_direction )
			{
			case 0: // to the right
				if( plasma.as_right != null )
					return plasma.as_right;
				new_seed[0] = plasma.corners[1];
				new_seed[1] = seed[0];
				new_seed[2] = plasma.corners[3];
				new_seed[3] = seed[1];
				break;
			case 1: // to the bottom
				if( plasma.as_bottom != null )
					return plasma.as_bottom;
				new_seed[0] = plasma.corners[2];
				new_seed[1] = plasma.corners[3];
				new_seed[2] = seed[0];
				new_seed[3] = seed[1];
				break;
			case 2: // to the left
				if( plasma.as_left != null )
					return plasma.as_left;
				new_seed[0] = seed[0];
				new_seed[1] = plasma.corners[0];
				new_seed[2] = seed[1];
				new_seed[3] = plasma.corners[2];
				break;
			case 3: // to the top
				if( plasma.as_top != null )
					return plasma.as_top;
				new_seed[0] = seed[0];
				new_seed[1] = seed[1];
				new_seed[2] = plasma.corners[0];
				new_seed[3] = plasma.corners[1];
				break;
			}
			System.Diagnostics.Debug.WriteLine( " setup new seed for extension..." );
			new_plasma = PlasmaCreatePatch( plasma.plasma, new_seed, roughness );

			switch( in_direction )
			{
			case 0: // to the right
				new_plasma.x = plasma.x + 1;
				new_plasma.y = plasma.y;
				break;
			case 1: // to the bottom
				new_plasma.x = plasma.x;
				new_plasma.y = plasma.y - 1;
				break;
			case 2: // to the left
				new_plasma.x = plasma.x - 1;
				new_plasma.y = plasma.y;
				break;
			case 3: // to the top
				new_plasma.x = plasma.x;
				new_plasma.y = plasma.y + 1;
				break;
			}
			///lprintf( "Create plasma at %d,%d", new_plasma.x, new_plasma.y );
			// overwrites the corners...
			SetMapCoord( plasma.plasma, new_plasma );

			{
				int stride = plasma.plasma.stride;
				int rows = plasma.plasma.rows;
				if( new_plasma.as_top != null || new_plasma.as_left != null )
					new_plasma.corners[0] = new_plasma.map1[0 + 0 * stride];
				if( new_plasma.as_top != null || new_plasma.as_right != null )
					new_plasma.corners[1] = new_plasma.map1[(stride - 1) + 0 * stride];
				if( new_plasma.as_bottom != null || new_plasma.as_left != null )
					new_plasma.corners[2] = new_plasma.map1[0 + (rows-1) * stride];
				if( new_plasma.as_bottom != null || new_plasma.as_right != null )
					new_plasma.corners[3] = new_plasma.map1[(stride - 1) + (rows-1) * stride];
			}
			System.Diagnostics.Debug.WriteLine( " patch render(2) " );

			new_plasma.Render();
			return new_plasma;
		}


		float[] PlasmaGetSurface( plasma_patch plasma )
		{
			return plasma.map;
		}


		static public float GetMapData( plasma_patch patch, int x, int y, int smoothing, bool force_scaling )
		{
			//System.Diagnostics.Debug.WriteLine( "map data at " + ( x + y * patch.plasma.stride ) );
				float input = patch.map1[ x + y * patch.plasma.stride ];
				if( force_scaling /*( patch.min_height < patch._min_height || patch.max_height > patch._max_height )*/ )
				{
					int tries = 0;
						bool updated;
					do
						{
							tries++;
							if( tries > 5 )
							{
								//lprintf( "capping oscillation at 20" );
								break;
							}
							updated  = false;
							if( input > patch._max_height )
							{
								// 
								input = patch._max_height - ( input - patch._max_height );
								updated = true;
							}
							else if( input < patch._min_height )
							{
								input = patch._min_height - ( input - patch._min_height );
								updated = true;
							}
						}
						while( updated );
						if( smoothing == 0 )
						{
						// need to specify a copy mode.
							return input;
							//sin( /*map2[index] * */( map_from[0] - patch.min_height ) / divider * 3.14159/2 /*+ map2[index] * 3.14159/2*/ );
							//( 1 + sin( /*map2[index] * */( map_from[0] - patch.min_height ) / divider * 3.14159 - 3.14159/2 /*+ map2[index] * 3.14159/2*/ ) ) / 2;
						}

						else if( smoothing == 1 )
						{
							// smooth top and bottom across sin curve, middle span is 1:1 ...
							return (float)
								( 1 + Math.Sin( input * 3.14159 - 3.14159/2 ) ) / 2;
						}

						if( smoothing == 3 )  // bad mode ... needs work
						{
						// peaker tops and bottoms smoother middle, middle span ...
						return (float)
							( 1 + Math.Tan( ( ( input ) + 0.5 ) * ( 3.14159 * 0.5 ) + (3.14159/2) ) ) /2;
						}

						if( smoothing == 4 ) // use square furnction, parabolic... cubic... qudric?
						// peaker tops and bottoms smoother middle, middle span is 1:1 ...
						{
							float tmp = input - 0.5f;
							if( tmp < 0 )
								return
									( 0.5f + ( 2 * tmp * tmp ) );
							else
								return
									0.5f -( 2 * tmp * tmp );
						}
						//*/
						//lprintf( "%g = %g %g", patch.map[index], patch.map1[index], map2[index] );
				}
				else
				{
					float divider = ( patch.max_height - patch.min_height );
					{
						// need to specify a copy mode.
						return ( input - patch.min_height ) / divider;
							//sin( /*map2[index] * */( map_from[0] - patch.min_height ) / divider * 3.14159/2 /*+ map2[index] * 3.14159/2*/ );
							//( 1 + sin( /*map2[index] * */( map_from[0] - patch.min_height ) / divider * 3.14159 - 3.14159/2 /*+ map2[index] * 3.14159/2*/ ) ) / 2;

						/*
						// smooth top and bottom across sin curve, middle span is 1:1 ...
						map[0] = 
							( 1 + sin( ( map_from[0] - patch.min_height ) / divider * 3.14159 - 3.14159/2 ) ) / 2;
						*/
						///*
						// peaker tops and bottoms smoother middle, middle span ...
						//map[0] = 
						//	( 1 + tan( ( ( ( map_from[0] - patch.min_height ) / divider ) + 0.5 ) * ( 3.14159 * 0.5 ) + (3.14159/2) ) ) /2;
						// peaker tops and bottoms smoother middle, middle span is 1:1 ...
						if( false )
						{
							float tmp = ( input - patch.min_height ) / divider - 0.5f;
							if( tmp < 0 )
								return ( 0.5f + ( 2 * tmp * tmp ) );
							else
								return 0.5f -( 2 * tmp * tmp );
						}
					}
				}
				return 0;
		}


		static public float[] PlasmaReadSurface( plasma_patch patch_root, int x, int y, int smoothing, bool force_scaling )
		{
			plasma_patch first_patch;
			plasma_patch last_patch;
			plasma_patch patch;
			plasma_state plasma = patch_root.plasma;
			int del_x = x < 0 ? - ((int)plasma.stride-1) : ((int)0);
			int del_y = y < 0 ? - ((int)plasma.rows-1) : ((int)0);
			int sec_x = (x +del_x) / (int)plasma.stride;
			int sec_y = -(y +del_y) / (int)plasma.rows;

			int ofs_x = (x/*-1*/) % plasma.stride;
			int ofs_y = (y/*-1*/) % plasma.rows;
			int out_x, out_y;
			//lprintf( "start at %d,%d  offset in first: %d,%d  sec: %d,%d", x, y, ofs_x, ofs_y, sec_x, sec_y );

			first_patch
				= patch 
				= GetMapCoord( plasma, sec_x, sec_y );
			//System.Diagnostics.Debug.WriteLine( " got coord and then... " );
			if( first_patch == null )
			{
				do
				{
					int n, m;
					patch = patch_root;
					while( sec_x < patch.x )
					{
						float[] seed = new float[2]{0.5f,0.5f};
						patch = PlasmaExtend( patch, 2, seed, patch_root.area_scalar );
					}
					while( sec_y < patch.y )
					{
						float[] seed = new float[2]{0.5f,0.5f};
						patch = PlasmaExtend( patch, 1, seed, patch_root.area_scalar );
					}
					while( sec_x > patch.x )
					{
						float[] seed = new float[2]{0.5f,0.5f};
						patch = PlasmaExtend( patch, 0, seed, patch_root.area_scalar );
					}
					while( sec_y > patch.y )
					{
						float[] seed = new float[2]{0.5f,0.5f};
						patch = PlasmaExtend( patch, 3, seed, patch_root.area_scalar );
					}
				}
				while( ( patch = GetMapCoord( plasma, sec_x, sec_y ) ) == null );
				first_patch = patch;
			}
			//lprintf( "patch is %d,%d", patch.x, patch.y ) ;
			if( patch != null )
			for( out_x = ofs_x; out_x < plasma.stride; out_x++ )
				for( out_y = ofs_y; out_y < plasma.rows; out_y++ )
				{
					//System.Diagnostics.Debug.WriteLine( " got coord and then... " + (( out_x - ofs_x ) + ( out_y - ofs_y ) * plasma.stride)  );
					plasma.read_map[( out_x - ofs_x ) + ( out_y - ofs_y ) * plasma.stride] 
						= GetMapData( patch, out_x, out_y, smoothing, force_scaling );
				}

			patch = GetMapCoord( plasma, sec_x + 1, sec_y );
			if( patch != null )
			{
				float[] seed = new float[]{0.5f,0.5f};
				patch = PlasmaExtend( first_patch, 0, seed, first_patch.area_scalar );
			}
			//lprintf( "patch is %d,%d", patch.x, patch.y ) ;
			if( patch != null )
			for( out_x = 0; out_x < ofs_x; out_x++ )
				for( out_y = ofs_y; out_y < plasma.rows; out_y++ )
				{
					plasma.read_map[ ( out_x + ( plasma.stride - ofs_x ) ) + ( out_y - ofs_y ) * plasma.stride] 
						= GetMapData( patch, out_x, out_y, smoothing, force_scaling );
				}

			patch = GetMapCoord( plasma, sec_x, sec_y - 1 );
			if( patch != null )
			{
				float[] seed = new float[]{0.5f,0.5f};
				patch = PlasmaExtend( first_patch, 1, seed, first_patch.area_scalar );
			}
			//lprintf( "patch is %d,%d", patch.x, patch.y ) ;
			if( patch != null )
			for( out_x = ofs_x; out_x < plasma.stride; out_x++ )
				for( out_y = 0; out_y < ofs_y; out_y++ )
				{
					plasma.read_map[ ( out_x - ofs_x ) + ( out_y + ( plasma.rows - ofs_y ) ) * plasma.stride] 
						= GetMapData( patch, out_x, out_y, smoothing, force_scaling );
				}
			last_patch = patch;
			patch = GetMapCoord( plasma, sec_x + 1, sec_y - 1 );
			if( patch != null )
			{
				float[] seed = new float[] { 0.5f, 0.5f };
				patch = PlasmaExtend( last_patch, 0, seed, first_patch.area_scalar );
			}
			//lprintf( "patch is %d,%d", patch.x, patch.y ) ;
			if( patch != null )
			for( out_x = 0; out_x < ofs_x; out_x++ )
				for( out_y = 0; out_y < ofs_y; out_y++ )
				{
					plasma.read_map[ ( out_x + ( plasma.stride - ofs_x ) ) + ( out_y + ( plasma.rows - ofs_y ) ) * plasma.stride] 
						= GetMapData( patch, out_x, out_y, smoothing, force_scaling );
				}
			System.Diagnostics.Debug.WriteLine( " got coord and then... left with a map" );

			return plasma.read_map;
		}

		public void PlasmaSetRoughness( plasma_patch plasma, float roughness, float horiz_rough )
		{
			plasma.area_scalar = roughness;
			plasma.horiz_area_scalar = roughness * horiz_rough;
		}


		public static plasma_state PlasmaGetMap( plasma_patch plasma )
		{
			return plasma.plasma;
		}

	}
}
