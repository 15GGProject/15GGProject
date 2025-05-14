using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private GameObject obSpn;

    [SerializeField] private int _obstacleNum;
    int arrowRandomNumber;

    Vector2 obstacleInstantiatePosition;

    // Start is called before the first frame update
    void Start()
    {
        _obstacleSpawner = obSpn.GetComponent<ObstacleSpawner>();
        _obstacleNum = _obstacleSpawner.ObstacleNumber;

        Debug.Log(_obstacleNum);
        PositionObstacle();
    }
    private void Update()
    {
        ActionObstacle();
    }

    public void PositionObstacle()
    {
        if (_obstacleNum < 4)
        {
           arrowRandomNumber = Random.Range(0, 2);
            //Debug.Log(arrowRandomNumber);

            for (int i = 0; i < 2; i++)
            {
                if (arrowRandomNumber == i)
                {
                    obstacleInstantiatePosition = new Vector2(_player.transform.position.x + 20, -2.6f + i * 0.8f); // ȭ�� && �̻��� ���� �� �̵� ���

                    transform.position = obstacleInstantiatePosition;
                }   
            }
        }
        else
        {
            obstacleInstantiatePosition = new Vector2(_player.transform.position.x + 15f, -9f); // ���̷��� ���� �� �̵� ���

            transform.position = obstacleInstantiatePosition;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("HIT!!");
            player.PlayerHpChange(-10f);
            //Destroy(this.gameObject);
            //�浹 �� ü�� ���� �� �Ͻ��� ���� ������� �Լ� �κ�
        }
    }

    void ActionObstacle()
    {
        Vector2 target = new Vector2(_player.transform.position.x - 5f, obstacleInstantiatePosition.y);

        if (_obstacleNum < 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.1f);
        }
        
        if ((Vector2)transform.position == target)
        {
            Destroy(this.gameObject);
        }
    }
}
