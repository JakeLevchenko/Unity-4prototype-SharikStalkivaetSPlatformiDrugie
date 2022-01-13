using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //инициализируем нажатие клавишь лево право
        float horizontalInput = Input.GetAxis("Horizontal");
        //поворачиваем камеру по нажатию клавишь лево-право
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
