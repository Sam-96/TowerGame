using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetController : MonoBehaviour {

    public int _score = 0;
    public Text score;

    public void Start()
    {
        SetScoreText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if collision is a cannonball
        if (collision.gameObject.tag == "cannonBall")
        {
            _score++;
            SetScoreText();

        }
    }

    void SetScoreText()
    { 
            score.text = "Score: " + _score.ToString();
    }
   
}
