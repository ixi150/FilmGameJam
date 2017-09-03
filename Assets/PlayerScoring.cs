using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoring : MonoBehaviour {
	public GameObject p1score, p2score, last;
	PlayerSettings settings;
	GameObject sett;
	// Use this for initialization
	void Start () {
		sett = GameObject.FindGameObjectWithTag ("Settings");
		settings = sett.GetComponent<PlayerSettings> ();
		p1score.GetComponent<Text> ().text = "" + settings.player1score;
		p2score.GetComponent<Text> ().text = "" + settings.player2score;
		if (settings.lastPlayerWon != 0)
			last.GetComponent<Text> ().text = "Ostatnio wygroł chop " + settings.lastPlayerWon;
		else
			last.GetComponent<Text> ().text = "";

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
