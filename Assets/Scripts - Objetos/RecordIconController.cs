using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordIconController : MonoBehaviour
{
    public GameObject ScoreBoard;

    public bool isActive = false;

    public float speed;

    private Vector3 initialPosition;
    private Vector3 activePosition;

    void Start()
    {
        initialPosition = ScoreBoard.transform.position;
        activePosition = initialPosition;
        activePosition.x = activePosition.x + 650;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isActive == false)
        {
            float fixedSpeed = speed * Time.deltaTime;
            ScoreBoard.transform.position = Vector3.MoveTowards(ScoreBoard.transform.position, initialPosition, fixedSpeed);
        }

        if (isActive == true)
        {
            float fixedSpeed = speed * Time.deltaTime;
            ScoreBoard.transform.position = Vector3.MoveTowards(ScoreBoard.transform.position, activePosition, fixedSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isActive = false;
        }
    }

}
