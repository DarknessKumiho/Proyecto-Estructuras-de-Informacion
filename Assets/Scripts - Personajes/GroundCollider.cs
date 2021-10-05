using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{

    private PlayerController Player_Zero;
    private Rigidbody2D rb2d;

    void Start()
    {
        Player_Zero = GetComponentInParent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            Player_Zero.transform.parent = col.transform;
            Player_Zero.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Player_Zero.grounded = true;
        }
        if (col.gameObject.tag == "Platform")
        {
            Player_Zero.transform.parent = col.transform;
            Player_Zero.grounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Player_Zero.grounded = false;
        }
        if (col.gameObject.tag == "Platform")
        {
            Player_Zero.transform.parent = null;
            Player_Zero.grounded = false;
        }
    }

}
