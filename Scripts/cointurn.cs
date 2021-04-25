using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cointurn : MonoBehaviour
{
    // snyr peninginum i hringi
    private void Update()
    {
        transform.Rotate(new Vector3(0, 80, 0) * Time.deltaTime);
    }

    // heldur utan um arekstur a coin
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            
            gameObject.SetActive(false);
            FindObjectOfType<GameManager>().CountPoints(1);
            FindObjectOfType<GameManager>().CoinSound();
        }
    }

}
