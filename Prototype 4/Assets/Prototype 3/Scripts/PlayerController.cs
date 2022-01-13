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
        //�������� � ���������� ������ � ������� ������
        focalPoint = GameObject.Find("Focal Point");
    }

   
    void Update()
    {
        //�������������� � ���������� ������� ������� ����� ���
        float forwardInput = Input.GetAxis("Vertical");
        //������� ������ ������ �� ������� ������� ������ �����
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        //������ ������� ���������� �������� �� ������ 
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        //����� �� �������� ������
        if (other.CompareTag("Powerup"))
        {
            //���������� ��� �� ��������� ������ (��������� ��������)
            hasPowerUp = true;
            //������� ������ ������
            Destroy(other.gameObject);
            //��������� �������� � �������� �������
            StartCoroutine(PowerupCountdownRoutine());
            //�������� ��������� �������� (������ ������� ��� �� ��������)
            powerupIndicator.gameObject.SetActive(true);
        }
        //������� �������� � ��������� ��������
        IEnumerator PowerupCountdownRoutine()
        {
            //������ ����� 7 ��� ����� �����������
            yield return new WaitForSeconds(7);
            //���������� ��� ����� ���������� (�������� ��������)
            hasPowerUp = false;
            //��������� ��������� ��������
            powerupIndicator.gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        //���� �������� ����� � ������������ ��������
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //������ ��������� ����������� �� ������ � �����
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collider with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            //��������� ����������� ����� �� ������ � ��������������� �����������
            enemyRigidbody.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        
        
        
        }
    }

  

}
