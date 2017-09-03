using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {
	public Vector2 spawnP1Location;
	public Vector2 spawnP2Location;
	PlayerSettings settings;
	GameObject sett;
	public GameObject[] charPrefabs;
	// Use this for initialization
	void Start () {
		sett = GameObject.FindGameObjectWithTag ("Settings");
		settings = sett.GetComponent<PlayerSettings> ();
		SpawnPlayer (true, spawnP1Location, settings.charChoice1);
		SpawnPlayer (true, spawnP2Location, settings.charChoice2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnPlayer(bool isFirstPlayer, Vector2 location, int characterIndex) {
		/*
		GameObject chars = Instantiate(charPrefabs[characterIndex], location,Quaternion.identity);
		chars.GetComponent<PlayerController> ().isFirstPlayer = isFirstPlayer;
		*/
		Debug.Log (characterIndex + " spawned");
	}
}
