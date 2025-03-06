using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    public float rotationSpeed = 22f;
    public float easingFactor = 0.5f;
    public float inertiaFactor = 0.05f;
    public float autoRotateDelay = 5f;
    public float autoRotationSpeed = 10f; // New public variable for controlling the auto-rotation speed

    private Vector3 mouseOrigin;
    private bool isDragging = false;
    private bool isAutoRotating = false;

    private Vector3 lastMousePosition;
    private Vector3 currentMousePosition;
    private Vector3 currentRotationSpeed;
    private float autoRotateTimer;
    private void Start()
    {
        // Initialize the globe with an initial rotation speed
        currentRotationSpeed = new Vector3(0f, autoRotationSpeed, 0f); 
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            mouseOrigin = Input.mousePosition;
            currentRotationSpeed = Vector3.zero;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            lastMousePosition = Input.mousePosition;
            currentMousePosition = lastMousePosition;
            autoRotateTimer = autoRotateDelay;
        }

        if (isDragging)
        {
            currentMousePosition = Input.mousePosition;

            Vector3 mouseDelta = currentMousePosition - mouseOrigin;
            float rotationX = mouseDelta.y * rotationSpeed * Time.deltaTime; // Inverted
            float rotationY = -mouseDelta.x * rotationSpeed * Time.deltaTime; // Inverted

            transform.Rotate(Vector3.right, rotationX, Space.World);
            transform.Rotate(Vector3.up, rotationY, Space.World);

            mouseOrigin = currentMousePosition;
            currentRotationSpeed = new Vector3(rotationX, rotationY, 0f);
        }
        else if (currentRotationSpeed.magnitude > 0f)
        {
            Vector3 dampingForce = -currentRotationSpeed * inertiaFactor;
            currentRotationSpeed += dampingForce * Time.deltaTime;
            transform.Rotate(Vector3.right, currentRotationSpeed.x, Space.World);
            transform.Rotate(Vector3.up, currentRotationSpeed.y, Space.World);
        }
        else if (autoRotateTimer > 0f)
        {
            autoRotateTimer -= Time.deltaTime;

            if (autoRotateTimer <= 0f)
            {
                isAutoRotating = true;
                currentRotationSpeed = new Vector3(0f, autoRotationSpeed, 0f); // Use the new autoRotationSpeed for auto-rotation
            }
        }
        else if (isAutoRotating)
        {
            transform.Rotate(Vector3.up, currentRotationSpeed.y * Time.deltaTime, Space.World);
            currentRotationSpeed *= 1f - easingFactor;

            if (currentRotationSpeed.magnitude < 0.01f)
            {
                isAutoRotating = false;
                currentRotationSpeed = Vector3.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ResetTransform();
        }
    }

    private void ResetTransform()
    {
        transform.rotation = Quaternion.identity;
        currentRotationSpeed = Vector3.zero;
        autoRotateTimer = autoRotateDelay; // Reset autoRotateTimer to its initial value
        isAutoRotating = false;
    }
}
