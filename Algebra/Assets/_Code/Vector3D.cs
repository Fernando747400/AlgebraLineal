using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3D : MonoBehaviour
{
    [Header ("Vectores")]
    [SerializeField] private GameObject gameObjectOne;
    [SerializeField] private GameObject gameObjectTwo;
    [Header("Traslaciones")]
    [SerializeField] private float X;
    [SerializeField] private float Y;
    [SerializeField] private float Z;



    void Update()
    {
        Debug.Log("Magnitud " + magnitud(parseVector(gameObjectOne)));
        Debug.Log("Normalizado " + normalize(parseVector(gameObjectOne)));
        Debug.Log("Distancia " + distance(parseVector(gameObjectOne),parseVector(gameObjectTwo)));
        Debug.Log("Cruzado " + cross(parseVector(gameObjectOne), parseVector(gameObjectTwo)));
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObjectOne.transform.position = transformVector(parseVector(gameObjectOne), X, Y, Z);
            Debug.Log("Espacio presionado");
        }
    }

    Vector3 parseVector(GameObject objectOne)
    {
        Vector3 answer;
        answer = objectOne.transform.position;
        return answer;
    }

    float magnitud(Vector3 vector)
    {
        float respuesta;
        respuesta = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2));
        return respuesta;
    }

    Vector3 normalize(Vector3 vector)
    {
        Vector3 respuesta;
        respuesta.x = vector.x / magnitud(vector);
        respuesta.y = vector.y / magnitud(vector);
        respuesta.z = vector.z / magnitud(vector);
        return respuesta;
    }

    float distance(Vector3 vectorOne, Vector3 vectorTwo)
    {
        float respuesta;
        respuesta = Mathf.Sqrt(Mathf.Pow(vectorOne.x - vectorTwo.x, 2)
            + Mathf.Pow(vectorOne.y - vectorTwo.y, 2)
            + Mathf.Pow(vectorOne.z - vectorTwo.z, 2));
        return respuesta;
    }

    public Vector3 cross(Vector3 vectorOne, Vector3 vectorTwo)
    {
        Vector3 answer;
        answer.x = (vectorOne.y * vectorTwo.z) - (vectorOne.z * vectorTwo.y);
        answer.y = (vectorOne.z * vectorTwo.x) - (vectorOne.x * vectorTwo.z);
        answer.z = (vectorOne.x * vectorTwo.y) - (vectorOne.y * vectorTwo.x);
        return answer;
    }

    public Vector3 transformVector(Vector3 Vector, float X, float Y, float Z)
    {
        Vector3 answer = new Vector3();
        float[,] delta = generateMatrix();
        float[] vectorMatrix = new float[4];
        vectorMatrix[0] = Vector.x;
        vectorMatrix[1] = Vector.y;
        vectorMatrix[2] = Vector.z;
        vectorMatrix[3] = 1;
        delta[0 ,3] = X;
        delta[1, 3] = Y;
        delta[2, 3] = Z;
        float[] multiplied = multiplyMatrix3D(delta,vectorMatrix);
        answer.x = multiplied[0];
        answer.y = multiplied[1];
        answer.z = multiplied[2];
        return answer;
    }

    float[] multiplyMatrix3D(float[,] delta, float[] Vector)
    {
        float[] answer = new float[4];
        float temporal = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int x = 0; x < 4; x++)
            {
                temporal = temporal + (delta[i, x] * Vector[i]);
                if (x == 3)
                {
                    answer[i] = temporal;
                }
            }
           temporal = 0;
        }
        return answer;
    } 

     float[,] generateMatrix()
    {
        float[,] answer = new float[4, 4];

        for (int i = 0; i < 4; i++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (i == x)
                {
                    answer[i, x] = 1;
                }
                else
                {
                    answer[i, x] = 0;
                }
            }
        }
        return answer;
    }
}
