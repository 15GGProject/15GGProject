using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private InGameUI ui;// UI�� �����ϴ� ���� : ui������Ʈ ���� = UI�����Ҷ� ȣ��
    static public GameManager Instance; // �̱��� ������ ���� Instance ����
    System.Random random = new System.Random(); // ���� ���� ������ ���� ����
    private Player player;

    protected InGameUI inGameUI;
    protected Score _score;
    public void Awake() // Awake �޼ҵ�� MonoBehaviour�� �����ֱ⿡�� ���� ���� ȣ���
    {
        // �̱��� ���� ����
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
            Debug.LogWarning("GameManager�� player�� ���� ��ϵ��� �ʾҽ��ϴ�.");
            return;
        }
        // �ӵ� ���� ����
        player.ApplyItemEffect(data, item); // �÷��̾�� ������ ȿ�� ����
    }
    public void Heal(ItemDate data, GameObject item)
    {
        // ü�� ȸ�������� ����
        player.ApplyItemEffect(data, item); // �÷��̾�� ������ ȿ�� ����
    }
    private IEnumerator SetActive(GameObject item)
    {
        yield return new WaitForSeconds(2f);
        item.SetActive(true);
    }
}
