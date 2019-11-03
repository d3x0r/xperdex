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
    public class Cursor
    {
        #region Properties
        #endregion

        #region Fields
        public Vector2 Position;

        GraphicsDevice Device;
        #endregion

        #region Initialization
        public Cursor(GraphicsDevice Device)
        {
            this.Device = Device;
        }
        #endregion

        #region Methods
        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            Position.X = mouseState.X;
            Position.Y = mouseState.Y;
        }

        // CalculateCursorRay Calculates a world space ray starting at the camera's
        // "eye" and pointing in the direction of the cursor. Viewport.Unproject is used
        // to accomplish this. see the accompanying documentation for more explanation
        // of the math behind this function.
        public Ray CalculateCursorRay(Matrix ViewMatrix, Matrix ProjectionMatrix, Viewport viewPort)
        {
            // create 2 positions in screenspace using the cursor position. 0 is as
            // close as possible to the camera, 1 is as far away as possible.
            Vector3 nearSource = new Vector3(Position, 0f);
            Vector3 farSource = new Vector3(Position, 1f);

            // use Viewport.Unproject to tell what those two screen space positions
            // would be in world space. we'll need the projection matrix and view
            // matrix, which we have saved as member variables. We also need a world
            // matrix, which can just be identity.
            Vector3 nearPoint = viewPort.Unproject(nearSource,
                ProjectionMatrix, ViewMatrix, Matrix.Identity);

            Vector3 farPoint = viewPort.Unproject(farSource,
                ProjectionMatrix, ViewMatrix, Matrix.Identity);

            // find the direction vector that goes from the nearPoint to the farPoint
            // and normalize it....
            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();

            // and then create a new ray using nearPoint as the source.
            return new Ray(nearPoint, direction);
        }
        #endregion
    }
}
