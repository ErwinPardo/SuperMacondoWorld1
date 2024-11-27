using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderActivator : MonoBehaviour
{
    public int index = 0;
    public GameObject[] gameObjects;  // Array de GameObjects cuyos colliders y sprites deseas activar/desactivar
    public Sprite activeSprite;       // Sprite que se asignará al activar el collider
    public Sprite inactiveSprite;     // Sprite que se asignará al desactivar el collider

    public int[] initialCounts = { 2, 2, 2, 2, 2, 2 }; // Valores iniciales para cada escena
    private int count;
    private int sceneIndex;           // Índice de la escena actual

    void Start()
    {
        // Obtén el índice de la escena actual
        sceneIndex = int.Parse(SceneManager.GetActiveScene().name);

        // Cargar el valor de count desde PlayerPrefs o usa el valor inicial si no hay datos guardados
        LoadCounts();

        // Activar los colliders y sprites según el valor actual de count
        //ActivateColliders();
    }

    void OnApplicationQuit()
    {
        SaveCounts(false);  // Guarda al salir de la aplicación
    }

    // Método para activar los BoxColliders y cambiar el Sprite
    public void ActivateColliders()
    {
        int limit = Mathf.Clamp(count, 0, gameObjects.Length);

        for (int i = 0; i < limit; i++)
        {
            GameObject obj = gameObjects[i];
            BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            if (collider != null)
            {
                collider.enabled = true; // Activa el collider
            }

            if (i != 0 && spriteRenderer != null && activeSprite != null)
            {
                spriteRenderer.sprite = activeSprite; // Cambia el sprite
            }
        }
    }

    // Método para desactivar los BoxColliders y cambiar el Sprite
    public void DeactivateColliders()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Debug.Log("desactivando nodo: " + i);
            GameObject obj = gameObjects[i];
            BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            if (collider != null)
            {
                collider.enabled = false; // Desactiva el collider
            }

            // Solo cambiar el sprite si no es el objeto en la posición 0 del arreglo
            if (i != 0 && spriteRenderer != null && inactiveSprite != null)
            {
                spriteRenderer.sprite = inactiveSprite; // Cambia el sprite
            }
        }
    }

    public void AddCount()
    {
        if (count < index + 2 && count < gameObjects.Length)
        {
            count++;
            SaveCounts(false);  // Guarda el nuevo valor de count
            ActivateColliders(); // Re-activar colliders después de añadir el count
        }
        else
        {
            SaveCounts(true);
        }
    }

    private void SaveCounts(bool Termino)
    {
        // Cargar el array de counts de todas las escenas
        string savedData = PlayerPrefs.GetString("SceneCounts", "1,0,0,0,0,0");
        string[] countsArray = savedData.Split(',');


        if(Termino == false)
        {
            // Actualizar el valor de count para la escena actual
            countsArray[sceneIndex] = count.ToString();

        }
        else
        {
            if (int.Parse(countsArray[0]) < 6)
            countsArray[0] = (sceneIndex+2).ToString();
        }
        

        // Guardar el array actualizado en PlayerPrefs
        PlayerPrefs.SetString("SceneCounts", string.Join(",", countsArray));
        PlayerPrefs.Save();
    }

    private void LoadCounts()
    {
        // Cargar el array de counts de todas las escenas
        string savedData = PlayerPrefs.GetString("SceneCounts", "1,0,0,0,0,0");
        string[] countsArray = savedData.Split(',');

        // Establecer el valor de count según la escena actual
        if (sceneIndex == 0) // Si estamos en la escena del lobby
        {
            count = int.Parse(countsArray[sceneIndex]); // Cargar el valor guardado

            // Aumentar count en 1, asegurando que no supere un límite
            if (count < initialCounts[sceneIndex]) // Verifica que no supere el límite
            {
                count++;
            }
        }
        else // Para las otras escenas
        {
            if (int.Parse(countsArray[sceneIndex]) == 0 && initialCounts.Length > sceneIndex)
            {
                count = initialCounts[sceneIndex];  // Usa el valor inicial si es la primera vez
            }
            else
            {
                count = int.Parse(countsArray[sceneIndex]);  // Cargar el valor guardado
            }
        }
    }


}
