using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		transform.Rotate(transform.up, 50f * Time.deltaTime);
	}
}
