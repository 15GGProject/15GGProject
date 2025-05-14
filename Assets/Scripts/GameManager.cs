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
        Debug.Log("���ھ� : 45~50���߰�");
        // ���� �߰� ����
        int score = random.Next(45, 51); // 45~50�� ������ ���� ���� ����
        Debug.Log("Score: " + score);
        // ui.UpdateScore(score); // UI ������Ʈ�Ҷ� ���
    }
    public void SpeedUp(ItemDate itemDate)
    {
        if (player == null)
        {
            Debug.LogWarning("GameManager�� player�� ���� ��ϵ��� �ʾҽ��ϴ�.");
            return;
        }
        // �ӵ� ���� ����
        player.ApplyItemEffect(itemDate); // �÷��̾�� ������ ȿ�� ����
    }
    public void Heal(ItemDate data)
    {
        // ü�� ȸ�������� ����
        player.ApplyItemEffect(data); // �÷��̾�� ������ ȿ�� ����
    }
}
