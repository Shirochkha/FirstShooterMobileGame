using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // public - ����� ������ �������(�������� � �����)
    public Rigidbody ship; //������� ����
    public float speed; //�������� �������
    public float tilt; // ����. �������(����� ������ ������, �� ����� ��������)

    public float xMin, xMax, zMin, zMax; // ������� ����

    public GameObject laserShot; // ������ ��������� �������� � ������
    public GameObject laser1; // ������ ��������� �������� �����
    public GameObject laser2; // ������ ��������� �������� ������

    public Transform gunPosition; // ��������������� ����� � ������
    public Transform gunPosition1; // ��������������� ����� �����
    public Transform gunPosition2; // ��������������� ����� ������

    public float shotDelayYellow; // �������� ����� ���������� � ������
    public float shotDelayGreen; // �������� ����� ���������� � ������

    float nextShotTimeYellow; // ����� ���������� ��������
    float nextShotTimeGreen; // ����� ���������� ��������

    // Start is called before the first frame update
    // ���, ������� ����������� ��� ��������� ������� �� �����
    void Start()
    {
        //ship.velocity = new Vector3(0, 0, 20); velocity - ��������(������ �������� �������)

    }

    // Update is called once per frame
    // ���, ������� ����������� �� ������ ����
    void Update()
    {
        if (!GameControllerScript.isStarted)
        {
            return;
        }

        // ���� � ���, ���� ����������� ����� ��������� �� �����������. ���������� �� -1 �� +1(�����-������)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax); //�������� ����������(������n ����������� �����)
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(correctX, 0, correctZ); // �� ������ ���� ������ ���������� �������(� �������� ������)

        // �������� �� X, ������� �� Z. Quaternion ???????????????????
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt); 

        if(Time.time > nextShotTimeYellow && Input.GetButton("Fire1"))
        {
            //��������
            Instantiate(laserShot, gunPosition.position, Quaternion.identity); //������, �������, �������(identity-������)

            nextShotTimeYellow = Time.time + shotDelayYellow; //�������� ��������
        }

        if (Time.time > nextShotTimeGreen && Input.GetButton("Fire2"))
        {
            //��������
            Instantiate(laser1, gunPosition1.position, Quaternion.identity);
            Instantiate(laser2, gunPosition2.position, Quaternion.identity);

            nextShotTimeGreen = Time.time + shotDelayGreen; //�������� ��������
        }
    }
}
