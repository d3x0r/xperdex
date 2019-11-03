using System;

namespace xperd3x.virtuality
{
	public class Transform
	{
		Vector3 speed;
		Vector3 accel;
		Vector3 rotation;
		Vector3 rotaccel;

		Vector3 scale;

		 const double ONE = 1.0F;
		 const double ZERO = 0.0F;

		 public const int vRight = 0;
		public const int vUp = 1;
		public const int vForward = 2;

		Vector3[] m = new Vector3[4]; // 4th column is not really used by anything I do in this...

		//----------------------------------------------------------------

		void Clear()
		{
			int a, b;
			for( a = 0; a < 4; a++ )
				for( b = 0; b < 3; b++ )
					if( a == b )
						m[a][ b] = ONE;
					else
						m[a][ b] = ZERO;
		}

		void Reset()
		{
			time_scale = 1.0F;
			scale = Vector3.unity;

			speed = Vector3.origin;
			rotation = Vector3.origin;
			accel = Vector3.origin;
			rotaccel = Vector3.origin;
		}

		//----------------------------------------------------------------
		public Transform()
		{
			Clear();
			Reset();
		}

		//----------------------------------------------------------------

		void Scale( double sx, double sy, double sz )
		{
			scale[0] = sx;
			scale[1] = sy;
			scale[2] = sz;
		}

		//----------------------------------------------------------------

		
		void Translate( Vector3 t )
		{
			m[3] = t;
		}

		//----------------------------------------------------------------

        public void Translate(double tx, double ty, double tz)
		{
			m[3]= new Vector3( tx, ty, tz );
		}

		//----------------------------------------------------------------


        public void TranslateRel(Vector3 t)
		{
			 m[3] += t;
		}

		//----------------------------------------------------------------

        public void TranslateRel(double tx, double ty, double tz)
		{
			 m[3] += new Vector3( tx, ty, tz );
		}

		//----------------------------------------------------------------

		public void RotateAround( Vector3 p, double amount )
		{
			// P defines an axis around which the rotation portion of the matrix
			// is rotated by an amount.
			// coded from http://www.mines.edu/~gmurray/ArbitraryAxisRotation/ArbitraryAxisRotation.html
			// and http://www.siggraph.org/education/materials/HyperGraph/modeling/mod_tran/3drota.htm
			// and http://astronomy.swin.edu.au/~pbourke/geometry/rotate/
			Vector3[] matrix_array = new Vector3[4];
			double Len = p.Magnitude;
			double Cos = Math.Cos( amount );
			double Sin = Math.Sin( amount );
			double normal;
			// actually the only parts of the matrix resulting
			// will only be the rotation matrix, for which we are
			// building an absolute translation... which may be saved by
			// passing an identity filled transform... but anyhow...
			// the noise in the speed, accel, etc resulting from uninitialized
			// stack space being used for the transform this is building, matters
			// not at all.

			// okay this is rude and ugly, and could be optimized a bit
			// but we do have a short stack and 3 are already gone.
			normal = p.X * p.X + p.Y * p.Y + p.Z * p.Z;
			matrix_array[0][ 0] = p.X * p.X + (p.Y * p.Y + p.Z * p.Z) * Cos
				/ normal;
			matrix_array[0][ 1] = p.X * p.Y * (1 - Cos) - p.Z * Len * Sin
				/ normal;
			matrix_array[0][ 2] = p.X * p.Z * (1 - Cos) + p.Y * Len * Sin
				/ normal;
			matrix_array[1][ 0] = p.X * p.Y * (1 - Cos) + p.Z * Len * Sin
				/ normal;
			matrix_array[1][ 1] = p.Y * p.Y + (p.X * p.X + p.Z * p.Z) * Cos
				/ normal;
			matrix_array[1][ 2] = p.Y * p.Z * (1 - Cos) - p.X * Len * Sin
				/ normal;
			matrix_array[2][ 0] = p.X * p.Z * (1 - Cos) - p.Y * Len * Sin
				/ normal;
			matrix_array[2][ 1] = p.Y * p.Z * (1 - Cos) + p.X * Len * Sin
				/ normal;
			matrix_array[2][ 2] = p.Z * p.Z + (p.X * p.X + p.Y * p.Y) * Cos
				/ normal;
			// oh yeah , be nice, and release these symbols...
			// V is such a common vector variable :)

			ApplyRotation( matrix_array, this );
		}

