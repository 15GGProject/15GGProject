using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;

    protected float speed = 12f;

    protected float jumpPower = 15f;
    protected int OriginJumpCount = 2;
    int jumpCount;

    //나중에 땅 레이어 만들어서 바꿔줘야 해
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheckPoint;

    protected float hp = 100f;

    public void Start()
    {
        //자기 컴포넌트 가져오기
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        jumpCount = OriginJumpCount;
    }

    public virtual void Jump()
    {
        //땅에 닿을때 jumpCount 초기화
        if (IsGrounded())
        {
            //Debug.Log("isground");
            jumpCount = OriginJumpCount;
        }
        // 점프 입력(왜인지모름 왜 설정한거보다 한번 더 점프하는지)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 1)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
            jumpCount--;
            //Debug.Log(jumpCount);
        }
    }
    public bool IsGrounded()
    {
        float checkDistance = 0.3f;
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, checkDistance, groundLayer);
        //Debug.Log(hit.collider.name);
        //확인용
        Debug.DrawRay(groundCheckPoint.position, Vector2.down * checkDistance, Color.red);

        return hit.collider != null;
    }
    //점프력 증감
    public virtual void JumpPowerUpDown(float num)
    {
        jumpPower += num;
    }
    //점프 횟수 증감
    public virtual void JumpCountUpDown(int num)
    {
        jumpCount += num;
    }

    public void AutoMove()
    {
        // x축 자동 이동
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }
}