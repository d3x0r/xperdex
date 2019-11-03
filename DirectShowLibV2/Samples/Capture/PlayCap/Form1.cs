/****************************************************************************
While the underlying libraries are covered by LGPL, this sample is released 
as public domain.  It is distributed in the hope that it will be useful, but 
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE.  
*****************************************************************************/
//------------------------------------------------------------------------------
// Desc: DirectShow sample code - a very basic application using video capture
//       devices.  It creates a window and uses the first available capture
//       device to render and preview video capture data.
//
// DirectShow Interfaces used : ICaptureGraphBuilder2, IGraphBuilder, 
// IMediaEventEx, IMediaControl, IVideoWindow, IBaseFilter
//
// DirectShowLib helper classes used : DsError, DsROTEntry, DsDevice
//
//------------------------------------------------------------------------------


using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using DirectShowLib;

#if !USING_NET11
using System.Runtime.InteropServices.ComTypes;
using xperdex.classes;
using PlayCap;
#endif

namespace DirectShowLib.Samples
{
	public class Form1 : System.Windows.Forms.Form
	{
		// a small enum to record the graph state
		enum PlayState
		{
			Stopped,
			Paused,
			Running,
			Init,
			TurnedOff,
		};

		// Application-defined message to notify app of filtergraph events
		public const int WM_GRAPHNOTIFY = 0x8000 + 1;

		IVideoWindow videoWindow = null;
		IMediaControl mediaControl = null;
		IMediaEventEx mediaEventEx = null;
		IGraphBuilder graphBuilder = null;
		ICaptureGraphBuilder2 captureGraphBuilder = null;
        IAMGraphStreams graph_streams;
        IMediaFilter graph_filter;
        IReferenceClock ref_clock;
		PlayState currentState = PlayState.Stopped;

		DsROTEntry rot = null;

		int min_channel;
		int max_channel;
		IAMTVTuner tuner = null;
		int volume;
        int channel;
        AMTunerSubChannel sub_channel;
        AMTunerSubChannel sub_channel2;

		IBasicAudio audio_mixer = null;

        FindDevices DeviceFinder = null;

		public Form1()
		{
			Network.Start();
			Network.PositionChange += UpdateStatus;
			Network.ChannelUp += new Network.SimpleEvent( Network_ChannelUp );
			Network.ChannelDown += new Network.SimpleEvent( Network_ChannelDown );
			Network.ChannelSet += new Network.SimpleIntEvent( Network_ChannelSet );
			Network.VolumeUp += new Network.SimpleEvent( Network_VolumeUp );
			Network.VolumeDown += new Network.SimpleEvent( Network_VolumeDown );
			Network.Hide += new Network.SimpleEvent( Network_Hide );
			Network.TurnOn += new Network.SimpleEvent( Network_TurnOn );
			Network.TurnOff += new Network.SimpleEvent( Network_TurnOff );

			this.TransparencyKey = this.BackColor;
			InitializeComponent();

			this.TopMost = true;
			// setting the border style here causes the form to show.
			//this.FormBorderStyle = FormBorderStyle.None;

			this.VisibleChanged += new EventHandler( Form1_VisibleChanged );
			this.ResizeEnd += new EventHandler( Form1_ResizeEnd );
			this.SetTopLevel( true );
			this.Move += new EventHandler( Form1_Move );

            try
            {

                CaptureVideo();
            }
            catch
            {
                Close();
            }
		}

		void Network_TurnOff()
		{
			if( this.InvokeRequired )
			{
				Network.SimpleEvent d = new Network.SimpleEvent( Network_TurnOff );
				this.Invoke( d );
			}
			else
			{
				switch( this.currentState )
				{
				case PlayState.Running:
					int hr = this.mediaControl.Stop();
					DsError.ThrowExceptionForHR( hr );
					currentState = PlayState.TurnedOff;
					break;
				}
			}
		}

