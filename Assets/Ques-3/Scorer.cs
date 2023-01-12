using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    TMP_Text scoreTxt;

    BallShooting ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            score++;
            scoreTxt.text = "Score : " + score;
            ball = collision.GetComponent<BallShooting>();
            ball.canShoot = false;
            StartCoroutine(CanShootAgain());
        }
    }
    IEnumerator CanShootAgain()
    {
        yield return new WaitForSeconds(3f);
        ball.ResetPos();
    }
}
