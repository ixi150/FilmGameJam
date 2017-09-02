using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePlayerChoices : MonoBehaviour {

	public int player1char, player2char;
	public GameObject choice;
	void Awake() {
		Object.DontDestroyOnLoad (this.gameObject);
	}
	void Update() {
		player1char = choice.GetComponent<ChangeCharacter> ().players [0].currChoice;
		player2char = choice.GetComponent<ChangeCharacter> ().players [1].currChoice;
	}
}
