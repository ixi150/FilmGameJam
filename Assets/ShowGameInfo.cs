using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowGameInfo : MonoBehaviour {
	public GameObject player1score, player2score, lastWon;

	GameObject info;
	PlayerSettings settings;
	void Start() {
		info = GameObject.FindGameObjectWithTag ("Settings");
		settings = info.GetComponent<PlayerSettings> ();
		player1score.GetComponent<Text> ().text = "" + settings.score1;
		player2score.GetComponent<Text> ().text = "" + settings.score2;
		if (settings.lastWon != 0)
			lastWon.GetComponent<Text> ().text = "Last won: Player " + settings.lastWon;

		}
	}

