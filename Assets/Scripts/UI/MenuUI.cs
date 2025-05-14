using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject menuPanel;
    public Score score;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;

    public void MenuUIOpen()
    {
        scoreText.text = "Score : " + score.CurrentScore;
        bestScoreText.text = "BestScore : " + PlayerPrefs.GetInt("BestScore", 0);

        Time.timeScale = 0f;
        Debug.Log("IsMenuBtn");
        menuPanel.SetActive(true);
    }
    public void MenuUIClose()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void AppExit()
    {
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
     #else
        Application.Quit();
     #endif
    }
    public void ReturnMainScene()
    {
        menuPanel.SetActive(false);  // 메뉴 UI 끄기
        Time.timeScale = 1f;         // 시간 되돌리기
        SceneManager.LoadScene("MainScene");
    }
}
