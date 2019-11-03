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
    public class Water : Component
    {
        #region Properties
        #endregion

        #region Fields
        GraphicsDevice Device;
        ContentManager Content;

        TestsMain game;     // Exposes access to the game

        Terrain SceneTerrain;
        Sky SceneSky;
        Weather SceneWeather;

        Vector3 WaterColor = Vector3.Zero;

        Effect WaterEffect;

        Texture2D WaterNormalTexture;
        Texture2D SkyTexture;

        VertexPositionTexture[] waterVertices;

        Vector3 Position;
        
        int Width;
        int Length;     

        float Elevation;

        RenderTarget2D RefractionRenderTarg;
        Texture2D RefractionMap;
        Vector3 RefractNormalDirection = Vector3.Normalize(new Vector3(0, 0, -1));   // Normal of water plane

        RenderTarget2D ReflectionRenderTarg;
        Texture2D ReflectionMap;
        Vector3 ReflectNormalDirection = Vector3.Normalize(new Vector3(0, 0, 1));// Normal of water plane reflection
        Matrix ReflectionViewMatrix;
        #endregion

        #region Initialization
        public Water(GraphicsDevice Device, ContentManager Content)
        {
            this.Device = Device;
            this.Content = Content;

            WaterEffect = Content.Load<Effect>("./Effects/water");

            // Set default textures in case none are initialized
            WaterNormalTexture = Content.Load<Texture2D>("./Textures/waterNormal");
            SkyTexture = Content.Load<Texture2D>("./Models/Textures/clouds");            
        }

        public void Initialize(Vector3 WaterColor, Vector3 Position, int Width, int Length, float Elevation)
        {
            this.Position = Position;
            this.Width = Width;
            this.Length = Length;
            this.Elevation = Elevation;

            SetupWaterVertices();
            RefractionRenderTarg = new RenderTarget2D(Device, 512, 512, 1, SurfaceFormat.Color);
            ReflectionRenderTarg = new RenderTarget2D(Device, 512, 512, 1, SurfaceFormat.Color);
        }

        public void SetSkyTexture(string SkyTexturePath)
        {
            SkyTexture = Content.Load<Texture2D>(SkyTexturePath);
        }

        public void SetSurfaceNormalMapTexture(string WaterNormalTexturePath)
        {
            WaterNormalTexture = Content.Load<Texture2D>(WaterNormalTexturePath);
        }

        private void SetupWaterVertices()
        {
            waterVertices = new VertexPositionTexture[6];

            waterVertices[0] = new VertexPositionTexture(new Vector3(0, 0, Elevation) + Position, new Vector2(0, 1));
            waterVertices[2] = new VertexPositionTexture(new Vector3(Width, Length, Elevation) + Position, new Vector2(1, 0));
            waterVertices[1] = new VertexPositionTexture(new Vector3(0, Length, Elevation) + Position, new Vector2(0, 0));

            waterVertices[3] = new VertexPositionTexture(new Vector3(0, 0, Elevation) + Position, new Vector2(0, 1));
            waterVertices[5] = new VertexPositionTexture(new Vector3(Width, 0, Elevation) + Position, new Vector2(1, 1));
            waterVertices[4] = new VertexPositionTexture(new Vector3(Width, Length, Elevation) + Position, new Vector2(1, 0));
        }

        public void Associate(Terrain SceneTerrain)
        {
            this.SceneTerrain = SceneTerrain;
        }

        public void Associate(Sky SceneSky)
        {
            this.SceneSky = SceneSky;
        }

        public void Associate(Weather Weather)
        {
            this.SceneWeather = Weather;
        }

        public void Associate(TestsMain game)
        {
            this.game = game;
        }
        #endregion

        #region Methods     
        public override void Draw(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            if (SceneTerrain != null)
            {
                DrawRefractionMap(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCam);
                DrawReflectionMap(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCam);

                Device.RenderState.AlphaBlendEnable = true;
                Device.RenderState.SourceBlend = Blend.SourceAlpha;
                Device.RenderState.DestinationBlend = Blend.InverseSourceAlpha;

                Device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);

                WaterEffect.CurrentTechnique = WaterEffect.Techniques["WaterAdv"];
                WaterEffect.Parameters["ReflectionView"].SetValue(ReflectionViewMatrix);
                WaterEffect.Parameters["ReflectionMapTexture"].SetValue(ReflectionMap);
                WaterEffect.Parameters["RefractionMapTexture"].SetValue(RefractionMap);

                WaterEffect.Parameters["WaveLength"].SetValue(1.9f);
                WaterEffect.Parameters["WaveHeight"].SetValue(0.3f);

                WaterEffect.Parameters["WindForce"].SetValue(2.0f);
                Matrix windDirection = Matrix.CreateRotationZ(MathHelper.PiOver2);
                WaterEffect.Parameters["WindDirection"].SetValue(windDirection);
            }
            else
            {
                WaterEffect.CurrentTechnique = WaterEffect.Techniques["Water"];
                WaterEffect.Parameters["CubeMapTexture"].SetValue(SkyTexture);
            }

            WaterEffect.Parameters["BumpTexture"].SetValue(WaterNormalTexture);

            Matrix WorldMatrix = Matrix.Identity;
            WaterEffect.Parameters["WorldMatrix"].SetValue(WorldMatrix);
            WaterEffect.Parameters["ViewMatrix"].SetValue(ViewMatrix);
            WaterEffect.Parameters["ProjectionMatrix"].SetValue(ProjectionMatrix);

            WaterEffect.Parameters["LightDirection"].SetValue(SceneLight.Direction);
            WaterEffect.Parameters["sky_color"].SetValue(SceneLight.AmbientColor);
            WaterEffect.Parameters["water_color"].SetValue(SceneLight.AmbientColor);
            WaterEffect.Parameters["AmbientPower"].SetValue(SceneLight.AmbientPower);
            WaterEffect.Parameters["Time"].SetValue((float)(gameTime.TotalGameTime.TotalMilliseconds * .000001f));

            WaterEffect.Begin();
            foreach (EffectPass pass in WaterEffect.CurrentTechnique.Passes)
            {
                pass.Begin();

                Device.VertexDeclaration = new VertexDeclaration(Device, VertexPositionTexture.VertexElements);
                Device.DrawUserPrimitives(PrimitiveType.TriangleList, waterVertices, 0, 2);

                pass.End();
            }
            WaterEffect.End();
        }

        public void SetWaterColor(Vector3 newColor)
        {
            WaterColor = newColor;
        }

        public bool IsUnderWater(Vector3 Position)
        {
            if (Position.Z < Elevation)
                return true;
            else
                return false;
        }

        private void DrawRefractionMap(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            Vector4 planeCoefficients = new Vector4(ReflectNormalDirection, Elevation);

            Matrix camMatrix = ViewMatrix * ProjectionMatrix;
            Matrix invCamMatrix = Matrix.Invert(camMatrix);
            invCamMatrix = Matrix.Transpose(invCamMatrix);

            planeCoefficients = Vector4.Transform(planeCoefficients, invCamMatrix);
            Plane RefractionClipPlane = new Plane(planeCoefficients);

            Device.ClipPlanes[0].Plane = RefractionClipPlane;
            Device.ClipPlanes[0].IsEnabled = true;

            Device.SetRenderTarget(0, RefractionRenderTarg);
            Device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.CornflowerBlue, 1.0f, 0);

            // Anything in this section will have refraction in water
            if (SceneTerrain != null)
                SceneTerrain.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCam);

            if (game != null)
                game.DrawAllEntities(gameTime, ref ViewMatrix, false, Elevation);
            
            //Device.ResolveRenderTarget(0);
			//Device.Re
			Device.SetRenderTarget( 0, null );
			RefractionMap = RefractionRenderTarg.GetTexture();
            
            Device.ClipPlanes[0].IsEnabled = false;

            //RefractionMap.Save("refractionmap.jpg", ImageFileFormat.Jpg);
        }

        private void DrawReflectionMap(GameTime gameTime, ref Matrix ViewMatrix, ref Matrix ProjectionMatrix, Light SceneLight, Camera CurrentCam)
        {
            Vector3 reflectPos = CurrentCam.GetPosition();
            reflectPos.Z = Elevation - (reflectPos.Z - Elevation);      // Move camera under the water

            Vector3 reflectForward = CurrentCam.ForwardVector;
            reflectForward.Z *= -1;

            ReflectionViewMatrix = Matrix.CreateLookAt(reflectPos, reflectPos + reflectForward, CurrentCam.UpVector);

            Vector4 PlaneCoefficients = new Vector4(ReflectNormalDirection, -Elevation);

            Matrix camMatrix = ReflectionViewMatrix * ProjectionMatrix;
            Matrix invCamMatrix = Matrix.Invert(camMatrix);
            invCamMatrix = Matrix.Transpose(invCamMatrix);

            PlaneCoefficients = Vector4.Transform(PlaneCoefficients, invCamMatrix);
            Plane ReflectionClipPlane = new Plane(PlaneCoefficients);

            Device.ClipPlanes[0].Plane = ReflectionClipPlane;
            Device.ClipPlanes[0].IsEnabled = true;

            Device.SetRenderTarget(0, ReflectionRenderTarg);
            Device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);
            
            // Anything in this section will have reflection in water
            if (SceneTerrain != null)
                SceneTerrain.Draw(gameTime, ref ReflectionViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCam);
            
            if (SceneSky != null)
                SceneSky.Draw(gameTime, ref ReflectionViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCam);

            if (SceneWeather != null)
                SceneWeather.Draw(gameTime, ref ReflectionViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCam);

            if (game != null)
                game.DrawAllEntities(gameTime, ref ReflectionViewMatrix, true, Elevation);          
            
            //Device.ResolveRenderTarget(0);
			Device.SetRenderTarget( 0, null );
			ReflectionMap = ReflectionRenderTarg.GetTexture();
            
            Device.ClipPlanes[0].IsEnabled = false;

            //ReflectionMap.Save("reflectionmap.jpg", ImageFileFormat.Jpg);
        }
        #endregion
    }
}
