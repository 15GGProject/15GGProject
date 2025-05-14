using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int MapCount = 6; //방해물 갯수(초기값)
    public Vector3 mapLastPosition = Vector3.zero;//방해물 마지막위치는 0,0,0으로 설정
    PoolManager poolManager;
    Map map;
    // Start is called before the first frame update
    private void Start()
    {
        poolManager = FindAnyObjectByType<PoolManager>();
        Map[] maps = GameObject.FindObjectsOfType<Map>();
        for (int i = 0; i < maps.Length; i++)
        {
            //Debug.Log(poolManager);
            //Debug.Log(maps[i].gameObject);
            if (maps[i].name != "Map01")
            poolManager.SetMap(maps[i].gameObject);
        }
        for (int i = 0; i < MapCount; i++)
        {
            Map map = poolManager.GetMap().GetComponent<Map>();
            mapLastPosition = map.SetPlace(mapLastPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Respawn"))
        {
            poolManager.SetMap(collision.gameObject);
            Map newmap = poolManager.GetMap().GetComponent<Map>();
            mapLastPosition = newmap.SetPlace(mapLastPosition);
            return;
        }

        //Debug.Log("Trigger : " + collision.name);
        //Map map = collision.GetComponent<Map>();
        //if (map)//맵 리스폰
        //{
        //    Debug.Log("MapRespawn");
        //    map.SetPlace(mapLastPosition, mapCount);
        //}
    }
}
