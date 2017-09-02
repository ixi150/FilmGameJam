using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour {
	public string spawnMineButton;
	public GameObject mine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (spawnMineButton)) {
			Instantiate (mine, this.transform.position, Quaternion.identity);
		}
	}
}
