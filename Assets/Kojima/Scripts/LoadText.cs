using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    [SerializeField] private TextMeshProUGUI backText;
    private string textData;
    private string[] splitText;
    private Vector3 textPosition;
    float posX;
    float posY;

    void Start()
    {
        textData = textFile.text;
        splitText = textData.Split(char.Parse("\n"));
        textPosition = backText.gameObject.GetComponent<Transform>().localPosition;
        backText.text = splitText[0];
        StartCoroutine(ChangeText());
    }

    void Update()
    {
        if (textPosition.x < 150)
        {
            posX = textPosition.x += 0.1f;
        }
        else
        {
            posX = 0.0f;
        }
        if (textPosition.y < 150)
        {
            posY = textPosition.y += 0.1f;
        }
        else
        {
            posY = 0.0f;
        }
        backText.gameObject.transform.localPosition = new Vector3(posX, posY, textPosition.z);
    }

    IEnumerator ChangeText()
    {
        for (int i = 1; i < splitText.Length; i++)
        {
            yield return new WaitForSeconds(5.0f);
            backText.text = splitText[i];
        }
    }
}
