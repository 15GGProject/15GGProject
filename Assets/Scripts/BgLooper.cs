using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int mapCount = 0; //���ع� ����(�ʱⰪ)
    public int numBgCount = 5;//��׶���,ž�׶���,���ұ׶��� �� ���� �� ������ 5�����̶� 5�� �������̴�.
    public Vector3 mapLastPosition = Vector3.zero;//���ع� ��������ġ�� 0,0,0���� ����

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

        if (map)//�� ������
        {
            Debug.Log("MapRespawn");
            map.SetPlace(mapLastPosition, mapCount);
        }
    }
}
