using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : BaseItem
{
    private string itemName = "Heal";
    private ItemType itemType = ItemType.Heal;
    // ������ ȿ���� �����ϴ� �޼ҵ�
        private void OnTriggerEnter2D(Collider2D other) // other�� �浹�� ������Ʈ�� �ǹ�
    {
        // �׽�Ʈ �����α�
        Debug.Log("���𰡿� �浹��: " + other.gameObject.name);
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            // ������ ȿ���� ����
            ApplyEffect();
            // �������� �ı�
            Destroy(gameObject);
        }
    }

    // ������ ȿ���� �����ϴ� �޼ҵ�
    public override void ApplyEffect()
    {
        ItemDate data = new ItemDate
        {
            itemName = this.itemName,
            itemType = this.itemType,
        };

        if (GameManager.Instance != null && GameManager.Instance.PlayerExists()) // �Ʒ��� ����
        {
            GameManager.Instance.Heal(data);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance �Ǵ� player�� ���� null�Դϴ�.");
        }
    }
}
