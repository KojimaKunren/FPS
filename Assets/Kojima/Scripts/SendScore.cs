using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendScore : MonoBehaviour
{
    public IEnumerator SendingScore()
    {
        string url = "http://localhost/FPS/send_score.py";
        WWWForm form = new WWWForm();
        form.AddField("score", PlayerPrefs.GetInt("HighScore"));

        using (UnityWebRequest uwr = UnityWebRequest.Post(url, form))
        {

            yield return uwr.SendWebRequest();
            switch (uwr.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("Error: " + uwr.error);
                    break;
            }
        }
    }
}
