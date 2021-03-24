using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikCube : MonoBehaviour
{
    MakeCube makecube;
    GameObject cube;
    public void Start()
    {
        for(int z =0; z < 3; z++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    cube = new GameObject();
                    Instantiate(cube);
                    cube.AddComponent<MakeCube>();
                    cube.transform.position = new Vector3(x,y,z);
                }
            }
        }
        
    }
}
