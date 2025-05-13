using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Map : MonoBehaviour
{
    public float widthPadding = 4f; // 맵 사이의 간격
    float width;
    public Vector3 SetPlace(Vector3 lastPosition, int mapcount)
    {
        Vector3 newPosition = lastPosition;
        width = ((BoxCollider2D)this.GetComponent<Collider2D>()).size.x;

        newPosition.x += width + widthPadding; // 공백 추가



        this.transform.position = newPosition;
        return newPosition;
    }
}
