using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider col) {
        if(col.TryGetComponent<IInteractable>(out IInteractable interactable)){
            interactable.Interact(transform);
        }
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)){
            interactable.Interact(transform);
        }
    }
}