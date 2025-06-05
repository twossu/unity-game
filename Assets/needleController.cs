using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleController : MonoBehaviour
{
    GameObject cat;
    public float speed = 0.1f; //cargenerator에서 속도 가져옴

    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다
        transform.Translate(-speed, 0, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position;              // 화살의 중심 좌표
        Vector2 p2 = this.cat.transform.position;  // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;  // 화살의 반경
        float r2 = 1.0f;  // 플레이어의 반경

        if (d < r1 + r2)
        {
            // 충돌한 경우는 화살을 지운다
            Destroy(gameObject);
        }
    }
}
