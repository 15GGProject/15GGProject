using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform startTransform;

    private float bulletSpeed = 1f;

    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        startTransform = GetComponentInParent<Transform>();
    }

    public void BulletAdvance(Vector2 vector)
    {
        
    }

    public void BulletSpeedUpDown(float num)
    {
        bulletSpeed += num;
    }
}