		void Network_TurnOn()
		{
			if( this.InvokeRequired )
			{
				Network.SimpleEvent d = new Network.SimpleEvent( Network_TurnOn );
				this.Invoke( d );
			}
			else
			{
				switch( this.currentState )
				{
				case PlayState.Stopped:
				case PlayState.TurnedOff:
					int hr = this.mediaControl.Run();
					DsError.ThrowExceptionForHR( hr );
					currentState = PlayState.Running;
					break;
				}
			}			
			
		}

		void Network_Hide()
		{
			if( this.InvokeRequired )
			{
				Network.SimpleEvent d = new Network.SimpleEvent( Network_Hide );
				this.Invoke( d );
			}
			else
			{
				this.Visible = false;
			}			
		}


		void Network_VolumeDown()
		{
			if( this.InvokeRequired )
			{
				Network.SimpleEvent d = new Network.SimpleEvent( Network_VolumeDown );
				this.Invoke( d );
			}
			else
			{
				if( audio_mixer != null )
				{
					audio_mixer.put_Volume( volume - 500 );
                    audio_mixer.get_Volume( out volume );
					Network.SendStatus( channel, volume, ( this.currentState == PlayState.Running ) );
                }
			}
		}

		void Network_VolumeUp()
		{
			if( this.InvokeRequired )
			{
				Network.SimpleEvent d = new Network.SimpleEvent( Network_VolumeUp );
				this.Invoke( d );
			}
			else
			{
				if( audio_mixer != null )
				{
                    audio_mixer.put_Volume( volume + 500 );
                    audio_mixer.get_Volume( out volume );
					Network.SendStatus( channel, volume, ( this.currentState == PlayState.Running ) );
				}
			}
		}

		void Network_ChannelSet( int new_channel )
		{
			if( this.InvokeRequired )
			{
				Network.SimpleIntEvent d = new Network.SimpleIntEvent( Network_ChannelSet );
                this.Invoke( d, new object[] { new_channel } );
			}
			else
			{
                if( new_channel >= min_channel && new_channel <= max_channel )
                {
                    tuner.put_Channel( new_channel, AMTunerSubChannel.Default, AMTunerSubChannel.Default );
                    tuner.get_Channel( out channel, out sub_channel, out sub_channel2 );
					Network.SendStatus( channel, volume, ( this.currentState == PlayState.Running ) );
                }
			}
			
		}

		void Network_ChannelDown()
		{
			if( this.InvokeRequired )
			{
				Network.SimpleEvent d = new Network.SimpleEvent( Network_ChannelDown );
				this.Invoke( d );
			}
			else
			{
				if( channel == min_channel )
					channel = max_channel;
				else
					channel = channel - 1;
				tuner.put_Channel( channel, AMTunerSubChannel.Default, AMTunerSubChannel.Default );
                tuner.get_Channel( out channel, out sub_channel, out sub_channel2 );
				Network.SendStatus( channel, volume, ( this.currentState == PlayState.Running ) );
            }
		}

		void Network_ChannelUp()
		{
			if( this.InvokeRequired )
			{
				Network.SimpleEvent d = new Network.SimpleEvent( Network_ChannelUp );
				this.Invoke( d );
			}
			else
			{
				if( channel == max_channel )
					channel = min_channel;
				else
					channel = channel + 1;
				tuner.put_Channel( channel, AMTunerSubChannel.Default, AMTunerSubChannel.Default );
                tuner.get_Channel( out channel, out sub_channel, out sub_channel2 );
                Network.SendStatus( channel, volume, (this.currentState==PlayState.Running) );
            }
		}


		void Form1_Move( object sender, EventArgs e )
		{
			this.TopMost = false;
			this.TopMost = true;
		}

		void Form1_ResizeEnd( object sender, EventArgs e )
		{
			this.TopMost = false;
			this.TopMost = true;
		}

		void Form1_VisibleChanged( object sender, EventArgs e )
		{
			this.TopMost = false;
			this.TopMost = true;
		}

	

		delegate void SetPlayerPosition( Int32 x, Int32 y, Int32 w, Int32 h );

