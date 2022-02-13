using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer side;
    private float _destroyBullet = 3f;
    private float _bulletSpeed = 20f;
    private string _enemy = "Enemy";
    private string _player = "Player";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        side = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag(_player).transform.localScale.x > 0)
        {
            rb.velocity = transform.right * _bulletSpeed;
            side.flipX = false;
            Destroy(gameObject, _destroyBullet);
        }
        if (GameObject.FindGameObjectWithTag(_player).transform.localScale.x < 0)
        {
            rb.velocity = -transform.right * _bulletSpeed;
            side.flipX = true;
            Destroy(gameObject, _destroyBullet);
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == _enemy)
        {
            Debug.Log($"{_enemy} killed");
            Destroy(gameObject);
        }
    }
}
