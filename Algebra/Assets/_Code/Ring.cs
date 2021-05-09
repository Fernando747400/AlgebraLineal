using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    Vector3DLibrary VectorCalculation = new Vector3DLibrary();

    [Header("Angulo de generación")]
    [SerializeField] private float generationAngle = 6f;

    [Header("Materiales")]
    [SerializeField] private Material material;
    [SerializeField] private Texture texture;

    [Header("Valores")]
    [SerializeField] private float Angle = 1f;
    [SerializeField] private float Speed = 1;
    public enum Axis {X,Y,Z};
    public Axis axis;

    Mesh mesh;
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    Vector3[] vertex;
    int[] triangles;
    Vector2[] uvs;
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();

        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        meshFilter.mesh = mesh;

        vertex = new Vector3[122];

        vertex[0] = new Vector3(0f, -0.063f, -3.893f);
        vertex[1] = new Vector3(0f, 0.063f, -3.893f);

        for (int i = 2; i<122; i++)
        {
            vertex[i] = VectorCalculation.rotateVectorAxisY(vertex[i - 2], generationAngle);
            i++;
            vertex[i] = VectorCalculation.rotateVectorAxisY(vertex[i - 2], generationAngle);
        }

        meshFilter.mesh.vertices = vertex;

        triangles = new int [360];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        for (int i = 6; i<360; i++)
        {
            triangles[i] = triangles[i-3];
            i++;
            triangles[i] = triangles[i-2];
            i++;
            triangles[i] = triangles[i-1]+1;
            i++;
            triangles[i] = triangles[i - 1];
            i++;
            triangles[i] = triangles[i - 3];
            i++;
            triangles[i] = triangles[i - 2]+1;
        }


        uvs = new Vector2[122];

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(0, 1);
        uvs[2] = new Vector2(1, 0);
        uvs[3] = new Vector2(1, 1);

        for (int i =4; i<120; i++)
        {
            uvs[i] = uvs[0];
            i++;
            uvs[i] = uvs[1];
            i++;
            uvs[i] = uvs[2];
            i++;
            uvs[i] = uvs[3];
        }
        uvs[120] = new Vector2(0,0);
        uvs[121] = new Vector2(0,1);


        meshFilter.mesh.triangles = triangles;
        meshFilter.mesh.uv = uvs;
        meshFilter.mesh.Optimize();
        meshFilter.mesh.RecalculateNormals();

        InvokeRepeating("updateVertex", 1f, 0.01f * Speed);
    }

    
    public void updateVertex()
    {
        Vector3[] auxiliarVertex = meshFilter.mesh.vertices;


        switch(axis)
        {
            case Axis.X:
                {
                    for (int i = 0; i < auxiliarVertex.Length; i++)
                    {
                        auxiliarVertex[i] = VectorCalculation.rotateVectorAxisX(auxiliarVertex[i], Angle);
                    }
                }
                break;

            case Axis.Y:
                {
                    for (int i = 0; i < auxiliarVertex.Length; i++)
                    {
                        auxiliarVertex[i] = VectorCalculation.rotateVectorAxisY(auxiliarVertex[i], Angle);
                    }
                }
                break;

            case Axis.Z:
                {
                    for (int i = 0; i < auxiliarVertex.Length; i++)
                    {
                        auxiliarVertex[i] = VectorCalculation.rotateVectorAxisZ(auxiliarVertex[i], Angle);
                    }
                }
                break;
        }

      
        meshFilter.mesh.vertices = auxiliarVertex;
    }
    
 
    
}
