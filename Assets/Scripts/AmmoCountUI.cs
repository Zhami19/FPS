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
        gun = FindObjectOfType<Gun>();
    }

    public void AmmoCount(int maxCount, int currentCount)
    {
        maxAmmo.text = maxCount.ToString();  
        currentAmmo.text = currentCount.ToString();
    }
}
