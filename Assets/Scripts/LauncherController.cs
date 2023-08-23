using TMPro;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private KeyCode input;
    [SerializeField] private Transform cylinder;
    [SerializeField] private float launchForce;
    [SerializeField] private TextMeshProUGUI instructionText;

    private GameObject player;
    private float minPositionZ;
    private float maxPositionZ;
    private float chargeMultiplier;
    private bool isCharging;
    private bool hasLaunched = false;

    private void Start()
    {
        maxPositionZ = cylinder.position.z;
        minPositionZ = cylinder.position.z - 2f;

        Invoke("activateLaunchText", 1f);
    }

    private void activateLaunchText()
    {
        if (!hasLaunched)
        {
            instructionText.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(input))
        {
            isCharging = true;

            instructionText.gameObject.SetActive(false);
        }
        else if (Input.GetKeyUp(input))
        {
            isCharging = false;

            if (player != null)
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.forward * launchForce * chargeMultiplier, ForceMode.Impulse);

                hasLaunched = true;
            }

            chargeMultiplier = 0;
        }

        if (isCharging)
        {
            if (cylinder.position.z > minPositionZ)
            {
                cylinder.position += Vector3.back * Time.deltaTime * 2.5f;
                chargeMultiplier = (maxPositionZ - cylinder.position.z) * 0.5f;
            }
            else
            {
                cylinder.position = new Vector3(cylinder.position.x, cylinder.position.y, minPositionZ);
                chargeMultiplier = 1f;
            }
        }
        else
        {
            if (cylinder.position.z < maxPositionZ)
            {
                cylinder.position += Vector3.forward * Time.deltaTime * 25f;
            }
            else
            {
                cylinder.position = new Vector3(cylinder.position.x, cylinder.position.y, maxPositionZ);
            }
        }

        if (hasLaunched)
        {
            instructionText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;

            Camera.main.GetComponent<CameraController>().SetOnLauncher(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;

            Camera.main.GetComponent<CameraController>().SetOnLauncher(false);
        }
    }
}
