using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicMovement : MonoBehaviour
{
    public Transform target; // Referencia al GameObject cuyo movimiento queremos imitar
    public Vector3 offset; // Desplazamiento desde la posición del objeto objetivo

    void Update()
    {
        // Calcular la posición con desplazamiento
        //Vector3 targetPosition = target.position + offset;
        Vector3 targetPosition = new Vector3(-target.position.x, target.position.y, target.position.z) + offset;

        // Copiar la posición y rotación del GameObject objetivo con desplazamiento
        transform.position = targetPosition;
        transform.rotation = target.rotation;
    }
}
