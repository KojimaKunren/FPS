using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    int currentScore;

    float currentTime;

    int[] scores;

    [SerializeField] private Text userNameText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;

    [SerializeField] private GameObject newRecordPanel;

    [SerializeField] private GameObject RankingCanvas;


    void Start()
    {
        //プレイヤー名表示
        userNameText = gameObject.GetComponent<Text>();
        userNameText.text = GetComponent<User>().GetUserName();

        //今回のゲームスコアを表示
        currentScore = PlayerPrefs.GetInt("score");
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = ($"Current Score: {currentScore}");

        currentTime = PlayerPrefs.GetFloat("time");
        timeText = gameObject.GetComponent<Text>();
        int minutes = (int)currentTime / 60;
        float seconds = currentTime % 60.0f;
        timeText.text = ($"Current Survival Time: {minutes}:{seconds}");

        scores = GetComponent<User>().GetScores();
        scores = CalcHighScore();

        if (CheckNewRecord())
        {
            newRecordPanel.SetActive(true);
        }
    }

    int[] CalcHighScore()
    {
        int[] newscores = new int[3];
        List<int> highscores = new List<int>();
        foreach (int s in scores)
        {
            highscores.Add(s);
        }
        highscores.Add(currentScore);

        for (int i = 0; i < 3; i++)
        {
            int highscore = highscores.Max();
            newscores.Append(highscore);
            highscores.Remove(i);
        }

        scores = newscores;

        return scores;
    }

    bool CheckNewRecord()
    {
        bool isNewRecord = false;
        if (currentScore > scores[0])
        {
            isNewRecord = true;
        }

        return isNewRecord;
    }
}
