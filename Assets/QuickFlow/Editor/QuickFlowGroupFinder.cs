#region Directives
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
#endregion

#if UNITY_EDITOR
namespace QuickFlow.Editor
{

    #region Menu Display
    public class QuickFlowGroupFinder : MonoBehaviour
    {

        [MenuItem("QuickFlow/QuickFlow Group&Finder #&g")]
        public static void QuickFlowWindow()
        {

            GroupFinderEditorWindow.DisplayGroupFinderWindow();

        }

    }
    #endregion

    #region Display Window GroupFinderWindow
    public class GroupFinderEditorWindow : EditorWindow
    {

        #region Create Window
        public static void DisplayGroupFinderWindow()
        {

            var window = GetWindow<GroupFinderEditorWindow>();

            window.minSize = new Vector2(300f, 510f);

            window.Show();

        }
        #endregion

        private int buttonHeight = 45;

        #region Group Variables
        private const string defaultText = "Enter Name";

        private string wantedName = defaultText;

        private bool dashType = false;

        private const string hyphen = "-";

        private const string equalSign = "=";

        private string totalDash;

        private int currentSelectedAmount;

        private int dashedLines = 0;

        private GameObject[] selected = new GameObject[0];

        private GameObject parentGameobject;
        #endregion

        #region Finder Variables
        private string userInput = null;

        private int selectedIndex = 0;

        private FilterTypes filter;

        private GameObject[] gameObjects = new GameObject[0];

        private List<GameObject> selectedGameobjects = new List<GameObject>();
        #endregion

        #region Group Fuctions
        private void GroupSelectedObjects()
        {

            if(wantedName != defaultText)
            {

                if(selected.Length > 0)
                {

                    GameObject groupGO = new GameObject(wantedName);

                    foreach(GameObject go in selected)
                    {

                        if(go.transform.parent != null)
                        {

                            parentGameobject = go.transform.parent.gameObject;

                        }

                        go.transform.SetParent(groupGO.transform);

                    }

                    if(parentGameobject != null)
                    {

                        DestroyParent();

                    }

                }
                else
                {

                    EditorUtility.DisplayDialog("Empty Selection", "No items have been selected. Need one or more objects selected to group.", "Okay");

                }

            }
            else
            {

                EditorUtility.DisplayDialog("Name Issue", "Must provide a name for the group.", "Okay");

            }

        }

        private void UngroupGameobjects()
        {

            if (selected.Length > 0)
            {

                foreach (GameObject go in selected)
                {

                    if (go.transform.parent == null) { return; }

                    parentGameobject = go.transform.parent.gameObject;

                    go.transform.parent = null;

                }

                DestroyParent();

            }
            else
            {

                EditorUtility.DisplayDialog("Ungroup Message", "Must need an object selected", "Okay");

            }

        }

        private void DestroyParent()
        {

            if(parentGameobject.transform.childCount == 0)
            {

                DestroyImmediate(parentGameobject);

            }

        }

        private void DestroyGameobject()
        {

            if(selected.Length > 0)
            {

                foreach(GameObject go in selected)
                {

                    DestroyImmediate(go);

                }

            }
            else
            {

                EditorUtility.DisplayDialog("Destroy Error", "No items have been selected. Need one or more objects selected to destroy item(s).", "Okay");

            }

        }

        private void SpawnHeaderGameobject()
        {
            
            float dashedLineSides = 0;

            if(wantedName != defaultText)
            {

                dashedLineSides = dashedLines / 2;

                if (dashedLines <= 2)
                {

                    LoopForDash(10);

                }
                else
                {

                    LoopForDash(dashedLineSides);

                }

                GameObject go = new GameObject(totalDash + wantedName + totalDash);

                totalDash = null;

            }
            else
            {

                EditorUtility.DisplayDialog("Name Issue", "Must provide a name for the Header Gameobject.", "Okay");

            }

        }

        private void LoopForDash(float loopValue)
        {

            for (int i = 0; i < loopValue; i++)
            {

                if (dashType)
                {

                    totalDash += equalSign;

                }
                else
                {

                    totalDash += hyphen;

                }

            }

        }
        #endregion

        #region Finder Functions
        private void SelectAllGameobjects()
        {

            UpdateSelection();

            Selection.objects = selectedGameobjects.ToArray();

        }

        private void SelectNextGameobject()
        {
            
            if(selectedGameobjects.Count > 0)
            {

                if(selectedIndex >= selectedGameobjects.Count - 1)
                {

                    selectedIndex = 0;

                }
                else
                {

                    selectedIndex++;

                }

                if (selectedGameobjects[selectedIndex] != null)
                {

                    Selection.activeGameObject = selectedGameobjects[selectedIndex];

                }

            }

        }

        private void SelectPreviousGameobject()
        {

            if (selectedGameobjects.Count > 0)
            {

                if (selectedIndex <= 0)
                {

                    selectedIndex = selectedGameobjects.Count - 1;

                }
                else
                {

                    selectedIndex--;

                }

                if (selectedGameobjects[selectedIndex] != null)
                {

                    Selection.activeGameObject = selectedGameobjects[selectedIndex];

                }

            }

        }

