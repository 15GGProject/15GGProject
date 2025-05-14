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
        // ���� ���� UI�� ó���� ��Ȱ��ȭ
        gameOverPanel.SetActive(false);

        // ��ư �̺�Ʈ ����
        if (retryButton != null)
            retryButton.onClick.AddListener(OnRetryClicked);
    }

    // �ܺο��� ȣ��: ���� ���� ó��
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

