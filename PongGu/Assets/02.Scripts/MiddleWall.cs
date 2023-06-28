using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MiddleWall : MonoBehaviour
{
    public GameObject[] wall = new GameObject[2];
    Sequence sequence;
    public GameObject rayObj;
    public GameObject ball;
    public BallTester ballSCR;
    public bool boundaries;
    public LayerMask ballLayer;
    public int sensingNum;      //레이캐스트 감지되는 횟수
    public Transform ballPosInit;

    GameManager GameManager => GameManager.GMinstance();
    // Start is called before the first frame update
    void Start()
    {
        ballSCR = ball.GetComponent<BallTester>();
    }

    // Update is called once per frame
    void Update()
    {
        boundaries = Physics2D.Raycast(rayObj.transform.position, rayObj.transform.up, 50, ballLayer);
        
        if (boundaries && sensingNum == 0)
        {
            sensingNum++;
            Debug.Log("반응");
            StartCoroutine(Wall1());
            StartCoroutine(Wall2()); 
        }
        if(!boundaries && sensingNum == 1)
        {
            sensingNum++;
        }
        if(sensingNum == 2 && boundaries)
        {
            Debug.Log("앙");
            ballSCR.rb.velocity = Vector2.zero;
            ball.transform.position = ballPosInit.position;
            ballSCR.CC.enabled = false;
            ballSCR.isPlayerAtached = true;
            GameManager.GMinstance().AttackerChange();
            sensingNum = 0;
        }
    }
    public IEnumerator Wall1()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject temp = wall[0];
        temp.gameObject.SetActive(true);
        sequence = DOTween.Sequence();
        sequence.Append(temp.transform.DOScale(new Vector2(0.5f, 0.5f), 0.7f));
        sequence.Append(temp.transform.DOScale(new Vector2(0.4f, 0.4f), 0.3f));
    }
    public IEnumerator Wall2()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject temp = wall[1];
        temp.gameObject.SetActive(true);
        sequence = DOTween.Sequence();
        sequence.Append(temp.transform.DOScale(new Vector2(0.5f, 0.5f), 0.7f));
        sequence.Append(temp.transform.DOScale(new Vector2(0.4f, 0.4f), 0.3f));
    }
}
