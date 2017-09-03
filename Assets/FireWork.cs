using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour {
	public GameObject projectile;
	public float liveTime;
	float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= liveTime) {
			int j = Random.Range (10, 30);
			Debug.Log (j);
			for (int i = 0; i < j; i++) {
				GameObject obj = Instantiate (projectile, this.transform.position, Quaternion.identity);
				//obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)));
			}
			Destroy (gameObject);

		}
	}
}
