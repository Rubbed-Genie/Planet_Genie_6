using UnityEngine;
using System.Runtime.InteropServices;

namespace Library
{
    public class Wrld04 : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void LoadWrld04();

        private void OnMouseDown()
        {
            LoadWrld04();
            Debug.Log("clicked");
        }
    }
}
