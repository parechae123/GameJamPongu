using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallTester : MonoBehaviour
{
    public Rigidbody2D rb;
    public RaycastHit2D hit;
    public CircleCollider2D CC;
    public Stats BallStat;
    public Stats BallOriginStat;
    public bool isPlayerAtached = false;
    public GameObject ThrowingPlayer;
    public LayerMask targetLayer;
    public Vector2 saveVector;
    public AudioClip bounce;
    public AudioClip playerDie;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GMinstance().ball = this.gameObject;
        BallStat = new Stats();
        BallOriginStat = new Stats();
        StatSetting();
        GameManager.GMinstance().ballStat = BallStat;
        GameManager.GMinstance().BallSCR = this;
        GameManager.GMinstance().OriginBallStat = BallOriginStat;
        GameManager.GMinstance().ballSR = GetComponent<SpriteRenderer>();
        
    }
    public void StatSetting()
    {
        BallOriginStat.size = transform.localScale;
        BallOriginStat.speed = 10;
        BallStat.size = BallOriginStat.size;
        BallStat.speed = BallOriginStat.speed;
    }
    // Update is called once per frame
    void Update()
    {
        
        hit = Physics2D.CircleCast(transform.position, CC.bounds.extents.x + 0.1f, Vector2.zero, 0, targetLayer);
        if (hit)
        {
            if (hit.collider.gameObject != ThrowingPlayer && hit.collider.gameObject.layer == 3)
            {
                if (hit.collider.TryGetComponent<Player>(out Player playerSCR))
                {
                    if (!isPlayerAtached)
                    {
                        SoundManager.soundManager.SFXSound("Die", playerDie);
                        CC.enabled = false;
                        GameManager.GMinstance().GameOver(playerSCR.isPlayerOne);
                        rb.velocity = Vector2.zero;
                        MiddleWall.middleWall.WallInit();
                    }
                    isPlayerAtached = true;
                    
                } 
            }
            else if(hit.collider.gameObject.layer==7)
            {
                saveVector = rb.velocity;
            }
        }
        if(GameManager.GMinstance().bounceNum >= 15)
        {
            GameManager.GMinstance().AttackerChange();
            MiddleWall.middleWall.WallInit();
        }
    }
    public void Init(Vector3 BallRot,GameObject throwingPlr)
    {
        GameManager.GMinstance().attackInfo.attackTurn = false;
        ThrowingPlayer = throwingPlr;
        isPlayerAtached = false;
        rb.velocity = new Vector2(BallRot.x,  BallRot.y).normalized * BallStat.speed;
    }
    public void SetItemSpeed()
    {
        Vector2 tempVec = Vector2.ClampMagnitude(saveVector * 1.5f, 15);
        rb.velocity = tempVec;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            SoundManager.soundManager.SFXSound("Bounce", bounce);
            GameManager.GMinstance().bounceNum++;
        }
    }


}
