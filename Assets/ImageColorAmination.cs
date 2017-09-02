using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorAmination : MonoBehaviour 
{
	public Gradient gradientAnimation;
	public float duration=1;

	 Image image;

	void Awake()
	{
		image = GetComponent<Image> ();
		StartCoroutine (StartAmination ());
	}

	IEnumerator StartAmination()
	{
		float timer = 0;
		do 
		{
			timer += Time.deltaTime;
			image.color = gradientAnimation.Evaluate(timer/duration);
			yield return new WaitForEndOfFrame ();
		} 
		while (timer < duration);
		Destroy (this);
	}
}
