#region File Description
//-----------------------------------------------------------------------------
// SmokePlumeParticleSystem.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace TestsForFun
{
    /// <summary>
    /// Custom particle system for flakes of snow.
    /// </summary>
    class SnowParticleSystem : ParticleSystem3D
    {
        public SnowParticleSystem(TestsMain game, ContentManager content)
            : base(game, content)
        { }


        protected override void InitializeSettings(ParticleSettings settings)
        {
            settings.TextureName = "./Particles/snowflake";

            settings.MaxParticles = 6000;

            settings.Duration = TimeSpan.FromSeconds(12);

            settings.MinHorizontalVelocity = -3;
            settings.MaxHorizontalVelocity = 3;

            settings.MinVerticalVelocity = 0;
            settings.MaxVerticalVelocity = 0;

            settings.Gravity = Vector3.Zero;

            settings.EndVelocity = 0.75f;

            settings.MinRotateSpeed = -1;
            settings.MaxRotateSpeed = 1;

            settings.MinStartSize = .5f;
            settings.MaxStartSize = 1.3f;

            settings.MinEndSize = .5f;
            settings.MaxEndSize = 1.3f;
        }

        public override void Draw(GameTime gameTime, Light SceneLight)
        {
            effectLightBrightnessParameter.SetValue(SceneLight.AmbientPower * 2);

            base.Draw(gameTime, SceneLight);
        }
    }
}
