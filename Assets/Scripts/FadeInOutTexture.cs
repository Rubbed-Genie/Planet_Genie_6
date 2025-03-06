using UnityEngine;

public class FadeInOutTexture : MonoBehaviour
{
    public float fadeInDuration = 1f; // Duration of the fade-in effect in seconds
    public float fadeOutDuration = 1f; // Duration of the fade-out effect in seconds
    private Material material;
    private Color originalColor;
    private float fadeInTimer = 0f;
    private float fadeOutTimer = 0f;
    private bool fadeInInProgress = false;
    private bool fadeOutInProgress = false;
    private float initialAlpha;

    void Start()
    {
        // Assuming the object has a renderer component with a material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            originalColor = material.color;
            initialAlpha = originalColor.a; // Store the initial alpha value
            material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Start with alpha 0
        }
    }

    void OnEnable()
    {
        // When the GameObject is activated, start the fade-in process
        fadeInInProgress = true;
        fadeInTimer = 0f;
    }

    void Update()
    {
        if (fadeInInProgress)
        {
            // If the fade-in timer hasn't reached the duration, continue fading in
            if (fadeInTimer < fadeInDuration)
            {
                // Increment the timer
                fadeInTimer += Time.deltaTime;
                // Calculate the current alpha value based on the timer and duration
                float targetAlpha = Mathf.Lerp(0f, initialAlpha, fadeInTimer / fadeInDuration);
                // Set the material's color with the updated alpha value
                material.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
            }
            else
            {
                // If fade-in is complete, mark it as such
                fadeInInProgress = false;
                // Start the fade-out process
                fadeOutInProgress = true;
                fadeOutTimer = 0f;
            }
        }

        if (fadeOutInProgress)
        {
            // If the fade-out timer hasn't reached the duration, continue fading out
            if (fadeOutTimer < fadeOutDuration)
            {
                // Increment the timer
                fadeOutTimer += Time.deltaTime;
                // Calculate the current alpha value based on the timer and duration
                float targetAlpha = Mathf.Lerp(initialAlpha, 0f, fadeOutTimer / fadeOutDuration);
                // Set the material's color with the updated alpha value
                material.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
            }
            else
            {
                // If fade-out is complete, mark it as such
                fadeOutInProgress = false;
                // Disable the GameObject
                gameObject.SetActive(false);
            }
        }
    }
}
