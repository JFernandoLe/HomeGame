using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMovement : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] InputActionReference move; // ← usamos el asset

    CharacterController characterController;
    Vector3 velocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        move.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
    }

    void Update()
    {
        Vector2 input = move.action.ReadValue<Vector2>();

        Vector3 direction = transform.right * input.x + transform.forward * input.y;

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = direction * speed + velocity;

        characterController.Move(finalMove * Time.deltaTime);
    }
}