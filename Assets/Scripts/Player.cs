using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;         
    public float rotationSpeed = 5f; 

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            float rotationAngle = rotationSpeed * Time.deltaTime * horizontalInput;

            transform.Rotate(Vector3.up, rotationAngle);
        }
    }

}
