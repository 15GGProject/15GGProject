using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Map : MonoBehaviour
{
    public float widthPadding = 4f; // 맵 사이의 간격
    float width;
    public Vector3 SetPlace(Vector3 lastposition)
    {
        Vector3 pos = lastposition;
        width = ((BoxCollider2D)this.GetComponent<Collider2D>()).size.x;
        pos.x += width + widthPadding;
        this.transform.position = pos;
        return pos;
    }
}
