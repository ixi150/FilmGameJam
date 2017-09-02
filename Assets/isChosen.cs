using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class isChosen : MonoBehaviour {
	public bool isPlayerOne;
	public GameObject choice;
	ChangeCharacter chan;
	// Use this for initialization
	void Start () {
		chan = choice.GetComponent<ChangeCharacter> ();
	}

	// Update is called once per frame
	void Update () {
		int i = 1;
		if (isPlayerOne)
			i = 0;

		if (chan.players [i].selected) {
			transform.GetComponent<Text> ().text = "Selected!";
		}
		else transform.GetComponent<Text> ().text = "";

	}
}
