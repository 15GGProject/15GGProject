using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : BaseController
{
    private Animator playerAnimator;
    private BoxCollider2D boxCollider2D;

    public void Start()
    {
        base.Start();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsRun", true);
        boxCollider2D = GetComponent<BoxCollider2D>();
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

    public void PlayerHpChange(float num)
    {
        this.hp += num;

    }

    public void Silde()
    {

    }
}
