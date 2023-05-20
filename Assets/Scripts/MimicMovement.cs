using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicMovement : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // Calcular la posición con desplazamiento invirtiendo el movimiento en X
        Vector3 targetPosition = new Vector3(-target.position.x, target.position.y, target.position.z);

        //Invierte rotacion cuando se mueve sobre el eje Y
        Quaternion targetRotation = Quaternion.Euler(0f, -target.eulerAngles.y, 0f);

        // Copiar la posición y rotación del player
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}
