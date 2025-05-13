using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    private GameObject player;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;

    private Vector2 shotDirection;

    private float bulletSpeed = 20f;
    private bool isFire = false;

    //3(ice),7(fire),8(Obstacle)
    private int layerMask = (1 << 8) | (1 << 7) | (1 << 3);

    float time = 0f;

    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        BulletAdvance();

        //10초후 총알 비활성화
        time += Time.deltaTime;
        if (time >= 10)
        {
            gameObject.SetActive(false);
        }
    }

    //총알 전진
    public void BulletAdvance()
    {
        rigidbody2D.velocity = shotDirection * bulletSpeed;
        //Debug.Log("바꾸기 전 : " + rigidbody2D.velocity);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + player.GetComponent<Player>().OutSpeed(), rigidbody2D.velocity.y);
        //Debug.Log("player rigidbody : " + player.GetComponent<Rigidbody2D>().velocity.x);
        //Debug.Log("바꾼 후 : " + rigidbody2D.velocity);
    }

    //총알 방향 설정
    public void SetDirection(Vector2 vector)
    {
        shotDirection = vector;
    }

    //속성 설정
    public void SetIsFire(bool fire)
    {
        isFire = fire;
        //Debug.Log("총알 속성 : " + isFire);
    }

    //총알 속도 증감
    public void BulletSpeedUpDown(float num)
    {
        bulletSpeed += num;
    }

    //총알 발사 각도 조절
    public void AdjustAngle(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //Debug.Log("총알 로테이션 값 : " + transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //3(ice),7(fire),8(Obstacle) 일때 비활성화
        if ((layerMask & (1<<collision.gameObject.layer)) != 0)
        {
            gameObject.SetActive(false);
        }
    }
}
