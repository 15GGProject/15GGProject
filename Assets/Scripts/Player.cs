using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using UnityEditor.Tilemaps;
>>>>>>> dev_player_a
using UnityEngine;
using UnityEngine.Timeline;

public class Player : BaseController
{
    private Animator playerAnimator;
<<<<<<< HEAD
    private BoxCollider2D boxCollider2D;
=======
    private BoxCollider2D playerBoxCollider2D;
    private Vector2 orignBoxSize;
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private Elemental Elemental;

    public PoolManager poolManager;

    protected float attackSpeed = 1f;
    protected float attackPower = 3f;

    private bool isFire = false;
>>>>>>> dev_player_a

    public void Start()
    {
        base.Start();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsRun", true);
<<<<<<< HEAD
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

=======
        playerBoxCollider2D = GetComponent<BoxCollider2D>();
        orignBoxSize = playerBoxCollider2D.size;
        isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);
    }
    public void Update()
    {
        //�����̽��� �� ����
        Jump();

        //��Ʈ�� Ű�� �����̵�
        Silde();

        //���콺 ��Ŭ������ ����
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack(SetClickDirection());
        }

        //t�� �Ӽ� ��ȯ
        if (Input.GetKeyDown(KeyCode.T))
        {
            isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);
        }
    }
    public void FixedUpdate()
    {
        //�ڵ��̵�
        AutoMove();
    }

    //���� �پ������� �������� + ���� Ƚ�� �ʱ�ȭ
>>>>>>> dev_player_a
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

<<<<<<< HEAD
    public void Silde()
    {

    }
}
=======
    //���� �پ������� �����̵� ����
    public void Silde()
    {
        if (IsGrounded() && Input.GetKey(KeyCode.LeftControl))
        {
            playerAnimator.SetBool("IsSlide", true);
            playerBoxCollider2D.size = new Vector2(orignBoxSize.x * 1.2f, orignBoxSize.y * 0.5f);
        }
        else
        {
            playerAnimator.SetBool("IsSlide", false);
            playerBoxCollider2D.size = orignBoxSize;
        }
    }

    //�÷��� ü�� num�� ��ŭ ����(-����)
    public void PlayerHpChange(float num)
    {
        this.hp += num;
    }

    //���콺 ��ġ ���� ��ǥ�� �÷��̾� ��ġ�� ������ ���Ͱ��� ��ֶ����� ���� �����ִ� �Լ�
    public Vector2 SetClickDirection()
    {
        Vector2 shotDirection = Vector2.zero;

        //���콺 �������� ���� ��ǥ�� ��ȯ�ϱ�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //Debug.Log(mousePos);
        shotDirection = mousePos - bulletStartPosition.position;
        //Debug.Log("shotDirection : " + shotDirection);
        return shotDirection.normalized;
    }

    //������Ʈ Ǯ���� �Ѿ� �����ͼ� ���
    public void Attack(Vector2 vector)
    {
        GameObject bullet = poolManager.GetBullet();
        bullet.transform.position = bulletStartPosition.position;
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null && bullet.activeInHierarchy)
        {
            bulletScript.SetDirection(vector);
            bulletScript.SetIsFire(isFire);
            Elemental.ApplyElemental(bullet.GetComponentInChildren<SpriteRenderer>(),isFire);
        }
    }

    //���ݷ� ����
    public void AttackPowerUpDown(float num)
    {
        attackPower += num;
    }
    public float OutSpeed()
    {
        return speed;
    }

    public bool IsFire()
    {
        return isFire;
    }
}
>>>>>>> dev_player_a
