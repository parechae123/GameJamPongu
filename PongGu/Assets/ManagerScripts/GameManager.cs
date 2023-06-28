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
    public BallTester BallSCR;
    private bool BallInvisible = true;
    public Transform ballPosInit;
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
        if (!isPlayerOne)
        {
            playerScore[0] += 1;
        }
        else
        {
            playerScore[1] += 1;
        }
        UIManager.UIinstance().ChangeScore(playerScore[0], playerScore[1],isPlayerOne);
        //����ȯ �߰� �Ŀ� ���ݱ� ���� �������,attackplayerü������ �ʿ�
        attackInfo.attackTurn = true;
        Debug.Log("GameOver");
        if (attackInfo.attackPlayer != attackInfo.Players[0])
        {
            attackInfo.attackPlayer = attackInfo.Players[0];
        }
        else
        {
            attackInfo.attackPlayer = attackInfo.Players[1];
        }
        ResetStat();
        ball.transform.position = ballPosInit.position;

    }
    public void AttackerChange()
    {
        Debug.Log("ATTKChange");
        if (attackInfo.attackPlayer != attackInfo.Players[0])
        {
            attackInfo.attackPlayer = attackInfo.Players[0];
        }
        else
        {
            attackInfo.attackPlayer = attackInfo.Players[1];
        }
        attackInfo.attackTurn = true;
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
        ballStat.speed = OriginBallStat.speed;
        ball.transform.localScale = OriginBallStat.size;
        ballStat.size = OriginBallStat.size;
        StopCoroutine(InvisibleBalls());
        BallInvisible = true;
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
    public Stats ItemTargetPlrSpeed(GameObject playerHaveitem)
    {
        if (playerHaveitem != attackInfo.Players[0])
        {
            return plrStat[0];
        }
        else
        {
            return plrStat[1];
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
        if (attackInfo.attackPlayer == attackInfo.Players[0])
        {
            UIManager.UIinstance().FirstAttackItem(true);
        }
        else
        {
            UIManager.UIinstance().FirstAttackItem(false);
        }
    }
    public void BallSpeedSet()
    {
        ballStat.speed = OriginBallStat.speed * 1.5f;
        BallSCR.SetItemSpeed();
    }
    public IEnumerator InvisibleBalls()
    {
        if (!BallInvisible)
        {
            Debug.Log("투명화 막음");
            yield break;
        }
        Debug.Log("투명화 시작");
        BallInvisible = false;
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
            if (BallInvisible)
            {
                Debug.Log("투명화 해제");
                ballSR.color = new Color(ballSR.color.r, ballSR.color.g, ballSR.color.b, 1);
                yield break;
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
