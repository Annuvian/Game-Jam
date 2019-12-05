using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plasma")
        {
            Destroy(collision.gameObject);
            health -= 5;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}