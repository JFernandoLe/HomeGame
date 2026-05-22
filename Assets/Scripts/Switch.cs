using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] List<GameObject> lights;
    [SerializeField] GameObject texto;

    bool inside = false;

    private void Update()
    {
        // Botón A del control derecho
        if (inside && OVRInput.GetDown(OVRInput.Button.One))
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
            {
                l.SetActive(!l.activeSelf);
            }
        }
    }

    private void ShowMessage()
    {
        texto.SetActive(true);
    }
}