using UnityEngine;

public class GestorVida : MonoBehaviour
{
    public GameObject heartPrefab; 
    public Transform container;    

    public Player player;  

    void Start()
    {
        DrawHearts();
    }

    void Update()
    {
        DrawHearts();
    }

    void DrawHearts()
    {
        // 1. Borrar corazones actuales
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // 2. Crear corazones según la vida
        for (int i = 0; i < player.life; i++)
        {
            Instantiate(heartPrefab, container);
        }
    }
}