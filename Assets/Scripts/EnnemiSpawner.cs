using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + GameManager.Instance.GetEnemySpawnRate(); // Fréquence d'apparition dynamique
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Choisir un point de spawn aléatoire
        Transform spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        GameObject enemy = Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);

        // Ajuster la vitesse de l'ennemi
        enemy.GetComponent<EnemyMovement>().SetSpeed(GameManager.Instance.GetEnemySpeed());
    }
}
