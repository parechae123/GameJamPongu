using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallTester : MonoBehaviour
{
    public Rigidbody2D rb;
    public RaycastHit2D hit;
    public CircleCollider2D CC;
    public float speed;
    public bool isPlayerAtached = false;
    public GameObject ThrowingPlayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.CircleCast(transform.position, CC.bounds.extents.x + 0.1f, Vector2.zero, 0, 8);
        if (hit)
        {
            if(hit.collider.TryGetComponent<Player>(out Player playerSCR)&&hit.collider.gameObject != ThrowingPlayer)
            {
                if (!isPlayerAtached)
                {
                    GameManager.GMinstance().GameOver(playerSCR.isPlayerOne);
                }
                isPlayerAtached = true;
            }
        }
    }


    public void Init(Vector3 BallRot,GameObject throwingPlr)
    {
        GameManager.GMinstance().attackInfo.attackTurn = false;
        ThrowingPlayer = throwingPlr;
        isPlayerAtached = false;
        rb.velocity = new Vector2(BallRot.x,  BallRot.y).normalized*speed;
    }
}
