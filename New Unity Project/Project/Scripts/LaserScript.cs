using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed;
    Rigidbody laser;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<Rigidbody>();
        laser.velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
