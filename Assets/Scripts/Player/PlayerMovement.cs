using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform body;
    private bool _isFlipped;
    private float _movementX;
    private float _sideForce = 8f;
    private float _jumpForce = 7f;
    private bool _isOnGround;
    private string _floor = "Floor";
    private string _enemy = "Enemy";
    private string _enemyBullet = "EnemyBullet";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && _isOnGround)
        {
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isOnGround = !_isOnGround;
        }
        PlayerMovementKeyboard();
        if (rb.position.y < -10)
        {
            GameManager.Instance.RestartRoundDelay(1f);
        }
    }
    private void PlayerMovementKeyboard()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        body.position += new Vector3(_movementX, 0f, 0f) * _sideForce * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            FlipDirection("Left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            FlipDirection("Right");
        }
    }
    private void FlipDirection(string side)
    {
        if (side == "Right" && _isFlipped)
        {
            body.localScale = new Vector3(body.localScale.x * -1, body.localScale.y, body.localScale.z);
            _isFlipped = false;
        }
        if (side == "Left" && !_isFlipped)
        {
            body.localScale = new Vector3(body.localScale.x * -1, body.localScale.y, body.localScale.z);
            _isFlipped = true;
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

