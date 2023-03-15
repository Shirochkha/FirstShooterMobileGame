using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLaser2Script : MonoBehaviour
{
    public float speed;
    Rigidbody Greenlaser2;
    // Start is called before the first frame update
    void Start()
    {
        Greenlaser2 = GetComponent<Rigidbody>();

        Greenlaser2.velocity = new Vector3(-35, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
