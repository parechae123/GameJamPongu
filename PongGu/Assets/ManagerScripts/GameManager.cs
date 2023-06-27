using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    public byte[] playerScore = new byte[2];//0=�÷��̾�1,1= �÷��̾�2
    public AttackTurns attackInfo;//�� �Ͽ� ���� ������ true��, ���� �Ŀ��� false�� ��ȯ
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
        //����ȯ �߰� �Ŀ� ���ݱ� ���� �������,attackplayerü������ �ʿ�
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
    public bool attackTurn;//�� �Ͽ� ���� ������ true��, ���� �Ŀ��� false�� ��ȯ
    public GameObject attackPlayer; //���ݱ��� ���� �÷��̾�
    public GameObject[] Players = new GameObject[2]; //�÷��̾� ������,[0]�÷��̾�1,[1]�÷��̾�2
}
