using UnityEngine;

public class Transformation : MonoBehaviour
{
    public GameObject demonForm; // Reference to the demon GameObject
    private bool isTransformed = false;

    void Start()
    {
        // Ensure the demon form is disabled initially
        demonForm.SetActive(false);
        demonForm.transform.localPosition = Vector3.zero; // Align with parent
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

            // Optionally disable normal form components
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
        }
        else
        {
            // Revert to normal form
            demonForm.SetActive(false);

            // Re-enable normal form components
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            GetComponent<Rigidbody2D>().simulated = true;
        }
    }
}
