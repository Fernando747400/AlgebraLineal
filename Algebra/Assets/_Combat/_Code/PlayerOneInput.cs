using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneInput : MonoBehaviour
{
    private Vector3DLibrary myVector3D = new Vector3DLibrary();
    private float MoveSpeed = 10f;
    private float RotationSpeed = 40f;
    private float ForwardInput,LeftInput,RightInput;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            ForwardInput = 1;
        }
        else ForwardInput = 0;

        if (Input.GetKey("a"))
        {
            LeftInput = 1;
        }
        else LeftInput = 0;

        if (Input.GetKey("d"))
        {
            RightInput = 1;
        }
        else RightInput = 0;
    }

    public void FixedUpdate()
    {
        if (ForwardInput == 1)
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
        }

        if (LeftInput == 1)
        {
            this.transform.rotation = Quaternion.Euler(myVector3D.transformVector(this.transform.rotation.eulerAngles, 0, -RotationSpeed * Time.deltaTime, 0));
        }

        if (RightInput == 1)
        {
            this.transform.rotation = Quaternion.Euler(myVector3D.transformVector(this.transform.rotation.eulerAngles, 0, RotationSpeed * Time.deltaTime, 0));
        }


    }
}
