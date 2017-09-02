using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class timerSelect : MonoBehaviour {
	public float time = 5f;
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			startGame ();
		}


		if(time >= 0f)
		{
			int seconds = Mathf.FloorToInt (time);
			int centSeconds = Mathf.FloorToInt((time - seconds) * 60);
			this.GetComponent<Text> ().text = string.Format ("{0}:{1:00}", seconds, centSeconds);
		}
	}

	void startGame() {
		SceneManager.LoadScene ("scenka");
	}
}
