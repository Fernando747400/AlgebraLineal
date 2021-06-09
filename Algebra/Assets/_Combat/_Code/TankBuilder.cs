using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBuilder : MonoBehaviour
{
    [Header("BuildingBlocks")]
    public GameObject baseTank;
    public GameObject baseWheels;
    [Header("Position and rotation")]
    public Vector3 InitialPosition;
    public Vector3 InititalRotation;
    [Header("Myself and enemy")]
    public GameObject enemy;
    [Header("ResetSound")]
    public AudioClip teleport;
    private Vector3DLibrary myVector3D = new Vector3DLibrary();
    private Vector3 InitialPositionSave, InitialRotationSave;
    void Start()
    {
        makeTank();
    }

 void makeTank()
    {
        //Make left set of wheels

        for (int x = -3; x < -1; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                 for (int z = -3; z < 3; z++)
                {
                Instantiate(baseWheels, new Vector3(x, y, z), Quaternion.identity, this.transform);
                }
            }
        }

        //Make right set of wheels

        for (int x = 2; x < 4; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int z = -3; z < 3; z++)
                {
                    Instantiate(baseWheels, new Vector3(x, y, z), Quaternion.identity, this.transform);
                }
            }
        }

        //Center mass of the tank

        for (int x = -1; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int z = -1; z < 2; z++)
                {
                    Instantiate(baseTank, new Vector3(x, y, z), Quaternion.identity, this.transform);
                }
            }
        }

        //Barrel of the gun
        for (int x = 0; x < 3; x++)
        {
            Instantiate(baseTank, new Vector3(0, 1, 2+x), Quaternion.identity, this.transform);
        }

        this.transform.position = myVector3D.transformVector(this.transform.position, InitialPosition.x, InitialPosition.y, InitialPosition.z);
        this.transform.rotation = Quaternion.Euler(myVector3D.transformVector(this.transform.rotation.eulerAngles,InititalRotation.x, InititalRotation.y, InititalRotation.z));
        InitialPositionSave = this.transform.position;
        InitialRotationSave = this.transform.rotation.eulerAngles;
        
    }

    public void resetPlayer()
    {
        this.transform.position = InitialPositionSave;
        this.transform.rotation = Quaternion.Euler(InitialRotationSave);
        AudioSource.PlayClipAtPoint(teleport,this.transform.position,1.0f);
    }

    public void checkPlayerDistance()
    {
        if (myVector3D.distance(this.transform.position, enemy.transform.position) < 9)
        {
            resetPlayer();
            enemy.GetComponent<TankBuilder>().resetPlayer();
        }
    }

    public void Update()
    {
        checkPlayerDistance();
    }

}
