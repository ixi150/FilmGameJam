using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {
	GameObject sett;
	PlayerSettings settings;
	public Vector2 player1StartPos;
	public Vector2 player2StartPos;
	List<GameObject> characters;
	// Use this for initialization
	void Start () {
		sett = GameObject.FindGameObjectWithTag ("Settings");
		settings = sett.GetComponent<PlayerSettings> ();
		SpawnPlayer (true, player1StartPos, settings.pick1);
		SpawnPlayer (false, player2StartPos, settings.pick2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnPlayer(bool isPlayerOne, Vector2 playerPos, int characterIndex) {
		Debug.Log ("spawned character " + characterIndex);
		//GameObject play = Instantiate (characters [characterIndex], player1StartPos, Quaternion.identity);
		//play.GetComponent<PlayerController> ().isFirstPlayer = isPlayerOne;

	}
}
