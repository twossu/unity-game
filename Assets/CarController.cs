using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    GameObject cat;
    public float speed = 0.1f; //cargenerator���� �ӵ� ������

    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    void Update()
    {
        // �������� �̵�
        transform.Translate(-speed, 0, 0);

        // ȭ�� ���� �ٱ����� ������ ����
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }

        // �浹 ����
        Vector2 p1 = transform.position;           // �ڵ��� ��ġ
        Vector2 p2 = this.cat.transform.position;  // ����� ��ġ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;  // �ڵ��� �ݰ�
        float r2 = 0.5f;  // ����� �ݰ�

        if (d < r1 + r2)
        {
            // ���� ��ũ��Ʈ�� �÷��̾�� ȭ���� �浹�ߴٰ� �����Ѵ� 
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            // �浹�ߴٸ� ȭ���� �����
            Destroy(gameObject);

        }
    }
}