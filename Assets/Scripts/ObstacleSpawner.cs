using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;

    [SerializeField] private GameObject _obstacles;

    public int ObstacleNumber;

    void Start()
    {
        GetObstacle();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌체 이름이 map11이라면 
        // ObstacleNumber = Random.Range(0, 6);
        // else
    }

    public void GetObstacle()
    {
        ObstacleNumber = Random.Range(0, 6);

        for (int i = 0; i < Obstacles.Length; i++)
        {
            if (ObstacleNumber == i)
            {
                GameObject newObj;

                newObj = Instantiate(Obstacles[i]);

                newObj.transform.SetParent(_obstacles.transform);
            }
        }
    }
}
