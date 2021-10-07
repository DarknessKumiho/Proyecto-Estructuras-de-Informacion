using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIconController : MonoBehaviour
{
    public Vector2 TeleportPoint;

    public PlayerController Player_Zero;
    public CameraMovement GameCamera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameCamera.minCamPos = GameCamera.minPosMenu;
            GameCamera.maxCamPos = GameCamera.maxPosMenu;

            Player_Zero.transform.position = TeleportPoint;
        }
    }
}
