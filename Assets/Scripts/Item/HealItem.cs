using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : BaseItem
{
    private string itemName = "Heal";
    private ItemType itemType = ItemType.Heal;
    // ������ ȿ���� �����ϴ� �޼ҵ�
    public override void ApplyEffect()
    {
        // ü�� ȸ�� ȿ���� �����ϴ� ����
        Debug.Log(itemName + " ü��ȸ�� ");
        
    }
}
