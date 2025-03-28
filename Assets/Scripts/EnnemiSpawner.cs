using UnityEngine;

public class EnnemiSpawner : MonoBehaviour
{
    public GameObject EnnemiPrefab;
    public float SpawnInterval = 3f;

    public Transform[] SpawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnnemy", 0f, SpawnInterval);
    }

    // Update is called once per frame
    void SpawnEnnemy()
    {
        int randonIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(EnnemiPrefab, SpawnPoints[randonIndex].position, Quaternion.identity);
    }
}
