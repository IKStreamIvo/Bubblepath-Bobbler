using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : MonoBehaviour {

	public Transform fruitStorage;
	private List<Rigidbody> _fruits;

	private void Start(){
		_fruits = new List<Rigidbody>();
		for (int i = 0; i < fruitStorage.childCount; i++)
		{
			Rigidbody fruit = fruitStorage.GetChild(i).GetComponent<Rigidbody>();
			fruit.isKinematic = true;
			_fruits.Add(fruit);
		}	
	}

	public void Hit(){
		if(_fruits.Count > 0){
			Rigidbody fruit = _fruits[Random.Range(0, _fruits.Count-1)];
			fruit.isKinematic = false;
			fruit.transform.SetParent(null, true);
		}
	}

}
