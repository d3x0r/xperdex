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
    public class Fog : Component
    {
        #region Properties
        #endregion

        #region Fields
        GraphicsDevice Device;

        Color FogColor;
        float FogThickness;
        #endregion

        #region Initialization
        public Fog(GraphicsDevice Device)
        {
            this.Device = Device;
        }

        public Fog(GraphicsDevice Device, Color FogColor, float FogThickness)
        {
            this.Device = Device;
            this.FogColor = FogColor;
            this.FogThickness = FogThickness;
        }
        #endregion

        #region Methods
        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            // This method for changing fog color is expensive/inefficient, I'm still
            // looking for a better way to do this.
            Vector3 fogColorVect = FogColor.ToVector3() * SceneLight.AmbientPower;
            Device.RenderState.FogColor = new Color(fogColorVect);
            Device.RenderState.FogStart = 0.0f;
            Device.RenderState.FogEnd = 1.0f;
            Device.RenderState.FogTableMode = FogMode.ExponentSquared;
            Device.RenderState.FogVertexMode = FogMode.ExponentSquared;
            Device.RenderState.FogDensity = FogThickness;
            Device.RenderState.FogEnable = true;
        }
        #endregion
    }
}
