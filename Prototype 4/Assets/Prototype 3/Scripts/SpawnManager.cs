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
    {   //������� ��� �������� � �������� � ������ Enemy � ������ �� ���������� � ���������� 
        enemyCount = FindObjectsOfType<Enemy>().Length;
        
        //���� ����� ��������� ��� (����� ����������� ������ �����) 
        if (enemyCount == 0) 
        {   
            //����������� ���������� ������������ ����� �� 1 ������ �����
            waweNumber++;
            //��������� ������� �������� ������ ������������ ��� �� ���
            SpawnEnemyWawe(waweNumber);
            //������� ������ ������ � ��������� �����
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    //������� ������� "�������� ������ ������������ ���������� ���"
    void SpawnEnemyWawe(int enemiesToSpawn)
    {   //������� ������� ������ ������� ����� 
        for (int i = 0; i < enemiesToSpawn; i++)
        {   //�������� � ����� �������
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


    //������� ������� "�������� �������� ����" � ������� ��� ������� 
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
    

}
