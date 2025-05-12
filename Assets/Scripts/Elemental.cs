using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    public bool ChangeAllElemental(SpriteRenderer spriteRenderer, bool isFire)
    {
        //���̶�� ������ �ٲٱ�
        if (isFire)
        {
            spriteRenderer.color = new Color(0.33f, 0.33f, 1f);
            isFire = false;
        }
        //�����̶�� �ҷ� �ٲٱ�
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
        //���̶�� �ҷ�
        if (isFire)
        {
            spriteRenderer.color = new Color(1f, 0.33f, 0.33f);
        }
        //�����̶�� ��������
        else
        {
            spriteRenderer.color = new Color(0.33f, 0.33f, 1f);
        }
    }
}