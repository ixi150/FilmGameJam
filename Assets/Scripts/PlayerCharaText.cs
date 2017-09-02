using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCharaText : MonoBehaviour {
	public bool isPlayerOne;
	public GameObject choice;
	ChangeCharacter chan;
	// Use this for initialization
	void Start () {
		chan = choice.GetComponent<ChangeCharacter> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerOne) {
			this.GetComponent<Text> ().text = "" + chan.players [0].currChoice;
		}
		else this.GetComponent<Text> ().text = "" + chan.players[1].currChoice;
	}
}
