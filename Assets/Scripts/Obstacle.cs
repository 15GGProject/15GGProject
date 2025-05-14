using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Obstacle : MonoBehaviour
{
    private GameObject _obSpn;
    private GameObject _bgLooper;

    private ObstacleSpawner _obstacleSpawner;
    
    private int _obstacleNum;
    private int _obstacleHp;
    private float obstacleSpeed;

    int arrowRandomNumber;

    Vector2 obstacleInstantiatePosition;

    [SerializeField] private ObstacleHandler obstacleHp; // Scriptable Object / SerializeField �ʼ�!!

    GameObject camera;
    Player player;

    bool isObstacleFire;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");
        player = FindAnyObjectByType<Player>();
 
        _obSpn = camera.transform.Find("ObSpnLooper").gameObject;
        _bgLooper = camera.transform.Find("BgLooper").gameObject;

        _obstacleSpawner = _obSpn.GetComponent<ObstacleSpawner>();
        _obstacleNum = _obstacleSpawner.ObstacleNumber;

        PositionObstacle();
        ObstacleHP();

        if (_obstacleNum % 2 == 0)
        {
            isObstacleFire = true;
        }
        else
            isObstacleFire = false;
    }
    private void Update()
    {
        movementObstacle();
    }

    void ObstacleHP()
    {
        if(_obstacleNum < 2)
        {
            _obstacleHp = obstacleHp.ArrowHp;
        }
        else if( 1 < _obstacleNum && _obstacleNum < 4 )
        {
            _obstacleHp = obstacleHp.MissileHp;
        }
        else
            _obstacleHp = obstacleHp.SkeletHp;
    }

    public void PositionObstacle()
    {
        if (_obstacleNum < 4) // ȭ�� & �̻���
        {
           arrowRandomNumber = Random.Range(0, 2); //ȭ�� & �̻��� ���� �� ����

            for (int i = 0; i < 2; i++)
            {
                if (arrowRandomNumber == i)
                {
                    obstacleInstantiatePosition = new Vector2(player.transform.position.x + 20, -2.6f + i * 0.8f); // ȭ�� & �̻��� ���� �� �̵� ���

                    transform.position = obstacleInstantiatePosition;
                }   
            }
        }
        else
        {
            obstacleInstantiatePosition = new Vector2(player.transform.position.x + 11.5f, -1f); // ���̷��� ���� �� �̵� ���

            transform.position = obstacleInstantiatePosition;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if (collision.gameObject.layer == 9 && isObstacleFire != player.isFire) // player�� �ε����� ü���� ���̰� �����ð� ����
        {
            player.ActivateInvincibility(1f);

            if (_obstacleNum < 2)
            {
                player.PlayerHpChange(-5f); //ȭ�� ������
            }
            else if (1 < _obstacleNum && _obstacleNum < 4)
            {
                player.PlayerHpChange(-10f); //�̻��� ������
            }
            else
                player.PlayerHpChange(-10f); // ���̷��� ������   
        }

        if (collision.gameObject == _bgLooper) // bgLooper�� �ε����� �ı�
        {
            Destroy(this.gameObject);
        }
        if (bullet != null)
        {
            _obstacleHp--;

            if (_obstacleHp < 1 )
                Destroy(this.gameObject);
        }
    }

    void movementObstacle()
    {
        obstacleSpeed = Random.Range(0.04f, 0.1f);

        if (_obstacleNum < 4)
        {
            Vector2 target = new Vector2(player.transform.position.x - 500f, obstacleInstantiatePosition.y);

            transform.position = Vector2.MoveTowards(transform.position, target, obstacleSpeed);
        }
    }
}
