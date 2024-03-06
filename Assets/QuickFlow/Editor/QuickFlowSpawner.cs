#region Directives
using UnityEngine;
using UnityEditor;
#endregion

#if UNITY_EDITOR
namespace QuickFlow.Editor
{

    #region Menu Display
    public class QuickFlowObjectSpawner : MonoBehaviour
    {

        [MenuItem("QuickFlow/QuickFlow Object Spawner #&f")]
        public static void Spawn()
        {

            ObjectSpawnEditorWindow.DisplayObjectSpawnWindow();

        }

    }
    #endregion

    #region SpawnWindow
    public class ObjectSpawnEditorWindow : EditorWindow
    {

        #region Create Window
        public static void DisplayObjectSpawnWindow()
        {

            var window = GetWindow<ObjectSpawnEditorWindow>();

            window.minSize = new Vector2(300f, 685f);

            window.Show();

        }
        #endregion

        #region Spawn Variables
        [Header("Button")]
        private int buttonHeight = 45;

        [Header("Object Name")]
        private string objectBaseName = "";

        private string previousBaseName = "";

        [Header("Prefab Object to Spawn")]
        private GameObject objectToSpawn;

        private Transform objectContainer;

        [Header("Textures")]
        public Texture2D icon;

        [Header("ID")]
        private int objectID = 0;

        private bool appendID = true;

        [Header("Random Sphere Location")]
        private bool useRandom = false;

        private float spawnRadius = 5f;

        private float minScaleVal = 0.1f;

        private float maxScaleVal = 1f;

        [Header("Default Spawn Location")]
        private bool defaultLocation = true;

        private Vector3 defaultSpawnLocation = new Vector3(0, 0, 0);

        [Header("Random Box Location")]
        private Vector3 minSpawnLocation;

        private Vector3 maxSpawnLocation;

        private float objectScale;

        private float scaleValue = 1f;
        #endregion

        #region Centering Function
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

            #region Random
            #region Title
            SetIndentation(5, true);

            EditorGUILayout.LabelField("Spawn New Object", EditorStyles.boldLabel);
            
            SetIndentation(5, false);
            #endregion

            EditorGUILayout.Space(10);

            #region Object Name
            objectBaseName = EditorGUILayout.TextField("Base Name", objectBaseName);

            if (objectBaseName == string.Empty)
            {

                EditorGUILayout.HelpBox("Assign a base name to the object ot be spawned.", MessageType.Error);

            }
            #endregion

            EditorGUILayout.Space(2);

            #region Prefab Spawn
            objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

            if (objectToSpawn == null)
            {

                EditorGUILayout.HelpBox("Place a Gameobject in the 'Prefab to Spawn' field.", MessageType.Error);

            }
            #endregion

            EditorGUILayout.Space(2);

            #region Texture
            icon = EditorGUILayout.ObjectField("Icon", icon, typeof(Texture2D), false) as Texture2D;
            
            if(icon == null)
            {

                EditorGUILayout.HelpBox("Adds an icon to the gameObject. Is not require to have.", MessageType.None, false);

            }

            #endregion

            EditorGUILayout.Space(2);

            #region Spawn Under Parent
            objectContainer = EditorGUILayout.ObjectField("Object Container", objectContainer, typeof(Transform), true) as Transform;

            if (objectContainer != null && EditorUtility.IsPersistent(objectContainer))
            {

                EditorGUILayout.HelpBox("Object Container must be a scene object.", MessageType.Error);

            }
            
            EditorGUILayout.HelpBox("Object Container not required.", MessageType.None, false);
            #endregion

            EditorGUILayout.Space(2);

            #region Number at the End
            appendID = EditorGUILayout.BeginToggleGroup("Append ID", appendID);

            objectID = EditorGUILayout.IntField("Object ID", objectID);

            if (objectID < 0)
            {

                objectID = 0;

            }

            EditorGUILayout.EndToggleGroup();
            #endregion

            EditorGUILayout.Space(2);

            #region Use Random Spawn
            useRandom = EditorGUILayout.BeginToggleGroup("Use Random Location", useRandom);
            
            spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);
            
            if(spawnRadius <= 0)
            {

                spawnRadius = 0.01f;

            }

            EditorGUILayout.LabelField("Minimum Scale Value: " + minScaleVal.ToString(), EditorStyles.boldLabel);

            EditorGUILayout.LabelField("Maximum Scale Value: " + maxScaleVal.ToString(), EditorStyles.boldLabel);  

            EditorGUILayout.EndToggleGroup();
            #endregion

            EditorGUILayout.Space(2);

            #region Box Spawn
            if (!useRandom)
            {

                #region Box Spawn Location
                defaultLocation = EditorGUILayout.BeginToggleGroup("Default Spawn", defaultLocation);

                if (defaultLocation)
                {

                    defaultSpawnLocation = EditorGUILayout.Vector3Field("Default Location", defaultSpawnLocation);

                }
                else
                {

                    defaultSpawnLocation = EditorGUILayout.Vector3Field("Default Location", defaultSpawnLocation);

                }

                EditorGUILayout.EndToggleGroup();

                if (!defaultLocation)
                {

                    minSpawnLocation = EditorGUILayout.Vector3Field("Min Location", minSpawnLocation);

                    maxSpawnLocation = EditorGUILayout.Vector3Field("Max Location", maxSpawnLocation);

                }
                #endregion

                EditorGUILayout.Space();

                #region Gameobject Scale
                scaleValue = EditorGUILayout.FloatField("Scale of the Object", scaleValue);

                if (scaleValue <= 0)
                {

                    scaleValue = 0f;

                    EditorGUILayout.HelpBox("Scale of the Object needs to be larger than zero.", MessageType.Error);

                }
                #endregion

            }
            #endregion

            EditorGUILayout.Space();

            #region Button to Spawn
            EditorGUI.BeginDisabledGroup(objectToSpawn == null || objectBaseName == string.Empty ||
                (objectContainer != null && EditorUtility.IsPersistent(objectContainer)));

            if (GUILayout.Button("Spawn Object", GUILayout.Height(buttonHeight)))
            {

                SpawnObject();

            }

            EditorGUI.EndDisabledGroup();
            #endregion

            EditorGUILayout.Space();
            #endregion

            Repaint();

        }
        #endregion

        #region Spawn Object Function
        void SpawnObject()
        {

            Vector3 spawnPos = Vector3.zero;

            if (!useRandom)
            {

                if (defaultLocation)
                {

                    spawnPos = defaultSpawnLocation;

                }

                if (!defaultLocation)
                {

                    spawnPos = new Vector3(Random.Range(minSpawnLocation.x, maxSpawnLocation.x), Random.Range(minSpawnLocation.y, maxSpawnLocation.y), Random.Range(minSpawnLocation.z, maxSpawnLocation.z));

                }

                objectScale = scaleValue;

            }
            else if (useRandom)
            {

                Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;

                spawnPos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

                objectScale = Random.Range(minScaleVal, maxScaleVal);

            }

            string objName = objectBaseName;

            if (previousBaseName != null && previousBaseName != objectBaseName)
            {

                previousBaseName = objectBaseName;

                objectID = 0;

            }
            else
            {

                previousBaseName = objectBaseName;

            }


            if (appendID)
            {

                objName += objectID.ToString();

                objectID++;

            }

            GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity, objectContainer);

            if (icon != null)
            {

                Debug.Log(icon);

                EditorGUIUtility.SetIconForObject(newObject, icon);

            }

            newObject.name = objName;

            newObject.transform.localScale = Vector3.one * objectScale;

        }
        #endregion
    
    }
    #endregion

}
#endif