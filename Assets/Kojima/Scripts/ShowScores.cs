using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScores : MonoBehaviour
{
    User user;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject scorePanel;

    void Start()
    {
        scorePanel.gameObject.SetActive(false);
        user = GameObject.Find("UserDataObject").GetComponent<User>();
    }
    public void ShowScore()
    {
        if (!scorePanel.gameObject.activeSelf)
        {
            scorePanel.gameObject.SetActive(true);
        }
        else
        {
            scorePanel.gameObject.SetActive(false);
        }

        makeScores();
    }

    public void makeScores()
    {
        scoreText.text = $"HighScore1: {user.GetScore(0)} \n HighScore2: {user.GetScore(1)} \n HighScore3: {user.GetScore(2)} \n \n TotalTime: {user.GetTotalTime()} \n PlayerTag: {user.GetPlayerTagCount()}";
    }

}
