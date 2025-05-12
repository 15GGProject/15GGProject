using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
}
