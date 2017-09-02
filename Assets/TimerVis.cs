using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerVis : MonoBehaviour {
	float startWidth, startHeight;
	public GameObject timer;
	Timer time;
	// Use this for initialization
	void Start () {
		startWidth = this.transform.GetComponent<RectTransform> ().rect.width;
		startHeight = this.transform.GetComponent<RectTransform> ().rect.height;
		time = timer.GetComponent<Timer> ();
	}

	// Update is called once per frame
	void Update () {
		this.transform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (time.TimeLeft / time.startTime * startWidth, startHeight);
		this.transform.localPosition = new Vector2 (time.Indicator / time.dmgThreshold * startWidth/2, this.transform.localPosition.y);

	}
}
