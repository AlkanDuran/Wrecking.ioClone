using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : OnHit, IInteractable
{
    public int magnitude = 3500;
    public float upForce = 10f;

    public void Interact(Transform interactTransform)
    {
        Debug.Log("bum");
        transform.GetComponent<PlayerControl>().isGrounded = false;
        TakeHit(interactTransform, magnitude, upForce);
    }
}
