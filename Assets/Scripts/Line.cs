using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer line;
    public Transform firstPos;
    public Transform lastPos;

    private void Start()
    {
        line.positionCount = 2;
    }

    private void Update()
    {
        line.SetPosition(0,firstPos.position);
        line.SetPosition(1, lastPos.position);
    }
}
