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
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            if (collision.gameObject.name == "Map11")
            {
                ObstacleNumber = Random.Range(0, 6);
            }
            else
            {
                ObstacleNumber = Random.Range(0, 4);
            }

            GetObstacle();
        } 
    }

    public void GetObstacle()
    {
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
