using UnityEngine;

public class Elevador : MonoBehaviour
{
    [SerializeField] Transform puntoDestino;
    [SerializeField] float cooldown = 1f;

    float lastTeleportTime = -999f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (Time.time < lastTeleportTime + cooldown) return;

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            teleport(player);
            lastTeleportTime = Time.time;
        }
    }

    void teleport(Player player)
    {
        Debug.Log("teleporting");
        player.Teleport(puntoDestino.position);
    }
}