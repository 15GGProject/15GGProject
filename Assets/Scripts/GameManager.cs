using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance; // 싱글톤 패턴을 위한 Instance 변수
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
    
    // 스코어아이템 트리거가 발동했을때 스코어아이템 클래스에서 호출되어 스코어를 추가하는 함수
    // 향후 uiManager랑 연결
    /*public void AddScore(ItemDate data)
    {
        ItemDate scoreData = data;
        Debug.Log("스코어 : 50점추가" + " " + scoreData.itemType + scoreData.itemName);
    }*/
}
