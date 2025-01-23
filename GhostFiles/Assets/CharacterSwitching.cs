using UnityEngine;

public class CharacterSwitching : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    private GameObject activeCharacter;

    private CameraFollow cameraFollow; // Reference to the CameraFollow script

    void Start()
    {
        // Get the CameraFollow component
        cameraFollow = Camera.main.GetComponent<CameraFollow>();

        // Start with Character1 as active
        activeCharacter = character1;
        SwitchCharacter(character1, character2);
    }

    void Update()
    {
        // Switch characters on Tab key press
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeCharacter == character1)
            {
                SwitchCharacter(character2, character1);
            }
            else
            {
                SwitchCharacter(character1, character2);
            }
        }
    }

    void SwitchCharacter(GameObject newCharacter, GameObject oldCharacter)
    {
        // Place the new character at the old character's position
        newCharacter.transform.position = oldCharacter.transform.position;

        // Update the active character
        activeCharacter = newCharacter;

        // Enable/Disable appropriate characters
        newCharacter.SetActive(true);
        oldCharacter.SetActive(false);

        // Update the camera target
        cameraFollow.UpdateTarget(newCharacter.transform);
    }
}
