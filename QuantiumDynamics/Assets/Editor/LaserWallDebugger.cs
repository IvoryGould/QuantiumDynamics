using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LaserWallController))]
public class LaserWallDebugger : Editor
{
    private LaserWallController _dependancy;
    private SerializedObject _soDependancy;

    private SerializedProperty Activated, LaserWall, Destination, Speed, String;

    private void OnEnable()
    {
        _dependancy = (LaserWallController)target;
        _soDependancy = new SerializedObject(target);

        Activated = _soDependancy.FindProperty("Activated");
        LaserWall = _soDependancy.FindProperty("LaserWall");
        Destination = _soDependancy.FindProperty("Destination");
        Speed = _soDependancy.FindProperty("Speed");
    }
    public override void OnInspectorGUI()
    {
        _soDependancy.Update();
        EditorGUI.BeginChangeCheck();

        _dependancy._toolbarTab= GUILayout.Toolbar(_dependancy._toolbarTab, new string[] { "Variables", "Debugging" });

        switch (_dependancy._toolbarTab)                // Switch that declares which tab is selected.
        {
            case 0:
                _dependancy._currentTab = "Variables";
                break;
            case 1:
                _dependancy._currentTab = "Debugging";
                break;
        }   

        if (EditorGUI.EndChangeCheck())
        {
            _soDependancy.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        switch (_dependancy._currentTab)                // Switch that displays which variables are exposed in each tab
        {
            case "Variables":
                EditorGUILayout.PropertyField(LaserWall);
                EditorGUILayout.PropertyField(Destination);
                EditorGUILayout.PropertyField(Speed);
                break;

            case "Debugging":
                
                if (GUILayout.Button("Reset"))
                {
                    _dependancy.Activated = false;
                    _dependancy.ResetLaser();
                }
                if (GUILayout.Button("Activate/Deactivate"))
                {
                    if (_dependancy.Activated)
                    {
                        _dependancy.Activated = false;
                    }
                    else if (!_dependancy.Activated)
                    {
                        _dependancy.Activated = true;
                    }
                }

                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            _soDependancy.ApplyModifiedProperties();
        }
    }
}
