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
        //������ ȿ��
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
        //������ ȿ��
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
        Debug.Log("�� ����ȭ");
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
        //������ ȿ��
        GameManager.GMinstance().BallSpeedSet();

        Debug.Log("�� ����");
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
        //������ ȿ��
        GameManager.GMinstance().ItemTargetPlrSpeed(targetPlayer).speed = GameManager.GMinstance().plrOriginStat[0].speed / 2;
        Debug.Log("�÷��̾� ��ȭ");
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
        //������ ȿ��
        Debug.Log(GameManager.GMinstance().ItemTargetOBJ(targetPlayer));
        Debug.Log("�� ����");
    }
}