using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace QuickFlow.MaterialPopup
{

    public class QuickFlowMaterial : MonoBehaviour
    {

        [MenuItem("Tools/QuickFlow/QuickFlow Window Material #m")]
        public static void Window()
        {

            MaterialPopup.MaterialWindow.Window();

        }

    }

    public class MaterialWindow : EditorWindow
    {

        #region Create Window
        public static void Window()
        {

            var window = GetWindow<MaterialWindow>();

            window.minSize = new Vector2(300f, 1000f);

            window.Show();

        }
        #endregion

        private string materialName = null;

        private Material material;
        
        public Texture2D albedo;

        public Texture2D metallic;

        public Texture2D roughness;

        public Texture2D normal;

        public Texture2D height;

        public Texture2D occlusion;

        public bool isEmissive;

        public Texture2D emission;

        private void OnGUI()
        {

            SetIndentation(6, true);
            EditorGUILayout.LabelField("Material", EditorStyles.boldLabel);
            SetIndentation(6, false);

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

        void CreateMaterial()
        {

            material = new Material(Shader.Find("Standard"));

            material.SetTexture("_MainTex", albedo);

            material.SetTexture("_MetallicGlossMap", metallic);

            material.SetTexture("_OcclusionMap", occlusion);

            material.SetTexture("_ParallaxMap", height);

            material.SetTexture("_BumpMap", normal);

            if (isEmissive)
            {

                material.SetTexture("_EmissionMap", emission);

            }

            Debug.Log("Material");

            string path = EditorUtility.SaveFilePanelInProject("Save Material", "New Material", "mat", "Save Material");
            
            if (!string.IsNullOrEmpty(path))
            {

                AssetDatabase.CreateAsset(material, path);
                
                AssetDatabase.SaveAssets();
                
                AssetDatabase.Refresh();
                
                Debug.Log("Material created and saved at: " + path);
            
            }
            else
            {

                Debug.LogWarning("Material creation cancelled.");
            
            }

        }

    }

}
#endif