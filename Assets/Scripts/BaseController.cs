using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;

    [Range(0f,8f)]protected float speed = 8f;

    protected float jumpPower = 15f;
    protected int OriginJumpCount = 1;
    int jumpCount;

    //���߿� �� ���̾� ���� �ٲ���� �� -> ����
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheckPoint;

    public float currentHp { get; protected set; } = 100f;
    public float maxHp { get; protected set; } = 100f;

    public void Start()
    {
        //�ڱ� ������Ʈ ��������
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //���� Ƚ�� �ʱ�ȭ
        jumpCount = OriginJumpCount;
    }
    //���� ����
    public virtual void Jump()
    {
        //���� ������ jumpCount �ʱ�ȭ
        if (IsGrounded())
        {
            //Debug.Log("isground");
            jumpCount = OriginJumpCount;
        }
        // ���� �Է�(�������� �� �����Ѱź��� �ѹ� �� �����ϴ���)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount >= 1)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
            jumpCount--;
            Debug.Log(jumpCount);
        }
    }
    //������ �ƴ��� bool�� ��ȯ
    public bool IsGrounded()
    {
        
        float checkDistance = 0.3f;
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, checkDistance, groundLayer);

        //Ȯ�ο�
        //if (hit.collider != null)Debug.Log(hit.collider.gameObject.layer);
        //Ȯ�ο�
        Debug.DrawRay(groundCheckPoint.position, Vector2.down * checkDistance, Color.red);

        return hit.collider != null;
    }
    //������ ����
    public virtual void JumpPowerUpDown(float num)
    {
        jumpPower += num;
    }
    //���� Ƚ�� ����
    public virtual void JumpCountUpDown(int num)
    {
        jumpCount += num;
    }
    // x�� �ڵ� �̵�
    public void AutoMove()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }
    //x�� �ӵ� ����
    public void SpeedUpDown(float num)
    {
        speed += num;
    }
}