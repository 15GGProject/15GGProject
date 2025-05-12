using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : BaseController
{
    private Animator playerAnimator;
    private BoxCollider2D playerBoxCollider2D;
    private Vector2 orignBoxSize;
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private Elemental Elemental;

    public PoolManager poolManager;

    protected float attackSpeed = 1f;
    protected float attackPower = 3f;

    protected int level = 1;
    protected float maxExperiencePoint = 100;
    protected float currentExperiencePoint = 0;
    protected int gold = 0;

    private bool isFire = false;

    public void Start()
    {
        base.Start();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsRun", true);
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

    //���� �پ������� ���� ���� + ���� Ƚ�� �ʱ�ȭ
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

    //��� ����
    public void GoldUpDown(int num)
    {
        gold += num;
    }
    //����ġ ����
    public void ExperiencePointUpDown(float num)
    {
        currentExperiencePoint += num;

        while (true)
        {
            if (currentExperiencePoint > maxExperiencePoint)
            {
                level++;
                currentExperiencePoint-=maxExperiencePoint;
            }
            else if(currentExperiencePoint<0)
            {
                currentExperiencePoint = 0;
            }
            else
            {
                break;
            }
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
    public bool OutIsFire()
    {
        return isFire;
    }
}