		void UpdateStatus( Int32 x, Int32 y, Int32 w, Int32 h )
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if( this.InvokeRequired )
			{
				SetPlayerPosition d = new SetPlayerPosition( UpdateStatus );
				this.Invoke( d, new object[] { x,y,w,h } );
			}
			else
			{
				if( w == 0 || h == 0 )
				{
					this.Visible = false;
				}
				else
				{
					if( !this.Visible )
					{
						this.Visible = true;
					}
					this.Location = new Point( x, y );
					this.Size = new Size( w, h );
					this.TopMost = true;
				}
			}
		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				// Stop capturing and release interfaces
				CloseInterfaces();
				//Network.Stop();
			}

			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
			this.SuspendLayout();
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.ClientSize = new System.Drawing.Size( 429, 251 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "Form1";
			this.Text = "Video Capture Previewer (PlayCap)";
			this.TopMost = true;
			this.Resize += new System.EventHandler( this.Form1_Resize );
			this.ResumeLayout( false );
			this.MouseDown += new MouseEventHandler( Form1_MouseDown );
			this.MouseUp += new MouseEventHandler( Form1_MouseUp );
            this.DeviceFinder = new FindDevices();
		}

		void Form1_MouseUp( object sender, MouseEventArgs e )
		{
			Log.log( "up" );			
		}

		void Form1_MouseDown( object sender, MouseEventArgs e )
		{
			Log.log( "down" );
		}
		#endregion


#if asdfasdf
		int SaveGraphFile(IGraphBuilder pGraph, String wszPath) 
		{
			String wszStreamName = "ActiveMovieGraph"; 
			int hr;
    
			IStorage *pStorage = NULL;
			hr = StgCreateDocfile(
				wszPath,
				STGM_CREATE | STGM_TRANSACTED | STGM_READWRITE | STGM_SHARE_EXCLUSIVE,
				0, &pStorage);
			if(FAILED(hr)) 
			{
				return hr;
			}

			IStream *pStream;
			hr = pStorage->CreateStream(
				wszStreamName,
				STGM_WRITE | STGM_CREATE | STGM_SHARE_EXCLUSIVE,
				0, 0, &pStream);
			if (FAILED(hr)) 
			{
				pStorage->Release();    
				return hr;
			}

			IPersistStream *pPersist = NULL;
			pGraph->QueryInterface(IID_IPersistStream, (void**)&pPersist);
			hr = pPersist->Save(pStream, TRUE);
			pStream->Release();
			pPersist->Release();
			if (SUCCEEDED(hr)) 
			{
				hr = pStorage->Commit(STGC_DEFAULT);
			}
			pStorage->Release();
			return hr;
		}
#endif

#if use_bda
		IBaseFilter bda_filter = null;
#endif
		IBaseFilter sourceFilter = null;
		IBaseFilter sourceAudioFilter = null;
        IBaseFilter reclock_filter = null;
        //IBaseFilter reclock_video_filter = null;
		IBaseFilter scale_filter = null;
		IAMCrossbar crossbar = null;

