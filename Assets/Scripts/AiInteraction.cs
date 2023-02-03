using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiInteraction : OnHit, IInteractable
{
    public int magnitude = 3500;
    public float upForce = 10f;
    public EnemyAi enemyAi;
    public void Interact(Transform interactTransform)
    {
        //enemyAi.hitDeactivate = true;
        var navMesh= GetComponent<NavMeshAgent>();
        //navMesh.ResetPath();
        navMesh.enabled = false;
        
        
        TakeHit(interactTransform,magnitude,upForce);
    }
}
