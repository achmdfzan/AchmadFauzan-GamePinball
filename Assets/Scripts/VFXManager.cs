using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance { get; private set; }

    [SerializeField] private GameObject vfxSource;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayVFX(Vector3 spawnPosition)
    {
        GameObject newObject = Instantiate(vfxSource, spawnPosition, Quaternion.identity);
        Destroy(newObject, 1f);
    }
}
