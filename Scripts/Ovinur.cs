using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ovinur : MonoBehaviour
{
    
    public GameObject daudi;
    private Transform player;
    private Rigidbody rb;
    private Vector3 movement;
    public float hradi = 5f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = FindObjectOfType<GameManager>().player;
        //texti.text = "Líf " + health.ToString();
    }

    // allt til að gera einfaldan ovin sem eltir stadsetningu leikmanns
    //-------------------------------------------------------------------------------------
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * hradi * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    //-------------------------------------------------------------------------------------

    // collision checker vid spilara
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            FindObjectOfType<GameManager>().TakeDamage(10);
            gameObject.SetActive(false);
            FindObjectOfType<GameManager>().CountPoints(-1);
        }
    }
    

}
