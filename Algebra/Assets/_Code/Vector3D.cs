using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3D : MonoBehaviour
{
    [Header ("Vectores")]
    [SerializeField] private GameObject gameObjectOne;
    [SerializeField] private GameObject gameObjectTwo;
 



    void Update()
    {
        Debug.Log("Magnitud " + magnitud(parseVector(gameObjectOne)));
        Debug.Log("Normalizado " + normalize(parseVector(gameObjectOne)));
        Debug.Log("Distancia " + distance(parseVector(gameObjectOne),parseVector(gameObjectTwo)));
        Debug.Log("Cruzado " + cross(parseVector(gameObjectOne), parseVector(gameObjectTwo)));
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
}
