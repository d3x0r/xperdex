using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Direct3D = Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.Direct3D;

namespace D3D_DemoLine
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			//direct3d1.Dx.Viewport.MaxZ = 18000;
			//direct3d1.
			direct3d1.DxFullScreen = true;
		}

		private void direct3d1_DxRenderPre( Gosub.Direct3d d3d, Microsoft.DirectX.Direct3D.Device dx )
		{
			// clear
			
			dx.Clear( ClearFlags.Target, Color.DarkBlue, 1.0f, 0 );

		}

		private void direct3d1_DxRender2d( Gosub.Direct3d d3d, Microsoft.DirectX.Direct3D.Device dx, Microsoft.DirectX.Direct3D.Surface surface, Graphics graphics )
		{
			// 2d...
		}

		Direct3D.CustomVertex.TransformedColored[] vertexes = null;

		private void direct3d1_DxRender3d_1( Gosub.Direct3d d3d, Microsoft.DirectX.Direct3D.Device dx )
		{
			try
			{
				int screenwidth = direct3d1.Width;
				int screenheight = direct3d1.Height;
				// 3d...
				{
					if( vertexes == null )
					{
						vertexes = new Direct3D.CustomVertex.TransformedColored[3];
					}
						// top vertex:
						vertexes[0].X = screenwidth / 2.0f; // halfway across the screen
						vertexes[0].Y = screenheight / 3.0f; // 1/3 down screen
						vertexes[0].Z = 1.3f;
						vertexes[0].Color = Color.Red.ToArgb();
						// right vertex:
						vertexes[1].X = ( screenwidth / 3.0f ) * 2.0f; // 2/3 across the screen
						vertexes[1].Y = ( screenheight / 3.0f ) * 2.0f; // 2/3 down screen
						vertexes[1].Z = 0.0f;
						vertexes[1].Color = Color.Green.ToArgb();
						// left vertex:
						vertexes[2].X = screenwidth / 3.0f; // 1/3 across the screen
						vertexes[2].Y = ( screenheight / 3.0f ) * 2.0f; // 2/3 down screen
						vertexes[2].Z = -0.01f;
						vertexes[2].Color = Color.Blue.ToArgb();
					//}

					dx.VertexFormat = Direct3D.CustomVertex.TransformedColored.Format;
					try
					{
						dx.DrawUserPrimitives(
						Direct3D.PrimitiveType.TriangleList,
						1, vertexes );
					}
					catch(
						Exception ex )
					{
						//return true;
					}
				}
			}
			catch { }
		}

		private void direct3d1_Load( object sender, EventArgs e )
		{

		}

	}
}
