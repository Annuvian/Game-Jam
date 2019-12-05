using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int health = 100;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FirePlasma();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AARound")
        {
            Destroy(collision.gameObject);
            health -= 20;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag == "SAM")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void FirePlasma()
    {
        Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 0.2f, -2), transform.rotation);
    }
}