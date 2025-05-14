using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject MenuPanel;

    public void MenuUIOpen()
    {
        Time.timeScale = 0f;
        Debug.Log("IsMenuBtn");
        MenuPanel.SetActive(true);
    }
    public void MenuUIClose()
    {
        MenuPanel.SetActive(false);
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
        MenuPanel.SetActive(false);  // 메뉴 UI 끄기
        Time.timeScale = 1f;         // 시간 되돌리기
        SceneManager.LoadScene("MainScene");
    }
}
