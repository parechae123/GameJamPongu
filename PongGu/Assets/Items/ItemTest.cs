using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public ItemBase ItemInfo;
    public GameObject targetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ItemInfo = new AttackTurnBall();
        ItemInfo.IdentitySetting();
        ItemInfo.ItemEffect(targetPlayer);
        
    }
}
