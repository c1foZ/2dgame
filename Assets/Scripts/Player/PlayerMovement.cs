using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _sideForce = 10f;
    private float _jumpForce = 7f;
    private bool _isOnGround;
    private string _floor = "Floor";
    private string _enemy = "Enemy";
    private string _enemyBullet = "EnemyBullet";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && _isOnGround)
        {
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isOnGround = !_isOnGround;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * _sideForce, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * _sideForce, ForceMode2D.Force);
        }
        if (rb.position.y < -10)
        {
            GameManager.Instance.RestartRoundDelay(1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D colliderInfo)
    {
        if (colliderInfo.collider.tag == _floor)
        {
            _isOnGround = true;
        }
        if (colliderInfo.collider.tag == _enemy || colliderInfo.collider.tag == _enemyBullet)
        {
            Destroy(gameObject);
            GameManager.Instance.RestartRoundDelay(2f);
        }
    }
}

