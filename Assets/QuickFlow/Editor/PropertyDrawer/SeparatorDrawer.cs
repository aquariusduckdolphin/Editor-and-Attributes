#region Using Directive
using UnityEditor;
using UnityEngine;
#endregion

#if UNITY_EDITOR
namespace QuickFlow
{

    [CustomPropertyDrawer(typeof(SeparatorAttribute))]
    public class SeparatorDrawer : DecoratorDrawer
    {

        public override void OnGUI(Rect position)
        {

            //Get a reference to the attribute
            SeparatorAttribute separatorAttribute = attribute as SeparatorAttribute;

            //Define the line to draw
            Rect separatorRect = new Rect(position.xMin, position.yMin + separatorAttribute.spacing, position.width, separatorAttribute.height);

            //Draw in
            EditorGUI.DrawRect(separatorRect, separatorAttribute.color);

        }

        public override float GetHeight()
        {

            SeparatorAttribute separatorAttribute = attribute as SeparatorAttribute;

            float totalSpacing = separatorAttribute.spacing 
                + separatorAttribute.height 
                + separatorAttribute.spacing;

            return totalSpacing;

        }

    }

}
#endif
