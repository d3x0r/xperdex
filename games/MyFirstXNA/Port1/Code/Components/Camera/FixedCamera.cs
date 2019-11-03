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
    public class FixedCamera : MyCamera
    {
        #region Properties
        #endregion

        #region Fields
        Vector3 PositionOffset = Vector3.Zero;
        Vector3 ForwardOffset = Vector3.Zero;

        float ShakeValue = 0f;
        #endregion

        #region Initialization
		public FixedCamera( MyBoundingBox box, float AspectRatio )
        {
            //this.game = game;
			this.box = box;
            this.AspectRatio = AspectRatio;
            PositionOffset = new Vector3(0, -10.0f, 2.5f);

            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                   AspectRatio, 1f, 4000f);
        }

        public FixedCamera(BaseEntity cameraTarget)
        {
            Target = cameraTarget;
            PositionOffset = new Vector3(0, -10.0f, 2.5f);
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            // A fixed camera may lose its target, for instance, if the target
            // is removed from the game, this 'null' check should keep the
            // game from crashing in such a case.
            if (Target != null)
            {
                Vector3 ForwardDistance = Vector3.Zero;

                // Position camera in space
                Position = PositionOffset;

                // Position camera should look at
                ForwardDistance = new Vector3(ShakeValue + ForwardOffset.X, ForwardOffset.Y, ForwardOffset.Z);
                ForwardDistance = Vector3.Transform(ForwardDistance, Target.RotationMatrix);

                // Keeps camera behind its target
                Position = Vector3.Transform(Position, Target.RotationMatrix);

                // Keeps camera "attached" to its target
                Position = Vector3.Transform(Position, Matrix.CreateTranslation(Target.position + ForwardDistance));

                ViewMatrix = Matrix.CreateLookAt(Position, Target.position + ForwardDistance, UpVector);
                
            }
        }

        public void SetCameraTarget(BaseEntity cameraTarget)
        {
            Target = cameraTarget;
        }

        public void SetPositionOffset(Vector3 newPosition)
        {
            PositionOffset = newPosition;
        }

        public void SetPositionOffset(float x, float y, float z)
        {
            PositionOffset = new Vector3(x, y, z);
        }

        public void SetForwardOffset(Vector3 newForwardOffset)
        {
            ForwardOffset = newForwardOffset;
        }

        public void SetForwardOffset(float x, float y, float z)
        {
            ForwardOffset = new Vector3(x, y, z);
        }

        public override void ZoomIn()
        {
            // No zoom for fixed cameras
        }

        public override void ZoomOut()
        {
            // No zoom for fixed cameras
        }
        #endregion
    }
}
