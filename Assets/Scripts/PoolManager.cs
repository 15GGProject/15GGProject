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

        //�⺻ �Ѿ� ����
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject gameObject = Instantiate(bulletPrefab);
            gameObject.SetActive(false);
            bulletPool.Add(gameObject);
        }
    }

    //��Ȱ��ȭ �� �Ѿ� ���ֱ�
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
