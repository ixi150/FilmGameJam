using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour {
	public int specialWeaponType;
	// Use this for initialization


	void OnTriggerEnter2D(Collider2D col) {
		if (col.GetComponent<PlayerController> ()) {
			col.GetComponent<PlayerController> ().specialWeapon = specialWeaponType;
			Destroy (transform.parent.gameObject);
			Destroy (gameObject);
		}
	}
}
