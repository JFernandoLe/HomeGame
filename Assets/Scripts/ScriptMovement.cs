using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2f;
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float backwardSpeed = 1.5f;
    [SerializeField] float gravity = -9.81f;

    [SerializeField] InputActionReference move;

    CharacterController characterController;
    Vector3 velocity;
    Animator animator;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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

        bool isRunning = Keyboard.current.leftShiftKey.isPressed;

        float inputMagnitude = input.magnitude;
        float currentSpeed = 0f;

        if (inputMagnitude > 0.1f)
        {
            if (input.y < -0.1f)
            {
                currentSpeed = backwardSpeed;
            }
            else
            {
                currentSpeed = isRunning ? runSpeed : walkSpeed;
            }
        }

        Vector3 direction = transform.right * input.x + transform.forward * input.y;

        characterController.Move(direction * currentSpeed * Time.deltaTime);

        if (inputMagnitude < 0.1f)
        {
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            float animationSpeed = inputMagnitude * currentSpeed;

            if (input.y < -0.1f)
            {
                animationSpeed *= -1;
            }

            animator.SetFloat("Speed", animationSpeed, 0.1f, Time.deltaTime);
        }

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    public void ResetVelocity()
    {
        velocity.y = -2f;
    }
}