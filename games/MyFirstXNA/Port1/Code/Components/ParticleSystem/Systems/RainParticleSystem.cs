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
    /// Create a particle system for dropping drops of rain
    /// </summary>
    class RainParticleSystem : ParticleSystem3D
    {
        public RainParticleSystem(TestsMain game, ContentManager content)
            : base(game, content)
        { }

        protected override void InitializeSettings(ParticleSettings settings)
        {
            settings.TextureName = "./Particles/rainDrop";

            settings.MaxParticles = 8000;

            settings.Duration = TimeSpan.FromSeconds(1.05);

            settings.MinHorizontalVelocity = 0;
            settings.MaxHorizontalVelocity = 20;

            settings.MinVerticalVelocity = 0;
            settings.MaxVerticalVelocity = 0;

            settings.Gravity = Vector3.Zero;

            settings.EndVelocity = 1.00f;

            settings.MinRotateSpeed = 0;
            settings.MaxRotateSpeed = 0;

            settings.MinStartSize = 1;
            settings.MaxStartSize = 1.3f;

            settings.MinEndSize = 1;
            settings.MaxEndSize = 1.3f;
        }

        public override void Draw(GameTime gameTime, Light SceneLight)
        {
            effectLightBrightnessParameter.SetValue(SceneLight.AmbientPower * 2);

            base.Draw(gameTime, SceneLight);
        }
    }
}
