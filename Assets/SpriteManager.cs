using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteManager : MonoBehaviour {
	public bool isPlayerOne = false;
	public GameObject choice;
	ChangeCharacter chan;
	public Sprite[] sprites;
	string text;
	// Use this for initialization
	void Start () {
		chan = choice.GetComponent<ChangeCharacter> ();
		changeSprite ();
	}

	// Update is called once per frame
	void Update () {
		changeSprite ();
	}
	void changeSprite() {
		int curr = 0;
		if (isPlayerOne) {
			curr = chan.players [0].currChoice;
		} else
			curr = chan.players [1].currChoice;

		this.GetComponent<Image> ().sprite = sprites [curr - 1];
	}
}
