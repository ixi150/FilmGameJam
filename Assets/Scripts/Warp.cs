using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    static Warp warp;

    public float warpOffset = 1.0f;
    new BoxCollider2D collider;

	void Awake ()
    {
        warp = this;
        collider = GetComponent<BoxCollider2D>();
	}
	
    public static void TryTeleport(Transform other)
    {
        warp.TryTeleportLocal(other);
    }

    void TryTeleportLocal(Transform other)
    {
        Vector2 dimensions = collider.size / 2;
        Vector2 warpPosition = other.position;

        if(other.position.x < -dimensions.x)
        {
            warpPosition.x = dimensions.x - warpOffset;        
        }
        else if(other.position.x > dimensions.x)
        {
            warpPosition.x = -dimensions.x + warpOffset;
        }

        if (other.position.y < -dimensions.y)
        {
            warpPosition.y = dimensions.y - warpOffset;
        }
        else if (other.position.y > dimensions.y)
        {
            warpPosition.y = -dimensions.y + warpOffset;
        }
        other.position = warpPosition;
    }
}
