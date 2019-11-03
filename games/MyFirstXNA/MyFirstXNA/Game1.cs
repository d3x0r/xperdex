using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using InputHandlers.Mouse;
using xperdex.classes;
using TestsForFun;

namespace MyFirstXNA
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{


		internal static MouseState last_event_state;
		internal static float last_event_state_Z;

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Viewport v;

		//Matrix translate = Matrix.CreateTranslation( 5.0F, 0.0F, 0.0F );


		class MyMouseState
		{

		}

		MouseHandler mh = MouseHandler.Instance;
		XNAMouse mouse;

	

		public Game1()
		{
			v = new Viewport();
			graphics = new GraphicsDeviceManager( this );
			//graphics.GraphicsDevice.DisplayMode
			//graphics.IsFullScreen = true;
			Content.RootDirectory = "Content";
			AspectRatio = 4.0f / 3.0f;
		}

		void mh_HandleLeftMouseClick( MouseState m )
		{
			Vector3 xwingPosition = new Vector3( 8, 1, -3 );
			Quaternion xwingRotation = Quaternion.Identity; 

			Matrix worldMatrix = Matrix.CreateScale( 0.0005f, 0.0005f, 0.0005f ) 
				* Matrix.CreateRotationY( MathHelper.Pi ) 
				* Matrix.CreateFromQuaternion( xwingRotation ) 
				* Matrix.CreateTranslation( xwingPosition );


			// behind and above the origin
			Vector3 campos = new Vector3( 0, 0.1f, 0.6f );

			// not entirely sure why... this isn't just a translation within the 
			// matrix of the position of the object we want to put the camera behind....
			// it's just one more point to translate... 
			campos = Vector3.Transform( campos, Matrix.CreateFromQuaternion( xwingRotation ) );
			campos += xwingPosition;


			Vector3 camup = new Vector3( 0, 1, 0 );
			camup = Vector3.Transform( camup, Matrix.CreateFromQuaternion( xwingRotation ) );
			Matrix viewMatrix = Matrix.CreateLookAt( campos, xwingPosition, camup );
			Matrix projectionMatrix = Matrix.CreatePerspectiveFieldOfView( MathHelper.PiOver4
				, graphics.GraphicsDevice.Viewport.AspectRatio
				, 0.2f, 500.0f );
			//graphics.GraphicsDevice.Projection
			//Projection = projectionMatrix;
			//this.P
		}


		void mh_HandleMouseMoving( MouseState m )
			{
				Game1.last_event_state = m;
				// yeah.. moving...
				Log.log( "move : " + m.X + " , " + m.Y );                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

				if( owns_mouse )
				{
					int xMousePosPrev = graphics.GraphicsDevice.Viewport.Width / 2;

					int yMousePosPrev = graphics.GraphicsDevice.Viewport.Height / 2;

					Mouse.SetPosition( xMousePosPrev, yMousePosPrev );

				}
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
			Activated += new EventHandler( Game1_Activated );
			Deactivated += new EventHandler( Game1_Deactivated );
			mh.HandleMouseMoving += new MouseHandler.DelHandleMouseMoving( mh_HandleMouseMoving );
			mh.HandleLeftMouseClick += new MouseHandler.DelHandleLeftMouseClick( mh_HandleLeftMouseClick );

			base.Initialize();
		}


		bool owns_mouse;

		void Game1_Deactivated( object sender, EventArgs e )
		{
			owns_mouse = false;
			//throw new NotImplementedException();
		}

		void Game1_Activated( object sender, EventArgs e )
		{
			owns_mouse = true;
			//throw new NotImplementedException();
		}


		// Set the 3D model to draw.
		//Model myModel;

		// The aspect ratio determines how to scale 3d to 2d projection.
		float AspectRatio;

		List<Component> ComponentList = new List<Component>();

		Terrain SceneTerrain;

		private MyBoundingBox mBox = new MyBoundingBox();

		public BoundingBox Bounds
		{
			get { return mBox.Bounds; }
		}


		private void LoadCameras()
		{
			FreeCamera = new FreeCamera( mBox, AspectRatio );      // Initialize the camera

			FixedCamera = new FixedCamera( mBox, AspectRatio );    // This camera cannot be used until an 
			// target entity is assigned to it.

			CurrentCamera = FreeCamera;
		}

		Input Input;

		private void LoadInput()
		{
			Input = new Input( GraphicsDevice );            // Initialize the input
			Input.SetupCamera( FreeCamera );      // Connect our input to the camera
			Input.SetAutoDraw( false );

			ComponentList.Add( Input );                // Add input to the component list      
		}

		private void LoadTerrain()
		{


			SceneTerrain = new Terrain( GraphicsDevice, Content );
			SceneTerrain.SetElevationStrength( 30 );                       // Changes elevation strength
			SceneTerrain.InitTerrainTextures( "./Textures/grass", "./Textures/rock", "./Textures/sand" );
			SceneTerrain.InitTerrainNormalsTextures( "./Textures/grassNormal", "./Textures/rockNormal", "./Textures/sandNormal" );

			SceneTerrain.Initialize( "./Images/Heightmaps/map2", "./Images/Terrainmaps/map1terrain", 25 );

			ComponentList.Add( SceneTerrain );
			//AddComponent( SceneTerrain );
		}
		List<BaseEntity> EntityList = new List<BaseEntity>();


		private void LoadEntities()
		{
		}

		private void LoadLight()
		{
			SceneLight = new SunLight( GraphicsDevice, Content );        // A default light is required for other components

			SceneLight.Direction = new Vector3( 1f, .5f, -.6f );          // Direction this light points
			SceneLight.AmbientColor = new Vector3( 0.3f, 0.3f, 0.3f );    // RGB values of our light
			SceneLight.SpecularColor = new Vector3( 0.2f, 0.2f, 0.2f );
			SceneLight.DiffuseColor = new Vector3( 1.0f, 1.0f, 1.0f );
			SceneLight.SpecularPower = 64;                              // Lower means more reflection
			SceneLight.AmbientPower = 0.6f;
			SceneLight.MinimumAmbient = 0.2f;
			SceneLight.EnableDayNight( 15 );                              // Let this sunlight rise and set every 30 seconds

			ComponentList.Add( SceneLight );
		}
		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			LoadCameras();
			LoadInput();
			LoadLight();
			LoadTerrain();

			LoadEntities();

			mouse = new XNAMouse( GraphicsDevice, "content/bitmap1.png" );
			ComponentList.Add( mouse );

			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch( GraphicsDevice );
			
			//ComponentList.Add( new MultiInstModel( Content, "Models\\p1_wedge" );
			//myModel = Content.Load<Model>( "Models\\cross1" );
			//myModel = Content.Load<Model>( "Models\\boxtex1" );

			ComponentList.Add( new MultiInstModel( Content, "Models\\marker1" ) );

			AspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

		
			//spriteBatch
			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}


		protected void UpdateInput()
		{

			// Get the game pad state.
			GamePadState currentState = GamePad.GetState( PlayerIndex.One );
			if( currentState.IsConnected )
			{
				// Rotate the model using the left thumbstick, and scale it down.
				modelRotation -= currentState.ThumbSticks.Left.X * 0.10f;

				// Create some velocity if the right trigger is down.
				Vector3 modelVelocityAdd = Vector3.Zero;

				// Find out what direction we should be thrusting, using rotation.
				modelVelocityAdd.X = -(float)Math.Sin( modelRotation );
				modelVelocityAdd.Z = -(float)Math.Cos( modelRotation );

				// Now scale our direction by how hard the trigger is down.
				modelVelocityAdd *= currentState.Triggers.Right;

				// Finally, add this vector to our velocity.
				modelVelocity += modelVelocityAdd;

				GamePad.SetVibration( PlayerIndex.One, currentState.Triggers.Right,
					currentState.Triggers.Right );


				// In case you get lost, press A to warp back to the center.
				if( currentState.Buttons.A == ButtonState.Pressed )
				{
					modelPosition = Vector3.Zero;
					modelVelocity = Vector3.Zero;
					modelRotation = 0.0f;
				}
			}
		}
		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update( GameTime gameTime )
		{
			CurrentCamera.Update( gameTime );

			foreach( Component thisComponent in ComponentList )
			{
				// Only update if this component is set for auto updating.
				if( thisComponent.autoUpdate )
					thisComponent.Update( gameTime );
			}


			// Allows the game to exit
			MouseHandler.Instance.Poll( Mouse.GetState(), gameTime );
			//KBHandler.Instance.Poll( Keyboard.GetState(), gameTime );

			if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed )
				this.Exit();


			// Get some input.
			UpdateInput();

			// Add velocity to the current position.
			modelPosition += modelVelocity;

			// Bleed off velocity over time.
			modelVelocity *= 0.95f;


			// TODO: Add your update logic here

			base.Update( gameTime );
		}

		// Set the position of the model in world space, and set the rotation.
		Vector3 modelPosition = Vector3.Zero;
		Vector3 modelVelocity = Vector3.Zero;
		float modelRotation = 0.0f;

		// Set the position of the camera in world space, for our view matrix.
		Vector3 cameraPosition = new Vector3( 0.0f, 50.0f, 5000.0f );

		//Matrix ViewMatrix;
		//Matrix ProjectionMatrix;

		FreeCamera FreeCamera;
		FixedCamera FixedCamera;
		static internal MyCamera CurrentCamera;           // Component

		// A little sunlight for our scene
		SunLight SceneLight;            // Component

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw( GameTime gameTime )
		{
			GraphicsDevice.Clear( Color.CornflowerBlue );
			GraphicsDevice.RenderState.DepthBufferEnable = true;
			GraphicsDevice.RenderState.CullMode = CullMode.CullCounterClockwiseFace;

			// Get the ViewMatrix and ProjectionMatrix from this scene's camera
			//ViewMatrix = CurrentCamera.ViewMatrix;
			//ProjectionMatrix = CurrentCamera.ProjectionMatrix;
			foreach( Component thisComponent in ComponentList )
			{
				if( thisComponent.autoDraw )
					thisComponent.Draw( gameTime
						, ref CurrentCamera.ViewMatrix
						, ref CurrentCamera.ProjectionMatrix
						, SceneLight
						, CurrentCamera );
			}
			//return;
			// TODO: Add your drawing code here



			// I don't want to draw here, I want to create content!

			// Copy any parent transforms.
			//Matrix[] transforms = new Matrix[myModel.Bones.Count];
			//myModel.CopyAbsoluteBoneTransformsTo( transforms );

			// Draw the model. A model can have multiple meshes, so loop.
			//foreach( ModelMesh mesh in myModel.Meshes )
			//{
			//    // This is where the mesh orientation is set, as well as our camera and projection.
			//    foreach( BasicEffect effect in mesh.Effects )
			//    {
			//        effect.EnableDefaultLighting();
			//        effect.World = transforms[mesh.ParentBone.Index] 
			//            * Matrix.CreateRotationY( modelRotation )
			//            * Matrix.CreateTranslation( modelPosition )
			//            /** Matrix.CreateScale( 0.1f )*/;

			//        effect.View = CurrentCamera.ViewMatrix;// Matrix.CreateLookAt( cameraPosition, Vector3.Zero, Vector3.Up );
			//        effect.Projection = CurrentCamera.ProjectionMatrix;// Matrix.CreatePerspectiveFieldOfView( MathHelper.ToRadians( 45.0f ),

			//        //AspectRatio, 1.0f, 10000.0f );
			//        effect.DirectionalLight0.Direction = SceneLight.Direction;
			//        effect.DirectionalLight1.Direction = Vector3.Transform( SceneLight.Direction, Matrix.CreateRotationY( MathHelper.PiOver2 ) );
			//        effect.DirectionalLight2.Direction = -SceneLight.Direction;
			//        effect.AmbientLightColor = SceneLight.AmbientColor * SceneLight.AmbientPower * 0;
			//        effect.DiffuseColor = SceneLight.DiffuseColor * SceneLight.AmbientPower;
			//        effect.SpecularColor = SceneLight.SpecularColor * SceneLight.AmbientPower;
			//        effect.SpecularPower = SceneLight.SpecularPower * SceneLight.AmbientPower;
			//        effect.EmissiveColor = SceneLight.AmbientColor * SceneLight.AmbientPower;
			//    }
			//    // Draw the mesh, using the effects set above.
			//    mesh.Draw();
			//}

			//mouse.Render();
			base.Draw( gameTime );
		}


		//override  

		VertexDeclaration vertexShaderDeclaration;
		VertexBuffer vertexBuffer;
		IndexBuffer indexBuffer;
		void CreateSomeObjects()
		{
			vertexShaderDeclaration = new VertexDeclaration( graphics.GraphicsDevice,
					VertexPositionNormalTexture.VertexElements );

			/*
			vertexBuffer = new VertexBuffer( graphics.GraphicsDevice,
				typeof( VertexPositionNormalTexture ),
				24,
				ResourceUsage.WriteOnly,
				ResourceManagementMode.Automatic );

			vertexArray = new VertexPositionNormalTexture[24];


			vertexBuffer.SetData<VertexPositionNormalTexture>( vertexArray );

			indexBuffer = new IndexBuffer( graphics.GraphicsDevice,
		sizeof( short ) * vertexIndices.Length,
		ResourceUsage.None,
		ResourceManagementMode.Automatic,
		IndexElementSize.SixteenBits );
			indexBuffer.SetData<short>( vertexIndices );
			 */
		}


		protected void CreateTexture()
		{
			/*
			faceTexture = new Texture2D( graphics.GraphicsDevice,
				64,
				64,
				1,
				ResourceUsage.Dynamic,
				SurfaceFormat.Bgr565,
				ResourceManagementMode.Manual );

			ushort[] data = new ushort[4096];
			for( int i = 0; i < 64; i++ )
			{
				SetTexturePixel( ref data, 64, 64, i, i, Color.SlateBlue );
				SetTexturePixel( ref data, 64, 64, 63 - i, i, Color.SlateGray );
			}
			faceTexture.SetData<ushort>( data, 0, 4096, SetDataOptions.Discard );
			 */
		}

		protected void DrawObjects()
		{
			GraphicsDevice device = graphics.GraphicsDevice;
			device.VertexDeclaration = vertexShaderDeclaration;

		}


	}



