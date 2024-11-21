using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _destroyBullet = 3f;
    private float _bulletSpeed = 10f;
    private string _player = "Player";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 direction = Vector2.right;
        if (GameObject.FindGameObjectWithTag("Enemy").transform.localScale.x < 0)
            direction = Vector2.left;

        rb.velocity = direction * _bulletSpeed;
        Destroy(gameObject, _destroyBullet);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_player))
            {
            // Find the Player and trigger the death animation
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Die();  // Call the Die method from PlayerMovement
            }

            Debug.Log($"{_player} killed");
            Destroy(gameObject);  // Destroy the bullet
        }
    }
}
