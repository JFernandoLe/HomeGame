using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] int force=1;

    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool inside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || inside) return;

        player.TakeDamage(force);
        inside = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        inside = false;
    }

}
