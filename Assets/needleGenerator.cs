using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleGenerator : MonoBehaviour
{
    public GameObject needlePrefab;
    float span = 1.0f;
    float delta = 0;
    GameDirector director;


    // ������ Ʈ�� y ��ǥ (����̿� ������ ����)
    float[] lanes = { -4.2f, -2.8f, -1.4f, 0f, 1.4f, 2.8f, 4.2f };

    void Start()
    {
        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update()
    {
        // ������ 10�� �̸��̸� �ƹ��͵� ���� ����
        if (director.GetScore() < 10) return;

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;

            GameObject go = Instantiate(needlePrefab);

            // Ʈ�� �� �ϳ� �����ؼ� y ��ǥ ����
            int index = Random.Range(0, lanes.Length);
            float py = lanes[index];

            go.transform.position = new Vector3(9f, py, 0);

            // ���� ��� �ӵ� ����
            int score = director.GetScore();

            float speed = 0.1f;
            if (score >= 15) speed = 0.15f;
            if (score >= 20) speed = 0.2f;
            if (score >= 30) speed = 0.3f;

            // needleController�� �ӵ� ����
            go.GetComponent<needleController>().speed = speed;
        }
    }
}