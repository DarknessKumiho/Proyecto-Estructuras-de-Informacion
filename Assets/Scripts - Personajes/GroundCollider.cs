using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{

    private PlayerController Player_Zero;

    void Start()
    {
        Player_Zero = GetComponentInParent<PlayerController>();

    }

    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Player_Zero.grounded = true;
        }
        if (col.gameObject.tag == "Platform")
        {
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
            Player_Zero.grounded = false;
        }
    }

}
