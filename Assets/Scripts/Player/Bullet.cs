using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _destroyBullet = 3f;
    private float _bulletSpeed = 20f;
    private string _enemy = "Enemy";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x > 0)
        {
            rb.velocity = transform.right * _bulletSpeed;
            Destroy(gameObject, _destroyBullet);
        }
        if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x < 0)
        {
            rb.velocity = -transform.right * _bulletSpeed;
            Destroy(gameObject, _destroyBullet);
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == _enemy)
        {
            Debug.Log($"{_enemy} killed");
            Destroy(gameObject, _destroyBullet - 2);
        }
    }
}
