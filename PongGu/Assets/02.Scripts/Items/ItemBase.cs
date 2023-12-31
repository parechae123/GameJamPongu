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
        ImagePath = "ItemIcons/FirstAttack";
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
        ImagePath = "ItemIcons/BallBigger";
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
        ImagePath = "ItemIcons/InvisibleBall";
        ItemIndex = 2;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        GameManager.GMinstance().SetInvisible();
        Debug.Log("공 투명화");
    }
}
public class BallFaster : ItemBase
{
    public override void IdentitySetting()
    {
        ImagePath = "ItemIcons/BallSpeed";
        ItemIndex = 3;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        GameManager.GMinstance().BallSpeedSet();

        Debug.Log("공 가속");
    }
}
public class PlayerSlower : ItemBase
{
    //target == enemy
    public override void IdentitySetting()
    {
        ImagePath = "ItemIcons/PlayerSlower";
        ItemIndex = 4;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        GameManager.GMinstance().ItemTargetPlrSpeed(targetPlayer).speed = GameManager.GMinstance().plrOriginStat[0].speed / 2;
        Debug.Log("플레이어 둔화");
    }
}
public class WallRestore : ItemBase
{
    //target == enemy
    public override void IdentitySetting()
    {
        ImagePath = "ItemIcons/repairWall";
        ItemIndex = 5;

    }
    public override void ItemEffect(GameObject targetPlayer)
    {
        /*        GameManager.GMinstance().ItemTargetOBJ(targetPlayer);*/
        //아이템 효과
        Debug.Log(GameManager.GMinstance().ItemTargetOBJ(targetPlayer));
        Debug.Log("벽 복구");
    }
}
