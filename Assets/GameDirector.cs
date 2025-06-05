using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가한다

public class GameDirector : MonoBehaviour
{
    public Text scoreText; // UI에 표시할 점수 텍스트
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

        // 예: 1초마다 점수 1점 증가
        score = (int)(timeElapsed * 1);

        // 텍스트 갱신
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

}
