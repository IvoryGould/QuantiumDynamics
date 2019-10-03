using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[CustomEditor(typeof(AreaTrigger))]
public class AreaTriggerDebugger : Editor
{
    private AreaTrigger _dependancy;
    private LaserWallController _dependancy2;
    private SerializedObject _soDependancy, _soDependancy2;

    private SerializedProperty HazardType, LaserWall, EnvironmentObjects, isActive, Activated, Destination, Speed, ReturnTime, MovementType;

    private void OnEnable()
    {
        _dependancy = (AreaTrigger)target;
        _soDependancy = new SerializedObject(target);

        //_dependancy2 = (LaserWallController)target;
        //_soDependancy2 = new SerializedObject(target);

        HazardType = _soDependancy.FindProperty("HazardType");
        LaserWall = _soDependancy.FindProperty("LaserWall");
        EnvironmentObjects = _soDependancy.FindProperty("EnvironmentObjects");
        isActive = _soDependancy.FindProperty("isActive");
        
        //Activated = _soDependancy2.FindProperty("Activated");
        //Destination = _soDependancy2.FindProperty("Destination");
        //Speed = _soDependancy2.FindProperty("Speed");
        //ReturnTime = _soDependancy2.FindProperty("ReturnTime");
        //MovementType = _soDependancy2.FindProperty("MovementType");
        
    }
    public override void OnInspectorGUI()
    {
        _soDependancy.Update();
        EditorGUI.BeginChangeCheck();

        _dependancy._toolbarTab = GUILayout.Toolbar(_dependancy._toolbarTab, new string[] { "Variables", "Debugging" });

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

        _soDependancy.Update();
        EditorGUI.BeginChangeCheck();

        switch (_dependancy._currentTab)                // Switch that displays which variables are exposed in each tab
        {
            case "Variables":

                EditorGUILayout.PropertyField(HazardType);
                switch (_dependancy.HazardType)
                {
                    case AreaTrigger.ObjectSelection.LaserWall:
                        EditorGUILayout.PropertyField(LaserWall);
                        break;

                    case AreaTrigger.ObjectSelection.Environment:
                        EditorGUILayout.PropertyField(EnvironmentObjects, true);
                        break;
                }
                break;

            case "Debugging":
                switch (_dependancy.HazardType)
                {
                    case AreaTrigger.ObjectSelection.LaserWall:
                        _dependancy.isActive = false;
                        EditorGUILayout.PropertyField(isActive);
                        break;
                    //case AreaTrigger.ObjectSelection.Environment:
                    //    _dependancy.isActive = true;
                    //    EditorGUILayout.PropertyField(Speed);
                    //    if (GUILayout.Button("Reset"))
                    //    {
                    //        _dependancy2.Activated = false;
                    //        _dependancy2.ResetLaser();
                    //    }
                    //    if (GUILayout.Button("Activate/Deactivate"))
                    //    {
                    //        if (_dependancy2.Activated)
                    //        {
                    //            _dependancy2.Activated = false;
                    //        }
                    //        else if (!_dependancy2.Activated)
                    //        {
                    //            _dependancy2.Activated = true;
                    //        }
                    //    }
                        //EditorGUILayout.PropertyField(isActive);
                        //break;
                }
                
                
                
                if (GUILayout.Button("Activate/Deactivate"))
                {
                    if (_dependancy.isActive)
                    {
                        _dependancy.isActive = false;
                        _dependancy.Deactivate();
                    }

                    if (!_dependancy.isActive)
                    {
                        _dependancy.isActive = true;
                        _dependancy.Activate();
                    }
                }
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            _soDependancy.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }
    }
}
