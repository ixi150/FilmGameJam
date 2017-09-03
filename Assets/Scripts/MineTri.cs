using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTri : MonoBehaviour
{
    public float dmg = 15;
    public float gracePeriod = 1f;
    public GameObject destroyEffect;
    float timer;
	public float destroyAfterTime = 10f;

    void Update()
    {
        timer += Time.deltaTime;
		if (timer >= destroyAfterTime) {
			Destroy(transform.parent.gameObject);
			Destroy(gameObject);
		}
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (timer >= gracePeriod)
        {
            if (col.GetComponent<PlayerController>())
            {
                col.GetComponent<PlayerController>().DealDmg(dmg);
                if (destroyEffect)
                    Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
