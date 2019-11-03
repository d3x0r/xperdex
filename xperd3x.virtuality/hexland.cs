using System;
using OpenTK.Graphics.OpenGL;
using xperdex.classes;
using xperdex.core.interfaces;
using OpenTK;
//using Microsoft.WindowsMobile.DirectX;


namespace xperd3x.virtuality
{
    public class hexland : GameWindow, IReflectorCanvas 
    {
		bool created_as_control;
		private System.Windows.Forms.Timer MoveupdateTimer = new System.Windows.Forms.Timer();	//Refresh  timer
		private System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();  //Refresh  timer
        private System.Windows.Forms.Timer drawTimer = new System.Windows.Forms.Timer();	//Refresh  timer

        public hexland()
        {
			created_as_control = false;
            InitBand();
            InitPole();
            drawTimer.Interval = 33;
            //drawTimer.Tick += new EventHandler( hexland_Render );
            drawTimer.Start();
            updateTimer.Interval = 33;
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Start();
			MoveupdateTimer.Interval = 10;
			MoveupdateTimer.Tick += new EventHandler( MoveupdateTimer_Tick );
			MoveupdateTimer.Start();

            base.KeyDown += Hexland_KeyDown;
            base.KeyUp += Hexland_KeyUp;
			//Render += new OnRender( hexland_Render );

        }

        protected override void OnRenderFrame( FrameEventArgs e )
        {
            hexland_Render( e );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (updateTimer != null)		//Close refresh timer
                {
                    updateTimer.Stop();
                    updateTimer.Dispose();
                    updateTimer = null;
                }
            }
            base.Dispose(disposing);
        }
		/// <summary>
		/// When the timer fires, refresh control
		/// </summary>
		//Microsoft.VisualBasic.Devices.Computer comp = new Microsoft.VisualBasic.Devices.Computer();
		private void updateTimer_Tick( object sender, EventArgs e )
		{
			//Microsoft.VisualBasic.Devices.Keyboard keys;
			//Microsoft.VisualBasic.Devices.Keyboard
			if( T_camera != null )
			{
				T_camera.Move();
				//T_camera.RotateRel( 0, 0.05, 0.005 );
				Invalidate();
			}
		}
		/// <summary>
		/// When the timer fires, refresh control
		/// </summary>
		//Microsoft.VisualBasic.Devices.Computer comp = new Microsoft.VisualBasic.Devices.Computer();
		private void MoveupdateTimer_Tick( object sender, EventArgs e )
		{
			//Microsoft.VisualBasic.Devices.Keyboard keys;
			//Microsoft.VisualBasic.Devices.Keyboard
			if( T_camera != null )
			{
				T_camera.Move();
			}
		}
		//#include <brain.hpp>
        //#include <../board/brainshell.hpp>

        //#include <psi.h>
        //#include <virtuality/view.h>
        //#include <GL/gl.h>
        //#include <GL/glu.h>

        const double SQRT3_OVER_2 = 1.7320508075688772935274463415059 / 2;
        const double M_PI = Math.PI;
        // divisions...
        const int HEX_SIZE = 15;

        // equitoral circumferance
        //
        // 24,901.55 miles (40,075.16 kilometers).
        // 131480184 ft			p
        // 40075160 m
        //  6378159.7555797717226664788383706m radius
        //
        // right now 640 is the hex scale, would take
        // 31308.71875 hexes to span the earth

        // 111319.88888888888888888888888889   m per degree
        // 1739.3732638888888888888888888889 m per 64th of a full hex/degree


        // kilometer scale... 1:1m
        //const double PLANET_CIRCUM ((6378*6.28318)*(1000.0))
        // kilometer scale... 1:1km
        const double PLANET_CIRCUM = (6378 * 6.28318); //*(1000.0))
        // 10 kilometer scale  1:10km
        //const double PLANET_CIRCUM (637.8*6.28318) //*(1000.0))
        //const double PLANET_CIRCUM ((40075.16)*(1000.0))

        const double PLANET_M_PER_ = ((PLANET_CIRCUM) / (6.0));


        const double PLANET_M_PER_DEG = ((PLANET_CIRCUM) / (360.0));
        const double PLANET_M_PER_MAJORHEX = ((PLANET_M_PER_DEG) / HEX_SIZE);

        const double PLANET_RADIUS = ((PLANET_CIRCUM) / (6.283185307179586476925286766559));
        const double HEIGHT_AT_1_DEGREE = (PLANET_RADIUS * 0.000038076935828711262644835174);

        // sin = opp / hyp
        // cos = adj / hyp

        // 51492.623774494753828625694911041meters
        //   242.86077971847967959579546315942
        //
        //
        //
        // 360 hexes around, in at least 3 directions, which mate
        // at 180x180x180
        // there is a sequence of hexes that map this...
        //                                           ,
        //                                      ,
        //        ,                          ,
        //            ,                   ,
        //        .      ,             ,
        //            .      ,      ,                                level + 1 = legnth of edge = 60(180/3)
        //        7      .       ,                                     // so actually level 59 is the magic number
        //
        //   19       8      .   ,                                 1           0
        //18      1       9                                           6  1*6    1
        //    6       2      .   ,                                 12    2*6    2
        //16      0      10                      .                   18  3*6    3
        //    5       3      .   ,                                   24  4*6    4
        //15      4      11                                              5*6
        //   14      12      .   ,                                    so at what stage is it 180?
        //                                                           // 30 ... so only 30 out becomes the full circumferance... but I still have to go 150
        //.      13       .      ,                                              ,     ,
        //    .       .       ,     ,                                        ,     ,     ,
        //        .       ,   13       ,
        /////         ,     7    8  14    ,                                  ,     ,     ,
        //        ,      19  1  2            ,                            ,     ,     ,     ,
        //              12 4      3 9           ,
        //               17  5  6   15             ,                      ,     ,     ,     ,
        //                  11   10                   ,                      ,     ,     ,
        //                     16
        //                                                                   ,     ,     ,
        //                                                                      ,     ,
        //
        //
        //.      13       .      ,                                      q ,     ,     ,
        //    .       .       ,     ,                                  ,     ,     ,     ,
        //        .       ,   13       ,                              r 2 a
        /////         ,     7    8  14    ,                            ,    1,     ,     ,
        //        ,      19  1  2            ,                            ,     ,     ,     ,
        //              12 4      3 9           ,                                1 a
        //               17  5  6   15             ,                      ,     ,    2,     ,
        //                  11   10                   ,                      ,     ,     , q
        //                     16                                                     r
        //                                                                   ,     ,     ,
        //                                                                      ,     ,
        //


        /*
         *
         *                                         sqrt(3)/2  = 1                     .
         *                                                                        _,     ,_
         *                                                                      ,/    ,    \,
         *                                                                   .  |     |     |  .
        //.      13       .      ,                                              ,     ,     ,
        //    .       .       ,     ,                                        ,     ,     ,     ,
        //        .       ,   13       ,                                    /|     |  .  |     |\
        /////         ,     7    8  14    ,                                 \,     ,     ,     ,/
        //        ,      19  1  2            ,                                  ,     ,     ,
        //              12 4      3 9           ,                            .  |     |     |  .
        //               17  5  6   15             ,                            ,     ,     ,
        //                  11   10                   ,                          \_,     ,_/
         *                                                                            .
         *
         *
         *
         *


         the length of each section at the equator

        40075160
         6679193.3333333333333333333333333
                .
             .     .
                 ____
             .   \ .
         *      . \                                sqrt(3)/2  = 1                     .
         *                                                  .   .                  ,     ,
         *                                               .   \ /   .            ,     ,     ,
         *                                          .     \   .   /          .  |     |     |  .
        //.      13       .      ,               .     .___.     .___.          ,     ,     ,
        //    .       .       ,     ,               *  |   |  *  |   |             ,     ,
        //        .       ,   13       ,         .     .___.     .___.            /|  .  |\
        /////         ,     7    8  14    ,         .     /   .   \               \,     ,/
        //        ,      19  1  2            ,           .   / \   .            ,     ,     ,
        //              12 4      3 9           ,           .   .            .        |     |  .
        //               17  5  6   15             ,                            ,     ,     ,
        //                  11   10                   ,                            ,     ,
         *                                                                            .
         *
         *
         *
         *
         *
         *
         *                                              ___
            //                                          | x |   .
            //                                       / \ ___  /  \
            //                                       \y /\  /\ x
            //                                        \/___/_2\/  ...
            //                                        /\  /\  /\  ...
            //                                       /y \___\/ y\
            //                                       \ /   x  \./
            //                                          |___|
         *
         *            \_\_\_\_\_\_\_\
         *             \_\_\_\_\_\_\_\
         *              \_\_\_\_\_\_\_\
         *               \ \ \ \ \ \ \ \
         *               _ _____________
         *              _ / ___________                 ___
            //          _ / / _________                 | x |   .
            //         _ / / / _______               / \ ___  /  \
            //        _ / / / / _____                \y /\  /\ x
            //       _ / / / / / ___                  \/___/_2\/  ...
            //      _ / / / / / / _                   /\  /\  /\  ...
            //       / / / / / / / .                 /y \___\/ y\
            //                                       \ /   x  \./
            //                                          |___|
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         *
         */





        //double height[3,60,60];
        // resoution of 111.31km
        // 111319.88888888888888888888888889
        // 64 1739.3732638888888888888888888889
        // 64 27.177707248263888888888888888889
        // 27
        // and still this, this is like 1.7m resolution
        //double height[3,64,64]; // 360 / 6 = 60 degrees... (not 64?)

        // this hexpatch is mapped differently...

        // a hex patch is 3 sets of squares..
        //
        // radial mapping here...
        // it is produced with level, r
        // where level is 0-hexsize from center to outside.
        // r is a counter clockwise rotation from zero to 120 degrees in hex_size total intervals
        // land hex
        //     x - zero at origin. y zero at origin.
        //    ___
        // y / 0 /\ y - zero at origin y at origin
        //  /___/+1\    ...
        //  \ +2\  /    ...
        // x \___\/ x
        //  3l y
        //
        //  edge from zero degrees is section 0, axis y
        //  edge from 60 degrees is section 0 axis hesize-x
        // building the map of coordinates results in differnet 'nearness' constants...
        //

        // level, R is near
        // so along the way one bit is dropped, but then the average geometry is
        // square, but there is a slow migration towards being diagonal... 45 degrees almost.

        struct rowcol
        {
            public int r, c;
        }
        struct area_coord
        {
            public int s, x, y; // sectory, x, y;
            public override string ToString()
            {
                return string.Format("area_coord({0},{1},{2})", s, x, y);
            }
        }

		/// <summary>
		/// hey this does soemthing useful?
		/// </summary>
        class world_height_map
        {
            // 6 hexpatches which are 60 units wide.
            // 3 mate together for a length of 180 between any two centers
            // 6 poles, 3 pair 180 apart... it works, I don't quite get it as
            // I attempt to explain it.

			//public double[][] jagged_heights;
			public double[, ,] height = new double[12, HEX_SIZE + 1, HEX_SIZE + 1]; // band arond the center... 30 degrees...

            public Vector3[, ,] grid = new Vector3[12, HEX_SIZE + 1, HEX_SIZE + 1]; // +1 cause there's this many squares bounded by +1 lines.

            public area_coord[, , ,] near_area = new area_coord[12, HEX_SIZE + 1, HEX_SIZE + 1, 4];
            // each area is near 4 other areas.
            // these areas are
            //        1
            //        |
            //    2 - o - 0
            //        |
            //        3
            //
        }
        world_height_map world_map = new world_height_map();


        // total world size is 64800 elements, 259200 bytes


        // mesh of 796262400 floating point heights
        // 3G (3185M) (above number *4)

        //struct world_map too_big;
        //
        //
        //
        //
        //

        //
        //     // how to make a sensible maping of sectors in a beleivable 360 section map, with 360x360x360 bands
        //
        //
        //
        //
        //
        //
        //
        //
        //

        // length of an edge - divided by HEX_SIZE = width of segment
        const double HEX_SCALE = PLANET_M_PER_MAJORHEX;

