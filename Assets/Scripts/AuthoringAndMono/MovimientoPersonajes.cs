using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovimientoPersonajes : MonoBehaviour
{
    public Transform objetivo; // El objetivo a seguir (romanos o aliens)
    public float velocidad = 5f; // Velocidad de movimiento

    void Update()
    {
        // Calcula la direcci�n hacia el objetivo
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        // Mueve el personaje hacia el objetivo
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // Rota el personaje hacia la direcci�n del objetivo (opcional)
        transform.LookAt(objetivo);
    }
}