using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;

    public int ObstacleNumber;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹ü �̸��� map11�̶�� 
        // ObstacleNumber = Random.Range(0, 6);
        // else
        GetObstacle();

        ObstacleNumber = Random.Range(0, 6);
    }


    public void GetObstacle()
    {
        
        for (int i = 0; i < Obstacles.Length; i++)
        {
            if (ObstacleNumber == i)
            {
                GameObject newObj;

                newObj = Instantiate(Obstacles[i]);

                newObj.transform.SetParent(this.transform);
            }
        }
    }
}