		public void CaptureVideo()
		{
			int hr = 0;

			try
			{
                int width = INI.Default["DirectShow Player"]["Video Player/Device Source Width", "352"].Integer;
                int Height = INI.Default["DirectShow Player"]["Video Player/Device Source Height", "240"].Integer;
                int fps = INI.Default["DirectShow Player"]["Video Player/Frames Per Second (0 unlimited)", "30"].Integer;
                bool antenna_input = INI.Default[Options.ProgramName]["Video Player/Capture Tuner from antenna", "true"].Bool;
				bool capture_TV = INI.Default[Options.ProgramName]["Video Player/Capture Tuner", "true"].Bool;
                bool capture_is_audio = INI.Default[Options.ProgramName]["Video Player/Capture Video is Audio also", "true"].Bool;
                IPin cap_pin = null;
				IPin cap_audio_pin;

                crossbar_to_tuner = capture_TV;
				// Get DirectShow interfaces
				GetInterfaces();

				// Attach the filter graph to the capture graph
				hr = this.captureGraphBuilder.SetFiltergraph( this.graphBuilder );
				DsError.ThrowExceptionForHR( hr );

				// Use the system device enumerator and class enumerator to find
				// a video capture/preview device, such as a desktop USB video camera.
                sourceFilter = this.DeviceFinder.FindVideoCaptureDevice(false);
				if( sourceFilter == null )
				{
					Network.SendStatus( channel, volume, false );
					return;
				}

#if use_bda
				bda_filter = FindVideoCaptureDevice( true );
#endif

                if( !capture_is_audio )
                    sourceAudioFilter = this.DeviceFinder.FindAudioCaptureDevice();
                else
                    sourceAudioFilter = sourceFilter;
                //reclock_video_filter = FindVideoRenderDevice();

				//scale_filter = FindVideoScaleDevice();
                reclock_filter = this.DeviceFinder.FindAudioRenderDevice();

				IAMAnalogVideoDecoder decoder = sourceFilter as IAMAnalogVideoDecoder;
				if( decoder != null )
				{
					AnalogVideoStandard oldStandard;
					decoder.get_TVFormat( out oldStandard );
					if( oldStandard != AnalogVideoStandard.NTSC_M )
					{
						decoder.put_TVFormat( AnalogVideoStandard.NTSC_M );
					}
					decoder = null;
				}

				// this is really for which input - the tuner we shouldn't adjust
				//if( !capture_TV )

                // Add Capture filter to our graph.
				hr = this.graphBuilder.AddFilter( sourceFilter, "Video Capture" );
				DsError.ThrowExceptionForHR( hr );

				if( scale_filter != null )
				{
					hr = this.graphBuilder.AddFilter( scale_filter, "Video Scaler" );
					DsError.ThrowExceptionForHR( hr );
				}
				this.graphBuilder.Connect( null, null );
#if use_bda
				if( bda_filter != null )
				{
					hr = this.graphBuilder.AddFilter( bda_filter, "Video Tuner" );
					DsError.ThrowExceptionForHR( hr );
				}
#endif

                if( capture_TV && !capture_is_audio )
                {
					if( sourceAudioFilter != null )
					{
						hr = this.graphBuilder.AddFilter( sourceAudioFilter, "Audio Capture" );
						DsError.ThrowExceptionForHR( hr );
					}
                }

				if( reclock_filter != null )
				{
					Log.log( "Adding 'reclock' which is the audio output device?" );
					hr = this.graphBuilder.AddFilter( reclock_filter, "Audio Renderer" );
					DsError.ThrowExceptionForHR( hr );
				}

                //this.graphBuilder.AddFilter( 
				AdjustCrossbarPin();

                bool cap_is_preview;
				{
					// set the video input size on the preview pin.
					cap_audio_pin = DsFindPin.ByCategory( (IBaseFilter)sourceAudioFilter, PinCategory.Preview, 0 );
					cap_pin = DsFindPin.ByCategory( (IBaseFilter)sourceFilter, PinCategory.Preview, 0 );
					if( cap_pin == null )
					{
						cap_is_preview = false;
						cap_audio_pin = DsFindPin.ByCategory( (IBaseFilter)sourceAudioFilter, PinCategory.Capture, 0 );
						cap_pin = DsFindPin.ByCategory( (IBaseFilter)sourceFilter, PinCategory.Capture, 0 );
					}
					else
						cap_is_preview = true;
					//Log.log( "Cap pin + " + cap_pin );
				}

				// Render the preview pin on the video capture filter
				// Use this instead of this.graphBuilder.RenderFile
				if( cap_is_preview )
				{
					//hr = this.captureGraphBuilder.RenderStream( PinCategory.Preview, MediaType.Video, scale_filter, null, null );
					//DsError.ThrowExceptionForHR( hr );
					hr = this.captureGraphBuilder.RenderStream( PinCategory.Preview, MediaType.Video, sourceFilter, null, null );
					DsError.ThrowExceptionForHR( hr );
                    if( sourceAudioFilter != null )
                    {
                        hr = this.captureGraphBuilder.RenderStream( PinCategory.Preview, MediaType.Audio, sourceAudioFilter, null, reclock_filter );
                        DsError.ThrowExceptionForHR( hr );
                    }
                }
				else
				{
					//hr = this.captureGraphBuilder.RenderStream( PinCategory.Capture, MediaType.Video, scale_filter, null, null );
					//DsError.ThrowExceptionForHR( hr );
					hr = this.captureGraphBuilder.RenderStream( PinCategory.Capture, MediaType.Video, sourceFilter, null, null );
					DsError.ThrowExceptionForHR( hr );
                    if( sourceAudioFilter != null )
                    {
                        //IBaseFilter renderer = null;
						//Log.log( "reclock is " + reclock_filter );
                        hr = this.captureGraphBuilder.RenderStream( PinCategory.Capture, MediaType.Audio, sourceAudioFilter, null, reclock_filter );
						if( hr != 0 )
						{
							Log.log( "Bad audio stream" );
						}
                        //DsError.ThrowExceptionForHR( hr );
                    }
                }

                IAMStreamConfig stream = cap_pin as IAMStreamConfig;
                if( stream != null )
                {
                    // 352x240
                    AMMediaType media;
                    VideoInfoHeader vih = new VideoInfoHeader();
                    stream.GetFormat( out media );

                    Marshal.PtrToStructure( media.formatPtr, vih );

                    //vih.BmiHeader.Width = width;
                    //vih.BmiHeader.Height = Height;
                    if( fps > 0 )
                        vih.AvgTimePerFrame = ( 10000000L / fps );

                    //Log.log( "set the bitmap override..." );
                    Marshal.StructureToPtr( vih, media.formatPtr, false );

                    hr = stream.SetFormat( media );
                    if( hr != 0 )
                    {
                        Log.log( "Failed to set format (preview)." + hr );
                    }
                }
                else
                    Log.log( "Failed to get stream config from source filter" );
                //graph_filter.SetSyncSource( ref_clock );
				object o;
                hr = captureGraphBuilder.FindInterface( null, null, sourceFilter, typeof( IReferenceClock ).GUID, out o );
                if( hr == 0 )
                    ref_clock = (IReferenceClock)o;
                if( ref_clock == null )
                {
                    hr = captureGraphBuilder.FindInterface( null, null, sourceAudioFilter, typeof( IReferenceClock ).GUID, out o );
                    ref_clock = (IReferenceClock)o;
                }

				hr = captureGraphBuilder.FindInterface( null, null, sourceFilter, typeof( IAMTVTuner ).GUID, out o );

				//graphBuilder.sa.

				if( hr >= 0 )
				{
					tuner = (IAMTVTuner)o;
					o = null;
				}
				if( tuner != null )
				{
					if( antenna_input )
					{
						TunerInputType type;
						hr = tuner.get_InputType( 0, out type );
						if( type != TunerInputType.Antenna )
						{
							tuner.put_InputType( 0, TunerInputType.Antenna );
							hr = tuner.get_InputType( 0, out type );
						}
					}
					else
					{
						if( tuner != null )
						{
							TunerInputType type;
							hr = tuner.get_InputType( 0, out type );
							if( type != TunerInputType.Cable )
							{
								tuner.put_InputType( 0, TunerInputType.Cable );
								hr = tuner.get_InputType( 0, out type );
							}
						}
					}
					tuner.ChannelMinMax( out min_channel, out max_channel );
					min_channel = INI.Default["DirectShow Player"]["Video Player/Minimum Channel", min_channel.ToString()].Integer;
					max_channel = INI.Default["DirectShow Player"]["Video Player/Maximum Channel", max_channel.ToString()].Integer;
				}
				// Now that the filter has been added to the graph and we have
				// rendered its stream, we can release this reference to the filter.

                if( sourceAudioFilter != null )
                {
                    //hr = captureGraphBuilder.FindInterface( null, null, sourceFilter, typeof( IAMTVAudio ).GUID, out o );
                    hr = captureGraphBuilder.FindInterface( null, null, sourceAudioFilter, typeof( IBasicAudio ).GUID, out o );
                    if( hr >= 0 )
                    {
                        audio_mixer = (IBasicAudio)o;
                        o = null;
                    }
                }

				Marshal.ReleaseComObject( sourceFilter );

                if( audio_mixer != null )
                {
                    audio_mixer.get_Volume( out volume );
                }
                if( tuner != null )
                {
                    tuner.get_Channel( out channel, out sub_channel, out sub_channel2 );
                }


                //this.graphBuilder.SetDefaultSyncSource();
                if( ref_clock != null )
                    this.graph_filter.SetSyncSource( ref_clock );
                graph_streams.SyncUsingStreamOffset( true );

                // Set video window style and position
				SetupVideoWindow();

				// Add our graph to the running object table, which will allow
				// the GraphEdit application to "spy" on our graph
				rot = new DsROTEntry( this.graphBuilder );

                //this.mediaControl.set
				// Start previewing video data
				hr = this.mediaControl.Run();
				DsError.ThrowExceptionForHR( hr );

				// Remember current state
				this.currentState = PlayState.Running;

				Network.SendStatus( channel, volume, ( this.currentState == PlayState.Running ) );
			}
			catch( Exception e )
			{
				MessageBox.Show( "An unrecoverable error has occurred : " + e.Message );
				this.DialogResult = DialogResult.Abort;
				this.Close();
				Application.Exit();
			}
		}

