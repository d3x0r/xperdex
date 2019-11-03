#region USING STATEMENTS
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
#endregion

namespace TestsForFun
{
    /// <summary>
    /// This class performs a few simple physics calculations
    /// that can be used in 3d programs.
    /// This class is setup as a singleton. Singletons are special
    /// because they are instanciated as soon as a single line makes
    /// a reference to one. Only one instance of them can be made, 
    /// which is where the word 'Single' comes into the name. This
    /// allows any place in the class full access to this singleton
    /// simply be creating a reference to the instance. Singleton
    /// classes are good for 'programming tools' so to speak. This
    /// physics class simply takes some input, and returns the changes.
    /// Other than the physics settings like gravity it doesn't hold
    /// any info important to the program itself, this way the other
    /// objects in the game aren't dependant upon needing different
    /// instances of it.
    /// </summary>
    public sealed class Physics
    {
        #region Properties
        public const float MeterToWorldScale = .01f;
        #endregion

        #region Fields

        static readonly Physics instance = new Physics();

        // Gives access outside of class
        public static Physics Instance
        {
            get { return instance; }
        }

        MathUtils MathUtils = MathUtils.Instance;

        public Vector3 GravityVector = new Vector3(0, 0, 0);

        public Vector3 WindVector = new Vector3(0, 0, 0);

        #endregion

        #region Initialization
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Physics()
        {
        }

        Physics()
        {
        }
        #endregion

        #region Methods
        public void SetGravityVector(Vector3 gravityVect)
        {
            GravityVector = gravityVect * MeterToWorldScale;
        }

        public void SetGravityVector(float x, float y, float z)
        {
            GravityVector = new Vector3(x, y, z) * MeterToWorldScale;
        }

        /// <summary>
        /// Sets direction and intensity of the wind. The higher
        /// this value is, the more intense the wind is. The last
        /// value in this vector is the verticle component because
        /// our game is set up with a world 'up' axis of Z. Most
        /// games will not have a vertical wind so this will most
        /// likely stay at zero.
        /// </summary>
        /// <param name="windVect">Wind speed magnitude vector</param>
        public void SetWindVector(Vector3 windVect)
        {
            WindVector = windVect * MeterToWorldScale;
        }

        /// <summary>
        /// Sets direction and intensity of the wind. The higher
        /// this value is, the more intense the wind is. The last
        /// value in this vector is the verticle component because
        /// our game is set up with a world 'up' axis of Z. Most
        /// games will not have a vertical wind so this will most
        /// likely stay at zero.
        /// </summary>
        /// <param name="x">Wind speed magnitude along the X-axis</param>
        /// <param name="y">Wind speed magnitude along the Y-axis</param>
        /// <param name="z">Wind speed magnitude along the Z-axis</param>
        public void SetWindVector(float x, float y, float z)
        {
            WindVector = new Vector3(x, y, z) * MeterToWorldScale;
        }

        public Vector3 ProcessWindResistance(GameTime gameTime, Vector3 CurrentVelocity, float AirViscosity)
        {
            // .001f is used because milliseconds are used instead of seconds
            CurrentVelocity *= (1 - gameTime.ElapsedGameTime.Milliseconds * AirViscosity * .001f);

            return CurrentVelocity;
        }

        public Vector3 ProcessFriction(GameTime gameTime, Vector3 CurrentVelocity, float EntityRoughness)
        {
            float DeltaValue = MathHelper.Clamp((gameTime.ElapsedGameTime.Milliseconds * EntityRoughness * .001f), 0, 1);
            CurrentVelocity *= (1 - DeltaValue);

            return CurrentVelocity;
        }

        /// <summary>
        /// Applies gravity to an object
        /// </summary>
        /// <param name="gameTime">XNA built-in timing</param>
        /// <param name="CurrentVelocity">Velocity vector of object</param>
        /// <param name="Mass">Mass of object</param>
        /// <param name="AirViscosity">Air viscosity of object</param>
        /// <returns>Returns new velocity vector</returns>
        public Vector3 ProcessGravity(GameTime gameTime, Vector3 CurrentVelocity, float Mass, float AirViscosity)
        {
            if (Mass > 0.0f)
            {
                // Gravity Vector is in meters per second
                // .0001f converts that to millimeters per second
                // Elapsed time is in milliseconds instead of seconds to match millimeters
                CurrentVelocity += GravityVector * .001f * gameTime.ElapsedGameTime.Milliseconds
                                                         * gameTime.ElapsedGameTime.Milliseconds
                                                         * (1 - AirViscosity);
            }

            return CurrentVelocity;
        }

        public Vector3 ProcessWind(GameTime gameTime, Vector3 CurrentVelocity, float Mass, float AirViscosity)
        {
            Vector3 DeltaValue = Vector3.Zero;

            // If mass is anything above 1
            if (Mass >= 1.0f)
            {
                // We determine the change in movement
                DeltaValue = (WindVector * .001f * gameTime.ElapsedGameTime.Milliseconds * (1 + AirViscosity)) / Mass;

                // If the change is negligable then just consider it zero.
                if (DeltaValue.Length() < 0.0001f)
                    DeltaValue = Vector3.Zero;

                // Apply changes
                CurrentVelocity += DeltaValue;
            }
            else      // Values between 0 and 1 are treated as if they were 1
            {
                DeltaValue = (WindVector * .001f * gameTime.ElapsedGameTime.Milliseconds * (1 + AirViscosity));

                if (DeltaValue.Length() < 0.0001f)
                    DeltaValue = Vector3.Zero;

                CurrentVelocity += DeltaValue;
            }

            return CurrentVelocity;
        }

