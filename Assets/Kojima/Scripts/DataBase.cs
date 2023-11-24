using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class DataBase : MonoBehaviour
{
    public User[] users;
    public GameObject scorePrefab;
    public Transform content;

    public IEnumerator GetRanking()
    {
        string url = "http://localhost/FPS/get_ranking.py";

        using (UnityWebRequest uwr = UnityWebRequest.Get(url))
        {
            yield return uwr.SendWebRequest();
            switch (uwr.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("Error: " + uwr.error);
                    break;
                default:
                    string responseText = uwr.downloadHandler.text;
                    Ranking ranking = JsonUtility.FromJson<Ranking>(responseText);
                    users = ranking.result;
                    break;
            }
        }

        ShowRanking();
    }

    void ShowRanking()
    {
        for (int i = 0; i < users.Length; i++)
        {
            User user = users[i];
            GameObject score = Instantiate(scorePrefab, content);
            Text scoreText = score.GetComponent<Text>();
            scoreText.text = $"{i + 1:000}位{user.name}:{user.GetScore(0)}";
        }
    }
}
