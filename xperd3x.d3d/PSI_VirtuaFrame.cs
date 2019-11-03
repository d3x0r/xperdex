

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
// this is a thing that is not always available!
//C:\Windows\Microsoft.NET\DirectX for Managed Code\1.0.2902.0\Microsoft.DirectX.DirectDraw.dll
//Core DirectDraw classes for Managed DirectX
using Direct3D = Microsoft.DirectX.Direct3D;

namespace xperd3x.d3d
{
	/// <summary>
	/// This class represents a 2d GUI drawing surface which is displayed
	/// in a 3d frame.
	/// </summary>
	public class PSI_VirtuaFrame
	{

		/// <summary>
		/// This is the position of the center point of the plane.
		/// </summary>
		Vector3 origin;
		/// <summary>
		/// This is the direction of the plane
		/// </summary>
		Vector3 normal;
		/// <summary>
		/// This is the width and height of the plane -(extent.x-1)/2,-(extent.y-1)/2 - (extent.x+1)/2,(extent.y+1)/2
		/// </summary>
		Vector2 extents;

		public PSI_VirtuaFrame()
		{
			normal = new Vector3( 0.0f, 0.0f, -1.0f );
			extents = new Vector2( 320.0f, 240.0f );
			PSI_Renderalbes.Frames.Add( this );
		}

		~PSI_VirtuaFrame()
		{
			PSI_Renderalbes.Frames.Remove( this );
		}

		public delegate void OnRender( D3DState state );
		public event OnRender Render;
		internal void DoRender( D3DState state )
		{
			Transforms t = state.graphics.Transform;
			// should project normal on t to get the Up/right vector

			state.graphics.RenderState.SourceBlend = Direct3D.Blend.SourceAlpha;
			state.graphics.RenderState.DestinationBlend = Direct3D.Blend.InvSourceAlpha;
			state.graphics.RenderState.AlphaBlendEnable = true;

			if( Render != null )
				Render( state );
		}

		public delegate void OnMouse( D3DState state, int x, int y, int b );
		public event OnMouse Mouse;
		internal void DoMouse( D3DState state, int x, int y, int b )
		{

		}
	}
}
