using System;
using UnityEditor;
using System.Collections;
using org.d3x0r.xperdex.games.unity_plugin;

public class UnityClassEditor : Editor {

	[CanEditMultipleObjects]
	[CustomEditor( typeof( Unityclass ) )]
	public override void OnInspectorGUI()
	{
		Unityclass myTarget = (Unityclass)target;
		
		//myTarget.Cells = EditorGUILayout.IntField( "Cells", myTarget.Cells );
		//EditorGUILayout.LabelField( "Cells", myTarget.Level.ToString() );
	}
}



