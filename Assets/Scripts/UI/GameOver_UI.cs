using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_UI : MonoBehaviour
{
    [Header("Game Over UI Elements")]
    public GameObject gameOverPanel;
    public Button retryButton;

    void Start()
    {
        // 게임 오버 UI는 처음엔 비활성화
        gameOverPanel.SetActive(false);

        // 버튼 이벤트 연결
        if (retryButton != null)
            retryButton.onClick.AddListener(OnRetryClicked);
    }

    // 외부에서 호출: 게임 오버 처리
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

   
    void OnRetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        
    }
}

