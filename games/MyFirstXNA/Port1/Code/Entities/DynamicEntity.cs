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
    public class DynamicEntity : BaseEntity
    {
        #region Properties
        #endregion

        #region Fields
        public Vector3 VelocityVector;

        public float elasticity
        {
            get { return Elasticity; }
        }
        protected float Elasticity = 0f;

        public float mass
        {
            get { return Mass; }
        }
        protected float Mass = 1f;

        /// <summary>
        /// Resistance to air flow, 0 = none, 1 = infinite.
        /// A feather for instance would have high resistance.
        /// A metal ball bearing would have very little resistance.
        /// A value of zero would be ok in an environment with no
        /// atmosphere, like space. A value of 1 would be unrealistic
        /// as the item is completely stopped by an air whatsoever.
        /// </summary>
        protected float AirViscosity = .2f;

        /// <summary>
        /// Friction. An item that is very smooth like a cube of 
        /// ice would easily slide across a surface and would have 
        /// a very low roughness value. An item like a cube wrapped 
        /// in sand paper might not slide much at all and would 
        /// have a very high value.
        /// </summary>
        protected float Roughness = 1f;

        // This should be used only for spheres....and is temporary...
        public BoundingSphere BoundingSphere;
        #endregion

        #region Initialization
        public DynamicEntity(GraphicsDevice device, ContentManager content, TestsMain game)
             : base(device, content, game)
        {

        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Temporary, bounding spheres work well only for spheres....
            BoundingSphere.Center = Position; 

            UpdatePhysics(gameTime);
        }

        public override void Initialize(Vector3 position, Vector3 rotation, string ModelPath, string modelName)
        {
            base.Initialize(position, rotation, ModelPath, modelName);

            // Temporary
            BoundingSphere = new BoundingSphere(Position, Model.Meshes[0].BoundingSphere.Radius);
        }

        public void UpdatePhysics(GameTime gameTime)
        {
            // This takes into effect any physics dealing with the terrain,
            // and also wind, which affects an entity differently depending upon
            // whether it is on the ground or not.
            ProcessGroundCollision(gameTime);

            // Process gravity effects
            VelocityVector = Physics.ProcessGravity(gameTime, VelocityVector, Mass, AirViscosity);

            // Process wind resistance, this creates 'terminal velocity'
            // effect that you see in environments that contain atmospheres.
            // Any game taking place in a vacuum, like space would not need
            // this line. This keeps an object from increasing speed infinitely.
            // For instance, if a person jumps out of an airplane, they don't speed
            // up all the way until they would hit the ground, their wind resistance
            // eventually cancels out gravity at 'terminal velocity'.
            VelocityVector = Physics.ProcessWindResistance(gameTime, VelocityVector, AirViscosity);

            // Take into account any changes in velocity and move the entity accordingly
            Position += VelocityVector;

            // If entity drops too far, mark it to be deleted from the scene
            if (Position.Z < TestsMain.LowestZ)
                MarkedForDeletion = true;
        }

        public virtual void ProcessGroundCollision(GameTime gameTime)
        {
            // Only check collision with terrain if this entity is in 
            // the x,y bounds of the heightmap
            if (game.sceneTerrain.IsAboveTerrain(this.Position.X, this.Position.Y))
            {
                float TerrainHeight = game.sceneTerrain.GetTerrainHeight(this.Position.X, this.Position.Y);
                Vector3 TerrainNormal = game.sceneTerrain.GetNormal(this.Position.X, this.Position.Y);

                // Check if player has hit or is touching the ground
                if (this.Position.Z <= TerrainHeight)
                {
                    this.Position.Z = TerrainHeight;  // Sticks entity back above ground

                    // Process bouncing of entity
                    VelocityVector = Physics.ProcessBounce(VelocityVector, Elasticity, TerrainNormal);

                    // Process friction of item to ground
                    VelocityVector = Physics.ProcessFriction(gameTime, VelocityVector, Roughness);

                    // Process wind effects, taking into account friction
                    VelocityVector = Physics.ProcessWind(gameTime, VelocityVector, Mass, AirViscosity, Roughness);
                }
                else
                    // Process wind effects
                    VelocityVector = Physics.ProcessWind(gameTime, VelocityVector, Mass, AirViscosity);
            }
            else
                // Process wind effects even if the entity is not above terrain.
                VelocityVector = Physics.ProcessWind(gameTime, VelocityVector, Mass, AirViscosity);
        }

        public void SetMass(float mass)
        {
            if (mass < 0)
                mass = 0;

            this.Mass = mass;
        }

        public void SetElasticity(float Elasticity)
        {
            if (Elasticity < 0)
                Elasticity = 0;

            this.Elasticity = Elasticity;
        }

        public void SetAirViscosity(float Viscosity)
        {
            if (Viscosity < 0)
                Viscosity = 0;

            this.AirViscosity = Viscosity;
        }

        public void SetRoughness(float Roughness)
        {
            if (Roughness < 0)
                Roughness = 0;

            this.Roughness = Roughness;
        }
        #endregion
    }
}
