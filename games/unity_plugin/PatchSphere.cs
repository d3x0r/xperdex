using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace org.d3x0r.xperdex.games.unity_plugin
{
	public class PatchSphere : MonoBehaviour
	{
		// 64 is the max patch size to render the sphere as one mesh
		// 74.5 actually 
		int cells = 3;


		public int Cells
		{
			get
			{
				return cells;
			}
			set
			{
				int n;
				for( n = 0; n < 12; n++ )
				{
					if( patches[n] == null )
						patches[n] = new Patch( this, value );
					else
						patches[n].Cells = value;
				}

				cells = value;

				MeshFilter meshfilter = gameObject.GetComponent<MeshFilter>();
				Mesh mesh = meshfilter.mesh;
				Vector3[] verts;
				Vector3[] norms;
				Vector2[] uvs;
				int[] tris;


				ReadSphere( out verts, out norms, out uvs, out tris );

				mesh.vertices = verts;
				mesh.triangles = tris;
				mesh.uv = uvs;
				mesh.normals = norms;

				//gameObject.AddComponent<MeshFilter>().mesh = mesh;

			}
		}

		internal class Patch
		{
			/*
 					case 0: // north pole,  0-0.33 arc  X spans first half, Y second half arc
							// near 1,2,3,4
					case 1:// north pole,  0.33-0.66 arc X spans first half, Y second half arc
							// near 0,2,5,6
					case 2: // north pole,  0.66-1.0 arc  X spans first half, Y second half arc
							// near 0,1,7,8

					case 3: // equater, 0-0.16   X spans arc, Y is equatorial band
							// near 4,8,0,9

					case 4: // equater, 0.16-0.33  X spans arc, Y is equatorial band
							// near 5,3,0,9  
					case 5:// equater, 0.33-0.50  X spans arc, Y is equatorial band
							// near 6,4,1,10
					case 6:// equater, 0.50-0.66  X spans arc, Y is equatorial band
							// near 7,5,1,10
					case 7:// equater, 0.66-0.83  X spans arc, Y is equatorial band
							// near 8,6,2,11
					case 8:// equater, 0.83-1.0  X spans arc, Y is equatorial band
							// near 3,7,2,11

 					case 9:  // south pole, 0-0.33 arc   X spans first half, Y second half arc
							// near 10,11,3,4
					case 10: // south pole, 0.33-0.66 arc  X spans first half, Y second half arc
							// near 9,11,5,6
					case 11: // south pole, 0.66-1.0 arc   X spans first half, Y second half arc
							// near 9,10,7,8
			 * 
			*/
			internal int patch_id;
			internal float[] heightmap;
			int cells;
			internal struct PatchFlags
			{
				internal bool skip_left;
				internal bool skip_right;
				internal bool skip_bottom;
				internal bool skip_top;
			};
			PatchFlags flags;
			PatchSphere sphere;

			public int Cells
			{
				set
				{
					cells = value;
					heightmap = new float[cells * cells];
				}
			}

			public Patch( PatchSphere sphere, int cells )
			{
				this.sphere = sphere;
				this.cells = cells;
				heightmap = new float[cells * cells];
			}

			public float this[int x, int y]
			{
				get
				{
					return heightmap[x + y * cells];
				}
				set
				{
					heightmap[x + y * cells] = value;
					if( x == 0 )
					{
						switch( patch_id )
						{
						case 0:
							sphere.patches[2].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						case 1:
							sphere.patches[0].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						case 2:
							sphere.patches[1].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
							sphere.patches[(3-1) + ( ( patch_id - 3 ) % 6 )].heightmap[( cells - 1 ) + ( patch_id / cells ) * cells]
								= value;
							break;

						case 9:
							sphere.patches[11].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						case 10:
							sphere.patches[9].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						case 11:
							sphere.patches[10].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						}
					}
					else if( x == (cells -1) )
					{
						switch( patch_id )
						{
						case 0:
							sphere.patches[4].heightmap[( patch_id / cells ) + 0 * cells]
								= value;
							break;
						case 1:
							sphere.patches[6].heightmap[( patch_id / cells ) + 0 * cells]
								= value;
							break;
						case 2:
							sphere.patches[8].heightmap[( patch_id / cells ) + 0 * cells]
								= value;
							break;
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
							sphere.patches[(3+1) + ( ( patch_id - 3 ) % 6 )].heightmap[( cells - 1 ) + ( patch_id / cells ) * cells]
								= value;
							break;
						case 9:
							sphere.patches[4].heightmap[( patch_id / cells ) + ( cells-1 ) * cells]
								= value;
							break;
						case 10:
							sphere.patches[6].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						case 11:
							sphere.patches[8].heightmap[( patch_id / cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						}
					}

					if( y == 0 )
					{
						switch( patch_id )
						{
						case 0:
							sphere.patches[3].heightmap[( patch_id % cells ) + ( 0 ) * cells]
								= value;
							break;
						case 1:
							sphere.patches[5].heightmap[( patch_id % cells ) + ( 0 ) * cells]
								= value;
							break;
						case 2:
							sphere.patches[4].heightmap[( patch_id % cells ) + ( 0 ) * cells]
								= value;
							break;
						case 3: // 0/2=0
						case 5: // 2/2=1
						case 7: // 4/2=2
							sphere.patches[(patch_id-3)/2].heightmap[( patch_id % cells ) + ( 0 ) * cells]
								= value;
							break;
						case 4: // 0/2 = 0
						case 6: // 2/2 = 1
						case 8: // 4/2 = 2
							sphere.patches[(patch_id-4)/2].heightmap[ 0 + ( patch_id % cells ) * cells]
								= value;
							break;
						case 9:
							sphere.patches[3].heightmap[( patch_id % cells ) + ( cells-1 ) * cells]
								= value;
							break;
						case 10:
							sphere.patches[5].heightmap[( patch_id % cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						case 11:
							sphere.patches[4].heightmap[( patch_id % cells ) + ( cells - 1 ) * cells]
								= value;
							break;
						}
					}
					else if( y == ( cells - 1 ) )
					{
						switch( patch_id )
						{
						case 0:
							sphere.patches[1].heightmap[ 0 + (patch_id%cells) * cells]
								= value;
							break;
						case 1:
							sphere.patches[2].heightmap[0 + ( patch_id % cells ) * cells]
								= value;
							break;
						case 2:
							sphere.patches[0].heightmap[0 + ( patch_id % cells ) * cells]
								= value;
							break;
						case 3: // 0/2=0
						case 5: // 2/2=1
						case 7: // 4/2=2
							sphere.patches[ 9 + ( patch_id - 3 ) / 2].heightmap[( patch_id % cells ) + ( 0 ) * cells]
								= value;
							break;
						case 4: // 0/2 = 0
						case 6: // 2/2 = 1
						case 8: // 4/2 = 2
							sphere.patches[9 + ( patch_id - 4 ) / 2].heightmap[0 + ( patch_id % cells ) * cells]
								= value;
							break;
						case 9:
							sphere.patches[10].heightmap[0 + ( patch_id % cells ) * cells]
								= value;
							break;
						case 10:
							sphere.patches[11].heightmap[0 + ( patch_id % cells ) * cells]
								= value;
							break;
						case 11:
							sphere.patches[9].heightmap[0 + ( patch_id % cells ) * cells]
								= value;
							break;
						}
					}
				}
			}

			void MateEdges( )
			{
				int n;
				for( n = 0; n < cells; n++ )
					this[0,n] = this[0,n];
				for( n = 0; n < cells; n++ )
					this[n, 0] = this[n, 0];
				for( n = 0; n < cells; n++ )
					this[cells-1, n] = this[cells-1, n];
				for( n = 0; n < cells; n++ )
					this[n, cells-1] = this[n, cells-1];

				switch( patch_id )
				{
				case 0:
					sphere.patches[1].flags.skip_left = true;
					sphere.patches[2].flags.skip_bottom = true;
					sphere.patches[3].flags.skip_top = true;
					sphere.patches[4].flags.skip_top = true;
					break;
				case 1:
					sphere.patches[2].flags.skip_left = true;
					sphere.patches[0].flags.skip_bottom = true;
					sphere.patches[5].flags.skip_top = true;
					sphere.patches[6].flags.skip_top = true;
					break;
				case 2:
					sphere.patches[0].flags.skip_left = true;
					sphere.patches[1].flags.skip_bottom = true;
					sphere.patches[7].flags.skip_top = true;
					sphere.patches[8].flags.skip_top = true;
					break;
				case 3:
					sphere.patches[0].flags.skip_bottom = true;
					sphere.patches[9].flags.skip_bottom = true;
					sphere.patches[8].flags.skip_right = true;
					sphere.patches[4].flags.skip_left = true;
					break;
				case 4:
					sphere.patches[0].flags.skip_right = true;
					sphere.patches[9].flags.skip_right = true;
					sphere.patches[3].flags.skip_right = true;
					sphere.patches[5].flags.skip_left = true;
					break;
				case 5:
					sphere.patches[0].flags.skip_bottom = true;
					sphere.patches[9].flags.skip_bottom = true;
					sphere.patches[4].flags.skip_right = true;
					sphere.patches[6].flags.skip_left = true;
					break;
				case 6:
					sphere.patches[0].flags.skip_right = true;
					sphere.patches[9].flags.skip_right = true;
					sphere.patches[5].flags.skip_right = true;
					sphere.patches[7].flags.skip_left = true;
					break;
				case 7:
					sphere.patches[0].flags.skip_bottom = true;
					sphere.patches[9].flags.skip_bottom = true;
					sphere.patches[6].flags.skip_right = true;
					sphere.patches[8].flags.skip_left = true;
					break;
				case 8:
					sphere.patches[0].flags.skip_right = true;
					sphere.patches[9].flags.skip_right = true;
					sphere.patches[7].flags.skip_right = true;
					sphere.patches[3].flags.skip_left = true;
					break;
				case 9:
					sphere.patches[10].flags.skip_left = true;
					sphere.patches[11].flags.skip_bottom = true;
					sphere.patches[3].flags.skip_bottom = true;
					sphere.patches[4].flags.skip_bottom = true;
					break;
				case 10:
					sphere.patches[11].flags.skip_left = true;
					sphere.patches[9].flags.skip_bottom = true;
					sphere.patches[5].flags.skip_bottom = true;
					sphere.patches[6].flags.skip_bottom = true;
					break;
				case 11:
					sphere.patches[9].flags.skip_left = true;
					sphere.patches[10].flags.skip_bottom = true;
					sphere.patches[7].flags.skip_bottom = true;
					sphere.patches[8].flags.skip_bottom = true;
					break;
				}
			}

		}

		Patch[] patches = new Patch[12];

		public void Start() //PatchSphere( int cells = 12 )
		{
			Mesh mesh = new Mesh();
			{
				// fill mesh
				Vector3[] verts;
				Vector3[] norms;
				Vector2[] uvs;
				int[] tris;

				gameObject.AddComponent<MeshRenderer>();

				ReadSphere( out verts, out norms, out uvs, out tris );

				mesh.vertices = verts;
				mesh.triangles = tris;
				mesh.uv = uvs;
				mesh.normals = norms;

				gameObject.AddComponent<MeshFilter>().mesh = mesh;
				//AssetDatabase.CreateAsset( mesh, "Assets/Default Patch Shere-" + sphere.Cells + ".asset" );
			}


			int n;
			this.cells = cells;
			for( n = 0; n < 12; n++ )
			{
				patches[n] = new Patch( this, cells );
			}
		}

		public int GetColumnsAtRow( int row )
		{
			int col = 0;
			if( row < cells )
			{
				// row 0 
				col = ( row * 6 );
				return col;
			}
			else if( row <= cells * 2 )
			{
				col = cells * 6;
			}
			else if( row < cells * 3 )
			{
				row = ( row - cells * 2 );
				int cols = ( cells ) - row;
				col = cols * 6;
			}
			return col;
		}

		// longitude goes from 0 to (cells*3 + 1)
		//      0-cells+1 = pole (cells+1 is also band...)
		//      cells+1-2xcells+1 = band
		//      cells*2+1
		// latitude goes from longitude < cells 
		//    to longitude * 6
		public void TranslatePolarToRect( int longitude, int latitude, out int patch, out int x, out int y )
		{
			while( longitude < 0 )
				longitude += (cells * 3);
			longitude = longitude % ( cells * 3 + 1 );

				/*************** North pole band **************/
			if( latitude < cells )
			{
				int cols = ( latitude );
				if( cols > 0 )
					longitude %= cols * 6;
				else  // at pole... do a constant
				{
					patch = 0;
					x = 0;
					y = ( cells - 1 );
					return;
				}
				if( longitude < cols )
				{
					patch = 0;
					x = longitude-0;
					y = (cells - 1)-latitude;
					return;
				}
				else if( longitude < cols * 2 )
				{
					patch = 0;
					x = latitude;
					y = ( ( cells - 1 ) - latitude ) + (longitude - cols);
					return;
				}
				else if( longitude < cols * 3 )
				{
					patch = 1;
					x = longitude-cols*2;
					y = (cells - 1)-latitude;
					return;
				}
				else if( longitude < cols * 4 )
				{
					patch = 1;
					x = latitude;
					y = ( ( cells - 1 ) - latitude ) + ( longitude - cols * 3 );
					return;
				}
				else if( longitude < cols * 5 )
				{
					patch = 2;
					x = longitude-cols*4;
					y = (cells - 1)-latitude;
					return;
				}
				else if( longitude < cols * 6 )
				{
					patch = 2;
					x = latitude;
					y = ( ( cells - 1 ) - latitude ) + ( longitude - cols * 5 );
					return;
				}
			}
				/*************** Middle band **************/
			else if( latitude < cells * 2 )
			{
				int cols = cells;
				patch = 3 + longitude / cells;
				x = longitude % cells;
				y = (cells-1) - (latitude - cells);
				return;
			}
				/*************** south pole band **************/
			else if( latitude <= cells * 3 )
			{
				latitude = ( cells - 1 ) - ( latitude - cells * 2 );
				//longitude = (cells-1) - (longitude - cells * 2 );
				int cols = ( latitude );
				if( cols > 0 )
					longitude %= cols * 6;
				else  // at pole... do a constant
				{
					patch = 9;
					x = 0;
					y = ( cells - 1 );
					return;
				}
				if( longitude < cols )
				{
					patch = 9;
					x = longitude - 0;
					y = ( cells - 1 ) - latitude;
					return;
				}
				else if( longitude < cols * 2 )
				{
					patch = 9;
					x = latitude;
					y = ( ( cells - 1 ) - latitude ) + ( longitude - cols );
					return;
				}
				else if( longitude < cols * 3 )
				{
					patch = 10;
					x = longitude - cols * 2;
					y = ( cells - 1 ) - latitude;
					return;
				}
				else if( longitude < cols * 4 )
				{
					patch = 10;
					x = latitude;
					y = ( ( cells - 1 ) - latitude ) + ( longitude - cols * 3 );
					return;
				}
				else if( longitude < cols * 5 )
				{
					patch = 11;
					x = longitude - cols * 4;
					y = ( cells - 1 ) - latitude;
					return;
				}
				else if( longitude < cols * 6 )
				{
					patch = 11;
					x = latitude;
					y = ( ( cells - 1 ) - latitude ) + ( longitude - cols * 5 );
					return;
				}
			}
			x = -1;
			y = -1;
			patch = -1;
		}

		// long/lat passed as 0-1.0 and 0 - 1.0
		public void TranslatePolarToRect( float longitude, float latitude, out int patch, out int x, out int y )
		{
			latitude = latitude - (int)latitude;
			longitude = longitude - (int)longitude;

			int row = (int)( latitude * cells * 3 );
			int col = 0;
			if( row < cells )
			{
				// row 0 
				row = row + 1;
				col = (int)( longitude * row * 6 );  

			}
			else if( row < cells * 2 )
			{
				col = (int)( longitude * cells * 6 );
			}
			else if( row < cells * 3 )
			{
				row = ( row - cells * 2 );
				int cols = ( cells - 1 ) - row;

				col = (int)( longitude * cols * 6 );  

			}
			TranslatePolarToRect( col, row, out patch, out x, out y );
		}
		float this[int longitude, int latitude]
		{
			get
			{
				while( longitude < 0 )
					longitude += ( cells * 3 );
				longitude = longitude % ( cells * 3 + 1 );

				if( longitude < cells )
				{
					int cols = ( longitude );
					if( latitude < cols )
					{
						return patches[0][longitude - 0, ( cells - 1 ) - latitude];
					}
					else if( latitude < cols * 2 )
					{
						return patches[0][( cells - 1 ) - latitude + longitude - cols
							, ( cells - 1 ) - longitude];
					}
					else if( latitude < cols * 3 )
					{
						return patches[0][( cells - 1 ) - latitude + longitude - cols
							, ( cells - 1 ) - longitude];
					}
					else if( latitude < cols * 4 )
					{
						return patches[1][longitude - cols * 3 + latitude, longitude - cols];
					}
					else if( latitude < cols * 5 )
					{
						return patches[2][longitude - cols * 4, ( cells - 1 ) - latitude];
					}
					else if( latitude < cols * 6 )
					{
						return patches[0][( cells - 1 ) - latitude + longitude - cols
							, ( cells - 1 ) - longitude];
					}
				}
				else if( longitude < cells * 2 )
				{
					int cols = cells * 6;

				}
				else if( longitude <= cells * 3 )
				{
					int cols = ( ( ( cells * 3 ) - longitude ) ) * 6;
				}
				return 0.0f;
			}
		}

		int GetTotalCells( int cells )
		{
			int row;
			int total = 1;
			for( row = 0; row < cells; row++ )
				total += GetColumnsAtRow( row + 1 );
			//Log( "Total cells of " + cells + " is " + total );
			return total;
		}
		int GetTotalCellsInverse( int cells )
		{
			int row;
			int total = 0;
			for( row = cells - 1; row >= 0; row++ )
				total += GetColumnsAtRow( row + 1 );
			return total;
		}

		void Log( string s )
		{
			//if( !is_unity )
			//	Console.WriteLine( s );
			//else
				Debug.Log( s );
		}
		// this returns the index of the vertex for the desired row/column
		// row 0 is vertex 0 and columns 0
		// row 1 is vertex 1-6 and columns 6
		// row 2 is vertex 7-19  and columns 12

		int GetPointIndex( int row, int col )
		{
			int stride;
			int result;
			if( row == 0 )
				result = 0;
			else if( row < cells )
				result = GetTotalCells( row - 1 ) + col % ( 6 * row );
			else if( row < cells * 2 )
				result = 1 + ( cells * ( cells - 1 ) * 3 ) + ( row - cells ) * ( 6 * cells ) + ( col % ( 6 * cells ) );
			else if( row < cells * 3 )
				result = GetTotalCells( row - 1 ) + col % ( 6 * ( cells * 3 - row ) );
			else
				result = 1 + ( 2 * 6 * ( cells + cells * cells ) / 2 )
						+ ( cells * ( cells - 1 ) * 6 );
			//Log( " intput " + row + "," + col + " = " + result + "(" + ( GetTotalCells( row - 1 ) + col ) + ")" );
			return result;
			// this should actually work itself for all bands... other than the column modulous
			//return GetTotalCells( row - 1 ) + col;
		}


		public void ReadSphere( 
				out Vector3[] points
						, out Vector3[] normals
						, out Vector2[] uvs
			, out int[] tris
						)
		{
			//    1 + 2 + 3 + 4  ..         10     20  
			//    1 + 2 + 3 + 4 + 5  ..     15     30  25+5
			//    1 + 2 + 3 + 4 + 5 + 6  .. 21     42  36+6
			//  points = 2 * 6 * (rows + rows*rows)/2
			// points += cells * cells*6
			// cells = 6 + 12 + 18 + 24 + ...
			// 12 = 1802 verts


			int max_points;
			Vector3[] v = new Vector3[2 + ( 2 * 6 * ( cells + cells * cells ) / 2 )
				+ ( cells * ( cells - 1 ) * 6 )];
			Vector3[] norms = new Vector3[2 + ( 2 * 6 * ( cells + cells * cells ) / 2 )
				+ ( cells * ( cells - 1 ) * 6 )];
			Vector2[] uv = new Vector2[2 + ( 2 * 6 * ( cells + cells * cells ) / 2 )
				+ ( cells * ( cells - 1 ) * 6 )];

			int[] tri = new int[3 * ( 2 * 2 * 3 * ( ( cells * cells ) )
					+ 2 * 6 * ( cells * cells ) )];
			int row;
			int col;
			int n = 0;

			//for( int t = 0; t <= cells * 3; t++ )
			//	Log( "OUtput : " + GetPointIndex( t, 0 ) );
			max_points = v.Length - 1;

			{
				int face = 0;

				// north pole
				for( row = 0; row < cells; row++ )
				{
					if( true )
						for( col = 0; col < row; col++ )
						{

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, col );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, col + 1 );
							tri[face * 6 + 2] = GetPointIndex( row + 1, col );
							tri[face * 6 + 4] = GetPointIndex( row, col + 1 );
							face++;

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, row * 2 + col );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, ( row + 1 ) * 2 + col + 1 );
							tri[face * 6 + 2] = GetPointIndex( row + 1, ( row + 1 ) * 2 + col );
							tri[face * 6 + 4] = GetPointIndex( row, row * 2 + col + 1 );
							face++;

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, row * 4 + col );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, ( row + 1 ) * 4 + col + 1 );
							tri[face * 6 + 2] = GetPointIndex( row + 1, ( row + 1 ) * 4 + col );
							tri[face * 6 + 4] = GetPointIndex( row, row * 4 + col + 1 );
							face++;


						}
					else
						col = row;

					for( ; col <= row; col++ )
					{
						if( true )
						{
							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, ( row ) );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, ( row + 1 ) );
							tri[face * 6 + 2] = GetPointIndex( row + 1, ( row + 1 ) - 1 );
							tri[face * 6 + 4] = GetPointIndex( row + 1, ( row + 1 ) + 1 );
							face++;

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, ( ( row ) ) * 3 );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, ( row + 1 ) * 3 );
							tri[face * 6 + 2] = GetPointIndex( row + 1, ( row + 1 ) * 3 - 1 );
							tri[face * 6 + 4] = GetPointIndex( row + 1, ( row + 1 ) * 3 + 1 );
							face++;
							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, ( row ) * 5 );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, ( row + 1 ) * 5 );
							tri[face * 6 + 2] = GetPointIndex( row + 1, ( row + 1 ) * 5 - 1 );
							tri[face * 6 + 4] = GetPointIndex( row + 1, ( row + 1 ) * 5 + 1 );
							face++;
						}
					}

					for( ; col <= row * 2; col++ )
					{
						tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, col );
						tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, col + 1 );
						tri[face * 6 + 2] = GetPointIndex( row, col - 1 );
						tri[face * 6 + 4] = GetPointIndex( row + 1, col + 2 );
						face++;
						tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, row * 2 + col );
						tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, row * 2 + col + 3 );
						tri[face * 6 + 2] = GetPointIndex( row, row * 2 + col - 1 );
						tri[face * 6 + 4] = GetPointIndex( row + 1, row * 2 + col + 4 );
						face++;
						tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( row, row * 4 + col );
						tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( row + 1, row * 4 + col + 5 );
						tri[face * 6 + 2] = GetPointIndex( row, row * 4 + col - 1 );
						tri[face * 6 + 4] = GetPointIndex( row + 1, row * 4 + col + 6 );
						face++;
					}
				}

				// equitorial band
				for( row = 0; row < cells; row++ )
				{
					for( col = 0; col < cells * 6; col++ )
					{
						tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( cells + row, col );
						tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( cells + row + 1, col + 1 );
						tri[face * 6 + 2] = GetPointIndex( cells + row + 1, col );
						tri[face * 6 + 4] = GetPointIndex( cells + row, col + 1 );
						face++;
					}
				}


				// south pole
				//if( false )
					for( row = cells - 1; row >= 0; row-- )
					{
						int base_row = cells * 2 + cells - row;
						for( col = 0; col < row; col++ )
						{
							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, col );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, col + 1 );
							tri[face * 6 + 2] = GetPointIndex( base_row, col + 1 );
							tri[face * 6 + 4] = GetPointIndex( base_row - 1, col );
							face++;

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, row * 2 + col );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, ( row + 1 ) * 2 + col + 1 );
							tri[face * 6 + 2] = GetPointIndex( base_row, row * 2 + col + 1 );
							tri[face * 6 + 4] = GetPointIndex( base_row - 1, ( row + 1 ) * 2 + col );
							face++;

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, row * 4 + col );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, ( row + 1 ) * 4 + col + 1 );
							tri[face * 6 + 2] = GetPointIndex( base_row, row * 4 + col + 1 );
							tri[face * 6 + 4] = GetPointIndex( base_row - 1, ( row + 1 ) * 4 + col );
							face++;

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, row * 1 + col + 1 );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, row * 1 + col + 2 );
							tri[face * 6 + 2] = GetPointIndex( base_row - 1, row * 1 + col + 3 );
							tri[face * 6 + 4] = GetPointIndex( base_row, row * 1 + col );
							face++;
							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, ( row ) * 3 + col + 1 );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, ( row + 1 ) * 3 + col + 1 );
							tri[face * 6 + 2] = GetPointIndex( base_row - 1, ( row + 1 ) * 3 + col + 2 );
							tri[face * 6 + 4] = GetPointIndex( base_row, ( row ) * 3 + col );
							face++;
							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, ( row ) * 5 + col + 1 );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, ( row + 1 ) * 5 + col + 1 );
							tri[face * 6 + 2] = GetPointIndex( base_row - 1, ( row + 1 ) * 5 + col + 2 );
							tri[face * 6 + 4] = GetPointIndex( base_row, ( row ) * 5 + col );
							face++;
						}

						for( ; col <= row; col++ )
						{
							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, ( row ) );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, ( row ) + 1 );
							tri[face * 6 + 2] = GetPointIndex( base_row - 1, ( row + 1 ) + 1 );
							tri[face * 6 + 4] = GetPointIndex( base_row - 1, ( row + 1 ) - 1 );
							face++;

							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, ( ( row ) ) * 3 );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, ( row + 1 ) * 3 );
							tri[face * 6 + 2] = GetPointIndex( base_row - 1, ( row + 1 ) * 3 + 1 );
							tri[face * 6 + 4] = GetPointIndex( base_row - 1, ( row + 1 ) * 3 - 1 );
							face++;
							tri[face * 6 + 3] = tri[face * 6 + 0] = GetPointIndex( base_row, ( row ) * 5 );
							tri[face * 6 + 5] = tri[face * 6 + 1] = GetPointIndex( base_row - 1, ( row + 1 ) * 5 );
							tri[face * 6 + 2] = GetPointIndex( base_row - 1, ( row + 1 ) * 5 + 1 );
							tri[face * 6 + 4] = GetPointIndex( base_row - 1, ( row + 1 ) * 5 - 1 );
							face++;
						}
					}


				/*
				 * code to trim the trinagle array to just what was used...
				int[] tri2 = new int[face * 6];
				for( int f = 0; f < face; f++ )
				{
					for( int p = 0; p < 6; p++ )
						tri2[f * 6 + p] = tri[f * 6 + p];
					//Log( "cell is " + tri[f * 6 + 0] + "," + tri[f * 6 + 1] + "," + tri[f * 6 + 2] + "     " + tri[f * 6 + 3] + "," + tri[f * 6 + 4] + "," + tri[f * 6 + 5] );
				}
				tri = tri2;
				*/
			}
			int cols;

			Vector3 tmp_v = Vector3.up;
			Quaternion longitude_rot;

			Vector3 v_latitude =
				//Vector3.up / (float)Math.Sqrt( 3 ) + Vector3.forward / (float)Math.Sqrt( 3 ) + Vector3.right / (float)Math.Sqrt( 3 );
				Vector3.up;
			Vector3 v_longitude =
				//Vector3.up / (float)Math.Sqrt( 3 ) - Vector3.forward / (float)Math.Sqrt( 3 ) + Vector3.right / (float)Math.Sqrt( 3 );
				Vector3.forward;

			// first point
			uv[n] = Vector2.right * ( (float)0 / (float)cells ) + Vector2.up * ( (float)0 / (float)cells );
			norms[n] = v_latitude;
			v[n++] = v_latitude;

			Vector3 tmp_elevation;

			longitude_rot = Quaternion.AngleAxis( 60.0f / ( cells ), v_longitude );

			// use v_latitude as the source.... it's the perpendicular for the other rotation so it must
			// be correct
			tmp_elevation = longitude_rot * v_latitude;

			//Debug.Log( "ZZ Init longitude (from)" + vf( v_latitude ) + " = " + vf( tmp_elevation ) + " step angle is " + ( 180.0f / ( cells * 3 ) ) );


			//Log( "Begin quatrnion rotations..." + longitude_rot + "    " + tmp_elevation );

			for( row = 1; row < cells; row++ )
			{
				cols = GetColumnsAtRow( row );
				Quaternion latitude_rot;
				//Vector3.Lerp( startPosition, endPosition,  );
				if( cols > 0 )
					latitude_rot = Quaternion.AngleAxis( -360.0f / ( cols ), v_latitude );
				else
					latitude_rot = Quaternion.AngleAxis( 0f, v_latitude );

				for( col = 0; col < cols; col++ )
				{
					int p, x, y;
					TranslatePolarToRect( col, row, out p, out x, out y );

					uv[n] = Vector2.right * ( (float)x / (float)cells ) + Vector2.up * ( (float)y / (float)cells );
					norms[n] = tmp_elevation;
					v[n++] = tmp_elevation;// *( 1 + patches[p][x, y] );

					tmp_elevation = latitude_rot * tmp_elevation;
				}
				//Log( "to Step longitude " + tmp_elevation );
				//tmp_elevation = trans1.ApplyRotation( tmp_elevation );
				tmp_elevation = longitude_rot * tmp_elevation;
				//Log( "Step longitude " + tmp_elevation );

			}
			//Log( "total points: " + n );

			cols = GetColumnsAtRow( cells );
			for( row = 0; row < cells; row++ )
			{
				Quaternion latitude_rot;
				latitude_rot = Quaternion.AngleAxis( -360f / ( cols ), v_latitude );

				for( col = 0; col < cols; col++ )
				{
					int p, x, y;
					TranslatePolarToRect( col, row, out p, out x, out y );
					uv[n] = Vector2.right * ( (float)x / (float)cells ) + Vector2.up * ( (float)y / (float)cells );
					norms[n] = tmp_elevation;
					v[n++] = tmp_elevation;// * ( 1 + patches[p][x, y] );
					tmp_elevation = latitude_rot * tmp_elevation;
				}
				tmp_elevation = longitude_rot * tmp_elevation;
			}
			//Log( "total points: " + n );
			for( row = 0; row < cells; row++ )
			{
				cols = GetColumnsAtRow( cells * 2 + row );
				Quaternion latitude_rot;
				if( cols > 0 )
					latitude_rot = Quaternion.AngleAxis( -360.0f / ( cols ), v_latitude );
				else
					latitude_rot = Quaternion.AngleAxis( 0, v_latitude );

				for( col = 0; col < cols; col++ )
				{
					int p, x, y;
					TranslatePolarToRect( col, row, out p, out x, out y );
					uv[n] = Vector2.right * ( (float)x / (float)cells ) + Vector2.up * ( (float)y / (float)cells );
					norms[n] = tmp_elevation;
					v[n++] = tmp_elevation;// * ( 1 + patches[p][x, y] );
					tmp_elevation = latitude_rot * tmp_elevation;
				}
				tmp_elevation = longitude_rot * tmp_elevation;
			}

			// done... 
			// last point
			uv[n] = Vector2.right * ( (float)0 / (float)cells ) + Vector2.up * ( (float)0 / (float)cells );
			norms[n] = -v_latitude;// -Vector3.up
			v[n++] = -v_latitude;// -Vector3.up

			//Log( "total points: " + n );

			tris = tri;
			uvs = uv;
			points = v;
			normals = norms;
		}
	}
}
