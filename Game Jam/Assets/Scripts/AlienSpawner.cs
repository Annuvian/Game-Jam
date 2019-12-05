using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject ship;

    public bool isSpawned = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned)
        {
            Instantiate(ship, transform.position, transform.rotation);
            isSpawned = true;
        }
    }
}