using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int value)
    {
        score += value;
        ScoreUIController.Instance.SetScoreUI(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
