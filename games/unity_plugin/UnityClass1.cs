using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
//using org.d3x0r.xperdex.games.unity_plugin;
namespace org.d3x0r.xperdex.games.unity_plugin
{
	// do not include a constructor; it will be tempting to use that
	public class Unityclass : MonoBehaviour
	{

		// called once, first, before any start
		// may just be a instance
		public void Awake()
		{

		}

			GameObject  target;
		Plane groundPlane;
		Collider me;
		Transform markerObject;

		// called once, second, preferred point; only activated scripts will get this
		public void Start()
		{
			//MeshFilter filter = (MeshFilter)GetComponent( typeof( MeshFilter ) );


			//filter.mesh.SetTriangles();
			groundPlane = new Plane( new Vector3( 0, 0, 1 ), new Vector3( 0, 0, 0 ) );

			me = null;// Collider.
			target = GameObject.FindWithTag( "Player" );


		}

		// this is a game tick
		public void Update()
		{
			if (Input.GetMouseButtonDown(0)) {
		// Get a ray corresponding to the screen position of the mouse.
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float rayDistance;
		
				// If the ray makes contact with the ground plane then
				// position the marker at the distance along the ray where it
				// crosses the plane.
				if (groundPlane.Raycast(ray, out rayDistance)) {
					markerObject.position = ray.GetPoint(rayDistance);
				}
			}
		}


		IEnumerator SomeCoroutine()
		{
			// Wait for one frame
			yield return 0;

			// Wait for two seconds
			yield return new WaitForSeconds( 2 );
		}


		public static void Test()
		{
			SaltyRandomGenerator srg = new SaltyRandomGenerator();
			srg.getsalt += srg_getsalt;
			int n;
			for( n = 0; n < 500; n++ )
				Console.WriteLine( "data is : " + srg.GetEntropy( 1, true ) );
			srg.Reset();
			for( n = 0; n < 500; n++ )
				Console.WriteLine( "data is : " + srg.GetEntropy( 1, false ) );
		}

		static void srg_getsalt( SaltyRandomGenerator.SaltData add_data_here )
		{
			add_data_here += BitConverter.GetBytes( 0 );
			//DateTime.Now.ToBinary() );
		}

		[SerializeField]
		int _cells;

		public int cells
		{
			get
			{
				return _cells;
			}
			set
			{
				_cells = value;// update mesh.
			}
		}

	}
}
