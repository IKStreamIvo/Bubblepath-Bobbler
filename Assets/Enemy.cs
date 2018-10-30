using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public float speed = 3f;
	public BoxCollider reverseTrigger;
	private Rigidbody _rb;
	private SpriteRenderer _renderer;
	private int _dir = -1;

	public bool caught {get; private set;}

	void Start () {
		_rb = GetComponent<Rigidbody>();
		_renderer = GetComponentInChildren<SpriteRenderer>();
		Debug.Log(Physics.gravity.y + "; " + Physics.gravity.magnitude + "; " + Physics.gravity.sqrMagnitude);
	}

	private void FixedUpdate(){
		if(caught) return;
		if(_rb.velocity.y == 0f){
			_rb.velocity = new Vector2(speed * _dir, 0f);
		}else{
			_rb.velocity = new Vector2(0f, _rb.velocity.y);
			_rb.AddForce(Vector3.up * -Physics.gravity.magnitude / 2.5f);
		}
	}

	public void Reverse(){
		_dir *= -1;
		_renderer.flipX = !_renderer.flipX;
		reverseTrigger.center = new Vector3(reverseTrigger.center.x * -1, reverseTrigger.center.y, reverseTrigger.center.z);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == gameObject) return;
		Debug.Log(other.gameObject.name);
		Reverse();
	}

	public void Capture(){
		if(!caught){
			caught = true;
			_rb.isKinematic = true;
			transform.localScale = new Vector3(.9f, .9f, .9f);
			transform.localPosition = new Vector3(0f, -.6f, 0f);
		}
	}

	public void Release(){
		if(caught){
			_rb.isKinematic = false;
			transform.localScale = new Vector3(1f, 1f, 1f);
			transform.SetParent(null);
			caught = false;
		}
	}
}
