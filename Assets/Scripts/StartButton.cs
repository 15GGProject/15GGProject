using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    [SerializeField] public GameObject menuPanel;
    public void OpenMainMenu()
    {
        menuPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void CloseMainMenu()
    {
        menuPanel.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
