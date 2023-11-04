using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float _speed = 1f;
    [SerializeField] float _jumpModifier = 1f;
    [SerializeField] float _speedMultiplier = 1f;
    float _horizontal = 0f;
    [SerializeField] bool _jumpRequested = false;
    [SerializeField] bool _isJumping = false;
    [SerializeField] int _gravity = 1;
    Rigidbody2D rb;
    BoxCollider2D coll;
    [SerializeField]LayerMask _ground;
    float _gravityScale = 1f;
    float _fallingGravityScale = 10f;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gravity != 0) { ApplyGravity(); }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) { _jumpRequested = true; }
        _horizontal = Input.GetAxis("Horizontal");
        if (_horizontal != 0) { MoveCharacter(); }
        if (_jumpRequested && isGrounded()) { DoJump(); }

    }
    void DoJump()
    {
        if (_gravity!=0)
        {
            rb.AddForce(Vector2.up * _gravity * _jumpModifier, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.up * _jumpModifier, ForceMode2D.Impulse);
        }
        _isJumping = true;
        _jumpRequested = false;
    }
    void MoveCharacter()
    {
        rb.velocity = new Vector2(_horizontal * _speedMultiplier, rb.velocity.y);
    }
    void ApplyGravity()
    {
        if (rb.velocity.y >= 0 && _isJumping)
        {
            rb.gravityScale = _gravityScale * _gravity;
        }
        else if (rb.velocity.y < 0 && _isJumping)
        {
            rb.gravityScale = _fallingGravityScale * _gravity;
        }
    }
    private bool isGrounded()
    {
        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, _ground))
        {
            _isJumping = false;
            return true;
        }
        return false;
    }
}
