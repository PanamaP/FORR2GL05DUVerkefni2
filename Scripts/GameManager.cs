using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public int count;
    public Text CountScore;
    public Text HealthText;
    public AudioSource[] sounds;
    public AudioSource CoinAudio;
    public AudioSource DeathAudio;
    public Transform player;
    public int health = 100;

    private void Start()
    {
        // lagar að músin sé ekki að sýna sig eftir dauða
        Cursor.visible = true;
        Cursor.lockState = 0;


        sounds = GetComponents<AudioSource>();
        CoinAudio = sounds[0];
        DeathAudio = sounds[1];

        

    }
    
    // uppfærir breytu um stig
    public void CountPoints(int stig)
    {
        count = count + stig;
        SetCountText();
    }

    // texti
    public void SetCountText()
    {
        CountScore.text = "Stig: " + count.ToString();
    }

    // spilar hljóð
    public void CoinSound()
    {
        CoinAudio.Play();
    }

    // spilar hljóð
    public void DeathSound()
    {
        DeathAudio.Play();
    }

    // uppfærir texta og breytu um hversu mikið damage leikmadur tekur
    public void TakeDamage(int damage)
    {
       // Debug.Log("health er núna" + (health).ToString());
        health -= damage;
        HealthUpdate(health);
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
            health = 100;
            Bullet.count = 0;//núll stilli stigin 
            HealthUpdate(health);
        }

    }

    // uppfærir texta um líf
    public void HealthUpdate(int health)
    {
        HealthText.text = "Líf " + health.ToString();
    }

    public void EndGame()
    {
        // if setning svo leikurinn sé ekki endalaust endurræstur
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            SceneManager.LoadScene(2);
        }
    }

    // breyta sem endurræsir leikin
    public void Endurræsa()
    {
        SceneManager.LoadScene(1);
    }
}
