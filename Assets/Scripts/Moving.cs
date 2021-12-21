using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rig.velocity = Vector3.forward * 2f;
    }

    public void StopMove()
    {
        rig.velocity = Vector3.zero;
    }
}
