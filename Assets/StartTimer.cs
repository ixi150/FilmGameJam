using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour {
	public float startTime = 5f;
	float timer;

	public float Timer {
		get {
			return timer;
		}
	}

	// Use this for initialization
	void Start () {
		timer = startTime;
		foreach (var player in GameObject.FindObjectsOfType<PlayerController>())
			player.enabled = false;
		foreach (var weapon in GameObject.FindObjectsOfType<BasicWeapon>())
			weapon.enabled = false;
		foreach (var plaform in GameObject.FindObjectsOfType<MovingPlatform>())
			plaform.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0 ) {
			foreach (var pl in GameObject.FindObjectsOfType<PlayerController>())
				pl.enabled = true;
			foreach (var weapon in GameObject.FindObjectsOfType<BasicWeapon>())
				weapon.enabled = true;
			foreach (var plaform in GameObject.FindObjectsOfType<MovingPlatform>())
				plaform.enabled = true;
			Destroy (gameObject);
		}
	}
}
