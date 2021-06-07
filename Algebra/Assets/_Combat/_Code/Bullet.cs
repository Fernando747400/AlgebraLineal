using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * 50f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.gameObject.name == "PlayerTwo")
        {
            Destroy(this.gameObject);
            Debug.Log("I hit a player two");
        }

        if (collision.gameObject.transform.parent.gameObject.name == "PlayerOne")
        {
            Destroy(this.gameObject);
            Debug.Log("I hit a player one");
        }
    }
}
