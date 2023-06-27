using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    public byte[] playerScore = new byte[2];//0=�÷��̾�1,1= �÷��̾�2
    public AttackTurns attackInfo;//�� �Ͽ� ���� ������ true��, ���� �Ŀ��� false�� ��ȯ
    public GameObject ball;
    public Stats ballStat;
    public Stats OriginBallStat;
    public SpriteRenderer ballSR;
    [SerializeField]public Stats[] plrStat = new Stats[2];
    [SerializeField] public Stats[] plrOriginStat = new Stats[2];
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
        ResetStat();
    }
    public void ResetStat()
    {
        plrStat[0].size = plrOriginStat[0].size;
        plrStat[0].speed = plrOriginStat[0].speed;
        attackInfo.Players[0].transform.localScale = plrOriginStat[0].size;
        plrStat[1].size = plrOriginStat[1].size;
        plrStat[1].speed = plrOriginStat[1].speed;
        attackInfo.Players[1].transform.localScale = plrOriginStat[1].size;
        StopCoroutine(InvisibleBalls());
    }
    public void SetInvisible()
    {
        StartCoroutine(InvisibleBalls());
    }
    public GameObject ItemTargetOBJ(GameObject playerHaveitem)
    {
        if (playerHaveitem != attackInfo.Players[0])
        {
            return attackInfo.Players[0];
        }
        else
        {
            return attackInfo.Players[1];
        }
    }
    public Player ItemTargetPlayerCompo(GameObject playerHaveitem) 
    {
        if (playerHaveitem != attackInfo.Players[0])
        {
            return attackInfo.Players[0].GetComponent<Player>();
        }
        else
        {
            return attackInfo.Players[1].GetComponent<Player>();
        }
    }
    public void SetPlayer(GameObject player)
    {
        attackInfo.attackPlayer = player;
        attackInfo.attackTurn = true;
    }
    public IEnumerator InvisibleBalls()
    {
        float timer = 0;
        float targetTime = 2f;
        bool needPlus = true;
        while (true)
        {
            if (needPlus)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            ballSR.color = new Color(ballSR.color.r, ballSR.color.g, ballSR.color.b, timer*(1/targetTime));
            yield return null;
            if (timer>=targetTime||timer<=0)
            {
                if (needPlus)
                {
                    needPlus = false;
                }
                else
                {
                    needPlus = true;
                }
            }
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
