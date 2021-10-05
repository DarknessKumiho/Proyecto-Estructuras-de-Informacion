using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffController : MonoBehaviour
{
    public PlayerController Player_Zero;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Jugador detectado !");
            Player_Zero.max_Speed += 0.5f;
            Player_Zero.speed_x += 1f;

            Destroy(gameObject);
        }
    }

}
