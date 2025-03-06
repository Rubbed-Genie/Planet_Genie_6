using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private bool rotateX;
    [SerializeField] private bool rotateY;
    [SerializeField] private bool rotateZ;
    [SerializeField] private bool clockwise;

    public float rotationSpeed = 20f;

    private void Update()
    {
        float rotationDirection = clockwise ? 1f : -1f;

        if (rotateX)
            transform.Rotate(Vector3.right * rotationSpeed * rotationDirection * Time.deltaTime);

        if (rotateY)
            transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);

        if (rotateZ)
            transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection * Time.deltaTime);
    }
}
