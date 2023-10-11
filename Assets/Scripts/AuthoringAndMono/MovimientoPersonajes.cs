using UnityEngine;

public class MovimientoPersonajes : MonoBehaviour
{
    public Transform objetivo; // El objetivo a seguir (romanos o aliens)
    public float velocidad = 5f; // Velocidad de movimiento
    public float vida = 100f; // Cantidad inicial de vida del personaje
    public float fuerzaDeAtaque = 20f; // Fuerza de ataque del personaje

    void Update()
    {
        if (vida > 0 && objetivo != null)
        {
            // Calcula la dirección hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;

            // Calcula el movimiento basado en la velocidad y dirección
            Vector3 movimiento = direccion * velocidad * Time.deltaTime;

            // Calcula la nueva posición
            Vector3 nuevaPosicion = transform.position + movimiento;

            // Limita la nueva posición dentro de los límites del plano (si es necesario)
            // Puedes añadir aquí la lógica de limitación del movimiento si es necesario

            // Aplica la nueva posición al personaje
            transform.position = nuevaPosicion;

            // Rota el personaje hacia la dirección del movimiento (opcional)
            transform.rotation = Quaternion.LookRotation(direccion);
        }
        else
        {
            // Si el personaje se queda sin vida, lo desactivamos
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si choca con el objetivo
        if (collision.transform == objetivo)
        {
            // Resta fuerza de ataque a la vida del objetivo
            objetivo.GetComponent<MovimientoPersonajes>().RecibirAtaque(fuerzaDeAtaque);
        }
    }

    // Método para recibir un ataque y reducir la vida del personaje
    public void RecibirAtaque(float cantidadDeAtaque)
    {
        vida -= cantidadDeAtaque;

        // Verifica si el personaje se queda sin vida
        if (vida <= 0)
        {
            // Desactiva el objeto cuando se queda sin vida
            gameObject.SetActive(false);
        }
        else
        {
            // Si queda "vivo", detiene su movimiento
            velocidad = 0f;
        }
    }
}
