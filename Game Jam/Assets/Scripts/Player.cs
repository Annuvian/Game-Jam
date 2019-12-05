using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject missile;
    public GameObject aabullet;
    public float speed = 5f;
    public bool cannonReloading = false;
    public bool samReloading = false;
    public int cannonAmmoCapacity = 300;
    public int samAmmoCapacity = 20;
    public int cannonAmmo;
    public int samAmmo;
    public float cannonReloadTimer = 0;
    public float cannonReloadTime = 5f;
    public float samReloadTimer = 0;
    public float samReloadTime = 20f;
    // Start is called before the first frame update
    void Start()
    {
        cannonAmmo = cannonAmmoCapacity;
        samAmmo = samAmmoCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !samReloading && samAmmo > 0)
        {
            FireSAM();
            if (samAmmo == 0)
            {
                samReloading = true;
            }
        }
        if (Input.GetButton("Fire1") && !cannonReloading && cannonAmmo > 0)
        {
            FireAAGun();
            if (cannonAmmo == 0)
            {
                cannonReloading = true;
            }
        }
        if (cannonReloading)
        {
            cannonReloadTimer += 1 * Time.deltaTime;
            if (cannonReloadTimer >= cannonReloadTime)
            {
                cannonReloadTimer = 0;
                cannonReloading = false;
                cannonAmmo = cannonAmmoCapacity;
            }
        }
        if (samReloading)
        {
            samReloadTimer += 1 * Time.deltaTime;
            if (samReloadTimer >= samReloadTime)
            {
                samReloadTimer = 0;
                samReloading = false;
                samAmmo = samAmmoCapacity;
            }
        }
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void FireAAGun()
    {
        Instantiate(aabullet, transform.position, transform.rotation);
        cannonAmmo -= 1;
    }

    void FireSAM()
    {
        Instantiate(missile, transform.position, transform.rotation);
        samAmmo -= 1;
    }

    void FireSAW()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}