using UnityEngine;

public class FadeInTexture : MonoBehaviour
{
    public float fadeInDuration = 1f; // Duration of the fade-in effect in seconds
    private Material material;
    private Color originalColor;
    private float fadeInTimer = 0f;
    private bool fadeInInProgress = false;

    void Start()
    {
        // Assuming the object has a renderer component with a material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            originalColor = material.color;
            // Set the initial color with alpha set to 0
            material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
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
            // If the fade-in timer hasn't reached the duration, continue fading
            if (fadeInTimer < fadeInDuration)
            {
                // Increment the timer
                fadeInTimer += Time.deltaTime;
                // Calculate the current alpha value based on the timer and duration
                float alpha = fadeInTimer / fadeInDuration;
                // Set the material's color with the updated alpha value
                material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            }
            else
            {
                // If fade-in is complete, mark it as such
                fadeInInProgress = false;
            }
        }
    }
}
