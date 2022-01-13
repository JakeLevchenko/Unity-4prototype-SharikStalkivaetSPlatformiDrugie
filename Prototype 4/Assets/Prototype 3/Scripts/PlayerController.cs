using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public bool hasPowerUp;
    private float powerStrength = 15.0f;

    public GameObject powerupIndicator;
    private GameObject focalPoint;
    private Rigidbody playerRb;
   

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //загоняем в переменную обьект в котором камера
        focalPoint = GameObject.Find("Focal Point");
    }

   
    void Update()
    {
        //инициализируем в переменную нажатие стрелок вверх низ
        float forwardInput = Input.GetAxis("Vertical");
        //толкаем обьект вперед по нажатию клавишь вперед назад
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        //задаем позицию индикатора усиления на игроке 
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        //когда мы казаемся бонуса
        if (other.CompareTag("Powerup"))
        {
            //записываем что мы коснулись бонуса (активируя усиления)
            hasPowerUp = true;
            //удаляем обьект бонуса
            Destroy(other.gameObject);
            //запускаем корутину с отсчетом времени
            StartCoroutine(PowerupCountdownRoutine());
            //включаем индикатор усиления (ставим галочку что бы включить)
            powerupIndicator.gameObject.SetActive(true);
        }
        //создаем корутину с отложеным запуском
        IEnumerator PowerupCountdownRoutine()
        {
            //делаем паузу 7 сек перед выполеннием
            yield return new WaitForSeconds(7);
            //записываем что бонус закончился (выключая усиления)
            hasPowerUp = false;
            //выключаем индикатор усиления
            powerupIndicator.gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        //если касаемся врага и активировано усиление
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //узнаем векторное направление от игрока к врагу
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collider with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            //импульсом отталкиваем врага от игрока в противоположном направлении
            enemyRigidbody.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        
        
        
        }
    }

  

}
