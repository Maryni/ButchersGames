using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

public class SetPoints : MonoBehaviour
{
    
    [SerializeField] private List<Vector3> pointsList;
    [SerializeField] private Vector3 mousePos;
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

    private void AddPoints()
    {
        Debug.Log($"mousePos = {mousePos}");
        Debug.Log("outside|outside");
        if (mousePressed)
        {
            Debug.Log("inside|outside");
            if (!pointsList.Contains(mousePos))
            {
                Debug.Log("inside|inside");
                pointsList.Add(mousePos);
            }
        }
    }

    private void SetPointsToNodes()
    {
        points = new SplinePoint[pointsList.Count];
        for (int i = 0; i < pointsList.Count; i++)
        {
            points[i].position = new Vector3(pointsList[i].x,0f,pointsList[i].y);
        }
        splineComputer.SetPoints(points);
        splineComputer.GetPoints();
    }

    private void RemoveOldPoints()
    {
        splineComputer.SetPoints(new SplinePoint[0]);
    }
}
