using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected SpriteRenderer spriteRenderer;

    [SerializeField] protected float speed = 3f;

    [SerializeField] protected float jampPower = 3f;
    [SerializeField] protected int jampCount = 3;

    [SerializeField] protected float hp = 100f;

    [SerializeField] protected float attackSpeed = 1f;
    [SerializeField] protected float attackPower = 3f;

    public void Start()
    {
        //자기 컴포넌트 가져오기
        rigidBody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    public void Jamp()
    {

    }
    public void JampPowerUpDown(float num)
    {

    }

    public void Attack()
    {

    }
    public void AttackPowerUpDown(float num)
    {

    }

}