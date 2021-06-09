using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeza : MonoBehaviour
{
    [SerializeField] private GameObject shroomPrefab;
    [SerializeField] private float playRange = 80f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float offset = 5.0f;
    private bool goingRight;
    private bool goingLeft;


    public void Start()
    {
        goingLeft = false;
        goingRight = true;
    }
    public void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        checkBorder();
    }

    public void checkBorder()
    {
        if (this.transform.position.x < -playRange && goingLeft)
        {
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z -offset );
            this.transform.rotation = Quaternion.Euler(0,90,0);
            goingRight = true;
            goingLeft = false;
        }

        if (this.transform.position.x > playRange && goingRight)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z -offset);
            this.transform.rotation = Quaternion.Euler(0, -90, 0);
            goingRight = false;
            goingLeft = true;
        }
    }

    public void finishHead()
    {
        Instantiate(shroomPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            finishHead();
        }
    }

}