        // Vertical_stride
        const double HEX_VERT_STRIDE = ((HEX_SCALE * 1.7320508075688772935274463415059 / 2) /*/ (double)HEX_SIZE*/ );

        // horizontal_stride
        const double HEX_HORZ_STRIDE = ((HEX_SCALE) /*/ (double)HEX_SIZE*/ );



        const int BODY_COUNT = 5;
        const double SPHERE_SIZE = PLANET_RADIUS;
        const int SPHERE_DIVISIONS = HEX_SIZE;

        //#define POLE_NEAR_AREA_DEBUG
        //#define DEBUG_RENDER_POLE_NEARNESS

        // land hex
        //     x
        //    ___
        // y / 0 /\ x
        //  /___/ 2\    ...
        //  \  1\  /    ...
        // y \___\/ y
        //      x


#if adfasdfasdf
enum { UP
	  , RIGHT_UP
	  , RIGHT_DOWN
	  , DOWN
	  , LEFT_DOWN
	  , LEFT_UP
} DIRECTIONS;
#endif

        //EasyRegisterControlWithBorder( "Terrain View", 0, BORDER_NONE );

        int cur_x, cur_y, cur_s;

        //void ConvertToSphereGrid( Vector3 p, out int s, out int x, out int y ); // s 0-3, s 4-9, 10-12

		///
        internal static void ConvertPolarToRect(int level
                                    , int c
                                    , out int x
                                    , out int y)
        {
            // all maps must include c == HEX_SIZE
            c %= (level * 2 + 1);
            if (c < level)
            {
                // need to redo the flat distortion....
                (x) = level;
                (y) = c;
            }
            else
            {
                //if( c == level )
                (x) = ((level) - (c - level));
                (y) = level;
            }
        }



        //class band {
        // the 4 corners that make up this sqaure.
        // could, in theory, scan this to come up with the 
        // correct square to point conversions


        void InitBand()
        {
            int s;
            int r;
            int c;
            // compute near areas in other grids for transitions....

            for (s = 0; s < 6; s++)
                for (r = 0; r <= HEX_SIZE; r++)
                    for (c = 0; c < HEX_SIZE; c++)
                    {
                        // basically the bottom left corner is always in itself.

                        if (r == HEX_SIZE)
                        {
                            // the first is upper left of this coord.  therefore
                            // near is off the sector
                            world_map.near_area[s, c, r, 0].s = s / 2;
                            ConvertPolarToRect(HEX_SIZE - 1, (s % 2) * HEX_SIZE + c
                                                    , out world_map.near_area[s + 3, c, r, 0].x
                                                    , out world_map.near_area[s + 3, c, r, 0].y);
                            world_map.near_area[s + 3, c, r, 3].s = s;
                            world_map.near_area[s + 3, c, r, 3].x = c;
                            world_map.near_area[s + 3, c, r, 3].y = r - 1;

                            if (c != 0)
                            {
                                world_map.near_area[s + 3, c, r, 1].s = s / 2;
                                ConvertPolarToRect(HEX_SIZE - 1, (s % 2) * HEX_SIZE + (c - 1)
                                                        , out world_map.near_area[s + 3, c, r, 1].x
                                                        , out world_map.near_area[s + 3, c, r, 1].y);
                                world_map.near_area[s + 3, c, r, 2].s = s + 3;
                                world_map.near_area[s + 3, c, r, 2].x = c - 1;
                                world_map.near_area[s + 3, c, r, 2].y = r;
                            }
                            else
                            {
                                world_map.near_area[s + 3, c, r, 1].s = ((s / 2) + 2) % 3;
                                ConvertPolarToRect(HEX_SIZE - 1, (s % 2) * HEX_SIZE + (HEX_SIZE)
                                                        , out world_map.near_area[s + 3, c, r, 1].x
                                                        , out world_map.near_area[s + 3, c, r, 1].y);

                                if (s != 0)
                                    world_map.near_area[s + 3, c, r, 2].s = s + 3 - 1;
                                else
                                    world_map.near_area[s + 3, c, r, 2].s = 3 + 5;
                                world_map.near_area[s + 3, c, r, 2].x = HEX_SIZE;
                                world_map.near_area[s + 3, c, r, 2].y = r - 1;
                            }
                        }
                        else
                        {
                            world_map.near_area[s + 3, c, r, 0].s = s + 3;
                            world_map.near_area[s + 3, c, r, 0].x = c;
                            world_map.near_area[s + 3, c, r, 0].y = r;
                            if (r != 0)
                            {
                                world_map.near_area[s + 3, c, r, 3].s = s + 3;
                                world_map.near_area[s + 3, c, r, 3].x = c;
                                world_map.near_area[s + 3, c, r, 3].y = r - 1;
                            }
                            else
                            {
                                world_map.near_area[s + 3, c, r, 3].s = 9 + s / 2;
                                ConvertPolarToRect(HEX_SIZE - 1, ((s % 2) * HEX_SIZE + c)
                                                        , out world_map.near_area[s + 3, c, r, 3].x
                                                        , out world_map.near_area[s + 3, c, r, 3].y);
                            }
                            if (r == 0)
                            {
                                if (c != 0)
                                {
                                    world_map.near_area[s + 3, c, r, 1].s = s + 3;
                                    world_map.near_area[s + 3, c, r, 1].x = c - 1;
                                    world_map.near_area[s + 3, c, r, 1].y = r;
                                    world_map.near_area[s + 3, c, r, 2].s = 9 + s / 2;
                                    ConvertPolarToRect(HEX_SIZE - 1, (s % 2) * HEX_SIZE + (c - 1)
                                                            , out world_map.near_area[s + 3, c, r, 2].x
                                                            , out world_map.near_area[s + 3, c, r, 2].y);
                                }
                                else
                                {
                                    if (s != 0)
                                        world_map.near_area[s + 3, c, r, 1].s = s + 3 - 1;
                                    else
                                        world_map.near_area[s + 3, c, r, 1].s = 3 + 5;
                                    world_map.near_area[s + 3, c, r, 1].x = HEX_SIZE - 1;
                                    world_map.near_area[s + 3, c, r, 1].y = r;
                                    world_map.near_area[s + 3, c, r, 2].s = 9 + ((s / 2) + 2) % 3;
                                    ConvertPolarToRect(HEX_SIZE - 1, (s % 2) * HEX_SIZE + (HEX_SIZE)
                                                            , out world_map.near_area[s + 3, c, r, 2].x
                                                            , out world_map.near_area[s + 3, c, r, 2].y);

                                }
                            }
                            else
                            {
                                // first is this point...
                                if (c != 0)
                                {
                                    world_map.near_area[s + 3, c, r, 1].s = s + 3;
                                    world_map.near_area[s + 3, c, r, 1].x = c - 1;
                                    world_map.near_area[s + 3, c, r, 1].y = r;

                                    world_map.near_area[s + 3, c, r, 2].s = s + 3;
                                    world_map.near_area[s + 3, c, r, 2].x = c - 1;
                                    world_map.near_area[s + 3, c, r, 2].y = r - 1;
                                }
                                else
                                {
                                    if (s != 0)
                                        world_map.near_area[s + 3, c, r, 1].s = s + 3 - 1;
                                    else
                                        world_map.near_area[s + 3, c, r, 1].s = 3 + 5;
                                    world_map.near_area[s + 3, c, r, 1].x = HEX_SIZE - 1;
                                    world_map.near_area[s + 3, c, r, 1].y = r;

                                    if (s != 0)
                                        world_map.near_area[s + 3, c, r, 2].s = s + 3 - 1;
                                    else
                                        world_map.near_area[s + 3, c, r, 2].s = 3 + 5;
                                    world_map.near_area[s + 3, c, r, 2].x = HEX_SIZE - 1;
                                    world_map.near_area[s + 3, c, r, 2].y = r - 1;
                                }
                            }
                        }
                    }
            for (r = 0; r < HEX_SIZE; r++)
                for (c = 0; c < HEX_SIZE; c++)
                {
#if asdf
					corners[c,r,0].c = c;
					corners[c,r,3].r = r+1;
					if( s == 5 && c == (HEX_SIZE-1) )
					{
						corners[c,r,1].c = 0;
						corners[c,r,1].r = r;
						corners[c,r,2].c = 0;
						corners[c,r,2].r = r+1;
					}
					else
					{
						corners[c,r,1].c = c + 1;
						corners[c,r,1].r = r;
						corners[c,r,2].c = c + 1;
						corners[c,r,2].r = r + 1;
					}
#endif
                }
            {
                Transform work = new Transform();
                int section, section2;
                int sections = 6 * HEX_SIZE;
                int sections2 = HEX_SIZE;

                //scale( ref_point, _X, SPHERE_SIZE );

                for (section2 = 0; section2 <= sections2; section2++)
                {
                    Vector3 patch1x;
                    //patch1x = Vector3.xAxis;
                    //patch1x.Roll((((60.0F / HEX_SIZE) * section2) - 30.0F));
                    work.RotateAbs( 0, 0, ((((60.0/HEX_SIZE)*section2)-30.0)*(1*M_PI))/180.0 );
                    patch1x = work.GetAxis( Transform.vRight );
                    for (section = 0; section < sections; section++)
                    {

                        //patch1x.Pitch(((double)section * 360.0F) / (double)sections);
                        //world_map.grid[section / HEX_SIZE, section % HEX_SIZE, section2] = patch1x;

                        //patch1x.Yaw(360 / sections);
                        //world_map.grid[3 + section / HEX_SIZE, section % HEX_SIZE, section2] = patch1x;
                        work.RotateAbs(0, ((double)section * (2.0 * M_PI)) / (double)sections, 0);
                        work.Apply( ref world_map.grid[3+section/HEX_SIZE,section%HEX_SIZE,section2]
								, patch1x );
                    }
                }

            }
        }

        // near_area points and this semi-polar representation needs a rectangular conversion


