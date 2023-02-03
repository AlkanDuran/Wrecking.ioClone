using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteract : MonoBehaviour,IInteractable
{

    public void Interact(Transform interactTransform)
    {
        interactTransform.GetComponent<PowerUp>().powerUpEnabled = true;
        this.gameObject.SetActive(false);
    }
}
