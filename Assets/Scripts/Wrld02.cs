using UnityEngine;
using System.Runtime.InteropServices;

namespace Library
{
    public class Wrld02 : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void LoadWrld02();

        private void OnMouseDown()
        {
            LoadWrld02();
            Debug.Log("clicked");
        }
    }
}
