using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int bulletCount = 10;
    public int mapCount = 11;
    public GameObject bulletPrefab;

    private List<GameObject> bulletPool;
    private List<GameObject> MapPool;


    private void Awake()
    {
        bulletPool = new List<GameObject>();
        MapPool = new List<GameObject>();
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject gameObject = Instantiate(bulletPrefab);
            gameObject.SetActive(false);
            bulletPool.Add(gameObject);
        }
    }
    public GameObject GetMap() //�ܺο��� ���������� �޼���
    {
        int random =Random.Range(0, MapPool.Count);
        GameObject selectMap = MapPool[random];
        while(selectMap.name == "Map01")
        {
            random = Random.Range(0, MapPool.Count);
            selectMap = MapPool[random];
        }
        selectMap.gameObject.SetActive(true);
        MapPool.Remove(MapPool[random]);
        //Debug.Log("GetMapName : "+selectMap.gameObject.name);
        return selectMap.gameObject;
        
    }
    public void SetMap(GameObject map) //�ܺο��� ���� ����(����Ʈ�� �ֱ�)
    {
        
            MapPool.Add(map);
            map.gameObject.SetActive(false);
    }

    public GameObject GetBullet()
    {
        foreach (GameObject go in bulletPool)
        {
            if(!go.activeInHierarchy)
            {
                go.SetActive(true);
                return go;
            }
        }

        //���� ��Ȱ��ȭ �� ������ ���ٸ� �����ؼ� ����Ʈ�� �߰��ϰ� ������
        GameObject nuwGameObject = Instantiate (bulletPrefab);
        nuwGameObject.SetActive(true);
        bulletPool.Add(nuwGameObject);
        return nuwGameObject;
    }
}
