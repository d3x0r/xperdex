using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using xperdex.core.interfaces;
using Direct3D = Microsoft.DirectX.Direct3D;

namespace xperd3x.d3d
{
	public abstract class PSI_DirectGrid : PSI_DirectFrame, IReflectorCreate
	{

		Direct3D.CustomVertex.TransformedColored[] vertexes = null;
		Direct3D.Sprite sprite;
		Direct3D.Texture texture;

		public abstract void OnCreate( Device device );

		public PSI_DirectGrid()
		{
		}

		#region IReflectorCreate Members

		void IReflectorCreate.OnCreate( Control pc )
		{
			//throw new Exception( "The method or operation is not implemented." );
			DoCreate(pc);
			sprite = new Direct3D.Sprite( state.graphics );
			texture = Direct3D.TextureLoader.FromFile(
state.graphics, "c:/ftn3000/etc/images/misc/sky.jpg", 0, 0, 0, 0, Direct3D.Format.Unknown,
Direct3D.Pool.Managed, Direct3D.Filter.Linear,
Direct3D.Filter.Linear, 0 );
			Run();
			//paused = false;
		}

		#endregion


		private Sprite textDrawerSprite = null;
		private Direct3D.Font font1 = null;
		private Microsoft.DirectX.Direct3D.Font font2 = null;
		private const string bigText =
		"This is a single call to Font.DrawText() with a large text " +
		"buffer. It shows that Font supports word wrapping. If " +
		"you resize the window, the words will automatically wrap " +
		"to the next line.  It also supports\r\nhard line breaks. " +
		"Font also supports Unicode text with correct word wrapping " +
		"for right-to-left languages.";

		public virtual void OnRender()
		{
			// do nothing by default
		}

		void Draw( 	Device device )
		{
			try
			{

				System.Drawing.Rectangle rect;
				// start drawing commands
				device.BeginScene();


				// Demonstration 1
				// Draw a simple line using DrawText
				// Pass in DrawTextFormat.NoClip so we don't have to calc
				// the bottom/right of the rect

				font1.DrawText( null,
					"This is a trivial call to Font.DrawText",
					new System.Drawing.Rectangle( 5, 150, 0, 0 ),
					DrawTextFormat.NoClip, System.Drawing.Color.Red );


				// Demonstration 2
				// Allow multiple draw calls to sort by texture changes
				// by Sprite When drawing 2D text use flags: 
				// SpriteFlags.AlphaBlend | SpriteFlags.SortTexture. 

				textDrawerSprite.Begin( SpriteFlags.AlphaBlend |
					SpriteFlags.SortTexture );

				rect = new System.Drawing.Rectangle( 5, this.screenheight - 15 * 6, 0, 0 );
				font2.DrawText( textDrawerSprite,
					"These are multiple calls to Font.DrawText()",
					rect, DrawTextFormat.NoClip, Color.White );
				rect = new System.Drawing.Rectangle( 5, this.screenheight - 15 * 5, 0, 0 );
				font2.DrawText( textDrawerSprite,
					"using the same Sprite. The font now caches",
					rect, DrawTextFormat.NoClip, Color.White );
				rect = new System.Drawing.Rectangle( 5, this.screenheight - 15 * 4, 0, 0 );
				font2.DrawText( textDrawerSprite,
					"letters on one or more textures. In order",
					rect, DrawTextFormat.NoClip, Color.White );
				rect = new System.Drawing.Rectangle( 5, this.screenheight - 15 * 3, 0, 0 );
				font2.DrawText( textDrawerSprite,
					"to sort by texturestate changes on multiple",
					rect, DrawTextFormat.NoClip, Color.White );
				rect = new System.Drawing.Rectangle( 5, this.screenheight - 15 * 2, 0, 0 );
				font2.DrawText( textDrawerSprite,
					"calls to DrawText() pass a Sprite and use flags",
					rect, DrawTextFormat.NoClip, Color.White );
				rect = new System.Drawing.Rectangle( 5, this.screenheight - 15 * 1, 0, 0 );
				font2.DrawText( textDrawerSprite,
					"SpriteFlags.AlphaBlend | SpriteFlags.SortTexture",
					rect, DrawTextFormat.NoClip, Color.White );

				textDrawerSprite.End();

				// Demonstration 3:
				// Word wrapping and unicode text.  
				// Note that not all fonts support dynamic font linking. 
				System.Drawing.Rectangle rc =
					new System.Drawing.Rectangle( 10, 35,
					this.screenwidth - 30, this.screenheight - 10 );

				font2.DrawText( null, bigText, rc,
					DrawTextFormat.Left | DrawTextFormat.WordBreak |
					DrawTextFormat.ExpandTabs,
					System.Drawing.Color.CornflowerBlue );

				// write the fps
				//fpsTimer.Render();
				OnRender( );
			}

			finally
			{
				// end the drawing commands and copy to screen
				device.EndScene();
				device.Present();
				//fpsTimer.StopFrame();
			}


			sprite.Begin(SpriteFlags.None);
			sprite.Draw( texture,
			new Rectangle( 0, 0, 512, 512 ),
					//new Vector2( 1.0f, 1.0f ), // scaling
					new Vector3( 256.0f, 256.0f, 0.0f ) //rotation center 
					//,0.0f // rogateion
					, new Vector3( 0.0f, 0.0f, 0.0f) // translation
					,Color.White // color
					);
			sprite.End();
		}
	}
}