        public void RotateAbs(Vector3 dv)
		{
			// set rotation matrix to coordinates specified.
			double[] rcos = new double[3]; // cos(rx), cos(ry), cos(rz)
			double[] rcosf = new double[3]; // cos[2]*cos[1]][ cos[2]*cos[0], cos[1]*cos[0]

			m[1][ 0] = -(m[0][ 1] = (double)Math.Sin( dv[vForward] ));
			m[2][ 0] = -(m[0][ 2] = (double)Math.Sin( dv[vUp] ));
			m[2][ 1] = -(m[1][ 2] = (double)Math.Sin( dv[vRight] ));
			m[0][ 0] = //s[0] *  // scale???? ookay...
				(rcosf[0] = (rcos[2] = (double)Math.Cos( dv[vForward] ))
							  * (rcos[1] = (double)Math.Cos( dv[vUp] )));
			m[1][ 1] = //s[1] *
				(rcosf[1] = (rcos[2]) * (rcos[0] = (double)Math.Cos( dv[vRight] )));
			m[2][ 2] = //s[2] *
				(rcosf[2] = (rcos[1]) * (rcos[0]));
		}

		//----------------------------------------------------------------

		public void RotateAbs( double rx, double ry, double rz )
		{
			RotateAbs( new Vector3( rx, ry, rz ) );
		}

		//------------------------------------

        private void Rotate(double dAngle, ref Vector3 vaxis1, ref Vector3 vaxis2)
		{
			Vector3 v1, v2;
			Vector3 vsave = vaxis1;
			double dsin = Math.Sin( dAngle );
			double dcos = Math.Cos( dAngle );

			v1 = vaxis1 * dcos;
			v2 = vaxis2 * dsin;
			vaxis1 = v1 - v2;

			v2 = vsave * dsin;
			v1 = vaxis2 * dcos;
			vaxis2 = v1 + v2;
		}

        public void Rotate(double dAngle, Vector3[] ax1, int ax1o, Vector3[] ax2, int ax2o)
		{
            Rotate(dAngle, ref ax1[ax1o], ref ax2[ax2o]
					);
		}
		//----------------------------------------------------------------

		void RotateYaw( ref Vector3[] m, double a ) { if( a != 0) Rotate ( a, m,vRight, m,vForward ); }
		void RotatePitch( ref Vector3[] m, double a ) { if( a != 0 )  Rotate( a, m, vForward, m, vUp ); }
		void RotateRoll( ref Vector3[] m, double a ) { if( a != 0 )  Rotate( a, m, vUp, m, vRight ); }
		int nTime;
        public void RotateRel(Vector3 r)
		{ // depends on Scale function....
			switch( nTime++ )
			{
			case 0:
				RotateYaw( ref m, r[vUp] );
				RotatePitch( ref m, r[vRight] );
				RotateRoll( ref m, r[vForward] );
				break;
			case 1:
				RotateYaw( ref m, r[vUp] );
				RotateRoll( ref m, r[vForward] );
				RotatePitch( ref m, r[vRight] );
				break;
			case 2:
				RotatePitch( ref m, r[vRight] );
				RotateYaw( ref m, r[vUp] );
				RotateRoll( ref m, r[vForward] );
				break;
			case 3:
				RotatePitch( ref m, r[vRight] );
				RotateRoll( ref m, r[vForward] );
				RotateYaw( ref m, r[vUp] );
				break;
			case 4:
				RotateRoll( ref m, r[vForward] );
				RotatePitch( ref m, r[vRight] );
				RotateYaw( ref m, r[vUp] );
				break;
			default:
				nTime = 0;
				RotateRoll( ref m, r[vForward] );
				RotateYaw( ref  m, r[vUp] );
				RotatePitch( ref m, r[vRight] );
				break;
			}
		}

		//----------------------------------------------------------------

