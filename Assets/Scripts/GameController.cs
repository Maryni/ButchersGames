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
     private SetPlayers setPlayers;
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

        if (setPlayers == null)
        {
            setPlayers = FindObjectOfType<SetPlayers>();
        }

        setPoints.SetPlayersScript(setPlayers);
        setPoints.SetSPlineComputer(splineComputer);
        setPoints.SetCamera(cam);
        
    }
}
