using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {
	public int charChoice1, charChoice2, player1score, player2score, lastPlayerWon;
	static PlayerSettings settings;
	// Use this for initialization
	void Start () {
		if (settings == null) {
			settings = this;
			Object.DontDestroyOnLoad (gameObject);
		} else
			Destroy (gameObject);
	}


}
