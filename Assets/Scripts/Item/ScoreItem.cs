using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : BaseItem
{
    private string itemName = "Score"; // 아이템 이름
    private ItemType itemType = ItemType.Score; // 아이템 종류

    private void OnTriggerEnter2D(Collider2D other) // other는 충돌한 오브젝트를 의미
    {
        // 테스트 디버깅로그
        Debug.Log("무언가와 충돌함: " + other.gameObject.name);
        // 충돌한 오브젝트가 플레이어일 경우
        if (other.gameObject.layer == 9)
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
        // 점수 아이템 효과를 적용하는 로직
        Debug.Log(itemName + " : 점수획득");
        GameManager.Instance.AddScore(); // 점수 추가
    }
}