		public void RotateRel( double x, double y, double z )
		{
			RotateRel( new Vector3( x, y, z ) );
		}

		//----------------------------------------------------------------

		void RotateTo( Vector3 vforward, Vector3 vright )
		{
			m[vForward] = vforward;
			m[vForward ].Normalize();
			m[vRight]= vright;
			m[vRight ].Normalize();
			m[vUp] = m[vForward].CrossProduct( m[vRight] );
		}

		//----------------------------------------------------------------

		void RotateMast( Vector3 vup )
		{
			m[vUp] = vup;
			m[vUp].Normalize();
			m[vForward] = m[vUp].CrossProduct( m[vRight] );
			m[vForward].Normalize();
			m[vRight] = m[vForward].CrossProduct( m[vUp] );
		}

		//----------------------------------------------------------------

		void RotateAroundMast( double amount )
		{
			RotateYaw( ref m, amount );
		}


		//----------------------------------------------------------------

		// Right as in Right Angle...
		void RotateRight( int Axis1, int Axis2 )
		{
			Vector3 v;
			if( Axis1 == -1 )
			{
				 m[vForward] = -m[vForward];
				 m[vRight] = -m[vRight];
			}
			else
			{
				v= m[Axis1] ;
				m[Axis1]= m[Axis2] ;
				 v .Invert();
				m[Axis2]= v ;
			}
		}

		//----------------------------------------------------------------

		void ApplyInverseRotation( Vector3[] m, Vector3 dest, Vector3 src )
		{
			dest[0] = m[0][ vRight] * src[vRight] +
						 m[0][ vUp] * src[vUp] +
						 m[0][ vForward] * src[vForward];
			dest[1] = m[1][ vRight] * src[vRight] +
						 m[1][ vUp] * src[vUp] +
						 m[1][ vForward] * src[vForward];
			dest[2] = m[2][ vRight] * src[vRight] +
						 m[2][ vUp] * src[vUp] +
						 m[2][ vForward] * src[vForward];
		}

		void ApplyInverseRotation( ref Vector3 dest, ref Vector3 src )
		{
			dest[0] = m[0][vRight] * src[vRight] +
						 m[0][vUp] * src[vUp] +
						 m[0][vForward] * src[vForward];
			dest[1] = m[1][vRight] * src[vRight] +
						 m[1][vUp] * src[vUp] +
						 m[1][vForward] * src[vForward];
			dest[2] = m[2][vRight] * src[vRight] +
						 m[2][vUp] * src[vUp] +
						 m[2][vForward] * src[vForward];
		}
		//----------------------------------------------------------------

		void ApplyRotation( Vector3[] m, ref Vector3 dest, Vector3 src )
		{
			dest[0] = ( m[vRight][0] * src[vRight] +
						 m[vUp][0] * src[vUp] +
						 m[vForward][ 0] * src[vForward]);
			dest[1] = (m[vRight][1] * src[vRight] +
						 m[vUp][1] * src[vUp] +
						 m[vForward][ 1] * src[vForward]);
			dest[2] = (m[vRight][2] * src[vRight] +
						 m[vUp][2] * src[vUp] +
						 m[vForward][ 2] * src[vForward]);
		}

		void ApplyRotation( Vector3[] m, Vector3[]src_m, int src_mo )
		{
			Vector3 dest = new Vector3 (
			(m[vRight][0] * src_m[src_mo][vRight] +
						 m[vUp][0] * src_m[src_mo][vUp] +
						 m[vForward][0] * src_m[src_mo][vForward])
			,(m[vRight][1] * src_m[src_mo][vRight] +
						 m[vUp][1] * src_m[src_mo][vUp] +
						 m[vForward][1] * src_m[src_mo][vForward])
			,(m[vRight][2] * src_m[src_mo][vRight] +
						 m[vUp][2] * src_m[src_mo][vUp] +
						 m[vForward][2] * src_m[src_mo][vForward]) );
			src_m[src_mo][0] = dest[0];
			src_m[src_mo][1] = dest[1];
			src_m[src_mo][2] = dest[2];
		}

