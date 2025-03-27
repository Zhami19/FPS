using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCountUI : MonoBehaviour
{
    Gun gun;

    [SerializeField] TMP_Text maxAmmo;
    [SerializeField] TMP_Text currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi");
        gun = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AmmoCount(int maxCount, int currentCount)
    {
        Debug.Log("Invoked AmmoCount");
        maxAmmo.text = maxCount.ToString();  
        currentAmmo.text = currentCount.ToString();
    }
}