        void InitPole()
        {
            Transform pole_work = new Transform();
            {
                int p;
                int level;
                int col;
                bool bLog = false;
#if POLE_NEAR_AREA_DEBUG
			bLog = 1;
#endif

                for (p = 0; p < 3; p++)
                {
                    world_map.near_area[p, 0, 0, 0].s = 0;
                    world_map.near_area[p, 0, 0, 0].x = 0;
                    world_map.near_area[p, 0, 0, 0].y = 0;
                    world_map.near_area[p, 0, 0, 1].s = 1;
                    world_map.near_area[p, 0, 0, 1].x = 0;
                    world_map.near_area[p, 0, 0, 1].y = 0;
                    world_map.near_area[p, 0, 0, 2].s = 2;
                    world_map.near_area[p, 0, 0, 2].x = 0;
                    world_map.near_area[p, 0, 0, 2].y = 0;
                    world_map.near_area[p, 0, 0, 3].s = -1;
                    world_map.near_area[p, 0, 0, 3].x = 0;
                    world_map.near_area[p, 0, 0, 3].y = 0;
                    continue;
                }
                for (p = 0; p < 3; p++)
                {
                    for (level = 1; level <= HEX_SIZE; level++)
                    {
                        for (col = 0; col < level; col++)
                        {
                            int x, y;
                            int ax, ay;

                            // square 1, upper left, considering that up and left are totally relative 
                            // beyond the first square.

                            ConvertPolarToRect(level, col, out ax, out ay);
                            if (bLog) Console.WriteLine("level %d,%d is base square %d,%d", level, col, ax, ay);
                            if (level < (HEX_SIZE - 1))
                            {
                                ConvertPolarToRect(level, col, out x, out y);
                                world_map.near_area[p, x, y, 0].s = p;
                                world_map.near_area[p, x, y, 0].x = x;
                                world_map.near_area[p, ax, ay, 0].y = y;
                                if (bLog) Console.WriteLine("level %d col %d is near (0) %d,%d,%d", level, col, p, x, y);

                                ConvertPolarToRect(level - 1, col, out x, out y);
                                world_map.near_area[p, ax, ay, 1].s = p;
                                world_map.near_area[p, ax, ay, 1].x = x;
                                world_map.near_area[p, ax, ay, 1].y = y;
                                if (bLog) Console.WriteLine("level %d col %d is near (1) %d,%d,%d", level, col, p, x, y);

                                if (col != 0)
                                {
                                    // level will be more than 1 if col is more than 1
                                    ConvertPolarToRect(level - 1, col - 1
                                        , out x
                                        , out y);
                                    world_map.near_area[p, ax, ay, 2].s = p;
                                    world_map.near_area[p, ax, ay, 2].x = x;
                                    world_map.near_area[p, ax, ay, 2].y = y;
                                    if (bLog) Console.WriteLine("level %d col %d is near (2) %d,%d", level, col, x, y);
                                    if (col == (level * 2))
                                    {
                                        ConvertPolarToRect(level - 1, 0, out x, out y);
                                        world_map.near_area[p, ax, ay, 3].s = (p + 1) % 3;
                                        world_map.near_area[p, ax, ay, 3].x = y;
                                        world_map.near_area[p, ax, ay, 3].y = x;
                                        if (bLog) Console.WriteLine("level %d col %d is near (3) %d,%d", level, col, x, y);
                                    }
                                    else
                                    {
                                        ConvertPolarToRect(level, col - 1
                                            , out x
                                            , out y);
                                        world_map.near_area[p, ax, ay, 3].s = p;
                                        world_map.near_area[p, ax, ay, 3].x = x;
                                        world_map.near_area[p, ax, ay, 3].y = y;
                                        if (bLog) Console.WriteLine("level %d col %d is near (3) %d,%d", level, col, x, y);
                                    }
                                }
                                else
                                {
                                    ConvertPolarToRect(level - 1, (level - 1) * 2, out x, out y);
                                    world_map.near_area[p, ax, ay, 2].s = (p + 2) % 3;
                                    world_map.near_area[p, ax, ay, 2].x = x;
                                    world_map.near_area[p, ax, ay, 2].y = y;
                                    if (bLog) Console.WriteLine("level %d col %d is near (2) %d,%d,%d", level, col, (p + 2) % 3, x, y);

                                    ConvertPolarToRect(level, (level) * 2, out x, out y);
                                    world_map.near_area[p, ax, ay, 3].s = (p + 2) % 3;
                                    world_map.near_area[p, ax, ay, 3].x = x;
                                    world_map.near_area[p, ax, ay, 3].y = y;
                                    if (bLog) Console.WriteLine("level %d col %d is near (3) %d,%d,%d", level, col, (p + 2) % 3, x, y);
                                }

                            }
                            else
                            {
                                // outer ring...
                            }

                        }
                        col = level;
                        {
                            int x, y;
                            int ax, ay;
                            ConvertPolarToRect(level, col, out ax, out ay);
#if POLE_NEAR_AREA_DEBUG
						Console.WriteLine( "level %d,%d is base square %d,%d", level, col, ax, ay );
#endif
                            ConvertPolarToRect(level, col, out x, out y);
                            world_map.near_area[p, ax, ay, 0].s = p;
                            world_map.near_area[p, ax, ay, 0].x = x;
                            world_map.near_area[p, ax, ay, 0].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (0) %d,%d", level, col, x, y );
#endif
                            ConvertPolarToRect(level, col + 1, out x, out y);
                            world_map.near_area[p, ax, ay, 1].s = p;
                            world_map.near_area[p, ax, ay, 1].x = x;
                            world_map.near_area[p, ax, ay, 1].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (1) %d,%d", level, col, x, y );
#endif
                            ConvertPolarToRect(level - 1, col - 1, out x, out y);
                            world_map.near_area[p, ax, ay, 2].s = p;
                            world_map.near_area[p, ax, ay, 2].x = x;
                            world_map.near_area[p, ax, ay, 2].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (2) %d,%d", level, col, x, y );
#endif
                            ConvertPolarToRect(level, col - 1, out x, out y);
                            world_map.near_area[p, ax, ay, 3].s = p;
                            world_map.near_area[p, ax, ay, 3].x = x;
                            world_map.near_area[p, ax, ay, 3].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (3) %d,%d", level, col, x, y );
#endif
                        }
                        for (col = level + 1; col <= level * 2; col++)
                        {
                            int x, y;
                            int ax, ay;
                            ConvertPolarToRect(level, col, out ax, out ay);
#if POLE_NEAR_AREA_DEBUG
						Console.WriteLine( "level %d,%d is base square %d,%d", level, col, ax, ay );
#endif
                            // square 1, upper left, considering that up and left are totally relative 
                            // beyond the first square.

                            if (level < (HEX_SIZE - 1))
                            {
                                ConvertPolarToRect(level, col, out x, out y);
                                world_map.near_area[p, ax, ay, 0].s = p;
                                world_map.near_area[p, ax, ay, 0].x = x;
                                world_map.near_area[p, ax, ay, 0].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (0) %d,%d", level, col, x, y );
#endif

                                ConvertPolarToRect(level - 1, col - 2, out x, out y);
                                world_map.near_area[p, ax, ay, 3].s = p;
                                world_map.near_area[p, ax, ay, 3].x = x;
                                world_map.near_area[p, ax, ay, 3].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (3) %d,%d", level, col, x, y );
#endif

                                if (col != level * 2)
                                {
                                    // level will be more than 1 if col is more than 1
                                    ConvertPolarToRect(level, col + 1
                                        , out x
                                        , out y);
                                    world_map.near_area[p, ax, ay, 1].s = p;
                                    world_map.near_area[p, ax, ay, 1].x = x;
                                    world_map.near_area[p, ax, ay, 1].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (1) %d,%d", level, col, x, y );
#endif
                                    ConvertPolarToRect(level - 1, col - 1
                                            , out x
                                            , out y);
                                    world_map.near_area[p, ax, ay, 2].s = p;
                                    world_map.near_area[p, ax, ay, 2].x = x;
                                    world_map.near_area[p, ax, ay, 2].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (2) %d,%d", level, col, x, y );
#endif
                                }
                                else
                                {
                                    ConvertPolarToRect(level, 0
                                        , out x
                                        , out y);

                                    world_map.near_area[p, ax, ay, 1].s = (p + 1) % 3;
                                    world_map.near_area[p, ax, ay, 1].x = x;
                                    world_map.near_area[p, ax, ay, 1].y = y;
#if POLE_NEAR_AREA_DEBUG
							Console.WriteLine( "level %d col %d is near (1) %d,%d,%d", level, col, (p+1)%3, x, y );
#endif

                                    ConvertPolarToRect(level - 1, 0
                                        , out x
                                        , out y);
                                    world_map.near_area[p, ax, ay, 2].s = (p + 1) % 3;
                                    world_map.near_area[p, ax, ay, 2].x = x;
                                    world_map.near_area[p, ax, ay, 2].y = y;
#if POLE_NEAR_AREA_DEBUG
								Console.WriteLine( "level %d col %d is near (2) %d,%d,%d", level, col, (p+1)%3, x, y );
#endif
                                }
                            }
                            else
                            {
                                // outer ring...
                            }
                            /*
                            world_map.near_area[p,ax,ay,0].s = p;
                            world_map.near_area[p,ax,ay,0].x = x;
                            world_map.near_area[p,ax,ay,0].y = y;
                            world_map.near_area[p,ax,ay,1].s = p;
                            world_map.near_area[p,ax,ay,1].x = x;
                            world_map.near_area[p,ax,ay,1].y = y;
                            world_map.near_area[p,ax,ay,2].s = p;
                            world_map.near_area[p,ax,ay,2].x = x;
                            world_map.near_area[p,ax,ay,2].y = y;
                            world_map.near_area[p,ax,ay,3].s = p;
                            world_map.near_area[p,ax,ay,3].x = x;
                            world_map.near_area[p,ax,ay,3].y = y;
                            */
                        }
                    }
                }
            }
            //}
#if asdfasdf
            {
                {
                    int level;
                    int col;
                    for (level = 0; level < HEX_SIZE; level++)
                        for (col = 0; col <= level * 2; col++)
                        {
                            int x, y;
                            ConvertPolarToRect(level, col, out x, out y);
                            corners[x, y, 0] = x;
                            corners[x, y, 1] = HEX_SIZE + x;
                            corners[x, y, 2] = HEX_SIZE + x + 1;
                            corners[x, y, 3] = x + 1;
                        }
                }
            }
#endif
            {
                Vector3 patch1, patch1x;
                int level;
                int c;
                int patch;
                //__try
                for (int north = 0; north <= 1; north++)
                {
                    for (patch = 0; patch < 3; patch++)
                    {
                        for (level = 0; level <= HEX_SIZE; level++)
                        {
                            double patch_bias = -(((patch + north * 9) * 120) * M_PI) / 180;
                            int sections = (level * 2);
                            pole_work.RotateAbs(0, 0, ((((60.0 / HEX_SIZE) * level)) * (1 * M_PI)) / 180.0);
                            patch1x = pole_work.GetAxis(Transform.vUp);
                            //Apply( pole_work, patch1x, ref_point );
                            if (sections == 0) // level 0
                            {
                                world_map.grid[(patch + north * 9), 0, 0] = patch1x;
                                continue;
                            }
                            //use common convert sphere to hex...
                            for (c = 0; c <= sections; c++)
                            {
                                int x, y;
                                ConvertPolarToRect(level, c, out x, out y);
                                pole_work.RotateAbs(0, patch_bias - ((120.0 * c) * (1 * M_PI)) / ((sections) * 180.0), 0);
                                patch1 = pole_work.Apply(patch1x);
                                world_map.grid[(patch + north * 9), x, y] = patch1;
                            }
                        }
                    }
                }
                //__except(EXCEPTION_EXECUTE_HANDLER){ Console.WriteLine( "Pole Patch Excepted." ); }
            }

        }



