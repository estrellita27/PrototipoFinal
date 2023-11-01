using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject personajePrefab; // Prefab del personaje a generar
    public Transform areaSpawn; // Área dentro de la cual se generan los personajes
    public int cantidadPersonajes = 5; // Número de personajes a generar

    void Start()
    {
        // Genera los personajes dentro del área especificada
        for (int i = 0; i < cantidadPersonajes; i++)
        {
            SpawnPersonaje();
        }
    }

    void SpawnPersonaje()
    {
        // Obtiene una posición aleatoria dentro del área de spawn
        Vector3 posicionAleatoria = new Vector3(
            Random.Range(areaSpawn.position.x - areaSpawn.localScale.x / 2, areaSpawn.position.x + areaSpawn.localScale.x / 2),
            areaSpawn.position.y,
            Random.Range(areaSpawn.position.z - areaSpawn.localScale.z / 2, areaSpawn.position.z + areaSpawn.localScale.z / 2)
        );

        // Instancia el personaje en la posición aleatoria y verifica colisiones
        UnityEngine.Collider[] colliders = Physics.OverlapSphere(posicionAleatoria, 1f);
        if (colliders.Length == 0)
        {
            GameObject nuevoPersonaje = Instantiate(personajePrefab, posicionAleatoria, Quaternion.identity);
            // Aquí podrías configurar las características del personaje si es necesario
        }
        else
        {
            // Si hay colisiones, intenta encontrar una nueva posición
            SpawnPersonaje();
        }
    }
}
