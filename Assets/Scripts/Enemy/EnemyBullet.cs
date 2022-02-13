using UnityEngine;
public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _destroyBullet = 3f;
    private float _bulletSpeed = 20f;
    private string _player = "Player";
    private string _enemy = "Enemy";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag(_enemy).transform.localScale.x > 0)
        {
            rb.AddForce(Vector2.left * _bulletSpeed, ForceMode2D.Impulse);
            Destroy(gameObject, _destroyBullet);
        }
        if (GameObject.FindGameObjectWithTag(_enemy).transform.localScale.x < 0)
        {
            rb.AddForce(Vector2.right * _bulletSpeed, ForceMode2D.Impulse);
            Destroy(gameObject, _destroyBullet);
        }

    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == _player)
        {
            Debug.Log($"{_player} killed");
            Destroy(gameObject, _destroyBullet - 2);
        }
    }
}