        // if not north, then south.
        bool RenderPolePatch(bool north)
        {
            int s, level, c, r;

            int x, y; // used to reference patch level
            //int x2, y2;
            bool bLog = false;
#if DEBUG_RENDER_POLE_NEARNESS
	bLog = 1;
#endif
            // create array of normals.
            //__try
            {
                for (s = 0; s < 3; s++)
                {
                    int north_offset = north ? 9 : 0;
                    for (level = 1; level <= HEX_SIZE; level++)
                    {
                        Vector3 v1;
                        //if( bLog )Console.WriteLine( "---------" );
                        //if( 0)  {
                        GL.glBegin(GL.GL_TRIANGLE_STRIP);
                        r = 0;
                        for (c = 0; c <= level; c++)
                        {
                            bool bodynear = false;
                            bool bodynear2 = false;
                            bool bodynearnear = false;
                            bool bodynearnear2 = false;
                            ConvertPolarToRect(level, c, out x, out y);
                            // consider removign the same function used below.
                            {
                                int n;
                                for (n = 0; n < 4; n++)
                                {
                                    //int m;
                                    int s2, x2, y2;
                                    s2 = world_map.near_area[s + north_offset, x, y, n].s + (north ? 9 : 0);
                                    x2 = world_map.near_area[s + north_offset, x, y, n].x;
                                    y2 = world_map.near_area[s + north_offset, x, y, n].y;

                                    if (bLog) Console.WriteLine("point {0},{1},{3},{4} is near {5},{6},{7}"
                                       , s, level, c, n
                                       , world_map.near_area[s + north_offset, x, y, n].s
                                       , world_map.near_area[s + north_offset, x, y, n].x
                                       , world_map.near_area[s + north_offset, x, y, n].y
                                       );

                                    //if( bodymap.band[world_map.near_area[s+north_offset,x,y,n].s+(north*10)]
                                    //		[world_map.near_area[s+north_offset,x,y,n].x]
                                    //		[world_map.near_area[s+north_offset,x,y,n].y] )
                                    if (s2 == cur_s &&
                                        x2 == cur_x &&
                                        y2 == cur_y)
                                    {
                                        bodynear = true;
                                    }
#if asdfasdf
							else for( m = 0; m < 4; m++ )
							{
								if( bodymap.near_areas[s2,x2,y2,m].s == cur_s &&
									bodymap.near_areas[s2,x2,y2,m].x == cur_x &&
									bodymap.near_areas[s2,x2,y2,m].y == cur_y )
								{
									bodynearnear = true;
								}
							}
#endif
                                }
                            }
                            if (bodynear)
                            {
                                if (bLog) Console.WriteLine("Is bodynear");
                                GL.glColor3d(1.0, 1.0, 1.0);
                            }
                            else if (bodynearnear)
                            {
                                if (bLog) Console.WriteLine("Is bodynearnear");
                                GL.glColor3d(0.4, 0, 0);
                            }
                            else
                            {
                                switch (s)
                                {
                                    case 0:
                                        GL.glColor3d(1.0, 0.0, 0.0);
                                        break;
                                    case 1:
                                        GL.glColor3d(0.0, 1.0, 0.0);
                                        break;
                                    case 2:
                                        GL.glColor3d(0.0, 0.0, 10);
                                        break;
                                }
                                /*
                                if( c & 1 )
                                GL.glColor3d( 1.0, 0.0, 0.0 );
                                else
                                GL.glColor3d( 0.0, 1.0, 0.0 );
                                */
                                //glColor3d( 0,0,0);
                            }
                            v1 = world_map.grid[s, x, y] * (SPHERE_SIZE + world_map.height[north ? 9 : 0 + s, x, y]);
                            GL.glVertex3d(v1[0]
                            , north ? v1[1] : -v1[1]
                            , v1[2]
                            );
                            if (c < (level))
                            {
                                //int bodynear2 = 0;
                                //	int bodynearnear2 = 0;
                                int n;
                                ConvertPolarToRect(level - 1, c, out x, out y);
                                for (n = 0; n < 4; n++)
                                {
                                    //int m;
                                    int s2, x2, y2;
                                    //if( bodymap.band[world_map.near_area[s+north_offset,x,y,n].s+(north*10)]
                                    //		[world_map.near_area[s+north_offset,x,y,n].x]
                                    //		[world_map.near_area[s+north_offset,x,y,n].y] )
                                    if (world_map.near_area[s + north_offset, x, y, n].s < 0)
                                        continue;
                                    if (bLog) Console.WriteLine("point %d,%d,%d,%d is near %d,%d,%d"
                                       , s, level - 1, c, n
                                       , world_map.near_area[s + north_offset, x, y, n].s
                                       , world_map.near_area[s + north_offset, x, y, n].x
                                       , world_map.near_area[s + north_offset, x, y, n].y
                                       );
                                    s2 = world_map.near_area[s + north_offset, x, y, n].s + (north ? 9 : 0);
                                    x2 = world_map.near_area[s + north_offset, x, y, n].x;
                                    y2 = world_map.near_area[s + north_offset, x, y, n].y;
                                    if (s2 == cur_s &&
                                        x2 == cur_x &&
                                        y2 == cur_y)
                                        bodynear2 = true;
#if asdfadsfff
							else for( m = 0; m < 4; m++ )
							{
								if( bodymap.near_areas[s2,x2,y2,m].s == cur_s &&
									bodymap.near_areas[s2,x2,y2,m].x == cur_x &&
									bodymap.near_areas[s2,x2,y2,m].y == cur_y )
								{
									bodynearnear2 = true;
								}
							}
#endif
                                }
                                if (bodynear2)
                                {
                                    if (bLog) Console.WriteLine("Is bodynear");
                                    GL.glColor3d(1.0, 1.0, 1.0);
                                }
                                else if (bodynearnear2)
                                {
                                    if (bLog) Console.WriteLine("Is bodynearnearnear");
                                    GL.glColor3d(0.4, 0.0, 0.0);
                                }
                                else
                                {
                                    if ((c & 1) != 0)
                                        GL.glColor3d(0.9, 0.0, 1.0);
                                    else
                                        GL.glColor3d(0.0, 0.9, 1.0);
                                    //glColor3d( 0,0,0);
                                }
                                v1 = world_map.grid[s, x, y] * (SPHERE_SIZE + world_map.height[north ? 9 : 0 + s, x, y]);
                                GL.glVertex3d(v1[0]
                                , north ? v1[1] : -v1[1]
                                , v1[2]
                                );
                            }
                            r++;
                        }
                        GL.glEnd();
                        //}
                        if (bLog) Console.WriteLine("---------");
                        //glFlush();
                        GL.glBegin(GL.GL_TRIANGLE_STRIP);
                        for (c = level; c <= level * 2; c++)
                        {
                            {
                                bool bodynear = false;
                                bool bodynearnear = false;
                                int n;
                                ConvertPolarToRect(level, c, out x, out y);
                                for (n = 0; n < 4; n++)
                                {
                                    //int m;
                                    int s2, x2, y2;
                                    if (bLog) Console.WriteLine("zzzpoint %d,%d,%d,%d is near %d,%d,%d"
                                       , s, level, c, n
                                       , world_map.near_area[s + north_offset, x, y, n].s
                                       , world_map.near_area[s + north_offset, x, y, n].x
                                       , world_map.near_area[s + north_offset, x, y, n].y
                                       );
                                    s2 = world_map.near_area[s + north_offset, x, y, n].s + (north ? 0 : 1);
                                    x2 = world_map.near_area[s + north_offset, x, y, n].x;
                                    y2 = world_map.near_area[s + north_offset, x, y, n].y;
                                    //if( bodymap.band[world_map.near_area[s+north_offset,x,y,n].s+(north*10)]
                                    //		[world_map.near_area[s+north_offset,x,y,n].x]
                                    //		[world_map.near_area[s+north_offset,x,y,n].y] )
                                    if (s2 == cur_s &&
                                        x2 == cur_x &&
                                        y2 == cur_y)
                                        bodynear = true;
#if asdfasdf
							else for( m = 0; m < 4; m++ )
							{
								if( bodymap.near_areas[s2,x2,y2,m].s == cur_s &&
									bodymap.near_areas[s2,x2,y2,m].x == cur_x &&
									bodymap.near_areas[s2,x2,y2,m].y == cur_y )
								{
									bodynearnear = true;
								}
							}
#endif
                                }
                                if (bodynear)
                                {
                                    if (bLog) Console.WriteLine("Is bodynear");
                                    GL.glColor3d(1.0, 1.0, 1.0);
                                }
                                else if (bodynearnear)
                                {
                                    if (bLog) Console.WriteLine("Is bodynearnear");
                                    GL.glColor3d(0.4, 0.0, 0.0);
                                }
                                else
                                {
                                    if ((c & 1) != 0)
                                        GL.glColor3d(0.8, 0.0, 0.0);
                                    else
                                        GL.glColor3d(0.0, 0.8, 0.0);
                                    //glColor3d( 0,0,0);
                                }
                            }
                            //ConvertPolarToRect( level, c, out x, out y );
                            //if( bLog )Console.WriteLine( "Render corner %d,%d", 2*level-c,level);
                            v1 = world_map.grid[s, x, y] * (SPHERE_SIZE + world_map.height[north ? 9 : 0 + s, x, y]);
                            GL.glVertex3d(v1[0]
                            , north ? v1[1] : -v1[1]
                            , v1[2]
                            );
                            if (c < (level) * 2)
                            {
                                {
                                    bool bodynear = false;
                                    bool bodynearnear = false;
                                    int n;
                                    ConvertPolarToRect(level - 1, c - 1, out x, out y);
                                    for (n = 0; n < 4; n++)
                                    {
                                        //int m;
                                        int s2, x2, y2;
                                        if ((world_map.near_area[s + north_offset, x, y, n].s) < 0)
                                            continue;
                                        if (bLog) Console.WriteLine("point %d,%d,%d,%d is near %d,%d,%d"
                                            , s, level - 1, c - 1, n
                                            , world_map.near_area[s + north_offset, x, y, n].s
                                            , world_map.near_area[s + north_offset, x, y, n].x
                                            , world_map.near_area[s + north_offset, x, y, n].y
                                            );
                                        s2 = world_map.near_area[s + north_offset, x, y, n].s + (north ? 9 : 0);
                                        x2 = world_map.near_area[s + north_offset, x, y, n].x;
                                        y2 = world_map.near_area[s + north_offset, x, y, n].y;
                                        if (s2 == cur_s &&
                                            x2 == cur_x &&
                                            y2 == cur_y)
                                            //if( bodymap.band[s2]
                                            //  	[world_map.near_area[s+north_offset,x,y,n].x]
                                            //		[world_map.near_area[s+north_offset,x,y,n].y] )
                                            bodynear = true;
                                    }
                                    if (bodynear)
                                    {
                                        if (bLog) Console.WriteLine("Is bodynear");
                                        GL.glColor3d(1.0, 1.0, 1.0);
                                    }
                                    else if (bodynearnear)
                                    {
                                        if (bLog) Console.WriteLine("Is bodynearnear");
                                        GL.glColor3d(0.5, 0.0, 0.0);

                                    }
                                    else
                                    {
                                        if ((c & 1) != 0)
                                            GL.glColor3d(1, 0.0, 1.0);
                                        else
                                            GL.glColor3d(0.0, 1, 1.0);
                                        //glColor3d( 0,0,0);
                                    }
                                }

                                //ConvertPolarToRect( level-1, c-1, out x, out y );
                                //if( bLog )Console.WriteLine( "Render corner %d,%d", 2*level-c-1,level-1);
                                v1 = world_map.grid[s, x, y] * (SPHERE_SIZE + world_map.height[north ? 9 : 0 + s, x, y]);
                                GL.glVertex3d(v1[0]
                                , north ? v1[1] : -v1[1]
                                , v1[2]
                                );
                            }
                        }
                        GL.glEnd();
                    }
                }
            }
            //__except(EXCEPTION_EXECUTE_HANDLER){ Console.WriteLine( "Pole Patch Excepted." );return 0; }
            return true;
        }


