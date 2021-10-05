using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject follow;

    public Vector2 minCamPos;
    public Vector2 maxCamPos;

    public Vector2 minPosMenu;
    public Vector2 maxPosMenu;

    public Vector2 minPosGame;
    public Vector2 maxPosGame;

    public float smoothTime;

    private Vector2 smoothVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref smoothVelocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref smoothVelocity.y, smoothTime);

        transform.position = new Vector3
            (
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z
            );
    }

}
