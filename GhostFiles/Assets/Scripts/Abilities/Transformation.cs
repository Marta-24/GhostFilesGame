using UnityEngine;

public class Transformation : MonoBehaviour
{
    public GameObject demonForm; // Reference to the demon GameObject
    private bool isTransformed = false;
    private CameraFollow cameraFollow; // Reference to the camera script
    private DemonEffect demonEffect; // Reference to the screen darkening effect

    void Start()
    {
        demonForm.SetActive(false);
        demonForm.transform.localPosition = Vector3.zero; // Align with parent

        // Get references to CameraFollow and DemonEffect
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        demonEffect = FindObjectOfType<DemonEffect>(); // Finds the effect script in the scene
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleTransformation();
        }
    }

    void ToggleTransformation()
    {
        isTransformed = !isTransformed;

        if (isTransformed)
        {
            // Enable demon form and align positions
            demonForm.SetActive(true);
            demonForm.transform.position = transform.position; // Sync positions

            // Update camera to follow the demon
            cameraFollow.UpdateTarget(demonForm.transform);

            // ✅ Tell the DemonEffectManager to start darkening
            demonEffect.ActivateDemonMode();

            // Disable normal form components
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
        }
        else
        {
            // Revert to normal form
            demonForm.SetActive(false);

            // Update camera to follow the player again
            cameraFollow.UpdateTarget(transform);

            // ✅ Tell the DemonEffectManager to start fading back
            demonEffect.DeactivateDemonMode();

            // Re-enable normal form components
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    public bool IsTransformed()
    {
        return isTransformed;
    }
}
