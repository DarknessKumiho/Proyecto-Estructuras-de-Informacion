using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlagController : MonoBehaviour
{
    public ChronometerController Cronometro;

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
            Cronometro.isPaused = false;
        }
    }

}
