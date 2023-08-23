using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private KeyCode input;
    [SerializeField] private float springPower;

    private HingeJoint hinge;
    private float targetReleased;
    private float targetPressed;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetReleased = hinge.limits.min;
        targetPressed = hinge.limits.max;
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;

        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetReleased;
        }

        hinge.spring = jointSpring;
    }
}
