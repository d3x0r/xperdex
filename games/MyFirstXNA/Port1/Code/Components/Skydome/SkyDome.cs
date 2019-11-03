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
    public class SkyDome : Sky
    {
        #region Properties
        #endregion

        #region Fields
        float RotateSpeed = 0;      // In radians per second

        bool Rotates = false;
        #endregion

        #region Initialization
        public SkyDome(GraphicsDevice device, ContentManager content, string TexturePath)
        {
            Device = device;
            Content = content;

            SkyTexturePath = TexturePath;
            Initialize(Vector3.Zero, Vector3.Zero, "./Models/Skys/dome");
            SkyTexture = Content.Load<Texture2D>(TexturePath);
            SetScale(3000);
        }
        
        /// <summary>
        /// Constructs a skydome, and sets it up to rotate.
        /// </summary>
        /// <param name="TexturePath">Sky texture</param>
        /// <param name="RotateSpeedRadiansPerSecond">Rotation speed of the sky in radians per second</param>
        public SkyDome(GraphicsDevice device, ContentManager content, string TexturePath, float RotateSpeedRadiansPerSecond)
        {
            Device = device;
            Content = content;

            SkyTexturePath = TexturePath;
            SkyTexture = Content.Load<Texture2D>(TexturePath);
            Initialize(Vector3.Zero, Vector3.Zero, "./Models/Skys/dome");
            SetScale(3000);

            Rotates = true;
            RotateSpeed = RotateSpeedRadiansPerSecond / 1000;
        }

        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            if ( Rotates )
                RotateHorizontal(RotateSpeed * gameTime.ElapsedGameTime.Milliseconds);   
        }

        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            // Set the alpha blend mode.
            Device.RenderState.AlphaBlendEnable = true;
            Device.RenderState.SourceBlend = Blend.SourceAlpha;
            Device.RenderState.DestinationBlend = Blend.InverseSourceAlpha;
            float OrgFogDensity = Device.RenderState.FogDensity;
            Device.RenderState.FogDensity *= .3f;

            WorldMatrix = Matrix.CreateScale(Scale)
                        * Matrix.CreateFromYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z)
                        * Matrix.CreateTranslation(CurrentCam.GetPosition() - ElevationPosition);            

            foreach (ModelMesh mesh in this.Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.Texture = SkyTexture;
                    effect.DirectionalLight0.Direction = -SceneLight.Direction;
                    effect.DirectionalLight1.Direction = Vector3.Transform(effect.DirectionalLight0.Direction, Matrix.CreateRotationY(MathHelper.PiOver2));
                    effect.DirectionalLight2.Direction = -SceneLight.Direction;
                    effect.AmbientLightColor = SceneLight.AmbientColor * SceneLight.AmbientPower * 0.5f;
                    effect.DiffuseColor = SceneLight.DiffuseColor * SceneLight.AmbientPower * 0.5f;
                    effect.SpecularColor = SceneLight.SpecularColor * SceneLight.AmbientPower * 0.5f;
                    effect.SpecularPower = SceneLight.SpecularPower;
                    effect.EmissiveColor = SceneLight.AmbientColor * SceneLight.AmbientPower * 0.5f;

                    effect.View = ViewMatrix;
                    effect.Projection = ProjectionMatrix;
                    effect.World = this.BoneTransforms[mesh.ParentBone.Index] * WorldMatrix;
                    effect.Alpha = Opacity;
                }
                mesh.Draw();
            }

            Device.RenderState.FogDensity = OrgFogDensity;
        }

        public void EnableRotation()
        {
            Rotates = true;
        }

        public void DisableRotation()
        {
            Rotates = false;
        }

        public void SetRotationSpeed(float RotateSpeedRadiansPerSecond)
        {
            RotateSpeed = RotateSpeedRadiansPerSecond / 1000;
        }
        #endregion
    }
}