using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    User user;

    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField passInput;

    string name;

    string pass;

    public void SendLoginUser()
    {
        StartCoroutine(Login_User());
    }

    public void InputData()
    {
        name = nameInput.text;
        pass = passInput.text;
    }

    public IEnumerator Login_User()
    {
        string url = "http://localhost/fps/login_player.py";

        WWWForm form = new WWWForm();
        form.AddField("player_name", name);
        form.AddField("player_pass", pass);

        using (UnityWebRequest uwr = UnityWebRequest.Post(url, form))
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
                    Debug.Log("");
                    // user = JsonUtility.FromJson<User>(responseText);
                    break;
            }
        }
    }
}
