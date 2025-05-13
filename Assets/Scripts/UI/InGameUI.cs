using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GoldText;
    public Image Player_Profile;
    private int score = 0;
    private int gold = 0;
    public float HP = 0f;
    public float TotalHP = 100f;
    public Slider HPSlider;

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
        BestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

    }
    private void Update()
    {
        ScoreUI();
        GoldUI();
        HPUI();
    }

    private void ScoreUI()
    {
        ScoreText.text = "Score : " + score;
    }
    private void GoldUI()
    {
        GoldText.text = "Gold : " + gold;
    }
    private void HPUI() 
    { 
        HPSlider.value = (HP/TotalHP);       
    }


}
