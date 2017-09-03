using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public float damage = 0.1f;
	public float screenShakeOnHit = 0f;
    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().DealDmg(damage);
			CameraShaker.AddShake (screenShakeOnHit, Camera.main.transform);
        }
    }

}
