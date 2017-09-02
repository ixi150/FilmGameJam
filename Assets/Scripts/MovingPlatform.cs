using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 motion;
    public float moveSpeed = 2.0f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.position += new Vector3(motion.x, motion.y, 0) * Time.deltaTime * moveSpeed;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
