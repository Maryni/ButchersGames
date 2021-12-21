using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

public class SetPoints : MonoBehaviour
{
    [SerializeField] private float modPoint;
    [SerializeField] private List<Vector3> pointsList;
    [SerializeField] private Vector3 mousePos;
    private SetPlayers setPlayers;
    private SplineComputer splineComputer;
    private bool mousePressed;
    private Camera cam;
    private SplinePoint[] points;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointsList.RemoveRange(0,pointsList.Count);
            mousePressed = true;
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        AddPoints();
        if (Input.GetMouseButtonUp(0))
        {
            RemoveOldPoints();
            SetPointsToNodes();
            mousePressed = false;
        }
    }

    public void SetCamera(Camera camera)
    {
        cam = camera;
    }

    public void SetSPlineComputer(SplineComputer splineComputer)
    {
        this.splineComputer = splineComputer;
    }

    public void SetPlayersScript(SetPlayers setPlayers)
    {
        this.setPlayers = setPlayers;
    }

    private void AddPoints()
    {
        if (mousePressed)
        {
            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);
            }
        }
    }

    private void SetPointsToNodes()
    {
        points = new SplinePoint[pointsList.Count];
        SplineComputer computer = FindObjectOfType<SplineComputer>();
        for (int i = 0; i < pointsList.Count; i++)
        {
            points[i].position = new Vector3((pointsList[i].x * modPoint)+ computer.transform.position.x,0f,(pointsList[i].y * modPoint)+computer.transform.position.z);
            for(int j = 0;j < setPlayers.PlayersList.Count; j++)
            {
                setPlayers.ActivatePlayer(j);
                setPlayers.SetPositionPlayerOnPoint(points[i].position,j);
                
     
            }
            Debug.Log($"point[{i}] = {points[i].position} | after");
            
        }
        splineComputer.SetPoints(points);
    }

    private void RemoveOldPoints()
    {
        splineComputer.SetPoints(new SplinePoint[0]);
    }
}
