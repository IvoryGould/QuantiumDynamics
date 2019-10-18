using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[CustomEditor(typeof(AreaTrigger))]
public class AreaTriggerDebugger : Editor
{
    private AreaTrigger _dependancy;
    private SerializedObject _soDependancy;

    private SerializedProperty HazardType, EnvironmentObjects, isActive;

    private void OnEnable()
    {
        _dependancy = (AreaTrigger)target;
        _soDependancy = new SerializedObject(target);

        HazardType = _soDependancy.FindProperty("HazardType");
        EnvironmentObjects = _soDependancy.FindProperty("EnvironmentObjects");
        isActive = _soDependancy.FindProperty("isActive");
        
    }
    public override void OnInspectorGUI()
    {
        ChangeCheckStart();

        // constructs toolbar tab for Variables and Debugging
        _dependancy._toolbarTab = GUILayout.Toolbar(_dependancy._toolbarTab, new string[] { "Variables", "Debugging" });

        // Switch that declares which tab is selected.
        switch (_dependancy._toolbarTab)                
        {
            case 0:
                _dependancy._currentTab = "Variables";
                break;
            case 1:
                _dependancy._currentTab = "Debugging";
                break;
        }

        ChangeCheckStop();
        ChangeCheckStart();

        // Switch that displays which variables are exposed in each tab
        switch (_dependancy._currentTab)                
        {
            case "Variables":

                EditorGUILayout.Foldout(true, "Environent Objects", EditorStyles.foldout);

                // For each environment object declared, add setactive tag.
                for (int i = 0; i < _dependancy.EnvironmentObjects.Count; i++)
                {

                    GUILayout.BeginHorizontal();
                    _dependancy.EnvironmentObjects[i] = (GameObject)EditorGUILayout.ObjectField(_dependancy.EnvironmentObjects[i], typeof(GameObject), true);
                    if (_dependancy.EnvironmentObjects[i])
                    {
                        _dependancy.EnvironmentObjects[i].SetActive(EditorGUILayout.Toggle(_dependancy.EnvironmentObjects[i].activeInHierarchy));
                    }
                    GUILayout.EndHorizontal();
                }


                // Buttons to add Gameobject Fields to the Environment Llist
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Add Field"))
                {
                    _dependancy.EnvironmentObjects.Add(null);
                }
                if (GUILayout.Button("Remove Field"))
                {
                    _dependancy.EnvironmentObjects.RemoveAt(_dependancy.EnvironmentObjects.Count - 1);
                }
                EditorGUILayout.EndHorizontal();

                break;

            case "Debugging":
                                
                if (GUILayout.Button("Activate/Deactivate"))
                {
                    if (_dependancy.isActive)
                    {
                        _dependancy.isActive = false;
                        _dependancy.Deactivate();
                    }

                    else if (!_dependancy.isActive)
                    {
                        _dependancy.isActive = true;
                        _dependancy.Activate();
                    }
                }
                break;
        }

        ChangeCheckStop();
    }

    private void ChangeCheckStart()
    {
        _soDependancy.Update();
        EditorGUI.BeginChangeCheck();
    }

    private void ChangeCheckStop()
    {
        if (EditorGUI.EndChangeCheck())
        {
            _soDependancy.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }
    }
}
