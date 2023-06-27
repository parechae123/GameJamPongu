using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    
    public static int wallHp = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            wallHp -= 1;
            if (wallHp == 0)
            {
                gameObject.SetActive(false);
            }
        }
        
    }
    private void OnEnable()     //오브젝트가 켜졌을 때 실행되는 함수
    {
        wallHp = 1;
    }
    //새로운 함수 추가 필요 if(Activeself)가 트루일 때만 실행이 되는 걸 만들기 이건 맵에 남아있는 벽만 HP가 올라가게 하기 위해
}