		void AdjustSourceSettings()
		{
			object o;
			int hr = captureGraphBuilder.FindInterface(
			PinCategory.Capture, MediaType.Video, sourceFilter, typeof( VideoInfoHeader2 ).GUID, out o );

			if( hr >= 0 )
			{
			}
		}

        bool crossbar_to_tuner;

		void AdjustCrossbarPin()
		{
			crossbar = null;
			object o = null;
			int hr;

			hr = captureGraphBuilder.FindInterface( PinCategory.Capture, MediaType.Video, sourceFilter, typeof( IAMCrossbar ).GUID, out o );

			if( hr >= 0 )
			{
				crossbar = (IAMCrossbar)o;

				int numOutPin, numInPin;
				int nOutputAudioLink, nInputAudioLink, nOutputVideoLink, nInputVideoLink;
				nOutputAudioLink = nInputAudioLink = nOutputVideoLink = nInputVideoLink = -1;
				crossbar.get_PinCounts( out numOutPin, out numInPin );
				int pIdxRel;
				PhysicalConnectorType pct;
				for( int i = 0; i < numInPin; i++ )
				{
					crossbar.get_CrossbarPinInfo( true, i, out pIdxRel, out pct );

					Log.log( pct.ToString() );

					if( crossbar_to_tuner )
					{
						if( pct == PhysicalConnectorType.Video_Tuner ) nInputVideoLink = i;
					}
					else
					{
						if( pct == PhysicalConnectorType.Video_Composite ) nInputVideoLink = i;
					}
					if( nInputAudioLink != -1 && nInputVideoLink != -1 ) break;
				}
				for( int i = 0; i < numOutPin; i++ )
				{
					crossbar.get_CrossbarPinInfo( false, i, out pIdxRel, out pct );
					Log.log( pct.ToString() );

					//if (pct == PhysicalConnectorType.Audio_AudioDecoder) nOutputAudioLink = i; 
					if( pct == PhysicalConnectorType.Video_VideoDecoder ) nOutputVideoLink = i;
					if( nOutputAudioLink != -1 && nOutputVideoLink != 1 ) break;
				}

				try
				{
					if( crossbar.Route( nOutputVideoLink, nInputVideoLink ) >= 0 )
					{
						Log.log( "Success set crossbar" );
						o = null;
					}
					else
					{
						o = null;
					}
				}
				catch
				{
					o = null;
				}
			}
			else
			{
				Log.log( "No Crossbar" );
			}
		}

