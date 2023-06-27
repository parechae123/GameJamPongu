using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MiddleWall : MonoBehaviour
{
    private bool wallActive = true;
    public GameObject[] wall = new GameObject[2];
    Sequence sequence;
    public float wallScale;
    GameManager GameManager => GameManager.GMinstance();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            StartCoroutine(WallAddCollider()); 
        }

    }
    public IEnumerator WallAddCollider()
    {
        for (int i = 0; i < wall.Length; i++)
        {
            wall[i].SetActive(true);
            sequence = DOTween.Sequence();
            sequence.Append(wall[i].transform.DOScale(new Vector2(1.3f, 1.3f), 0.7f));
            sequence.Append(wall[i].transform.DOScale(new Vector2(1, 1), 0.3f));
        }
        yield return new WaitForSeconds(1);
        
    }
}
