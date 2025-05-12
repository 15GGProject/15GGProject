using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Player player;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;

    private Vector2 shotDirection;

    private float bulletSpeed = 10f;

    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        BulletAdvance();
    }

    //총알 전진
    public void BulletAdvance()
    {
        rigidbody2D.velocity = shotDirection * bulletSpeed;
        //Debug.Log(rigidbody2D.velocity);
    }

    //총알 방향
    public void SetDirection(Vector2 vector)
    {
        shotDirection = vector;
    }

    //총알 속도 증감
    public void BulletSpeedUpDown(float num)
    {
        bulletSpeed += num;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != player.name)
        {
            //Debug.Log(collision);
            //플레이어가 아니라면 부딪치면 비활성화
            gameObject.SetActive(false);
        }
    }
}
