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
    public abstract class Weather : Component
    {
        #region Properties
        #endregion

        #region Fields
        protected Physics Physics = Physics.Instance;
        protected Random random;

        protected Vector3 CameraOrigin = Vector3.Zero;
        protected Light SceneLight;

        protected float ParticleStartElevation = 50f;    // Elevation snow begins at

        protected float Intensity = 1f;               // Amount of snow, in flakes per millisecond
        protected float TimeSinceLastParticle = 0.0f;    // Time since last flake was created, in milliseconds

        protected float ParticleAirViscosity = .1f;
        #endregion

        #region Initialization
        public Weather()
        {
        }
        #endregion

        #region Methods 
        public void SetIntensity(float WeatherParticlesPerSecond)
        {
            Intensity = 1000 / WeatherParticlesPerSecond;
        }

        public Vector3 RandomPointNearOrigin()
        {
            float XLocation = (float)(random.NextDouble() * 300) - 150;    // -150 to 150
            float YLocation = (float)(random.NextDouble() * 300) - 150;    // -150 to 150

            return (new Vector3(CameraOrigin.X + XLocation, CameraOrigin.Y + YLocation, CameraOrigin.Z + ParticleStartElevation));
        }
        #endregion
    }
}
