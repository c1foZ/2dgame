using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _speed = 1f;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private string _bullet = "Bullet";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-_speed, rb.velocity.y);
        Debug.Log(rb.velocity);
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == _bullet)
        {
            Destroy(gameObject);
            // GameManager.Instance.RestartRoundDelay(2f);
        }
    }
}