		/*
		// This version of FindCaptureDevice is provide for education only.
		// A second version using the DsDevice helper class is define later.
		public IBaseFilter FindCaptureDevice()
		{
			int hr = 0;
#if USING_NET11
      UCOMIEnumMoniker classEnum = null;
      UCOMIMoniker[] moniker = new UCOMIMoniker[1];
#else
			IEnumMoniker classEnum = null;
			IMoniker[] moniker = new IMoniker[1];
#endif
			object source = null;

			// Create the system device enumerator
			ICreateDevEnum devEnum = (ICreateDevEnum)new CreateDevEnum();

			// Create an enumerator for the video capture devices
			hr = devEnum.CreateClassEnumerator( FilterCategory.VideoInputDevice, out classEnum, 0 );
			DsError.ThrowExceptionForHR( hr );

			// The device enumerator is no more needed
			Marshal.ReleaseComObject( devEnum );

			// If there are no enumerators for the requested type, then 
			// CreateClassEnumerator will succeed, but classEnum will be NULL.
			if( classEnum == null )
			{
				throw new ApplicationException( "No video capture device was detected.\r\n\r\n" +
											   "This sample requires a video capture device, such as a USB WebCam,\r\n" +
											   "to be installed and working properly.  The sample will now close." );
			}

			// Use the first video capture device on the device list.
			// Note that if the Next() call succeeds but there are no monikers,
			// it will return 1 (S_FALSE) (which is not a failure).  Therefore, we
			// check that the return code is 0 (S_OK).
#if USING_NET11
      int i;
      if (classEnum.Next (moniker.Length, moniker, IntPtr.Zero) == 0)
#else
			while( classEnum.Next( moniker.Length, moniker, IntPtr.Zero ) == 0 )
#endif
			{
				// Bind Moniker to a filter object
				Guid iid = typeof( IBaseFilter ).GUID;
				moniker[0].BindToObject( null, null, ref iid, out source );
			}
			//else
			//{
			//	throw new ApplicationException( "Unable to access video capture device!" );
			//}

			// Release COM objects
			Marshal.ReleaseComObject( moniker[0] );
			Marshal.ReleaseComObject( classEnum );

			// An exception is thrown if cast fail
			return (IBaseFilter)source;
		}
		*/
			// Uncomment this version of FindCaptureDevice to use the DsDevice helper class
			// (and comment the first version of course)




