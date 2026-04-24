using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TakeDamage(int damage)
    {
        if (life > 0)
        {
            life -= damage;
        }
        Debug.Log("Vida actual: " + life);
    }
    public void Teleport(Vector3 destino)
    {
        CharacterController cc = GetComponent<CharacterController>();

        cc.enabled = false;
        transform.position = destino;
        cc.enabled = true;
    }
}
