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
	public abstract class MyCamera : Camera
	{
		public Vector3 Position
		{
			get
			{
				return base.Position;
			}
			set
			{
				base.Position = value;

			}
		}
	}

    public class FreeCamera : MyCamera
    {
        #region Properties
        #endregion

        #region Fields
        
        #endregion

        #region Initialization

        public FreeCamera( MyBoundingBox box, float AspectRatio)
        {
			this.box = box;
            //this.game = game;
            this.AspectRatio = AspectRatio;

            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                   AspectRatio, 1f, 4000f);
        }
        #endregion

        #region Methods
        public override void MoveCam(float PitchDelta, float TurnDelta, float LeftRightDelta, float FrontBackDelta)
        {
            Pitch += PitchDelta;
            Turn += TurnDelta;

            Position += RightVector * FrontBackDelta;
            Position += ForwardVector * LeftRightDelta;
        }

        public override void Update(GameTime gameTime)
        {
            RightVector = Vector3.Cross(UpVector, ForwardVector);
            FlatFront = Vector3.Cross(RightVector, UpVector);

            PitchMatrix = Matrix.CreateFromAxisAngle(RightVector, Pitch);
            TurnMatrix = Matrix.CreateFromAxisAngle(UpVector, Turn);

            TiltedFront = Vector3.TransformNormal(ForwardVector, PitchMatrix * TurnMatrix);

            // Check angle so we cant flip over
            if (Vector3.Dot(TiltedFront, FlatFront) > 0.001f)
            {
                ForwardVector = Vector3.Normalize(TiltedFront);
            }

            // Compute view matrix
            ViewMatrix = Matrix.CreateLookAt(Position, Position + ForwardVector, UpVector);

            // Reset pitch and turn values so the next input loop can start fresh
            Pitch = 0.0f;
            Turn = 0.0f;
        }

        public override void ZoomIn()
        {
            if (ZoomLevel < 32)
            {
                ZoomLevel *= 2;
            }
            else
                ZoomLevel = 1;
        }

        public override void ZoomOut()
        {
            if (ZoomLevel > 2)
            {
                ZoomLevel /= 2;
            }
        }

        public override float GetViewingAngle()
        {
            return (CurrentViewAngle / ZoomLevel);      // Default viewing angle of 90 degrees
        }
        #endregion
    }
}
