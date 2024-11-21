using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform body;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string DIE_ANIMATION = "Die";
    private bool _isMoving;
    private bool _isFlipped;
    private float _movementX;
    private float _sideForce = 8f;
    private float _jumpForce = 7f;
    private bool _isOnGround;
    private string _floor = "Floor";
    private string _enemy = "Enemy";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (!_isMoving)
        {
            if (Input.GetKey(KeyCode.W) && _isOnGround)
            {
                rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isOnGround = !_isOnGround;
            }
            PlayerMovementKeyboard();
        }
        AnimatePlayer();
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
        else if (Input.GetKey(KeyCode.D))
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
    private void AnimatePlayer()
    {
        if (_movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (_movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    private void OnCollisionEnter2D(Collision2D colliderInfo)
    {
        if (colliderInfo.collider.tag == _floor)
        {
            _isOnGround = true;
        }
        if (colliderInfo.collider.tag == _enemy)
        {
            Die();
        }
    }
    public void Die()
    {
        anim.SetBool(DIE_ANIMATION, true); 
        _isMoving = true; 
        rb.velocity = Vector2.zero;
        StartCoroutine(DisableMovementForDelay(2f));
        GameManager.Instance.RestartRoundDelay(2f); 
        
    }
    private IEnumerator DisableMovementForDelay(float delay)
    {
         _isMoving = true; 
        yield return new WaitForSeconds(delay); 
        _isMoving = false;  
    }
   
}

