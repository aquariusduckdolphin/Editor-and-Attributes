using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

#if UNITY_EDITOR
namespace QuickFlow.Editor
{

    #region Menu Display
    public class QuickFlowCreateMaterialWindow : MonoBehaviour
    {

        [MenuItem("Tools/QuickFlow/QuickFlow Window Material #m")]
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

            window.minSize = new Vector2(300f, 550f);

            window.maxSize = window.minSize;

            window.Show();

        }
        #endregion

        #region Material Variables
        private Material material;
        
        public Texture2D albedo;

        public Texture2D metallic;

        public Texture2D roughness;

        public Texture2D normal;

        public Texture2D height;

        public Texture2D occlusion;

        public bool isEmissive;

        public Texture2D emission;
        #endregion

        private bool standardMaterial = true;

        private const string standard = "Standard";

        private bool urpMaterial = false;

        private const string urp = "Universial Render Pipeline/Lit";

        private bool hdrpMaterial = false;

        private const string hdrp = "HDRP/Lit";

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

            Tooget();

            albedo = EditorGUILayout.ObjectField("Albedo Map", albedo, typeof(Texture2D), false) as Texture2D;

            metallic = EditorGUILayout.ObjectField("Metallic Map", metallic, typeof(Texture2D), false) as Texture2D;

            roughness = EditorGUILayout.ObjectField("Roughness Map", roughness, typeof(Texture2D), false) as Texture2D;

            normal = EditorGUILayout.ObjectField("Normal Map", normal, typeof(Texture2D), false) as Texture2D;

            height = EditorGUILayout.ObjectField("Height Map", height, typeof(Texture2D), false) as Texture2D;

            occlusion = EditorGUILayout.ObjectField("Occlusion Map", occlusion, typeof(Texture2D), false) as Texture2D;

            isEmissive = EditorGUILayout.BeginToggleGroup("Use Emissive Map", isEmissive);

            emission = EditorGUILayout.ObjectField("Emission Map", emission, typeof(Texture2D), false) as Texture2D;

            EditorGUILayout.EndToggleGroup();

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
            else if (hdrpMaterial)
            {

                material = new Material(Shader.Find(hdrp));

            }


            material.SetTexture("_MainTex", albedo);

            material.SetTexture("_MetallicGlossMap", metallic);

            material.SetTexture("_OcclusionMap", occlusion);

            material.SetTexture("_ParallaxMap", height);

            material.SetTexture("_BumpMap", normal);

            if (isEmissive)
            {

                material.SetTexture("_EmissionMap", emission);

            }

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

        private void Tooget()
        {

            standardMaterial = EditorGUILayout.BeginToggleGroup("Standard Material", standardMaterial);
            
            //EditorGUI.BeginDisabledGroup(standardMaterial);

            //hdrpMaterial = EditorGUILayout.BeginToggleGroup("HDRP Material", hdrpMaterial);

            //EditorGUI.EndDisabledGroup();

            EditorGUILayout.EndToggleGroup();


        }

    }
    #endregion

}
#endif