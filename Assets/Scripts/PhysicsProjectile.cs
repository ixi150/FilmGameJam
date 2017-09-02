﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProjectile : MonoBehaviour
{
    public bool destroyOnContact = true;
    public GameObject destroyEffect;
    public float addShakeOnDestroy = 1.5f;
    public float addShakeOnPlayerHit = 5.0f;

	public float dmg = 1f;
	PlayerController owner;
	void Start ()
    {
	}
	

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag != "Projectile")
        {
            var player = col.GetComponent<PlayerController>();
            if (player == owner)
                return;

            if (player)
            {
                player.DealDmg(dmg);
                DestroyThisAndAddShake(addShakeOnPlayerHit);
            }
            else
            {
                DestroyThisAndAddShake(addShakeOnDestroy);
            }           
        }

    }

    void DestroyThisAndAddShake(float shake)
    {
        if (destroyOnContact)
        {
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
        }
        CameraShaker.AddShake(shake);
        Destroy(gameObject);
    }

	public void SetOwner(PlayerController control) {
		owner = control;
	}
}
