using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] TMP_Text maxAmmo;
    [SerializeField] TMP_Text currentAmmo;

    FPSController FPScontroller;
    Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        FPScontroller = FindObjectOfType<FPSController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            Debug.Log("inRange");
            if (FPScontroller != null)
            {
                Debug.Log("Added Listener");
                FPScontroller.OnInteract += Refill;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            Debug.Log("outOfRange");
            if (FPScontroller != null)
            {
                Debug.Log("Removed Listener");
                FPScontroller.OnInteract -= Refill;
            }
        }
    }

    public void Refill()
    {
        Debug.Log("Refilling");

        int max = int.Parse(maxAmmo.text);
        Debug.Log(max);
        int current = int.Parse(currentAmmo.text);
        Debug.Log(current);
        int amountToRefill = max - current;

        currentAmmo.text = maxAmmo.text;

        FPScontroller.IncreaseAmmo(amountToRefill);
    }
}