        void RenderBandPatch()
        {
            int section, section2;
            int sections = 6 * HEX_SIZE;
            int sections2 = HEX_SIZE;
            Vector3 patch1, patch2;
            //VECTOR ref_point;
            //InitBandPatch();

            //scale( ref_point, _X, SPHERE_SIZE );

            for (section2 = 0; section2 < sections2; section2++)
            {
                GL.glBegin(GL.GL_TRIANGLE_STRIP);
                for (section = 0; section <= sections; section++)
                {
                    int s = 3 + (section / HEX_SIZE) % 6; // might be 6, which needs to be 0.
                    patch1 = world_map.grid[s, section % HEX_SIZE, section2] * SPHERE_SIZE;
                    patch2 = world_map.grid[s, section % HEX_SIZE, section2 + 1] * SPHERE_SIZE;

                    {
                        bool bodynear = false;
                        bool bodynearnear = false;
                        bool bodynear2 = false;
                        bool bodynearnear2 = false;
                        int n;
                        //Console.WriteLine( "---------------------------------------------" );
                        for (n = 0; n < 4; n++)
                        {
                            /*
                            Console.WriteLine( "%d,%d,%d is near %d,%d,%d", s, section%HEX_SIZE, section2
                            , _band.patches[s].near_area[s,section%HEX_SIZE,section2,n].s
                            , _band.patches[s].near_area[s,section%HEX_SIZE,section2,n].x
                            , _band.patches[s].near_area[s,section%HEX_SIZE,section2,n].y
                            );
                            Console.WriteLine( "%d,%d,%d is near %d,%d,%d", s, section, section2+1
                            , _band.patches[s].near_area[s,section%HEX_SIZE,section2+1,n].s
                            , _band.patches[s].near_area[s,section%HEX_SIZE,section2+1,n].x
                            , _band.patches[s].near_area[s,section%HEX_SIZE,section2+1,n].y
                            );
                            */
                            {
                                //int m;
                                int s2, x2, y2;
                                s2 = world_map.near_area[s, section % HEX_SIZE, section2, n].s;
                                x2 = world_map.near_area[s, section % HEX_SIZE, section2, n].x;
                                y2 = world_map.near_area[s, section % HEX_SIZE, section2, n].y;
                                if (s2 == cur_s &&
                                    x2 == cur_x &&
                                    y2 == cur_y)
                                //if(
                                //	bodymap.band[_band.patches[s].near_area[s,section%HEX_SIZE,section2,n].s]
                                //	[_band.patches[s].near_area[s,section%HEX_SIZE,section2,n].x]
                                //	[_band.patches[s].near_area[s,section%HEX_SIZE,section2,n].y]
                                //  )
                                {
                                    bodynear = true;
                                }
#if asdfasdf
						else for( m = 0; m < 4; m++ )
						{
							if( s2 > 2 && s2 < 9 )
								if( bodymap.near_areas[s2,x2,y2,m].s == cur_s &&
									bodymap.near_areas[s2,x2,y2,m].x == cur_x &&
									bodymap.near_areas[s2,x2,y2,m].y == cur_y )
								{
									bodynearnear = true;
								}
						}
#endif
                            }
                            {
                                //int m;
                                int s2, x2, y2;
                                s2 = world_map.near_area[s, section % HEX_SIZE, section2 + 1, n].s;
                                x2 = world_map.near_area[s, section % HEX_SIZE, section2 + 1, n].x;
                                y2 = world_map.near_area[s, section % HEX_SIZE, section2 + 1, n].y;
                                if (s2 == cur_s &&
                                    x2 == cur_x &&
                                    y2 == cur_y)
                                //if(
                                //	bodymap.band[_band.patches[s].near_area[s,section%HEX_SIZE,section2+1,n].s]
                                //	[_band.patches[s].near_area[s,section%HEX_SIZE,section2+1,n].x]
                                //	[_band.patches[s].near_area[s,section%HEX_SIZE,section2+1,n].y]
                                //  )
                                {
                                    bodynear2 = true;
                                }
#if asdfadsf
						else for( m = 0; m < 4; m++ )
						{
							if( s2 > 2 && s2 < 9 )
								if( bodymap.near_areas[s2,x2,y2,m].s == cur_s &&
									bodymap.near_areas[s2,x2,y2,m].x == cur_x &&
									bodymap.near_areas[s2,x2,y2,m].y == cur_y )
								{
									bodynearnear2 = true;
								}
						}
#endif
                            }
                        }
                        //Console.WriteLine( "---------------------------------------------" );

                        if (bodynear)
                        {
                            GL.glColor3d(1.0, 1.0, 1.0);
                        }
                        else if (bodynearnear)
                        {
                            GL.glColor3d(0.6, 0.6, 0.6);
                        }
                        else
                        {
                            if ((section2 & 1) != 0)
                            {
                                if ((section & 1) != 0)
                                    GL.glColor3d(1.0//(double)section/(double)sections
                                    , 0.0, 0.0);
                                else
                                    GL.glColor3d(0.0, 1.0 //(double)section/(double)sections
                                    , 0.0);
                            }
                            else
                            {
                                if ((section & 1) != 0)
                                    GL.glColor3d(1.0//(double)section/(double)sections
                                    , 1.0, 0.0);
                                else
                                    GL.glColor3d(1.0, 1.0 //(double)section/(double)sections
                                    , 0.0);
                            }
                            //glColor3f( 0,0,0 );
                        }
                        GL.glVertex3dv(patch1.Array);
                        if (bodynear2)
                        {
                            GL.glColor3d(1.0, 1.0, 1.0);
                        }
                        else if (bodynearnear2)
                        {
                            GL.glColor3d(0.6, 0.6, 0.6);
                        }
                        else
                        {
                            if ((section & 1) == 0)
                                GL.glColor3d(1.0//(double)section/(double)sections
                                , 0.0, 1.0);
                            else
                                GL.glColor3d(0.0, 1.0 //(double)section/(double)sections
                                , 1.0);
                            //glColor3f( 0,0,0 );
                        }
                        GL.glVertex3dv(patch2.Array);
                    }
                }
                GL.glEnd();
            }
        }

        //pole[] pole_patches;

        bool DrawSphereThing()
        {
            //which is a 1x1x1 sort of patch array
            RenderBandPatch();
			RenderPolePatch( false );
			RenderPolePatch( true );
            return true;
        }

        //void MatePoleEdge( HexPatch patch, int section, PSQUAREPATCH square )
        //{
        //}


        void MateEdge(int section1, int section2)
        {
            int n;
            Console.WriteLine("mating %d and %d", section1, section2);
            switch (section1)
            {
                case 0:
                    switch (section2)
                    {
                        case 0:
                            break;
                        case 1:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[section2, n, 0] =
                                    world_map.height[section1, n, HEX_SIZE - 1];
                            break;
                        case 2:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[section2, 0, n] =
                                    world_map.height[section1, HEX_SIZE - 1, n];
                            break;
                    }
                    break;
                case 1:
                    switch (section2)
                    {
                        case 0:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[section2, n, HEX_SIZE - 1] =
                                    world_map.height[section1, n, 0];
                            break;
                        case 1:
                            break;
                        case 2:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[section2, n, HEX_SIZE - 1] =
                                    world_map.height[section1, HEX_SIZE - 1, n];
                            break;
                    }
                    break;
                case 2:
                    switch (section2)
                    {
                        case 0:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[section2, HEX_SIZE - 1, n] =
                                    world_map.height[section1, 0, n];
                            break;
                        case 1:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[section2, HEX_SIZE - 1, n] =
                                    world_map.height[section1, n, HEX_SIZE - 1];
                            break;
                        case 2:
                            break;
                    }
                    break;
            }
        }



        void MateAnotherEdge(int patch1, int patch2, int section1, int section2)
        {
            int n;
            Console.WriteLine("mating %d and %d", section1, section2);
            switch (section1)
            {
                case 0:
                    switch (section2)
                    {
                        case 0:
                            break;
                        case 1:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[patch1 + section1, n, 0] =
                                    world_map.height[patch2 + section2, n, HEX_SIZE - 1];
                            break;
                        case 2:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[patch1 + section1, 0, n] =
                                    world_map.height[patch2 + section2, HEX_SIZE - 1, n];
                            break;
                    }
                    break;
                case 1:
                    switch (section2)
                    {
                        case 0:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[patch1 + section1, n, HEX_SIZE - 1] =
                                    world_map.height[patch2 + section2, n, 0];
                            break;
                        case 1:
                            break;
                        case 2:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[patch1 + section1, 0, n] =
                                    world_map.height[patch2 + section2, n, 0];
                            break;
                    }
                    break;
                case 2:
                    switch (section2)
                    {
                        case 0:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[patch1 + section1, HEX_SIZE - 1, n] =
                                    world_map.height[patch2 + section2, 0, n];
                            break;
                        case 1:
                            for (n = 0; n < HEX_SIZE; n++)
                                world_map.height[patch1 + section1, n, 0] =
                                    world_map.height[patch2 + section2, 0, n];
                            break;
                        case 2:
                            break;
                    }
                    break;
            }
        }

        void CreatePatch()
        {
            int s;
            // create both polar patches for quick hack.
            //HexPatch[] patch = new HexPatch[2];
            //MemSet( patch, 0, sizeof( HEXPATCH ) * 2 );
            //SetPoint( patch.origin, _0 );
            int[,] mating_edges = new int[6, 2] { { 0, 1 }, { 2, 1 }, { 2, 0 }
								 , { 1, 0 }, { 1, 2 }, { 0, 2 } };

            for (s = 0; s < 6; s++)
            {
                MateAnotherEdge(s / 2, s
                                    , mating_edges[s, 0]
                                    , mating_edges[s, 1]);

            }
        }

        // only bodies within a certain grid portion need to be checked
        // for_all_near_bodies...
        // where near_area is for x-3, y-3 to x+3, y+3 and finding bodies in those sectors;

        void ConvertToSphereGrid(Vector3 p, out int s, out int x, out int y) // s 0-3, s 4-9, 10-12
        {
            // vertical projection... soh cah toa, cah  cos of angle...
            p.Normalize();
            (x) = -1;
            (y) = -1;
            //Console.WriteLine( "z is %g", p[2] );
            (s) = 0;
            if (p[Transform.vUp] < -0.5)
            {
                //(*s) = 10;
                p[Transform.vUp] = -p[Transform.vUp];
            }
            else // north is 9+ // south is normal.
                (s) = 9;
            if (p[Transform.vUp] > 0.5)
            {
                int level;
                int r;
                int tmpx = 0;
                int tmpy = 0;
                int _tmpx = 0, _tmpy = 0;
                Vector3 v = new Vector3(p[0], 0, p[2]);
                double len = v.Magnitude;
                /*
                        if( *s )

                            Console.WriteLine( "South pole" );
                        else
                            Console.WriteLine( "North pole" );
                            */
                //Console.WriteLine( "radial length: %g", len );
                //PrintVector( p );
                for (level = 0; level <= HEX_SIZE; level++)
                {
                    //PrintVector( pole_patch.patches[0].grid[level,0] );
                    if (len < -world_map.grid[3, level, 0][Transform.vRight])
                    {
                        //Console.WriteLine( "Comparison is %g > %g at %d", len, pole_patch.patches[0].grid[level,0,vRight], level );
                        //Console.WriteLine( "result level is %d", level );
                        level = level - 1;
                        break;
                    }
                }
                if (p[Transform.vForward] > 0)
                {
                    //Console.WriteLine( "forward from origin..." );
                    if (p[Transform.vRight] > -0.5)
                    {
                        for (r = 0; r <= (level * 2); r++)
                        {
                            ConvertPolarToRect(level, r, out tmpx, out tmpy);
                            //PrintVector( pole_patch.patches[0].grid[tmpx,tmpy] );
                            if (p[Transform.vRight] < world_map.grid[3, tmpx, tmpy][Transform.vRight])
                            {
                                break;
                            }
                            _tmpx = tmpx;
                            _tmpy = tmpy;
                        }
                        if (r != 0)
                        {
                            tmpx = _tmpx;
                            tmpy = _tmpy;
                        }
                        s += 0;
                    }
                    else
                    {
                        for (r = 0; r <= (level * 2); r++)
                        {
                            ConvertPolarToRect(level, r, out tmpx, out tmpy);
                            if (p[Transform.vUp] > world_map.grid[4, tmpx, tmpy][Transform.vUp])
                                break;
                            _tmpx = tmpx;
                            _tmpy = tmpy;
                        }
                        if (r != 0)
                        {
                            tmpx = _tmpx;
                            tmpy = _tmpy;
                        }
                        s += 1;
                    }
                    x = tmpx;
                    y = tmpy;
                }
                else
                {
                    if (p[Transform.vRight] > -0.5)
                    {
                        for (r = 0; r <= (level * 2); r++)
                        {
                            ConvertPolarToRect(level, r, out tmpx, out tmpy);
                            if (p[Transform.vRight] > world_map.grid[3, tmpx, tmpy][Transform.vRight])
                                break;
                            _tmpx = tmpx;
                            _tmpy = tmpy;
                        }
                        if (r != 0)
                        {
                            tmpx = _tmpx;
                            tmpy = _tmpy;
                        }
                        s += 2;
                    }
                    else
                    {
                        for (r = 0; r <= (level * 2); r++)
                        {
                            ConvertPolarToRect(level, r, out tmpx, out tmpy);
                            if (p[Transform.vUp] > world_map.grid[4, tmpx, tmpy][Transform.vUp])
                                break;
                            _tmpx = tmpx;
                            _tmpy = tmpy;
                        }
                        if (r != 0)
                        {
                            tmpx = _tmpx;
                            tmpy = _tmpy;
                        }
                        s += 1;
                    }
                    (x) = tmpx;
                    (y) = tmpy;
                }
            }
            else
            {
                int level; // y level of band
                //Console.WriteLine( "equator" );
                //PrintVector( p );
                // turns out the the band coordinates are stored from top town... and that everything
                // we're viewing is upside down.
                for (level = 0; level < HEX_SIZE; level++)
                {
                    if (p[Transform.vUp] < world_map.grid[3, 0, level][Transform.vUp])
                    {
                        break;
                    }
                }
                (y) = level - 1;
                (s) = 3;
                if (p[Transform.vRight] > 0.5)
                {
                    if (p[Transform.vForward] > 0)
                    {
                        int n;
                        for (n = 0; n < HEX_SIZE; n++)
                        {
                            //PrintVector( _band.patches[0].grid[n,level] );
                            if (p[Transform.vForward] < world_map.grid[3, n, level][Transform.vForward])
                            {
                                break;
                            }
                        }
                        x = n--;
                        s += 0;
                    }
                    else
                    {
                        int n;
                        for (n = 0; n < HEX_SIZE; n++)
                        {
                            //PrintVector(_band.patches[5].grid[n,level] );
                            if (p[Transform.vForward] < world_map.grid[8, n, level][Transform.vForward])
                                break;
                        }
                        (x) = n - 1;
                        (s) += 5;
                    }
                }
                else if (p[Transform.vRight] < -0.5)
                {
                    if (p[Transform.vForward] > 0)
                    {
                        int n;
                        for (n = 0; n < HEX_SIZE; n++)
                        {
                            if (p[Transform.vForward] > world_map.grid[5, n, level][Transform.vForward])
                                break;
                        }
                        (x) = n - 1;
                        (s) += 2;
                    }
                    else
                    {
                        int n;
                        for (n = 0; n < HEX_SIZE; n++)
                        {
                            if (p[Transform.vForward] > world_map.grid[6, n, level][Transform.vForward])
                                break;
                        }
                        (x) = n - 1;
                        (s) += 3;
                    }
                }
                else
                {
                    if (p[2] > 0)
                    {
                        int n;
                        for (n = 0; n < HEX_SIZE; n++)
                        {
                            if (p[Transform.vRight] > world_map.grid[4, n, level][Transform.vRight])
                                break;
                        }
                        (x) = n - 1;
                        (s) += 1;
                    }
                    else
                    {
                        int n;
                        for (n = 0; n < HEX_SIZE; n++)
                        {
                            //PrintVector( _band.patches[4].grid[n,level] );
                            if (p[Transform.vRight] < world_map.grid[7, n, level][Transform.vRight])
                                break;
                        }
                        (x) = n - 1;
                        (s) += 4;
                    }
                }
                //Console.WriteLine( "Middle Band" );
            }

            //Console.WriteLine( "Result %d,%d,%d", (*s), (*x), (*y) );
            //   sqrt( p[0]*p[0]+p[2]*p[2] )

        }

