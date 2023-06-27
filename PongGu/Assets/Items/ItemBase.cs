using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase 
{
    public string ImagePath;
    public int ItemIndex;
    public abstract void IdentitySetting();
    public abstract void ItemEffect(GameObject targetPlayer);
}
public class AttackTurnBall : ItemBase
{
    public override void IdentitySetting()
    {
        ImagePath = "";
        ItemIndex = 0;
        
    }
    public override void ItemEffect(GameObject targetPlayer)
    {
/*        GameManager.GMinstance().ItemTarget(targetPlayer);*/
        //아이템 효과
        Debug.Log(GameManager.GMinstance().ItemTarget(targetPlayer));
        Debug.Log(targetPlayer);
    }
}
