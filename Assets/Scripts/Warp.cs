using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    static Warp warp;

    public float warpOffset = 1.0f;
    public Vector2 boxSize = new Vector2(16, 9);

	void Awake ()
    {
        warp = this;
	}
	
    public static void TryTeleport(Transform other)
    {
        warp.TryTeleportLocal(other);
    }

    void TryTeleportLocal(Transform other)
    {
        Vector2 dimensions = boxSize / 2;
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
