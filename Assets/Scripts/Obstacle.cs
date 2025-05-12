using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private ObstacleHandler _obstacleHandler;

    private int randomNumber;
    Vector2 obstacleInstantiatePosition;

    float directionX;
    float directionY;

    // Start is called before the first frame update
    void Start()
    {
        _obstacleHandler = GetComponent<ObstacleHandler>();

        _obstacleHandler.GetObstacle();
    }

    public void PositionObstacle()
    {
        randomNumber = Random.Range(0, 2);

        for (int i = 0; i < 2; i++)
        {
            if (randomNumber == i)
            {
                obstacleInstantiatePosition = new Vector2(_player.transform.position.x + 10 , -2.6f + i * 0.8f); // 아래가 random 0번, 위가 random 1번
            }
        }
    }

    public void MovementObstacle()
    {
        if (_obstacleHandler.ObstacleNumber < 4)
        {
            Vector2 target = new Vector2(obstacleInstantiatePosition.x, directionY);

            transform.position = Vector2.MoveTowards(obstacleInstantiatePosition, target, 0.1f);
        }
    }
    private void Update()
    {
        MovementObstacle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("HIT!!");
            player.PlayerHpChange(-10f);
            Destroy(this);
        }
    }
}
