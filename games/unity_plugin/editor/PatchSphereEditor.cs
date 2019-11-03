﻿using System;
using UnityEditor;
using System.Collections;
using org.d3x0r.xperdex.games.unity_plugin;

[CanEditMultipleObjects]
[CustomEditor( typeof( PatchSphere ) )]
public class PatchSphereEditor : Editor {

	public override void OnInspectorGUI()
	{
		PatchSphere myTarget = (PatchSphere)target;
		
		myTarget.Cells = EditorGUILayout.IntField( "Cells", myTarget.Cells );
		//EditorGUILayout.LabelField( "Cells", myTarget.Level.ToString() );
	}
}



