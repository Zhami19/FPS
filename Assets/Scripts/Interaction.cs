using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    FPSController controller;

    private bool isInteractable = false;

    UnityAction<bool> OnInteract;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<FPSController>();

        if(controller != null )
        { 
            controller.OnInteractable += isCollision;
        }

        OnInteract += Refill;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Interact()
    {
        Input.GetButton("Interact");
        OnInteract?.Invoke(isInteractable);
    }

    private void isCollision(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            isInteractable = true;  
        }
        else
        {
            controller.OnInteractable -= isCollision;
        }
    }

    private void Refill(bool interactable)
    {

    }
}
