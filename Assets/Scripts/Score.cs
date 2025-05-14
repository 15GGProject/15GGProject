using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int CurrentScore { get; private set; } = 0;
    public int BestScore { get; private set; }

    private void Awake()
    {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
    }
    public void addScore(int addScore)
    {
        CurrentScore += addScore;
    }
    public void BestScoreCurrent()
    {
        if (BestScore < CurrentScore)
        {
            PlayerPrefs.SetInt("BestScore", CurrentScore);
            BestScore = CurrentScore;
        }
    }
}
