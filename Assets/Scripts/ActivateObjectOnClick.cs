using UnityEngine;

public class ActivateObjectOnClick : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnMouseDown()
    {
        objectToActivate.SetActive(!objectToActivate.activeSelf);
    }
}
