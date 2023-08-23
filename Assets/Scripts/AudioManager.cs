using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private GameObject bumperSFXObject;
    [SerializeField] private GameObject switchSFXObject;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlayBumperSFX(Vector3 spawnPosition)
    {
        GameObject newObject = Instantiate(bumperSFXObject, spawnPosition, Quaternion.identity);
        Destroy(newObject, 1f);
    }

    public void PlaySwitchSFX(Vector3 spawnPosition)
    {
        GameObject newObject = Instantiate(switchSFXObject, spawnPosition, Quaternion.identity);
        Destroy(newObject, 1f);
    }
}
