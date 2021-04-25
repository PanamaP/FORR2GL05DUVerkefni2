using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController lentur;
    private Rigidbody leikmadur;
    public float currYPos;
    public float startYPos;
    public float endYPos;
    private float heightToKill = 25f;
    

    void Start()
    {
        leikmadur = GetComponent<Rigidbody>();
        lentur = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // stanlaust að uppfæra y-ás stöðu spilara
        currYPos = leikmadur.position.y;

        // ef spilari ýtir á space til að hoppa er tekið inn hvaða hæð er hoppað frá
        if (Input.GetKey(KeyCode.Space) && lentur.isGrounded)
        {
            startYPos = leikmadur.position.y;
        } else if(!lentur.isGrounded)
        {
            endYPos = leikmadur.position.y;
        }

        // ef hæðin sem hoppað er frá er meiri en heightToKill þar sem leikmaður lendir, þá deyr hann
        if (lentur.isGrounded)
        {
            if (startYPos - endYPos > heightToKill)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }

        // ef leikmaður hoppar útaf mappinu þá deyr hann eða að fer of djúpt í vatn
        if (leikmadur.position.y < 83f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    


        
}
