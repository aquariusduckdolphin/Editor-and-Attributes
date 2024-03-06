using UnityEngine;

namespace QuickFlow
{

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
    public class SeparatorAttribute : PropertyAttribute
    {

        public readonly float height;

        public readonly float spacing;

        public readonly Color color;

        public SeparatorAttribute()
        {

            float _height = 1f;

            float _spacing = 20f;

            //QuickColors _color = QuickColors.White;

            Color _color = Color.white;

            height = _height;

            spacing = _spacing;

            color = _color;

        }

        /*public SeparatorAttribute(QuickColors _color)
        {

            float _height = 1f;

            float _spacing = 10f;

            height = _height;

            spacing = _spacing;

            color = _color;

        }

        public SeparatorAttribute(float _spacing)
        {

            QuickColors _color = QuickColors.White;

            float _height = 1f;

            height = _height;

            spacing = _spacing;

            color = _color;

        }

        public SeparatorAttribute(float _height, QuickColors _color)
        {

            float _spacing = 10f;

            height = _height;

            spacing = _spacing;

            color = _color;

        }

        public SeparatorAttribute(float _height, float _spacing, QuickColors _color)
        {

            height = _height;

            spacing = _spacing;

            color = _color;

        }*/

    }

}
