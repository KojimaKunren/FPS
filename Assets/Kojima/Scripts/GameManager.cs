using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    Player player;
    public GameObject playerObject;
    public GameObject mainCanvas;
    public GameObject gameEndCanvas;

    public GameObject gameOverTextPanel;

    public GameObject gameClearTextPanel;

    public float timer;

    public Text countdownText;

    int minute;
    int seconds;


    public Color endColor;
    void Start()
    {
        mainCanvas.gameObject.SetActive(true);
        gameEndCanvas.SetActive(false); //ゲームーオーバー用キャンバスをオフに
        gameOverTextPanel.SetActive(false);
        gameClearTextPanel.SetActive(false);
        player = playerObject.gameObject.GetComponent<Player>();
    }

    void Update()
    {
        CountdownTimer();
        ChangeTimerColor();

        if (player.IsDead())
        {
            EndGame();
            Destroy(playerObject);
            gameOverTextPanel.SetActive(true);
            return;
        }

        if (timer <= 0 && !player.IsDead())
        {
            EndGame();
            gameClearTextPanel.SetActive(true);
        }
    }

    //ゲームオーバーボタン設定用
    // public void OnGameOverButtonClicked()
    // {
    //     SceneManager.LoadScene("GameOver");

    // }

    public void EndGame()
    {
        PlayerPrefs.SetFloat("time", timer);
        PlayerPrefs.SetInt("score", player.GetScore());
        Cursor.lockState = CursorLockMode.None;
        enabled = false;
        gameEndCanvas.SetActive(true);
        Invoke("MoveResult", 3.0f);
    }

    public void MoveResult()
    {
        SceneManager.LoadScene("Result");
    }

    public void CountdownTimer()
    {
        if (timer <= 0.0f)
        {
            return;
        }
        timer -= Time.deltaTime;
        minute = (int)timer / 60;
        seconds = (int)timer % 60;

        countdownText.text = string.Format("{0}:{1}", minute, seconds);
    }

    public void ChangeTimerColor()
    {
        if (timer <= 30)
        {
            countdownText.color = endColor;
        }
    }
}
