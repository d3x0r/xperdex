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
    public class TestsMain : Microsoft.Xna.Framework.Game
    {
        // Hover your mouse over classes (in Teal), or functions to
        // get more detailed descriptions about things. I will have
        // descriptions or comments on as many things as possible.

        #region Properties
        public const int SCREEN_WIDTH = 1024;
        public const int SCREEN_HEIGHT = 768;

        public const float LowestZ = -1000f;
        #endregion

        #region Fields
        GraphicsDeviceManager Graphics;
        ContentManager Content;

        List<Component> ComponentList;

        Matrix ViewMatrix;
        Matrix ProjectionMatrix;

        public GraphicsDevice device
        {
            get { return Device; }
        }
        GraphicsDevice Device;

        SpriteBatch SpriteBatch;
        SpriteFont Haetten_16PtReg;

        Physics Physics = Physics.Instance;

        // DO NOT uncomment until you've created an XACT sound file
        // for your game. AudioManager requires this file to initialize.
        // You can find tutorials on how to use XACT to create sound files
        // online. XACT is included with XNA.
        //AudioManager AudioMgr = AudioManager.Instance;

        // Once you've created a sound file, you can then load up
        // specific wave files from the sound bank here simply by
        // specifying the sound name here. The AudioManager does not
        // require a file path, just the file name. If your wave file is
        // called MySound.wav, no matter where the path is you simply
        // just pass in "MySound" as the parameter.
        //Sound SoundVariableNameHere = new Sound("your sound's file name here");

        // NOTE: You should not remove Component variables even if you do not 
        // wish to use them. There are places where the code will check if you're
        // using certain variables. If you do not wish to use a component you
        // simply never initialize it, and it will remain null, taking up
        // very little memory.

        // A camera we can use to view the scene. 
        FreeCamera FreeCamera;          
        FixedCamera FixedCamera;
        Camera CurrentCamera;           // Component

        // An input class to read in from keyboard, mouse, or gamepad
        Input Input;                    // Component

        // A little sunlight for our scene
        SunLight SceneLight;            // Component

        // A skydome for the scene
        SkyDome SceneSky;               // Component

        Fog SceneFog;                   // Component

        public Terrain sceneTerrain
        {
            get { return SceneTerrain; }
        }
        Terrain SceneTerrain;

        Water Water;

        public SnowWeather SnowWeather;        // Component
        public RainWeather RainWeather;        // Component

        Viewport Viewport;
        float AspectRatio;

        public List<BaseEntity> entityList
        {
            get { return EntityList; }
        }
        List<BaseEntity> EntityList;

		private BoundingBox boundingBox
		{
			get
			{
				return mBox.Bounds;
			}
		}
		private MyBoundingBox mBox = new MyBoundingBox();

        public BoundingBox Bounds
        {
            get { return boundingBox; }
        }
        #endregion

        #region Initialization

        public TestsMain()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content = new ContentManager(Services, "Content");
        }
        
        protected override void Initialize()
        {
            base.Initialize();

            SetupGraphicsDevice();

            // Setup a spriteBatch which allows us to draw font messages and sprites
            // to the screen.
            SpriteBatch = new SpriteBatch(Device);
            Haetten_16PtReg = Content.Load<SpriteFont>("Images/Fonts/Haetten16PtReg");

            // Setup a component list
            ComponentList = new List<Component>();

            // Make sure to initialize any lists you make in a game
            // before using them.
            EntityList = new List<BaseEntity>();

            LoadCameras();

            LoadInput();

            SceneLight = new SunLight(Device, Content);        // A default light is required for other components
            LoadLight();

            LoadSkies();            

            LoadTerrain();

            LoadWeatherSystems();

            LoadWater();

            LoadFog();

            LoadEntities();

            LoadPhysicsValues();
        }

        private void LoadCameras()
        {
            FreeCamera = new FreeCamera( mBox, AspectRatio);      // Initialize the camera

            FixedCamera = new FixedCamera( mBox, AspectRatio);    // This camera cannot be used until an 
                                                                 // target entity is assigned to it.

            CurrentCamera = FreeCamera;
        }


		void SimpleAddSphere()
		{
			AddSphere( CurrentCamera.GetPosition() + CurrentCamera.ForwardVector * 5, CurrentCamera.ForwardVector * 2,
									   .05f, .7f, .3f, 5f, 0f );
		}

        private void LoadInput()
        {
            Input = new Input( Device );            // Initialize the input
            Input.SetupCamera(FreeCamera);      // Connect our input to the camera
            Input.SetAutoDraw(false);

			Input.InputEvent e;
			e = new Input.InputEvent( Keys.Tab, SwitchCameras );
			Input.external_events.Add( e );
			e = new Input.InputEvent( Keys.Space, SimpleAddSphere );
			Input.external_events.Add( e );
			e = new Input.InputEvent( Keys.Back, ClearAllEntities );
			Input.external_events.Add( e );
			e = new Input.InputEvent( Keys.Escape, Exit );
			Input.external_events.Add( e );
			

            AddComponent(Input);                // Add input to the component list      
        }

        private void LoadLight()
        {
            SceneLight.Direction = new Vector3(1f, .5f, -.6f);          // Direction this light points
            SceneLight.AmbientColor = new Vector3(0.3f, 0.3f, 0.3f);    // RGB values of our light
            SceneLight.SpecularColor = new Vector3(0.2f, 0.2f, 0.2f);
            SceneLight.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
            SceneLight.SpecularPower = 64;                              // Lower means more reflection
            SceneLight.AmbientPower = 0.6f;
            SceneLight.MinimumAmbient = 0.2f;            
            SceneLight.EnableDayNight(15);                              // Let this sunlight rise and set every 30 seconds

            AddComponent(SceneLight);
        }

        private void LoadTerrain()
        {
            SceneTerrain = new Terrain(Device, Content);
            SceneTerrain.SetElevationStrength(30);                       // Changes elevation strength
            SceneTerrain.InitTerrainTextures("./Textures/grass", "./Textures/rock", "./Textures/sand");
            SceneTerrain.InitTerrainNormalsTextures("./Textures/grassNormal", "./Textures/rockNormal", "./Textures/sandNormal");

            SceneTerrain.Initialize("./Images/Heightmaps/map2", "./Images/Terrainmaps/map1terrain", 25);

            AddComponent(SceneTerrain);
        }

        private void LoadWater()
        {
            Water = new Water(Device, Content);

            // You cannot use the mapwidth and mapheight variables if you do not have a terrain component initialized
            // In that case you must specify your own values.
            if ( SceneTerrain.Initialized )
                Water.Initialize(new Vector3(0.2f, 0.2f, 1.0f), Vector3.Zero, SceneTerrain.MapWidth, SceneTerrain.MapHeight, 100f);
            else
                Water.Initialize(new Vector3(0.2f, 0.2f, 1.0f), Vector3.Zero, 50, 50, 100f);
            
            // You must initialize the sky component before the water component
            // in order for this to work. 
            if ( SceneSky.Initialized )
                Water.SetSkyTexture(SceneSky.SkyTexturePath);
            else   // If you aren't going to have a sky, pass your own texture in here
                Water.SetSkyTexture("./Models/Textures/clouds");

            Water.SetSurfaceNormalMapTexture("./Textures/waterNormal");

            // Allows the water to use refraction and reflection using the scene
            // This does cause a slight performance hit as well though
            Water.Associate(SceneTerrain);  // Sets up reflection/refraction of terrain
            Water.Associate(SceneSky);      // Sets up reflection/refraction of the sky
            Water.Associate(SnowWeather);   // Sets up reflection/refraction of weather particles
            Water.Associate(this);          // Sets up reflection/refraction for all entities

            AddComponent(Water, 0);         // Set water as first component, it needs to draw first
        }

        private void LoadSkies()
        {
            SceneSky = new SkyDome(Device, Content, "./Models/Textures/clouds", .01f);

            SkyDome SceneSkyInner = new SkyDome(Device, Content, "./Models/Textures/skyFog", .05f);
            SceneSkyInner.SetElevation(990f);
            SceneSkyInner.SetScale(2900f);
            SceneSkyInner.SetOpacity(1f);
            SceneSkyInner.RotateHorizontal(MathHelper.PiOver2);

            // Two sky layers gives the effect of depth for clouds, however if you only 
            // wanted one sky layer that is fine as well.
            AddComponent(SceneSky);             // Initialize an outer sky layer
            AddComponent(SceneSkyInner);        // Initialize an inner sky layer
        }

        private void LoadFog()
        {
            SceneFog = new Fog(Device, Color.White, .002f);
            AddComponent(SceneFog);
        }

        private void LoadEntities()
        {
            Sphere newEntity;
            Random random = new Random();

            if (sceneTerrain != null)
            {
                // Create a bunch of spheres above our terrain, laid out
                // in a gridlike fashion.
                for (int x = 1; x < sceneTerrain.MapWidth; x += 25)
                {
                    for (int y = 1; y < sceneTerrain.MapHeight; y += 25)
                    {
                        newEntity = new Sphere(Device, Content, this);
                        newEntity.Initialize(new Vector3(x, y, x + y), Vector3.Zero, "./Models/sphere", "Sphere");
                        newEntity.SetScale(.05f);           // Size of spheres
                        newEntity.SetElasticity(.7f);       // Elasticity (bounciness) of spheres
                        newEntity.SetAirViscosity(.4f);
                        newEntity.SetMass(15);              // Mass of spheres
                        newEntity.SetRoughness(0);          // Friction with ground (currently not fully accurate)                        
                        EntityList.Add(newEntity);
                    }
                }
            }

            newEntity = new Sphere(Device, Content, this);
            newEntity.Initialize(new Vector3(75, 75, 75), Vector3.Zero, "./Models/sphere", "Sphere");
            newEntity.SetScale(.2f);           // Size of spheres
            newEntity.SetElasticity(.7f);       // Elasticity (bounciness) of spheres
            newEntity.SetAirViscosity(.4f);
            newEntity.SetMass(100);              // Mass of spheres
            newEntity.SetRoughness(0);          // Friction with ground (currently not fully accurate)
            EntityList.Add(newEntity);

            FixedCamera.SetCameraTarget(newEntity);
        }

        private void LoadPhysicsValues()
        {
            Physics.SetGravityVector(0, 0, -9.8f);

            Physics.SetWindVector(30, 30, 0f);
        }

        private void LoadWeatherSystems()
        {
            // Note: You shouldn't have more than one weather system
            // running at one time unless you keep the combined intensity
            // of them below around 200-250 particles per second.

            SnowWeather = new SnowWeather(this, Content);
            SnowWeather.SetIntensity(250f);
            AddComponent(SnowWeather);

            //RainWeather = new RainWeather(this, Content);
            //RainWeather.SetIntensity(450f);
            //AddComponent(RainWeather);
        }

        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            if (unloadAllContent)
            {
                // Removes all content that has been loaded through the
                // content pipeline. This is called after a game.Exit() has
                // been called. The C# garbage collector is free to clear
                // this memory after the references of the content are unloaded.
                Content.Unload();
            }
        }

        private void SetupGraphicsDevice()
        {
            Device = Graphics.GraphicsDevice;

            // Window's height and width
            Graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            Graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

            // Set to true for full screen
            Graphics.IsFullScreen = false;

            Graphics.MinimumPixelShaderProfile = ShaderProfile.PS_2_0;

            // Uncomment this to see the actual maximum attainable frames per second           
            //Graphics.SynchronizeWithVerticalRetrace = false;

            // Applies the changes made above to the graphics card.
            Graphics.ApplyChanges();

            // This must be set after the graphics changes are made.
            Viewport = Device.Viewport;

            AspectRatio = (float)Viewport.Width / (float)Viewport.Height;
        }
        #endregion

        #region Methods

        protected override void Update(GameTime gameTime)
        {
            CurrentCamera.Update(gameTime);

            // This updates all of our components that are in the
            // component list
            foreach (Component thisComponent in ComponentList)
            {
                // Only update if this component is set for auto updating.
                if ( thisComponent.autoUpdate )
                    thisComponent.Update(gameTime);
            }

            foreach (BaseEntity thisEntity in EntityList)
                thisEntity.Update(gameTime);

            CheckEntityCollisions(gameTime);

            // This cleans up any entities that were manually marked as garbage.
            CheckForGarbageEntities();

            // You can play a sound simply by calling PlaySound()...
            // You place this anywhere you want to call the sound. In this
            // case the sound would play every game loop, which might be
            // excessive. Usually you'll want this somewhere where an
            // event occurs, like a collision, or possibly during an input.
            //SoundVariableNameHere.PlaySound();
            
            base.Update(gameTime);
        }

        // This should not be deleted
        public void AddComponent(Component thisComponent)
        {
            thisComponent.Initialize();
            ComponentList.Add(thisComponent);
        }

        // This should not be deleted
        public void AddComponent(Component thisComponent, int InsertIndex)
        {
            thisComponent.Initialize();
            ComponentList.Insert(InsertIndex, thisComponent);
        }

        private void CheckEntityCollisions(GameTime gameTime)
        {
            // Check every pair of entities against each other for collision.
            // Algorithm is set up to not check any pair twice.
            for (int i = 0; i < EntityList.Count; i++)
            {
                if (EntityList[i] is DynamicEntity)
                {
                    for (int j = i + 1; j < EntityList.Count; j++)
                    {
                        if (EntityList[j] is DynamicEntity)
                        {
                            DynamicEntity FirstEntity = EntityList[i] as DynamicEntity;
                            DynamicEntity SecondEntity = EntityList[j] as DynamicEntity;

                            if (Physics.CheckEntityCollision(ref FirstEntity, ref SecondEntity))
                            {
                                Physics.ProcessEntityCollision(gameTime, ref FirstEntity, ref SecondEntity);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks for any entities that have been manually marked
        /// for deletion and removes them from the list. Unless any
        /// specific entity references exists, then C#'s built-in garbage
        /// collector should remove it from memory when it deems necessary.
        /// </summary>
        private void CheckForGarbageEntities()
        {
            for (int i = EntityList.Count - 1; i >= 0; i--)
            {
                if (EntityList[i].MarkedForDeletion)
                    DestroyEntity(EntityList[i]);
            }
        }

        private void DestroyEntity(BaseEntity thisEntity)
        {
            EntityList.Remove(thisEntity);

            if (FixedCamera.target == thisEntity)
                FixedCamera.SetCameraTarget(null);
        }

        public void AddSphere(Vector3 position, Vector3 velocity, float scale, float elasticity, float viscocity, float mass, float roughness)
        {
            Sphere newSphere = new Sphere(Device, Content, this);
            newSphere.Initialize(position, Vector3.Zero, "./Models/sphere", "Sphere");
            newSphere.SetScale(scale);
            newSphere.SetElasticity(elasticity);
            newSphere.SetAirViscosity(viscocity);
            newSphere.SetMass(mass);
            newSphere.SetRoughness(roughness);
            newSphere.SetVelocityVector(velocity);
            EntityList.Add(newSphere);

            FixedCamera.SetCameraTarget(newSphere);
        }

        public void ClearAllEntities()
        {
            foreach (BaseEntity thisEntity in EntityList)
                thisEntity.MarkedForDeletion = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clears the entire window/screen to a specific color
            Device.Clear(Color.CornflowerBlue);

            // Get the ViewMatrix and ProjectionMatrix from this scene's camera
            ViewMatrix = CurrentCamera.ViewMatrix;
            ProjectionMatrix = CurrentCamera.ProjectionMatrix;

            foreach (Component thisComponent in ComponentList)
            {
                if (thisComponent.autoDraw)
                    thisComponent.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCamera);
            }

            DrawAllEntities(gameTime);

            // This is causing a very strange bug. Reported on XNA forums: 
            // http://forums.xna.com/ShowThread.aspx?PostID=26455#26479
            //DrawHUD(gameTime);

            base.Draw(gameTime);

            // Used to determine FPS
            float Elapsed = gameTime.ElapsedGameTime.Milliseconds;

            if (Elapsed < float.Epsilon)
                Elapsed = 1;

            // Setting a window title is an easy debug technique, but will not help in fullscreen debugging.            
            Window.Title = "Spheres: " + EntityList.Count + " --- FPS: " + (int)(1000 / Elapsed);
        }

        public void DrawAllEntities(GameTime gameTime)
        {
            // Go through any entities you've added to the scene and draw each one.
            foreach (BaseEntity thisEntity in EntityList)
                thisEntity.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCamera);
        }

        // This draw function is utilitized by the water component
        public void DrawAllEntities(GameTime gameTime, ref Matrix ViewMatrix, bool Above, float Elevation)
        {
            // Go through any entities you've added to the scene and draw each one.
            foreach (BaseEntity thisEntity in EntityList)
            {
                if (Above)
                {
                    if (thisEntity.position.Z >= Elevation)
                        thisEntity.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCamera);
                }
                else
                {
                    if (thisEntity.position.Z <= Elevation)
                        thisEntity.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCamera);
                }
            }
        }

        // This draw function is utilitized by the water component
        public void DrawAllEntities(GameTime gameTime, ref Matrix ViewMatrix)
        {
            // Go through any entities you've added to the scene and draw each one.
            foreach (BaseEntity thisEntity in EntityList)
                thisEntity.Draw(gameTime, ref ViewMatrix, ref ProjectionMatrix, SceneLight, CurrentCamera);
        }

        public void DrawHUD(GameTime gameTime)
        {
            SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.SaveState);

            // You can call DrawString between any spritebatch begin/end pair to draw text to the screen.
            // You simply tell it which spriteFont to use, what message to display, what screen coordinates and color to use.
            // Note, creating a string each frame causes garbage. If the message is always the same, consider making a string
            // that is part of the class and using that variable in drawstring rather than something like the lines below.

            // NOTE!: DrawString command has fairly poor performance, and should be used sparingly. I leave these here only
            // as an example of how to use the spritebatch's drawstring function, and so you understand the keyboard controls
            // for this sample program. You should remove these when making your own game.
            SpriteBatch.DrawString(Haetten_16PtReg, "W, A, S, D, and arrow keys control the camera", new Vector2(20, 20), Color.Yellow);
            SpriteBatch.DrawString(Haetten_16PtReg, "Enter, Spacebar - Shoot spheres, Backspace - Delete spheres", new Vector2(20, 45), Color.Yellow);
            SpriteBatch.DrawString(Haetten_16PtReg, "Change wind or gravity: [ or ] and + / - keys", new Vector2(20, 70), Color.LightGray);

            string CameraMode;
            if (CurrentCamera == FixedCamera)
            {
                CameraMode = "Fixed";

                if (FixedCamera.target == null)
                    SpriteBatch.DrawString(Haetten_16PtReg, "No target for fixed camera!", new Vector2(20, SCREEN_HEIGHT - 50), Color.Red);
            }
            else
                CameraMode = "Free";

            // Used to determine FPS
            float Elapsed = gameTime.ElapsedGameTime.Milliseconds;

            if (Elapsed < float.Epsilon)
                Elapsed = 1;

            SpriteBatch.DrawString(Haetten_16PtReg, "Camera: " + CameraMode + " || Zoom: " + CurrentCamera.zoomLevel + "x", new Vector2(SCREEN_WIDTH - 220, 20), Color.LightGray);
            SpriteBatch.DrawString(Haetten_16PtReg, "FPS: " + (int)(1000 / Elapsed), new Vector2(SCREEN_WIDTH - 80, 45), Color.LightBlue);            
            
            SpriteBatch.DrawString(Haetten_16PtReg, "Spheres: " + EntityList.Count, new Vector2(SCREEN_WIDTH - 120, 70), Color.LightBlue);

            // You can also use the SpriteBatch.Draw() function here. Pass it a texture to display sprites on the screen.

            SpriteBatch.End();
        }

        public void SwitchCameras()
        {
            if (CurrentCamera == FreeCamera)
                CurrentCamera = FixedCamera;
            else
                CurrentCamera = FreeCamera;
        }
        #endregion
    }
}
