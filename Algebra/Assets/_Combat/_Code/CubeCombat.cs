using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCombat : MonoBehaviour
{
    public Material material;

    Mesh mesh;
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    Vector3[] vertex;
    int[] triangles;

    public void makeCube(Material newMaterial)
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = newMaterial;
        meshFilter.mesh = mesh;

        vertex = new[]
        {
            new Vector3(0,0,0),
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(1,1,0), //cara 1 (4)
            new Vector3(0,1,0),
            new Vector3(0,1,1),
            new Vector3(1,1,0),
            new Vector3(1,1,1), //cara 2 (7)
            new Vector3(0,0,1),
            new Vector3(0,1,1),
            new Vector3(1,0,1),
            new Vector3(1,1,1), //cara 3 (11)
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3(1,0,1), //cara 4 (15)
            new Vector3(0,0,0),
            new Vector3(0,1,0),
            new Vector3(0,0,1),
            new Vector3(0,1,1), //cara 5 (19)
            new Vector3(1,0,0),
            new Vector3(1,1,0),
            new Vector3(1,0,1),
            new Vector3(1,1,1), //cara 6 (23)
        };


        meshFilter.mesh.vertices = vertex;

        triangles = new[]
        {
            //Cara 1 (frente)
            0,1,2,  // T_1
            1,3,2,  // T_2
            //Cara 2 (arriba)
            4,5,6,
            5,7,6,
            //cara 3 (atras)
            10,9,8,
            10,11,9,
            //cara 4 (abajo)
            12,14,13,
            13,14,15,
            //cara 5 (izquierda)
            17,16,18,
            18,19,17,
            //cara 6 (derecha)
            20,21,22,
            21,23,22
        };

        meshFilter.mesh.triangles = triangles;
}

    public void Start()
    {
        makeCube(material);
    }

}
