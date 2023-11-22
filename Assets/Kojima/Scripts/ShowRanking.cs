using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRanking : MonoBehaviour
{
    [SerializeField] private GameObject rankingPanel;
    public void ShowingRanking()
    {
        if (rankingPanel.gameObject.activeSelf)
        {
            rankingPanel.gameObject.SetActive(true);
        }
        else
        {
            rankingPanel.gameObject.SetActive(false);
        }
    }
}
