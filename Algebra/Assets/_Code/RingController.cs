using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    [Header("Vectores")]
    [SerializeField] private GameObject gameObjectOne;
    [Header("Angulo")]
    [SerializeField] private float Angle;

    Vector3DLibrary vector3D = new Vector3DLibrary();

    // Update is called once per frame
    void Update()
    {
        gameObjectOne.transform.position = vector3D.rotateVectorAxisX(vector3D.parseVector(gameObjectOne), Angle);
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown("w"))
        {
            gameObjectOne.transform.position = vector3D.rotateVectorAxisX(vector3D.parseVector(gameObjectOne),Angle);
        }

        if (Input.GetKeyDown("s"))
        {
            gameObjectOne.transform.position = vector3D.rotateVectorAxisX(vector3D.parseVector(gameObjectOne), -Angle);
        }

        if (Input.GetKeyDown("a"))
        {
            gameObjectOne.transform.position = vector3D.rotateVectorAxisY(vector3D.parseVector(gameObjectOne), Angle);
        }

        if (Input.GetKeyDown("d"))
        {
            gameObjectOne.transform.position = vector3D.rotateVectorAxisY(vector3D.parseVector(gameObjectOne), -Angle);
        }
    }
}
