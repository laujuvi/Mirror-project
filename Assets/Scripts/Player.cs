using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del objeto
    public float rotationSpeed = 5f;   // Velocidad de rotación del objeto

    void Update()
    {
        // Obtener las entradas del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 movement = new Vector3(-moveVertical, 0f, moveHorizontal);

        // Actualizar la posición del objeto en función de la dirección y velocidad
        transform.position += movement * speed * Time.deltaTime;

        // Rotar el objeto para que apunte en la dirección de movimiento
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
