using UnityEngine;
using UnityEngine.InputSystem;

public class DoorActions : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    [SerializeField] private InputActionReference action;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    private bool state = false;
    private bool playerInside = false;

    private void OnEnable()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (action != null)
            action.action.Enable();
    }

    private void OnDisable()
    {
        if (action != null)
            action.action.Disable();
    }

    private void Update()
    {
        if (playerInside && action != null && action.action.WasPressedThisFrame())
        {
            state = !state;
            animator.SetBool("isActive", state);

            //  sonido correcto
            if (audioSource != null)
            {
                audioSource.PlayOneShot(state ? openSound : closeSound);
            }

            Debug.Log("Cambiando estado de la puerta");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
}