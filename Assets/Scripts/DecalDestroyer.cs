using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalDestroyer : MonoBehaviour
{
    public float lifetime = 5.0f;
	float timer;
    void Start ()
    {

	}
	void Update() {
		timer += Time.deltaTime;
		if (timer >= lifetime) {
			if (GetComponent<PhysicsProjectile> () != null) {
				if (GetComponent<PhysicsProjectile> ().destroyEffect != null) {
					Instantiate (GetComponent<PhysicsProjectile> ().destroyEffect, transform.position, Quaternion.identity);
				}
			}
			Destroy (gameObject);
		}
	}
	
}
