using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject MenuPanel;

    public void MenuUIOpen()
    {
        Debug.Log("IsMenuBtn");
        MenuPanel.SetActive(true);
    }
    public void MenuUIClose()
    {
        MenuPanel.SetActive(false);
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
}
