using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public static bool _isGrounded;

    //private Animator _animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            _isGrounded = true;
            //_animator.SetBool("isJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            _isGrounded = false;
            //_animator.SetBool("isJumping", false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            _isGrounded = true;
            //_animator.SetBool("isJumping", true);
        }
    }
}
