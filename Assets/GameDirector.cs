using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� ����ϹǷ� ���� �ʰ� �߰��Ѵ�

public class GameDirector : MonoBehaviour
{
    public Text scoreText; // UI�� ǥ���� ���� �ؽ�Ʈ
    private float timeElapsed = 0f;
    private int score = 0;
    GameObject hpGauge;

    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        // ��: 1�ʸ��� ���� 1�� ����
        score = (int)(timeElapsed * 1);

        // �ؽ�Ʈ ����
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

}
