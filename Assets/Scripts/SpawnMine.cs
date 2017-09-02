using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour {
	string spawnMineButton;
	public int spawnMineNumber;
	public GameObject mine;
	// Use this for initialization
	void Start () {
		if (transform.parent.GetComponent<PlayerController> ().isFirstPlayer) {
			spawnMineButton = "joystick 1 button " + spawnMineNumber;
		} else spawnMineButton = "joystick 2 button " + spawnMineNumber;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (spawnMineButton)) {
			Instantiate (mine, this.transform.position, Quaternion.identity);
		}
	}
}
