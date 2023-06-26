using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    public byte[] playerScore = new byte[2];//0=플레이어1,1= 플레이어2
    public static GameManager GMinstance()
    {
        return GM;
    }
    void Awake()
    {
        if(GM == null)
        {
            GM = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if(GM != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void GameOver(bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            playerScore[0] += 1;
        }
        else
        {
            playerScore[1] += 1;
        }
        UIManager.UIinstance().scoreText[0].text = playerScore[0].ToString();
        UIManager.UIinstance().scoreText[1].text = playerScore[1].ToString();
    }
}
