using UnityEngine;

namespace QuickFlow
{

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class TitleAttribute :  PropertyAttribute
    {

        public readonly float height;

        public readonly float spacing;

        public readonly Color color;

        public readonly string title;

        public TitleAttribute()
        {

            string _title = "Title";

            float _height = 1f;

            float _spacing = 10f;

            Color _color = new Color(0f, 1f, 1f);

            title = _title;

            height = _height;

            spacing = _spacing;

            color = _color;

        }
        
    }
}
