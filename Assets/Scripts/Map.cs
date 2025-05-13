using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Map: MonoBehaviour
{
    public float widthPadding = 4f;//방해물의 폭(좌우공간)을 정의
    public Vector3 SetPlace(Vector3 lastPosition, int obstacleCount)//랜덤으로 방해물을 생성하는 메서드(마지막포지션,방해물의갯수)
    {
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);//생성되는 x축은 마지막포지션에 패딩값을 더해준다.

        transform.position = placePosition;//x값을 넣어준다.

        return placePosition;//플레이스 포지션을 리턴한다.
    }
}
