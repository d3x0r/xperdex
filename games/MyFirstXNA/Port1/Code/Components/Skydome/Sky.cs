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
    public abstract class Sky : BaseEntity
    {
        #region Properties
        #endregion

        #region Fields
        protected Texture2D SkyTexture;

        public string SkyTexturePath;   // For things like the water component to use this texture

        protected Vector3 ElevationPosition = new Vector3(0, 0, 1000);  // Default skydome position
        #endregion

        #region Initialization
        public Sky()
        {
        }
        #endregion

        #region Methods   
        public void SetElevation(float Elevation)
        {
            ElevationPosition = new Vector3(0, 0, Elevation);
        }
        #endregion
    }
}
