using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour {
	int abilityNumber;
	public int keyNumber;
	string key;
	public float shootForce;
	PlayerController control;
	public GameObject[] specials;
	public Transform muzzle;
	// Use this for initialization
	void Start () {
		control = transform.GetComponent<PlayerController> ();
		if (control.isFirstPlayer)
			key = "joystick 1 button " + keyNumber;
		else
			key = "joystick 2 button " + keyNumber;
			
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key) && control.specialWeapon != 0) {
			GameObject obj = Instantiate (specials [control.specialWeapon - 1], muzzle.position, muzzle.rotation);
			obj.GetComponent<Rigidbody2D>().AddForce(muzzle.right * shootForce, ForceMode2D.Impulse);
			control.specialWeapon = 0;
		}

	}
}