        private void UpdateSelection()
        {

            selectedGameobjects.Clear();

            //Find all objects
            GameObject[] gameObjects = FindObjectsOfType<GameObject>();

            if(filter == FilterTypes.GameobjectName)
            {

                if(userInput != null)
                {

                    //Store if matches
                    foreach (GameObject go in gameObjects)
                    {

                        string selectedName = null;

                        if (userInput.Length <= go.name.Length)
                        {

                            selectedName = go.name.Substring(0, userInput.Length);

                        }

                        if (selectedName == userInput)
                        {

                            selectedGameobjects.Add(go);

                        }

                    }

                }

            }
            else if(filter == FilterTypes.Tag)
            {

                if (selectedGameobjects.Count <= 0)
                {

                    EditorUtility.DisplayDialog("Retieved Data", "There were no objects with a tag of " + userInput, "Okay");

                }

                if (userInput != null)
                {

                    foreach (GameObject go in gameObjects)
                    {

                        if (go.transform.tag == userInput)
                        {

                            selectedGameobjects.Add(go);

                        }

                    }

                }   

            }
            else if (filter == FilterTypes.Layer)
            {

                if (selectedGameobjects.Count <= 0)
                {

                    EditorUtility.DisplayDialog("Retieved Data", "There were no objects with a tag of " + userInput, "Okay");

                }

                LayerMask mask = LayerMask.NameToLayer(userInput);

                if(userInput != null)
                {

                    foreach (GameObject go in gameObjects)
                    {

                        if (go.layer == mask)
                        {

                            selectedGameobjects.Add(go);

                        }

                    }

                }
                else
                {

                    //EditorUtility.DisplayDialog(filter, "Need", "Okay")

                }

            }

        }

        private void OnHierarchyChange()
        {

            UpdateSelection();

        }
        #endregion

        #region Centering Words
        void SetIndentation(int indentAmount, bool value)
        {

            if (value)
            {

                for (int i = 0; i < indentAmount; i++)
                {

                    EditorGUI.indentLevel++;

                }

            }
            else
            {

                for (int i = 0; i < indentAmount; i++)
                {

                    EditorGUI.indentLevel--;

                }

            }

        }
        #endregion

        #region Show in Window
        private void OnGUI()
        {

            #region Group
            SetIndentation(8, true);
            EditorGUILayout.LabelField("Grouper", EditorStyles.boldLabel);
            SetIndentation(8, false);

            selected = Selection.gameObjects;

            currentSelectedAmount = selected.Length;

            EditorGUILayout.BeginHorizontal();
            {

                EditorGUILayout.Space();

                EditorGUILayout.BeginVertical();
                {

                    EditorGUILayout.Space();

                    EditorGUILayout.LabelField("Selected Count: " + currentSelectedAmount.ToString());
                    GUILayout.Space(5);

                    wantedName = EditorGUILayout.TextField("Group Name", wantedName);
                    dashType = EditorGUILayout.BeginToggleGroup("Use equal sign", dashType);

                    if (dashType)
                    {

                        EditorGUILayout.LabelField("Equal Sign: " + equalSign.ToString());

                    }
                    else
                    {

                        
                        EditorGUILayout.LabelField("Equal Sign: " + equalSign.ToString());

                    }

                    EditorGUILayout.EndToggleGroup();

                    dashedLines = EditorGUILayout.IntField("Number of dahes", dashedLines);

                    EditorGUILayout.Space();

                }
                
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();

            }
            
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {

                GUILayout.Space(10);

                if (GUILayout.Button("Group Selected", GUILayout.ExpandWidth(true), GUILayout.Height(buttonHeight)))
                {

                    GroupSelectedObjects();

                }

                GUILayout.Space(1);

                if (GUILayout.Button("Ungroup Selected", GUILayout.ExpandWidth(true), GUILayout.Height(buttonHeight)))
                {

                    UngroupGameobjects();

                }

                GUILayout.Space(10);

            }
            
            GUILayout.EndHorizontal();

            EditorGUILayout.HelpBox("This will permanently destory the GameObject. Undo will NOT bring back the Object.", MessageType.Warning, true);

            if (GUILayout.Button("Destroy Gameobject", GUILayout.ExpandWidth(true), GUILayout.Height(buttonHeight)))
            {

                DestroyGameobject();

            }

            GUILayout.Space(1);

            if (GUILayout.Button("Header Object", GUILayout.ExpandWidth(true), GUILayout.Height(buttonHeight)))
            {

                SpawnHeaderGameobject();

            }
            #endregion

            #region Finder
            EditorGUILayout.Space(10);
            SetIndentation(8, true);
            EditorGUILayout.LabelField("Finder", EditorStyles.boldLabel);
            SetIndentation(8, false);

            filter = (FilterTypes)EditorGUILayout.EnumPopup("Filter type: ", filter);

            userInput = EditorGUILayout.TextField("Gameobject Name", userInput, GUILayout.ExpandWidth(true));
            EditorGUILayout.Space(5);

            if (GUILayout.Button("Select All", GUILayout.Height(buttonHeight)))
            {

                SelectAllGameobjects();

            }

            EditorGUILayout.Space(5);
            EditorGUILayout.BeginHorizontal();
            {

                GUILayout.Space(1);
                GUILayout.Label("Cycle Selection:");

                if (GUILayout.Button("Previous", GUILayout.Height(buttonHeight)))
                {

                    SelectPreviousGameobject();

                }

                if (GUILayout.Button("Next", GUILayout.Height(buttonHeight)))
                {

                    SelectNextGameobject();

                }

            }

            EditorGUILayout.EndHorizontal();
            #endregion

            Repaint();

        }
        #endregion

    }
    #endregion

}
#endif