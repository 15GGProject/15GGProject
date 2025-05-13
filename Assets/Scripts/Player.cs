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
        orignBoxOffset = playerBoxCollider2D.offset; // YH EDIT
        isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);
    }
    public void Update()
    {
        //스페이스바 로 점프
        Jump();

        //컨트롤 키로 슬라이딩
        Silde();

        //마우스 우클릭으로 공격
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack(SetClickDirection());
        }

        //t로 속성 전환
        if (Input.GetKeyDown(KeyCode.T))
        {
            isFire = Elemental.ChangeAllElemental(spriteRenderer, isFire);
        }
    }
    public void FixedUpdate()
    {
        //자동이동
        AutoMove();
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

    //플레어 체력 num값 만큼 증가(-가능)
    public void PlayerHpChange(float num)
    {
        this.currentHp += num;
    }

    
    //마우스 위치 월드 좌표와 플레이어 위치를 연결한 백터값의 노멀라이즈 값을 구해주는 함수
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
            Elemental.ApplyElemental(bullet.GetComponentInChildren<SpriteRenderer>(),isFire);
            float angle = Mathf.Atan2(vector.y,vector.x)*Mathf.Rad2Deg;
            bulletScript.AdjustAngle(angle);
        }
    }

    //골드 증감
    public void GoldUpDown(int num)
    {
        gold += num;
    }
    //경험치 증감
    public void ExperiencePointUpDown(float num)
    {
        currentExperiencePoint += num;

        while (true)
        {
            //현재 경험치가 최대 경험치 이상이라면 레벨 올리고 그만큼 빼줌
            if (currentExperiencePoint >= maxExperiencePoint)
            {
                level++;
                currentExperiencePoint-=maxExperiencePoint;
            }
            //0보다 작다면 다시 0으로
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
    //공격력 증감
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