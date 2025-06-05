using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
 
        // ���� ȭ��ǥ
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(0, 1.4f, 0);

        }

        // ������ ȭ��ǥ
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(0, -1.4f, 0);

        }

        //y �̵�����
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);  //�� �Ʒ� �Ѿ�� �ʵ���
        transform.position = pos;

    }
}
