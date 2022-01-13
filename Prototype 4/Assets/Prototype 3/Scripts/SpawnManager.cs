using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9;
    public int enemyCount;
    public int waweNumber = 1;

    void Start()
    {
        
        
    }

    void Update()
    {   //находим все елементы в иерархии с именем Enemy и заноим их количество в переменную 
        enemyCount = FindObjectsOfType<Enemy>().Length;
        
        //если таких елементов нет (когда закончилась первая волна) 
        if (enemyCount == 0) 
        {   
            //увеличиваем количество возрождаемых мячей на 1 каждую волну
            waweNumber++;
            //запускаем функцию создания врагов определенное кол во раз
            SpawnEnemyWawe(waweNumber);
            //создаем обьект бонуса в рандомном месте
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    //создаем функцию "создания врагов определенное количество раз"
    void SpawnEnemyWawe(int enemiesToSpawn)
    {   //создаем столько врагов сколько ввели 
        for (int i = 0; i < enemiesToSpawn; i++)
        {   //копируем в сцену префабы
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


    //создаем функцию "диапазон игрового поля" и выводим его размеры 
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
    

}
