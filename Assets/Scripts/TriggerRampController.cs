using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private Material rampMaterial;
    [SerializeField] private Material customGreenMaterial;

    private bool isBlinking = false;
    private bool isWhite = false;

    private void Start()
    {
        rampMaterial.color = customGreenMaterial.color;
    }

    private void OnDestroy()
    {
        rampMaterial.color = customGreenMaterial.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBlinking = true;

            changeMaterialColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBlinking = false;

            rampMaterial.color = customGreenMaterial.color;
            isWhite = false;
        }
    }

    private void changeMaterialColor()
    {
        if (isBlinking)
        {
            if (isWhite) ScoreManager.Instance.AddScore(5);
            rampMaterial.color = isWhite ? customGreenMaterial.color : Color.white;
            isWhite = !isWhite;
            Invoke("changeMaterialColor", 0.1f);
        }
    }
}