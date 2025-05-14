using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : BaseItem
{
    private string itemName = "Speed";
    private ItemType itemType = ItemType.Speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            // ������ ȿ���� ����
            ApplyEffect();
            // �������� ��Ȱ��ȭ > 2�ʵ� �ٽ� Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }

    public override void ApplyEffect()
    {
        // �ӵ� ������ ȿ���� �����ϴ� ����
        //Debug.Log(itemName + " : �ӵ� ����");
        ItemDate data = new ItemDate
        {
            itemName = this.itemName,
            itemType = this.itemType,
            duration = 5f // ���ӽð� ����
        };

        if (GameManager.Instance != null && GameManager.Instance.PlayerExists()) // �Ʒ��� ����
        {
            GameManager.Instance.SpeedUp(data, this.gameObject);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance �Ǵ� player�� ���� null�Դϴ�.");
        }

        // �ӵ� ���� ȿ���� �����ϴ� �޼ҵ� ȣ��
        GameManager.Instance.SpeedUp(data, this.gameObject); // �ӵ� ����
    }
}
