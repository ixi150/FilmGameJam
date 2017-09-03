using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour {
	string spawnMineButton;
	public int spawnMineNumber;
	public GameObject mine;
	public float cooldown = 1f;
	bool canShoot = true;
	float timer = 0f;
	// Use this for initialization
	void Start () {
		if (transform.parent.GetComponentInParent<PlayerController> ().isFirstPlayer) {
			spawnMineButton = "joystick 1 button " + spawnMineNumber;
		} else spawnMineButton = "joystick 2 button " + spawnMineNumber;
	}
	
	// Update is called once per frame
	void Update () {
		if(canShoot == false) {
		timer += Time.deltaTime;
			if (timer >= cooldown)
				canShoot = true;
			}
		if (Input.GetKeyDown (spawnMineButton) && canShoot) {
			Instantiate (mine, this.transform.position, Quaternion.identity);
		}
	}
}
