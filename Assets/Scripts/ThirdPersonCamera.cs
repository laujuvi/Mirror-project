using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -5f);  
    public float damping = 1f;           // Suavidad de movimiento de la c�mara
    public LayerMask collisionLayer;
    public float rotationSpeed = 5f;     // Rotaci�n de la c�mara

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("No se ha asignado el objetivo (jugador) en el script ThirdPersonCamera.");
        }
    }

    private void LateUpdate()
    {
        // Obtener la rotaci�n actual del jugador
        Quaternion desiredRotation = target.rotation;

        // Calcular la posici�n final de la c�mara
        Vector3 desiredPosition = target.position - (desiredRotation * offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, damping * Time.deltaTime);

        // Realizar el raycast desde el objetivo hasta la posici�n suavizada de la c�mara
        RaycastHit hit;
        if (Physics.Linecast(target.position, smoothedPosition, out hit, collisionLayer))
        {
            smoothedPosition = hit.point;
        }

        transform.position = smoothedPosition;

        // Rotar la c�mara hacia donde mira el jugador
        Quaternion desiredLookRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredLookRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = smoothedRotation;
    }

}
