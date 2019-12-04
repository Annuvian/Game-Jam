using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int health = 100;
    public int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (transform.position.x > 0f)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }
}