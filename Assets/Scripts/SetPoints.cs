using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SetPoints : MonoBehaviour
{
    [SerializeField] private SplineComputer splineComputer;
    [SerializeField] private List<Vector3> pointsList;
    [SerializeField] private Vector3 mousePos;
    private bool mousePressed;
    private Camera cam;
    private SplinePoint[] points;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePressed = true;
            mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        AddPoints();
        if (Input.GetMouseButtonUp(0))
        {
            SetPointsToNodes();
        }
    }

    public void SetCamera(Camera camera)
    {
        cam = camera;
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
        for (int i = 0; i < pointsList.Count; i++)
        {
            points[i].position = pointsList[i];
        }
        splineComputer.SetPoints(points);
    }
}
