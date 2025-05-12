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

    //�Ѿ� ����
    public void BulletAdvance()
    {
        rigidbody.velocity = shotDirection * bulletSpeed;
    }

    //�Ѿ� ����
    public void SetDirection()
    {
        shotDirection = player.SetClickDirection();
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
            //gameObject.SetActive(false);
        }
    }
}
