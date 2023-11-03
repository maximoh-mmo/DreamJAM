using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float _speed = 1f;
    [SerializeField] float _speedMultiplier = 1f;
    float _horizontal = 0f;
    bool _jumpRequested = false;
    bool _isJumping = false;
    int _gravity = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_gravity!=0) { ApplyGravity(); }
        if (Input.GetKeyDown(KeyCode.Space)) { _jumpRequested = true; }
        _horizontal = Input.GetAxis("Horizontal");
        if (_horizontal != 0) { MoveCharacter(); }
        if (_jumpRequested) { DoJump(); }
    }
    void DoJump()
    {
        Debug.Log("I'm Jumping");
        _jumpRequested = false;
        _isJumping = true;
    }
    void MoveCharacter()
    {
        transform.position = new Vector2(transform.position.x + _horizontal * Time.deltaTime,transform.position.y);
    }
    void ApplyGravity()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y -9.807f* _gravity * Time.deltaTime);
    }
}