		void ApplyRotation( double[] s, Vector3[] m, ref Vector3 dest, Vector3 src )
		{
			dest[0] = s[0] * (m[vRight][0] * src[vRight] +
						 m[vUp][0] * src[vUp] +
						 m[vForward][ 0] * src[vForward]);
			dest[1] = s[1] * (m[vRight][1] * src[vRight] +
						 m[vUp][1] * src[vUp] +
						 m[vForward][ 1] * src[vForward]);
			dest[2] = s[2] * (m[vRight][2] * src[vRight] +
						 m[vUp][2] * src[vUp] +
						 m[vForward][ 2] * src[vForward]);
		}


		void ApplyRotation( Vector3[] m, Transform t )
		{
			ApplyRotation( m, t.m, 0 );
			ApplyRotation( m, t.m, 1 );
			ApplyRotation( m, t.m, 2 );
		}

		void ApplyRotation( ref Vector3 dest, Vector3 src )
		{
			ApplyRotation( m, ref dest, src );
		}

		//----------------------------------------------------------------

		void ApplyTranslation( ref Vector3 dest, Vector3 src )
		{
			dest = src + m[3];
		}

		//----------------------------------------------------------------
		void ApplyInverseTranslation( Vector3 dest, Vector3 src )
		{
			dest = m[3] - src;
		}

		//----------------------------------------------------------------

		void ApplyInverse( ref Vector3 dest, ref Vector3 src )
		{
			Vector3 v = src - m[3];
			ApplyInverseRotation( ref dest, ref v );
		}


		//----------------------------------------------------------------

		public void Apply( ref Vector3 dest, Vector3 src )
		{
			ApplyRotation( ref dest, src );
			ApplyTranslation( ref dest, dest );
		}
		//----------------------------------------------------------------

		public Vector3 Apply( Vector3 src )
		{
			Vector3 dest = new Vector3();
			ApplyRotation( ref dest, src );
			ApplyTranslation( ref dest, dest );
			return dest;
		}
		//----------------------------------------------------------------

		public void Apply( Ray3 prd, Ray3 prs )
		{
			Apply( ref prd.o, prs.o );
			ApplyRotation( ref prd.n, prs.n );
		}

		//----------------------------------------------------------------

		public void Apply( Transform ptd, Transform pts )
		{
			Transform t = new Transform();
			ApplyRotation( ref t.m[0], pts.m[0] );
			ApplyRotation( ref t.m[1], pts.m[1] );
			ApplyRotation( ref t.m[2], pts.m[2] );
			Apply( ref t.m[3], pts.m[3] );
			ptd.m = t.m;
		}

		//----------------------------------------------------------------

		void ApplyTranslation( Transform ptd, Transform pts )
		{
			Transform t = new Transform();
			t.m[0] = pts.m[0];
			t.m[1]= pts.m[1] ;
			t.m[2]= pts.m[2] ;
			Apply( ref t.m[3], pts.m[3] );
			ptd.m = t.m;
		}

		//----------------------------------------------------------------

		// may be called with the same transform for source and dest
		// safely transforms such that the source is not destroyed until
		// the value of dest is computed entirely, which is then set into dest.
		void ApplyRotation( Transform ptd, Transform pts )
		{
			ptd.Clear();
			ApplyRotation( ref ptd.m[0], pts.m[0] );
			ApplyRotation( ref ptd.m[1], pts.m[1] );
			ApplyRotation( ref ptd.m[2], pts.m[2] );
			ptd.m[3]= pts.m[3] ;
		}

		//----------------------------------------------------------------

		void ApplyInverse( Ray3 prd, Ray3 prs )
		{
			ApplyInverse( ref prd.o, ref prs.o );
			ApplyInverseRotation( ref prd.n, ref prs.n );
		}

		//----------------------------------------------------------------

		void ApplyInverse( Transform ptd, Transform pts )
		{
			ptd.Clear();
			ApplyInverseRotation( ref ptd.m[0], ref pts.m[0] );
			ApplyInverseRotation( ref ptd.m[1], ref pts.m[1] );
			ApplyInverseRotation( ref ptd.m[2], ref pts.m[2] );
			ApplyInverse( ref ptd.m[3], ref pts.m[3] );
		}

