using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BasicWeapon : MonoBehaviour
{
    public float fireRate = 5.0f;
    public float spread = 3.0f;
    public int shootAmount = 1;

    public Transform muzzle;
    public Rigidbody2D projectile;
    public float shootForce = 10.0f;

    public float cameraShakeAmplitude = 2.0f;

    float timer;

    public AudioClip shootClip;
    AudioSource audioSource;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0.5f;
        audioSource.clip = shootClip;
	}
	
	void Update ()
    {
        if (fireRate > 0)
        {
            if (Input.GetButton("Fire1") && timer <= 0)
            {
                Shoot();
            }
            timer -= Time.deltaTime;
        }
	}

    void Shoot()
    {
        for (int i = 0; i < shootAmount; i++)
        {
            muzzle.localRotation = Quaternion.Euler(0, 0, Random.Range(-spread, spread));
            Rigidbody2D instance = Instantiate(projectile, muzzle.position, muzzle.rotation);
            instance.AddForce(muzzle.right * shootForce, ForceMode2D.Impulse);
        }

        CameraShaker.AddShake(cameraShakeAmplitude);
        audioSource.Play();
        timer = 1 / fireRate;
    }
}