			public void GetInterfaces()
		{
			int hr = 0;

			// An exception is thrown if cast fail
			this.graphBuilder = (IGraphBuilder)new FilterGraph();
			this.captureGraphBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
			this.mediaControl = (IMediaControl)this.graphBuilder;
			this.videoWindow = (IVideoWindow)this.graphBuilder;
			this.mediaEventEx = (IMediaEventEx)this.graphBuilder;
            this.graph_streams = (IAMGraphStreams)this.graphBuilder;
            this.graph_filter = (IMediaFilter)this.graphBuilder;

			hr = this.mediaEventEx.SetNotifyWindow( this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero );
			DsError.ThrowExceptionForHR( hr );
		}

		public void CloseInterfaces()
		{
			// Stop previewing data
			if( this.mediaControl != null )
				this.mediaControl.StopWhenReady();

			this.currentState = PlayState.Stopped;

			// Stop receiving events
			if( this.mediaEventEx != null )
				this.mediaEventEx.SetNotifyWindow( IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero );

			// Relinquish ownership (IMPORTANT!) of the video window.
			// Failing to call put_Owner can lead to assert failures within
			// the video renderer, as it still assumes that it has a valid
			// parent window.
			if( this.videoWindow != null )
			{
				this.videoWindow.put_Visible( OABool.False );
				this.videoWindow.put_Owner( IntPtr.Zero );
			}


			// Remove filter graph from the running object table
			if( rot != null )
			{
				rot.Dispose();
				rot = null;
			}

			if( tuner != null )
			{
				Marshal.ReleaseComObject( tuner );
				tuner = null;
			}
			// Release DirectShow interfaces
			Marshal.ReleaseComObject( this.mediaControl ); this.mediaControl = null;
			Marshal.ReleaseComObject( this.mediaEventEx ); this.mediaEventEx = null;
			Marshal.ReleaseComObject( this.videoWindow ); this.videoWindow = null;
			Marshal.ReleaseComObject( this.graphBuilder ); this.graphBuilder = null;
			Marshal.ReleaseComObject( this.captureGraphBuilder ); this.captureGraphBuilder = null;
		}

