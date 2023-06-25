using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D BC;
    public float speed = 12;
    public bool isAimingBall = false;
    public int AttackKey;
    public BallTester ball;
    // Start is called before the first frame update
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        BC = GetComponent<BoxCollider2D>();
    }
    public void Update()
    {
        if (!isAimingBall)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            ball.transform.position = new Vector3(transform.position.x + 1, Input.GetAxis("Vertical") + transform.position.y, transform.position.z);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.zero;
                isAimingBall = true;


            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isAimingBall= false;
            ball.Init(ball.transform.position*-2);
        }
        //1p2p 나누는 하위 클래스를 만들던지 해야할듯함
    }
}
