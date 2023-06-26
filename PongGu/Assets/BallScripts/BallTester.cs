using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallTester : MonoBehaviour
{
    public Rigidbody2D rb;
    public RaycastHit2D hit;
    public CircleCollider2D CC;
    public Vector2 lastVelocity;
    public Vector3 startPosition;
    public float speed;
    public bool isPlayerAtached = false;
    public GameObject ThrowingPlayer;
    // Start is called before the first frame update
    void Start()
    {
/*        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0.1f,0.1f)*2000, ForceMode2D.Force);
        CC = GetComponent<CircleCollider2D>();
        Vector2.Reflect(Vector2.right, Vector2.down);*/
        startPosition = transform.position;
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
        ThrowingPlayer = throwingPlr;
        isPlayerAtached = false;
        rb.velocity = new Vector2(BallRot.x,  BallRot.y).normalized*speed;
    }
}
