using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform startTransform;
    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        startTransform = GetComponentInParent<Transform>();
    }

    //public void 
}
