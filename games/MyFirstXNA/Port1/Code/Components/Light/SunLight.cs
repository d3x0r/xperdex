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
    public class SunLight : Light
    {
        #region Properties
        #endregion

        #region Fields
        GraphicsDevice Device;
        ContentManager Content;

        MathUtils MathUtils = MathUtils.Instance;

        bool DayNightEnabled = false;
        Timer DayNightTimer;

        #endregion

        #region Initialization
        public SunLight(GraphicsDevice Device, ContentManager Content)
        {
            this.Device = Device;
            this.Content = Content;
            DayNightTimer = new Timer();
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ProcessDayNightEffects(gameTime);
        }

        private void ProcessDayNightEffects(GameTime gameTime)
        {
            if (DayNightEnabled)
            {
                DayNightTimer.Update(gameTime);

                // Move sun across the map
                Direction.X = (float)Math.Cos(DayNightTimer.Cycles * MathHelper.Pi * 2);
                //Direction.Y = (float)Math.Cos(DayNightTimer.Cycles * MathHelper.Pi * 2);
                Direction.Y = (float)Math.Sin(DayNightTimer.Cycles * MathHelper.Pi * 2) * .4f;

                // Sun elevation in the sky, -.2f makes the days slightly longer than nights
                Direction.Z = (float)((Math.Sin(DayNightTimer.Cycles * MathHelper.Pi * 2)) - .3f);

                // Clamp the AmbientPower so it never goes completely black
                AmbientPower = -Direction.Z;
                AmbientPower = MathHelper.Clamp(AmbientPower, MinimumAmbient, 0.5f);
            }
        }

        public void EnableDayNight(int DayCycleLengthSeconds)
        {
            DayNightEnabled = true;
            DayNightTimer = new Timer(DayCycleLengthSeconds * 1000);
        }

        public void DisableDayNight()
        {
            DayNightEnabled = false;
        }
        #endregion
    }
}   