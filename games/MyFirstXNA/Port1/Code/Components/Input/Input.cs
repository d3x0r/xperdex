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
    public class Input : Component
    {
        #region Properties
        #endregion

        #region Fields
        //TestsMain game;

		public struct InputEvent
		{
			internal Keys key;
			public delegate void Event();
			public Event DoEvent;
			//KeyState state;
			public InputEvent( Keys key, Event handler )
			{
				this.key = key;
				this.DoEvent = handler;	
			}
		}

		public List<InputEvent> external_events = new List<InputEvent>();


        Physics Physics = Physics.Instance;       

        GamePadState CurrentGamePadState;
        GamePadState PreviousGamePadState;

        MouseState CurrentMouseState;
        MouseState PreviousMouseState;

        List<Keys> PreviousKeysDown;

        KeyboardState CurrentKeyboardState;

        Cursor MouseCursor;

        FreeCamera FreeInputCam;
        FixedCamera FixedInputCam;

		GraphicsDevice device;

        Camera CurrentInputCam;
        #endregion

        #region Initialization
        public Input(GraphicsDevice device)
        {
            //game = thisGame;
			this.device = device;
            PreviousKeysDown = new List<Keys>();

            MouseCursor = new Cursor(device);            
        }

        public void SetupCamera( Camera inCam )
        {
            if (inCam is FreeCamera)
            {
                FreeInputCam = (inCam as FreeCamera);
                CurrentInputCam = FreeInputCam;
            }
            else if (inCam is FixedCamera)
            {
                FixedInputCam = (inCam as FixedCamera);
                CurrentInputCam = FixedInputCam;
            }
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            CheckKeyboard(gameTime);
            CheckMouse(gameTime);
            //CheckGamePad(gameTime);
        }

        /// <summary>
        /// This checks the keyboard for input. The way this function is set up allows
        /// for knowing the last key pressed, this allows the ProcessKeyboard to setup
        /// for repeating keys, and keys that are meant to be pressed once. The only downside
        /// to this method is that creating an array of keys every loop causes garbage
        /// collection. However on a PC this is not a huge deal for garbage this small,
        /// and keyboard checking is not needed on the Xbox360.
        /// </summary>
        /// <param name="gameTime"></param>
        private void CheckKeyboard(GameTime gameTime)
        {
            CurrentKeyboardState = Keyboard.GetState();
            Keys[] CurrentlyPressed = CurrentKeyboardState.GetPressedKeys();

            foreach (Keys key in CurrentlyPressed)
            {
                if (PreviousKeysDown.Count == 0)
                    ProcessKeyboard(key, Keys.Zoom, gameTime);
                else
                {
                    for (int i = 0; i < PreviousKeysDown.Count; i++)
                        ProcessKeyboard(key, PreviousKeysDown[i], gameTime);
                }
            }

            PreviousKeysDown.Clear();      // Clear the previous list of keys down

            // Update the list of previous keys that are down for next loop
            foreach (Keys key in CurrentlyPressed)
                PreviousKeysDown.Add(key);
        }

        private void ProcessKeyboard(Keys newkey, Keys oldkey, GameTime gameTime)
        {
            float Time = gameTime.ElapsedGameTime.Milliseconds;

            // These variables hold information about input for the camera
            float Pitch = 0.0f;
            float Turn = 0.0f;
            float FrontBackDelta = 0.0f;
            float LeftRightDelta = 0.0f;

            // For keys that are held in
            if (oldkey == newkey)
            {
				bool found = false;
				foreach( InputEvent ie in external_events )
				{
					if( ie.key == newkey )
					{
						found = true;
						ie.DoEvent();
						break;
					}
				}
				if( !found )
                switch (newkey)
                {
                    case Keys.Up:
                        Pitch += Time * 0.001f;
                        break;
                    case Keys.Down:
                        Pitch -= Time * 0.001f;
                        break;
                    case Keys.Left:
                        Turn += Time * 0.001f;
                        break;
                    case Keys.Right:
                        Turn -= Time * 0.001f;
                        break;
                    case Keys.W:
                        FrontBackDelta += Time * 0.1f;
                        break;
                    case Keys.S:
                        FrontBackDelta -= Time * 0.1f;
                        break;
                    case Keys.A:
                        LeftRightDelta += Time * 0.1f;
                        break;
                    case Keys.D:
                        LeftRightDelta -= Time * 0.1f;
                        break;
                    case Keys.OemOpenBrackets:
                        Physics.WindVector.X += .1f;
                        break;
                    case Keys.OemCloseBrackets:
                        Physics.WindVector.X -= .1f;
                        break;
                    case Keys.OemPlus:
                        Physics.GravityVector.Z -= .001f;
                        break;
                    case Keys.OemMinus:
                        Physics.GravityVector.Z += .001f;
                        break;
                    case Keys.Enter:
                        //game.AddSphere(CurrentInputCam.GetPosition() + CurrentInputCam.ForwardVector * 5, CurrentInputCam.ForwardVector * 2, 
                        //               .05f, 0.7f, .3f, 5f, 0f);
                        break;
                    case Keys.Back:
                        //game.ClearAllEntities();
                        break;
                }
            }
            else   // For keys that AREN'T meant to repeat when held in
            {
                switch (newkey)
                {
                    case Keys.Space:
                        //game.AddSphere(CurrentInputCam.GetPosition() + CurrentInputCam.ForwardVector * 5, CurrentInputCam.ForwardVector * 2, 
                        //               .05f, .7f, .3f, 5f, 0f);
                        break;
                    case Keys.Tab:
                        //game.SwitchCameras();
                        break;
                    case Keys.Escape:
                        //game.Exit();
                        break;
                }
            }

            if (CurrentInputCam != null)
                CurrentInputCam.MoveCam(Pitch, Turn, FrontBackDelta, LeftRightDelta);
        }

        /// <summary>
        /// Check for any connected gamepads, and set up their states for processing.
        /// </summary>
        /// <param name="gameTime">XNA built-in time parameter for timing</param>
        private void CheckGamePad(GameTime gameTime)
        {
            CurrentGamePadState = GamePad.GetState(PlayerIndex.One);

            if (CurrentGamePadState.IsConnected)
            {
                ProcessGamePad(gameTime, PlayerIndex.One);
            }

            PreviousGamePadState = CurrentGamePadState;

            // For a multi-player game that would require multiple gamepads, a good idea
            // would be to setup a player class in which each player was initialized with
            // a unique PlayerIndex value, and the class would have gamepad states of its own.
            // This way the game could iterate through each player, and check each one's
            // input individually.
        }

        private void ProcessGamePad(GameTime gameTime, PlayerIndex playerNumber)
        {
            // You can setup actions to occur if a button is pressed.
            if (CurrentGamePadState.Buttons.A == ButtonState.Pressed)
            {
            }

            // If you want an action that occurs only once if a button is held in
            // you could do it like this
            if (CurrentGamePadState.Buttons.B == ButtonState.Pressed &&
                PreviousGamePadState.Buttons.B != ButtonState.Pressed)
            {
            }

            if (CurrentGamePadState.DPad.Down == ButtonState.Pressed)
            {
            }

            // Detect movement left to right on the thumbstick
            // A value of zero means there is no left-right movement
            if (CurrentGamePadState.ThumbSticks.Left.X != 0)
            {
                // Process left movement
                if (CurrentGamePadState.ThumbSticks.Left.X < 0)
                {

                }
                else // Process right movement
                {

                }

                // Thumbstick values are analog, and as such are more than a simple
                // pressed or not pressed. This value can be used to determine the
                // intensity of an action. If I wanted to use the thumbstick to turn
                // a vehicle then the furthur from 0 the X value is the stronger the turn
                // value would be.
            }

            if (CurrentGamePadState.Triggers.Right > 0)
            {
                // Triggers are analog like thumbsticks, however their value is always
                // zero or positive, never negative.
            }
        }
       
        private void CheckMouse(GameTime gameTime)
        {
            MouseCursor.Update();   // The cursor class is useful for things like ray tracing
                                    // in 3d game/game editor or stuff like triangle picking.

            CurrentMouseState = Mouse.GetState();
            ProcessMouse(gameTime);
            PreviousMouseState = CurrentMouseState;
        }

        private void ProcessMouse(GameTime gameTime)
        {
            if (CurrentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (PreviousMouseState.LeftButton != ButtonState.Pressed)
                {
                    CurrentInputCam.ZoomIn();
                }
                else
                {

                }
            }

            // Determine is mouse has moved left or right since last frame
            if (CurrentMouseState.X != PreviousMouseState.X)
            {
                
            }

            // Determine is mouse has moved up or down since last frame
            if (CurrentMouseState.Y != PreviousMouseState.Y)
            {

            }
        }
        #endregion

    }
}
