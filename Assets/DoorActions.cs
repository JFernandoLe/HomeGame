using UnityEngine;
using UnityEngine.InputSystem;

public class DoorActions : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private InputAction action;
    bool state=false;
    private void OnEnable()
    {
        if(animator==null) animator = GetComponent<Animator>();
        if(action!=null) action.Enable();
        
    }

    private void OnDisable()
    {
        if(action!=null) action.Disable();
    }

    private void OnTriggerStay(Collider other)
    {
        if (animator != null)
        {
            if(action.WasPressedThisFrame())
            {
                state = !state;
                animator.SetBool("isActive", state);
            }
        }
    }
}
