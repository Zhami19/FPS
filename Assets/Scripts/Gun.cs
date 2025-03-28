using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // references
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator anim;

    // stats
    [SerializeField] int maxAmmo;
    [SerializeField] float timeBetweenShots = 0.1f;

    [SerializeField] UnityEvent<int, int> OnChangeAmmo;
    public UnityEvent OnFire;

    // private variables
    int ammo;
    float elapsed = 0;


    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        OnChangeAmmo?.Invoke(maxAmmo, ammo);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    public bool AttemptFire()
    {
        if (ammo <= 0)
        {
            return false;
        }

        if(elapsed < timeBetweenShots)
        {
            return false;
        }

        Debug.Log("Bang");
        Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
        timeBetweenShots = 0;
        ammo -= 1;
        OnChangeAmmo?.Invoke(maxAmmo, ammo);
        OnFire?.Invoke();


        return true;
    }

    public void AddAmmo(int amount)
    {
        Debug.Log("Ammo before " + ammo);
        ammo += amount;
        Debug.Log("Ammo now is " + ammo);
    }
}
