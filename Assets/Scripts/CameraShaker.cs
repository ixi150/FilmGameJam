using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    static CameraShaker cameraShaker;

    public float shakeSpeed = 10.0f;
    public float shakeDecay = 5.0f;

    float currentAmplitude;

    void Start ()
    {
        cameraShaker = this;
	}
	
	void Update ()
    {
        if (currentAmplitude > 0)
        {
            currentAmplitude = Mathf.MoveTowards(currentAmplitude, 0.0f, Time.deltaTime * shakeDecay);

            float bx = (Mathf.PerlinNoise(0, Time.time * shakeSpeed) - 0.5f);
            float by = (Mathf.PerlinNoise(0, (Time.time * shakeSpeed) + 100)) - 0.5f;

            bx *= currentAmplitude;
            by *= currentAmplitude;

            transform.localPosition = new Vector3(bx, by, -1);
        }
    }

    public static void AddShake(float amplitude)
    {
        cameraShaker.SetAmplitude(amplitude);
    }

    void SetAmplitude(float amplitude)
    {
        currentAmplitude = amplitude;
    }

}
