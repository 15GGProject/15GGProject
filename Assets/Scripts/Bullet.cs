using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Player player;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;

    private Vector2 shotDirection;

    private float bulletSpeed = 15f;
    private bool isFire = false;

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
        //Debug.Log("�ٲٱ� �� : " + rigidbody2D.velocity);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + player.OutSpeed(), rigidbody2D.velocity.y);
        //Debug.Log("player rigidbody : " + player.GetComponent<Rigidbody2D>().velocity.x);
        //Debug.Log("�ٲ� �� : " + rigidbody2D.velocity);
    }

    //�Ѿ� ����
    public void SetDirection(Vector2 vector)
    {
        shotDirection = vector;
    }

    public void SetIsFire(bool fire)
    {
        isFire = fire;
        Debug.Log("�Ѿ� �Ӽ� : " + isFire);
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
