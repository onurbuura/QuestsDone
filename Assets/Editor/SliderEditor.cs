using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Controller)), CanEditMultipleObjects]
public class SliderEditor : Editor
{
    public SerializedProperty
        valueTypeProp,
        sliderProp,
        floatProp;

    void OnEnable()
    {
        valueTypeProp = serializedObject.FindProperty("sensitivityType");
        sliderProp = serializedObject.FindProperty("SensitivityBar");
        floatProp = serializedObject.FindProperty("SensitivityFloat");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(valueTypeProp);

        Controller.SensitivityType st = (Controller.SensitivityType)valueTypeProp.enumValueIndex;
        switch (st)
        {
            case Controller.SensitivityType.Slider:
                EditorGUILayout.PropertyField(sliderProp, new GUIContent("Sensitivity Value"));
                break;

            case Controller.SensitivityType.Typing:
                EditorGUILayout.PropertyField(floatProp, new GUIContent("Sensitivity Amount"));
                break;

        }

        serializedObject.ApplyModifiedProperties();
    }
}
