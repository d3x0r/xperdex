using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;

namespace Terragrid
{
	public class Grid
	{

		internal struct BasicPlane {
			internal static Vector3 origin = new Vector3();
			internal Vector3 o;
			internal Vector3 n;
			internal BasicPlane( Vector3 origin, Vector3 normal )
			{
				o = origin;
				n = normal;
			}
		}

		public class Connection: List<Connection>
		{
			Vector3 position;

			public Connection( Vector3 p )
			{
				position = p;
			}
		}

		List<Connection> points;

		int connections;


		int ICOSA_SIDES = 20;
BasicPlane[] icosahedron = { new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.0f, 0.342952f, 0.895252f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.553051f, 0.553576f, 0.552725f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.3423f, 0.89355f, 0 ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.3423f, 0.89355f, 0 ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.553051f, 0.553576f, 0.552725f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.89355f, 0, 0.34125f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.89355f, 0, -0.34125f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.553051f, 0.553576f, -0.552725f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0, 0.342952f, -0.895252f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0, -0.342952f, -0.895252f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.553051f, -0.553576f, -0.552725f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.3423f, -0.89355f, 0f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.3423f, -0.89355f, 0f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.553051f, -0.553576f, 0.552725f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0f, -0.342952f, 0.895252f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( 0.553051f, -0.553576f, 0.552725f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.89355f, 0, 0.34125f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.89355f, 0, -0.34125f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.553051f, 0.553576f, -0.552725f ) )
										, new BasicPlane( new Vector3( 0,0,0), new Vector3( -0.553051f, -0.553576f, -0.552725f ) ) };

int _80_SIDES = 80;
BasicPlane[] _80sides;

BasicPlane[] _320sides;
BasicPlane[] _1280sides;
/*
 taken from http://www.cs.clemson.edu/~bobd/illuminate/index5.html
**  The code below creates an icosahedron, based on the
** code from page 84 of the OpenGL Programming Guide, second
** edition.  In the book, the triangles are not specified in
** counter clockwise order, so they had to be reordered here.
*/
/*
 * #define X .525731112119133606
	#define Z .850650808352039932
	static GLfloat vdata[12][3] = {
		{-X, 0.0, Z}, {X, 0.0, Z}, {-X, 0.0, -Z}, {X, 0.0, -Z},
		{0.0, Z, X}, {0.0, Z, -X}, {0.0, -Z, X}, {0.0, -Z, -X},
		{Z, X, 0.0}, {-Z, X, 0.0}, {Z, -X, 0.0}, {-Z, -X, 0.0}
		};
	static GLuint tindices[20][3] = {
		{0,4,1}, {0,9,4}, {9,5,4}, {4,5,8}, {4,8,1},
		{8,10,1}, {8,3,10}, {5,3,8}, {5,2,3}, {2,7,3},
		{7,10,3}, {7,6,10}, {7,11,6}, {11,0,6}, {0,1,6},
		{6,1,10}, {9,0,11}, {9,11,2}, {9,2,5}, {7,2,11} };
	int i;
	glBegin(GL_TRIANGLES);
	for (i = 0; i < 20; i++) {
		// color information here 
		glVertex3fv(&vdata[tindices[i][0]][0]);
		glVertex3fv(&vdata[tindices[i][1]][0]);
		glVertex3fv(&vdata[tindices[i][2]][0]);
	}
	glEnd();
*/

// also dodeca hedron above is the normals here - (points) - probably
// smothing of the points to cause a sphere effect with opengl
Vector3[] icosa_points = { new Vector3(  -0.526f, 0.0f, 0.851f )
							  , new Vector3(  0.526f, 0.0f, 0.851f )
							  , new Vector3(  -0.526f, 0.0f, -0.851f )
							  , new Vector3(  0.526f, 0.0f, -0.851f )
							  , new Vector3(  0.0f, 0.851f, 0.525f )
							  , new Vector3(  0.0f, 0.851f, -0.525f )
							  , new Vector3(  0.0f, -0.851f, 0.525f )
							  , new Vector3(  0.0f, -0.851f, -0.525f )
							  , new Vector3(  0.851f, 0.525f, 0.0f )
							  , new Vector3(  -0.851f, 0.525f, 0.0f )
							  , new Vector3(  0.851f, -0.525f, 0.0f )
							  , new Vector3(  -0.851f, -0.525f, 0.0f ) };

int[,] icosa_index = { { 4, 0, 1 }
							  , { 9, 0, 4 }
							  , {  5, 9, 4 }
							  , {  5, 4, 8 }
							  , {  8, 4, 1 }
							  , {  10, 8, 1 }
							  , {  3, 8, 10 }
							  , {  3, 5, 8 }
							  , {  2, 5, 3 }
							  , {  7, 2, 3 }
							  , {  10, 7, 3 }
							  , {  6, 7, 10 }
							  , {  11, 7, 6 }
							  , {  0, 11, 6 }
							  , {  1, 0, 6 }
							  , {  1, 6, 10 }
							  , {  0, 9, 11 }
							  , {  11, 9, 2 }
							  , {  2, 9, 5 }
							  , {  2, 7, 11 } };


