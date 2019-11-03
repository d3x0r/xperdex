
using xperd3x.d3d;
// this is a thing that is not always available!
//C:\Windows\Microsoft.NET\DirectX for Managed Code\1.0.2902.0\Microsoft.DirectX.DirectDraw.dll
//Core DirectDraw classes for Managed DirectX
using Direct3D = Microsoft.DirectX.Direct3D;
using System.Drawing;


namespace xperdex.layout.board
{

	/// <summary>
	/// Cell is a class which encapsulates a single blob of drawable data.  
	/// Board uses cells to output to its surface.
	/// </summary>
	public class Cell
	{
		internal int x_ofs, y_ofs;
		internal int rows, cols;
		internal Direct3D.VertexBuffer cell_verts;
		internal Rectangle image_rectangle( PeiceRepresentation peice, Image image )
		{
			int tmpx, tmpy;
			return new Rectangle( tmpx = image.Width * x_ofs / peice.Cols
				, tmpy = image.Height * y_ofs / peice.Rows
				, image.Width * ( x_ofs + 1 ) / peice.Cols - tmpx
				, image.Height * ( y_ofs + 1 ) / peice.Rows - tmpy );
		}

		// cells are setup as x, y index of col, row, and 1, 1 wide,high, and a total rows and cols they are of.

		// okay so this computes from that, 
		public void SetupCell( D3DState state, float x, float y, float width, float height, float rows, float cols )
		{
			x_ofs = (int)x;
			y_ofs = (int)y;
			this.rows = (int)rows;
			this.cols = (int)cols;

			if( state == null )
				return;

			cell_verts = new Direct3D.VertexBuffer(
									 typeof( Direct3D.CustomVertex.PositionTextured ),
									 4,
									 state.graphics,
									 0,
									 Direct3D.CustomVertex.PositionTextured.Format,
									 Direct3D.Pool.Default );


			Direct3D.CustomVertex.PositionTextured[] verts =
						 (Direct3D.CustomVertex.PositionTextured[])cell_verts.Lock( 0, 0 );
			verts[0].X = -1.0f; verts[0].Y = -1.0f; verts[0].Z = 0.0f;
			verts[0].Tu = ( x * width ) / cols; verts[0].Tv = ( y * height ) / rows;

			verts[1].X = -1.0f; verts[1].Y = 1.0f; verts[1].Z = 0.0f;
			verts[1].Tu = ( ( x + 1 ) * width ) / cols; verts[1].Tv = ( y * height ) / rows;

			verts[2].X = 1.0f; verts[2].Y = -1.0f; verts[2].Z = 0.0f;
			verts[2].Tu = ( x * width ) / cols; verts[2].Tv = ( ( y + 1 ) * height ) / rows;

			verts[3].X = 1.0f; verts[3].Y = 1.0f; verts[3].Z = 0.0f;
			verts[3].Tu = ( ( x + 1 ) * width ) / cols; verts[3].Tv = ( ( y + 1 ) * height ) / rows;
			cell_verts.Unlock();
		}
	}
}
