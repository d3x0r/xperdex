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
    public abstract class Light : Component
    {
        #region Properties
        #endregion

        #region Fields
        public Vector3 Direction = Vector3.Zero;
        public float AmbientPower = 1f;
        public Vector3 AmbientColor = Vector3.Zero;
        public Vector3 SpecularColor = Vector3.Zero;
        public float SpecularPower = 1f;
        public Vector3 DiffuseColor = Vector3.Zero;

        public float MinimumAmbient = .1f;

        public Vector3 UpVector = new Vector3(0, 0, 1); 
        #endregion

        #region Initialization
        
        public Light()
        {

        }
        #endregion

        #region Methods
        #endregion
    }
}
