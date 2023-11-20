using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameText : MonoBehaviour
{
    [SerializeField] private Player player; //プレイヤー格納用

    string name; //プレイヤー名格納用
    Text nameText; //ネームテキスト格納用

    void Start()
    {
        nameText = this.GetComponent<Text>(); //ネームテキストのテキストコンポーネントを取得
    }

    void Update()
    {
        name = player.GetName(); //プレイヤー名を取得
        nameText.text = name; //プレイヤー名を表示
    }
}
