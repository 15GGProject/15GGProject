using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int mapCount = 0; //방해물 갯수(초기값)
    private int numBgCount = 11;
    public Vector3 mapLastPosition = Vector3.zero;//방해물 마지막위치는 0,0,0으로 설정

    // Start is called before the first frame update
    private void Start()
    {
        Map[] maps = GameObject.FindObjectsOfType<Map>();
        mapCount = maps.Length;
        for (int i = 0; i < mapCount; i++)
        {
 
            maps[i].SetPlace(mapLastPosition, i);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            float MapSizeX = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;
            pos.x += (MapSizeX+1) * numBgCount;
            collision.transform.position = pos;
            Debug.Log("Name :" + this.name + "pos : " + pos + "MapSizeX : "+MapSizeX+ "numBgCount : numBgCount");
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
    }
}
