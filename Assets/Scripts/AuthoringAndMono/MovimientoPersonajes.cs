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
            // Calcula la direcci�n hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;

            // Calcula el movimiento basado en la velocidad y direcci�n
            Vector3 movimiento = direccion * velocidad * Time.deltaTime;

            // Calcula la nueva posici�n
            Vector3 nuevaPosicion = transform.position + movimiento;

            // Limita la nueva posici�n dentro de los l�mites del plano (si es necesario)
            // Puedes a�adir aqu� la l�gica de limitaci�n del movimiento si es necesario

            // Aplica la nueva posici�n al personaje
            transform.position = nuevaPosicion;

            // Rota el personaje hacia la direcci�n del movimiento (opcional)
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

    // M�todo para recibir un ataque y reducir la vida del personaje
    public void RecibirAtaque(float cantidadDeAtaque)
    {
        vida -= cantidadDeAtaque;

        // Verifica si el personaje se queda sin vida
        if (vida <= 0)
        {
            // Desactiva el objeto cuando se queda sin vida
            gameObject.SetActive(false);
        }
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
