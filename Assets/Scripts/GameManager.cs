using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance; // �̱��� ������ ���� Instance ����
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
    
    // ���ھ������ Ʈ���Ű� �ߵ������� ���ھ������ Ŭ�������� ȣ��Ǿ� ���ھ �߰��ϴ� �Լ�
    // ���� uiManager�� ����
    /*public void AddScore(ItemDate data)
    {
        ItemDate scoreData = data;
        Debug.Log("���ھ� : 50���߰�" + " " + scoreData.itemType + scoreData.itemName);
    }*/
}
