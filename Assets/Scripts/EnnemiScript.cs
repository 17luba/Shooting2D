using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private float speed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // D�placement vers le joueur
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Detruire l'ennemi

            Destroy(collision.gameObject); // Detruire la balle apr�s la collision

            GameManager.Instance.IncrementKillCount(); // Incr�menter le nombre d'ennemis tu�s
        }

        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.GameOver(); // Appeler le Game Over
        }
    }
}
