using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    string name;
    int score;

    int[] scores;

    int totalTime;

    int playerTagScore;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public User(string name, int[] scores, int totalTime, int playerTagScore)
    {
        this.name = name;
        this.scores = scores;
        this.totalTime = totalTime;
        this.playerTagScore = playerTagScore;
    }

    public string GetUserName()
    {
        return this.name;
    }

    public int[] GetScores()
    {
        return this.scores;
    }

    public int GetScore(int i)
    {
        return this.scores[i];
    }
}
