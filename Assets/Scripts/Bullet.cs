using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    private float bulletSpeed = 1f;

    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponentInChildren<Rigidbody2D>();
    }
    
    //총알 전진
    public void BulletAdvance(Vector2 vector)
    {
        rigidbody.velocity = vector.normalized*bulletSpeed;
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
            //뭐라도 부딧치면 비활성화
            gameObject.SetActive(false);
        }
    }
}
