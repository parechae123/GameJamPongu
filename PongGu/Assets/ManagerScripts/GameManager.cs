using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    public byte[] playerScore = new byte[2];//0=플레이어1,1= 플레이어2
    public AttackTurns attackInfo;//내 턴에 공격 전에는 true를, 공격 후에는 false를 반환
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
        //씬전환 추가 후에 공격권 변경 해줘야함,attackplayer체인지도 필요
        attackInfo.attackTurn = true;
        if (attackInfo.attackPlayer != attackInfo.Players[0])
        {
            attackInfo.attackPlayer = attackInfo.Players[0];
        }
        else
        {
            attackInfo.attackPlayer = attackInfo.Players[1];
        }
    }
}
[System.Serializable]
public class AttackTurns
{
    public bool attackTurn;//내 턴에 공격 전에는 true를, 공격 후에는 false를 반환
    public GameObject attackPlayer; //공격권을 가진 플레이어
    public GameObject[] Players = new GameObject[2]; //플레이어 정보값,[0]플레이어1,[1]플레이어2
}
