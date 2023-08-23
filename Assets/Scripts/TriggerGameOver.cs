using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;

            GameOverUI.SetActive(true);
        }
    }
}
