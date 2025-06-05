using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    public GameObject carPrefab;
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
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;

            GameObject go = Instantiate(carPrefab);//계속만들기

            // 트랙 중 하나 선택해서 y 좌표 결정
            int index = Random.Range(0, lanes.Length);
            float py = lanes[index];

            go.transform.position = new Vector3(9f, py, 0);

            // 점수 기반 속도 설정
            int score = director.GetScore();

            float speed = 0.1f;
            if (score >= 10) speed = 0.15f;
            if (score >= 15) speed = 0.2f;
            if (score >= 20) speed = 0.3f;

            // CarController에 속도 전달
            go.GetComponent<CarController>().speed = speed;
        }
    }
}