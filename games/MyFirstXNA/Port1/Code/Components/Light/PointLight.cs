#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace TestsForFun
{
    public class PointLight : Light
    {
        #region Properties
        #endregion

        #region Fields
        Vector3 Position = Vector3.Zero;
        #endregion

        #region Initialization
        public PointLight()
        {

        }

        public PointLight(Vector3 Position)
        {
            this.Position = Position;
        }

        public PointLight(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
        }
        #endregion

        #region Methods
        // This class is still under construction
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void SetPosition(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
        }

        public void SetPosition(Vector3 Position)
        {
            this.Position = Position;
        }
        #endregion
    }
}
