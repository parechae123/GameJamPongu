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
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        GameManager.GMinstance().SetPlayer(targetPlayer);
    }
}
public class BigBall : ItemBase
{
    public override void IdentitySetting()
    {
        ImagePath = "";
        ItemIndex = 1;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        GameObject TempBall = GameManager.GMinstance().ball;
        TempBall.transform.localScale = GameManager.GMinstance().OriginBallStat.size*2;
    }
}
public class BallInvisible : ItemBase
{
    public override void IdentitySetting()
    {
        ImagePath = "";
        ItemIndex = 2;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        GameManager.GMinstance().SetInvisible();
    }
}
public class BallFaster : ItemBase
{
    public override void IdentitySetting()
    {
        ImagePath = "";
        ItemIndex = 3;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        GameManager.GMinstance().ballStat.speed = GameManager.GMinstance().OriginBallStat.speed * 1.5f;
    }
}
public class PlayerSlower : ItemBase
{
    //target == enemy
    public override void IdentitySetting()
    {
        ImagePath = "";
        ItemIndex = 4;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        Debug.Log(GameManager.GMinstance().ItemTargetOBJ(targetPlayer));
        Debug.Log(targetPlayer);
    }
}
public class WallRestore : ItemBase
{
    //target == enemy
    public override void IdentitySetting()
    {
        ImagePath = "";
        ItemIndex = 5;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        Debug.Log(GameManager.GMinstance().ItemTargetOBJ(targetPlayer));
        Debug.Log(targetPlayer);
    }
}
public class GenericItemTarget<T>
{
    public T TargetConvert;
}