        /// <summary>
        /// Processes wind while object is touching the ground
        /// </summary>
        /// <param name="gameTime">XNA built-in timing</param>
        /// <param name="CurrentVelocity">Velocity Vector to modify</param>
        /// <param name="Mass">Mass of object</param>
        /// <param name="AirViscosity">Air viscosity of object</param>
        /// <param name="EntityRoughness">Roughness of object (used for friction)</param>
        /// <returns>New velocity vector</returns>
        public Vector3 ProcessWind(GameTime gameTime, Vector3 CurrentVelocity, float Mass, float AirViscosity, float EntityRoughness)
        {
            Vector3 DeltaValue = Vector3.Zero;

            // If mass is anything above 1
            if (Mass >= 1.0f)
            {
                // We determine the change in movement
                DeltaValue = (WindVector * .001f * gameTime.ElapsedGameTime.Milliseconds
                                 * (1 - AirViscosity) * (1 - EntityRoughness)) / Mass;

                // If the change is negligable then just consider it zero.
                if (DeltaValue.Length() < 0.0001f)
                    DeltaValue = Vector3.Zero;

                // Apply changes
                CurrentVelocity += DeltaValue;
            }
            else    // Values between 0 and 1 are treated as if they were 1
            {
                DeltaValue = (WindVector * .001f * gameTime.ElapsedGameTime.Milliseconds
                                 * (1 - AirViscosity) * (1 - EntityRoughness));

                if (DeltaValue.Length() < 0.0001f)
                    DeltaValue = Vector3.Zero;

                CurrentVelocity += DeltaValue;
            }

            return CurrentVelocity;
        }

        /// <summary>
        /// Returns velocity of deflection
        /// </summary>
        /// <param name="CurrentVelocity">Velocity vector if item to be bounced</param>
        /// <param name="Elasticity">Elasticity of item to be bounced</param>
        /// <param name="CollisionNormal">Normal vector of plane the item is bouncing off of</param>
        /// <returns>Velocity vector of deflection</returns>
        public Vector3 ProcessBounce(Vector3 CurrentVelocity, float Elasticity, Vector3 CollisionNormal)
        {
            Vector3 newDirection = Elasticity * (-2 * Vector3.Dot(CurrentVelocity, CollisionNormal) * CollisionNormal + CurrentVelocity);

            return newDirection;
        }

        // Currently only set to work with spheres.
        public bool CheckEntityCollision(ref DynamicEntity FirstEntity, ref DynamicEntity SecondEntity)
        {
            // This will only work properly on a sphere...
            if (FirstEntity.BoundingSphere.Intersects(SecondEntity.BoundingSphere))
            {
                return true;
            }

            return false;
        }

        public void ProcessEntityCollision(GameTime gameTime, ref DynamicEntity FirstEntity, ref DynamicEntity SecondEntity)
        {
            Vector3 FirstToSecondVect = MathUtils.VectorFirstToSecond(FirstEntity.position, SecondEntity.position);
            FirstToSecondVect.Normalize();

            float a1 = Vector3.Dot(FirstEntity.VelocityVector, FirstToSecondVect);
            float a2 = Vector3.Dot(SecondEntity.VelocityVector, FirstToSecondVect);

            float MassTotal = FirstEntity.mass + SecondEntity.mass;

            float optimizedP = (2.0f * (a1 - a2)) / MassTotal;

            Vector3 FirstDirection = FirstEntity.VelocityVector - optimizedP * SecondEntity.mass * FirstToSecondVect;
            Vector3 SecondDirection = SecondEntity.VelocityVector + optimizedP * FirstEntity.mass * FirstToSecondVect;

            FirstEntity.VelocityVector = FirstDirection * FirstEntity.elasticity;
            SecondEntity.VelocityVector = SecondDirection * SecondEntity.elasticity;

            maintainMinimumDistance(ref FirstEntity, ref SecondEntity);
        }

        public void maintainMinimumDistance(ref DynamicEntity FirstEntity, ref DynamicEntity SecondEntity)
        {
            float distanceToEntity = MathUtils.VectorFirstToSecond(FirstEntity.position, SecondEntity.position).Length();

            float radiiSum = FirstEntity.BoundingSphere.Radius + SecondEntity.BoundingSphere.Radius;

            float MassTotal = FirstEntity.mass + SecondEntity.mass;

            if (distanceToEntity < radiiSum)
            {
                Vector3 newPos = MathUtils.VectorFirstToSecond(FirstEntity.position, SecondEntity.position) * (distanceToEntity - radiiSum) * (SecondEntity.mass / MassTotal);
                FirstEntity.SetPosition(FirstEntity.position + newPos);
                SecondEntity.SetPosition(SecondEntity.position - newPos);
            }
        }

        // Under construction, not in use
        public Vector3 ProcessRoll(GameTime gameTime, Vector3 CurrentVelocity, Vector3 CollisionNormal)
        {
            if (CurrentVelocity.Length() < .3f)
            {
                if (CollisionNormal.Z < .999f)
                    CurrentVelocity += CollisionNormal * .01f;// *(1 - CollisionNormal.Z);
            }

            return CurrentVelocity;
        }

        #endregion
    }
}
