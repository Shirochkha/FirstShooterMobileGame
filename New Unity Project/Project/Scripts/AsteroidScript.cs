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
        size = Random.Range(0.5f, 2.0f); // коэф.размера

        asteroid = GetComponent<Rigidbody>();

        transform.localScale *= size;
        asteroid.velocity = new Vector3(0, 0, -speed) / size;
        asteroid.angularVelocity = Random.insideUnitSphere * angularSpeed; //угловая скорость-случайный вектор
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //срабатывает, когда проиходит столкновение
    //other - объект, с которым произошло столкновение
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
        // взрыв
        // transform.position - позиция текущего объекта
        Instantiate(asteroidExplosionEffect, transform.position, Quaternion.identity);

        if(other.tag == "Player")
        {
            Instantiate(playerExplosionEffect, other.transform.position, Quaternion.identity);
          Time.timeScale = 0;
            //написать, что неактивен, когда хочу сделать кнопку Начать заново
        }

        //начисление очков игроку
        GameControllerScript.score += (int)(20 / size);

        Destroy(gameObject); //gameObject - текущий игровой объект
        Destroy(other.gameObject); // уничтожение того, с чем было столкновение
    }
}
