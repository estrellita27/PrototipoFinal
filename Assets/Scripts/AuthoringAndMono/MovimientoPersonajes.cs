using UnityEngine;

public class MovimientoPersonajes : MonoBehaviour
{
    public Transform objetivo; // El objetivo a seguir (romanos o aliens)
    public float velocidad = 5f; // Velocidad de movimiento

    void Update()
    {
        // Calcula la dirección hacia el objetivo
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        // Mueve el personaje hacia el objetivo
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // Rota el personaje hacia la dirección del objetivo (opcional)
        transform.LookAt(objetivo);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si choca con el objeto objetivo
        if (collision.transform == objetivo)
        {
            // Desaparece el objeto actual
            Destroy(gameObject);
        }
    }
}
