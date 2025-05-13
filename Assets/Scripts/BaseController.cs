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

    //나중에 땅 레이어 만들어서 바꿔줘야 해 -> 했음
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheckPoint;

    public float currentHp { get; protected set; } = 100f;
    public float maxHp { get; protected set; } = 100f;

    public void Start()
    {
        //자기 컴포넌트 가져오기
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //점프 횟수 초기화
        jumpCount = OriginJumpCount;
    }
    //점프 구현
    public virtual void Jump()
    {
        //땅에 닿을때 jumpCount 초기화
        if (IsGrounded())
        {
            //Debug.Log("isground");
            jumpCount = OriginJumpCount;
        }
        // 점프 입력(왜인지모름 왜 설정한거보다 한번 더 점프하는지)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount >= 1)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
            jumpCount--;
            Debug.Log(jumpCount);
        }
    }
    //땅인지 아닌지 bool값 반환
    public bool IsGrounded()
    {
        
        float checkDistance = 0.3f;
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, checkDistance, groundLayer);

        //확인용
        //if (hit.collider != null)Debug.Log(hit.collider.gameObject.layer);
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
    // x축 자동 이동
    public void AutoMove()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }
    //x축 속도 증감
    public void SpeedUpDown(float num)
    {
        speed += num;
    }
}