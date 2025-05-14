using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI ScoreText;
    public Image Player_Profile;
    public int score = 0;
    public Slider HPSlider;
    public int BestScore = 0;
    private void Start()
    {
        SpriteRenderer playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        if (playerSpriteRenderer != null && Player_Profile != null)
        {
            Player_Profile.sprite = playerSpriteRenderer.sprite;
        }
        else
        {
            Debug.LogWarning("Player SpriteRenderer 또는 Profile Image가 연결되지 않았습니다.");
        }
        BestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

    }
    private void Update()
    {
        ScoreUI();
        HPUI();
        BestScoreUI();
    }

    private void ScoreUI()
    {
        ScoreText.text = "Score : " + score;
    }

    private void HPUI()
    {
        HPSlider.value = (player.GetComponent<Player>().currentHp / player.GetComponent<Player>().maxHp);
    }

    private void BestScoreUI()
    {
        BestScoreText.text = "BestScore : " + PlayerPrefs.GetInt("BestScore", 0);
    }
}
