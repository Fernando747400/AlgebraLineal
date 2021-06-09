using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerpo : MonoBehaviour
{
    [SerializeField] private GameObject HeadPrefab;
    [SerializeField] private GameObject HeadToFollow;
    [SerializeField] private float followDistance = 2.0f;
    [SerializeField] private float followSpeed = 5.0f;

    public void Update()
    {
        followHead();
        checkHead();
    }

    public void followHead()
    {
        if (Vector3.Distance(this.transform.position,HeadToFollow.transform.position) > followDistance)
        {
            this.transform.LookAt(HeadToFollow.transform.position);
            this.transform.Translate(Vector3.forward*Time.deltaTime*followSpeed);
        }
    }

    public void splitHead()
    {
        Instantiate(HeadPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void checkHead()
    {
        if (HeadToFollow == null && !searchHead())
        {        
            splitHead();
        }
    }

    public bool searchHead()
    {
        bool answer = false;
        if (GameObject.Find("CentepideHead") == null)
        {
            answer = false;
        } else
        {
            HeadToFollow = GameObject.Find("CentepideHead").gameObject;
            answer = true;
        }
        return answer;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            splitHead();
        }
    }
}
