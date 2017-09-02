using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class updateStartTimer : MonoBehaviour {
	public GameObject timer;
	// Use this for initialization
	
	void Update () {
		if(timer.GetComponent<StartTimer> ().Timer >= 0f)
		{
			int seconds = Mathf.FloorToInt (timer.GetComponent<StartTimer> ().Timer);
			int centSeconds = Mathf.FloorToInt((timer.GetComponent<StartTimer> ().Timer - seconds) * 60);
			this.GetComponent<Text> ().text = string.Format ("{0}:{1:00}", seconds, centSeconds);
			if (seconds <= 0 && centSeconds <= 0f) {
				Destroy (transform.parent.gameObject);
				Destroy (gameObject);
			}

		}
	}
}
