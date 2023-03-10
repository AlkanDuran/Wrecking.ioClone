using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour 
{
    public NavMeshAgent agent;
    public float range; 

    public Transform centrePoint;
    

    public bool enemyDetected;
    //public bool hitDeactivate;
    public float height;
    
    public bool isGrounded = true;
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        //Grounded();
        if (agent.enabled) SetDestination();
        //if(enemyDetected) TimerStart();
    }

    public void SetDestination()
    {
        if(agent.remainingDistance <= agent.stoppingDistance) 
        { 
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) 
            {
                agent.SetDestination(point);
            }
        } 
    }
    
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        { 
            
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public void TimerStart()
    {
        StartCoroutine(RotateAroundCloser());
        //agent.ResetPath();
        RotateAround();
        
    }
    
    private IEnumerator RotateAroundCloser()
    {
        yield return new WaitForSeconds(3f);
        enemyDetected = false;
    }
    
    private void RotateAround()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 250, transform.rotation.z) * Time.deltaTime);
    }
    
    void Grounded()
    {
        if (transform.position.y > height)
        {
            isGrounded = false;
        }

        if (!isGrounded && transform.position.y < height)
        {
            isGrounded = true;
            agent.enabled = true;
            //hitDeactivate = false;
        }
    }
    
}