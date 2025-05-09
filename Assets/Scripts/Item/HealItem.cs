using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : BaseItem
{
    private string itemName = "Heal";
    private ItemType itemType = ItemType.Heal;
    // 아이템 효과를 적용하는 메소드
    public override void ApplyEffect()
    {
        // 체력 회복 효과를 적용하는 로직
        Debug.Log(itemName + " 체력회복 ");
        
    }
}
