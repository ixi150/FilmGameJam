using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour {
	public int spawnMineButtonNumber;
	string fireButton;
	public GameObject mine;
	// Use this for initialization
	void Start () {
		fireButton = "joystick 1 button " +spawnMineButtonNumber;
		if (!this.transform.parent.GetComponent<PlayerController> ().isFirstPlayer) {
			fireButton = "joystick 2 button " + spawnMineButtonNumber;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (fireButton)) {
			Instantiate (mine, this.transform.position, Quaternion.identity);
		}
	}
}
