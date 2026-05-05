using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 10;

    private CharacterController cc;
    private ScriptMovement movement;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        movement = GetComponent<ScriptMovement>();
    }

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
        cc.enabled = false;

        //  colocar los pies en el suelo (no el centro)
        transform.position = destino - new Vector3(0, cc.height / 2f, 0);

        cc.enabled = true;

        //  resetear velocidad vertical
        if (movement != null)
        {
            movement.ResetVelocity();
        }
    }
}