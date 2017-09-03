using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverColorController : MonoBehaviour
{
    public Gradient gradientAnimation;
    public float duration = .3f;

    OverColor[] overColors;

    private void Start()
    {
        overColors = GetComponentsInChildren<OverColor>();
    }

    public void Animate()
    {
        foreach (var overcolor in overColors)
            overcolor.Animate(duration, gradientAnimation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Animate();
        }   
    } 

}
