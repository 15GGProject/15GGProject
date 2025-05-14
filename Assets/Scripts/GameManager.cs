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

    protected InGameUI inGameUI;
    protected Score _score;
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

        Time.timeScale = 1.0f;
    }

    public void Start()
    {
        _score = GetComponentInChildren<Score>();
        inGameUI = FindAnyObjectByType<InGameUI>();
    }
    public void RegisterPlayer(Player p)
    {
        player = p;
    }

    public bool PlayerExists()
    {
        return player != null;
    }

    public void AddScore(GameObject item)
    {
        _score.addScore(50);
        _score.BestScoreCurrent();

        inGameUI.score = _score.CurrentScore;
        inGameUI.BestScore = _score.BestScore;
        StartCoroutine(SetActive(item));
    }
    public void SpeedUp(ItemDate data, GameObject item)
    {
        if (player == null)
        {
            Debug.LogWarning("GameManager의 player가 아직 등록되지 않았습니다.");
            return;
        }
        // 속도 증가 로직
        player.ApplyItemEffect(data, item); // 플레이어에게 아이템 효과 적용
    }
    public void Heal(ItemDate data, GameObject item)
    {
        // 체력 회복아이템 로직
        player.ApplyItemEffect(data, item); // 플레이어에게 아이템 효과 적용
    }
    private IEnumerator SetActive(GameObject item)
    {
        yield return new WaitForSeconds(2f);
        item.SetActive(true);
    }
}
