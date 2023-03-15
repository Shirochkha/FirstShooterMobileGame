using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroisSourceScript : MonoBehaviour
{
    public GameObject asteroid;
    public float delay; // ��������

    float nextTime; //����� ���������� �������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.isStarted)
        {
            return;
        }

        if (Time.time > nextTime)
        {
            float right = transform.localScale.x / 2;
            float randomX  = Random.Range(-right, right); //�������� ��������� �����

            Vector3 pos = new Vector3(randomX, 0, transform.position.z);

            Instantiate(asteroid, pos, Quaternion.identity); //������, �������, �������(identity-������)

            nextTime = Time.time + delay; //�������� ��������
        }
    }
}
