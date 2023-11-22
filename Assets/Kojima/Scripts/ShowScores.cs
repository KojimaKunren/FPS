using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScores : MonoBehaviour
{
    [SerializeField] private GameObject scorePanel;

    void Start()
    {
        scorePanel.gameObject.SetActive(false);
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
    }
}
