using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : BaseItem
{
    private string itemName = "Speed";
    private ItemType itemType = ItemType.Speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 플레이어일 경우
        if (collision.gameObject.name == "Player")
        {
            // 아이템 효과를 적용
            ApplyEffect();
            // 아이템을 파괴
            Destroy(gameObject);
        }
    }

    public override void ApplyEffect()
    {
        // 속도 아이템 효과를 적용하는 로직
        Debug.Log(itemName + " : 속도 감속");
        ItemDate data = new ItemDate
        {
            itemName = this.itemName,
            itemType = this.itemType,
            duration = 5f // 지속시간 설정
        };

        if (GameManager.Instance != null && GameManager.Instance.PlayerExists()) // 아래에 설명
        {
            GameManager.Instance.SpeedUp(data);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance 또는 player가 아직 null입니다.");
        }

        // 속도 증가 효과를 적용하는 메소드 호출
        //GameManager.Instance.SpeedUp(data); // 속도 증가
    }
}
