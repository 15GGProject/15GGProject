using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : BaseItem
{
    private string itemName = "Speed";
    private ItemType itemType = ItemType.Speed;

    public override void ApplyEffect()
    {
        // �ӵ� ������ ȿ���� �����ϴ� ����
        Debug.Log(itemName + " : �ӵ� ����");
        
    }
}
