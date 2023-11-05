using System.Diagnostics.Tracing;
using UnityEditor.XR;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    float _jumpModifier = 12f;
    float _speedMultiplier = 4f;
    float _horizontal = 0f;
    bool _tryInteract, _jumpRequested, _isJumping, _interactable = false;
    int _gravity = 1;
    Rigidbody2D rb;
    CapsuleCollider2D coll;
    [SerializeField]LayerMask _ground;
    float _gravityScale = 1f;
    float _fallingGravityScale = 3f;
    SpriteRenderer sr;
    PhysicsMaterial2D pm;
    // Start is called before the first frame update
    void Start()
    {
       
        sr = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent <CapsuleCollider2D> ();
        rb = GetComponent<Rigidbody2D>();
        pm = rb.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gravity != 0) { ApplyGravity(); }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) { _jumpRequested = true; }
        _horizontal = Input.GetAxis("Horizontal");
        if (_horizontal != 0) { MoveCharacter(); }
        if (_horizontal == 0) { StopCharacter(); }
        if (_jumpRequested && isGrounded()) { DoJump(); }
        if (Input.GetKeyDown(KeyCode.E)) { _tryInteract = true; }
        if (Input.GetKeyUp(KeyCode.E)) { _tryInteract = false; }
        if (_interactable && _tryInteract) { TryInteract(); }
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
        rb.sharedMaterial = pm;
        _isJumping = true;
        _jumpRequested = false;
    }
    void MoveCharacter()
    {   
        if (_horizontal > 0)
        {
            sr.flipX = true;
        }
        if (_horizontal < 0)
        {
            sr.flipX = false;
        }
        rb.velocity = new Vector2(_horizontal * _speedMultiplier, rb.velocity.y);
    }
    void StopCharacter()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
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
            rb.sharedMaterial = null;
            _isJumping = false;
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable" && _tryInteract)
        {
            _interactable = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable" && _tryInteract)
        {
            _interactable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable" && _tryInteract)
        {
            _interactable = false;
        }
    }

    void TryInteract()
    {
        Debug.Log("Trying to do a thing");
    }
}
