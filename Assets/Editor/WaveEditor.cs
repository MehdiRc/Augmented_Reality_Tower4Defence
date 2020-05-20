using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(int))]
public class WaveEditor : PropertyDrawer {

    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        GUI.backgroundColor = Color.cyan;
        EditorGUI.PropertyField(position, property, GUIContent.none);

        EditorGUI.EndProperty();
	}
}
 