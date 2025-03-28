using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;

    FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = 1;
        player = FindObjectOfType<FPSController>();
    }

    public void DamageTaken()
    {
        healthBar.fillAmount -= .2f;
    }
}
