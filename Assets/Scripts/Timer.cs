using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
	public float startTime = 20f;
	float timeLeft;
	GameObject sett;
	PlayerSettings settings;

	public float TimeLeft {
		get {
			return timeLeft;
		}
	}
	public bool TestIndicatorRight = false;
	public bool TestIndicatorLeft = false;
	float indicator = 0f;

	public float Indicator {
		get {
			return indicator;
		}
	}

	public float dmgThreshold = 100f;
	public enum Players {None, Player1, Player2};
	// Use this for initialization

	void Start () {
		sett = GameObject.FindGameObjectWithTag ("Settings");
		timeLeft = startTime;
		settings = sett.GetComponent<PlayerSettings> ();
	}
	
	// Update is called once per frame
	void Update () {
		DecreaseTime ();
		if (timeLeft < 0)
			timeLeft = 0;

//FOR TESTING ONLY
		if (TestIndicatorLeft == true) {
			moveIndicator (false, 5f);
			TestIndicatorLeft = false;
		}
		if (TestIndicatorRight == true) {
			moveIndicator (true, 5f);
			TestIndicatorRight = false;
		}
	}

	void DecreaseTime() {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0f)
			DecideWinner();
	}

	void DecideWinner() {
		if (indicator < 0)
			PlayerWon (Players.Player1);
		else if (indicator > 0)
			PlayerWon (Players.Player2);
		else
			PlayerWon (Players.None);

		SceneManager.LoadScene ("Select");
		}

	public void moveIndicator(bool isRight, float dmg) {
		if (isRight)
			indicator += dmg;
		else
			indicator -= dmg;
		
		if (Mathf.Abs(indicator) + timeLeft/startTime * dmgThreshold > dmgThreshold) {
			dealWithTreshold ();
		}
		if (indicator > dmgThreshold)
			indicator = dmgThreshold;
		else if (indicator < -dmgThreshold)
			indicator = -dmgThreshold;
	}

	void dealWithTreshold() {
		float overKill = Mathf.Abs(indicator) + timeLeft/startTime * dmgThreshold - dmgThreshold;
		timeLeft -= overKill;
		indicator = Mathf.Abs (indicator) / indicator * (dmgThreshold - timeLeft/startTime*dmgThreshold);

	}

		void PlayerWon(Players playerWon) {  ///WIP, will be in a different obj
		switch (playerWon) {
		case Players.None:
			Debug.Log ("No one won! GameOver!");
			break;
		case Players.Player1:
			Debug.Log ("Player 1 won!");
			settings.score1++;
			settings.lastWon = 1;
			break;
		case Players.Player2:
			Debug.Log ("Player 2 won!");
			settings.score2++;
			settings.lastWon = 2;
			break;
		}
	}
}
