using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
namespace org.d3x0r.xperdex.games.unity_plugin
{
	public class MenuItemClass : EditorWindow
	{

		[MenuItem( "GameObject/Create Other/plasa terrain 2" )]
		public static void CustomPlasmaMeshCSharp()
		{
			int cells = 128;
			float[] seeds = new float[]{ 1.0f, 0.0f, 0.0f, 1.0f };
			//System.Diagnostics.Debug.WriteLine( "make plasma..." );
			PlasmaGenerator.plasma_patch plasma = PlasmaGenerator.PlasmaCreate(  seeds, cells * 2, cells, cells );
			//Terrain terrain = new Terrain();
			Mesh mesh = new Mesh();
			{
				// fill mesh
				Vector3[] verts = new Vector3[(cells) * (cells)];
				Vector2[] uvs = new Vector2[(cells) * (cells)];
				int[] tris = new int[(cells-1) * (cells-1) * 6];// { 0, 1, 2, 2, 1, 3 };

				System.Diagnostics.Debug.WriteLine( "Building verts..." );
				
				{
					int x, y;
					//System.Diagnostics.Debug.WriteLine( " Read surface..."  );
							
					float[] map = PlasmaGenerator.PlasmaReadSurface( plasma, 0, 0, 0, true );
					for( x = 0; x < cells; x++ )
						for( y = 0; y < cells; y++ )
						{
							//System.Diagnostics.Debug.WriteLine( " index" + ( x + y * cells ) + " and " + x + " ," + y );
							verts[( x + y * cells )] = -Vector3.right + Vector3.right * 2 * x / (cells-1)
								+ Vector3.up - Vector3.up * 2 * y / ( cells - 1 );
							verts[( x + y * cells )].z = map[( x + y * cells )];
							//System.Diagnostics.Debug.WriteLine( " index" + ( x + y * cells ) + " and " + x + " ," + y+ " = " + verts[( x + y * cells )] );
							uvs[( x + y * cells )] = -Vector2.right + Vector2.right * 2 * x / ( cells - 1 )
								+ Vector2.up - Vector2.up * 2 * y / ( cells - 1 );
						}

					for( x = 0; x < (cells-1); x++ )
						for( y = 0; y < (cells-1); y++ )
						{
							int cell_id = ( x + y * (cells-1) ) * 6;

							tris[cell_id + 0] = ( x + 0 ) + ( y + 0 ) * cells;
							tris[cell_id + 1] = ( x + 1 ) + ( y + 0 ) * cells;
							tris[cell_id + 2 ] = ( x + 0 ) + ( y + 1 ) * cells;
							tris[cell_id + 3] = ( x + 0 ) + ( y + 1 ) * cells;
							tris[cell_id + 4] = ( x + 1 ) + ( y + 0 ) * cells;
							tris[cell_id + 5] = ( x + 1 ) + ( y + 1 ) * cells;
						}
				}
				mesh.vertices = verts;
				mesh.triangles = tris;
				mesh.uv = uvs;
				mesh.RecalculateNormals();
			}
			{
				GameObject newMeshObject = new GameObject();
				newMeshObject.AddComponent<MeshFilter>().mesh = mesh;
				newMeshObject.AddComponent<MeshRenderer>();
				AssetDatabase.CreateAsset( mesh, "Assets/Default asset Name.asset" );
			}
		}

		[MenuItem( "GameObject/Create Other/Plasma Ball Host" )]
		public static void CustomPlasmaBallCSharp()
		{
			//GameObject newMeshObject = new GameObject();
			int cells = 2;
			//System.Diagnostics.Debug.WriteLine( "make plasma..." );
			//PatchSphere sphere = new PatchSphere( 73 );
			GameObject newMeshObject = new GameObject();
			PatchSphere sphere = //new PatchSphere( 2 );
				newMeshObject.AddComponent<PatchSphere>();
			//Terrain terrain = new Terrain();
			Mesh mesh = new Mesh();
			{
				// fill mesh
				Vector3[] verts ;
				Vector3[] norms;
				Vector2[] uvs;
				int[] tris;

				newMeshObject.AddComponent<MeshRenderer>();

				sphere.ReadSphere( out verts, out norms, out uvs, out tris );

				mesh.vertices = verts;
				mesh.triangles = tris;
				mesh.uv = uvs;
				mesh.normals = norms;

				newMeshObject.AddComponent<MeshFilter>().mesh = mesh;
				AssetDatabase.CreateAsset( mesh, "Assets/Default Patch Shere-"+sphere.Cells+".asset" );
			}
		}
	
	}
}
