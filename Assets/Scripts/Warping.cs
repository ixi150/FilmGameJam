using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warping : MonoBehaviour
{
	void FixedUpdate()
    {
        Warp.TryTeleport(transform);
    }
}
