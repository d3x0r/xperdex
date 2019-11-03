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
    public class Sphere : DynamicEntity
    {
        #region Properties
        #endregion

        #region Fields
        float Radius = 0f;
        #endregion

        #region Initialization
        public Sphere(GraphicsDevice device, ContentManager content, TestsMain game)
             : base(device, content, game)
        {

        }

        public override void Initialize(Vector3 position, Vector3 rotation, string ModelPath, string ModelName)
        {
            base.Initialize(position, rotation, ModelPath, ModelName);

            for (int i = 0; i < BoneTransforms.Length; i++)
            {
                BoneTransforms[i] = Matrix.Identity;
            }

            // Temporary
            BoundingSphere = new BoundingSphere(Position, Model.Meshes[0].BoundingSphere.Radius);
            Radius = BoundingSphere.Radius;
        }
        #endregion

        #region Methods
        public override void ProcessGroundCollision(GameTime gameTime)
        {
            // Only check collision with terrain if this entity is in 
            // the x,y bounds of the heightmap
            if (game.sceneTerrain != null && game.sceneTerrain.IsAboveTerrain(this.Position.X, this.Position.Y))
            {
                float TerrainHeight = game.sceneTerrain.GetTerrainHeight(this.Position.X, this.Position.Y);
                Vector3 TerrainNormal = game.sceneTerrain.GetNormal(this.Position.X, this.Position.Y);

                // Check if player has hit or is touching the ground
                if ( (this.Position.Z - Radius) <= TerrainHeight)
                {
                    this.Position.Z = (TerrainHeight + Radius);  // Sticks sphere back above ground

                    // Process bouncing of entity
                    VelocityVector = Physics.ProcessBounce(VelocityVector, Elasticity, TerrainNormal);

                    // Process friction of item to ground
                    VelocityVector = Physics.ProcessFriction(gameTime, VelocityVector, Roughness);

                    // Process wind effects, taking into account friction
                    VelocityVector = Physics.ProcessWind(gameTime, VelocityVector, Mass, AirViscosity, Roughness);

                    // Rolling is currently buggy, and should be left off until fixed
                    //VelocityVector = Physics.ProcessRoll(gameTime, VelocityVector, TerrainNormal);
                }
                else
                    // Process wind effects
                    VelocityVector = Physics.ProcessWind(gameTime, VelocityVector, Mass, AirViscosity);
            }
            else
                // Process wind effects even if the entity is not above terrain.
                VelocityVector = Physics.ProcessWind(gameTime, VelocityVector, Mass, AirViscosity);
        }

        public override void SetScale(float scale)
        {
            if (scale < 0)
                scale = 0;

            this.Scale = scale;

            BoundingSphere.Radius = Model.Meshes[0].BoundingSphere.Radius * Scale;
            Radius = BoundingSphere.Radius;
        }

        public void SetVelocityVector(Vector3 velocity)
        {
            this.VelocityVector = velocity;
        }
        #endregion
    }
}
