using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {

	public float spawnEverySeconds = 4f;
	public float offset = 1f;
	float timer;
	public float minx, maxx;
	float timeTillNext;
	public GameObject[] spawn;
	// Use this for initialization
	void Start () {
		timeTillNext = Random.Range (spawnEverySeconds - offset, spawnEverySeconds + offset);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeTillNext) {
			timeTillNext = Random.Range (spawnEverySeconds - offset, spawnEverySeconds + offset);
			timer = 0;
			SpawnItem ();
		}
	}

	void SpawnItem() {
		GameObject spawned = Instantiate (spawn [Random.Range (0, spawn.GetLength(0))], new Vector3 (Random.Range (minx, maxx), 4f), Quaternion.identity);

	}
}
