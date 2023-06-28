using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPlayerOne;
    private float playerAxis;
    public Rigidbody2D rb;
    public Collider2D BC;
    public bool isAimingBall = false;
    public int AttackKey;
    public Stats nowStat;
    public Stats originStat;
    public BallTester ball;
    public float boundaryMax;
    float ballX = 0;
    float BallRot = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        BC = GetComponent<Collider2D>();
        if (isPlayerOne)
        {
            playerAxis = 1;
        }
        else
        {
            playerAxis = -1;
        }
        boundaryMax = (-BC.bounds.extents.x-0.08f) * playerAxis;

    }
    private void SetStats()
    {
        nowStat.size = transform.localScale;
        nowStat.speed = 4;
    }
    private void Start()
    {
        nowStat = new Stats();
        originStat = new Stats();
        SetStats();
        originStat.speed = nowStat.speed;
        originStat.size = nowStat.size;
        if (isPlayerOne)
        {
            GameManager.GMinstance().plrOriginStat[0] = originStat;
            GameManager.GMinstance().plrStat[0] = nowStat;
        }
        else
        {
            GameManager.GMinstance().plrOriginStat[1] = originStat;
            GameManager.GMinstance().plrStat[1] = nowStat;
        }
        /*
        GameManager.GMinstance().attackInfo.attackTurn = true;
        if (isPlayerOne)
        {
            GameManager.GMinstance().attackInfo.Players[0] = this.gameObject;
        }
        else
        {
            GameManager.GMinstance().attackInfo.Players[1] = this.gameObject;
            GameManager.GMinstance().attackInfo.attackPlayer = this.gameObject;
        }*/
    }
    public void Update()
    {
        switch (isPlayerOne)
        {
            case true:
                if (!isAimingBall && boundaryMax > transform.position.x)
                {
                    rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * nowStat.speed;
                }
                else if (boundaryMax < transform.position.x&& !isAimingBall)
                {
                    rb.velocity = Vector2.zero;
                    if (Input.GetAxisRaw("Horizontal") < 0 || (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") != 0) || Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") == 0)
                    {
                        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * nowStat.speed;
                    }
                }
                if (GameManager.GMinstance().attackInfo.attackPlayer == this.gameObject && GameManager.GMinstance().attackInfo.attackTurn == true)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (ball.transform.position.y > -4.13f && ball.transform.position.y < 4.13f)
                        {
                            BallRot += Input.GetAxis("Vertical") * Time.deltaTime;
                            BallRot = Mathf.Clamp(BallRot, -1.5f, 1.5f);
                            ballX = BallRot / 3;
                            ballX = Mathf.Abs(Mathf.Clamp(ballX, -1, 1));
                            ballX = ballX * -playerAxis;
                            ball.transform.position = new Vector3(transform.position.x + (BC.bounds.size.x * playerAxis) + ballX, BallRot + transform.position.y, transform.position.z);
                        }
                        else if (ball.transform.position.y > 4.13f && Input.GetAxisRaw("Vertical") < 0)
                        {
                            BallRot += Input.GetAxis("Vertical") * Time.deltaTime;
                            BallRot = Mathf.Clamp(BallRot, -1.5f, 1.5f);
                            ballX = BallRot / 3;
                            ballX = Mathf.Abs(Mathf.Clamp(ballX, -1, 1));
                            ballX = ballX * -playerAxis;
                            ball.transform.position = new Vector3(transform.position.x + (BC.bounds.size.x * playerAxis) + ballX, BallRot + transform.position.y, transform.position.z);
                        }
                        else if (ball.transform.position.y < -3.5f && Input.GetAxisRaw("Vertical") > 0)
                        {
                            BallRot += Input.GetAxis("Vertical") * Time.deltaTime;
                            BallRot = Mathf.Clamp(BallRot, -1.5f, 1.5f);
                            ballX = BallRot / 3;
                            ballX = Mathf.Abs(Mathf.Clamp(ballX, -1, 1));
                            ballX = ballX * -playerAxis;
                            ball.transform.position = new Vector3(transform.position.x + (BC.bounds.size.x * playerAxis) + ballX, BallRot + transform.position.y, transform.position.z);
                        }
                        //얘는 각도로
                        if (Input.GetKeyDown(KeyCode.LeftControl))
                        {
                            rb.isKinematic = true;
                            BallRot = 0;
                            ball.rb.velocity = Vector2.zero;
                            rb.velocity = Vector2.zero;
                            isAimingBall = true;
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.LeftControl))
                    {
                        isAimingBall = false;
                        Vector3 ballDir = (ball.transform.position - transform.position) * 15;
                        ball.Init(new Vector3(ballDir.x, ballDir.y, ballDir.z), this.gameObject);
                        rb.isKinematic = false;
                        BallRot = 0;
                        GameManager.GMinstance().ResetStat();
                    } 
                }
                break;
            case false:
                if (!isAimingBall && boundaryMax < transform.position.x)
                {
                    rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2")).normalized * nowStat.speed;
                }
                else if (boundaryMax > transform.position.x && !isAimingBall)
                {
                    rb.velocity = Vector2.zero;
                    if (Input.GetAxisRaw("Horizontal2") > 0 || (Input.GetAxisRaw("Horizontal2") > 0 && Input.GetAxisRaw("Vertical2") != 0) || Input.GetAxisRaw("Vertical2") != 0 && Input.GetAxisRaw("Horizontal2") == 0)
                    {
                        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2")).normalized * nowStat.speed;
                    }
                }
                if (GameManager.GMinstance().attackInfo.attackPlayer == this.gameObject && GameManager.GMinstance().attackInfo.attackTurn == true)
                {
                    if (Input.GetKey(KeyCode.Slash))
                    {
                        if (ball.transform.position.y > -4.13f && ball.transform.position.y < 4.13f)
                        {
                            BallRot += Input.GetAxis("Vertical2") * Time.deltaTime;
                            BallRot = Mathf.Clamp(BallRot, -1.5f, 1.5f);//아크탄제트로 연산하고 화살표로 바꿔야함
                            ballX = BallRot / 3;
                            ballX = Mathf.Abs(Mathf.Clamp(ballX, -1, 1));
                            ballX = ballX * -playerAxis;
                            ball.transform.position = new Vector3(transform.position.x + (BC.bounds.size.x * playerAxis) + ballX, BallRot + transform.position.y, transform.position.z);
                        }
                        else if (ball.transform.position.y > 4.13f && Input.GetAxisRaw("Vertical2") < 0)
                        {
                            BallRot += Input.GetAxis("Vertical2") * Time.deltaTime;
                            BallRot = Mathf.Clamp(BallRot, -1.5f, 1.5f);//아크탄제트로 연산하고 화살표로 바꿔야함
                            ballX = BallRot / 3;
                            ballX = Mathf.Abs(Mathf.Clamp(ballX, -1, 1));
                            ballX = ballX * -playerAxis;
                            ball.transform.position = new Vector3(transform.position.x + (BC.bounds.size.x * playerAxis) + ballX, BallRot + transform.position.y, transform.position.z);
                        }
                        else if (ball.transform.position.y < -4.13f && Input.GetAxisRaw("Vertical2") > 0)
                        {
                            BallRot += Input.GetAxis("Vertical2") * Time.deltaTime;
                            BallRot = Mathf.Clamp(BallRot, -1.5f, 1.5f);//아크탄제트로 연산하고 화살표로 바꿔야함
                            ballX = BallRot / 3;
                            ballX = Mathf.Abs(Mathf.Clamp(ballX, -1, 1));
                            ballX = ballX * -playerAxis;
                            ball.transform.position = new Vector3(transform.position.x + (BC.bounds.size.x * playerAxis) + ballX, BallRot + transform.position.y, transform.position.z);
                        }
                        //얘는 각도로
                        if (Input.GetKeyDown(KeyCode.Slash))
                        {
                            rb.isKinematic = true;
                            BallRot = 0;
                            ball.rb.velocity = Vector2.zero;
                            rb.velocity = Vector2.zero;
                            isAimingBall = true;
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.Slash))
                    {
                        isAimingBall = false;
                        Vector3 ballDir = (ball.transform.position - transform.position) * 15;
                        ball.Init(new Vector3(ballDir.x, ballDir.y, ballDir.z), this.gameObject);
                        rb.isKinematic = false;
                        BallRot = 0;
                        GameManager.GMinstance().ResetStat();
                    } 
                }
                break;
        }

        //1p2p 나누는 하위 클래스를 만들던지 해야할듯함
    }
}
[System.Serializable]
public class Stats
{
    public float speed;
    public Vector3 size;
}
