using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Vector3DLibrary VectorCalculation = new Vector3DLibrary();
    [SerializeField] GameObject target;
    public void Start()
    {
        InvokeRepeating("RotateCamera",1,0.05f);
    }
    // Update is called once per frame
    void RotateCamera()
    {
        this.gameObject.gameObject.transform.position = VectorCalculation.rotateVectorAxisY(this.gameObject.transform.position, 1);
        this.gameObject.transform.LookAt(target.gameObject.transform);
    }
}
