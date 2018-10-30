using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gravity))]
public class PlayerController : MonoBehaviour {

	Animator _animator;
	Rigidbody _rigidbody;
	SpriteRenderer _renderer;

	[Header("References")]
	public GameObject bulletPrefab;

	[Header("Properties")]
	public Vector2 speed = new Vector2(2f, 2f);
	public float shootForce = 5f;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody>();
		_renderer = GetComponentInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		float hor = Input.GetAxisRaw("Horizontal");
		float ver = Input.GetAxisRaw("Vertical");
		_rigidbody.velocity = new Vector3(hor * speed.x, 0f, ver * speed.y);
		if(hor != 0f || ver != 0f){			
			_animator.SetBool("Moving", true);

			//Set dir
			if(hor != 0f){
				if(hor < 0f){
					_renderer.flipX = true;
				}else{
					_renderer.flipX = false;
				}
			}
		}else if(_animator.GetBool("Moving")){
			_animator.SetBool("Moving", false);
		}

		if(Input.GetButtonDown("Fire1")){
			_animator.SetTrigger("Shoot");
			
			int dir;
			if(_renderer.flipX){
				dir = -1;
			}else{
				dir = 1;
			}
			Vector3 pos = transform.position + new Vector3(dir * .6f, .8f);
			GameObject projectile = Instantiate(bulletPrefab, pos, Quaternion.identity);
			BubbleProjectile bubble = projectile.GetComponent<BubbleProjectile>();
			bubble.Shoot(shootForce * dir);
		}
	}
}
