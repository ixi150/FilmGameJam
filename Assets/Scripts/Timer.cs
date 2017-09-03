using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public float startTime = 20f;
	bool timeStart = false;
	bool endGame = false;
	float timeLeft;
	public GameObject endText, whiteScreen;
	PlayerSettings settings;
	GameObject sett;
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
	public float fadeInSpeed = .4f;

	void Start () {
		timeLeft = startTime;
		sett = GameObject.FindGameObjectWithTag ("Settings");
		settings = sett.GetComponent<PlayerSettings> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(timeStart == false) {
			if (GameObject.FindObjectOfType<StartTimer> () == null)
				timeStart = true;
			}

		if (timeStart && endGame == false)
			DecreaseTime ();

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
			PlayerWon (Players.Player2);
		else if (indicator > 0)
			PlayerWon (Players.Player1);
		else
			PlayerWon (Players.None);

		SpawnEndFeels ();
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
			endText.GetComponent<Text>().text = "REMIZ!";
			break;
		case Players.Player1:
			endText.GetComponent<Text> ().text = "Wygrywa gracz nr 1!";
			settings.player1score++;
			settings.lastPlayerWon = 1;
			break;
		case Players.Player2:
			endText.GetComponent<Text>().text = "Wygrywa gracz nr 2!";
			settings.player2score++;
			settings.lastPlayerWon = 2;
			break;
		}
	}

	void SpawnEndFeels() {
		endGame = true;
		StartCoroutine (SpawningEnd());
	}

	IEnumerator SpawningEnd() {
		float timer = 0f;

		foreach (var player in GameObject.FindObjectsOfType<PlayerController>())
			player.enabled = false;
		
		while(true) {
			//text appears
			endText.GetComponent<Text>().color = new Color(endText.GetComponent<Text>().color.r, endText.GetComponent<Text>().color.g, endText.GetComponent<Text>().color.b, endText.GetComponent<Text>().color.a + 5/255f);

			//time slows down
			Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.05f, Time.unscaledDeltaTime);

			//zoom
            foreach (var camera in  Camera.main.GetComponentsInChildren<Camera> ())
			camera.orthographicSize = Mathf.MoveTowards (camera.orthographicSize, 2, Time.unscaledDeltaTime/2);

			timer += Time.unscaledDeltaTime;

			if (timer >= 4f) {
				var image = whiteScreen.GetComponent<Image> ();
				var color = image.color;
				color.a += Time.unscaledDeltaTime * fadeInSpeed;
				image.color = color;

				if (whiteScreen.GetComponent<Image> ().color.a >= 1) {
					Time.timeScale = 1;
					SceneManager.LoadScene ("Select");
					break;
				}
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
