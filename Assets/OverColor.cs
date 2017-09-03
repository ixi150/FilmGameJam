using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OverColor : MonoBehaviour
{
    Gradient gradientAnimation;
    float timer, duration;
    new SpriteRenderer renderer;
    Material material;

    void Awake ()
    {
        renderer = GetComponent<SpriteRenderer>();
        material = renderer.material;
    }
	
	void Update ()
    {
		if (timer < duration)
        {
            timer = Mathf.MoveTowards(timer, duration, Time.deltaTime);
            material.SetColor("_OverColor", gradientAnimation.Evaluate(timer / duration));
        }
	}

    public void Animate(float duration, Gradient gradient)
    {
        gradientAnimation = gradient;
        this.duration = duration;
        timer = 0;
    }
}
