using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProjectile : MonoBehaviour
{
    public float lifetime = 5.0f;
    public GameObject destroyEffect;
	public float dmg = 1f;
    float timer;
	PlayerController owner;
	void Start ()
    {
        timer = lifetime;
	}
	
	void Update ()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
		var player = col.GetComponent<PlayerController> ();
		if (player == owner && lifetime - timer < 0.5f)
			return;

        if (col.transform.tag != "Warp")
        {
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
			if (player) {
				player.DealDmg (dmg);
			}
            Destroy(gameObject);
        }
    }

	public void SetOwner(PlayerController control) {
		owner = control;
	}
}
