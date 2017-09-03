using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProjectile : MonoBehaviour
{
    public float lifetime = 5.0f;
    public GameObject destroyEffect;
    public float dmg = 1f;
    float timer, extraTimer;
    public int lives = 1;
    public bool destroyOnContact = true;
    public float addShakeOnDestroy = 1.5f;
    public float addShakeOnPlayerHit = 2.0f;
    PlayerController owner;
	void Start()
    {
        timer = lifetime;

    }

    void Update()
    {
        timer -= Time.deltaTime;
        extraTimer += Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent<PlayerController>();
        if (player == owner && lifetime - timer < 0.5f)
            return;

        if (player)
        {
            player.DealDmg(dmg);
        }

        if (extraTimer >= 0.5f && destroyOnContact)
        {
			Debug.Log (lives);            
			lives--;
            extraTimer = 0;
        }
        if (lives <= 0)
        {
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }


    public void SetOwner(PlayerController control)
    {
        owner = control;
    }
}