		//----------------------------------------------------------------

		void ApplyInverseTranslation( Transform ptd, Transform pts )
		{
			ptd.m[0] = pts.m[0] ;
			ptd.m[1] = pts.m[1] ;
			ptd.m[2] = pts.m[2] ;
			ptd.m[3] = pts.m[3] - m[3];  // more then rotate....
		}

		//----------------------------------------------------------------

		void ApplyInverseRotation( Transform ptd, Transform pts )
		{
			Transform t = new Transform();
			ApplyInverseRotation( ref t.m[0], ref pts.m[0] );
			ApplyInverseRotation( ref t.m[1], ref pts.m[1] );
			ApplyInverseRotation( ref t.m[2], ref pts.m[2] );
			t.m[3]= pts.m[3] ;
			ptd.m = t.m;
		}

		//----------------------------------------------------------------

		public void TurnLeft( double scale )
		{
			rotation[vUp] = -scale;
		}
		public void TurnRight( double scale )
		{
			rotation[vUp] = scale;
		}
		public void TurnUp( double scale )
		{
			rotation[vRight] = -scale;
		}
		public void TurnDown( double scale )
		{
			rotation[vRight] = scale;
		}
		public void RollLeft( double scale )
		{
			rotation[vForward] = scale;
		}
		public void RollRight( double scale )
		{
			rotation[vForward] = -scale;
		}
		public void Forward( double distance )
		{
			speed[vForward] = distance;
		}

		//----------------------------------------------------------------

		public void Up( double distance )
		{
			speed[vUp] = distance;
		}

		//----------------------------------------------------------------

		public void Right( double distance )
		{
			speed[vRight] = distance;
		}

		//----------------------------------------------------------------

		public void Move(  )
		{
			// this matrix of course....
			// clock the matrix one cycle....
			// this means - add one speed vector 
			// and one rotation vector to the current
			// x-y-z-a-b-c position and orientation 
			// matrix...  this is later referenced
			// to trasform the remaining points
			// (application of this matrix)
			Vector3 v;
			 v= speed+ accel ;
			v = v * time_scale; // velocity applied across this time
			m[3][ 0] += v[0] * m[0][ 0]
							 + v[1] * m[1][ 0]
							 + v[2] * m[2][ 0];
			m[3][ 1] += v[0] * m[0][ 1]
							 + v[1] * m[1][ 1]
							 + v[2] * m[2][ 1];
			m[3][ 2] += v[0] * m[0][ 2]
							 + v[1] * m[1][ 2]
				+ v[2] * m[2][ 2];
			// include time scale for rotation also...
			if( rotation[0] != 0 || rotation[1] != 0 || rotation[2] != 0 )
			{
				RotateRel( rotation );
			}
		}

		//----------------------------------------------------------------

		void Unmove( Transform pt )
		{
			// this matrix of course....
			// clock the matrix one cycle....
			// this means - add one speed vector 
			// and one rotation vector to the current
			// x-y-z-a-b-c position and orientation 
			// matrix...  this is later referenced
			// to trasform the remaining points
			// (application of this matrix)
			if( rotation[0] != 0 || rotation[1] != 0 || rotation[2] != 0 )
			{
				nTime--; // back up the rotation ticker one... provides better unwinding.
				RotateRel( -rotation );
			}

			m[3][ 0] -= speed[0] * m[0][ 0]
							 + speed[1] * m[1][ 0]
							 + speed[2] * m[2][ 0];
			m[3][ 1] -= speed[0] * m[0][ 1]
							 + speed[1] * m[1][ 1]
							 + speed[2] * m[2][ 1];
			m[3][ 2] -= speed[0] * m[0][ 2]
							 + speed[1] * m[1][ 2]
							 + speed[2] * m[2][ 2];
		}

		//----------------------------------------------------------------

		Vector3 GetSpeed( Vector3 s )
		{
			s= speed ;
			return s;
		}

		//----------------------------------------------------------------

		Vector3 SetSpeed( Vector3 s )
		{
			speed= s;
			return s;
		}

