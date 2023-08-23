using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private Color color;
    [SerializeField] private float multiplier;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        GetComponentInChildren<Renderer>().material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector3 pushDirection = collision.transform.position - transform.position;
            pushDirection.y = 0;

            Rigidbody playerRB = collision.collider.GetComponent<Rigidbody>();
            playerRB.AddForce(pushDirection *  multiplier, ForceMode.Impulse);

            animator.SetTrigger("Hit");

            AudioManager.Instance.PlayBumperSFX(collision.transform.position);
            VFXManager.Instance.PlayVFX(collision.contacts[0].point);

            ScoreManager.Instance.AddScore(score);
        }
    }
}
