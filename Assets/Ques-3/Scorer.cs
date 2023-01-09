using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    TMP_Text scoreTxt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            score++;
            scoreTxt.text = "Score : " + score;
        }
    }
}