        enum displaymode
        {
            MODE_UNKNOWN,
            MODE_PERSP,
            MODE_ORTHO
        }
        displaymode mode = displaymode.MODE_UNKNOWN;

        void BeginVisPersp()
        {
            //if( mode != MODE_PERSP )
            {
                mode = displaymode.MODE_PERSP;
                GL.glMatrixMode(GL.GL_PROJECTION);						// Select The Projection Matrix
                GL.glLoadIdentity();									// Reset The Projection Matrix
                // Calculate The Aspect Ratio Of The Window
                GLU.gluPerspective(45.0f, 1.0f, 0.1f, 10000.0f);
                GL.glMatrixMode(GL.GL_MODELVIEW);							// Select The Modelview Matrix
                GL.glLoadIdentity();									// Reset The Modelview Matrix
            }
        }

        bool InitGL()										// All Setup For OpenGL Goes Here
        {

            GL.glShadeModel(GL.GL_SMOOTH);							// Enable Smooth Shading
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);				// Black Background
            GL.glClearDepth(1.0f);									// Depth Buffer Setup
            GL.glEnable(GL.GL_DEPTH_TEST);							// Enables Depth Testing
            GL.glDepthFunc(GL.GL_LEQUAL);								// The Type Of Depth Testing To Do
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_Hint, GL.GL_NICEST);	// Really Nice Perspective Calculations
            BeginVisPersp();
            return true;										// Initialization Went OK
        }

#if asdfasdff
int ShowPatch(  )
{
	int x, y, s;
	if( !DrawSphereThing( patch ) )
		return 0;
	GL.glBegin(GL.GL_TRIANGLES);
	GL.glColor3d( 1.0, 1.0, 1.0 );
	GL.glVertex3d( patch[0].origin[0] - 1 * HEX_HORZ_STRIDE
				 , patch[0].origin[1] + 1.2f * HEX_HORZ_STRIDE
				 , patch[0].origin[2] );
	GL.glVertex3d( patch[0].origin[0] - 1 * HEX_HORZ_STRIDE
				 , patch[0].origin[1] - 1.2f * HEX_HORZ_STRIDE
				 , patch[0].origin[2] );
	GL.glVertex3d( patch[0].origin[0] + 1 * HEX_HORZ_STRIDE
				 , patch[0].origin[1] - 0
				 , patch[0].origin[2] );
	GL.glEnd();					// Done Drawing The Cube

	for( s = 0; s < 3; s++ )
//	for( s = 0; s < 2; s++ )
//   s=2;
	{
		for( x = 0; x < HEX_SIZE; x++ )
      //x = 0 ;
		{
			GL.glBegin( GL.GL_TRIANGLE_STRIP );
			// the way this works, Y will be represented as +1
			// make ssense? no... that is Y and Y+1 are alwasy
         // used, therefore at HEX_SIZE-1, HEX_SIZE-1+1 is invalid.
			for( y = 0; y < (HEX_SIZE-1); y++ )
			{
				switch( s )
				{
				case 0:
					//glBegin(GL_TRIANGLES);
					if( y == 0 )
					{
						GL.glColor3d( 0.0, 1.0, 0.0 );
						GL.glVertex3d( patch[0].origin[0]
									  - (HEX_SIZE-x) * HEX_HORZ_STRIDE
									  + y * HEX_HORZ_STRIDE/2
									 , patch[0].origin[1]
									  - (-y) * HEX_VERT_STRIDE
									 , patch[0].origin[2]
									  - patch[0].height[s, x, y] );

						GL.glColor3d( 0.0, 1.0, 1.0 );
						GL.glVertex3d( patch[0].origin[0]
									  - (HEX_SIZE-(x+1)) * HEX_HORZ_STRIDE
									  + y * HEX_HORZ_STRIDE/2
									 , patch[0].origin[1]
									  - (-y) * HEX_VERT_STRIDE
									 , patch[0].origin[2]
									  - ((x!=HEX_SIZE-1)
									  ? patch[0].height[s, (x + 1), y]
									  : patch[0].height[2, 0, y]) );
					}
					GL.glColor3d( 0.0, 0.0, 1.0 );
					GL.glVertex3d( patch[0].origin[0]
								  - (HEX_SIZE-x) * HEX_HORZ_STRIDE
								  + (y+1) * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  - (-(y+1)) * HEX_VERT_STRIDE
								 , patch[0].origin[2]
								  - patch[0].height[s, x, (y + 1)] );
					GL.glColor3d( 1.0, 0.0, 1.0 );
					GL.glVertex3d( patch[0].origin[0]
								  - (HEX_SIZE-(x+1)) * HEX_HORZ_STRIDE
								  + (y+1) * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  - (-(y+1)) * HEX_VERT_STRIDE
								 , patch[0].origin[2]
								  - ((x!=HEX_SIZE-1)
								  ? patch[0].height[s, x + 1, y + 1]
								  : patch[0].height[2, 0, y + 1]) );
					break;
				case 1:
					//glBegin(GL_TRIANGLES);
				//	Console.WriteLine( "uhh %g %g %g"
				//			 ,patch.origin[0] - (HEX_SIZE-x) * HEX_HORZ_STRIDE/2 - y * HEX_HORZ_STRIDE/2
				//			 , patch.origin[1] - (HEX_SIZE-y) * HEX_VERT_STRIDE
            //           , patch.origin[2] - world_map.height[s,x,y] );
					//   tmp = patch.origin[0] - (HEX_SIZE-x) * HEX_HORZ_STRIDE - y * HEX_HORZ_STRIDE/2;
					//if( y == 0 )
					{
						GL.glColor3d( 1.0, 0.0, 0.0 );
						GL.glVertex3d( patch[0].origin[0]
									  - (HEX_SIZE-(x)) * HEX_HORZ_STRIDE
									  + y * HEX_HORZ_STRIDE/2
									 , patch[0].origin[1]
									  - (+y) * HEX_VERT_STRIDE
									 , patch[0].origin[2]
									  - patch[0].height[s, x, y] );
						GL.glColor3d( 0.0, 0.0, 1.0 );
						GL.glVertex3d( patch[0].origin[0]
									  - (HEX_SIZE-(x+1)) * HEX_HORZ_STRIDE
									  + y * HEX_HORZ_STRIDE/2
									 , patch[0].origin[1]
									  - (+y) * HEX_VERT_STRIDE
									 , patch[0].origin[2]
									  - ((x!=HEX_SIZE-1)
									  ? patch[0].height[s, x + 1, y]
									  : patch[0].height[2, y, 0])
									 );
					}
					GL.glColor3d( 0.0, 1.0, 1.0 );
					GL.glVertex3d( patch[0].origin[0]
								  - (HEX_SIZE-(x)) * HEX_HORZ_STRIDE
								  + (y+1) * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  - (+y+1) * HEX_VERT_STRIDE
								 , patch[0].origin[2]
								  - patch[0].height[s, x, y + 1] );
					GL.glColor3d( 1.0, 1.0, 0.0 );
					GL.glVertex3d( patch[0].origin[0]
								  - (HEX_SIZE-(x+1)) * HEX_HORZ_STRIDE
								  + (y+1) * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  - (+(y+1)) * HEX_VERT_STRIDE
								 , patch[0].origin[2]
								  - ((x!=HEX_SIZE-1)
								  ? patch[0].height[s, x + 1, (y + 1)]
								  : patch[0].height[2, y + 1, 0])
								 );
               //glEnd();
					break;
				case 2:
//					GL.glBegin(GL_TRIANGLES);
					//glColor3f( (1.0 * y) / HEX_SIZE, (1.0 * x) / HEX_SIZE, 1.0 );
			  // 	Console.WriteLine( "uhh %g %g %g"
			  // 			 ,patch.origin[0] - (HEX_SIZE-x) * HEX_HORZ_STRIDE/2 - y * HEX_HORZ_STRIDE/2
			  // 			 , patch.origin[1] - (HEX_SIZE-y) * HEX_VERT_STRIDE
           //            , patch.origin[2] - world_map.height[s,x,y] );
					//    tmp = patch.origin[0] - (HEX_SIZE-x) * HEX_HORZ_STRIDE/2 - y * HEX_HORZ_STRIDE/2;
					if( y == 0 )
					{
						GL.glColor3d( 1.0, 0.0, 1.0 );
						GL.glVertex3d( patch[0].origin[0]
								  + (x) * HEX_HORZ_STRIDE/2
								  + y * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  + (y) * HEX_VERT_STRIDE
                          - ( x * HEX_VERT_STRIDE )
								 , patch[0].origin[2] - patch[0].height[s, x, y] );
						GL.glColor3d( 1.0, 0.0, 0.0 );
					GL.glVertex3d( patch[0].origin[0]
								  + ((x+1)) * HEX_HORZ_STRIDE/2
								  + (y) * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  + (y) * HEX_VERT_STRIDE
                          - ( (x+1) * HEX_VERT_STRIDE )
								 , patch[0].origin[2]
								  - ((x!=HEX_SIZE-1)
								  ? patch[0].height[s, (x + 1), y]
								  : 0)
								 );
					}
						GL.glColor3d( 1.0, 1.0, 0.0 );
						GL.glVertex3d( patch[0].origin[0]
								  + (x) * HEX_HORZ_STRIDE/2
								  + (y	+1) * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  + (y+1) * HEX_VERT_STRIDE
                          - ( x * HEX_VERT_STRIDE )
								 , patch[0].origin[2] - patch[0].height[s, x, y + 1] );
						GL.glColor3d( 0.0, 1.0, 1.0 );
						GL.glVertex3d( patch[0].origin[0]
								  + (x+1) * HEX_HORZ_STRIDE/2
								  + (y+1) * HEX_HORZ_STRIDE/2
								 , patch[0].origin[1]
								  + ((y+1)) * HEX_VERT_STRIDE
                          - ( (x+1) * HEX_VERT_STRIDE )
								 , patch[0].origin[2]
								  - ((x!=HEX_SIZE-1)
								  ? patch[0].height[s, x + 1, (y + 1)]
								  : 0) // not sure what this would be... next patch I suppose...
								 );
//					GL.glEnd();					// Done Drawing The Cube
					break;
				}
			}
				GL.glEnd();					// Done Drawing The Cube
		}
	}
   /*
	GL.glBegin(GL_TRIANGLES);
	GL.glColor3f( 1.0, 1.0, 1.0 );
	GL.glVertex3f( patch.origin[0] - 1 * HEX_HORZ_STRIDE/3
				 , patch.origin[1] + 1.2f * HEX_HORZ_STRIDE/3
				 , patch.origin[2] );
	GL.glVertex3f( patch.origin[0] - 1  * HEX_HORZ_STRIDE/3
				 , patch.origin[1] - 1.2f * HEX_HORZ_STRIDE/3
				 , patch.origin[2] );
	GL.glVertex3f( patch.origin[0] + 1  * HEX_HORZ_STRIDE/3
				 , patch.origin[1] - 0
				 , patch.origin[2] );
				 glEnd();
				 */// Done Drawing The Cube
  GL.glFlush();
  return 1;
}

