using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Instance unique pour l'acc�s global
    public TextMeshProUGUI KillCountText; // Referent au text pour afficher le score
    private int killCount = 0; // nombre d'ennemi tu�s

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementKillCount()
    {
        killCount++;
        KillCountText.text = "Kills : " + killCount;
    }
}
