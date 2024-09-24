using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Variable pública para arrastrar la escena en el Inspector

    // Función pública que cambiará a la escena definida
    public void ChangeScene(string sceneToLoad)
    {
        // Verifica si la escena no está vacía
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Cambia a la escena que se ha asignado en el Inspector
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No se ha asignado una escena para cargar.");
        }
    }
}
