using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class GameController : MonoBehaviour
{
     private SplineComputer splineComputer;
     private Camera cam;
     private SetPoints setPoints;

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

        if (splineComputer == null)
        {
            splineComputer = FindObjectOfType<SplineComputer>();
        }
        setPoints.SetSPlineComputer(splineComputer);
        setPoints.SetCamera(cam);
        
    }
}
