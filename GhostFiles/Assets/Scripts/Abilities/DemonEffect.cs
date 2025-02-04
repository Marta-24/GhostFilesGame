using UnityEngine;
using UnityEngine.UI;

public class DemonEffect : MonoBehaviour
{
    public Image vignette; // UI Image covering the screen
    public float darkenTime = 10f; // Time to full black
    public float lightenTime = 2f; // Time to fade back to normal
    private float currentDarkness = 0f; // 0 = no darkness, 1 = full black
    private float darknessSpeed; // Speed of darkening per second
    private float lightenSpeed; // Speed of lightening per second
    private bool isDemon = false; // Whether the demon mode is active

    void Start()
    {
        darknessSpeed = 1f / darkenTime; // Calculate darkening speed
        lightenSpeed = 1f / lightenTime; // Calculate lightening speed
        SetVignetteAlpha(0f); // Start fully normal
    }

    void Update()
    {
        if (isDemon)
        {
            // Gradually increase darkness (until fully black)
            currentDarkness = Mathf.Clamp01(currentDarkness + darknessSpeed * Time.deltaTime);
        }
        else
        {
            // Gradually decrease darkness (until fully normal)
            currentDarkness = Mathf.Clamp01(currentDarkness - lightenSpeed * Time.deltaTime);
        }

        SetVignetteAlpha(currentDarkness);
    }

    public void ActivateDemonMode()
    {
        isDemon = true; // Start darkening
    }

    public void DeactivateDemonMode()
    {
        isDemon = false; // Start lightening
    }

    private void SetVignetteAlpha(float alpha)
    {
        if (vignette == null) return;

        Color color = vignette.color;
        color.a = alpha;
        vignette.color = color;
    }
}
