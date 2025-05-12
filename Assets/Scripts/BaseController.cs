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

<<<<<<< HEAD
=======
    //나중에 땅 레이어 만들어서 바꿔줘야 해
>>>>>>> dev_player_a
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheckPoint;

    protected float hp = 100f;

<<<<<<< HEAD
    protected float attackSpeed = 1f;
    protected float attackPower = 3f;

=======
>>>>>>> dev_player_a
    public void Start()
    {
        //자기 컴포넌트 가져오기
        rigidBody = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        spriteRenderer = GetComponent<SpriteRenderer>();
=======
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
>>>>>>> dev_player_a

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
<<<<<<< HEAD
        float checkDistance = 0.2f;
=======
        float checkDistance = 0.3f;
>>>>>>> dev_player_a
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, checkDistance, groundLayer);
        //Debug.Log(hit.collider.name);
        //확인용
        Debug.DrawRay(groundCheckPoint.position, Vector2.down * checkDistance, Color.red);

        return hit.collider != null;
    }
<<<<<<< HEAD
    public virtual void JumpPowerUpDown(float num)
    {

    }

    public virtual void Attack()
    {

    }
    public virtual void AttackPowerUpDown(float num)
    {

=======
    //점프력 증감
    public virtual void JumpPowerUpDown(float num)
    {
        jumpPower += num;
    }
    //점프 횟수 증감
    public virtual void JumpCountUpDown(int num)
    {
        jumpCount += num;
>>>>>>> dev_player_a
    }

    public void AutoMove()
    {
        // x축 자동 이동
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }
}