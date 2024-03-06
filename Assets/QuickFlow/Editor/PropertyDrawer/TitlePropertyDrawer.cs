#region Using Directive
using UnityEditor;
using UnityEngine;
#endregion

#if UNITY_EDITOR
namespace QuickFlow
{

    [CustomPropertyDrawer(typeof(TitleAttribute), true)]
    public class TitlePropertyDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            //base.OnGUI(position, property, label);

            EditorGUI.BeginProperty(position, label, property);

            TitleAttribute titleAttribute = attribute as TitleAttribute;

            Rect separatorRect = new Rect(position.xMin, position.yMin + titleAttribute.spacing, position.width / 2, titleAttribute.height);

            //Draw ine
            EditorGUI.DrawRect(separatorRect, titleAttribute.color);

            EditorGUILayout.Space();

            EditorGUI.EndProperty();

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            TitleAttribute titleAttribute = attribute as TitleAttribute;

            return base.GetPropertyHeight(property, label);

        }

    }

}
#endif
