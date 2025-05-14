using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private InGameUI ui;// UI를 관리하는 변수 : ui오브젝트 연결 = UI관리할때 호출
    static public GameManager Instance; // 싱글톤 패턴을 위한 Instance 변수
    System.Random random = new System.Random(); // 랜덤 숫자 생성을 위한 변수
    private Player player;
    public void Awake() // Awake 메소드는 MonoBehaviour의 생명주기에서 가장 먼저 호출됨
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void RegisterPlayer(Player p)
    {
        player = p;
    }

    public bool PlayerExists()
    {
        return player != null;
    }

    public void AddScore()
    {
        Debug.Log("스코어 : 45~50점추가");
        // 점수 추가 로직
        int score = random.Next(45, 51); // 45~50점 사이의 랜덤 점수 생성
        Debug.Log("Score: " + score);
        // ui.UpdateScore(score); // UI 업데이트할때 사용
    }
    public void SpeedUp(ItemDate itemDate)
    {
        if (player == null)
        {
            Debug.LogWarning("GameManager의 player가 아직 등록되지 않았습니다.");
            return;
        }
        // 속도 증가 로직
        player.ApplyItemEffect(itemDate); // 플레이어에게 아이템 효과 적용
    }
    public void Heal(ItemDate data)
    {
        // 체력 회복아이템 로직
        player.ApplyItemEffect(data); // 플레이어에게 아이템 효과 적용
    }
}
