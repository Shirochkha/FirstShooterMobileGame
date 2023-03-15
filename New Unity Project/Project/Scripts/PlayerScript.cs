using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // public - можно задать снаружи(например в юнити)
    public Rigidbody ship; //твердое тело
    public float speed; //скорость корабля
    public float tilt; // коэф. наклона(чтобы менять наклон, не меняя скорость)

    public float xMin, xMax, zMin, zMax; // границы поля

    public GameObject laserShot; // шаблон лазерного выстрела в центре
    public GameObject laser1; // шаблон лазерного выстрела слево
    public GameObject laser2; // шаблон лазерного выстрела справо

    public Transform gunPosition; // местанохождение пушки в центре
    public Transform gunPosition1; // местанохождение пушки слево
    public Transform gunPosition2; // местанохождение пушки справо

    public float shotDelayYellow; // задержка между выстрелами в центре
    public float shotDelayGreen; // задержка между выстрелами в центре

    float nextShotTimeYellow; // время следующего выстрела
    float nextShotTimeGreen; // время следующего выстрела

    // Start is called before the first frame update
    // Код, который выполняется при появлении объекта на сцене
    void Start()
    {
        //ship.velocity = new Vector3(0, 0, 20); velocity - скорость(задаем скорость кораблю)

    }

    // Update is called once per frame
    // Код, который выполняется на каждый кадр
    void Update()
    {
        if (!GameControllerScript.isStarted)
        {
            return;
        }

        // инфа о том, куда пользоватль хочет двигаться по горизонтале. Возвращает от -1 до +1(влево-вправо)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax); //зажимаем координату(возвраn правильного числа)
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(correctX, 0, correctZ); // на каждый кадр задаем правильную позицию(в пределах экрана)

        // движение по X, поворот по Z. Quaternion ???????????????????
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt); 

        if(Time.time > nextShotTimeYellow && Input.GetButton("Fire1"))
        {
            //стрельба
            Instantiate(laserShot, gunPosition.position, Quaternion.identity); //шаблон, позиция, поворот(identity-пустой)

            nextShotTimeYellow = Time.time + shotDelayYellow; //задержка выстрела
        }

        if (Time.time > nextShotTimeGreen && Input.GetButton("Fire2"))
        {
            //стрельба
            Instantiate(laser1, gunPosition1.position, Quaternion.identity);
            Instantiate(laser2, gunPosition2.position, Quaternion.identity);

            nextShotTimeGreen = Time.time + shotDelayGreen; //задержка выстрела
        }
    }
}
