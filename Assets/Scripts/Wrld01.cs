using UnityEngine;
using System.Runtime.InteropServices;

namespace Library
{
    public class Wrld01 : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void LoadWrld01();

        private void OnMouseDown()
        {
            LoadWrld01();
            Debug.Log("clicked");
        }
    }
}