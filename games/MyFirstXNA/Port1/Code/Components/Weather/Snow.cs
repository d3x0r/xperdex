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
    public class SnowWeather : Weather
    {
        #region Properties
        #endregion

        #region Fields
        SnowParticleSystem SnowParticleSystem;
        #endregion

        #region Initialization
        public SnowWeather(TestsMain game, ContentManager content)
        {
            SnowParticleSystem = new SnowParticleSystem(game, content);
            SnowParticleSystem.Initialize();

            random = new Random();
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            ProcessSnowCreation(gameTime);

            SnowParticleSystem.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            CameraOrigin = CurrentCam.GetPosition();
            this.SceneLight = SceneLight;
            SnowParticleSystem.SetCamera(ViewMatrix, ProjectionMatrix);
            SnowParticleSystem.Draw(gameTime, SceneLight);
        }

        public void ProcessSnowCreation(GameTime gameTime)
        {
            TimeSinceLastParticle += gameTime.ElapsedGameTime.Milliseconds;

            // If the time between flakes has exceeded intensity value
            // then it is time for another flake
            while (TimeSinceLastParticle > Intensity)
            {
                TimeSinceLastParticle -= Intensity;
				if( SceneLight == null )
					break;
                // Create a particle somewhere around the player, in the sky.
                SnowParticleSystem.AddParticle(RandomPointNearOrigin(), 
                                              (Physics.GravityVector + Physics.WindVector * ParticleAirViscosity) / Physics.MeterToWorldScale,
                                               new Color((SceneLight.DiffuseColor + SceneLight.AmbientColor) * 0.5f));
            }
        }
        #endregion
    }
}
