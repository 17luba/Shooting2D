using UnityEngine;

public class EnnemiScript : MonoBehaviour
{
    public float Speed = 2;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Trouver le joueur
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Deplacer l'ennemi vers le jouer
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detruire l'ennemi
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Ennemi touché par la balle");

            Destroy(gameObject);

            Destroy(collision.gameObject);
            GameManager.Instance.IncrementKillCount();
        }
    }
}
