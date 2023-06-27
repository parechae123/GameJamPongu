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
    public bool boundaries;
    public LayerMask ballLayer;
    public int sensingNum;      //레이캐스트 감지되는 횟수
    public Transform ballPosInit;

    GameManager GameManager => GameManager.GMinstance();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(rayObj.transform.position, rayObj.transform.up, Color.red, 0);
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
            ball.transform.position = ballPosInit.position;
            sensingNum = 0;
        }
        
    }
    public IEnumerator Wall1()
    {

        GameObject temp = Instantiate(wall[1], wall[1].transform.position, wall[1].transform.rotation);
        sequence = DOTween.Sequence();
        sequence.Append(temp.transform.DOScale(new Vector2(1.3f, 1.3f), 0.7f));
        sequence.Append(temp.transform.DOScale(new Vector2(1, 1), 0.3f));

        yield return new WaitForSeconds(0.5f);
        if (!temp.TryGetComponent<BoxCollider2D>(out BoxCollider2D bc2))
        {
            temp.AddComponent<BoxCollider2D>();
        }
        
    }
    public IEnumerator Wall2()
    {
        GameObject temp = Instantiate(wall[0], wall[0].transform.position, wall[0].transform.rotation);
        sequence = DOTween.Sequence();
        sequence.Append(temp.transform.DOScale(new Vector2(1.3f, 1.3f), 0.7f));
        sequence.Append(temp.transform.DOScale(new Vector2(1, 1), 0.3f));

        yield return new WaitForSeconds(0.5f);
        if (!temp.TryGetComponent<BoxCollider2D>(out BoxCollider2D bc2))
        {
            temp.AddComponent<BoxCollider2D>();
        }
        
    }
}
