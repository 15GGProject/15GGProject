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
    
    //�Ѿ� ����
    public void BulletAdvance(Vector2 vector)
    {
        rigidbody.velocity = vector.normalized*bulletSpeed;
    }
    
    //�Ѿ� �ӵ� ����
    public void BulletSpeedUpDown(float num)
    {
        bulletSpeed += num;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            //���� �ε�ġ�� ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}
