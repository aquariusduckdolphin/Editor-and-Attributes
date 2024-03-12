#region Directives
using UnityEditor;
using UnityEngine;
#endregion

#if UNITY_EDITOR
namespace QuickFlow.Editor
{

    #region Menu Display
    public class QuickFlowCreateMaterialWindow : MonoBehaviour
    {

        [MenuItem("QuickFlow/QuickFlow Material Editor Window #m")]
        public static void Window()
        {

            MaterialEditorWindow.Window();

        }

    }
    #endregion

    #region Display Window Material 
    public class MaterialEditorWindow : EditorWindow
    {

        #region Create Window
        public static void Window()
        {

            var window = GetWindow<MaterialEditorWindow>();

            window.minSize = new Vector2(300f, 640f);

            window.Show();

        }
        #endregion

        #region Material Variables
        private Material material;
        
        private Texture2D albedo;

        private Texture2D metallic;

        private bool useRoughness = false;

        private Texture2D roughness;

        private Texture2D normal;

        private Texture2D height;

        private Texture2D occlusion;

        private bool isEmissive;

        private Texture2D emission;
        #endregion

        #region Material Type
        private bool standardMaterial = true;

        private const string standard = "Standard";

        /*private bool urpMaterial = false;

        private const string urp = "Universial Render Pipeline/Unlit";

        private bool hdrpMaterial = false;

        private const string hdrp = "HDRP/Lit";*/
        #endregion

        #region Indentation
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

            SetIndentation(6, true);
            EditorGUILayout.LabelField("Material", EditorStyles.boldLabel);
            SetIndentation(6, false);

            ToggleGroups();

            albedo = EditorGUILayout.ObjectField("Albedo Map", albedo, typeof(Texture2D), false) as Texture2D;

            metallic = EditorGUILayout.ObjectField("Metallic Map", metallic, typeof(Texture2D), false) as Texture2D;

            useRoughness = EditorGUILayout.BeginToggleGroup("Use Roughness Map", useRoughness);

            roughness = EditorGUILayout.ObjectField("Roughness Map", roughness, typeof(Texture2D), false) as Texture2D;

            EditorGUILayout.EndToggleGroup();

            EditorGUILayout.HelpBox("Having the roughness map checked means that the metallic map will not be used.", MessageType.Info);

            normal = EditorGUILayout.ObjectField("Normal Map", normal, typeof(Texture2D), false) as Texture2D;

            height = EditorGUILayout.ObjectField("Height Map", height, typeof(Texture2D), false) as Texture2D;

            occlusion = EditorGUILayout.ObjectField("Occlusion Map", occlusion, typeof(Texture2D), false) as Texture2D;

            isEmissive = EditorGUILayout.BeginToggleGroup("Use Emissive Map", isEmissive);

            emission = EditorGUILayout.ObjectField("Emission Map", emission, typeof(Texture2D), false) as Texture2D;

            EditorGUILayout.EndToggleGroup();

            EditorGUILayout.Space();

            if (GUILayout.Button("Create Material", GUILayout.ExpandWidth(true), GUILayout.Height(45)))
            {

                CreateMaterial();

            }

        }
        #endregion

        #region Create the Material
        void CreateMaterial()
        {

            if (standardMaterial)
            {

                material = new Material(Shader.Find(standard));


            }
            /*else if (hdrpMaterial)
            {

                material = new Material(Shader.Find(hdrp));

            }
            else if (urpMaterial)
            {

                material = new Material(Shader.Find(urp));

            }*/

            material.SetTexture("_MainTex", albedo);

            if (!useRoughness)
            {

                material.SetTexture("_MetallicGlossMap", metallic);

            }
            else
            {

                material.SetTexture("_MetallicGlossMap", roughness);

            }


            material.SetTexture("_OcclusionMap", occlusion);

            material.SetTexture("_ParallaxMap", height);

            material.SetTexture("_BumpMap", normal);

            if (isEmissive)
            {

                material.SetTexture("_EmissionMap", emission);

            }

            OpenFolderForMaterialDisplay();

        }
        #endregion

        #region Allow the user to place the material and name
        private void OpenFolderForMaterialDisplay()
        {

            string path = EditorUtility.SaveFilePanelInProject("Save Material", "New Material", "mat", "Save Material");

            if (!string.IsNullOrEmpty(path))
            {

                AssetDatabase.CreateAsset(material, path);

                AssetDatabase.SaveAssets();

                AssetDatabase.Refresh();

            }
            else
            {

                Debug.Log("Material failed to be created!");

            }

        }
        #endregion

        #region Toggle for Material Type
        private void ToggleGroups()
        {

            //standardMaterial = EditorGUILayout.Toggle("Standard Material", standardMaterial);

            EditorGUILayout.LabelField("Material Shader: Standard");

            /*EditorGUI.BeginDisabledGroup(standardMaterial);

            hdrpMaterial = EditorGUILayout.Toggle("HDRP Material", hdrpMaterial);

            EditorGUI.BeginDisabledGroup(hdrpMaterial);

            urpMaterial = EditorGUILayout.Toggle("URP Material", urpMaterial);

            EditorGUI.EndDisabledGroup();

            EditorGUI.EndDisabledGroup();*/

        }
        #endregion

    }
    #endregion

}
#endif