using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : BaseItem
{
    private string itemName = "Speed";
    private ItemType itemType = ItemType.Speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (collision.gameObject.name == "Player")
        {
            // ������ ȿ���� ����
            ApplyEffect();
            // �������� �ı�
            Destroy(gameObject);
        }
    }

    public override void ApplyEffect()
    {
        // �ӵ� ������ ȿ���� �����ϴ� ����
        Debug.Log(itemName + " : �ӵ� ����");
        ItemDate data = new ItemDate
        {
            itemName = this.itemName,
            itemType = this.itemType,
            duration = 5f // ���ӽð� ����
        };

        if (GameManager.Instance != null && GameManager.Instance.PlayerExists()) // �Ʒ��� ����
        {
            GameManager.Instance.SpeedUp(data);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance �Ǵ� player�� ���� null�Դϴ�.");
        }

        // �ӵ� ���� ȿ���� �����ϴ� �޼ҵ� ȣ��
        //GameManager.Instance.SpeedUp(data); // �ӵ� ����
    }
}
