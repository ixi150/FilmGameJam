using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCharaText : MonoBehaviour {
	public bool isPlayerOne;
	public GameObject choice;
	ChangeCharacter chan;
	string text;
	// Use this for initialization
	void Start () {
		chan = choice.GetComponent<ChangeCharacter> ();
	}
	
	// Update is called once per frame
	void Update () {
		int curr = 0;
		if (isPlayerOne) {
			curr = chan.players [0].currChoice;
		} else
			curr = chan.players [1].currChoice;


		switch (curr) {
		case 1:
			text = "Karbonowy\nJanusz";
			break;
		case 2:
			text = "Ebonitowy\nKrzyżtoff";
			break;
		case 3:
			text = "Rakietowa\nAstygmatka";
			break;
		case 4:
			text = "Sister";
			break;
			
		}
		this.GetComponent<Text> ().text = text;
	}
}
