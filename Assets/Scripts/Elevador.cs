using UnityEngine;

public class Elevador : MonoBehaviour
{
    [SerializeField] Vector3 posicion;
    bool inside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || inside) return;

        inside = true;

        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            teleport(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        inside = false;
    }

    public void teleport(Player player)
    {
        Debug.Log("teleporting");
        player.Teleport(posicion);
    }
}