using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject character1UI; // UI for Character 1
    public GameObject character2UI; // UI for Character 2
    public GameObject demonUI;      // UI for Demon

    private Transformation transformationScript; // Reference to the transformation script
    private CharacterSwitching characterSwitchingScript; // Reference to character switching

    void Start()
    {
        // Find the required scripts in the scene
        transformationScript = FindObjectOfType<Transformation>();
        characterSwitchingScript = FindObjectOfType<CharacterSwitching>();

        // Make sure the correct UI is displayed at start
        UpdateUI();
    }

    void Update()
    {
        // Continuously update UI based on active character
        UpdateUI();
    }

    void UpdateUI()
    {
        if (transformationScript.IsTransformed())
        {
            // Demon is active
            character1UI.SetActive(false);
            character2UI.SetActive(false);
            demonUI.SetActive(true);
        }
        else if (characterSwitchingScript.IsCharacter1Active())
        {
            // Character 1 is active
            character1UI.SetActive(true);
            character2UI.SetActive(false);
            demonUI.SetActive(false);
        }
        else
        {
            // Character 2 is active
            character1UI.SetActive(false);
            character2UI.SetActive(true);
            demonUI.SetActive(false);
        }
    }
}
