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
    public class RainWeather : Weather
    {
        #region Properties
        #endregion

        #region Fields
        RainParticleSystem RainParticleSystem;
        #endregion

        #region Initialization
        public RainWeather(TestsMain game, ContentManager content)
        {
            RainParticleSystem = new RainParticleSystem(game, content);
            RainParticleSystem.Initialize();

            random = new Random();
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            ProcessRainCreation(gameTime);

            RainParticleSystem.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            CameraOrigin = CurrentCam.GetPosition();
            this.SceneLight = SceneLight;
            RainParticleSystem.SetCamera(ViewMatrix, ProjectionMatrix);
            RainParticleSystem.Draw(gameTime, SceneLight);
        }

        public void ProcessRainCreation(GameTime gameTime)
        {
            TimeSinceLastParticle += gameTime.ElapsedGameTime.Milliseconds;

            // If the time between flakes has exceeded intensity value
            // then it is time for another flake
            while (TimeSinceLastParticle > Intensity)
            {
                TimeSinceLastParticle -= Intensity;

                // Create a particle somewhere around the player, in the sky.
                RainParticleSystem.AddParticle(RandomPointNearOrigin(),
                                              (Physics.GravityVector * 12 + Physics.WindVector * ParticleAirViscosity) / Physics.MeterToWorldScale,
                                               new Color((SceneLight.DiffuseColor + SceneLight.AmbientColor) * 0.5f));
            }
        }
        #endregion
    }
}
