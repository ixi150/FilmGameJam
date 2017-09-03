using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    static CameraShaker cameraShaker;

    public float shakeSpeed = 10.0f;
    public float shakeDecay = 5.0f;

    float currentAmplitude;

    Transform target;

    void Start ()
    {
        cameraShaker = this;
        target = transform;
	}
	
	void Update ()
    {
        Shakin(target);
    }

    void Shakin(Transform target)
    {
        if (currentAmplitude > 0)
        {
            currentAmplitude = Mathf.MoveTowards(currentAmplitude, 0.0f, Time.deltaTime * shakeDecay);

            float bx = (Mathf.PerlinNoise(0, Time.time * shakeSpeed) - 0.5f);
            float by = (Mathf.PerlinNoise(0, (Time.time * shakeSpeed) + 100)) - 0.5f;

            bx *= currentAmplitude;
            by *= currentAmplitude;

            target.localPosition = new Vector3(bx, by, -1);
        }
    }

    public static void AddShake(float amplitude, Transform target)
    {
        cameraShaker.SetAmplitude(amplitude, target);
    }

    void SetAmplitude(float amplitude, Transform target)
    {
        currentAmplitude = amplitude;
    }
}
