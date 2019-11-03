using System;
using System.Collections.Generic;

// this is a thing that is not always available!
//C:\Windows\Microsoft.NET\DirectX for Managed Code\1.0.2902.0\Microsoft.DirectX.DirectDraw.dll
//Core DirectDraw classes for Managed DirectX
using Direct3D = Microsoft.DirectX.Direct3D;
using DirectSound = Microsoft.DirectX.DirectSound;
using DirectInput = Microsoft.DirectX.DirectInput;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.DirectX.Direct3D;
using System.Threading;
using Microsoft.DirectX;
using System.Drawing;
using xperdex.core.interfaces;


namespace xperd3x.d3d
{
	public class D3DState
	{
		public Direct3D.Device graphics = null;
		public DirectSound.Device sound = null;
		public DirectInput.Device keyboard = null;
		public DirectInput.Device mouse = null;
		public DirectInput.Device gameinput = null;
		public D3DState()
		{
			Direct3D.Device graphics = null;
			DirectSound.Device sound = null;
			DirectInput.Device keyboard = null;
			DirectInput.Device mouse = null;
			DirectInput.Device gameinput = null;
		}
	}

	public static class PSI_Renderalbes 
	{
		public static List<PSI_VirtuaFrame> Frames = new List<PSI_VirtuaFrame>();
	}

	[ControlAttribute( Name="Direct 3D Renderer" )]
	public class PSI_DirectFrame : IReflectorCanvas, IReflectorWidget
	{

		Control control;

		public D3DState state;
		//Direct3
		//Microsoft.DirectX.DirectDraw.Surface   
		static string gametitle = "Advanced Framework";
		public int screenwidth = 640;
		public int screenheight = 480;
		//If you recall, these values were kind of hidden away inside the MainClass constructor in the
		//first framework, so you had to hunt that function down if you wanted to change them.
		//Also added are some other statics:
		//static Timer gametimer = null;
		static bool paused = true;
		static bool unpause = false;
		public PSI_DirectFrame()
		{
			
		}

		~PSI_DirectFrame()
		{
			paused = true;
		}

		void PSI_DirectFrame_SizeChanged( object sender, EventArgs e )
		{
			screenwidth = control.Width;
			screenheight = control.Height;
			if( unpause )
				paused = false;
		}


		protected virtual void ProcessFrame()
		{
			if( !paused )
			{
				// do processing here
			}
			else
				System.Threading.Thread.Sleep( 1 );
		}

		void AnimationThread()
		{
		}

		public bool InitializeGraphics()
		{
			try
			{
				PresentParameters presentParams = new PresentParameters();
				presentParams.Windowed = true;
				presentParams.SwapEffect = SwapEffect.Discard;
				state = new D3DState();
				state.graphics = new Direct3D.Device( 0, DeviceType.Hardware, control,
				Direct3D.CreateFlags.SoftwareVertexProcessing, presentParams );
				//The previous code creates a new graphics device. It’s not going to make a whole lot of
				//sense to you right now, but don’t worry that much about it. Just know that it works, and
				//that I’ll get to it in much more detail in Chapter 7.
				//The next part of the code sets up the event handlers (which are delegates):
				state.graphics.DeviceLost += new EventHandler( this.InvalidateDeviceObjects );
				state.graphics.DeviceReset += new EventHandler( this.RestoreDeviceObjects );
				state.graphics.Disposing += new EventHandler( this.DeleteDeviceObjects );
				state.graphics.DeviceResizing += new CancelEventHandler( this.EnvironmentResizing );

				/* 2d feature for turning off back culling on badly chosen flat rectangels */
				state.graphics.RenderState.CullMode = Direct3D.Cull.None;

				// yes I want this.
				state.graphics.RenderState.AlphaBlendEnable = true;


				//The first three events handle whenever a device is lost (say, if the user switches to another
				//window), the device is reset for any reason, or the device is disposed of. These first three
				//events are solid events; when they happen, you have to handle them. No ifs, ands, or buts
				//about it—the operating system is telling you something happened and your event handler
				//has to take care of the situation.
				//The final event handles when the graphics device is resized, which is a special kind of
				//event because it can be cancelled. A cancelable event is an event that your program can
				//decide to reject. For example, if the user says he’s going to resize your game window, your
				//program will get the event, but you can tell the operating system, “Nope, it’s not gonna
				//happen!” and the event won’t complete. This behavior is used mostly to prevent forms
				//from closing before the user saves his data in windows applications.
				//The final part of the code returns true for a successful initialization, or catches any
				//DirectXExceptions that may have been thrown and returns false:
				return true;
			}
			catch( DirectXException )
			{
				return false;
			}
		}
		public virtual void InvalidateDeviceObjects( object sender, EventArgs e )
		{
		}
		public virtual void RestoreDeviceObjects( object sender, EventArgs e )
		{
		}
		public virtual void DeleteDeviceObjects( object sender, EventArgs e )
		{
		}
		public virtual void EnvironmentResizing( object sender, CancelEventArgs e )
		{
		}

