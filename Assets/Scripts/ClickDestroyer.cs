using UnityEngine;

public class ClickDestroyer : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] clickableScripts; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var script in clickableScripts)
            {
                Destroy(script);
            }
        }
    }
}