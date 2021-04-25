using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float speed = 20f;
    public Rigidbody rb;
    public int damage = 10;
    public GameObject sprengjan;
    public static int count;//klasabreyta


    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // klassik collision checker
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Ovinur")
        {
            count += 10;
            Destroy(collision.gameObject); //eyðir kassanum
            Sprengja(); // framkvaemir sprengju
            FindObjectOfType<GameManager>().CountPoints(1);

        }

        void Sprengja()
        {
            Instantiate(sprengjan, transform.position, transform.rotation);
        }
    }
}
