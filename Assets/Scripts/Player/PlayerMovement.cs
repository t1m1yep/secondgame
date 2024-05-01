using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    private bool _isJumping;
    private bool _isGrounded = false;
    private Rigidbody _rb;
    private Vector2 _input;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        _isJumping = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        if(_isGrounded) {
            if(_isJumping) {
                _rb.velocity = new Vector3(_rb.velocity.x, jumpSpeed, _rb.velocity.z);
            }
            else if (_input.magnitude > 0.5){
                Debug.Log(_input.magnitude);
                _rb.AddForce(Movement(speed), ForceMode.VelocityChange);
            }
            else {
                Debug.Log(_input.magnitude);
                _rb.velocity = new Vector3(_rb.velocity.x * 0.05f * Time.fixedDeltaTime, _rb.velocity.y, _rb.velocity.z * 0.05f * Time.fixedDeltaTime);
            }
        }
    }

    private Vector3 Movement(float speed) {
        Vector3 vel = new Vector3(_input.x, 0, _input.y);
        vel = transform.TransformDirection(vel);
        vel *= speed;
        return vel;
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Floor") {
            _isGrounded = true;   
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Floor") {
            _isGrounded = false;   
        }
    }
}
