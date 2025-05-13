using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Obstacle : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;

    public int _obstacleNum;
    int arrowRandomNumber;

    Vector2 obstacleInstantiatePosition;

    // Start is called before the first frame update
    void Start()
    {
        _obstacleSpawner = GetComponentInParent<ObstacleSpawner>();
        _obstacleNum = _obstacleSpawner.ObstacleNumber;

        PositionObstacle();
    }
    private void Update()
    {
        MovementObstacle();
    }

    public void PositionObstacle()
    {
        if (_obstacleNum < 4)
        {
           arrowRandomNumber = Random.Range(0, 2);

            for (int i = 0; i < 2; i++)
            {
                if (arrowRandomNumber == i)
                {
                    obstacleInstantiatePosition = new Vector2(transform.position.x + 10f, 3.4f + i * 0.8f); // 화살 && 미사일
                }   
            }
        }
        else
            obstacleInstantiatePosition = new Vector2(transform.position.x + 11.5f, 5f); // 스켈레톤
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("HIT!!");
            player.PlayerHpChange(-10f);
            Destroy(this.gameObject);
            //충돌 시 체력 감소 및 일시적 무적 판정모드 함수 부분
        }
    }

    void MovementObstacle()
    {
        if (_obstacleNum < 4)
        {
            Vector2 target = new Vector2(obstacleInstantiatePosition.x - 5f, obstacleInstantiatePosition.y);

            transform.position = Vector2.MoveTowards(transform.position, target, 0.1f);
        }
    }
}
