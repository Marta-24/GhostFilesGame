using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        SpawnGhosts();
    }

    void SpawnGhosts()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(ghostPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
