using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    public static ScoreUIController Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void SetScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
