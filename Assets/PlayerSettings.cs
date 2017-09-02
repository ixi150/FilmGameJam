using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {
	public int score1, score2, lastWon;
	public int pick1, pick2;
	private static PlayerSettings settings;

	// Use this for initialization
	void Awake () {
		if (settings == null) {
		Object.DontDestroyOnLoad (this.gameObject);
			settings = this;
		} else
			Destroy (gameObject);

	}

}
