using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 defaultPosition;
    private bool onLauncher = false;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || onLauncher)
        {
            FocusAtTarget(5f);
        }
        else
        {
            GoBackToDefault();
        }
    }

    public void SetOnLauncher(bool onLauncher)
    {
        this.onLauncher = onLauncher;
    }

    public void FocusAtTarget(float distance)
    {
        Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
        Vector3 targetPosition = target.position + (targetToCameraDirection * distance);

        StartCoroutine(MovePosition(targetPosition, 0.1f));
    }

    public void GoBackToDefault()
    {
        StartCoroutine(MovePosition(defaultPosition, 0.1f));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0f, 1f, timer / time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
