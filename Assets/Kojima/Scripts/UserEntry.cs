using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserEntry : MonoBehaviour
{
    User user;

    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField passInput;

    string name;
    string pass;
    string date;



    public void SendEntryUser()
    {
        StartCoroutine(Entry_User());
        SetUser();
    }
    public void Inputdata()
    {
        name = nameInput.text;
        pass = passInput.text;
        date = System.DateTime.Now.ToString();
    }

    public IEnumerator Entry_User()
    {
        string url = "http://localhost/fps/register_user.py";

        WWWForm form = new WWWForm();
        form.AddField("player_name", name);
        form.AddField("player_pass", pass);
        form.AddField("created_date", date);

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

    void SetUser()
    {
        int[] scores = new int[] { 000, 000, 000 };
        int totalTime = 00;

        int playerTagScore = 00;


        user = new User(name, scores, totalTime, playerTagScore);
        DontDestroyOnLoad(user);
    }
}
