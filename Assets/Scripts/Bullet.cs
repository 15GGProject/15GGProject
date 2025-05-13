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

        //10���� �Ѿ� ��Ȱ��ȭ
        time += Time.deltaTime;
        if (time >= 10)
        {
            gameObject.SetActive(false);
        }
    }

    //�Ѿ� ����
    public void BulletAdvance()
    {
        rigidbody2D.velocity = shotDirection * bulletSpeed;
        //Debug.Log("�ٲٱ� �� : " + rigidbody2D.velocity);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + player.GetComponent<Player>().OutSpeed(), rigidbody2D.velocity.y);
        //Debug.Log("player rigidbody : " + player.GetComponent<Rigidbody2D>().velocity.x);
        //Debug.Log("�ٲ� �� : " + rigidbody2D.velocity);
    }

    //�Ѿ� ���� ����
    public void SetDirection(Vector2 vector)
    {
        shotDirection = vector;
    }

    //�Ӽ� ����
    public void SetIsFire(bool fire)
    {
        isFire = fire;
        //Debug.Log("�Ѿ� �Ӽ� : " + isFire);
    }

    //�Ѿ� �ӵ� ����
    public void BulletSpeedUpDown(float num)
    {
        bulletSpeed += num;
    }

    //�Ѿ� �߻� ���� ����
    public void AdjustAngle(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //Debug.Log("�Ѿ� �����̼� �� : " + transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //3(ice),7(fire),8(Obstacle) �϶� ��Ȱ��ȭ
        if ((layerMask & (1<<collision.gameObject.layer)) != 0)
        {
            gameObject.SetActive(false);
        }
    }
}
