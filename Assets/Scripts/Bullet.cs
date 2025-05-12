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

    //�Ѿ� ����
    public void BulletAdvance()
    {
        rigidbody2D.velocity = shotDirection * bulletSpeed;
        //Debug.Log(rigidbody2D.velocity);
    }

    //�Ѿ� ����
    public void SetDirection(Vector2 vector)
    {
        shotDirection = vector;
    }

    //�Ѿ� �ӵ� ����
    public void BulletSpeedUpDown(float num)
    {
        bulletSpeed += num;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != player.name)
        {
            //Debug.Log(collision);
            //�÷��̾ �ƴ϶�� �ε�ġ�� ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}
