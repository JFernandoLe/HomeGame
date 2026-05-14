using UnityEngine;

public class BodyFollowHead : MonoBehaviour
{
    [SerializeField] private Transform head;

    private void LateUpdate()
    {
        Vector3 forward = head.forward;

        forward.y = 0f;

        if (forward.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(forward);

            transform.rotation =
                Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * 5f
                );
        }
    }
}