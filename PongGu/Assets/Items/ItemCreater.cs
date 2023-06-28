using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

public class ItemCreater : MonoBehaviour
{
    public Dictionary<int,ItemBase> ItemList = new Dictionary<int, ItemBase>();
    public string aing;
    [SerializeField]private float itemCreateTime = 10;
    private float timer;
    public int itemRandomValue;
    public Vector3 ItemPosition;
    public Vector3 maxPosition;
    public Vector3 minPosition;
    void Start()
    {
        ItemList.Add(0, new AttackTurnBall());
        ItemList.Add(1, new BigBall());
        ItemList.Add(2, new BallInvisible());
        ItemList.Add(3, new BallFaster());
        ItemList.Add(4, new PlayerSlower());
        ItemList.Add(5, new WallRestore());
        for (int i = 0; i<ItemList.Count;i++)
        {
            ItemList[i].IdentitySetting();
            Debug.Log(ItemList[i].ItemIndex);
        }
        ItemPosition.x = Random.Range(minPosition.x, maxPosition.x);
        ItemPosition.y = Random.Range(minPosition.y, maxPosition.y);
        GameObject OBJTemp = Instantiate(Resources.Load<GameObject>("LoadGameObjects/Item"), ItemPosition, Quaternion.identity);
        OBJTemp.GetComponent<DropedItem>().itemInfo = ItemList[0];
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > itemCreateTime&&!GameManager.GMinstance().attackInfo.attackTurn)
        {
            timer = 0;
            itemRandomValue = Random.Range(1, ItemList.Count);
            ItemPosition.x = Random.Range(minPosition.x,maxPosition.x);
            ItemPosition.y = Random.Range(minPosition.y,maxPosition.y);
            GameObject OBJTemp = Instantiate(Resources.Load<GameObject>("LoadGameObjects/Item"),ItemPosition,Quaternion.identity);
            OBJTemp.GetComponent<DropedItem>().itemInfo = ItemList[itemRandomValue];
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(maxPosition, 0.3f);
        Gizmos.DrawSphere(minPosition, 0.3f);

    }
}
