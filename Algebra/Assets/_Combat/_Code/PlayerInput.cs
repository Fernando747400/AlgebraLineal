using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3DLibrary myVector3D = new Vector3DLibrary();
    private bool ForwardInput, LeftInput, RightInput, FireInput;
    private float Cooldown = 5f;
    private float CooldownTimer;
    [Header ("Speeds")]
    [SerializeField] private float MoveSpeed = 10f;
    [SerializeField] private float RotationSpeed = 40f;
    [Header("Input Keys")]
    [SerializeField] private string ForwardKey;
    [SerializeField] private string LeftKey;
    [SerializeField] private string RightKey;
    [SerializeField] private string FireKey;
    [Header("Bullet")]
    [SerializeField] private GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(ForwardKey))
        {
            ForwardInput = true;
        }
        else ForwardInput = false;

        if (Input.GetKey(LeftKey))
        {
            LeftInput = true;
        }
        else LeftInput = false;

        if (Input.GetKey(RightKey))
        {
            RightInput = true;
        }
        else RightInput = false;

        if (Input.GetKey(FireKey))
        {
            FireInput = true;
        }
        else FireInput = false;
    }

    public void FixedUpdate()
    {
        if (ForwardInput)
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
        }

        if (LeftInput)
        {
            this.transform.rotation = Quaternion.Euler(myVector3D.transformVector(this.transform.rotation.eulerAngles, 0, -RotationSpeed * Time.deltaTime, 0));
        }

        if (RightInput)
        {
            this.transform.rotation = Quaternion.Euler(myVector3D.transformVector(this.transform.rotation.eulerAngles, 0, RotationSpeed * Time.deltaTime, 0));
        }

        if (FireInput)
        {
            if (Time.time > CooldownTimer)
            {
                Instantiate(bullet,transform.Find("Canon").transform);
                CooldownTimer = Time.time + Cooldown;
            }
        }
    }
}
