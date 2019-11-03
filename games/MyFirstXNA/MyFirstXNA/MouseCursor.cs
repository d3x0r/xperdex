using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TestsForFun;

namespace MyFirstXNA
{
	internal class XNAMouse: Component
	{
        SpriteBatch mouseSprite;

		Matrix billboard;
        Texture2D mouseTexture;
		Vector3 position;

        public XNAMouse(GraphicsDevice device,string fileName)
        {
            //mouseSprite = new SpriteBatch(device);
            mouseTexture =Texture2D.FromFile(device, fileName);
        }

        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        //public void Render()
        {
			/*
            mouseSprite.Begin(SpriteBlendMode.AlphaBlend);
			mouseSprite.Draw( mouseTexture
				, new Rectangle( Game1.last_event_state.X, Game1.last_event_state.Y,
					mouseTexture.Width, mouseTexture.Height)
					, Color.White);
            mouseSprite.End();
			*/
        }

		public override void Update( GameTime gameTime )
		{
			Vector3 pos = new Vector3( Game1.last_event_state.X, Game1.last_event_state.Y, Game1.last_event_state_Z );
			billboard = Matrix.CreateBillboard( pos, Game1.CurrentCamera.Position, Game1.CurrentCamera.UpVector, Game1.CurrentCamera.ForwardVector );

			//base.Update( gameTime );
		}

        public void Dispose()
        {
            mouseTexture.Dispose();
            mouseSprite.Dispose();
        }
    }


}
