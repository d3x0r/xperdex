using System;
using System.Collections.Generic;
using System.Text;

namespace Body
{
	public class Class1
	{
			PLIST gliders = NULL;
	PLIST cycles = NULL;
	PLIST bodies = NULL;

class Radar 
	{
	// need to find the defualts for the brain.ss
	NATIVE power; // 0-256 I guess... 
	NATIVE turn;
	NATIVE current_angle;
	NATIVE nearest;
	//connector *motion[4];
	//PBRAIN_STEM brainstem; // connectors to the body
	void Tick( void )
	{
		//DebugBreak();
		current_angle += ( turn / 8.0 );
		if( current_angle > 256.0 )
			current_angle -= 512.0;
		if( current_angle < -256.0 )
			current_angle += 512.0;
	}
	void CreateRadar( PBRAIN_STEM add_to_brainstem )
	{
		static int n;
		char buffer[16];

		/* make a timer to call tick callback with this parameter....*/
		/* this is a total hack, and works under MSVC only, so far. */
		{
			union {
				void  (__thiscall Radar::*Tickx)( void );
				void CPROC (*Ticky)( PTRSZVAL );
			} cast_f;
			cast_f.Tickx = &Radar::Tick;
			AddTimer( 10, cast_f.Ticky, (PTRSZVAL)this );
		}



		if( add_to_brainstem )
		{
			int n;
			PBRAIN_STEM check_stem;
			for( n = 0; n < 24; n++ )
			{
				snprintf( buffer, sizeof( buffer ), "radar %d", n+1 );
				for( check_stem = add_to_brainstem.first_module(); 
						check_stem; 
						check_stem = add_to_brainstem.next_module() )
				{
					if( StrCmp( check_stem.name(), buffer ) == 0 )
						break;
				}
				if( !check_stem )
					break;
			}
		}
		else
		{
			snprintf( buffer, sizeof( buffer ), "radar %d", ++n );
		}
		brainstem = new BRAIN_STEM( buffer );
		power = 256;
		motion[0] = new connector( "power", &power );
		turn = 0;
		motion[1] = new connector( "turn", &turn );
		current_angle = 0;
		motion[2] = new connector( "angle", &current_angle );
		nearest = 0;
		motion[3] = new connector( "nearest", &nearest );
		brainstem.AddOutput( motion[0] );
		brainstem.AddOutput( motion[1] );
		brainstem.AddInput( motion[2] );
		brainstem.AddInput( motion[3] );
		if( add_to_brainstem )
			add_to_brainstem.AddModule( brainstem );
	}
public:
	Radar( PBRAIN_STEM add_to_brainstem )
	{
		CreateRadar( add_to_brainstem );
	}
	Radar()
	{
		CreateRadar( NULL );
	}
};


struct position_history {
	_POINT origin;
	_POINT up;
	_POINT right;
};

typedef class Body BODY, *PBODY;
class Body
{
public:
	DeclareLink( class Body );
	POBJECT object;
	PBRAIN_STEM brainstem; // connectors to the body
	PBRAIN brain;
	PBRAINBOARD board; 

	// these are 256 to 0 range.
	NATIVE speed, rotation; 
	PCONNECTOR motion[2];
	Radar *radars[3]; // need at least 3... offset on body.
	Body( POBJECT body_object )
	{
		int n;
		next = NULL;
		me = NULL;
		board = NULL;
		object = body_object;
		brainstem = new BRAIN_STEM( "body" );
		motion[0] = new CONNECTOR( "forward", &speed );
		motion[1] = new CONNECTOR( "turn", &rotation );
		brainstem.AddOutput( motion[0] );
		brainstem.AddOutput( motion[1] );
		for( n = 0; n < 3; n++ )
			radars[n] = new Radar( brainstem );
		brain = new BRAIN( brainstem );
	}

