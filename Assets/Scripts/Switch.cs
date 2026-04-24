using UnityEngine;
using System.Collections.Generic;

public class Switch : MonoBehaviour
{
    [SerializeField] List<GameObject> lights;

    bool inside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || inside) return;

        inside = true;
        ToggleLights();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

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
}