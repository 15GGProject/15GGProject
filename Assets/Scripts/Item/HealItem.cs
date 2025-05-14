using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : BaseItem
{
    private string itemName = "Heal";
    private ItemType itemType = ItemType.Heal;
    // 아이템 효과를 적용하는 메소드
        private void OnTriggerEnter2D(Collider2D other) // other는 충돌한 오브젝트를 의미
    {
        // 테스트 디버깅로그
        Debug.Log("무언가와 충돌함: " + other.gameObject.name);
        // 충돌한 오브젝트가 플레이어일 경우
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            // 아이템 효과를 적용
            ApplyEffect();
            // 아이템을 파괴
            Destroy(gameObject);
        }
    }

    // 아이템 효과를 적용하는 메소드
    public override void ApplyEffect()
    {
        ItemDate data = new ItemDate
        {
            itemName = this.itemName,
            itemType = this.itemType,
        };

        if (GameManager.Instance != null && GameManager.Instance.PlayerExists()) // 아래에 설명
        {
            GameManager.Instance.Heal(data);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance 또는 player가 아직 null입니다.");
        }
    }
}
