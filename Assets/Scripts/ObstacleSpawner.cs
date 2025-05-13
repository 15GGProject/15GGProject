using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;

    public int ObstacleNumber;

    void Start()
    {
        GetObstacle();
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

                newObj.transform.SetParent(this.transform);
            }
        }
    }
}
