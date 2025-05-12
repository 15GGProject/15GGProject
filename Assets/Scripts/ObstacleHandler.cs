using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    //public int ObstacleElemental;
    //public int ObstacleType;

    public int ObstacleNumber;

    [SerializeField] private Sprite[] Obstacles;

    private SpriteRenderer sr;
    public void GetObstacle()
    {
        sr = GetComponent<SpriteRenderer>();

        ObstacleNumber = Random.Range(0, 6);

        for (int i  =  0;  i < Obstacles.Length; i++)
        {
            if (ObstacleNumber == i)
            {
                sr.sprite = Obstacles[i];
            }
        }
    }
}
