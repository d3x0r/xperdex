using System;
using UnityEditor;
using System.Collections;
using org.d3x0r.xperdex.games.unity_plugin;

public class UnityClassEditor : Editor {

	[CanEditMultipleObjects]
	[CustomEditor( typeof( PatchSphere ) )]
	public override void OnInspectorGUI()
	{
		PatchSphere myTarget = (PatchSphere)target;
		
		myTarget.Cells = EditorGUILayout.IntField( "Cells", myTarget.Cells );
		//EditorGUILayout.LabelField( "Cells", myTarget.Level.ToString() );
	}
}



