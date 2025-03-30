using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Instance unique pour l'accès global
    public TextMeshProUGUI KillCountText; // Referent au text pour afficher le score
    private int killCount = 0; // nombre d'ennemi tués

    public GameObject GameOverPanel;
    public Button RetryButton;

    private float enemySpawnRate = 2f;
    private float enemySped = 2f;
    private int killsToIncreaseDifficulty = 10;

    private void Awake()
    {
            Instance = this;
    }

    private void Start()
    {
        KillCountText.text = "Kills: " + killCount;

        GameOverPanel.SetActive(false);

        RetryButton.onClick.AddListener(RestartGame);
    }

    public void IncrementKillCount()
    {
        killCount++;
        KillCountText.text = "Kills : " + killCount;

        if (killCount % killsToIncreaseDifficulty == 0)
        {
            IncreaseDifficulty();
        }
    }

    public void IncreaseDifficulty() 
    {
        enemySpawnRate = Mathf.Max(0.5f, enemySpawnRate - 0.2f); // Diminuer le temps entre l'apparition des ennemis
        enemySped += 1.5f; // Augmenter la vitesse des ennemis
        Debug.Log("Dificulté augmentée : vitesse des ennemis = " + enemySped + ", Temps d'apparition = " + enemySpawnRate);
    }

    public float GetEnemySpeed()
    {
        return enemySped;
    }

    public float GetEnemySpawnRate()
    {
        return enemySpawnRate;
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Mettre le jeu en pause
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reprendre le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharger la scene
    }

}
