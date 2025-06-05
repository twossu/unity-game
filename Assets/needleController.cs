using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleController : MonoBehaviour
{
    GameObject cat;
    public float speed = 0.1f; //cargenerator���� �ӵ� ������

    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    void Update()
    {
        // �����Ӹ��� ������� ���Ͻ�Ų��
        transform.Translate(-speed, 0, 0);

        // ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }

        // �浹 ����
        Vector2 p1 = transform.position;              // ȭ���� �߽� ��ǥ
        Vector2 p2 = this.cat.transform.position;  // �÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;  // ȭ���� �ݰ�
        float r2 = 1.0f;  // �÷��̾��� �ݰ�

        if (d < r1 + r2)
        {
            // �浹�� ���� ȭ���� �����
            Destroy(gameObject);
        }
    }
}
