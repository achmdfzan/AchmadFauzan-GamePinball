using System.Collections;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        On,
        Off,
        Blink
    }

    [SerializeField] private int score;
    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;
    [SerializeField] private Renderer planeRenderer;

    private ParticleSystem switchParticle;
    private bool isOn;
    private SwitchState currentState;

    private void Start()
    {
        isOn = false;
        currentState = SwitchState.Off;

        switchParticle = GetComponent<ParticleSystem>();
        SetMaterial(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && currentState == SwitchState.Off)
        {
            StartCoroutine(Blink(5));

            ScoreManager.Instance.AddScore(score);
            AudioManager.Instance.PlaySwitchSFX(transform.position);

            switchParticle.Play();
        }
    }

    private void SetMaterial(bool isOn)
    {
        this.isOn = isOn;

        if (isOn)
        {
            planeRenderer.material = onMaterial;
        }
        else
        {
            planeRenderer.material = offMaterial;
        }
    }

    private IEnumerator Blink(int times)
    {
        currentState = SwitchState.Blink;

        int blinkTimes = times * 2;
        
        for (int i = 0; i < blinkTimes; i++)
        {
            SetMaterial(!isOn);
            yield return new WaitForSeconds(0.1f);
        }

        SetMaterial(!isOn);

        currentState = SwitchState.On;
    }
}
