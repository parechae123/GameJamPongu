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
    private void OnEnable()     //������Ʈ�� ������ �� ����Ǵ� �Լ�
    {
        wallHp = 1;
    }
    //���ο� �Լ� �߰� �ʿ� if(Activeself)�� Ʈ���� ���� ������ �Ǵ� �� ����� �̰� �ʿ� �����ִ� ���� HP�� �ö󰡰� �ϱ� ����
}
