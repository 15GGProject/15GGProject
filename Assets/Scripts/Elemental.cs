using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    public bool ChangeAllElemental(SpriteRenderer spriteRenderer, bool isFire)
    {
        //불이라면 얼음로 바꾸기
        if (isFire)
        {
            spriteRenderer.color = new Color(0.33f, 0.33f, 1f);
            isFire = false;
        }
        //얼음이라면 불로 바꾸기
        else
        {
            spriteRenderer.color = new Color(1, 0.33f, 0.33f);
            isFire = true;
        }

        //Debug.Log(spriteRenderer.color);
        return isFire;
    }

    public void ApplyElemental(SpriteRenderer spriteRenderer, bool isFire)
    {
        //불이라면 불로
        if (isFire)
        {
            spriteRenderer.color = new Color(1f, 0.33f, 0.33f);
        }
        //얼음이라면 얼음으로
        else
        {
            spriteRenderer.color = new Color(0.33f, 0.33f, 1f);
        }
    }
}