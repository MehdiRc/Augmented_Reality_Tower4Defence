using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameMaster))]
public class TestEditor : Editor {
    bool listVisibilityAttack;

    /* public override void OnInspectorGUI () {
		serializedObject.Update();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("_cam"),true);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyPrefab"),true);

		ArrayGUI(serializedObject.FindProperty("waves"),"Wave ",  ref listVisibilityAttack);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("timeBetweenWaves"),true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("waveCountDownText"),true);
		serializedObject.ApplyModifiedProperties();
	}

    private void ArrayGUI(SerializedProperty property, string itemType, ref bool visible){
        visible = EditorGUILayout.Foldout(visible, property.name);
        if (visible){
            EditorGUI.indentLevel++;
            SerializedProperty arraySizeProp = property.FindPropertyRelative("Array.size");
            EditorGUILayout.PropertyField(arraySizeProp);
 

            for (int i = 0; i < arraySizeProp.intValue; i++){
                EditorGUILayout.PropertyField(property.GetArrayElementAtIndex(i), new GUIContent(itemType + i.ToString()), true);
                //EditorGUILayout.PropertyField(property.GetArrayElementAtIndex(i).FindProperty("WaveBoards").GetArrayElementAtIndex(0), new GUIContent("tata"), true);
                SerializedProperty test = property.GetArrayElementAtIndex(i).FindPropertyRelative("waveBoards").GetArrayElementAtIndex(0);
                EditorGUILayout.PropertyField(test, new GUIContent("caca"), true);
            }
            EditorGUI.indentLevel--;
        }
    } */
}
