using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public bool grounded {get; private set;}
    public Collider groundCheck;
    public LayerMask layerMask;
    Rigidbody _rb;
    float _distToGround;

    Vector3 _center;
    Vector3 _halfExtends; 

    private void Start(){
        _rb = GetComponent<Rigidbody>();
        _distToGround = groundCheck.bounds.extents.y;
        _center = groundCheck.bounds.center;
        _halfExtends = new Vector3(groundCheck.bounds.extents.x, groundCheck.bounds.extents.y, groundCheck.bounds.extents.z);
    }

	private void FixedUpdate() {
        if(!IsGrounded()){
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
			_rb.AddForce(Vector3.up * -Physics.gravity.magnitude / 2.5f);
        }
    }
	
    private bool IsGrounded(){
        grounded = (Physics.OverlapBox(_center, _halfExtends, Quaternion.identity, layerMask).Length > 0) ? true : false;
        //grounded = Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
        return grounded;
    }
}
