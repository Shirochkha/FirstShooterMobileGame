using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrollerScript : MonoBehaviour
{
    public float speed;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // где фон находится изначально
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Repeat(Time.time * speed, 100); //0 .. 100. Mathf.Repeat - зациклили
        transform.position = startPosition + new Vector3(0, 0, -offset);
    }
}
