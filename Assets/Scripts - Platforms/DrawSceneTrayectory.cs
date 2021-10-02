using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSceneTrayectory : MonoBehaviour
{

    public Transform from;
    public Transform to;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(from.position, to.position);
        Gizmos.DrawSphere(from.position, 0.10f);
        Gizmos.DrawSphere(to.position, 0.10f);
    }

}
