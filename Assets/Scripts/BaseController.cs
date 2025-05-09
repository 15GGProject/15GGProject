using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour, Elemental
{
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;

    protected float speed = 12f;

    protected float jumpPower = 15f;
    protected int OriginJumpCount = 2;
    int jumpCount;

    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheckPoint;

    protected float hp = 100f;

    protected float attackSpeed = 1f;
    protected float attackPower = 3f;

    public void Start()
    {
        //�ڱ� ������Ʈ ��������
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        jumpCount = OriginJumpCount;
    }

    public virtual void Jump()
    {
        //���� ������ jumpCount �ʱ�ȭ
        if (IsGrounded())
        {
            //Debug.Log("isground");
            jumpCount = OriginJumpCount;
        }
        // ���� �Է�(�������� �� �����Ѱź��� �ѹ� �� �����ϴ���)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 1)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
            jumpCount--;
            //Debug.Log(jumpCount);
        }
    }
    public bool IsGrounded()
    {
        float checkDistance = 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, checkDistance, groundLayer);
        //Debug.Log(hit.collider.name);
        //Ȯ�ο�
        Debug.DrawRay(groundCheckPoint.position, Vector2.down * checkDistance, Color.red);

        return hit.collider != null;
    }
    public virtual void JumpPowerUpDown(float num)
    {

    }

    public virtual void Attack()
    {

    }
    public virtual void AttackPowerUpDown(float num)
    {

    }

    public void AutoMove()
    {
        // x�� �ڵ� �̵�
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }

    public void ChangeColor()
    {

    }
}