//----------------------------------------------------------------------------------------


  public class ChaseCamera : DrawableGameComponent
  {
    private static ChaseCamera activeCamera = null;
    private ContentManager _content;

    
    private Quaternion rotation;
    private float turnSpeed = 30f;
    int centerX;
    int centerY;

    int mscroll;
    

    #region Chased object properties (set externally each frame)

    /// <summary>
    /// Position of object being chased.
    /// </summary>
    public Vector3 ChasePosition
    {
      get { return chasePosition; }
      set { chasePosition = value; }
    }
    private Vector3 chasePosition;

    /// <summary>
    /// Direction the chased object is facing.
    /// </summary>
    public Vector3 ChaseDirection
    {
      get { return chaseDirection; }
      set { chaseDirection = value; }
    }
    private Vector3 chaseDirection;

    /// <summary>
    /// Chased object's Up vector.
    /// </summary>
    public Vector3 Up
    {
      get { return up; }
      set { up = value; }
    }
    private Vector3 up = Vector3.Up;

    #endregion

    public static ChaseCamera ActiveCamera
    {
      get { return activeCamera; }
      set { activeCamera = value; }
    }

    public ChaseCamera(Game game, ContentManager content)
      : base(game)
    {
      _content = content;
      Reset();
      if (ActiveCamera == null)
        ActiveCamera = this;
    }

    #region Desired camera positioning (set when creating camera or changing view)

    /// <summary>
    /// Desired camera position in the chased object's coordinate system.
    /// </summary>
    public Vector3 DesiredPositionOffset
    {
      get { return desiredPositionOffset; }
      set { desiredPositionOffset = value; }
    }
    private Vector3 desiredPositionOffset = new Vector3(0, 0.0f, 0.0f);

    /// <summary>
    /// Desired camera position in world space.
    /// </summary>
    public Vector3 DesiredPosition
    {
      get
      {
        // Ensure correct value even if update has not been called this frame
        UpdateWorldPositions();

        return desiredPosition;
      }
    }
    private Vector3 desiredPosition;

    /// <summary>
    /// Look at point in the chased object's coordinate system.
    /// </summary>
    public Vector3 LookAtOffset
    {
      get { return lookAtOffset; }
      set { lookAtOffset = value; }
    }
    
    private Vector3 lookAtOffset = new Vector3(0, 0, 0);

    /// <summary>
    /// Look at point in world space.
    /// </summary>
    public Vector3 LookAt
    {
      get
      { // Ensure correct value even if update has not been called this frame
        UpdateWorldPositions();
        return lookAt;
      }
    }
    private Vector3 lookAt;

    #endregion

    #region Camera physics (typically set when creating camera)

    /// <summary>
    /// Physics coefficient which controls the influence of the camera's position
    /// over the spring force. The stiffer the spring, the closer it will stay to
    /// the chased object.
    /// </summary>
    public float Stiffness
    {
      get { return stiffness; }
      set { stiffness = value; }
    }
    private float stiffness = 1800.0f;

    /// <summary>
    /// Physics coefficient which approximates internal friction of the spring.
    /// Sufficient damping will prevent the spring from oscillating infinitely.
    /// </summary>
    public float Damping
    {
      get { return damping; }
      set { damping = value; }
    }
    private float damping = 600.0f;

    /// <summary>
    /// Mass of the camera body. Heaver objects require stiffer springs with less
    /// damping to move at the same rate as lighter objects.
    /// </summary>
    public float Mass
    {
      get { return mass; }
      set { mass = value; }
    }
    private float mass = 50.0f;

    #endregion

    #region Current camera properties (updated by camera physics)

    /// <summary>
    /// Position of camera in world space.
    /// </summary>
    public Vector3 Position
    {
      get { return position; }
    }
    private Vector3 position;

    /// <summary>
    /// Velocity of camera.
    /// </summary>
    public Vector3 Velocity
    {
      get { return velocity; }
    }
    private Vector3 velocity;

    #endregion

    #region Perspective properties

    /// <summary>
    /// Perspective aspect ratio. Default value should be overriden by application.
    /// </summary>
    public float AspectRatio
    {
      get { return aspectRatio; }
      set { aspectRatio = value; }
    }
    private float aspectRatio = 4.0f / 3.0f;

    /// <summary>
    /// Perspective field of view.
    /// </summary>
    public float FieldOfView
    {
      get { return fieldOfView; }
      set { fieldOfView = value; }
    }
    private float fieldOfView = MathHelper.ToRadians(45.0f); // Width of the view

    /// <summary>
    /// Distance to the near clipping plane.
    /// </summary>
    public float NearPlaneDistance
    {
      get { return nearPlaneDistance; }
      set { nearPlaneDistance = value; }
    }
    private float nearPlaneDistance = 1.0f;

    /// <summary>
    /// Distance to the far clipping plane.
    /// </summary>
    public float FarPlaneDistance
    {
      get { return farPlaneDistance; }
      set { farPlaneDistance = value; }
    }
    private float farPlaneDistance = 10000.0f;

    #endregion

    #region Matrix properties

    /// <summary>
    /// View transform matrix.
    /// </summary>
    public Matrix View
    {
      get { return view; }
    }
    private Matrix view;

    /// <summary>
    /// Projecton transform matrix.
    /// </summary>
    public Matrix Projection
    {
      get { return projection; }
    }
    private Matrix projection;

    #endregion

    #region Methods

    /// <summary>
    /// Rebuilds object space values in world space. Invoke before publicly
    /// returning or privately accessing world space values.
    /// </summary>
    private void UpdateWorldPositions()
    {
      // Construct a matrix to transform from object space to worldspace
      Matrix transform = Matrix.Identity;
      transform.Forward = ChaseDirection;
      transform.Up = Up;
      transform.Right = Vector3.Cross(Up, ChaseDirection);

      // Calculate desired camera properties in world space
      desiredPosition = ChasePosition +
          Vector3.TransformNormal(DesiredPositionOffset, transform);
      lookAt = ChasePosition +
          Vector3.TransformNormal(LookAtOffset, transform);
    }
    /// <summary>
    /// Rebuilds camera's view and projection matricies.
    /// </summary>
    private void UpdateMatrices()
    {
      view = Matrix.CreateLookAt(this.Position, this.LookAt, this.Up);    
      projection = Matrix.CreatePerspectiveFieldOfView(FieldOfView,
          AspectRatio, NearPlaneDistance, FarPlaneDistance);
    }
    private void UpdateMatrices(int i)
    {
      Vector3 campos = new Vector3(0, 0.1f, 0.6f);
      campos = Vector3.Transform(campos, Matrix.CreateFromQuaternion(rotation));      
      Vector3 camup = new Vector3(0, 0, 0);
      camup = Vector3.Transform(camup, Matrix.CreateFromQuaternion(rotation));

      view = Matrix.CreateLookAt(this.Position+campos, this.LookAt, this.Up + camup);

      projection = Matrix.CreatePerspectiveFieldOfView(FieldOfView,
                               AspectRatio, NearPlaneDistance, FarPlaneDistance);

    }
    /// <summary>
    /// Forces camera to be at desired position and to stop moving. The is useful
    /// when the chased object is first created or after it has been teleported.
    /// Failing to call this after a large change to the chased object's position
    /// will result in the camera quickly flying across the world.
    /// </summary>
    public void Reset()
    {
      UpdateWorldPositions();
      // Stop motion
      velocity = Vector3.Zero;
      // Force desired position
      position = desiredPosition;
      rotation = new Quaternion(0, 0, 0, 1);      
      UpdateMatrices();
    }
    /// <summary>
    /// Animates the camera from its current position towards the desired offset
    /// behind the chased object. The camera's animation is controlled by a simple
    /// physical spring attached to the camera and anchored to the desired position.
    /// </summary>
    public override void Update(GameTime gameTime)
    {
      if (gameTime == null)
        throw new ArgumentNullException("gameTime");
      //KeyboardState keyboard = Keyboard.GetState();
      MouseState mouse = Mouse.GetState();
      UpdateWorldPositions();
           
      if (mouse.LeftButton == ButtonState.Pressed)
      {
        mscroll = 0;
        centerX = Game.Window.ClientBounds.Width / 2;
        centerY = Game.Window.ClientBounds.Height / 2;       
        Mouse.SetPosition(centerX, centerY);
        //RevolveGlobal(new Vector3(1, 0, 0), (MathHelper.ToRadians((mouse.Y - centerY) * turnSpeed * 0.01f)));
        Revolve(new Vector3(1, 0, 0), (mouse.Y - centerY) * 0.01f);
        //RevolveGlobal(new Vector3(0, 1, 0), (MathHelper.ToRadians((mouse.X - centerX) * turnSpeed * 0.01f)));
        Revolve(new Vector3(0, 1, 0), (mouse.X - centerX) * 0.01f);
     //   TranslateGlobal(new Vector3(0, 0, 0));
        Translate(new Vector3(0, 0, 0));             
        UpdateMatrices(1);
      }
      else
      {
        mscroll = 1;
        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
        // Calculate spring force
        Vector3 stretch = position - desiredPosition;
        Vector3 force = -stiffness * stretch - damping * velocity;
        // Apply acceleration
        Vector3 acceleration = force / mass;
        velocity += acceleration * elapsed;
        // Apply velocity
        position += velocity * elapsed;        
        UpdateMatrices();      
      }
      //if (mouse.ScrollWheelValue <= mscroll)
      if (mscroll !=0 )
      {
        Translate(new Vector3(0, 0, mouse.ScrollWheelValue * 0.01f));        
      }
    }       
    #endregion

    public void Rotate(Vector3 axis, float angle)
    {
      axis = Vector3.Transform(axis, Matrix.CreateFromQuaternion(rotation));
      rotation = Quaternion.Normalize(Quaternion.CreateFromAxisAngle(axis, angle) * rotation);
    }
    public void RotateGlobal(Vector3 axis, float angle)
    {
      rotation = Quaternion.Normalize(Quaternion.CreateFromAxisAngle(axis, angle) * rotation);
    }
    public void Translate(Vector3 distance)
    {
      position += Vector3.Transform(distance, Matrix.CreateFromQuaternion(rotation));
    }
    public void TranslateGlobal(Vector3 distance)
    {
      position += distance;
    }
    public void Revolve(Vector3 axis, float angle)
    {
      Vector3 revolveAxis = Vector3.Transform(axis, Matrix.CreateFromQuaternion(rotation));
      Quaternion rotate = Quaternion.CreateFromAxisAngle(revolveAxis, angle);
      position = Vector3.Transform(position - ChasePosition, Matrix.CreateFromQuaternion(rotate)) + ChasePosition;
      Rotate(axis, angle);
    }
    public void RevolveGlobal(Vector3 axis, float angle)
    {
      Quaternion rotate = Quaternion.CreateFromAxisAngle(axis, angle);
      position = Vector3.Transform(position - ChasePosition, Matrix.CreateFromQuaternion(rotate)) + ChasePosition;
      RotateGlobal(axis, angle);
    }
  }


}
