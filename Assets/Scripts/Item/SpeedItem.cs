using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : BaseItem
{
    private string itemName = "Speed";
    private ItemType itemType = ItemType.Speed;

    public override void ApplyEffect()
    {
        // 속도 아이템 효과를 적용하는 로직
        Debug.Log(itemName + " : 속도 증가");
        
    }
}
