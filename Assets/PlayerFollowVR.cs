using UnityEngine;

public class PlayerFollowVR : MonoBehaviour
{
    [SerializeField] private Transform head;

    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        Vector3 targetPosition =
            new Vector3(
                head.position.x,
                transform.position.y,
                head.position.z
            );

        transform.position =
            targetPosition + offset;
    }
}