		static int depth;
		void FillQuadSet( BasicPlane[] set, int base_index, int levels, ref Vector3 i1, ref Vector3 i2, ref Vector3 i3 )
		{
			Vector3 p1, p2, p3;
			levels--;
			depth++;
			p1 = i2 + i1;
			p1.Normalize();
			p2 = i3 + i2;
			p2.Normalize();
			p3 = i1 + i3;
			p3.Normalize();
			if( levels > 0 )
			{
				{
					FillQuadSet( set, base_index + ( 0 << ( 2 * levels ) ), levels, ref p1, ref p2, ref p3 );
					FillQuadSet( set, base_index + ( 1 << ( 2 * levels ) ), levels, ref p1, ref p2, ref i2 );
					FillQuadSet( set, base_index + ( 2 << ( 2 * levels ) ), levels, ref p2, ref p3, ref i3 );
					FillQuadSet( set, base_index + ( 3 << ( 2 * levels ) ), levels, ref p3, ref p1, ref i1 );
				}
			}
			else
			{
				set[base_index] = new BasicPlane( BasicPlane.origin, Vector3.Normalize( Vector3.Cross( p3 - p2, p2 - p1 ) ) );
				set[base_index + 1] = new BasicPlane( BasicPlane.origin, Vector3.Normalize( Vector3.Cross( i2 - p1, p2 - i2 ) ) );
				set[base_index + 2] = new BasicPlane( BasicPlane.origin, Vector3.Normalize( Vector3.Cross( i3 - p2, p3 - i3 ) ) );
				set[base_index + 3] = new BasicPlane( BasicPlane.origin, Vector3.Normalize( Vector3.Cross( i1 - p3, p1 - i1 ) ) );
			}
			depth--;
		}


		BasicPlane[] InitIcosohedron( int levels, float radius )
		{
			{
				BasicPlane[] result = new BasicPlane[20 * ( 1 << ( 2 * levels ) )];
				int n, p;
				for( n = 0; n < 12; n++ )
				{
					icosa_points[n].Normalize();
				}

				//int prior = 20;
				//_80sides = new BasicPlane[prior = prior * 4];
				//_320sides = new BasicPlane[prior = prior * 4];
				//_1280sides = new BasicPlane[prior = prior * 4];

				for( n = 0; n < 20; n++ )
				{
					//Log( "Fill 80 sides..." );
					//1 << 2
					FillQuadSet( result, n * (1<<(2*levels)), levels
								  , ref icosa_points[icosa_index[n,0]]
								  , ref icosa_points[icosa_index[n,1]]
								  , ref icosa_points[icosa_index[n,2]] );
				}

				for( n = 0; n < result.Length; n++ )
				{
					result[n].n = result[n].n * radius;
				}

#if test1
		for( n = 0; n < 20; n++ )
		{
			Vector3 p1, p2, p3;
         Vector3 v1, v2;
			scale( p1, add( p1, icosa_points[icosa_index[n][1]], icosa_points[icosa_index[n][0]] ), 0.5 );
         scale( p1, p1, 1.0 / Length( p1 ) );
         scale( p2, add( p2, icosa_points[icosa_index[n][2]], icosa_points[icosa_index[n][1]] ), 0.5 );
         scale( p2, p2, 1.0 / Length( p2 ) );
			scale( p3, add( p3, icosa_points[icosa_index[n][0]], icosa_points[icosa_index[n][2]] ), 0.5 );
         scale( p3, p3, 1.0 / Length( p3 ) );
			sub( v1, icosa_points[icosa_index[n][1]], icosa_points[icosa_index[n][0]] );
         sub( v2, icosa_points[icosa_index[n][2]], icosa_points[icosa_index[n][1]] );
			crossproduct( icosahedron[n].n, v1, v2 );
         normalize( icosahedron[n].n );
         PrintVector3( icosahedron[n].n );
		}
#endif
				return result;
			}

		}

		public Grid()
		{

		}

		[STAThread]
		static void Main()
		{
			Grid g = new Grid();
			// 3 = 1280
			// 5 = 20480
			// 10 = 20971520
			BasicPlane[] sphere_layer1 = g.InitIcosohedron( 5, 100.0f );
																			
		}
	}
}
