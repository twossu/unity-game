using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    GameObject cat;
    public float speed = 0.1f; //cargenerator에서 속도 가져옴

    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    void Update()
    {
        // 왼쪽으로 이동
        transform.Translate(-speed, 0, 0);

        // 화면 왼쪽 바깥으로 나가면 제거
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position;           // 자동차 위치
        Vector2 p2 = this.cat.transform.position;  // 고양이 위치
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;  // 자동차 반경
        float r2 = 0.5f;  // 고양이 반경

        if (d < r1 + r2)
        {
            // 감독 스크립트에 플레이어와 화살이 충돌했다고 전달한다 
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            // 충돌했다면 화살을 지운다
            Destroy(gameObject);

        }
    }
}