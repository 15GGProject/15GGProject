using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Map : MonoBehaviour
{
    public float widthPadding = 4f; // �� ������ ����
    float width;
    public Vector3 SetPlace(Vector3 lastPosition, int mapcount)
    {
        Vector3 newPosition = lastPosition;
        width = ((BoxCollider2D)this.GetComponent<Collider2D>()).size.x;

        newPosition.x += width + widthPadding; // ���� �߰�



        this.transform.position = newPosition;
        return newPosition;
    }
}
