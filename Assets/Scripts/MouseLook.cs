using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensibilidad = 100f;
    [SerializeField] Transform cuerpoJugador;
    [SerializeField] InputActionReference look;

    float rotacionX = 0f;

    void OnEnable()
    {
        look.action.Enable();
    }

    void OnDisable()
    {
        look.action.Disable();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 input = look.action.ReadValue<Vector2>();

        float mouseX = input.x * sensibilidad * Time.deltaTime;
        float mouseY = input.y * sensibilidad * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }
}