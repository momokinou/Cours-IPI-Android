using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public Text score;
    private int scoreValue = 0;

    void Start()
    {
        
    }

    void Update()
    {
        score.text = "Deaths: " + scoreValue;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Respawn"))
        {
            scoreValue += 1;
        }
    }

}
