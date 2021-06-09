using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject PlayerOne;
    private GameObject PlayerTwo;
    private GameObject CameraOne;
    private Vector3DLibrary myVector3D = new Vector3DLibrary();
    private AudioSource audioSource;
    private Vector3 initialPosition;
    [Header("Audio clips")]
    [SerializeField] AudioClip fire;
    [SerializeField] AudioClip explosion;
    [Header("Bullet behavior")]
    [SerializeField] float destroyDistance = 60f;
    [SerializeField] float knockBack = 40f;

    public void Start()
    {
        initialPosition = this.transform.position;
        PlayerOne = GameObject.Find("PlayerOne");
        PlayerTwo = GameObject.Find("PlayerTwo");
        CameraOne = PlayerOne.transform.Find("Canon").gameObject;
        audioSource = this.GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(fire, CameraOne.transform.position);
    }

    void Update()
    {
        checkDistance();
        this.transform.Translate(Vector3.forward * Time.deltaTime * 50f);
        destroyFar();
    }

    void checkDistance()
    {
        if (myVector3D.distance(this.transform.position, PlayerOne.transform.position) < 5.5 || myVector3D.distance(this.transform.position, PlayerTwo.transform.position) < 5.5)
        {
            if (myVector3D.distance(this.transform.position, PlayerOne.transform.position) < 5.5)
            {
                PlayerOne.GetComponent<Rigidbody>().AddForce(-myVector3D.normalize(this.transform.position - PlayerOne.transform.position) * knockBack, ForceMode.Impulse);
                AudioSource.PlayClipAtPoint(explosion, CameraOne.transform.position,1.0f);
                PlayerPrefs.SetInt("PlayerTwoScore", PlayerPrefs.GetInt("PlayerTwoScore") + 1);             
            }
            else if (myVector3D.distance(this.transform.position, PlayerTwo.transform.position) < 5.5)
            {
                PlayerTwo.GetComponent<Rigidbody>().AddForce(-myVector3D.normalize(this.transform.position - PlayerTwo.transform.position) * knockBack, ForceMode.Impulse);
                AudioSource.PlayClipAtPoint(explosion, CameraOne.transform.position, 1.0f);
                PlayerPrefs.SetInt("PlayerOneScore", PlayerPrefs.GetInt("PlayerOneScore") + 1);
            }
            checkHighScore();
            Destroy(this.gameObject);
        }
    }

    void destroyFar()
    {
        if (myVector3D.distance(initialPosition, this.transform.position)> destroyDistance)
        {
            Destroy(this.gameObject);
        }
    }

    void checkHighScore()
    {
        if (PlayerPrefs.GetInt("PlayerOneHighScore") < PlayerPrefs.GetInt("PlayerOneScore"))
        {
            PlayerPrefs.SetInt("PlayerOneHighScore", PlayerPrefs.GetInt("PlayerOneScore"));
        }
        if (PlayerPrefs.GetInt("PlayerTwoHighScore") < PlayerPrefs.GetInt("PlayerTwoScore"))
        {
            PlayerPrefs.SetInt("PlayerTwoHighScore", PlayerPrefs.GetInt("PlayerTwoScore"));
        }
        PlayerPrefs.Save();
    }

  
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            AudioSource.PlayClipAtPoint(explosion, CameraOne.transform.position, 1.0f);
            Destroy(this.gameObject);
        }
    }
   
}
