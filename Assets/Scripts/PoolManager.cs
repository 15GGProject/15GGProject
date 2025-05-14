using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int bulletCount = 10;
    public GameObject bulletPrefab;

    private List<GameObject> bulletPool;

    private void Start()
    {
        bulletPool = new List<GameObject>();

        //기본 총알 생성
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject gameObject = Instantiate(bulletPrefab);
            gameObject.SetActive(false);
            bulletPool.Add(gameObject);
        }
    }

    //비활성화 된 총알 빼주기
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

        //만약 비활성화 된 남은게 없다면 생성해서 리스트에 추가하고 내보냄
        GameObject nuwGameObject = Instantiate (bulletPrefab);
        nuwGameObject.SetActive(true);
        bulletPool.Add(nuwGameObject);
        return nuwGameObject;
    }
}
