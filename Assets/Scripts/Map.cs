using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Map: MonoBehaviour
{
    public float widthPadding = 4f;//���ع��� ��(�¿����)�� ����
    public Vector3 SetPlace(Vector3 lastPosition, int obstacleCount)//�������� ���ع��� �����ϴ� �޼���(������������,���ع��ǰ���)
    {
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);//�����Ǵ� x���� �����������ǿ� �е����� �����ش�.

        transform.position = placePosition;//x���� �־��ش�.

        return placePosition;//�÷��̽� �������� �����Ѵ�.
    }
}
