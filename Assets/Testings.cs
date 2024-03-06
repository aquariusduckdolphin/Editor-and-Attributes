using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickFlow
{
    public class Testings : MonoBehaviour
    {


        public Material material;

        //public Color color = Color.

        //public QuickColors color;

        // Start is called before the first frame update
        void Start()
        {

        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnDrawGizmosSelected()
        {

            Gizmos.DrawIcon(transform.position, "enemy.png", true);

        }

    }
}
