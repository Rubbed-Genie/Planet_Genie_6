using UnityEngine;
using System.Runtime.InteropServices;

namespace Library
{
    public class Wrld03 : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void LoadWrld03();

        private void OnMouseDown()
        {
            LoadWrld03();
            Debug.Log("clicked");
        }
    }
}
