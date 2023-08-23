using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        creditButton.onClick.AddListener(GoToCredit);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    private void GoToCredit()
    {
        SceneManager.LoadScene(2);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
