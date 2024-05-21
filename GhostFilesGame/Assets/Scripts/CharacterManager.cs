using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject ryan;  // Reference to the Ryan character
    public GameObject shane; // Reference to the Shane character
    private GameObject activeCharacter;
    private Light playerLight;

    void Start()
    {
        // Set Ryan as the default active character
        activeCharacter = ryan;
        playerLight = activeCharacter.GetComponentInChildren<Light>();
        ryan.SetActive(true);
        shane.SetActive(false);
    }

    void Update()
    {
        // Log input detection for debugging
        if (Input.GetButtonDown("Switch"))
        {
            Debug.Log("Switch input detected");
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Store the current position
        Vector3 currentPosition = activeCharacter.transform.position;

        // Toggle active character
        if (activeCharacter == ryan)
        {
            Debug.Log("Switching to Shane");
            activeCharacter = shane;
            ryan.SetActive(false);
            shane.SetActive(true);
        }
        else
        {
            Debug.Log("Switching to Ryan");
            activeCharacter = ryan;
            shane.SetActive(false);
            ryan.SetActive(true);
        }

        // Set the new active character to the previous position
        activeCharacter.transform.position = currentPosition;

        // Transfer the light to the new active character
        playerLight.transform.parent = activeCharacter.transform;
        playerLight.transform.localPosition = Vector3.zero; // Ensure the light is correctly positioned
    }
}
