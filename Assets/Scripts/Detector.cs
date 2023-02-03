using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour, IInteractable
{
    public EnemyAi enemyAi;
    public void Interact(Transform transform)
    {
        enemyAi.enemyDetected = true;
        enemyAi.TimerStart();
        Debug.Log("rotate");
        
    }

}
