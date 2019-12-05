using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int health = 100;
    public GameObject laser;
    public float speed;
    public float leftLimit = -8.7f;
    public float rightLimit = 8.7f;
    public bool left;
    public float xPos;
    public bool inShot = false;
    public GameObject myspawner;
    public AlienSpawner spawner;
    private float timer = 0;
    private float fireRate = 1f;
    private bool justFired = false;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y == 4.6f)
        {
            myspawner = GameObject.Find("Alien Spawner");
        } else if (transform.position.y == 3.5f)
        {
            myspawner = GameObject.Find("Alien Spawner (1)");
        } else if (transform.position.y == 2.4f)
        {
            myspawner = GameObject.Find("Alien Spawner (2)");
        } else if (transform.position.y == 1.3f)
        {
            myspawner = GameObject.Find("Alien Spawner (3)");
        } else if (transform.position.y == 0.2f)
        {
            myspawner = GameObject.Find("Alien Spawner (4)");
        }
        spawner = myspawner.GetComponent<AlienSpawner>();
        speed = Random.Range(1f, 5f);
        xPos = transform.position.x;
        if (xPos < leftLimit)
        {
            left = true;
        } else
        {
            left = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > leftLimit && transform.position.x < rightLimit)
        {
            inShot = true;
        }
        if (justFired)
        {
            timer += 1 * Time.deltaTime;
            if (timer >= fireRate)
            {
                timer = 0;
                justFired = false;
            }
        }
        if (left)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            if (transform.position.x >= rightLimit && inShot)
            {
                left = false;
            }
        } else
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            if (transform.position.x <= leftLimit && inShot)
            {
                left = true;
            }
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
                spawner.isSpawned = false;
            }
        }
        if (collision.gameObject.tag == "SAM")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            spawner.isSpawned = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building" && !justFired)
        {
            FirePlasma();
        }
    }
    void FirePlasma()
    {
        Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 0.2f, -2), transform.rotation);
        justFired = true;
    }
}