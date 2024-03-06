#region Using Directive
using UnityEngine;
using UnityEditor;
#endregion

#if UNITY_EDITOR
namespace QuickFlow
{

    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            GUI.enabled = false;

            EditorGUI.PropertyField(position, property, label);

            GUI.enabled = true;

        }

    }
}
#endif