using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject missile;
    public GameObject aabullet;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            FireSAM();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            FireAAGun();
        }
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void FireAAGun()
    {
        Instantiate(aabullet, transform.position, transform.rotation);
    }

    void FireSAM()
    {
        Instantiate(missile, transform.position, transform.rotation);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.gameObject.name);
        }
    }

    void FireSAW()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}