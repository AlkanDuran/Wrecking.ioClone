using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool rotationStart,powerUpEnabled;
    
    public GameObject powerUpBall;
    public Collider wreckingCol;
    public MeshRenderer wreckingMesh;
    public LineRenderer wreckingLine;
    public Transform pivotPoint;
    public int rotateAmount;
    private void Update()
    {
        if (powerUpEnabled)
        {
            if (!rotationStart)
            {
                ActivatePowerUpBall();
                
            }
            
            pivotPoint.Rotate(pivotPoint.up*rotateAmount,Space.Self);
        }
    }

    public void ActivatePowerUpBall()
    {
        StartCoroutine(PowerUpTimer());
        wreckingCol.enabled = false;
        wreckingMesh.enabled = false;
        wreckingLine.enabled = false;
        powerUpBall.SetActive(true);
        rotationStart = true;
    }
    
    public void DeactivatePowerUpBall()
    {
        powerUpEnabled = false;
        powerUpBall.SetActive(false);
        wreckingCol.enabled = true;
        wreckingMesh.enabled = true;
        wreckingLine.enabled = true;
        rotationStart = false;
    }

    private IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(5);
        DeactivatePowerUpBall();
    }
}