		//----------------------------------------------------------------
		double time_scale;
		double SetTimeScale( double scale )
		{
			time_scale = scale; // application of motion uses this factor
			return scale;
		}

		//----------------------------------------------------------------
		Vector3 GetAccel( Vector3 s )
		{
			s= accel ;
			return s;
		}

		//----------------------------------------------------------------

		Vector3 SetAccel( Vector3 s )
		{
			accel= s ;
			return s;
		}

		//----------------------------------------------------------------

		Vector3 SetRotation( Vector3 r )
		{
			rotation= r ;
			return r;
		}

		//----------------------------------------------------------------

		public void GetOrigin( Vector3 o )
		{
			o= m[3] ;
		}

		//----------------------------------------------------------------

		public Vector3 GetOrigin( Transform pt )
		{
			return m[3];
		}

		//----------------------------------------------------------------

		public void GetAxis( out Vector3 a, int n )
		{
			a = m[n];
		}

		//----------------------------------------------------------------

		public Vector3 GetAxis( int n )
		{
			return m[n];
		}

		//----------------------------------------------------------------

		public void SetAxis( Vector3 a, int n )
		{
			m[n] = a;
		}

		//----------------------------------------------------------------

		public void SetAxis( double a, double b, double c, int n )
		{
			m[n][ 0] = a;
			m[n][ 1] = b;
			m[n][ 2] = c;
			m[n][ 3] = 0;
		}

		//----------------------------------------------------------------

		void InvertTransform( Transform pt )
		{
			double tmp;
			int i, j;
			// confusing loops - but this will invert top row
			// to left row - reversable operation...
			// unsure if I need to change signs during this 
			// the matrix determinate should still be the same....???
			for( j = 0; j < 3; j++ )
			{
				for( i = j + 1; i < 4; i++ )
				{
					tmp = m[i][ j];
					m[i][ j] = m[j][ i];
					m[j][ i] = tmp;
				}
			}
		}
		//----------------------------------------------------------------

		public void GetGLMatrix( double[] result )
		{
			// ugly but perhaps there will be some optimization if I
			// do this linear like... sure it's a lot of code, but at
			// least there's no work to loop and multiply...
			//result = new Vector3[4];
			result[(0*4)+ 0] = m[0][ 0];
			result[(0*4)+ 1] = m[1][0];
			result[(0*4)+ 2] = -m[2][0];
			//result[0][3] = m[3][0];
			result[(0*4)+ 3] = ZERO;// m[0][3];

			result[(1*4)+ 0] = m[0][1];
			result[(1*4)+ 1] = m[1][1];
			result[(1*4)+ 2] = -m[2][1];
			//result[1][3] = m[3][1];
			result[(1*4)+ 3] = ZERO;// m[1][3];

			// z was inverted of what it should have been...
			result[(2*4)+ 0] = m[0][2];
			result[(2*4)+ 1] = m[1][2];
			result[(2*4)+ 2] = -m[2][2];
			//result[2][3] = m[3][2];
			result[(2*4)+ 3] = ZERO;//m[2][ 3];

			//result[3][0] = m[0][3];
			//result[3][1] = m[1][3];
			//result[3][2] = m[2][3];
			//result[3][3] = m[3][3];
			// okay apparently opengl applies
			// this origin, and then rotates according to the
			// above matrix... so I need to undo having the correct
			// bias on the translation.
			//DOFUNC(ApplyInverseRotation)( result[3], m[3] );
			m[2].Invert(); // vFoward = -vForward before application...
			Vector3 v = new Vector3();
			ApplyInverseRotation( ref v, ref m[3] );
			v.Invert();
			result[(3*4)+0] = v[0];
			result[(3*4)+1] = v[1];
			result[( 3 * 4 ) + 2] = v[2];
			 m[2] .Invert();
			/* fuck I can't do this either.... 
			 m[2] .Invert();
			 result[3] .Invert();
			*/
			//ApplyRotation( result[3]*4)+ m[3] );
			result[(3 * 4) + 3] = ONE;// m[3][3];
		}
	}
}
