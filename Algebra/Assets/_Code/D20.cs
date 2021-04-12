using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D20 : MonoBehaviour
{
    public Material material;

    Mesh mesh;
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    Vector3[] vertex;
    public Texture texture;
    int[] triangles;

    public void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();

        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        meshFilter.mesh = mesh;

        vertex = new[]
        {
            //cara 1
            new Vector3(0,0,0),//0 A
            new Vector3(1,0,0), //1 B
            new Vector3(0.5f,0,0.87f), //2 C
        
            //Cara 2
            new Vector3(0,0,0),//3 A
            new Vector3(1,0,0), //4 B
            new Vector3(0.5f,0.58f,-0.65f), //5 D
             
            //Cara 3
            new Vector3(0,0,0),//6 A
            new Vector3(0.5f,0.58f,-0.65f), //7 D
            new Vector3(-0.31f,0.93f,-0.18f), //8 G

            //Cara 4
            new Vector3(0,0,0),//9 A
            new Vector3(-0.31f,0.93f,-0.18f), //10 G
            new Vector3(-0.31f,0.58f,0.76f), //11 F
          
            //Cara 5
            new Vector3(0,0,0),//12 A
            new Vector3(-0.31f,0.58f,0.76f), //13 F
            new Vector3(0.5f,0,0.87f), //14 C
           
            //Cara 6
            new Vector3(1,0,0),//15 B
            new Vector3(0.5f,0.58f,-0.65f), //16 D
            new Vector3(1.31f,0.93f,-0.18f), //17 H

             //Cara 7
            new Vector3(0.5f,0.58f,-0.65f),//18 D
            new Vector3(1.31f,0.93f,-0.18f), //19 H
            new Vector3(0.5f,1.51f,-0.29f), //20 J

            //Cara 8
            new Vector3(0.5f,0.58f,-0.65f),//21 D
            new Vector3(0.5f,1.51f,-0.29f), //22 J
            new Vector3(-0.31f,0.93f,-0.18f), //23 G

            //Cara 9
            new Vector3(0,1.51f,0.58f),//24 L
            new Vector3(0.5f,1.51f,-0.29f), //25 J
            new Vector3(-0.31f,0.93f,-0.18f), //26 G

             //Cara 10
            new Vector3(0,1.51f,0.58f),//27 L
            new Vector3(-0.31f,0.58f,0.76f), //28 F
            new Vector3(-0.31f,0.93f,-0.18f), //29 G

             //Cara 11
            new Vector3(0,1.51f,0.58f),//30 L
            new Vector3(-0.31f,0.58f,0.76f), //31 F
            new Vector3(0.5f,0.93f,1.22f), //32 I

             //Cara 12
            new Vector3(0.5f,0,0.87f),//33 C
            new Vector3(-0.31f,0.58f,0.76f), //34 F
            new Vector3(0.5f,0.93f,1.22f), //35 I

            //Cara 13
            new Vector3(0.5f,0,0.87f),//36 C
            new Vector3(1.31f,0.58f,0.76f), //37 E
            new Vector3(0.5f,0.93f,1.22f), //38 I

            //Cara 14
            new Vector3(0.5f,0,0.87f),//39 C
            new Vector3(1.31f,0.58f,0.76f), //40 E
            new Vector3(1,0,0), //41 B

            //Cara 15
            new Vector3(1.31f,0.93f,-0.18f),//42 H
            new Vector3(1.31f,0.58f,0.76f), //43 E
            new Vector3(1,0,0), //44 B

            //Cara 16
            new Vector3(1.31f,0.93f,-0.18f),//45 H
            new Vector3(1.31f,0.58f,0.76f), //46 E
            new Vector3(1,1.51f,0.58f), //46 K

            //Cara 17
            new Vector3(1.31f,0.93f,-0.18f),//47 H
            new Vector3(0.5f,1.51f,-0.29f), //48 J
            new Vector3(1,1.51f,0.58f), //49 K

            //Cara 18
            new Vector3(0,1.51f,0.58f),//50 L
            new Vector3(0.5f,1.51f,-0.29f), //51 J
            new Vector3(1,1.51f,0.58f), //52 K

            //Cara 19
            new Vector3(0,1.51f,0.58f),//53 L
            new Vector3(0.5f,0.93f,1.22f), //54 I
            new Vector3(1,1.51f,0.58f), //55 K

            //Cara 20
            new Vector3(1.31f,0.58f,0.76f),//53 E
            new Vector3(0.5f,0.93f,1.22f), //54 I
            new Vector3(1,1.51f,0.58f), //55 K          
        };


        meshFilter.mesh.vertices = vertex;

        triangles = new[]
        {
            0,1,2,  // cara 1
            3,5,4,  //cara 2 
            6,8,7, //cara 3
            11,10,9, //cara 4
            14,13,12, //cara 5
            16,17,15, //cara 6
            18,20,19, //cara 7
            21,23,22, //cara 8
            24,25,26, //cara 9
            27,29,28, //cara 10
            30,31,32, //cara 11
            33,35,34, //cara 12
            36,37,38, //cara 13
            39,41,40, //cara 14
            42,43,44, //cara 15
            45,47,46, //cara 16
            48,49,50, //cara 17
            51,53,52, //cara 18
            54,55,56, //cara 19
            57,59,58, //cara 20
        };

        Vector2[] uvs = {
            //cara 1
            new Vector2(0.9090f,0),
            new Vector2(0.8181f,0.3333f),
            new Vector2(1,0.3333f),

            //cara 2
            new Vector2(0.7272f,0),
            new Vector2(0.8181f,0.3333f),
            new Vector2(0.6363f,0.3333f),

            //cara 3
            new Vector2(0.5454f,0),
            new Vector2(0.6363f,0.3333f),
            new Vector2(0.4545f,0.3333f),

            //cara 4
            new Vector2(0.3636f,0),
            new Vector2(0.4545f,0.3333f),
            new Vector2(0.2727f,0.3333f),

            //cara 5
            new Vector2(0.1818f,0),
            new Vector2(0.2727f,0.3333f),
            new Vector2(0.0909f,0.3333f),

            //cara 6
            new Vector2(0.6363f,0.3333f),
            new Vector2(0.8181f,0.3333f),
            new Vector2(0.7272f,0.6666f),

            //cara 7
            new Vector2(0.6363f,0.3333f),
            new Vector2(0.7272f,0.6666f),
            new Vector2(0.5454f,0.6666f),

            //cara 8
            new Vector2(0.6363f,0.3333f),
            new Vector2(0.5454f,0.6666f),
            new Vector2(0.4545f,0.3333f),

            //cara 9
            new Vector2(0.3636f,0.6666f),
            new Vector2(0.5454f,0.6666f),
            new Vector2(0.4545f,0.3333f),

            //cara 10
            new Vector2(0.3636f,0.6666f),
            new Vector2(0.2727f,0.3333f),
            new Vector2(0.4545f,0.3333f),

            //cara 11
            new Vector2(0.3636f,0.6666f),
            new Vector2(0.2727f,0.3333f),
            new Vector2(0.1818f,0.6666f),

            //cara 12
            new Vector2(0.0909f,0.3333f),
            new Vector2(0.2727f,0.3333f),
            new Vector2(0.1818f,0.6666f),

            //cara 13
            new Vector2(0.0909f,0.3333f),
            new Vector2(0,0.6666f),
            new Vector2(0.1818f,0.6666f),

            //cara 14
            new Vector2(1,0.3333f),
            new Vector2(0.9090f,0.6666f),
            new Vector2(0.8181f,0.3333f),

            //cara 15
            new Vector2(0.7272f,0.6666f),
            new Vector2(0.9090f,0.6666f),
            new Vector2(0.8181f,0.3333f),

            //cara 16
            new Vector2(0.9090f,0.6666f),
            new Vector2(0.7272f,0.6666f),
            new Vector2(0.8181f,1),

            //cara 17
            new Vector2(0.7272f,0.6666f),
            new Vector2(0.5454f,0.6666f),
            new Vector2(0.6363f,1),

            //cara 18
            new Vector2(0.3636f,0.6666f),
            new Vector2(0.5454f,0.6666f),
            new Vector2(0.4545f,1),

            //cara 19
            new Vector2(0.3636f,0.6666f),
            new Vector2(0.1818f,0.6666f),
            new Vector2(0.2727f,1),

            //cara 20
            new Vector2(0,0.6666f),
            new Vector2(0.1818f,0.6666f),
            new Vector2(0.0909f,1)
        };

        meshFilter.mesh.triangles = triangles;
        meshFilter.mesh.uv = uvs;
        meshFilter.mesh.Optimize();
        meshFilter.mesh.RecalculateNormals();
    }
}
