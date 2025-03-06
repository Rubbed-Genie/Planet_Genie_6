using UnityEngine;

public class ActivateObjectOnMouseOver : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToActivate2;
    public float countdownDuration = 5f; // Duration of the countdown in seconds
    private float countdownTimer = 0f;
    private bool isCountingDown = false;

    private void Update()
    {
        // Check if countdownTimer is greater than 0 and decrement it
        if (isCountingDown)
        {
            countdownTimer -= Time.deltaTime;

            // Check if countdownTimer has reached 0 and deactivate objectToActivate2
            if (countdownTimer <= 0f)
            {
                objectToActivate2.SetActive(false);
                countdownTimer = 0f; // Reset the timer
                isCountingDown = false; // Reset the flag
            }
        }
    }

    private void OnMouseEnter()
    {
        // Check if countdown is already active
        if (!isCountingDown)
        {
            objectToActivate.SetActive(true);
            objectToActivate2.SetActive(true);
            countdownTimer = countdownDuration; // Start the countdown timer
            isCountingDown = true; // Set the flag to true
        }
    }
}
