using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    

    public float speed = 3.0f;
    
    
    void Start()
    {
        //инициализируем ригидбоди
        enemyRb = GetComponent<Rigidbody>();
        //находим в иерархии обьект плеер и переносим его в переменную
        player = GameObject.Find("Player");
    }


    void Update()
    {
        //находим векторное расстояние от врага к игроку
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //толкаем врага в сторону игрока по вектору по скорости
        enemyRb.AddForce(lookDirection * speed);

        //уничтожаем падающие с платформы шары
        if (gameObject.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
