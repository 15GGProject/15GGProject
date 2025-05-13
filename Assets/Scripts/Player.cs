using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : BaseController
{
    [SerializeField] private Camera _camera;
    private Animator playerAnimator;
    private BoxCollider2D playerBoxCollider2D;
    private Vector2 orignBoxSize;
    private Vector2 orignBoxOffset; //YH EDIT
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private Elemental Elemental;

    [Range(0f, 8f)] protected float speed = 8f;

    public PoolManager poolManager;

    protected float AttackTime;
    protected float coolDownAttack { get; private set; } = 0.2f;
    protected float attackPower { get; private set; } = 3f;

    protected int level { get; private set; } = 1;
    protected float maxExperiencePoint { get; private set; } = 100;
    protected float currentExperiencePoint { get; private set; } = 0;
    protected int gold { get; private set; } = 0;

    private bool isFire = false;
    private bool isInvincible = false;


    public void Start()
    {
        base.Start();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsRun", true);
        playerBoxCollider2D = GetComponent<BoxCollider2D>();
        orignBoxSize = playerBoxCollider2D.size;
        orignBoxOffset = playerBoxCollider2D.offset; // YH EDIT
        isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);

        AttackTime = coolDownAttack;
    }
    public void Update()
    {
        //�����̽��� �� ����
        Jump();

        //��Ʈ�� Ű�� �����̵�
        Silde();

        //���� ������ �ڵ��̵�
        if (IsGrounded()) AutoMove();

        //���� �ð� ���� ���� �����ϰ�
        AttackTime += Time.deltaTime;
        //Debug.Log(AttackTime);
        //���콺 ��Ŭ������ ����
        if (Input.GetKeyDown(KeyCode.Mouse0) && AttackTime >= coolDownAttack)
        {
            Attack(SetClickDirection());
            AttackTime = 0;
        }
        //g�� �Ӽ� ��ȯ
        if (Input.GetKeyDown(KeyCode.G))
        {
            isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);
        }
        //���� �׽�Ʈ
        if(Input.GetKeyDown(KeyCode.K))
        {
            ActivateInvincibility(3f);
        }
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
            playerBoxCollider2D.offset = new Vector2(orignBoxOffset.x, orignBoxOffset.y - 0.2f); //YH EDIT
        }
        else
        {
            playerAnimator.SetBool("IsSlide", false);
            playerBoxCollider2D.size = orignBoxSize;
            playerBoxCollider2D.offset = orignBoxOffset; // YH EDIT
        }
    }

    //���콺 ��ġ ���� ��ǥ�� �÷��̾� ��ġ�� ������ ���Ͱ��� ��ֶ����� ���� �����ִ� �Լ�
    public Vector2 SetClickDirection()
    {
        Vector2 shotDirection = Vector2.zero;

        //���콺 �������� ���� ��ǥ�� ��ȯ�ϱ�
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
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
            Elemental.ApplyElemental(bullet.GetComponentInChildren<SpriteRenderer>(), isFire);

            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            bulletScript.AdjustAngle(angle);

            bulletScript.setTime();
        }
    }

    //�־��� �ð��� ���� �����ð��� �ɾ��ִ� �Լ�
    public void ActivateInvincibility(float duration)
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine(duration));
        }
    }

    //���� �ڷ�ƾ
    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        //Invincibility(10)
        this.gameObject.layer = 10;
        Debug.Log("���� ���� ����"+ this.gameObject.layer);

        float elapsed = 0f;
        bool visible = true;
        float blinkInterval = 0.1f; //�����̴� ����(0.1�ʸ���)

        // ������ ���� (���� �ð� ���� �ݺ�)
        while (elapsed < duration)
        {
            elapsed += blinkInterval;
            Debug.Log(elapsed);

            // ���İ� ����
            Color color = spriteRenderer.color;
            color.a = visible ? 0.2f : 1f;
            spriteRenderer.color = color;

            visible = !visible;

            yield return new WaitForSeconds(blinkInterval); // �����̴� ���� (0.1�ʸ���)
        }

        // ������� ����
        Color resetColor = spriteRenderer.color;
        resetColor.a = 1f;
        spriteRenderer.color = resetColor;

        isInvincible = false;
        //Player(9)
        this.gameObject.layer = 9;
        Debug.Log("���� ���� ����" + this.gameObject.layer);
    }

    //��� ����
    public void GoldUpDown(int num)
    {
        gold += num;
    }
    //����ġ ����(�ʿ���� ���ɼ� ����)
    public void ExperiencePointUpDown(float num)
    {
        currentExperiencePoint += num;

        while (true)
        {
            //���� ����ġ�� �ִ� ����ġ �̻��̶�� ���� �ø��� �׸�ŭ ����
            if (currentExperiencePoint >= maxExperiencePoint)
            {
                level++;
                currentExperiencePoint -= maxExperiencePoint;
            }
            //0���� �۴ٸ� �ٽ� 0����
            else if (currentExperiencePoint < 0)
            {
                currentExperiencePoint = 0;
            }
            else
            {
                break;
            }
        }
    }
    //���ݷ� ����(�ʿ������)
    public void AttackPowerUpDown(float num)
    {
        attackPower += num;
    }
    //�÷��̾� ü�� num�� ��ŭ ����(-����)
    public void PlayerHpChange(float num)
    {
        this.currentHp += num;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        else if(currentHp<0)
        {
            currentHp = 0;
        }
    }
    //�÷��̾� ���� �ӵ� ����
    public void AttackSpeedUpDown(float num)
    {
        coolDownAttack += num;
        if(coolDownAttack<0f)
        {
            coolDownAttack = 0f;
        }
    }
}