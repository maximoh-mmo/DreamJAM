using System.Diagnostics.Tracing;
using UnityEditor.XR;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField] float _jumpModifier = 12f;
    [SerializeField] float _speedMultiplier = 4f;
    [SerializeField] float _horizontal = 0f;
    [SerializeField] bool _tryInteract, _jumpRequested, _isGrounded, _isJumping, _interactable, _interact = false;
    [SerializeField] int _gravity = 1;
    Rigidbody2D rb;
    CapsuleCollider2D coll;
    [SerializeField]LayerMask _ground;
    [SerializeField] float _gravityScale = 1f;
    [SerializeField] float _fallingGravityScale = 3f;
    SpriteRenderer sr;
    PhysicsMaterial2D pm;
    Animator _animator;
    [SerializeField] GameObject _currentInteractable = null;
    public bool Interact {  get { return _interact; } }
    public float JumpModifier { set { _jumpModifier = value; } }
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent <CapsuleCollider2D> ();
        rb = GetComponent<Rigidbody2D>();
        pm = rb.sharedMaterial;
       
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = isGrounded();
        _horizontal = Input.GetAxis("Horizontal");
        
        if (_isGrounded==true )
        {
            rb.sharedMaterial = null;
            coll.sharedMaterial = null;
            _animator.SetBool("isJumping", false);
        }
        if (_jumpRequested==true && _isGrounded == true) { DoJump(); }
        if (_gravity != 0) { ApplyGravity(); }
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true) { _jumpRequested = true; }
        if (_horizontal != 0) { MoveCharacter(); }
        if (_horizontal == 0) { StopCharacter(); }
        if (Input.GetKeyDown(KeyCode.E)) { _tryInteract = true; }
        if (Input.GetKeyUp(KeyCode.E)) { _tryInteract = false; }
        if (_interactable==true && _tryInteract == true) { TryInteract(); }
    }
    void DoJump()
    {
        _animator.SetBool("isWalking", false);
        _animator.SetBool("isJumping", true);
        rb.sharedMaterial = pm;
        coll.sharedMaterial= pm;
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
        if (_isGrounded == true) { _animator.SetBool("isWalking", true); _animator.SetBool("isJumping", false); }
        else { _animator.SetBool("isWalking", false); }
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
        _animator.SetBool("isWalking", false);
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
    void ApplyGravity()
    {
        if (rb.velocity.y >= 0 && _isJumping == true)
        {
            rb.gravityScale = _gravityScale * _gravity;
        }
        else if (rb.velocity.y < 0 && _isJumping == true)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _currentInteractable = collision.gameObject;
            _interactable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _currentInteractable = null;
            _interactable = false;
        }
    }

    void TryInteract()
    {
        if (_currentInteractable != null)
        {
            _currentInteractable.GetComponent<InteractableSwitch>().Trigger();
        }
    }
}