		public delegate void DoUpdate();
		public event DoUpdate Update;

		Direct3D.CustomVertex.TransformedColored[] vertexes = null;

		public virtual void Draw( Direct3D.Device graphics )
		{
		}

		public delegate void OnRender( D3DState state );
		public event OnRender Render;

		bool DoRender()
		{
			if( state.graphics.Disposed )
			{
				// throw some sort of exception... I shoudlnt' be here...
				return false;
			}


			if( state.graphics != null )
			{
				if( graphicslost )
				{
					try
					{
						state.graphics.TestCooperativeLevel();
					}
					catch( Direct3D.DeviceLostException )
					{
						// device cannot be reacquired yet, just return
						return true;
					}
					catch( Direct3D.DeviceNotResetException )
					{
						// device has not been reset, but it can be reacquired now
						state.graphics.Reset( state.graphics.PresentationParameters );
					}
					graphicslost = false;
				}
                try
                {
                    state.graphics.Clear( ClearFlags.Target, Color.DarkBlue, 1.0f, 0 );
                    state.graphics.BeginScene();
					//foreach( PSI_VirtuaFrame frame in PSI_Renderalbes.Frames )
					{
						//frame.DoRender( state );
					}
					if( Render != null )
						Render( state );
					else
					{
                        if( vertexes == null )
                        {
                            vertexes = new Direct3D.CustomVertex.TransformedColored[3];
                            // top vertex:
                            vertexes[0].X = screenwidth / 2.0f; // halfway across the screen
                            vertexes[0].Y = screenheight / 3.0f; // 1/3 down screen
                            vertexes[0].Z = 0.0f;
                            vertexes[0].Color = Color.Red.ToArgb();
                            // right vertex:
                            vertexes[1].X = ( screenwidth / 3.0f ) * 2.0f; // 2/3 across the screen
                            vertexes[1].Y = ( screenheight / 3.0f ) * 2.0f; // 2/3 down screen
                            vertexes[1].Z = 0.0f;
                            vertexes[1].Color = Color.Green.ToArgb();
                            // left vertex:
                            vertexes[2].X = screenwidth / 3.0f; // 1/3 across the screen
                            vertexes[2].Y = ( screenheight / 3.0f ) * 2.0f; // 2/3 down screen
                            vertexes[2].Z = 0.0f;
                            vertexes[2].Color = Color.Blue.ToArgb();
                        }

                        state.graphics.VertexFormat = Direct3D.CustomVertex.TransformedColored.Format;
                        try
                        {
                            state.graphics.DrawUserPrimitives(
                            Direct3D.PrimitiveType.TriangleList,
                            1, vertexes );
                        }
                        catch(
                            Exception ex )
                        {
                            return true;
                        }
                    }
                    // TODO : Scene rendering
                    if( !state.graphics.Disposed )
                    {
                        state.graphics.EndScene();
                        state.graphics.Present();
                    }
                }
                // device has been lost, and it cannot be re-initialized yet
                catch( Direct3D.DeviceLostException )
                {
                    graphicslost = true;
                }
                catch( NullReferenceException )
                {
                    graphicslost = true;
                }
			}
			return true;
		}
		static bool graphicslost = false;
		void RunThread()
		{
			while( true )
			{
				if( paused )
					return;
				if( control.Visible )
				{
					if( Update != null )
						Update();
					if( !DoRender() )
						break;
				}
				Application.DoEvents();
			}
		}
		public void Run()
		{
			unpause = true;
			//paused = false;
		}


		#region IReflectorCreate Members

		public void DoCreate( Control pc )
		{
			state = new D3DState();
			control = pc;
			pc.SizeChanged += new EventHandler( PSI_DirectFrame_SizeChanged );
			//paused = false;
			if( !InitializeGraphics() )
			{
				MessageBox.Show( "Error while initializing Direct3D" );
			}
			ThreadStart ts = new ThreadStart( RunThread );
			Thread runthread = new Thread( ts );
			runthread.Start();
			paused = false;
		}

		void IReflectorCreate.OnCreate( Control pc )
		{
			DoCreate( pc );
		}

		#endregion


		#region IReflectorWidget Members

		bool IReflectorWidget.CanShow
		{
			get { return true; }
		}

		void IReflectorWidget.OnPaint( PaintEventArgs e )
		{
			this.DoRender();
		}

		void IReflectorWidget.OnKeyPress( KeyPressEventArgs e )
		{
			if( (int)e.KeyChar == (int)System.Windows.Forms.Keys.Escape )
			{
				paused = true;
				//this.Close();
			}
		}
		void IReflectorWidget.OnMouse( MouseEventArgs e )
		{
		}

		#endregion

	}
}


