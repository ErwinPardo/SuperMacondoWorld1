using UnityEngine;

public class ColliderActivator : MonoBehaviour
{
    public GameObject[] gameObjects;  // Array de GameObjects cuyos colliders y sprites deseas activar/desactivar
    public Sprite activeSprite;       // Sprite que se asignará al activar el collider
    public Sprite inactiveSprite;     // Sprite que se asignará al desactivar el collider
    public int count=2;



    // Método para activar los BoxColliders y cambiar el Sprite
    public void ActivateColliders()
    {
        // Limitar el conteo al tamaño del array
        int limit = Mathf.Clamp(count, 0, gameObjects.Length);
        //Debug.Log($"Activando {limit} colliders y cambiando sprites...");

        for (int i = 0; i < limit; i++)
        {
            GameObject obj = gameObjects[i];
            BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            if (collider != null)
            {
                collider.enabled = true; // Activa el collider
                //Debug.Log($"Activando collider en {obj.name}");
            }
            else
            {
                //Debug.LogWarning($"No se encontró un BoxCollider en {obj.name}");
            }

            // Solo cambiar el sprite si no es el objeto en la posición 0 del arreglo
            if (i != 0 && spriteRenderer != null && activeSprite != null)
            {
                spriteRenderer.sprite = activeSprite; // Cambia el sprite
                //Debug.Log($"Cambiando sprite en {obj.name}");
            }
            else if (i == 0)
            {
                //Debug.Log($"{obj.name} está en la posición 0, no se cambiará su sprite.");
            }
        }
    }

    // Método para desactivar los BoxColliders y cambiar el Sprite
    public void DeactivateColliders()
    {
        //Debug.Log("Desactivando colliders y cambiando sprites...");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject obj = gameObjects[i];
            BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            if (collider != null)
            {
                collider.enabled = false; // Desactiva el collider
               // Debug.Log($"Desactivando collider en {obj.name}");
            }
            else
            {
               // Debug.LogWarning($"No se encontró un BoxCollider en {obj.name}");
            }

            // Solo cambiar el sprite si no es el objeto en la posición 0 del arreglo
            if (i != 0 && spriteRenderer != null && inactiveSprite != null)
            {
                spriteRenderer.sprite = inactiveSprite; // Cambia el sprite
               // Debug.Log($"Cambiando sprite a inactivo en {obj.name}");
            }
            else if (i == 0)
            {
               // Debug.Log($"{obj.name} está en la posición 0, no se cambiará su sprite.");
            }
        }
    }

    public void AddCount(int index)
    {
       // Debug.Log("XD");
        if (count<index+2 && count<5)
        {
            
            count++;
        }
    }
}