#endif
        int[, ,] delta_table = new int[,,] { { { -1,0 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 0, 1 }, { -1, 1 } }
											 , { { -1,0 }, {-1, 1 }, { 0, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 } }
											 , { { -1, -1 }, { 0, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 0 } }
};

        void DistortPatch( //HexPatch patch
                              int section, int x, int y
                              , double delta // delta up/down for this point.
                              , double tension // tension between this point and near points.
                              , double radius // total radius to consider moving... (tension?)
                              )
        {
            if (tension >= 1.0 || tension <= -1.0)
                return;
            //if( delta < 0.0001 )
            //   return;
            //while( delta > 0.00001 )
            {
                int[,] near_points = new int[6, 3];
                //Console.WriteLine( "Delta is %g", delta );
                for (int p = 0; p < 6; p++)
                {
                    near_points[p, 0] = x + delta_table[section, p, 0];
                    near_points[p, 1] = y + delta_table[section, p, 1];
                    near_points[p, 2] = section;
                }
                world_map.height[section, x, y] += delta;
                switch (section)
                {
                    case 0:
                        if (y == 0)
                        {
                            world_map.height[1, x, 0] = world_map.height[section, x, y];
                            near_points[1, 2] = 1;
                            near_points[1, 0] = x;
                            near_points[1, 1] = 1;
                            if (x == (HEX_SIZE - 1))
                            {
                                Console.WriteLine("this isn't right... might not be...");
                                near_points[2, 2] = 2;
                                near_points[2, 0] = 1;
                                near_points[2, 1] = 1;
                            }
                            else
                            {
                                near_points[2, 2] = 1;
                                near_points[2, 0] = x + 1;
                                near_points[2, 1] = 1;
                            }
                        }
                        if (x == 0)
                        {
                            near_points[0, 2] = -1;
                            near_points[5, 2] = -1;
                            /*
                                if( y == (HEX_SIZE-1) )
                                {
                                    near_points[5,2] = -1;
                                }
                                else
                                {
                               near_points[5,2] = 2;
                                    }
                               */
                        }
                        if (x == (HEX_SIZE - 1))
                        {
                            world_map.height[2, y, 0] = world_map.height[section, x, y];
                            near_points[3, 2] = 2;
                            near_points[3, 0] = 0;
                            near_points[3, 1] = y;
                            if (y != 0)
                            {
                                near_points[2, 2] = 2;
                                near_points[2, 0] = y;
                                near_points[2, 1] = 1;
                            }
                            // near_point 2 is taken care of above?
                        }
                        if (y == (HEX_SIZE - 1))
                        {
                            world_map.height[2, y, 0] = world_map.height[section, x, y];
                            near_points[4, 2] = -1;
                            near_points[5, 2] = -1;
                        }
                        break;
                    case 1:
                        if (x == 0)
                        {
                            near_points[0, 2] = -1;
                            near_points[1, 2] = -1;
                        }
                        if (y == 0)
                        {
                            near_points[4, 2] = -1;
                            near_points[5, 2] = -1;
                        }
                        if (x == (HEX_SIZE - 1))
                        {
                            near_points[3, 2] = -1;
                            near_points[4, 2] = -1;
                        }
                        if (y == (HEX_SIZE - 1))
                        {
                            near_points[1, 2] = -1;
                            near_points[2, 2] = -1;
                        }
                        break;
                    case 2:
                        if (x == 0)
                        {
                            near_points[0, 2] = -1;
                            near_points[5, 2] = -1;
                        }
                        if (y == 0)
                        {
                            near_points[0, 2] = -1;
                            near_points[1, 2] = -1;
                        }
                        if (x == (HEX_SIZE - 1))
                        {
                            near_points[2, 2] = -1;
                            near_points[3, 2] = -1;
                        }
                        if (y == (HEX_SIZE - 1))
                        {
                            near_points[3, 2] = -1;
                            near_points[4, 2] = -1;
                        }
                        break;
                }
                {
                    for (int p = 0; p < 6; p++)
                    {
                        if (near_points[0, 2] >= 0)
                            world_map.height[near_points[p, 2], near_points[p, 0], near_points[p, 1]] += delta * tension;
                    }
                }
                //delta *= tension;
            }
        }

        Random rx = new Random();

        void RipplePatch(int s)
        {
            //int n;
            int x, y;
            double distort;
            int sector;
            sector = rx.Next(12);
            x = rx.Next(HEX_SIZE);
            y = rx.Next(HEX_SIZE);
            distort = (double)rx.NextDouble();

            distort *= (rx.Next(255) < 0x80) ? -1 : 1;
            //distort *= 1.5;
            distort *= HEX_SCALE * 0.75;
            DistortPatch(sector, x, y, distort, 0.5, 0);

        }

#if asdfasdfasdf

	PTRANSFORM T;
	POBJECT current;

	void CPROC UpdateUserBot( PTRSZVAL unused )
	{
		static VECTOR KeySpeed, KeyRotation;
		//static VECTOR move = { 0.01, 0.02, 0.03 };
		{
			extern void ScanKeyboard( PRENDERER hDisplay, PVECTOR KeySpeed, PVECTOR KeyRotation );
			ScanKeyboard( NULL, KeySpeed, KeyRotation );
			SetSpeed( T, KeySpeed );
			SetRotation( T, KeyRotation );
			Move(T);  // relative rotation...
		}
		if( IsKeyDown( NULL, KEY_N ) )
		{
			if( current )
			{
				current = NULL;
				//LookAt( 
			}
			else
			{
				current = (POBJECT)GetLink( &cycles, 0 );
			}
		}
		{
			static int xdel1;
			static int ydel1;
			static int sdel1;
			static int xdel2;
			static int ydel2;
			static int sdel2;
			if( !xdel1 && IsKeyDown( NULL, KEY_1 ) )
			{
				cur_x ++;
				if( cur_x == HEX_SIZE )
				{
					cur_x = 0;
				}
				xdel1 = 1;
			}
			else if( xdel1 && !IsKeyDown( NULL, KEY_1 ) )
				xdel1 = 0;
			if( !xdel2 && IsKeyDown( NULL, KEY_2 ) )
			{
				if( cur_x )
					cur_x--;
				else
					cur_x = HEX_SIZE -1;
				xdel2 = 1;
			}
			else if( xdel2 && !IsKeyDown( NULL, KEY_2 ) )
				xdel2 = 0;

			if( !ydel1 && IsKeyDown( NULL, KEY_3 ) )
			{
				cur_y++;
				if( cur_y == HEX_SIZE )
					cur_y = 0;
				ydel1 = 1;
			}
			else if( ydel1 && !IsKeyDown( NULL, KEY_3 ) )
				ydel1 = 0;

			if( !ydel2 && IsKeyDown( NULL, KEY_4 ) )
			{
				if( cur_y )
					cur_y--;
				else
					cur_y = HEX_SIZE-1;
				ydel2 = 1;
			}
			else if( ydel2 && !IsKeyDown( NULL, KEY_4 ) )
				ydel2 = 0;

			if( !sdel1 && IsKeyDown( NULL, KEY_5 ) )
			{
				cur_s++;
				if( cur_s == 12 )
					cur_s = 0;
				sdel1 = 1;
			}
			else if( sdel1 && !IsKeyDown( NULL, KEY_5 ) )
				sdel1 = 0;

			if( !sdel2 && IsKeyDown( NULL, KEY_6 ) )
			{
				if( cur_s )
					cur_s--;
				else
					cur_s = 11;
				sdel2 = 1;
			}
			else if( sdel2 && !IsKeyDown( NULL, KEY_6 ) )
				sdel2 = 0;
		//add( KeyRotation, KeyRotation, move );
		if(0)
		{
			static int n;
			char filename[32];
			n++;
			if( n > 25 ) n = 0;
			snprintf( filename, sizeof( filename ), "state-%d", n );
			{
				FILE *last = fopen( "state-last", "wt" );
				fprintf( last, "%d", n );
				fclose( last );
			}
			SaveTransform( T, filename );
		}
		//SaveTransform( T, "recoverme" );
	}
	if( !bwait_move_gliders )
	{
		INDEX idx;
		PBODY body;
		POBJECT glider;
		LIST_FORALL( bodies, idx, PBODY, body )
		{
			GL.glider = body.object;
			//Console.WriteLine( "body.speed %g", body.speed );
			Forward( glider.Ti, body.speed / 25.60 );
			//Rotate( a,m[vForward],m[vRight] )
			{
				VECTOR r;
				r[0] = 0;
				r[1] = (body.rotation / 256.0) / 20.0 ;
				r[2] = 0;
				SetRotation( glider.Ti, r );
			}
			body.Move();
		}
	}
		}



enum {
	LISTBOX_BODIES=5000
	, BUTTON_SHOW_BRAIN
} ;

PRELOAD( RegisterResources )
{
	EasyRegisterResource( "terrain/body interface", LISTBOX_BODIES, LISTBOX_CONTROL_NAME  );
	EasyRegisterResource( "terrain/body interface", BUTTON_SHOW_BRAIN, NORMAL_BUTTON_NAME );
}

void CPROC ShowBrain( PTRSZVAL psv, PSI_CONTROL button )
{
	PSI_CONTROL list = GetNearControl( button, LISTBOX_BODIES );
	PLISTITEM pli = GetSelectedItem( list );
	if( pli )
	{
		PBODY body = (PBODY)GetItemData( pli );
		if( !body.board )
			body.board = CreateBrainBoard( body.brain );
	}
}

static void CPROC BoardCloseEvent( PTRSZVAL psv, PIBOARD board )
{
	PBODY body = (PBODY)psv;
	body.board = NULL;
}

void CPROC ShowSelectedBrain( PTRSZVAL psv, PSI_CONTROL pc, PLISTITEM pli )
{
	PBODY body = (PBODY)GetItemData( pli );
	if( !body.board )
	{
		body.board = CreateBrainBoard( body.brain );
		GetBoard( body.board ).SetCloseHandler( BoardCloseEvent, (PTRSZVAL)body );
	}
}

void CreateBodyInterface()
{
	PSI_CONTROL frame = LoadXMLFrame( "BodyInterface.Frame" );
	if( frame )
	{
		PSI_CONTROL list = GetControl( frame, LISTBOX_BODIES );
		SetButtonPushMethod( GetControl( frame, BUTTON_SHOW_BRAIN ), ShowBrain, 0 );
		SetDoubleClickHandler( list, ShowSelectedBrain, 0 );
		{
			INDEX idx;
			PBODY body;
			LIST_FORALL( bodies, idx, PBODY, body )
			{
				char name[256];
				snprintf( name, sizeof( name ), "Body %d", idx );
				SetItemData( AddListItem( list, name ), (PTRSZVAL)body );
			}
		}
		DisplayFrame( frame ); // leave it open forever?
	}
}

