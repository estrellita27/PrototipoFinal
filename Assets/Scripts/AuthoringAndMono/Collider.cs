using UnityEngine;

public class Collider : MonoBehaviour
{
    // Permanently scales the size of the mesh by a factor.

    float scaleFactor = 2f;

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

        Vector3[] vertices = mesh.vertices;
        for (int p = 0; p < vertices.Length; p++)
        {
            vertices[p] *= scaleFactor;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}