		public void SetupVideoWindow()
		{
			int hr = 0;

			// Set the video window to be a child of the main window
			hr = this.videoWindow.put_Owner( this.Handle );
			DsError.ThrowExceptionForHR( hr );

			hr = this.videoWindow.put_WindowStyle( WindowStyle.Child | WindowStyle.ClipChildren );
			//hr = this.videoWindow.put_WindowStyle( 0 );//WindowStyle. | WindowStyle.ClipChildren );
			DsError.ThrowExceptionForHR( hr );

			WindowStyleEx wsex;
			this.videoWindow.get_WindowStyleEx( out wsex );
			wsex |= WindowStyleEx.Transparent;
			this.videoWindow.put_WindowStyleEx( wsex );
			
			// Use helper function to position video window in client rect 
			// of main application window
			ResizeVideoWindow();

			// Make the video window visible, now that it is properly positioned
			hr = this.videoWindow.put_Visible( OABool.True );
			DsError.ThrowExceptionForHR( hr );

						//this.TopMost = true;
			// setting the border style here causes the form to show.
			this.FormBorderStyle = FormBorderStyle.None;
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20;// WindowStyleEx.Transparent; //WS_EX_TRANSPARENT
				return cp;
			}
		}
 
 		public void ResizeVideoWindow()
		{
			// Resize the video preview window to match owner window size
			if( this.videoWindow != null )
			{
				this.videoWindow.SetWindowPosition( 0, 0, this.ClientSize.Width, this.ClientSize.Height );
			}
		}

		public void ChangePreviewState( bool showVideo )
		{
			// this is a new feature, if it's off, don't turn it on.
			if( this.currentState == PlayState.TurnedOff )
				return;

			int hr = 0;
			
			// If the media control interface isn't ready, don't call it
			if( this.mediaControl == null )
				return;

			if( showVideo )
			{
				if( this.currentState != PlayState.Running )
				{
					// Start previewing video data
					hr = this.mediaControl.Run();
					this.currentState = PlayState.Running;
				}
			}
			else
			{
				// Stop previewing video data
				hr = this.mediaControl.StopWhenReady();
				this.currentState = PlayState.Stopped;
			}
		}

		public void HandleGraphEvent()
		{
			int hr = 0;
			EventCode evCode;
			IntPtr evParam1, evParam2;

			if( this.mediaEventEx == null )
				return;

			while( this.mediaEventEx.GetEvent( out evCode, out evParam1, out evParam2, 0 ) == 0 )
			{

				// Free event parameters to prevent memory leaks associated with
				// event parameter data.  While this application is not interested
				// in the received events, applications should always process them.
				hr = this.mediaEventEx.FreeEventParams( evCode, evParam1, evParam2 );
				DsError.ThrowExceptionForHR( hr );

				// Insert event processing code here, if desired
			}
		}

		protected override void WndProc( ref Message m )
		{
			//Log.log( "Recieve " + m.Msg );
			switch( m.Msg )
			{
			case WM_GRAPHNOTIFY:
				{
					HandleGraphEvent();
					break;
				}
			}

			// Pass this message to the video window for notification of system changes
			if( this.videoWindow != null )
				this.videoWindow.NotifyOwnerMessage( m.HWnd, m.Msg, m.WParam, m.LParam );

			base.WndProc( ref m );
		}

		private void Form1_Resize( object sender, System.EventArgs e )
		{
			// Stop graph when Form is iconic
			if( this.WindowState == FormWindowState.Minimized )
				ChangePreviewState( false );

			// Restart Graph when window come back to normal state
			if( this.WindowState == FormWindowState.Normal )
				ChangePreviewState( true );

			ResizeVideoWindow();
		}

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            Form1 form = new Form1();
            if( !form.IsDisposed )
			    Application.Run( form );
		}

	}
}
