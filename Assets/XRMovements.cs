using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class XRMovements : MonoBehaviour
{
    [SerializeField] private Transform centerEyeAnchor;

    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;

    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input =
            OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 forward = centerEyeAnchor.forward;
        Vector3 right = centerEyeAnchor.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction =
            forward * input.y +
            right * input.x;

        controller.Move(direction * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}