using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Player player;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    private Vector2 shotDirection;

    private float bulletSpeed = 1000f;

    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    public void Update()
    {
        BulletAdvance();
    }

    //총알 전진
    public void BulletAdvance()
    {
        rigidbody.velocity = shotDirection * bulletSpeed;
    }

    //총알 방향
    public void SetDirection()
    {
        shotDirection = player.SetClickDirection();
    }

    //총알 속도 증감
    public void BulletSpeedUpDown(float num)
    {
        bulletSpeed += num;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            //뭐라도 부딪치면 비활성화
            //gameObject.SetActive(false);
        }
    }
}
