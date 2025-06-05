using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleGenerator : MonoBehaviour
{
    public GameObject needlePrefab;
    float span = 1.0f;
    float delta = 0;
    GameDirector director;


    // 가능한 트랙 y 좌표 (고양이와 동일한 간격)
    float[] lanes = { -4.2f, -2.8f, -1.4f, 0f, 1.4f, 2.8f, 4.2f };

    void Start()
    {
        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update()
    {
        // 점수가 10점 미만이면 아무것도 하지 않음
        if (director.GetScore() < 10) return;

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;

            GameObject go = Instantiate(needlePrefab);

            // 트랙 중 하나 선택해서 y 좌표 결정
            int index = Random.Range(0, lanes.Length);
            float py = lanes[index];

            go.transform.position = new Vector3(9f, py, 0);

            // 점수 기반 속도 설정
            int score = director.GetScore();

            float speed = 0.1f;
            if (score >= 15) speed = 0.15f;
            if (score >= 20) speed = 0.2f;
            if (score >= 30) speed = 0.3f;

            // needleController에 속도 전달
            go.GetComponent<needleController>().speed = speed;
        }
    }
}