void CreateBodies( POBJECT pWorld )
{
	int n;
	PBODY body;
	POBJECT glider;
	VECTOR v;
	for( n = 0; n < BODY_COUNT; n++ )
	{
		AddLink( &gliders, glider = MakeGlider() );
		PutIn( pWorld, glider );
		scale( v, _Z, (3000/3600)/100 ); // 3 k/hr
		SetSpeed( glider.Ti, v );
		//SetSpeed( glider.Ti, _Y );
		Translate( glider.Ti, 0, SPHERE_SIZE, 0 );
		{
			//VECTOR v1,v2,v3;
			//scale( v1, _X, 1 );
			//GetAxisV( glider.Ti, v2, vRight );
			// in two operations one can observe
			// the tip in pitch because of forward motion
			//RotateAround( glider.Ti, v2, 0 );
		}
		//.RotateRel( glider.Ti, 0, ( 6.14 * n ) / 100.0, 0 );
		RotateRel( glider.Ti, 0, ( 6.28 * n ) / 4.0, 0 );
		Forward( glider.Ti, 50 );
		
			AddLink( &bodies, body = new Glider( glider ) );
	}
	AddLink( &gliders, glider = MakeGlider() );
	AddLink( &cycles, glider = MakeGlider() );
	PutIn( pWorld, glider );
	scale( v, _Z, (3000/3600)/100 ); // 3 k/hr
	SetSpeed( glider.Ti, v );
	//SetSpeed( glider.Ti, _Y );
	Translate( glider.Ti, 0, SPHERE_SIZE, 0 );
	AddLink( &bodies, body = new CyberCycle( glider ) );
	bwait_move_gliders = 0;
}

#endif

#if asdfasdfasdf
POBJECT CreateWorldCubeThing( Vector3 v, Colors color )
{
		POBJECT pWorld;
	{
		pWorld = CreateScaledInstance( CubeNormals, CUBE_SIDES, 2, v, (PVECTOR)_Z, (PVECTOR)_X, (PVECTOR)_Y );
		SetObjectColor( pWorld, color );
      /// is also the same as AddRootObject
		SetRootObject( pWorld );
		{
			VECTOR r;
			r[0] = 0.05;
			r[1] = 0.02;
			r[2] = 0.15;
			SetRotation( pWorld.Ti, r );
		}
	}
      return pWorld;
}
#endif
        Transform TCam;
        Transform T_camera;


        //PVIEW view;

        //int bEnabledGL;


        static int n = 19;
        static bool first = true;
        static int d;

		void hexland_Render( FrameEventArgs e )
        {

            //WGL.wglMakeCurrent(DC, RC);

            InitGL();
            //SaveTransform( T, "recoverme" );
            double[] m = new double[16];
            Transform T;
            //if (false)
            {
                Transform[] tmp = new Transform[2];
                //char buffer[32];
                n++;
                if (n > 21) n = 0;
                //LoadTransform( &tmp[d], "state-"+n );
                //tmp[d].ShowTransform();
                //if( ( tmp[d].m[0,1] > 0.983537 )
                //  &&( tmp[d].m[0,1] < 0.983539 ) )
                //	DebugBreak();
                if (first)
                {
                    first = false;
                    return;
                    //continue;
                }
                T = tmp[d];
                //memcpy( T[0].rotation, tmp[d].rotation, sizeof( tmp[d].rotation ) );
                //memcpy( T[0].speed, tmp[d].speed, sizeof( tmp[d].speed ) );
                //Move( T );
                //ShowTransform( T );
                T = tmp[d];
                d = 1 - d;
            }
            //LoadTransform( T, "state-21" );
            //PrintMatrix( T.m );
            //LoadTransform( T, "state-22" );
            //PrintMatrix( T.m );
            //LoadTransform( T, "state-23" );
            //PrintMatrix( T.m );
            //LoadTransform( T, "recoverme" );
            //PrintMatrix( T );
            //Console.WriteLine( "Getting matrix..." );
            if (T_camera == null)
                T_camera = new Transform();
            T_camera.GetGLMatrix(m);
            GL.glLoadMatrixd(m);
            //RipplePatch( patch );
            //RipplePatch( patch+1 );
            //GL.glClear(GL.GL_COLOR_BUFFER_BIT
            //    | GL.GL_DEPTH_BUFFER_BIT
            //    );	// Clear Screen And Depth Buffer
            //glLoadIdentity();
            //glTranslatef((-1.5f),1.0f,-30.0);		// Move Left 1.5 Units And Into The Screen 6.0
            DrawSphereThing();
            //ShowPatch( patch );
            //if( T.m[3,2] != 0 )
            //	 DebugBreak();
            //PrintVector( GetOrigin( T ) );

            //ShowObjects(NULL,&TCam);
            //GL.glFlush();													// Flush The GL Rendering Pipeline
            //WGL.wglSwapBuffers(DC);
#if asdfadsf
		{
			INDEX idx;
			PBODY body;

			LIST_FORALL( bodies, idx, PBODY, body )
			{
				body.Draw();
			}
			ShowObjects(view,T_camera);
		}
		VTest.Step();

		SetActiveGLDisplay( NULL );
#endif
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // hexland
            // 
            this.Name = "hexland";
            this.ResumeLayout(false);

        }

        private void Hexland_KeyDown( object sender, OpenTK.Input.KeyboardKeyEventArgs e )
        {
			if( e.Key == OpenTK.Input.Key.A )
			{
				T_camera.TurnLeft( 0.01 );
				//e.Handled = true;
			}
			if( e.Key == OpenTK.Input.Key.D )
			{
				T_camera.TurnRight( 0.01 );
				//e.Handled = true;
			}
			if( e.Key == OpenTK.Input.Key.W )
			{
				T_camera.Forward( 100.0 );
				//e.Handled = true;
			}
			if( e.Key == OpenTK.Input.Key.S )
			{
				T_camera.Forward( -100.0 );
				//e.Handled = true;
			}
			if( e.Key == OpenTK.Input.Key.R )
			{
				T_camera.TurnUp( -0.01 );
				//e.Handled = true;
			}
			if( e.Key == OpenTK.Input.Key.F )
			{
				T_camera.TurnUp( 0.01 );
				//e.Handled = true;
			}
			if( e.Key == OpenTK.Input.Key.Q )
			{
				T_camera.RollLeft( 0.01 );
				//e.Handled = true;
			}
			if( e.Key == OpenTK.Input.Key.E )
			{
				T_camera.RollRight( 0.01 );
				//e.Handled = true;
			}
			//if( !e.Handled )
				//base.OnKeyDown( e );
		}
        private void Hexland_KeyUp( object sender, OpenTK.Input.KeyboardKeyEventArgs e )
		{
			if( e.Key == OpenTK.Input.Key.A )
			{
				T_camera.TurnLeft( 0.0 );
			}
			if( e.Key == OpenTK.Input.Key.D )
			{
				T_camera.TurnRight( 0.0 );
			}
			if( e.Key == OpenTK.Input.Key.W )
			{
				T_camera.Forward( 0.0 );
			}
			if( e.Key == OpenTK.Input.Key.S )
			{
				T_camera.Forward( 0.0 );
			}
			if( e.Key == OpenTK.Input.Key.Q )
			{
				T_camera.RollLeft( 0.0 );
			}
			if( e.Key == OpenTK.Input.Key.E )
			{
				T_camera.RollLeft( 0.0 );
			}
			if( e.Key == OpenTK.Input.Key.R )
			{
				T_camera.TurnUp( 0.0 );
			}
			if( e.Key == OpenTK.Input.Key.F )
			{
				T_camera.TurnUp( 0.0 );
			}
		}

		#region IReflectorCreate Members

		void IReflectorCreate.OnCreate( System.Windows.Forms.Control pc )
		{
			created_as_control = true;
            /*
			if( this.Parent == null )
			{
				this.Dock = System.Windows.Forms.DockStyle.Fill;
				pc.Controls.Add( this );
			}
            */
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}

//private override 
#if canusemouse
static int OnMouseCommon( "Terrain View" )( PSI_CONTROL pc, S_32 x, S_32 y, _32 b )
{
	static int _b;
	static struct {
		struct {
			BIT_FIELD bMoving : 1;
		} flags;
		S_32 x, y;
	} mouse;
	if( b & MK_LBUTTON && !( _b &MK_LBUTTON ) )
	{
		mouse.x = x;
		mouse.y = y;
		mouse.flags.bMoving = 1;
	}
	else if( b&MK_LBUTTON )
	{
		MoveCommonRel( pc, x - mouse.x, y - mouse.y );
	}
	_b = b;
	return 0;
}

#endif

#if what_startup_used_to_be
int main( int argc, char **argv )
{
	POBJECT pWorld;
	// create patch returns two patches in array.
	PSI_CONTROL pcDisplay;
	T = CreateTransform();
	{
		extern void CreateGPSGridDisplay();
		//CreateGPSGridDisplay();
	}

	//Translate( T, 0, 0, -30 );
	AddTimer( 10, UpdateUserBot, 0 );
	//RipplePatch( patch );
	// MUST show the window before the context
	// can be activated - otherwise certain facts about the window
	// do not exist.

	pcDisplay = MakeNamedControl( NULL, "Terrain View", 0, 0, 640, 640, -1 );

	DisplayFrame( pcDisplay );
	//SetAllocateLogging( TRUE );

	EnableOpenGL( GetFrameRenderer( pcDisplay ) );
	bEnabledGL = 1;
	//SetActiveGLDisplay( pRend );
	view = CreateViewEx( V_FORWARD, NULL, "Forward 1", 200, 200 );
#if asdfadsfasdf
	CreateViewEx( V_RIGHT, NULL, "Forward 1", 200, 200 );
	CreateViewEx( V_LEFT, NULL, "Forward 1", 200, 200 );
	CreateViewEx( V_UP, NULL, "Forward 1", 200, 200 );
	CreateViewEx( V_DOWN, NULL, "Forward 1", 200, 200 );
	CreateViewEx( V_BACK, NULL, "Forward 1", 200, 200 );
#endif
	{
		VECTOR v;

		v[0] = 0;
		v[1] = 0;
		v[2] = 15;
		CreateWorldCubeThing( v, ColorAverage( BASE_COLOR_BLUE, BASE_COLOR_WHITE, 50, 100 ) );

		v[0] = 0;
		v[1] = 0;
		v[2] = -15;
		CreateWorldCubeThing( v, ColorAverage( BASE_COLOR_BLUE, BASE_COLOR_BLACK, 50, 100 ) );

		v[0] = 0;
		v[1] = 15;
		v[2] = 0;
		CreateWorldCubeThing( v, ColorAverage( BASE_COLOR_GREEN, BASE_COLOR_WHITE, 50, 100 ) );
		v[0] = 0;
		v[1] = -15;
		v[2] = 0;
		CreateWorldCubeThing( v, ColorAverage( BASE_COLOR_GREEN, BASE_COLOR_BLACK, 50, 100 ) );

		v[0] = 15;
		v[1] = 0;
		v[2] = 0;
		CreateWorldCubeThing( v, ColorAverage( BASE_COLOR_RED, BASE_COLOR_WHITE, 50, 100 ) );
		v[0] = -15;
		v[1] = 0;
		v[2] = 0;
		pWorld = CreateWorldCubeThing( v, ColorAverage( BASE_COLOR_RED, BASE_COLOR_BLACK, 50, 100 ) );
	}

	//CreateBodies( pWorld );			

	VTest = new VirtualityTester();

	// a dialog to interface to the bodies that
	// have been created within the world.
	//SetAllocateLogging( TRUE );

	//CreateBodyInterface();
	{
      //int x;	
		while(1)	
		{	
			if( current )
			{
				TCam = current.Ti[0];
				//Invert( TCam.m[vUp] );
				Forward( &TCam, -60 );
				Up( &TCam, 20 );
				Right( &TCam, 0 );
				// go one step back and above the body, parallel forward view normal
				Move( &TCam );
				T_camera = &TCam;
			}
			else
			{
				T_camera = view.Tglobal;
				//TCam = view.Tglobal[0];
			}

			VirtualityUpdate();
			//Move( pWorld.Ti );
			SmudgeCommon( pcDisplay );
			//Relinquish();
			Sleep( 30 );
		}
	}
}
#endif

	}

