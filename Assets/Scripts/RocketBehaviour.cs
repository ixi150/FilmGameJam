using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public Color startColor = Color.cyan;
    public Color endColor = Color.red;

    public float lifetime = 10.0f;
    public Transform centerOfMass;

    float timer;
    Rigidbody2D rb;
    new SpriteRenderer renderer;

	void Start ()
    {
        timer = lifetime;
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }
	
	void Update ()
    {
        if (centerOfMass) rb.centerOfMass = centerOfMass.localPosition;
        timer -= Time.deltaTime;
        renderer.color = Color.Lerp(startColor, endColor, 1 - timer / lifetime);

        if (timer <= 0)
        {
            foreach (var rb in GetComponentsInChildren<Rigidbody2D>())
            {
                rb.gravityScale = 1;
            }
            foreach (var particle in GetComponentsInChildren<ParticleSystem>())
            {
                var emissionModule = particle.emission;
                emissionModule.enabled = false;
            }
            enabled = false;
        }
	}
}
