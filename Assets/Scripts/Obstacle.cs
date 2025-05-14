using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Obstacle : MonoBehaviour
{
    private GameObject _player;
    private GameObject _obSpn;
    private GameObject _bgLooper;

    private ObstacleSpawner _obstacleSpawner;
    
    private int _obstacleNum;

    private int _obstacleHp;

    int arrowRandomNumber;

    Vector2 obstacleInstantiatePosition;

    [SerializeField] private ObstacleHandler obstacleHp; // Scriptable Object / SerializeField 필수!!

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Camera");
        GameObject player = GameObject.Find("Player_00");
 
        _obSpn = camera.transform.Find("ObSpnLooper").gameObject;
        _bgLooper = camera.transform.Find("BgLooper").gameObject;
        _player = player;

        _obstacleSpawner = _obSpn.GetComponent<ObstacleSpawner>();
        _obstacleNum = _obstacleSpawner.ObstacleNumber;

        PositionObstacle();
        ObstacleHP();
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
        if (_obstacleNum < 4) // 화살 & 미사일
        {
           arrowRandomNumber = Random.Range(0, 2); //화살 & 미사일 높이 값 랜덤

            for (int i = 0; i < 2; i++)
            {
                if (arrowRandomNumber == i)
                {
                    obstacleInstantiatePosition = new Vector2(_player.transform.position.x + 20, -2.6f + i * 0.8f); // 화살 & 미사일 스폰 후 이동 장소

                    transform.position = obstacleInstantiatePosition;
                }   
            }
        }
        else
        {
            obstacleInstantiatePosition = new Vector2(_player.transform.position.x + 15f, -1f); // 스켈레톤 스폰 후 이동 장소

            transform.position = obstacleInstantiatePosition;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = _player.GetComponent<Player>();
        Bullet bullet = collision.GetComponent<Bullet>();

        if (collision.gameObject == _player) // player와 부딪히면 체력이 깎이고 일정시간 무적
        {
            if (_obstacleNum < 2)
            {
                player.PlayerHpChange(-5f); //화살 데미지
            }
            else if (1 < _obstacleNum && _obstacleNum < 4)
            {
                player.PlayerHpChange(-10f); //미사일 데미지
            }
            else
                player.PlayerHpChange(-10f); // 스켈레톤 데미지
            
            //충돌 시 체력 감소 및 일정시간 무적모드 함수 부분
        }
        if (collision.gameObject == _bgLooper) // bgLooper와 부딪히면 파괴
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
        if (_obstacleNum < 4)
        {
            Vector2 target = new Vector2(_player.transform.position.x - 5f, obstacleInstantiatePosition.y);

            transform.position = Vector2.MoveTowards(transform.position, target, 0.1f);
        }
    }
}
