using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour
{
    public ItemBase itemInfo;
    private bool isUsed = false;
    
    RaycastHit2D hit;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(itemInfo.ImagePath);
    }
    private void Update()
    {
        if (!isUsed)
        {
            hit = Physics2D.BoxCast(transform.position, Vector2.one, 0,Vector2.zero,1,8);
            if (hit)
            {
                Debug.Log("아이템 발동");
                isUsed = true;
                itemInfo.ItemEffect(hit.collider.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
