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

    public PoolManager poolManager;

    protected float AttackTime;
    protected float coolDownAttack { get; private set; } = 0.2f;
    protected float attackPower { get; private set; } = 3f;

    protected int level { get; private set; } = 1;
    protected float maxExperiencePoint { get; private set; } = 100;
    protected float currentExperiencePoint { get; private set; } = 0;
    public int gold { get; private set; } = 0;

    public bool isFire { get; private set; } = false;
    private bool isInvincible = false;

    private bool isSpeedBuffed = false; // 스c드 버프 상태 유무

    public void Start()
    {
        GameManager.Instance.RegisterPlayer(this); // GameManager에 이 Player 인스턴스를 등록
        base.Start();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsRun", true);
        playerBoxCollider2D = GetComponent<BoxCollider2D>();
        orignBoxSize = playerBoxCollider2D.size;
        orignBoxOffset = playerBoxCollider2D.offset; // YH EDIT
        isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);

        AttackTime = coolDownAttack;

        GameManager.Instance.RegisterPlayer(this); // GameManager에 이 Player 인스턴스를 등록
    }
    public void Update()
    {
        //스페이스바 로 점프
        Jump();

        //컨트롤 키로 슬라이딩
        Silde();

        //땅에 있으면 자동이동
        if (IsGrounded()) AutoMove();

        //일정 시간 마다 공격 가능하게
        AttackTime += Time.deltaTime;
        //Debug.Log(AttackTime);
        //마우스 우클릭으로 공격
        if (Input.GetKeyDown(KeyCode.Mouse0) && AttackTime >= coolDownAttack)
        {
            Attack(SetClickDirection());
            AttackTime = 0;
        }
        //g로 속성 전환
        if (Input.GetKeyDown(KeyCode.G))
        {
            isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);
        }
        //무적 테스트
        if(Input.GetKeyDown(KeyCode.K))
        {
            ActivateInvincibility(3f);
        }
    }

    //땅에 붙어있으면 점프 가능 + 점프 횟수 초기화
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

    //땅에 붙어있으면 슬라이딩 가능
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

    //마우스 위치 좌표와 플레이어 위치를 연결한 백터값의 노멀라이즈 값을 구해주는 함수
    public Vector2 SetClickDirection()
    {
        Vector2 shotDirection = Vector2.zero;

        //마우스 포지션을 월드 좌표로 변환하기
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //Debug.Log(mousePos);
        shotDirection = mousePos - bulletStartPosition.position;
        //Debug.Log("shotDirection : " + shotDirection);
        return shotDirection.normalized;
    }

    //오브젝트 풀에서 총알 가져와서 쏘기
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

    //넣어준 시간에 따라 무적시간을 걸어주는 함수
    public void ActivateInvincibility(float duration)
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine(duration));
        }
    }

    //무적 코루틴
    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        //Invincibility(10)
        this.gameObject.layer = 10;
        //Debug.Log("무적 상태 시작"+ this.gameObject.layer);

        float elapsed = 0f;
        bool visible = true;
        float blinkInterval = 0.1f; //깜빡이는 간격(0.1초마다)

        // 깜빡임 루프 (무적 시간 동안 반복)
        while (elapsed < duration)
        {
            elapsed += blinkInterval;
            //Debug.Log(elapsed);

            // 알파값 변경
            Color color = spriteRenderer.color;
            color.a = visible ? 0.2f : 1f;
            spriteRenderer.color = color;

            visible = !visible;

            yield return new WaitForSeconds(blinkInterval); // 깜빡이는 간격 (0.1초마다)
        }

        // 원래대로 복구
        Color resetColor = spriteRenderer.color;
        resetColor.a = 1f;
        spriteRenderer.color = resetColor;

        isInvincible = false;
        //Player(9)
        this.gameObject.layer = 9;
        //Debug.Log("무적 상태 종료" + this.gameObject.layer);
    }

    //골드 증감
    public void GoldUpDown(int num)
    {
        gold += num;
    }
    //경험치 증감(필요없을 가능성 높음)
    public void ExperiencePointUpDown(float num)
    {
        currentExperiencePoint += num;

        while (true)
        {
            //현재 경험치가 최대 경험치 이상이라면 레벨 올리고 그만큼 빼줌
            if (currentExperiencePoint >= maxExperiencePoint)
            {
                level++;
                currentExperiencePoint -= maxExperiencePoint;
            }
            //0보다 작다면 다시 0으로
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
    //공격력 증감(필요없을듯)
    public void AttackPowerUpDown(float num)
    {
        attackPower += num;
    }
    public void ApplyItemEffect(ItemDate data, GameObject itemObj)
    {
        // 버프 처리
        if (data.itemType == ItemType.Speed)
        {
            StartCoroutine(SetActive(itemObj));

            ActivateInvincibility(5f);
            StartCoroutine(SpeedBuffTimer(data.duration));//버프지속시간

            if (isSpeedBuffed) return;

            isSpeedBuffed = true;


            SpeedUpDown(4f); // 예: 기본 8에서 12로 증가
        }
        else if (data.itemType == ItemType.Heal)
        {
            StartCoroutine(SetActive(itemObj));
            PlayerHpChange(30);
        }
    }
    private IEnumerator SpeedBuffTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (isSpeedBuffed)
        {
            SpeedUpDown(-4f); // 증가시킨 만큼 다시 빼기
        }
        isSpeedBuffed = false;
    }
    //플레이어 체력 num값 만큼 증가(-가능)
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
    //플레이어 공격 속도 증감
    public void AttackSpeedUpDown(float num)
    {
        coolDownAttack += num;
        if(coolDownAttack<0f)
        {
            coolDownAttack = 0f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //구조물에 닿았을때 무적시간 
        if(collision.gameObject.layer == 8 && this.gameObject.layer == 9)
        {
            PlayerHpChange(-5f);
            ActivateInvincibility(1f);
        }
    }
    private IEnumerator SetActive(GameObject item)
    {
        yield return new WaitForSeconds(2f);
        item.SetActive(true);
    }
}