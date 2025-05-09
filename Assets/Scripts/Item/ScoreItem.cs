using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : BaseItem
{
    private string itemName = "Score"; // ������ �̸�
    private ItemType itemType = ItemType.Score; // ������ ����

    private void OnTriggerEnter2D(Collider2D other) // other�� �浹�� ������Ʈ�� �ǹ�
    {
        // �׽�Ʈ �����α�
        Debug.Log("���𰡿� �浹��: " + other.gameObject.name);
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (other.gameObject.name == "TestPlayer")
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
        // ���� ������ ȿ���� �����ϴ� ����
        Debug.Log(itemName + " : ����ȹ��");
        ItemDate data = new ItemDate
        {
            itemName = this.itemName,
            itemType = this.itemType,
        };
        // GameManager.Instance.AddScore(data); // ���� �߰�
    }
}
