using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	Rigidbody _rb;
	SpriteRenderer _renderer;
	float _lifetime;
	int _size;
	public float gravDiv = 10f;
	public Sprite[] sprites;
	public GameObject caughtObject;

	void Start () {
		_rb = GetComponent<Rigidbody>();
		_renderer = GetComponentInChildren<SpriteRenderer>();
		_lifetime = 0f;
		_size = 0;
	}
	
	void Update () {
		_lifetime += Time.deltaTime * 1000f;

		if(caughtObject == null){
			if(_lifetime >= 1666 && _size < 1){
				_size += 1;
				_renderer.sprite = sprites[_size];
			}else if(_lifetime >= 3333 && _size < 2){
				_size += 1;
				_renderer.sprite = sprites[_size];
			}else if(_lifetime >= 5000 && _size < 3){
				_size += 1;
				_renderer.sprite = sprites[_size];
			}else if(_lifetime >= 5300 && _size < 4){
				Destroy(gameObject);
			}
		}

		if(caughtObject != null){
			if(_lifetime >= 5000){
			caughtObject.GetComponent<Enemy>().Release();
				Destroy(gameObject);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(caughtObject != null) return;
		if(other.GetComponent<Enemy>()){
			_lifetime = 0f;
			caughtObject = other.gameObject;
			caughtObject.transform.SetParent(transform);
			caughtObject.GetComponent<Enemy>().Capture();
		}
	}

	void FixedUpdate() {
		_rb.velocity = (Vector3.up * (Physics.gravity.magnitude / gravDiv));
	}
}
