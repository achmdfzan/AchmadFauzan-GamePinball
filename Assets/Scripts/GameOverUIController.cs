using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button homeButton;

    private void Start()
    {
        retryButton.onClick.AddListener(RetryGame);
        homeButton.onClick.AddListener(BackToMenu);
    }

    private void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
