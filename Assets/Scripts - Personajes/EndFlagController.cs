using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFlagController : MonoBehaviour
{
    public PlayerController Player_Zero;
    public ChronometerController Cronometro;
    public CameraMovement Camara;

    public Vector3 TeleportPoint;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Cronometro.isPaused = true;
            Cronometro.ResetWatch();

            Player_Zero.transform.position = TeleportPoint;

            Camara.minCamPos = Camara.minPosMenu;
            Camara.maxCamPos = Camara.maxPosMenu;

        }
    }

}
