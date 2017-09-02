using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
public class ChangeCharacter : MonoBehaviour {
	public class PlayerChoice{
		public bool selected;
		public GameObject obj;
		public int currChoice;
		public bool axisReturned;
	};
	bool start = false;
	GameObject obj;
	bool playerOneSelected, playerTwoSelected;
	public GameObject playerObj1, playerObj2;
	public List<GameObject> charaObj;
	public List<PlayerChoice> players;
	public float chooseThreshold;

	public string player1axis, player1choose, player1cancel;
	public string player2axis, player2choose, player2cancel;

	public string[] joysticks;

	public GameObject rdy, canvas;

	void Awake() {
		players = new List<PlayerChoice> ();
	
		players.Add (new PlayerChoice () {
			selected = false,
			obj = playerObj1,
			currChoice = 1,
			axisReturned = false
		}
		);
		players.Add (new PlayerChoice () {
			selected = false,
			obj = playerObj2,
			currChoice = 4,
			axisReturned = false
		}
			
		);
	}


	void Update() {
		positionPlayer (players[0]);
		positionPlayer (players[1]);
		InputPlayer (true, player1axis, player1choose, player1cancel, 0.5f);
		InputPlayer (false,player2axis, player2choose, player2cancel, 0.5f);
		moveChecks ();

		joysticks = Input.GetJoystickNames ();
	}

	void positionPlayer(PlayerChoice player) {
		player.obj.transform.localPosition = charaObj[player.currChoice - 1].transform.localPosition;
	}



	void InputPlayer(bool isPlayerOne, string axis, string choose, string cancel, float chooseThreshold) {
		int playerNumber = 1;
		if (isPlayerOne)
			playerNumber = 0;

		if (players [playerNumber].selected == false) {
			if(players[playerNumber].axisReturned) {
				if (Input.GetAxis (axis) > chooseThreshold) {
					players [playerNumber].currChoice++;
					players [playerNumber].axisReturned = false;
				} else if (Input.GetAxis (axis) < -chooseThreshold) {
					players [playerNumber].currChoice--;
					players [playerNumber].axisReturned = false;
				}
			} 
			if (Mathf.Abs (Input.GetAxis (axis)) <= chooseThreshold)
				players [playerNumber].axisReturned = true;

			if (Input.GetKeyDown(choose)) {
				players [playerNumber].selected = true;
				Debug.Log (choose);
			}
		}
		if(Input.GetKeyDown(cancel)) {
				players [playerNumber].selected = false;
		}

		}

	void moveChecks() {
		for (int i = 0; i < 2; i++) {
			if (players[i].currChoice > 4)
				players[i].currChoice = 1;

			if (players[i].currChoice < 1)
				players[i].currChoice = 4;
		}
		if (players [0].selected && players [1].selected && start == false) {
			startGame ();
			start = true;
		} else if (start && (players [0].selected == false || players [1].selected == false)) {
			start = false;
			Destroy (obj);
		}
	}
	void startGame() {
		obj = Instantiate (rdy, rdy.transform.position, rdy.transform.rotation);
		obj.transform.SetParent (canvas.transform, false);
	}
}
