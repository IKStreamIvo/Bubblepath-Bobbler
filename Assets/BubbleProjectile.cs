using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleProjectile : MonoBehaviour {
	
	public GameObject bubblePrefab;
	public Rigidbody rb;

	public void Shoot(float velocity){
		rb.velocity = new Vector2(velocity, 0f);
	}

	private void OnCollisionEnter(Collision other){

		GameObject bubble = Instantiate(bubblePrefab, transform.position + new Vector3(0f, .5f, 0f), Quaternion.identity);

		/*if(other.gameObject.GetComponent<FruitTree>()){
			other.gameObject.GetComponent<FruitTree>().Hit();
		}*/

		Destroy(gameObject);
	}
}
