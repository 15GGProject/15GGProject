using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GoldText;
    private float time = 0f;
    private int score = 0;
    private int gold = 0;
    public float HP = 0f;
    public float TotalHP = 100f;
    public Slider HPSlider;
    private void Update()
    {
        time += Time.deltaTime;
        TimeText.text = "Time : " + time.ToString("F1");
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
