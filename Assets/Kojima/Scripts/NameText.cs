using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameText : MonoBehaviour
{
    public Player player;

    string name;
    Text nameText;

    void Start()
    {
        nameText = this.GetComponent<Text>();

    }

    void Update()
    {
        name = player.GetName();
        nameText.text = name;
    }
}
