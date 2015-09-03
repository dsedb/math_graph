using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GraphManager))]
public class GraphManagerOnInspector : Editor
{
    public override void OnInspectorGUI()
    {
		var obj = target as GraphManager;
		obj.setValue(EditorGUILayout.Slider("value", obj.getValue (), -3.0f, 6.0f));
		EditorUtility.SetDirty(target);
	}
}