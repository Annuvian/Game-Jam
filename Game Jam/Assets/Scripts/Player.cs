using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public GameController gc;
    public GameObject missile;
    public GameObject aabullet;
    public float speed = 5f;
    public bool cannonReloading = false;
    public bool samReloading = false;
    public int totalCannonAmmo = 2700;
    public int cannonAmmoCapacity = 300;
    public int totalSAMAmmo = 80;
    public int samAmmoCapacity = 20;
    public int cannonAmmo;
    public int samAmmo;
    public float cannonReloadTimer = 0;
    public float cannonReloadTime = 5f;
    public float samReloadTimer = 0;
    public float samReloadTime = 20f;
    public bool allowInput = true;

    // UI Stuff
    public Text TCA;
    public Text CCM;
    public Text TSA;
    public Text CSL;

    // Start is called before the first frame update
    void Start()
    {
        cannonAmmo = cannonAmmoCapacity;
        samAmmo = samAmmoCapacity;
        TCA.text = "Spare Cannon Ammo: " + totalCannonAmmo.ToString();
        CCM.text = "Current Cannon Magazine: " + cannonAmmo.ToString();
        TSA.text = "Spare SAM Ammo: " + totalSAMAmmo.ToString();
        CSL.text = "Current SAMs Loaded: " + samAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !samReloading && samAmmo > 0 && allowInput)
        {
            FireSAM();
            if (samAmmo == 0 && totalSAMAmmo >= samAmmoCapacity)
            {
                samReloading = true;
                CSL.text = "Current SAMs Loaded: RELOADING";
            } else if (samAmmo == 0 && totalSAMAmmo == 0)
            {
                CSL.text = "Current SAMs Loaded: EMPTY";
            }
        }
        if (Input.GetButton("Fire1") && !cannonReloading && cannonAmmo > 0 && allowInput)
        {
            FireAAGun();
            if (cannonAmmo == 0 && totalCannonAmmo >= cannonAmmoCapacity)
            {
                CCM.text = "Current Cannon Magazine: RELOADING";
                cannonReloading = true;
            } else if (cannonAmmo == 0 && totalCannonAmmo == 0)
            {
                CCM.text = "Current Cannon Magazine: EMPTY";
            }
        }
        if (cannonReloading)
        {
            cannonReloadTimer += 1 * Time.deltaTime;
            if (cannonReloadTimer >= cannonReloadTime)
            {
                cannonReloadTimer = 0;
                cannonReloading = false;
                totalCannonAmmo -= cannonAmmoCapacity;
                cannonAmmo = cannonAmmoCapacity;
                CCM.text = "Current Cannon Magazine: " + cannonAmmo.ToString();
                TCA.text = "Spare Cannon Ammo: " + totalCannonAmmo.ToString();
            }
        }
        if (samReloading)
        {
            samReloadTimer += 1 * Time.deltaTime;
            if (samReloadTimer >= samReloadTime)
            {
                samReloadTimer = 0;
                samReloading = false;
                totalSAMAmmo -= samAmmoCapacity;
                samAmmo = samAmmoCapacity;
                TSA.text = "Spare SAM Ammo: " + totalSAMAmmo.ToString();
                CSL.text = "Current SAMs Loaded: " + samAmmo.ToString();
            }
        }
        if ((cannonAmmo == 0 && totalCannonAmmo == 0) && (samAmmo == 0 && totalSAMAmmo == 0))
        {
            gc.gameOverText.text = "You have run out of all ammunition. You managed to fend off the invasion for " + Math.Round(gc.score).ToString() + " seconds, giving the survivors valuable time to escape!";
            gc.GameOver();
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
        CCM.text = "Current Cannon Magazine: " + cannonAmmo.ToString();
    }

    void FireSAM()
    {
        Instantiate(missile, transform.position, transform.rotation);
        samAmmo -= 1;
        CSL.text = "Current SAMs Loaded: " + samAmmo.ToString();
    }

    void FireSAW()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}