using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showSpecial : MonoBehaviour {
	int special;
	int internalSpecial;
	GameObject player;
	public bool isFirstPlayer;
	PlayerController control;
	public Sprite images;
	// Use this for initialization
	void Start () {
		internalSpecial = special;

		GameObject[] obj = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject o in obj) {
			if (o.GetComponent<PlayerController> ().isFirstPlayer == isFirstPlayer) {
				player = o;
				control = o.GetComponent<PlayerController> ();
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		special = control.specialWeapon;
		if (special != internalSpecial) {
			transform.GetComponent<Image> ().sprite = images;
			internalSpecial = special;

		}
	}
}
