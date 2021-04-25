using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 100f;



    // Update is called once per frame
    void Update()
    {
        // biður ef að ytt er a takka
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // byr til  skot og hrada, eydir sidan skotinu ef 1sek
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * speed);
            Destroy(instBullet, 1f);//kúl eeytt eftir 1sek
           
        }
    }
}
