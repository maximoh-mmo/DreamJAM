using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float _speed = 1f;
    [SerializeField] float _jumpModifier = 1f;
    [SerializeField] float _speedMultiplier = 1f;
    float _horizontal = 0f;
    bool _jumpRequested = false;
    bool _isJumping = false;
    int _gravity = 0;
    Rigidbody2D rb;
    BoxCollider2D coll;
    [SerializeField]LayerMask _ground;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // (_gravity!=0) { ApplyGravity(); }
        if (Input.GetKeyDown(KeyCode.Space)) { _jumpRequested = true; }
        _horizontal = Input.GetAxis("Horizontal");
        if (_horizontal != 0) { MoveCharacter(); }
        if (_jumpRequested && isGrounded()) { DoJump(); }
    }
    void DoJump()
    {
        Debug.Log("I'm Jumping");
        rb.AddForce(Vector2.up * _gravity * _jumpModifier, ForceMode2D.Impulse);
        _jumpRequested = false;
        _isJumping = true;
        
    }
    void MoveCharacter()
    {
        rb.velocity = new Vector2(_horizontal * _speedMultiplier, rb.velocity.y);
    }
    void ApplyGravity()
    { 
        rb.velocity = Vector2.up * -9.807f * _gravity * Time.deltaTime;
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, _ground);
    }
}
