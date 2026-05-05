using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch : MonoBehaviour
{
    [SerializeField] List<GameObject> lights;
    [SerializeField] GameObject texto;
    [SerializeField] InputActionReference actionE;

    bool inside = false;

    private void OnEnable()
    {
        if (actionE != null)
            actionE.action.Enable();
    }

    private void OnDisable()
    {
        if (actionE != null)
            actionE.action.Disable();
    }

    private void Update()
    {
        if (inside && actionE.action.triggered)
        {
            ToggleLights();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || inside) return;
        Debug.Log("Entro");
        inside = true;
        ShowMessage();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        texto.SetActive(false);
        inside = false;
    }

    private void ToggleLights()
    {
        foreach (GameObject l in lights)
        {
            if (l != null)
                l.SetActive(!l.activeSelf);
        }
    }

    private void ShowMessage()
    {
        texto.SetActive(true);
    }
}