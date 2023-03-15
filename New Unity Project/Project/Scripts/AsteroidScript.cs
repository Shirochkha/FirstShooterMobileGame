using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed;
    public float angularSpeed;

    public GameObject asteroidExplosionEffect;
    public GameObject playerExplosionEffect;

    float size;

    Rigidbody asteroid;

    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0.5f, 2.0f); // ����.�������

        asteroid = GetComponent<Rigidbody>();

        transform.localScale *= size;
        asteroid.velocity = new Vector3(0, 0, -speed) / size;
        asteroid.angularVelocity = Random.insideUnitSphere * angularSpeed; //������� ��������-��������� ������
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�����������, ����� ��������� ������������
    //other - ������, � ������� ��������� ������������
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Asteroid")
        {
            return;
        }

        if (other.tag == "GameBoundary")
        {
            return;
        }
        // �����
        // transform.position - ������� �������� �������
        Instantiate(asteroidExplosionEffect, transform.position, Quaternion.identity);

        if(other.tag == "Player")
        {
            Instantiate(playerExplosionEffect, other.transform.position, Quaternion.identity);
          Time.timeScale = 0;
            //��������, ��� ���������, ����� ���� ������� ������ ������ ������
        }

        //���������� ����� ������
        GameControllerScript.score += (int)(20 / size);

        Destroy(gameObject); //gameObject - ������� ������� ������
        Destroy(other.gameObject); // ����������� ����, � ��� ���� ������������
    }
}
