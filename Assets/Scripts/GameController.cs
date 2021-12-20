using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private SetPoints setPoints;

    private void Awake()
    {
        if (setPoints == null)
        {
            setPoints = FindObjectOfType<SetPoints>();
        }

        if (cam == null)
        {
            cam = Camera.main;
        }
        setPoints.SetCamera(cam);
    }
}
