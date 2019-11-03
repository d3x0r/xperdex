using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using xperd3x.virtuality;
using OpenGL;

namespace ParticleBoy
{
	public partial class BodyViewer : OpenGL.BaseGLControl
	{

		Transform T_camera = new Transform();
		double[] m = new double[16];

		Timer move_timer;

		public BodyViewer()
		{
			InitializeComponent();
			move_timer = new Timer();
			move_timer.Interval = 50;
			move_timer.Tick += new EventHandler( move_timer_Tick );
			Render += new OnRender( BodyViewer_Render );

			move_timer.Start();
		}

		void move_timer_Tick( object sender, EventArgs e )
		{
			T_camera.Move();
			Refresh();
		}


		void DrawLine( Vector3 p, Vector3 m, float t1, float t2, Color c )
		{
			float[] vec_c = new float[] { c.R, c.G, c.B, c.A };
			Vector3 v1, v2;
			GL.glBegin( GL.GL_LINES );
			GL.glColor4fv( vec_c );
			GL.glVertex3dv( (m * t1 + p).Array );
			GL.glVertex3dv( (m * t2 + p).Array );
			GL.glEnd();
		}

		void DrawOriginAxis()
		{
			DrawLine( Vector3.origin, Vector3.xAxis, 0, 1, Color.Red );
			DrawLine( Vector3.origin, Vector3.yAxis, 0, 1, Color.Green );
			DrawLine( Vector3.origin, Vector3.zAxis, 0, 1, Color.Blue );
		}

		void BodyViewer_Render( PaintEventArgs e )
		{
			GL.glMatrixMode( GL.GL_MODELVIEW );							// Select The Modelview Matrix
			T_camera.GetGLMatrix( m );
			GL.glLoadMatrixd( m );

			DrawOriginAxis();
		}

		protected override void InitializeGL( object sender, EventArgs e )
		{
			base.InitializeGL( sender, e );
		}

		protected override void ResizeGL( object sender, EventArgs e )
		{
			base.ResizeGL( sender, e );
		}

		protected override void OnKeyDown( System.Windows.Forms.KeyEventArgs e )
		{
			if( e.KeyCode == System.Windows.Forms.Keys.A )
			{
				T_camera.TurnLeft( 0.01 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.D )
			{
				T_camera.TurnRight( 0.01 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.W )
			{
				T_camera.Forward( 1.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.S )
			{
				T_camera.Forward( -1.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.R )
			{
				T_camera.TurnUp( -0.01 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.F )
			{
				T_camera.TurnUp( 0.01 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.Q )
			{
				T_camera.RollLeft( 0.01 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.E )
			{
				T_camera.RollRight( 0.01 );
				e.Handled = true;
			}
			if( !e.Handled )
				base.OnKeyDown( e );
		}
		protected override void OnKeyUp( System.Windows.Forms.KeyEventArgs e )
		{
			if( e.KeyCode == System.Windows.Forms.Keys.A )
			{
				T_camera.TurnLeft( 0.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.D )
			{
				T_camera.TurnRight( 0.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.W )
			{
				T_camera.Forward( 0.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.S )
			{
				T_camera.Forward( 0.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.Q )
			{
				T_camera.RollLeft( 0.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.E )
			{
				T_camera.RollLeft( 0.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.R )
			{
				T_camera.TurnUp( 0.0 );
				e.Handled = true;
			}
			if( e.KeyCode == System.Windows.Forms.Keys.F )
			{
				T_camera.TurnUp( 0.0 );
				e.Handled = true;
			}
			if( !e.Handled )
				base.OnKeyDown( e );
		}

	
	}
}
