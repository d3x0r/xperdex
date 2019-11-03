// =================================================================
//
// Name:			   3D XNA Game Template
//
// Created by:         J. Nic Foster
// Contact Info:       nfoste82@gmail.com
//
// Version:            0.14
// Date created:       08-31-07
// Date last modified: 09-28-07
//
// Disclaimer:         Anyone can use this program under the simple
//                     agreement that you do not call the code your
//                     own. Simple enough, just give credit, thank
//                     you. Oh, and if this program causes anything
//                     bad to happen in any way, that is not my
//                     problem, and by you using it, you accept this fact.
//
// =================================================================

CONTROLS:
------------------------------------------------------
Arrow keys for rotation.
W, A, S, D for moving the camera, tab switches camera modes.

HELP and INFO:
------------------------------------------------------
For information on what functions do what, I've used summary
documentation, which is built into C#. What this means is that
you can hover over the function name and get a description, or
if you're in the process of using the function intellisense
should give you more information.

This program is intended for XNA beginners and more
importantly, programming novices. It sets you up with
many 3D game essentials.

This is something I've thrown together in a few days, so
it will likely be lacking many features, documentation,
and commenting. However, feel free to email me with any
specific questions.

The spheres and physics you see in this demo are leftover from
the physics sample on my site. I left it in not only to show
what the template can do, but how it does it.

Here are some tips for the physics demo part of the template:
=============================================================
To change wind direction, wind speed, gravity direction,
  gravity intensity, look for the Initialize() function
  in GameMain.cs.
 
To add/remove spheres, or change their individual properties,
  look in the LoadEntities() function in GameMain.cs.
  
You can change the heightmap if you'd like. It is
  located in ./Resources/Images/Heightmaps

You can change elevation intensity of the heightmap as well.
  Look in the LoadTerrain() function in GameMain.cs.
=============================================================

If you would like to start "from scratch" simply remove any
component initializations you will not be needing. For instance,
if you do not need terrain, simply remove the LoadTerrain()
function, or just comment out the call to it within Initialize().


=============================================================
CHANGE LOG
=============================================================
v0.15 (9-30-2007)
- Added rain weather component.
- Added a water component. Water has two settings, a high
  performance, but simple, cube map reflective type (CREDIT:
  Handkor). Or a lower performance, but much more realistic
  water that uses refraction and reflection (CREDIT: Riemer
  Grootjans).
  
v0.14 (9-28-2007)
- Added a skydome component. Skydome has the option of rotating
  as well.
- Added an example of skydome transparency, allows different
  layers of sky.
- Added a fog component.
- Added camera zoom for FreeCamera cameras.
- Added a fixed camera class. Switch cameras using the TAB key.
- Added example of fixing camera to an entity. Simply shoot a
  sphere using spacebar or enter while in fixed camera mode.
- Added a weather component. Weather system uses a particle
  emitter to create particles like snow. Currently only the
  snow weather component is included, rain may follow.
- Included a particle system setup. Particle system is a slightly
  modified version of the 3D Particle Sample that is
  downloadable from the XNA Creator's Club site.
- Create a terrain smoothing algorithm.
- Added normal mapping for terrains.
- Terrains no longer tile, and no longer fade in and out by
  distance. Terrain textures are simply wrapped over terrain.

v0.13 (09-14-2007)
- Setup template on a component-based system. This will allow
  the programmer to simply add components they need or want,
  and leave out others.
- This also allows me to create components individually, which
  could be downloaded seperately and added to the game template
  as needed. It will also keep the game template program from
  getting more complicated for the programmer as I add to it.
- Camera, input, light, terrain, and timer classes are all
  components and derived from components.
- Light was a struct, and is now a class.
- Light was changed to an abstract class. All lights are now
  currently either SunLights or PointLights.
- PointLight class is still under construction and there is
  no code for rendering point lights.
- Sunlight can now have day and nighttime effects in which the
  sun can rise and set.
- Timer now uses pure C# components. Previously used interop
  services.
  
v0.12 (09-13-2007)
- Small tweak to minimum distance function in physics class.
  Should now be more accurate for entities of different mass
  colliding together.
- More comments and documentation added.

v0.11 (09-12-2007)
- Major optimation of terrain/quad-tree classes. Game should
  now require 30% less RAM to load terrains. Slightly less
  garbage is produced by terrains as well.
- Upgrades physics component from v0.1 to v0.12. Major
  physics changes include collision between spheres and
  bouncing of spheres according to terrain normals.
- Included code for integrating and using the Xbox360 Controller
  and the mouse.
- Commented and documented some of the code.

=============================================================
Known bugs:
=============================================================
- There are probably many, that I haven't had time to test for.
- Feel free to contact me with any bothersome ones at my email.

=============================================================
Future versions content?
=============================================================
Nothing set in stone, but here are some things I'm considering:

- Water-based physics for underwater entities
- Spheres create water splash with particles upon hitting water.
- Allow water transparency setting
- Set water up to reflect actual scene wind and wind direction
- Pass water actual light color
- Setup water specularity
- Setup water perlin noise
- Change Water settings (like actual waves possibly, wave speed, transparency)
- Make SpriteBatch section a component
- Underwater shader? Water 'fog' effects?
- Animated sky planes (use same process that water uses to animate)
- Terrain wrapping to scale over terrain when needed.
- Particles that react to vertices (rain hits the ground).
- Vegetation system (allow multiple types).
- Sound emitters.
- Postprocess Bloom.
- Setup pointlighting effects.
- Sun billboard
- Different shader effects.
- Particle emitters (like campfire)
- Simple A.I. sample (artificial intelligence).
- Shadow mapping terrain
- Shadow mapping models

=============================================================
Advanced topics to consider
=============================================================

- Dynamic water, reacting to entities and possibly particles (like rain)
- Volumetric fog effects....like clouds
- Lens flare effect, possible if I do a sun billboard
- Cloud rim lighting

