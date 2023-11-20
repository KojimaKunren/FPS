using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Player player;

    int score;
    Text scoreText;

    void Start()
    {
        scoreText = this.GetComponent<Text>();

    }

    void Update()
    {
        score = player.GetScore();
        scoreText.text = score + "";
    }
}
