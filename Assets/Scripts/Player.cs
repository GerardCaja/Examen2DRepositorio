using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _playerSpeed = 5;
    [SerializeField] private float _jumpForce = 5;
    private float _playerInputH;

    private Rigidbody2D _rBody2D;
    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
        }

        _animator.SetBool("isJumping", !GroundSensor._isGrounded);
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        _playerInputH = Input.GetAxis("Horizontal");
        _rBody2D.velocity = new Vector2(_playerInputH * _playerSpeed, _rBody2D.velocity.y);

        if(_playerInputH < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("isRunning", true);
        }

        else if(_playerInputH > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("isRunning", true);
        }

        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
