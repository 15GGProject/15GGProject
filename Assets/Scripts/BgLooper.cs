using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int mapCount = 0; //방해물 갯수(초기값)
    public int numBgCount = 5;//백그라운드,탑그라운드,바텀그라운드 의 각각 총 갯수가 5개씩이라 5를 넣은것이다.
    public Vector3 mapLastPosition = Vector3.zero;//방해물 마지막위치는 0,0,0으로 설정

    // Start is called before the first frame update
    void Start()
    {
        Map[] maps = GameObject.FindObjectsOfType<Map>();
        mapLastPosition = maps[0].transform.position;
        mapCount = maps.Length;
        for (int i = 0; i < mapCount; i++) 
        { 
            mapLastPosition = maps[i].SetPlace(mapLastPosition,mapCount);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger : "+collision.name);
        if (collision.CompareTag("Respawn"))
        {
            float BgObjectWidth = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;
            pos.x += BgObjectWidth * numBgCount;
            collision.transform.position = pos;
        }
        Map map = collision.GetComponent<Map>();

        if (map)//맵 리스폰
        {
            Debug.Log("MapRespawn");
            map.SetPlace(mapLastPosition, mapCount);
        }
    }
}
