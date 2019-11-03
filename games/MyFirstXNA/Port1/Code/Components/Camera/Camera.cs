#region Using statements
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;
#endregion

namespace TestsForFun
{

	public class MyBoundingBox
	{
		public BoundingBox Bounds;
	};

    public abstract class Camera : Component
    {
        #region Properties
        #endregion

        #region Fields
		protected MyBoundingBox box;
        //protected TestsMain game;

        protected Vector3 Position = new Vector3(200, 0, 175);        // Starting position of camera
        public Vector3 ForwardVector = new Vector3(-.5f, .5f, -.3f);      // Starting viewing angle of camera
        protected Vector3 FlatFront = Vector3.Zero;
        protected Vector3 TiltedFront = Vector3.Zero;
        public Vector3 RightVector = new Vector3(1, 0, 0);
        public Vector3 UpVector = new Vector3(0, 0, 1);
        protected Matrix PitchMatrix = Matrix.Identity;
        protected Matrix TurnMatrix = Matrix.Identity;

        protected float Pitch = 0.0f;
        protected float Turn = 0.0f;

        public Matrix ViewMatrix;
        public Matrix ProjectionMatrix;
        public float AspectRatio;

        protected float CurrentViewAngle = MathHelper.PiOver4;

        public BaseEntity target
        {
            get { return Target; }
        }
        protected BaseEntity Target = null;

        public Vector3 TargetPosition;

        public int zoomLevel
        {
            get { return ZoomLevel; }
        }
        protected int ZoomLevel = 1;      // 1x zoom by default

        public float Near = 1f;
        public float Far = 2000.0f;
        public float FarMax = 3000.0f;
        public float Fov = MathHelper.ToRadians(45.0f);

        #endregion

        #region Initialization

        public Camera()
        {            
        }

        #endregion

        #region Methods
        public void UpdateTargetPosition()
        {
            if (target == null)
                TargetPosition = Vector3.Zero;
            else
                TargetPosition = target.position;
        }

        public virtual void MoveCam(float PitchDelta, float TurnDelta, float LeftRightDelta, float FrontBackDelta)
        {
            // Not abstract because some cameras do not have a MoveCam function. The reason this
            // function is not placed into those specific classes is because the input class needs
            // to be able to use any type of camera, and still be able to make calls like MoveCam().
            // If input calls this function on a fixed camera, nothing happens. Still looking into
            // any ways that might be cleaner or more efficient than this one.
        }

        public virtual float GetViewingAngle()
        {
            return CurrentViewAngle;      // Default viewing angle of 90 degrees
        }

        public Vector3 GetPosition()
        {
            return Position;
        }

        public abstract void ZoomIn();

        public abstract void ZoomOut();

        protected virtual void AdjustCameraPlanes()
        {
            ViewMatrix = Matrix.CreateLookAt(Position, Target.position, UpVector);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(Fov, 1, Near, FarMax);

            // Find the most distant point of AABB
            float MaxZ = 0.0f;

            for (int i = 0; i < 8; i++)
            {
                // transform z coordinate with view matrix
				float fZ = box.Bounds.GetCorners()[i].X * ViewMatrix.M13 + box.Bounds.GetCorners()[i].Y *
                    ViewMatrix.M23 + box.Bounds.GetCorners()[i].Z * ViewMatrix.M33 + 1 * ViewMatrix.M43;

                // check if its largest
                if (fZ < MaxZ)
                {
                    MaxZ = fZ;
                }
            }

            // use largest Z coordinate as new far plane
            Far = (0 - MaxZ) + Near;
        }

        public void UpdateShadowing()
        {
            AdjustCameraPlanes();
        }
        #endregion
    }
}