using UnityEngine;

public class ScriptMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Transform rigTransform;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = rigTransform.position;
    }

    private void Update()
    {
        Vector3 delta =
            rigTransform.position - lastPosition;

        Vector3 horizontalDelta =
            new Vector3(delta.x, 0f, delta.z);

        float speed =
            horizontalDelta.magnitude / Time.deltaTime;

        animator.SetFloat(
            "Speed",
            speed,
            0.1f,
            Time.deltaTime
        );

        lastPosition = rigTransform.position;
    }

    public void ResetVelocity()
    {

    }
}