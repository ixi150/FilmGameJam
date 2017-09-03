using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showSpecial : MonoBehaviour {
	public Sprite[] charSprites;
	public bool isPlayerOne;
	PlayerSettings settings;
	GameObject sett;
	// Use this for initialization
	void Start () {
		sett = GameObject.FindGameObjectWithTag ("Settings");
		settings = sett.GetComponent<PlayerSettings> ();
	}
	void Update() {
		if (isPlayerOne)
			GetComponent<Image> ().sprite = charSprites [settings.charChoice1-1];
		else GetComponent<Image> ().sprite = charSprites [settings.charChoice2-1];
			
	}
}
