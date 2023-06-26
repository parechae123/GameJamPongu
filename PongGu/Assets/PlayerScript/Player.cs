using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D BC;
    public float speed = 12;
    public bool isAimingBall = false;
    public int AttackKey;
    public BallTester ball;
    public Vector3 boundaryMin;
    public Vector3 boundaryMax;
    float BallRot = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        BC = GetComponent<BoxCollider2D>();
    }
    public void Update()
    {
        if (!isAimingBall&&boundaryMax.x>transform.position.x)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        }
        else if(boundaryMax.x < transform.position.x)
        {
            rb.velocity = Vector2.zero;
            if (Input.GetAxisRaw("Horizontal") < 0||(Input.GetAxisRaw("Horizontal")<0&&Input.GetAxisRaw("Vertical")!= 0)|| Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") == 0)
            {
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            BallRot+= Input.GetAxis("Vertical") * Time.deltaTime;
            BallRot = Mathf.Clamp(BallRot, -1.5f, 1.5f);//아크탄제트로 연산하고 화살표로 바꿔야함
            ball.transform.position = new Vector3(transform.position.x + BC.bounds.size.x, BallRot + transform.position.y, transform.position.z);
            //얘는 각도로
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.isKinematic = true;
                BallRot = 0;
                ball.rb.velocity = Vector2.zero;
                rb.velocity = Vector2.zero;
                isAimingBall = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isAimingBall= false;
            ball.Init((ball.transform.position - transform.position)*15);
            rb.isKinematic = false;
            Debug.Log(ball.transform.position - transform.position);
            BallRot =0;
        }
        //1p2p 나누는 하위 클래스를 만들던지 해야할듯함
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(boundaryMax, 1);
        Gizmos.DrawSphere(boundaryMin, 1);
    }
}
