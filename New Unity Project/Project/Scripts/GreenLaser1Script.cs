using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLaser1Script : MonoBehaviour
{
    public float speed;
    Rigidbody Greenlaser1;
    // Start is called before the first frame update
    void Start()
    {
        Greenlaser1 = GetComponent<Rigidbody>();

        Greenlaser1.velocity = new Vector3(35, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
