using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager UI;
    public TextMeshProUGUI[] scoreText = new TextMeshProUGUI[2];
    //0�� ���� �÷��̾� 1�� ������ �÷��̾�
    public static UIManager UIinstance()
    {
        return UI;
    }
    void Awake()
    {
        if (UI == null)
        {
            UI = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (UI != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void ChangeScore(byte plrOneScore,byte plrTwoScore)
    {
        scoreText[0].text = plrOneScore.ToString();
        scoreText[1].text = plrTwoScore.ToString();
    }
}
