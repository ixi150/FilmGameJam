using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public float startTime = 20f;
	float timeLeft;

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

    public RectTransform guiHolder;

	void Start () {
		timeLeft = startTime;
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

		SceneManager.LoadScene (Application.loadedLevelName);
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
        CameraShaker.AddShake(overKill, guiHolder);

	}

		void PlayerWon(Players playerWon) {  ///WIP, will be in a different obj
		switch (playerWon) {
		case Players.None:
			Debug.Log ("No one won! GameOver!");
			break;
		case Players.Player1:
			Debug.Log ("Player 1 won!");
			break;
		case Players.Player2:
			Debug.Log ("Player 2 won!");
			break;
		}
	}
}
