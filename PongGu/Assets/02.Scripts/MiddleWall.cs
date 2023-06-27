using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MiddleWall : MonoBehaviour
{
    private bool wallActive = true;
    public GameObject wall;
    Sequence sequence;
    public float wallScale;
    // Start is called before the first frame update
    void Start()
    {
        if (wallActive)
        {
            wall.SetActive(true);
            sequence = DOTween.Sequence();
            sequence.Append(wall.transform.DOScale(new Vector2(1.3f, 1.3f), 1));
            sequence.Append(wall.transform.DOScale(new Vector2(1, 1), 0.5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
