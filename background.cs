using UnityEngine;

public class ColorFadingCube : MonoBehaviour
{
    public float colorChangeDuration = 2.0f; // Duration of the color change
    private Renderer cubeRenderer;
    private Color[] colors;
    private int currentColorIndex = 0;
    private float timer = 0.0f;
    private bool increasingColor = true;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        // Define an array of colors you want the cube to cycle through
        colors = new Color[]
        {
            Color.blue,
            Color.magenta
        };
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= colorChangeDuration)
        {
            // Toggle between increasing and decreasing color
            increasingColor = !increasingColor;
            timer = 0.0f;
        }

        // Calculate the lerp value
        float lerpValue = timer / colorChangeDuration;

        if (increasingColor)
        {
            // Lerping from blue to magenta
            cubeRenderer.material.color = Color.Lerp(colors[0], colors[1], lerpValue);
        }
        else
        {
            // Lerping from magenta to blue
            cubeRenderer.material.color = Color.Lerp(colors[1], colors[0], lerpValue);
        }
    }
}
