using UnityEngine;
using System.Runtime.InteropServices;
namespace Library
{
    public class WRldSelect : MonoBehaviour
    {
        public GameObject Wrld01;
        public GameObject Wrld02;
        public GameObject Wrld03;
        public GameObject Wrld04;

        [DllImport("__Internal")]
        private static extern void LoadWrld01();

        [DllImport("__Internal")]
        private static extern void LoadWrld02();

        [DllImport("__Internal")]
        private static extern void LoadWrld03();

         [DllImport("__Internal")]
        private static extern void LoadWrld04();


        private void OnMouseDown()
        {
            if (gameObject == Wrld01)
            {
                WRldSelect.LoadWrld01();
                Debug.Log("wrld1");
            }

            if (gameObject == Wrld02)
            {
                WRldSelect.LoadWrld02();
                Debug.Log("wrld2");
            }

            if (gameObject == Wrld03)
            {
                WRldSelect.LoadWrld03();
                Debug.Log("wrld3");
            }
            
            if (gameObject == Wrld04)
            {
                WRldSelect.LoadWrld04();
                Debug.Log("wrld4");
            }
        }
    }
}
