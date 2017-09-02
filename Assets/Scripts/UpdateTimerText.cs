using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateTimerText : MonoBehaviour {
	public GameObject timer;
	// Update is called once per frame
	void Start() {

	}
	void Update () {
		if(timer.GetComponent<Timer> ().TimeLeft >= 0f)
		{
			int seconds = Mathf.FloorToInt (timer.GetComponent<Timer> ().TimeLeft);
			int centSeconds = Mathf.FloorToInt((timer.GetComponent<Timer> ().TimeLeft - seconds) * 60);
			this.GetComponent<Text> ().text = string.Format ("{0}:{1:00}", seconds, centSeconds);
	}
}
}
