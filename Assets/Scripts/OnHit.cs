using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnHit : MonoBehaviour
{
   protected void TakeHit(Transform interactTransform,int magnitude,float upForce)
   {
      var force = transform.position - interactTransform.transform.position;
      force.Normalize();
      var rb = GetComponent<Rigidbody>();
      rb.AddForce(force * magnitude);
      rb.AddForce(Vector3.up*upForce);

   }
}
