using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Moving>())
        {
            collision.gameObject.GetComponent<Moving>().StopMove();
        }
    }
}
