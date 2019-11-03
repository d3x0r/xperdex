////////////////////////////////////////////////////////////////
// (C) 2006 Paul Bentley 
// This work is licenced under the Creative Commons Attribution 2.0 License.
//  To view a copy of this licence, visit 
//  http://creativecommons.org/licenses/by/2.0/uk/ 
//  or send a letter to 
//  Creative Commons, 
//  559 Nathan Abbott Way, 
//  Stanford, California 94305, USA.
////////////////////////////////////////////////////////////////


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

namespace CameraMovement
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Movement : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ContentManager content;

        private Matrix viewMatrix;
        private Matrix projectionMatrix;
        Vector3 cameraPosition = new Vector3(0, 5, 60); // Right handed system, +ve z goes into screen.  This places camera behind screen
        float cameraYaw = 0;
        float cameraPitch = 0;

        // The direction the camera points without rotation.
        Vector3 cameraReferenceVector = new Vector3(0, 0, -1); // Looking into screen

        // World transformation to use when displaying the star
        Matrix sceneWorldTransformation;


        bool windowActiveFlag = false;
        bool mouseCapturedFlag = false;
        // Previous mouse position
        int xMousePosPrev;
        int yMousePosPrev;

        float forwardSpeed = 2.0F;
        float strafeSpeed = 1.0F;

        // Information about the game window
        static int screenWidth;
        static int screenHeight;
        static float screenAspectRatio;
        // Field of view of the camera in radians (pi/4 is 45 degrees).
        static float cameraFOV;
        // Z value for near clip plane
        static float nartClipPlane = 5.0f;
        // Z value for far clip plane
        static float farClipPlane = 1000.0f;

        // Structures for vertices
        int vertexCount;
        VertexDeclaration vertexShaderDeclaration;
        VertexBuffer m_vertexBuffer;
        VertexPositionColor [] vertexArray;

        BasicEffect shaderEffect;

            
        public Movement()
        {
            graphics = new GraphicsDeviceManager(this);
            content = new ContentManager(Services);

            // Set event handlers for game activation.  These are used to ensure mouse is captured when window is brought into focus.
            // Note: When the mouse is captured, either alt-f4 to stop the program or alt-tab to deaactive game
            Activated += new EventHandler(GameActivated);
            Deactivated += new EventHandler(GameDeactivated);
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        /// <summary>
        /// Load your graphics content.  If loadAllContent is true, you should
        /// load content from both ResourceManagementMode pools.  Otherwise, just
        /// load ResourceManagementMode.Manual content.
        /// </summary>
        /// <param name="loadAllContent">Which type of content to load.</param>
        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
                InitialiseShader();
                InitialiseStar();
            }

            InitialiseCamera();

            // TODO: Load any ResourceManagementMode.Manual content
        }

        private void InitialiseCamera()
        {
            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;

            screenAspectRatio = (float)screenWidth / (float)screenHeight;

            cameraFOV = MathHelper.PiOver4;

            // Create a perspective matrix, using the field of view (in radians), the aspect ratio of the screen, and the near
            //  and far clip planes
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(cameraFOV, screenAspectRatio, nartClipPlane, farClipPlane);
        }

        void UpdateCamera()
        {
            // Copy the camera's reference vector.
            Vector3 cameraLookAtVector = cameraReferenceVector;

            // Create a vector pointing the direction the camera is facing.
            cameraLookAtVector = Vector3.Transform(cameraLookAtVector, Matrix.CreateRotationX(cameraPitch));
            cameraLookAtVector = Vector3.Transform(cameraLookAtVector, Matrix.CreateRotationY(cameraYaw));

            // Calculate the position the camera is looking at.
            cameraLookAtVector += cameraPosition;

            // Create a view matrix for the camera, using the camera position (the coordinates controlled by the keyboard) and
            //  a vector pointing in the direction the user has chosen (controlled by the mouse)
            // The third parameter is a vector which points up - this indicates the direction that "up" is in
            viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraLookAtVector, new Vector3(0.0f, 1.0f, 0.0f));
        }



        /// <summary>
        /// Unload your graphics content.  If unloadAllContent is true, you should
        /// unload content from both ResourceManagementMode pools.  Otherwise, just
        /// unload ResourceManagementMode.Manual content.  Manual content will get
        /// Disposed by the GraphicsDevice during a Reset.
        /// </summary>
        /// <param name="unloadAllContent">Which type of content to unload.</param>
        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            if (unloadAllContent == true)
            {
                content.Unload();
            }
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the default game to exit on Xbox 360 and Windows
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Only consider input if window has the focus
            if (windowActiveFlag)
            {
                MouseInput();
                KeyboardInput();
            }
            UpdateCamera();

            base.Update(gameTime);
        }

        private void MouseInput()
        {
            if (!mouseCapturedFlag && MouseInWindow())
            {
                mouseCapturedFlag = true;
                CentreMouse();
                return;
            }
            // Only perform mouse-input if we currently have the focus
            if (mouseCapturedFlag)
            {
                // Retrieve the current state of the mouse (position and buttons)
                MouseState mouseState = Mouse.GetState();
                // Calculate change in mouse position
                int dx = xMousePosPrev - mouseState.X;
                int dy = yMousePosPrev - mouseState.Y;

                cameraYaw += dx / 100.0F;
                // Clamp yaw angle to -180 degrees to +180 degrees (with wrap-around)
                if (cameraYaw <= -Math.PI)
                {
                    cameraYaw += (float)(2 * Math.PI);
                }
                if (cameraYaw > Math.PI)
                {
                    cameraYaw -= (float)(2 * Math.PI);
                }
                cameraPitch -= dy / 150.0F;

                // Clamp pitch angle to -90 degrees to +90 degrees (with no wrap-around)
                if (cameraPitch > Math.PI / 2)
                {
                    cameraPitch = (float)(Math.PI / 2);
                }
                else if (cameraPitch < -Math.PI / 2)
                {
                    cameraPitch = (float)(-Math.PI / 2);
                }
                CentreMouse();
            }
        }

        private void KeyboardInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            float forwardVelocity = 0.0F;

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                forwardVelocity += forwardSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                forwardVelocity -= forwardSpeed;
            }
            double m_dlSin = Math.Sin((double)cameraYaw);
            double m_dlCos = Math.Cos((double)cameraYaw);

            cameraPosition.X -= (float)(forwardVelocity * m_dlSin);
            cameraPosition.Z -= (float)(forwardVelocity * m_dlCos);

            float strafeVelocity=0.0F;
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                strafeVelocity -= strafeSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                strafeVelocity += strafeSpeed;
            }

            cameraPosition.X += (float)(strafeVelocity * m_dlCos);
            cameraPosition.Z -= (float)(strafeVelocity * m_dlSin);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            
            DrawPoints();
            
            base.Draw(gameTime);
        }

        protected void DrawPoints()
        {
            graphics.GraphicsDevice.VertexDeclaration = vertexShaderDeclaration;
            graphics.GraphicsDevice.RenderState.PointSize = 10;
            

            shaderEffect.Begin(SaveStateMode.None);
            foreach (EffectPass pass in shaderEffect.CurrentTechnique.Passes)
            {
                pass.Begin();

                shaderEffect.World = sceneWorldTransformation;
                shaderEffect.View = viewMatrix;
                shaderEffect.Projection = projectionMatrix;

                graphics.GraphicsDevice.Vertices[0].SetSource(m_vertexBuffer, 0, VertexPositionColor.SizeInBytes);
                graphics.GraphicsDevice.DrawPrimitives(PrimitiveType.PointList, 0, vertexCount);

                pass.End();
            }
            shaderEffect.End();

        }

        /// <summary>
        /// Initialise the shader with basic lighting
        /// </summary>
        protected void InitialiseShader()
        {
            shaderEffect = new BasicEffect(graphics.GraphicsDevice, null);
            shaderEffect.Alpha = 1.0F;
            shaderEffect.DiffuseColor = new Vector3(1.0f, 0.7f, 0.7f);
            shaderEffect.SpecularColor = new Vector3(0.75f, 0.75f, 0.75f);
            shaderEffect.SpecularPower = 10.0f;
            shaderEffect.AmbientLightColor = new Vector3(0.75f, 0.75f, 0.75f);

            shaderEffect.DirectionalLight0.Enabled = true;
            shaderEffect.DirectionalLight0.DiffuseColor = Vector3.One;
            shaderEffect.DirectionalLight0.Direction = Vector3.Normalize(new Vector3(1.0f, -1.0f, -1.0f));
            shaderEffect.DirectionalLight0.SpecularColor = Vector3.One;

            shaderEffect.LightingEnabled = true;
        }



        /// <summary>
        /// Initialise all the necessary structures to display the star
        /// </summary>
        protected void InitialiseStar()
        {
            vertexCount = 20;
            vertexShaderDeclaration = new VertexDeclaration(graphics.GraphicsDevice, VertexPositionColor.VertexElements);
            m_vertexBuffer = new VertexBuffer(graphics.GraphicsDevice, typeof(VertexPositionColor), vertexCount, ResourceUsage.WriteOnly, ResourceManagementMode.Automatic);
            vertexArray = new VertexPositionColor[vertexCount];

            // Star is made of 5 outer points, and 5 inner points
            double starRadius = 20.0;
            double innerRadius = starRadius * 0.35;

            int vertexCounter = 0;
            for (double vertexAngle = 0.0; vertexAngle < Math.PI * 2; vertexAngle += Math.PI * 2 / 5)
            {
                vertexArray[vertexCounter].Position = new Vector3((float)(starRadius*Math.Sin(vertexAngle)), (float)(starRadius*Math.Cos(vertexAngle)), 0.0F);
                vertexArray[vertexCounter + 5].Position = new Vector3((float)(-innerRadius * Math.Sin(vertexAngle)), (float)(-innerRadius * Math.Cos(vertexAngle)), 0.0F);
                vertexCounter++;
            }

            // Create a path leading to the star
            float pathZ = 60.0F;
            float pathY = vertexArray[2].Position.Y;
            for (int floorVertexCounter = 10; floorVertexCounter < 20; floorVertexCounter+=2)
            {
                vertexArray[floorVertexCounter].Position = new Vector3((float)(-starRadius / 2), pathY, pathZ);
                vertexArray[floorVertexCounter + 1].Position = new Vector3((float)(starRadius / 2), pathY, pathZ);

                pathZ -= 12.0F;
            }

            m_vertexBuffer.SetData<VertexPositionColor>(vertexArray);

            sceneWorldTransformation=Matrix.CreateTranslation(new Vector3(0.0F,0.0F,-30.0F));
        }

        void GameDeactivated(object sender, EventArgs e)
        {
            windowActiveFlag = false;
            mouseCapturedFlag = false;
        }

        void GameActivated(object sender, EventArgs e)
        {
            windowActiveFlag = true;
            if (MouseInWindow())
            {
                mouseCapturedFlag = true;
                CentreMouse();
            }
        }

        bool MouseInWindow()
        {
            MouseState mouseSTate = Mouse.GetState();

            if (mouseSTate.X > 0 && mouseSTate.X <= Window.ClientBounds.Width &&
                mouseSTate.Y > 0 && mouseSTate.Y <= Window.ClientBounds.Height)
            {
                return true;
            }
            return false;
        }

        void CentreMouse()
        {
            xMousePosPrev = graphics.GraphicsDevice.Viewport.Width / 2;
            yMousePosPrev = graphics.GraphicsDevice.Viewport.Height / 2;
            Mouse.SetPosition(xMousePosPrev, yMousePosPrev);
        }
    }
}
