using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Map : MonoBehaviour
{
    public float widthPadding = 4f; // �� ������ ����
    float width;
    public void SetPlace(Vector3 lastPosition, int mapidx)
    {
        Vector3 newPosition = lastPosition;
        //if(lastPosition == Vector3.zero) return newPosition = new Vector3(0,0,0);
        width = ((BoxCollider2D)this.GetComponent<Collider2D>()).size.x;
            newPosition.x += (width + widthPadding)*mapidx; // ���� �߰�
        Debug.Log("Name :"+this.name+"newPosition : "+newPosition.x+"width : "+ width + "widthPadding : "+widthPadding);
        this.transform.position = newPosition;
    }
}
