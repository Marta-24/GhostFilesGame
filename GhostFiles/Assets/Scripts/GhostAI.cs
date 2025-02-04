using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public Transform character1; // Reference to Character 1
    public Transform character2; // Reference to Character 2
    public GameObject demonForm; // Reference to the demon GameObject
    public float detectionRadius = 5f; // Distance at which the ghost detects the player
    public float fleeRadius = 7f; // Distance at which ghosts flee from the demon
    public float moveSpeed = 2f; // Speed of the ghost
    public float fleeSpeed = 3f; // Speed when fleeing
    public float floatAmplitude = 0.2f; // Floating up/down effect range
    public float floatSpeed = 2f; // Speed of floating effect
    public float groundOffset = 1f; // Distance above the ground
    public int damage = 1; // Damage dealt to the player

    private Transform activeCharacter; // The currently controlled character
    private bool isChasing = false;
    private bool isFleeing = false;
    private Transformation transformationScript; // Reference to Character 2's transformation script

    void Start()
    {
        // Get the transformation script from Character 2
        transformationScript = character2.GetComponent<Transformation>();
    }

    void Update()
    {
        UpdateActiveCharacter();
        FloatEffect();
        DetectPlayer();

        // ✅ **If the demon is active, the ghost flees**
        if (transformationScript != null && transformationScript.IsTransformed())
        {
            FleeFromDemon();
        }
        else if (isChasing && activeCharacter != null)
        {
            ChasePlayer();
        }
    }

    void UpdateActiveCharacter()
    {
        // If the demon is active, the ghost should target the demon form
        if (transformationScript != null && transformationScript.IsTransformed())
        {
            activeCharacter = demonForm.transform;
        }
        else if (character1.gameObject.activeSelf)
        {
            activeCharacter = character1;
        }
        else if (character2.gameObject.activeSelf)
        {
            activeCharacter = character2;
        }
    }

    void FloatEffect()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position += new Vector3(0, newY * Time.deltaTime, 0);
    }

    void DetectPlayer()
    {
        if (activeCharacter == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, activeCharacter.position);
        isChasing = distanceToPlayer < detectionRadius;
    }

    void ChasePlayer()
    {
        if (activeCharacter == null) return;

        Vector3 targetPosition = new Vector3(activeCharacter.position.x, activeCharacter.position.y + groundOffset, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void FleeFromDemon()
    {
        if (demonForm == null) return;

        float distanceToDemon = Vector2.Distance(transform.position, demonForm.transform.position);

        if (distanceToDemon < fleeRadius)
        {
            isFleeing = true;

            // Move away from the demon
            Vector3 fleeDirection = (transform.position - demonForm.transform.position).normalized;
            Vector3 fleeTarget = transform.position + fleeDirection * fleeSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, fleeTarget, fleeSpeed * Time.deltaTime);
        }
        else
        {
            isFleeing = false;
        }
    }
}
