using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : BaseController
{
    private Animator playerAnimator;
    private BoxCollider2D playerBoxCollider2D;

    public void Start()
    {
        base.Start();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsRun", true);
        playerBoxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void Update()
    {
        Jump();
    }

    public void FixedUpdate()
    {
        AutoMove();
    }

    public override void Jump()
    {
        base.Jump();

        if (IsGrounded())
        {
            playerAnimator.SetBool("IsJump", false);
        }
        else
        {
            playerAnimator.SetBool("IsJump", true);
        }
    }

    public void Silde()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerAnimator.SetBool("IsSlide", true);
            //playerBoxCollider2D.size = 
        }
    }

    //플레어 체력 num값 만큼 증가(-가능)
    public void playerHpChange(float num)
    {
        this.hp += num;
    }
}