	virtual void Move( void )
	{
      /* update position, already must be setup...*/
		sack::math::vector::Move( object.Ti );
      /* correct position to sphere boundry */
		{
			VECTOR vertical;
			GetOriginV( object.Ti, vertical );
			Invert( vertical );
			RotateMast( object.Ti, vertical );
			normalize( vertical );
			scale( vertical, vertical, (-SPHERE_SIZE*0.99) );
			{
				VECTOR force;
				sub( force, GetOrigin( object.Ti ), vertical );
				//if( Length( force ) > 1.0 )
				//	DebugBreak();
				//lprintf( "Force vector is %g", Length( force ) );
				TranslateV( object.Ti, vertical );
				{
					int s, x, y;
					ConvertToSphereGrid( vertical, &s, &x, &y );
					//PrintVector( vertical );
					//lprintf( "Body at sphere part %d,%d,%d", s, x, y );
					UnlinkThing( this );
					LinkThing( bodymap.band[s][x][y], this );
				}
			}
		}
	}
	virtual	void Draw( void )
	{
	}

};

class Glider:public Body
{
public:
	GL.glider( POBJECT object ):Body(object)
	{
	}
	void Move( void )
	{
		Body::Move();
		if( ( ( rand() & 0xFF ) > 0xF0 ) )
		{

			if( ( rand() & 0xFF ) > 0x80 )
			{
				RotateAroundMast( object.Ti, (float)rand() / 600000.0 );
			}
			else
				RotateAroundMast( object.Ti, (float)rand() / -600000.0 );
		}
	}
};

class CyberCycle:public Body
{
	struct {
		BIT_FIELD turn_left : 1;
		BIT_FIELD turn_right : 1;
		BIT_FIELD turned_left : 1;
		BIT_FIELD turned_right : 1;
		BIT_FIELD started : 1;
	} flags;
	_32 portion_to_turn; // 360/portion
	PCONNECTOR motion[2];
	struct position_history pos;
	PDATAQUEUE position_history; // struct position_history queue
public:
	CyberCycle( POBJECT body_object ):Body(body_object)
	{
      //DebugBreak();
      position_history = CreateLargeDataQueueEx( sizeof( struct position_history ), 500, 2500 DBG_SRC );
		//motion[0] = new CONNECTOR( "right", &speed );
		//motion[1] = new CONNECTOR( "left", &rotation );
      //motion[2] = new CONNECTOR( "forward_distance", &rotation );
	}
	void Reset( void )
	{
		flags.started = 0;
      //
		//EmptyDataQueue( position_history );
		//
      position_history.Top = position_history.Bottom = 0;
	}
	void RightTurnClyde( int yes )
	{
		if( yes )
		{
			if( !flags.turn_right )
				flags.turn_right = 1;
		}
		else
			if( flags.turn_right )
			{
            flags.turned_right = 0;
				flags.turn_right = 0;
			}
	}
	void LeftTurnClyde( int yes )
	{
		if( yes )
		{
			if( !flags.turn_left )
				flags.turn_left = 1;
		}
		else
			if( flags.turn_left )
			{
				flags.turned_left = 0;
				flags.turn_left = 0;
			}
	}
	void Move( void )
	{
		/* override default move so we can look at left/right turn status */
		if( ( ( rand() & 0xFF ) > 0xF0 ) )
		{
			if( ( rand() & 0xFF ) > 0x80 )
			{
				LeftTurnClyde( TRUE );
			}
			else
				RightTurnClyde( TRUE );
		}
		else
		{
			LeftTurnClyde( 0 );
			RightTurnClyde(0);
		}
		if( flags.started )
		{
			//PrintVector( pos.origin );
			EnqueData( &position_history, &pos );
		}
		if( flags.turn_left && !flags.turned_left )
		{
			//RotateAroundMast( object.Ti, -M_PI/2 );
			RotateAroundMast( object.Ti, -M_PI/10 );
		}
		if( flags.turn_right && !flags.turned_right )
		{
			//RotateAroundMast( object.Ti, M_PI/2 );
			RotateAroundMast( object.Ti, M_PI/10 );
		}
		Forward( object.Ti, 10.0 );
		Body::Move();
		GetOriginV( object.Ti, pos.origin );
		GetAxisV( object.Ti, pos.up, vUp );
		GetAxisV( object.Ti, pos.right, vRight );
		flags.started = 1;
	}
	void Draw( void )
	{
		if( flags.started )
		{
			struct position_history curpos;
			INDEX idx = 0;
			VECTOR v;
			GL.gl.glBegin( GL_QUAD_STRIP );
			GL.gl.glColor3d( 1.0, 0.0, 1.0 );
			for( idx = 256;PeekDataQueueEx( &position_history, struct position_history, &curpos, idx ); ) 
				DequeData( &position_history, NULL );
			for( idx = 0; PeekDataQueueEx( &position_history, struct position_history, &curpos, idx ); idx++ )
			{
				//PrintVector( curpos.origin );
				GL.gl.glVertex3dv( curpos.origin );
				addscaled( v, curpos.origin, curpos.up, 20.0 );
				//PrintVector( v );
				GL.gl.glVertex3dv( v );
			}
			//PrintVector( pos.origin );
			GL.gl.glVertex3dv( pos.origin );
			addscaled( v, pos.origin, pos.up, 20.0 );
			GL.gl.glVertex3dv( v );
			GL.gl.glEnd();
         /*
			GL.gl.glBegin( GL_LINE_STRIP );
         glColor3d( 1.0, 1.0, 1.0 );
			for( idx = 0; PeekDataQueueEx( &position_history, &curpos, idx ); idx++ )
			{
            glVertex3dv( curpos.origin );
			}
			GL.gl.glVertex3dv( pos.origin );
			GL.gl.glEnd();
         */
		}
	}
};


	}
}
